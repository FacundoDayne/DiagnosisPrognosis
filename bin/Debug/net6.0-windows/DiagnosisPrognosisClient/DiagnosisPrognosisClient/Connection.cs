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

		internal static bool checkServer(string ipadd)
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

			
			Process proc = System.Diagnostics.Process.Start(relativeProgramStr, ipadd);

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

		public static byte CheckServerSuccess()
		{
			List<string> receivedReply = AskDatabaseOpened();
			string singleString = "";
			foreach (string x in receivedReply)
			{
				singleString = singleString + x;
			}
			if (singleString.IndexOf("!dbISopen!") > -1)
			{
				return 2;
			}
			else if (singleString.IndexOf("!failed!") > -1)
			{
				return 1;
			}
			return 0;
		}

		public static byte TryLogin(string username, string password)
		{
			string request = $"<TOK>tempToken<EOT><IPP>ip:port<EOI><AUT>{username}<AUT>{password}<EOA><INS>requestLogin<EOC>";
			List<string> receivedReply = StartClient(request);
			string singleString = "";
			string[] data = GetData(receivedReply);
			foreach (string x in receivedReply)
			{
				singleString = singleString + x;
			}

			if (singleString.IndexOf("!Success!") > -1)
			{
				Transfer.userid = Convert.ToInt32(data[3]); Debug.WriteLine(data[3]);
				Transfer.usertype = Convert.ToInt32(data[4]); Debug.WriteLine(data[4]);
				return 3;
			}
			else if (singleString.IndexOf("!usernamefail!") > -1)
			{
				return 1;
			}
			else if (singleString.IndexOf("!passwordfail!") > -1)
			{
				return 2;
			}
			return 0;
		}

		public static void AskIP()
		{
			StartClient("ippadd");
		}

		public static List<string> AskDatabaseOpened()
		{
			string request = "<TOK>tempToken<EOT><IPP>ip:port<EOI><AUT>tempUser<AUT>tempPass<EOA><INS>checkDbIsOpen<EOC>";
			return StartClient(request);
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

		public static List<string> AskUpdatePatient(string Data)
		{
			string request = $"<TOK>tempToken<EOT><IPP>ip:port<EOI><AUT>tempUser<AUT>tempPass<EOA><INS>updatePatient<EOC><DAT>{Data}<EOD>";
			return StartClient(request);
		}

		public static List<string> AskSexCourse()
		{
			string request = $"<TOK>tempToken<EOT><IPP>ip:port<EOI><AUT>tempUser<AUT>tempPass<EOA><INS>sexCourseInfo<EOC>";
			return StartClient(request);
		}

		public static List<string> AskPatientAllInfo(int ID)
		{
			string request = $"<TOK>tempToken<EOT><IPP>ip:port<EOI><AUT>tempUser<AUT>tempPass<EOA><INS>patientAllInfo<EOC><DAT>{ID}<EOD>";
			return StartClient(request);
		}

		public static List<string> AskSexCoursePatientAllInfo(int ID)
		{
			string request = $"<TOK>tempToken<EOT><IPP>ip:port<EOI><AUT>tempUser<AUT>tempPass<EOA><INS>patientAllInfoSC<EOC><DAT>{ID}<EOD>";
			return StartClient(request);
		}

		public static List<string> AskSymptomTable()
		{
			string request = $"<TOK>tempToken<EOT><IPP>ip:port<EOI><AUT>tempUser<AUT>tempPass<EOA><INS>requestSymptoms<EOC>";
			return StartClient(request);
		}

		public static List<string> SubmitSymptoms(List<int> symptomIds)
		{
			string ids = "%GetIllnesses%";
			foreach (int x in symptomIds)
			{
				ids += x + "%GetIllnesses%";
			}
			string request = $"<TOK>tempToken<EOT><IPP>ip:port<EOI><AUT>tempUser<AUT>tempPass<EOA><INS>GetIllnesses<EOC><DAT>" + ids + "<EOD>";
			return StartClient(request);
		}

		public static List<string> SubmitDiagnosis(string symptoms, string illness)
		{
			string request = $"<TOK>tempToken<EOT><IPP>ip:port<EOI><AUT>tempUser<AUT>tempPass<EOA><INS>SaveDiagnosis<EOC><DAT>" + Transfer.userid + "%Diagnosis%" + symptoms + "%Diagnosis%" + illness + "<EOD>";
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
					sender.SendTimeout = 30;
					Debug.WriteLine("Socket connected to " +
						sender.RemoteEndPoint.ToString());

					while (true)
					{
						byte[] msg = Encoding.ASCII.GetBytes("?isDBon?<EOF>");
						sender.Send(msg);
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

		public static string[] GetData(List<String> data)
		{
			string fullString = "";
			foreach (string x in data)
			{
				fullString = fullString + x;
			}
			string[] separator = { "<TOK>", "<IPP>", "<AUT>", "<INS>", "<DAT>", "<EOF>", "<EOT>", "<EOI>", "<EOA>", "<EOC>", "<EOD>" };
			
			string[] extracted = fullString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			List<string> noSpaces = new List<string>();
			
			foreach (string x in extracted)
			{
				if (x != "")
				{
					noSpaces.Add(x);
				}
			}
			string[] outp = noSpaces.ToArray();
			return outp;
		}
	}
}
