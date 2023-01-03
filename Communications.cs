using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;

namespace DiagnosisPrognosis
{
	internal static class Communications
	{
		static string _ip = "";
		static string _port = "";
		static Queue<string> _outgoingMessages = new Queue<string>();
		static Queue<string> _request = new Queue<string>();

		public static void StartServer(string setIpAddress)
		{
			Transfer.SetDatabaseFileName(@"\SafeDP_Database.mdf");
			Transfer.SetDatabasePath();
			Transfer.SetDatabaseConnection();

			try
			{
				Transfer.SetDatabaseConnection();
				Transfer.DatabaseConnection.Open();

			} catch (SqlException sqlex)
			{
				Console.WriteLine("SQL Exception: Couldn't connect to SQL Database. Terminating Server.");
				Console.WriteLine(sqlex.Message);
				return;
			}

			IPAddress ipAddress = IPAddress.Parse("192.168.0.30");
			int port = 11000;

			_ip = setIpAddress;
			_port = port.ToString();

			Console.WriteLine(ipAddress.ToString());
			IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

			try
			{
				Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

				listener.Bind(localEndPoint);

				Socket handler;
				bool continueCommunications = true;
				Console.WriteLine("Waiting for a connection...");
				while (true)
				{

					Console.WriteLine("Listening...");
					listener.Listen(10);
					handler = listener.Accept();

					string data = null;
					byte[] bytes = null;

					while (true)
					{
						bytes = new byte[1024];
						int bytesRec = handler.Receive(bytes);
						data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

						// Insert data output

						// The data format should be:
						// "id <ID> ip:port <IPP> user <USR> pass <EOU> sqluser <AUT> sqlpass <EOA> command <CMD> value <Data> value <Data> value <Data> value <EOF> "
						// id = identify if data belongs to server
						// user = program user
						// pass = program password
						// sqluser = sql user
						// sqlpass = sql password
						// command = what to do with data
						// value = sql parameters
						//

						SplitData(data);

						if (data.IndexOf("<EOF>") > -1)
						{
							break;
						}
					}
					Console.WriteLine("Txt received : {0}", data);

					byte[] msg = Encoding.ASCII.GetBytes(data);

					if (_outgoingMessages.Count != 0)
					{
						while (_outgoingMessages.Count != 0)
						{
							string req = "%" + _request.Dequeue() + "%";
							string message = _outgoingMessages.Dequeue();
							byte[] outgoingMessage = Encoding.ASCII.GetBytes(message);
							handler.Send(outgoingMessage);
							Console.WriteLine(outgoingMessage);
						}
					}
					
					msg = Encoding.ASCII.GetBytes("<EOF>");
					handler.Send(msg);

					if (!continueCommunications)
					{
						break;
					}

					
				}
				handler.Shutdown(SocketShutdown.Both);
				handler.Close();
			}
			catch (SocketException ex)
			{
				Console.WriteLine(ex.ToString());
			}

			Transfer.DatabaseConnection.Close();

			Console.WriteLine("\n Press any key to continue");
			Console.ReadKey();

		}

		private static void sendData(string data)
		{

		}

		private static void SplitData(string data)
		{
			string[] splitString = { "<TOK>", "<IPP>", "<AUT>", "<INS>", "<DAT>" , "<EOF>" ,
									"<EOT>" , "<EOI>" , "<EOA>", "<EOC>" , "<EOD>" };
			string[] splitData = data.Split(splitString, StringSplitOptions.None);
			List<string> cutData = new List<string>();
			foreach (string x in splitData)
			{
				if (x != "")
				{
					cutData.Add(x);
				}
			}

			// Result:
			// {
			// id
			// user<USR>pass
			// sqluser<AUT>sqlpass
			// command
			// value<DATA>value<DATA>value...<EOF>
			// }

			for (int x = 0; x < cutData.Count; x++)
			{
				Console.WriteLine(x + " " + cutData[x]);
			}

			Console.WriteLine("Helvete");

			if (cutData.Count == 0)
			{
				Console.WriteLine("Received Nothing");
				return;
			}

			for (int x = 0; x < cutData.Count; x++)
			{
				Console.WriteLine($"[{x}] : {cutData[x]}");
			}

			switch (cutData[4])
			{
				case "ippadd":
					Console.WriteLine("Received IP Request");
					_request.Enqueue(cutData[4]);
					_outgoingMessages.Enqueue(returnAddress());
					break;
				case "patientTable":
					Console.WriteLine("Received Patient Table Request");
					_request.Enqueue(cutData[4]);
					_outgoingMessages.Enqueue(requestPatientTable());
					break;
				case "patientInfo":
					Console.WriteLine("Received Patient Information Request");
					_request.Enqueue(cutData[4]);
					_outgoingMessages.Enqueue(requestPatientInfo(Convert.ToInt32(cutData[5])));
					break;
			}
		}

