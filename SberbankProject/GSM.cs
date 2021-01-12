using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading;

namespace SberbankProject
{
    public class GSM
    {
        private SerialPort serialPort;

        public GSM(string serialPortName)
        {
            serialPort = new SerialPort(serialPortName, 9600, Parity.None, 8);
            serialPort.NewLine = "\r\n";
            serialPort.Open();
            //serialPort.DataReceived += new SerialDataReceivedEventHandler(ReceivedDataEvent);

            string[] initCommands = {"AT", "AT+CMGF=1", "AT+CSCS=UCS2", "AT+CNMI=2,1,0,0", "ATE0"};

            foreach (string command in initCommands)
            {
                Thread.Sleep(500);
                serialPort.WriteLine(command);
                serialPort.ReadLine();
            }
        }

        /// Возвращает ID сообщения которое пришло
        public int waitSMS()
        {
            while (true)
            {
                string incomingSMS = serialPort.ReadLine();
                string regularPattern = @"^\+CMTI:\D*(?<smsID>\d*)";

                if (Regex.IsMatch(incomingSMS, regularPattern))
                {
                    Match match = Regex.Match(incomingSMS, regularPattern);
                    return Convert.ToInt32(match.Groups["smsID"].Value);
                }
            }
        }

        public void readSMS(int smsID, ref string phoneNumber, ref string smsText)
        {
            serialPort.WriteLine("AT+CMGR=" + smsID);
            serialPort.ReadLine(); // CRLF

            phoneNumber = serialPort.ReadLine();
            smsText = decodeSMS(serialPort.ReadLine());

            string patternNumber = @",""(?<phone>.+)"",,";

            if (Regex.IsMatch(phoneNumber, patternNumber))
            {
                Match match = Regex.Match(phoneNumber, patternNumber);
                phoneNumber = decodeSMS(match.Groups["phone"].Value);
            }
        }

        public void deleteSMS(int smsIndex)
        {

        }

        public void callNumber(string number)
        {
            serialPort.WriteLine("ATD+" + number + ";");
        }

        public int getLevelSignal()
        {
            serialPort.WriteLine("AT+CSQ");
            string data = serialPort.ReadLine();
            string pattern = @"\+CSQ: (?<signalLevel>\d*)";
            
            if (Regex.IsMatch(data, pattern))
            {
                Match match = Regex.Match(data, pattern);
                return Convert.ToInt32(match.Groups["signalLevel"].Value);
            }
            return 0;
        }

        public string decodeSMS(string text)
        {
            try
            {
                byte[] buf = new byte[text.Length / 2];
                for (int i = 0; i < text.Length; i += 2)
                {
                    buf[i / 2] = Convert.ToByte(text.Substring(i, 2), 16);
                }
                return Encoding.BigEndianUnicode.GetString(buf);
            }
            catch
            {
                return "Ошибка определения номера";
            }
        }

        public void writeSMS(string number, string text)
        {

        }

        public void closePort()
        {
            serialPort.DiscardInBuffer();
            serialPort.DiscardOutBuffer();
            serialPort.Close();
        }
    }
}
