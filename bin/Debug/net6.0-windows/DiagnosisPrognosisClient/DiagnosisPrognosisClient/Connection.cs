using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace DiagnosisPrognosisClient
{
	internal static class ConnectServer
	{
		private static bool searchProcess(string ProcessName)
		{
			IEnumerable<Process> chromeDriverProcesses = Process.GetProcesses().
				Where(pr => pr.ProcessName == ProcessName);
			foreach (Process process in chromeDriverProcesses)
			{
				Debug.WriteLine(process.ProcessName);
				return true;
			}
			return false;
		}

		public static void PrintProcess()
		{
			IEnumerable<Process> chromeDriverProcesses = Process.GetProcesses().
				Where(pr => pr.ProcessName == "DiagnosisPrognosis");
			foreach (Process process in chromeDriverProcesses)
			{
				Debug.WriteLine(process.ProcessName);
			}
		}

		public static void searchIpAddresses()
		{
			string host = Dns.GetHostName();
			IPAddress[] IP = Dns.GetHostAddresses(host);
			foreach (IPAddress ip in IP)
			{
				if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
				{
					Debug.WriteLine(ip.ToString());
				}
			}
		}

		internal static bool checkServer()
		{
			
			if (searchProcess("DiagnosisPrognosis"))
			{
				MessageBox.Show("Server is now running!", "Server is running");
				return true;
			}
			DialogResult dlgResult = MessageBox.Show("Server is not running. Launch server now?", "Server has walked", MessageBoxButtons.YesNo);
			if (dlgResult == DialogResult.No)
			{
				return false;
			}

			string programStr = @"C:\Users\Rivera\source\repos\FacundoDayne\DiagnosisPrognosis\bin\Debug\net6.0-windows\DiagnosisPrognosis.exe";
			string relativeProgramStr = @"..\..\..\..\..\DiagnosisPrognosis.exe";

			MessageBox.Show(Environment.ProcessPath);

			
			Process proc = System.Diagnostics.Process.Start(relativeProgramStr, "192.168.0.30");

			int numberOfAttempts = 0;
			while (numberOfAttempts <= 10)
			{
				if (searchProcess("DiagnosisPrognosis"))
				{
					MessageBox.Show("Server is now running!", "Server is running");
					return true;
				}
				numberOfAttempts++;

				Thread.Sleep(500);
			}
			MessageBox.Show("Server failed to run", "Server has walked.");
			
			
			return false;
		}

		public static bool CheckServerSuccess()
		{
			List<string> receivedReply = ReceiveConfirmation();
			string singleString = "";
			foreach (string x in receivedReply)
			{
				singleString = singleString + x;
			}
			return false;
		}

		public static void AskIP()
		{
			StartClient("ippadd");
		}

		public static List<string> AskPatientTable()
		{
			string request = "<TOK>tempToken<EOT><IPP>ip:port<EOI><AUT>tempUser<AUT>tempPass<EOA><INS>patientTable<EOC>";
			return StartClient(request);
		}

		public static List<string> AskPatientInfo(int ID)
		{
			string request = $"<TOK>tempToken<EOT><IPP>ip:port<EOI><AUT>tempUser<AUT>tempPass<EOA><INS>patientInfo<EOC><DAT>{ID}<EOD>";
			return StartClient(request);
		}

		public static List<string> AskAddPatient(string Data)
		{
			string request = $"<TOK>tempToken<EOT><IPP>ip:port<EOI><AUT>tempUser<AUT>tempPass<EOA><INS>addPatient<EOC><DAT>{Data}<EOD>";
			return StartClient(request);
		}

		static byte[] bytes;
		static public Socket sender;
		static IPEndPoint remoteEP;

		public static List<string> StartClient(string message)
		{
			bytes = new byte[1024];
			List<string> receivedReply = new List<string>();
			try
			{

				IPAddress ipAddress = IPAddress.Parse("192.168.0.30");
				Console.WriteLine(ipAddress.ToString());
				remoteEP = new IPEndPoint(ipAddress, 11000);

				sender = new Socket(ipAddress.AddressFamily,
					SocketType.Stream, ProtocolType.Tcp);

				try
				{
					int conncectionAttempts = 0;
					while (conncectionAttempts <= 10)
					{
						sender.Connect(remoteEP);
						if (sender.Connected)
						{
							break;
						}
						conncectionAttempts++;
					}
					if (conncectionAttempts > 10)
					{
						receivedReply.Add("Failed");
						return receivedReply;
					}

					Debug.WriteLine("Socket connected to " +
						sender.RemoteEndPoint.ToString());

					byte[] msg = Encoding.ASCII.GetBytes(message + "<EOF>");

					int bytesSent = sender.Send(msg);

					while (true)
					{
						int bytesRec = sender.Receive(bytes);
						string dataRec = Encoding.ASCII.GetString(bytes, 0, bytesRec);

						receivedReply.Add(dataRec);

						Debug.WriteLine("Received = " +
							dataRec);

						if (dataRec.IndexOf("<EOF>") > -1)
						{
							break;
						}
					}
				}
				catch (ArgumentNullException ane)
				{
					Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
					closeConn();
				}
				catch (SocketException se)
				{
					Console.WriteLine("SocketException : {0}", se.ToString());
					closeConn();
				}
				closeConn();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
				closeConn();
			}

			Debug.WriteLine("Reply");
			foreach (string x in receivedReply)
			{
				Debug.WriteLine(x);
			}
			return receivedReply;
		}

		public static List<string> ReceiveConfirmation()
		{
			bytes = new byte[1024];
			List<string> receivedReply = new List<string>();
			try
			{

				IPAddress ipAddress = IPAddress.Parse("192.168.0.30");
				Console.WriteLine(ipAddress.ToString());
				remoteEP = new IPEndPoint(ipAddress, 11000);

				sender = new Socket(ipAddress.AddressFamily,
					SocketType.Stream, ProtocolType.Tcp);

				try
				{
					sender.Connect(remoteEP);

					Debug.WriteLine("Socket connected to " +
						sender.RemoteEndPoint.ToString());

					while (true)
					{
						int bytesRec = sender.Receive(bytes);
						string dataRec = Encoding.ASCII.GetString(bytes, 0, bytesRec);

						receivedReply.Add(dataRec);

						Debug.WriteLine("Received = " +
							dataRec);

						if (dataRec.IndexOf("<EOF>") > -1)
						{
							break;
						}
					}
				}
				catch (ArgumentNullException ane)
				{
					Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
					closeConn();
				}
				catch (SocketException se)
				{
					Console.WriteLine("SocketException : {0}", se.ToString());
					closeConn();
				}
				closeConn();
			} catch (SocketException sx)
			{
				Console.WriteLine("Error");
			}

			Debug.WriteLine("Reply");
			foreach (string x in receivedReply)
			{
				Debug.WriteLine(x);
			}
			return receivedReply;
		}

		public static void closeConn()
		{
			if (sender != null)
			{
				try
				{
					sender.Shutdown(SocketShutdown.Both);
					sender.Close();
					sender = null;
				} catch (SocketException ex)
				{
					Console.WriteLine("SocketException : {0}", ex.ToString());
				}
			}
		}

		public static string[] GetData(List<String> data, string[] ends)
		{
			string fullString = "";
			foreach(string x in data)
			{
				fullString = fullString + x;
			}
			//string[] cutString = fullString.Split(ends, StringSplitOptions.RemoveEmptyEntries);
			//return cutString[0];

			//////
			string[] separator = { "<TOK>", "<IPP>", "<AUT>", "<INS>", "<DAT>", "<EOF>", "<EOT>", "<EOI>", "<EOA>", "<EOC>", "<EOD>" };
			//string line = "<TOK>TestToken<EOI><IPP>10.10.10.10:11100<EOI><REQ>%Bet%askfhkasjfgkjasg%Bet%%Bet%llllriwui%Bet%<REQ><EOF>";
			string[] extracted = fullString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			List<string> noSpaces = new List<string>();
			foreach (string x in extracted)
			{
				if (x != "")
				{
					noSpaces.Add(x);
				}
			}

			Debug.WriteLine("YU");
			string[] tocut = null;
			foreach (string x in noSpaces)
			{
				if (x.IndexOf(ends[0]) > -1)
				{
					Debug.WriteLine("SU");
					tocut = x.Split(ends, StringSplitOptions.RemoveEmptyEntries);
					return tocut;
				}
			}
			Debug.WriteLine("PU");
			return null;
		}
	}
}
