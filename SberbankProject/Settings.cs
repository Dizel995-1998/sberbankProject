using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace SberbankProject
{
	public class Settings
    {
		[JsonProperty("server_ip")]
		public string serverIP;
		[JsonProperty("serial_port_name")]
		public string serialPortName;
		[JsonProperty("server_port")]
		public int serverPort;
		[JsonProperty("time_out_sms")]
		public int timeOutSMS;

		public Settings()
        {
			this.serverIP = "127.0.0.1";
			this.serverPort = 80;
			this.serialPortName = "COM1";
			this.timeOutSMS = 500;
		}
	}

	public static class SettingsManager
	{
		/* Метод возвращающий обьект класса Settings с конфигурацией из файла, либо дефолтный обьект если файла нет */
		public static Settings loadConfigFromFile(string path)
        {
			Settings config = null;
			
			using (Stream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
				if (stream.Length > 0) 
				{
					byte[] arJson = new byte[stream.Length];
					stream.Read(arJson, 0, (int) stream.Length);
					config = JsonConvert.DeserializeObject<Settings>(Encoding.Default.GetString(arJson));
				} else 
				{
					config = new Settings();
                }
				return config;
            }
        }

		public static void saveConfig(string path, Settings config)
        {
			using (Stream stream = new FileStream(path, FileMode.Open))
			{
				byte[] arJsonByte = Encoding.Default.GetBytes(JsonConvert.SerializeObject(config));
				stream.Write(arJsonByte, 0, arJsonByte.Length);
			}
        }
	}
}