		private static string returnAddress()
		{
			string ipAddPort = _ip + ":" + _port;
			return ipAddPort;
		}

		private static byte[] ConvertDataSetToBytes(DataSet UnconvertedDataSet)
		{
			byte[] ConvertedDataSet = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				BinaryFormatter formatter = new BinaryFormatter();
				UnconvertedDataSet.RemotingFormat = SerializationFormat.Binary;
				formatter.Serialize(memoryStream, UnconvertedDataSet);
				ConvertedDataSet = memoryStream.ToArray();
			}
			return ConvertedDataSet;
		}

		private static string ByteArrayToString(byte[] byteArray)
		{
			string OutputString = "";
			for (int x = 0; x < byteArray.Length; x++)
			{
				OutputString = OutputString + byteArray[x];
				if (x != (byteArray.Length - 1))
				{
					OutputString = OutputString + ".";
				}
			}
			return OutputString;
		}
		
		private static string requestPatientTable()
		{
			string OutputString = $"<TOK>TestToken<EOI><IPP>{_ip}:{_port}<EOI><DAT>";
			using (SqlDataAdapter datad = new SqlDataAdapter("SELECT patient_id AS 'ID', CONCAT(patient_lastname, ', ', patient_firstname, ' ', SUBSTRING(patient_middlename, 1, 1)) AS 'Name' FROM PatientTable", Transfer.DatabaseConnection))
			{
				SqlCommandBuilder scmd = new SqlCommandBuilder(datad);
				DataSet PatientDataSet = new DataSet();
				datad.Fill(PatientDataSet);

				byte[] PatientDataSetBytes = ConvertDataSetToBytes(PatientDataSet);
				OutputString = OutputString + "%patientTable%" + ByteArrayToString(PatientDataSetBytes) + "%patientTable%";
			}
			using (SqlDataAdapter datad = new SqlDataAdapter("SELECT patient_id AS 'ID', CONCAT(patient_lastname, ', ', patient_firstname, ' ', SUBSTRING(patient_middlename, 1, 1)) AS 'Name' FROM PatientTable", Transfer.DatabaseConnection))
			{
				SqlCommandBuilder scmd = new SqlCommandBuilder(datad);
				DataSet PatientDataSet = new DataSet();
				datad.Fill(PatientDataSet);

				byte[] PatientDataSetBytes = ConvertDataSetToBytes(PatientDataSet);
				OutputString = OutputString + "%patientTable%" + ByteArrayToString(PatientDataSetBytes) + "%patientTable%";
			}
			if (Transfer.DatabaseConnection.State == ConnectionState.Closed)
			{
				Transfer.SetDatabaseConnection();
				Transfer.DatabaseConnection.Open();
			}
			OutputString = OutputString + "<EOD>";
			return OutputString;
		}

		private static string requestPatientInfo(int PatientID)
		{
			
			string OutputString = $"<TOK>TestToken<EOI><IPP>{_ip}:{_port}<EOI><DAT>%patientInfo%";
			using (SqlCommand scmd = new SqlCommand("SELECT a.patient_id, CONCAT(a.patient_lastname, ', ', a.patient_firstname, ' ', SUBSTRING(a.patient_middlename, 1, 1)) AS 'Name', a.patient_age AS 'Age', c.sex_name as 'Sex', b.course_name AS 'Course' FROM PatientTable a INNER JOIN CourseTable b ON a.patient_course_id = b.course_id INNER JOIN SexTable c ON c.sex_id = a.patient_sex_id WHERE a.patient_id = @cID", Transfer.DatabaseConnection))
			{
				scmd.Parameters.AddWithValue("@cID", SqlDbType.Int).Value = PatientID;
				SqlDataReader sread = scmd.ExecuteReader();
				while (sread.Read())
				{
					OutputString = OutputString + sread.GetString(1) + "%patientInfo%";
					OutputString = OutputString + Convert.ToString(sread.GetInt32(2)) + "%patientInfo%";
					OutputString = OutputString + sread.GetString(3) + "%patientInfo%";
					OutputString = OutputString + sread.GetString(4) + "%patientInfo%";
				}
				sread.Close();
			}
			if (Transfer.DatabaseConnection.State == ConnectionState.Closed)
			{
				Transfer.SetDatabaseConnection();
				Transfer.DatabaseConnection.Open();
			}
			OutputString = OutputString + "<EOD>";
			return OutputString;
		}

