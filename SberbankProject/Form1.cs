using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using SuperWebSocket;
using System.Runtime.InteropServices;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Threading;

namespace SberbankProject
{
    public partial class mainForm : Form
    {
        private delegate void writeLineSocketLogs(string line);
        private delegate void writeLineGsmLogs(string line);

        protected WebSocketServer webSocketServer = new WebSocketServer();
        protected Settings config;
        protected GSM gsmModem;
        protected Thread gsmThread;
        protected string pathToConfigFile = @"G:\\settings.txt";

        public mainForm()
        {
            InitializeComponent();
            comboBoxSerialPort.Items.AddRange(SerialPort.GetPortNames());
            config = SettingsManager.loadConfigFromFile(pathToConfigFile);
            gsmThread = new Thread(threadWorkGSM);
            gsmThread.Start();
            gsmThread.Suspend();

            textBoxServerIP.Text = config.serverIP;
            comboBoxSerialPort.Text = config.serialPortName;
            textBoxServerPort.Text = Convert.ToString(config.serverPort);
            textBoxTimeOut.Text = Convert.ToString(config.timeOutSMS);

            webSocketServer.NewSessionConnected += WsServer_NewSessionConnected;
            webSocketServer.NewMessageReceived += WsServer_NewMessageReceived;
            webSocketServer.NewDataReceived += WsServer_NewDataReceived;
            webSocketServer.SessionClosed += WsServer_SessionClosed;
            webSocketServer.Setup(config.serverIP, config.serverPort);
        }

        private void writeGsmLogs(string line)
        {
            textBoxGsmLogs.Text += line + "\r\n";
        }

        private void writeSocketLogs(string line)
        {
            textBoxWebSocketLogs.Text += line + "\r\n";
        }

        private void buttonApplicationStart_Click(object sender, EventArgs e)
        {
            if (!this.validateSettingsForms())
            {
                MessageBox.Show("Некорректно заполнены поля");
                return;
            }

            config.serialPortName = comboBoxSerialPort.Text;
            config.serverIP = textBoxServerIP.Text;
            config.serverPort = Convert.ToInt32(textBoxServerPort.Text);
            config.timeOutSMS = Convert.ToInt32(textBoxTimeOut.Text);

            if (!webSocketServer.Start()) {
                MessageBox.Show("Не удалось открыть веб-сокет сервер на указанном порту");
                webSocketServer.Stop();
                return;
            }

            try {
                gsmModem = new GSM(config.serialPortName);
            } catch {
                MessageBox.Show("Не удалось открыть последовательный порт");
                webSocketServer.Stop();
                return;
            }
            // Запрещаем пользователю повторно нажимать на кнопку если работа уже начата
            buttonApplicationStart.Enabled = false;
            gsmThread.Resume();
        }

        public void threadWorkGSM()
        {
            string phoneNumber = "", textSMS = "";
            int smsID = gsmModem.waitSMS();
            gsmModem.readSMS(smsID, ref phoneNumber, ref textSMS);
            BeginInvoke(new writeLineGsmLogs(writeGsmLogs), "phoneNumber: " + phoneNumber);
            BeginInvoke(new writeLineGsmLogs(writeGsmLogs), "textSMS: " + textSMS);
        }

        private  void WsServer_SessionClosed(WebSocketSession session, SuperSocket.SocketBase.CloseReason value)
        {
            BeginInvoke(new writeLineSocketLogs(writeSocketLogs), "Сессия завершена");
        }

        private  void WsServer_NewDataReceived(WebSocketSession session, byte[] value)
        {
            BeginInvoke(new writeLineSocketLogs(writeSocketLogs), "Получены новые данные от клиента");
        }

        private void WsServer_NewMessageReceived(WebSocketSession session, string value)
        {
            BeginInvoke(new writeLineSocketLogs(writeSocketLogs), "Получен запрос от клиента: " + value);
        }

        private void WsServer_NewSessionConnected(WebSocketSession session)
        {
            BeginInvoke(new writeLineSocketLogs(writeSocketLogs), "Подключился клиент");
        }

        private void buttonApplicationEnd_Click(object sender, EventArgs e)
        {
            gsmThread.Suspend();
            webSocketServer.Stop();
            gsmModem.closePort();
            buttonApplicationStart.Enabled = true;
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            this.config.serialPortName = comboBoxSerialPort.Text;
            this.config.serverIP = textBoxServerIP.Text;
            this.config.serverPort = Convert.ToInt32(textBoxServerPort.Text);
            this.config.timeOutSMS = Convert.ToInt32(textBoxTimeOut.Text);

            SettingsManager.saveConfig(this.pathToConfigFile, this.config);
        }

        private bool validateSettingsForms()
        {
            string patternIPaddress = @"^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$";
            if (!Regex.IsMatch(textBoxServerIP.Text, patternIPaddress))
            {
                return false;
            }

            if (Convert.ToInt32(textBoxServerPort.Text) < 0 || Convert.ToInt32(textBoxServerPort.Text) > 65536 )
            {
                return false;
            }

            if (Convert.ToInt32(textBoxTimeOut.Text) < 0)
            {
                return false;
            }

            if (String.IsNullOrEmpty(textBoxServerPort.Text))
            {
                return false;
            }

            return true;
        }
    }
}
