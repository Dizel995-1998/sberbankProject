using System;

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
		}
	}
}