		private static string requestSexCourseInfo ()
		{
			string OutputString = $"<TOK>TestToken<EOI><IPP>{_ip}:{_port}<EOI><DAT>%sexCourseInfo%";
			using (SqlDataAdapter datad = new SqlDataAdapter("SELECT sex_id, sex_name FROM SexTable;", Transfer.DatabaseConnection))
			{
				SqlCommandBuilder scmd = new SqlCommandBuilder(datad);
				DataSet PatientDataSet = new DataSet();
				datad.Fill(PatientDataSet);

				byte[] PatientDataSetBytes = ConvertDataSetToBytes(PatientDataSet);
				OutputString = OutputString + "%sexCourseInfo%" + ByteArrayToString(PatientDataSetBytes);
			}
			using (SqlDataAdapter datad = new SqlDataAdapter("SELECT course_id, course_name FROM CourseTable;", Transfer.DatabaseConnection))
			{
				SqlCommandBuilder scmd = new SqlCommandBuilder(datad);
				DataSet PatientDataSet = new DataSet();
				datad.Fill(PatientDataSet);

				byte[] PatientDataSetBytes = ConvertDataSetToBytes(PatientDataSet);
				OutputString = OutputString + "%sexCourseInfo%" + ByteArrayToString(PatientDataSetBytes);
			}
			if (Transfer.DatabaseConnection.State == ConnectionState.Closed)
			{
				Transfer.SetDatabaseConnection();
				Transfer.DatabaseConnection.Open();
			}
			OutputString = OutputString + "%sexCourseInfo%<EOD>";
			return OutputString;
		}

		private static string requestAddPatient(string data)
		{
			string OutputString = "<OUT>!Failed!<OUT>";
			string[] separator = { "%patientInfo%" };
			string[] information = data.Split(separator, StringSplitOptions.None);

			try
			{
				SqlCommand sqlAddPatient = new SqlCommand(
									"INSERT INTO PatientTable values(@LastName, @FirstName, @MiddleName," +
									"@Age, @Sex, @Course, @Contact, @Birthdate, @Allergy, @Consult, @Checkup, @Medicalneeds, @StudentNum)"
									, Transfer.DatabaseConnection);
				bool allergy = false, consultation = false, checkup = false, medicalneeds = false;
				if (information[8] == "1")
					allergy = true;
				if (information[9] == "1")
					consultation = true;
				if (information[10] == "1")
					checkup = true;
				if (information[11] == "1")
					medicalneeds = true;


				sqlAddPatient.Parameters.AddWithValue("@LastName", information[0]);
				sqlAddPatient.Parameters.AddWithValue("@FirstName", information[1]);
				sqlAddPatient.Parameters.AddWithValue("@MiddleName", information[2]);
				sqlAddPatient.Parameters.AddWithValue("@Age", Convert.ToInt32(information[3]));
				sqlAddPatient.Parameters.AddWithValue("@Sex", Convert.ToByte(information[4]));
				sqlAddPatient.Parameters.AddWithValue("@Course", Convert.ToInt16(information[5]));
				sqlAddPatient.Parameters.AddWithValue("@Contact", information[6]);
				sqlAddPatient.Parameters.AddWithValue("@Birthdate", SqlDbType.Date).Value = DateTime.Parse(information[7]);
				sqlAddPatient.Parameters.AddWithValue("@Allergy", allergy);
				sqlAddPatient.Parameters.AddWithValue("@Consult", consultation);
				sqlAddPatient.Parameters.AddWithValue("@Checkup", checkup);
				sqlAddPatient.Parameters.AddWithValue("@Medicalneeds", medicalneeds);
				sqlAddPatient.Parameters.AddWithValue("@StudentNum", Convert.ToInt32(information[12]));

				sqlAddPatient.ExecuteNonQuery();

				sqlAddPatient.Dispose();

				OutputString = "<OUT>!Success!<OUT><MSG>Query is successful<MSG>";
			}
			catch (SqlException sqlEx)
			{
				OutputString = "<OUT>!Failed!<OUT><MSG>SQL error<MSG>";
			}
			catch (FormatException forEx)
			{
				OutputString = "<OUT>!Failed!<OUT><MSG>Format error<MSG>";
			}
			return OutputString;
		}
	}
}
