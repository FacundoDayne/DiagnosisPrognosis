using System;
using System.Diagnostics;
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

			IPAddress ipAddress = IPAddress.Parse(setIpAddress);
			int port = 11000;

			_ip = setIpAddress;
			_port = port.ToString();

			Console.WriteLine(ipAddress.ToString());
			IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
			/*
			try
			{
				Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

				listener.Bind(localEndPoint);

				Socket handler;
				Console.WriteLine("!Database! Waiting for a connection...");

				Console.WriteLine("!Database! Listening...");
				listener.Listen(10);
				handler = listener.Accept();

				string data = null;
				byte[] bytes = null;
				string sqlConnectionSuccess = "!failed!";

				while (true)
				{
					bytes = new byte[1024];
					int bytesRec = handler.Receive(bytes);
					data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
					Console.WriteLine("Received = " + data);
					if (data.IndexOf("?isDBon?") > -1)
					{
						if (Transfer.DatabaseConnection.State == ConnectionState.Open)
						{
							sqlConnectionSuccess = "!dbISopen!";
							Console.WriteLine("Database is open!");
						}
					}
					if (data.IndexOf("<EOF>") > -1)
					{
						break;
					}
				}

				byte[] msg = Encoding.ASCII.GetBytes(sqlConnectionSuccess + "<EOF>");
				handler.Send(msg);
				handler.Dispose();
				listener.Dispose();
			}
			catch (SocketException sox)
			{
				Console.WriteLine(sox.ToString());
			}
			catch (SqlException sqx)
			{
				Console.WriteLine(sqx.ToString());
			}
			*/

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
				case "sexCourseInfo":
					Console.WriteLine("Received Patient Information Request");
					_request.Enqueue(cutData[4]);
					_outgoingMessages.Enqueue(requestSexCourseInfo());
					break;
				case "patientAllInfo":
					Console.WriteLine("Received Patient All Info Request");
					_request.Enqueue(cutData[4]);
					_outgoingMessages.Enqueue(requestPatientAllInfo(Convert.ToInt32(cutData[5])));
					break;
				case "patientAllInfoSC":
					Console.WriteLine("Received Patient All Info Request");
					_request.Enqueue(cutData[4]);
					_outgoingMessages.Enqueue(requestPatientAllInfoCD(Convert.ToInt32(cutData[5])));
					break;
				case "addPatient":
					Console.WriteLine("Received Add Patient Request");
					_request.Enqueue(cutData[4]);
					_outgoingMessages.Enqueue(requestAddPatient(cutData[5]));
					break;
				case "updatePatient":
					Console.WriteLine("Received Update Patient Request");
					_request.Enqueue(cutData[4]);
					_outgoingMessages.Enqueue(requestUpdatePatient(cutData[5]));
					break;
				case "requestSymptoms":
					Console.WriteLine("Received Symptoms Table Request");
					_request.Enqueue(cutData[4]);
					_outgoingMessages.Enqueue(requestSymptoms());
					break;
				case "GetIllnesses":
					Console.WriteLine("Received Diagnose Request");
					_request.Enqueue(cutData[4]);
					_outgoingMessages.Enqueue(Diagnose(cutData[5]));
					break;
				case "SaveDiagnosis":
					Console.WriteLine("Received Diagnosis Save Request");
					_request.Enqueue(cutData[4]);
					_outgoingMessages.Enqueue(SaveDiagnosis(cutData[5]));
					break;
				case "checkDbIsOpen":
					Console.WriteLine("Received Database State Request");
					_request.Enqueue(cutData[4]);
					_outgoingMessages.Enqueue(checkDbIsOpen());
					break;
				case "requestLogin":
					Console.WriteLine("Received Login Request");
					_request.Enqueue(cutData[4]);
					_outgoingMessages.Enqueue(requestLogin(cutData[2], cutData[3]));
					break;
			}
		}

		private static string returnAddress()
		{
			string ipAddPort = _ip + ":" + _port;
			return ipAddPort;
		}

		private static string checkDbIsOpen()
		{
			string dbConOpen = "!failed!";
			if (Transfer.DatabaseConnection.State == ConnectionState.Open)
				dbConOpen = "!dbISopen!";
			return dbConOpen;
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

				int y = 0;
				foreach (string x in information)
				{
					Debug.WriteLine(y + "\t" + x);
					y++;
				}

				sqlAddPatient.Parameters.AddWithValue("@LastName", information[0]);
				sqlAddPatient.Parameters.AddWithValue("@FirstName", information[1]);
				sqlAddPatient.Parameters.AddWithValue("@MiddleName", information[2]);
				sqlAddPatient.Parameters.AddWithValue("@Age", Convert.ToInt32(information[3]));
				sqlAddPatient.Parameters.AddWithValue("@Sex", Convert.ToByte(information[4]));
				sqlAddPatient.Parameters.AddWithValue("@Course", Convert.ToInt16(information[5]));
				sqlAddPatient.Parameters.AddWithValue("@Contact", information[6]);
				sqlAddPatient.Parameters.AddWithValue("@Birthdate", SqlDbType.Date).Value = DateTime.Parse(information[7]).Date;
				sqlAddPatient.Parameters.AddWithValue("@Allergy", SqlDbType.Bit).Value = allergy;
				sqlAddPatient.Parameters.AddWithValue("@Consult", SqlDbType.Bit).Value = consultation;
				sqlAddPatient.Parameters.AddWithValue("@Checkup", SqlDbType.Bit).Value = checkup;
				sqlAddPatient.Parameters.AddWithValue("@Medicalneeds", SqlDbType.Bit).Value = medicalneeds;
				sqlAddPatient.Parameters.AddWithValue("@StudentNum", Convert.ToInt32(information[12]));

				sqlAddPatient.ExecuteNonQuery();

				sqlAddPatient.Dispose();

				Transfer.DatabaseConnection.Close();

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

			if (Transfer.DatabaseConnection.State == ConnectionState.Closed)
			{
				Transfer.SetDatabaseConnection();
				Transfer.DatabaseConnection.Open();
			}

			return OutputString;
		}

		private static string requestUpdatePatient(string data)
		{
			string OutputString = "<OUT>!Failed!<OUT>";
			string[] separator = { "%patientInfo%" };
			string[] information = data.Split(separator, StringSplitOptions.None);

			try
			{
				SqlCommand sqlAddPatient = new SqlCommand(
									"UPDATE PatientTable SET " +
									"patient_lastname = @LastName, " +
									"patient_firstname = @FirstName, " +
									"patient_middlename = @MiddleName," +
									"patient_age = @Age, " +
									"patient_sex_id = @Sex, " +
									"patient_course_id = @Course, " +
									"patient_contactnumber = @Contact, " +
									"patient_birthdate = @Birthdate," +
									"patient_allergies = @Allergy, " +
									"patient_consultation = @Consult, " +
									"patient_checkup = @Checkup, " +
									"patient_medicalneeds = @Medicalneeds, " +
									"patient_studentnumber = @StudentNum " +
									"WHERE patient_id = @id"
									, Transfer.DatabaseConnection);
				bool allergy = false, consultation = false, checkup = false, medicalneeds = false;
				if (information[9] == "1")
					allergy = true;
				if (information[10] == "1")
					consultation = true;
				if (information[11] == "1")
					checkup = true;
				if (information[12] == "1")
					medicalneeds = true;


				sqlAddPatient.Parameters.AddWithValue("@LastName", information[1]);
				sqlAddPatient.Parameters.AddWithValue("@FirstName", information[2]);
				sqlAddPatient.Parameters.AddWithValue("@MiddleName", information[3]);
				sqlAddPatient.Parameters.AddWithValue("@Age", Convert.ToInt32(information[4]));
				sqlAddPatient.Parameters.AddWithValue("@Sex", Convert.ToByte(information[5]));
				sqlAddPatient.Parameters.AddWithValue("@Course", Convert.ToInt16(information[6]));
				sqlAddPatient.Parameters.AddWithValue("@Contact", information[7]);
				sqlAddPatient.Parameters.AddWithValue("@Birthdate", SqlDbType.Date).Value = DateTime.Parse(information[8]).Date;
				sqlAddPatient.Parameters.AddWithValue("@Allergy", SqlDbType.Bit).Value = allergy;
				sqlAddPatient.Parameters.AddWithValue("@Consult", SqlDbType.Bit).Value = consultation;
				sqlAddPatient.Parameters.AddWithValue("@Checkup", SqlDbType.Bit).Value = checkup;
				sqlAddPatient.Parameters.AddWithValue("@Medicalneeds", SqlDbType.Bit).Value = medicalneeds;
				sqlAddPatient.Parameters.AddWithValue("@StudentNum", Convert.ToInt32(information[13]));
				sqlAddPatient.Parameters.AddWithValue("@id", Convert.ToInt32(information[0]));

				sqlAddPatient.ExecuteNonQuery();

				sqlAddPatient.Dispose();

				Transfer.DatabaseConnection.Close();

				OutputString = "<OUT>!Success!<OUT><MSG>Query is successful<MSG>";
			}
			catch (SqlException sqlEx)
			{
				OutputString = "<OUT>!Failed!<OUT><MSG>SQL error<MSG>";
				Debug.WriteLine(sqlEx.Message);
			}
			catch (FormatException forEx)
			{
				OutputString = "<OUT>!Failed!<OUT><MSG>Format error<MSG>";
			}

			if (Transfer.DatabaseConnection.State == ConnectionState.Closed)
			{
				Transfer.SetDatabaseConnection();
				Transfer.DatabaseConnection.Open();
			}

			return OutputString;
		}

		private static string requestPatientAllInfo(int PatientID)
		{

			string OutputString = $"<TOK>TestToken<EOI><IPP>{_ip}:{_port}<EOI><DAT>%patientAllInfo%";
			using (SqlCommand scmd = new SqlCommand("SELECT a.*, b.sex_name FROM PatientTable a INNER JOIN SexTable b ON a.patient_sex_id = b.sex_id WHERE a.patient_id = @cID", Transfer.DatabaseConnection))
			{
				scmd.Parameters.AddWithValue("@cID", SqlDbType.Int).Value = PatientID;
				SqlDataReader sread = scmd.ExecuteReader();
				while (sread.Read())
				{
					int allergy = 0, consultation = 0, checkup = 0, medicalneeds = 0;
					if ((bool)sread.GetValue("patient_allergies") == true)
						allergy = 1;
					if ((bool)sread.GetValue("patient_consultation") == true)
						consultation = 1;
					if ((bool)sread.GetValue("patient_checkup") == true)
						checkup = 1;
					if ((bool)sread.GetValue("patient_medicalneeds") == true)
						medicalneeds = 1;
					Console.WriteLine("");
					OutputString = OutputString + sread.GetValue("patient_lastname") + "%patientAllInfo%";
					OutputString = OutputString + sread.GetValue("patient_firstname") + "%patientAllInfo%";
					OutputString = OutputString + sread.GetValue("patient_middlename") + "%patientAllInfo%";
					OutputString = OutputString + Convert.ToString(sread.GetValue("patient_age")) + "%patientAllInfo%";
					OutputString = OutputString + Convert.ToString(sread.GetValue("patient_sex_id")) + "%patientAllInfo%";
					OutputString = OutputString + Convert.ToString(sread.GetValue("patient_course_id")) + "%patientAllInfo%";
					OutputString = OutputString + sread.GetValue("patient_contactnumber") + "%patientAllInfo%";
					OutputString = OutputString + Convert.ToDateTime(sread.GetValue("patient_birthdate")).ToString("yyyy-MM-dd") + "%patientAllInfo%";
					OutputString = OutputString + allergy + "%patientAllInfo%";
					OutputString = OutputString + consultation + "%patientAllInfo%";
					OutputString = OutputString + checkup + "%patientAllInfo%";
					OutputString = OutputString + medicalneeds + "%patientAllInfo%";
					OutputString = OutputString + sread.GetValue("patient_studentnumber") + "%patientAllInfo%";
					OutputString = OutputString + sread.GetValue("sex_name") + "%patientAllInfo%";

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

		private static string requestPatientAllInfoCD(int PatientID)
		{

			string OutputString = $"<TOK>TestToken<EOI><IPP>{_ip}:{_port}<EOI><DAT>%patientAllInfoSC%";
			using (SqlCommand scmd = new SqlCommand("SELECT * FROM PatientTable a WHERE a.patient_id = @cID", Transfer.DatabaseConnection))
			{
				scmd.Parameters.AddWithValue("@cID", SqlDbType.Int).Value = PatientID;
				SqlDataReader sread = scmd.ExecuteReader();
				while (sread.Read())
				{
					int allergy = 0, consultation = 0, checkup = 0, medicalneeds = 0;
					if ((bool)sread.GetValue("patient_allergies") == true)
						allergy = 1;
					if ((bool)sread.GetValue("patient_consultation") == true)
						consultation = 1;
					if ((bool)sread.GetValue("patient_checkup") == true)
						checkup = 1;
					if ((bool)sread.GetValue("patient_medicalneeds") == true)
						medicalneeds = 1;
					Console.WriteLine("");
					OutputString = OutputString + sread.GetValue("patient_lastname") + "%patientAllInfoSC%"; Console.Write("1");
					OutputString = OutputString + sread.GetValue("patient_firstname") + "%patientAllInfoSC%"; Console.Write("2");
					OutputString = OutputString + sread.GetValue("patient_middlename") + "%patientAllInfoSC%"; Console.Write("3");
					OutputString = OutputString + Convert.ToString(sread.GetValue("patient_age")) + "%patientAllInfoSC%"; Console.Write("4");
					OutputString = OutputString + Convert.ToString(sread.GetValue("patient_sex_id")) + "%patientAllInfoSC%"; Console.Write("5");
					OutputString = OutputString + Convert.ToString(sread.GetValue("patient_course_id")) + "%patientAllInfoSC%"; Console.Write("6");
					OutputString = OutputString + sread.GetValue("patient_contactnumber") + "%patientAllInfoSC%"; Console.Write("7");
					OutputString = OutputString + Convert.ToDateTime(sread.GetValue("patient_birthdate")).ToString("yyyy-MM-dd") + "%patientAllInfoSC%"; Console.Write("8");
					OutputString = OutputString + allergy + "%patientAllInfoSC%"; Console.Write("9");
					OutputString = OutputString + consultation + "%patientAllInfoSC%"; Console.Write("10");
					OutputString = OutputString + checkup + "%patientAllInfoSC%"; Console.Write("11");
					OutputString = OutputString + medicalneeds + "%patientAllInfoSC%"; Console.Write("12");
					OutputString = OutputString + sread.GetValue("patient_studentnumber") + "%patientAllInfoSC%";
				}
				sread.Close();
			}
			using (SqlDataAdapter datad = new SqlDataAdapter("SELECT sex_id, sex_name FROM SexTable;", Transfer.DatabaseConnection))
			{
				SqlCommandBuilder scmd = new SqlCommandBuilder(datad);
				DataSet PatientDataSet = new DataSet();
				datad.Fill(PatientDataSet);

				byte[] PatientDataSetBytes = ConvertDataSetToBytes(PatientDataSet);
				OutputString = OutputString + "%patientAllInfoSC%" + ByteArrayToString(PatientDataSetBytes);
			}
			using (SqlDataAdapter datad = new SqlDataAdapter("SELECT course_id, course_name FROM CourseTable;", Transfer.DatabaseConnection))
			{
				SqlCommandBuilder scmd = new SqlCommandBuilder(datad);
				DataSet PatientDataSet = new DataSet();
				datad.Fill(PatientDataSet);

				byte[] PatientDataSetBytes = ConvertDataSetToBytes(PatientDataSet);
				OutputString = OutputString + "%patientAllInfoSC%" + ByteArrayToString(PatientDataSetBytes);
			}
			if (Transfer.DatabaseConnection.State == ConnectionState.Closed)
			{
				Transfer.SetDatabaseConnection();
				Transfer.DatabaseConnection.Open();
			}
			OutputString = OutputString + "<EOD>";
			return OutputString;
		}
		
		private static string requestLogin(string username, string password)
		{
			string OutputString = $"<TOK>TestToken<EOI><IPP>{_ip}:{_port}<EOI>";

			string OutputString2 = "<OUT>!Failed!<OUT>";

			using (SqlCommand scmd = new SqlCommand("SELECT a.id, a.usertype, a.patientID, a.doctorID, a.adminID FROM UserTable a WHERE a.username = @usern AND a.password = @userp;", Transfer.DatabaseConnection))
			{
				scmd.Parameters.AddWithValue("@usern", SqlDbType.Int).Value = username;
				scmd.Parameters.AddWithValue("@userp", SqlDbType.Int).Value = password;
				SqlDataReader sread = scmd.ExecuteReader();
				while (sread.Read())
				{
					if (sread.HasRows)
					{
						if (Convert.ToInt32(sread.GetValue("usertype")) == 0)
						{
							OutputString2 = "<OUT>!Success!<OUT><DAT>" + Convert.ToInt32(sread.GetValue("patientID")) + "<DAT>" + Convert.ToInt32(sread.GetValue("usertype")) + "<DAT>";
						}
						else if (Convert.ToInt32(sread.GetValue("usertype")) == 1)
						{
							OutputString2 = "<OUT>!Success!<OUT><DAT>" + Convert.ToInt32(sread.GetValue("doctorID")) + "<DAT>" + Convert.ToInt32(sread.GetValue("usertype")) + "<DAT>";
						}
						else if (Convert.ToInt32(sread.GetValue("usertype")) == 2)
						{
							OutputString2 = "<OUT>!Success!<OUT><DAT>" + Convert.ToInt32(sread.GetValue("adminID")) + "<DAT>" + Convert.ToInt32(sread.GetValue("usertype")) + "<DAT>";
						}
					}
				}
				sread.Close();
			}
			if (Transfer.DatabaseConnection.State == ConnectionState.Closed)
			{
				Transfer.SetDatabaseConnection();
				Transfer.DatabaseConnection.Open();
			}
			OutputString = OutputString + OutputString2;
			return OutputString;
		}

		private static string requestSymptoms()
		{
			string OutputString = $"<TOK>TestToken<EOI><IPP>{_ip}:{_port}<EOI><DAT>";
			using (SqlDataAdapter datad = new SqlDataAdapter("SELECT * FROM SymptomsTable", Transfer.DatabaseConnection))
			{
				SqlCommandBuilder scmd = new SqlCommandBuilder(datad);
				DataSet PatientDataSet = new DataSet();
				datad.Fill(PatientDataSet);

				byte[] PatientDataSetBytes = ConvertDataSetToBytes(PatientDataSet);
				OutputString = OutputString + "%symptomTable%" + ByteArrayToString(PatientDataSetBytes) + "%symptomTable%";
			}
			if (Transfer.DatabaseConnection.State == ConnectionState.Closed)
			{
				Transfer.SetDatabaseConnection();
				Transfer.DatabaseConnection.Open();
			}
			OutputString = OutputString + "<EOD>";
			return OutputString;
		}

		private static string Diagnose(string data)
		{
			string OutputString = $"<TOK>TestToken<EOI><IPP>{_ip}:{_port}<EOI><DAT>";
			string[] separator = { "%GetIllnesses%" };
			string[] information = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			List<int> ids = new List<int>();
			foreach (string x in information)
			{
				if (x != "")
				{
					ids.Add(Convert.ToInt32(x));
				}
			}

			List<Illness> MatchIllnesses = new List<Illness>();
			try
			{
				// ** Loops through all given symptoms
				foreach (int x in ids)
				{

					// ** Retrieves table of illnesses that match the current symptom ** //
					SqlCommand findIllnessViaID = new SqlCommand(
						"select c.illness_id as 'illness id', c.illness_name as 'illness name'," +
						" c.illness_virality as 'virality'," +
						" a.symptom_name as 'symptom name', a.symptom_id as 'symptom id'" +
						" from SymptomsTable a" +
						" inner join IllnessSymptomsTable b on b.symptom_id = a.symptom_id" +
						" inner join IllnessTable c on b.illness_id = c.illness_id" +
						" WHERE a.symptom_id = @symptomID;"
						, Transfer.DatabaseConnection
					);

					findIllnessViaID.Parameters.AddWithValue("@symptomID", x);
					SqlDataReader reader = findIllnessViaID.ExecuteReader();

					while (reader.Read())
					{
						// ** Check if the illnesses list is empty ** //
						// ** If it is empty, add a new illness ** //
						if (MatchIllnesses.Count == 0)
						{
							MatchIllnesses.Add(new Illness((int)reader["illness id"], (string)reader["illness name"], x, (int)reader["virality"]));
						}

						// ** If it is not empty, check if the current illness exists ** //
						else
						{

							// ** Following variables check if there is a match ** //
							bool exists = false;

							// ** loops through the list of illnesses ** //

							for (int loop = 0; loop < MatchIllnesses.Count; loop++)
							{

								// ** Checks if the current illness matches with the list's illnesses ** //
								// ** If true, give the existing illness the new symptom ** //

								if (MatchIllnesses[loop].illnessID == (int)reader["illness id"])
								{
									exists = true;
									MatchIllnesses[loop].AddMatchSymptoms((int)reader["symptom id"]);
								}
							}

							// ** If there are no match, add a new illness ** //

							if (exists == false)
							{
								MatchIllnesses.Add(new Illness((int)reader["illness id"], (string)reader["illness name"], x, (int)reader["virality"]));
							}
						}
					}
					reader.Close();
				}
				for (int ill = 0; ill < MatchIllnesses.Count; ill++)
				{
					SqlCommand getIllnessSymptoms = new SqlCommand(
						"select c.symptom_name as 'symptom name', " +
						" c.symptom_id as 'symptom id'" +
						" from IllnessTable a" +
						" inner join IllnessSymptomsTable b on b.illness_id = a.illness_id" +
						" inner join SymptomsTable c on b.symptom_id = c.symptom_id" +
						" WHERE a.illness_id = @illnessID;"
						, Transfer.DatabaseConnection);

					getIllnessSymptoms.Parameters.AddWithValue("@illnessID", MatchIllnesses[ill].illnessID);
					SqlDataReader reader2 = getIllnessSymptoms.ExecuteReader();

					while (reader2.Read())
					{
						MatchIllnesses[ill].addSymptom((int)reader2["symptom id"]);
					}

					reader2.Close();
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.ToString());
			}

			DataSet DataOutput = new DataSet();

			DataTable illnessMatches = new DataTable();
			illnessMatches.Columns.Add("IllnessID");
			illnessMatches.Columns.Add("IllnessName");
			illnessMatches.Columns.Add("Symptoms");
			illnessMatches.Columns.Add("MatchSymptoms");

			foreach (Illness x in MatchIllnesses)
			{
				string symptoms = "";
				for (int y = 0; y < x.getAllSymptom().ToArray().Length; y++)
				{
					symptoms += y;
					if (y != x.getAllSymptom().ToArray().Length)
					{
						symptoms += ".";
					}
				}
				string matched = "";
				for (int y = 0; y < x.getAllMatches().ToArray().Length; y++)
				{
					matched += y;
					if (y != x.getAllSymptom().ToArray().Length)
					{
						matched += ".";
					}
				}
				illnessMatches.Rows.Add(x.illnessID, x.illnessName, symptoms, matched);
			}

			DataOutput.Tables.Add(illnessMatches);

			byte[] DataSetBytes = ConvertDataSetToBytes(DataOutput);
			OutputString = OutputString + "%IllnessTable%" + ByteArrayToString(DataSetBytes) + "%IllnessTable%";

			OutputString += "<EOD>";
			return OutputString;
		}
		
		private static string SaveDiagnosis(string data)
		{
			string OutputString = $"<TOK>TestToken<EOI><IPP>{_ip}:{_port}<EOI><DAT>";
			string[] separator = { "%Diagnosis%" };
			string[] information = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			List<string> removedSpace = new List<string>();
			foreach (string x in information)
			{
				if (x != "")
				{
					removedSpace.Add(x);
				}
			}
			foreach (string x in information)
			{
				Console.WriteLine(x);
			}
			Console.WriteLine("a");
			foreach (string x in removedSpace)
			{
				Console.WriteLine(x);
			}

			try
			{
				SqlCommand sqlRemovePatSymp = new SqlCommand(
										"DELETE FROM PatientSymptomsTable WHERE PatientID = @PatientID; " +
										"DELETE FROM PatientDiagnosisTable WHERE PatientID = @PatientID;"
										, Transfer.DatabaseConnection);

				sqlRemovePatSymp.Parameters.AddWithValue("@PatientID", Convert.ToString(removedSpace[0]));

				sqlRemovePatSymp.ExecuteNonQuery();

				string[] ids = removedSpace[1].Split('.');
				foreach (string y in ids)
				{
					SqlCommand sqlAddPatSymp = new SqlCommand(
										"INSERT INTO PatientSymptomsTable values(@PairKey, @PatientID, @SymptomID)"
										, Transfer.DatabaseConnection);


					sqlAddPatSymp.Parameters.AddWithValue("@PairKey", (removedSpace[0] + "_" + y));
					sqlAddPatSymp.Parameters.AddWithValue("@PatientID", removedSpace[0]);
					sqlAddPatSymp.Parameters.AddWithValue("@SymptomID", y);

					sqlAddPatSymp.ExecuteNonQuery();
					sqlAddPatSymp.Dispose();
				}
				string[] ids2 = removedSpace[2].Split('.');
				foreach (string y in ids2)
				{
					SqlCommand sqlAddPatSymp = new SqlCommand(
										"INSERT INTO PatientDiagnosisTable values(@PairKey, @PatientID, @IllnessID)"
										, Transfer.DatabaseConnection);


					sqlAddPatSymp.Parameters.AddWithValue("@PairKey", (removedSpace[0] + "_" + y));
					sqlAddPatSymp.Parameters.AddWithValue("@PatientID", removedSpace[0]);
					sqlAddPatSymp.Parameters.AddWithValue("@IllnessID", y);

					sqlAddPatSymp.ExecuteNonQuery();
					sqlAddPatSymp.Dispose();
				}

				Transfer.DatabaseConnection.Close();

				OutputString = "<OUT>!Success!<OUT><MSG>Query is successful<MSG>";
			}
			/*
			catch (SqlException sqlEx)
			{
				OutputString = "<OUT>!Failed!<OUT><MSG>SQL error<MSG>";
			}
			*/
			catch (FormatException forEx)
			{
				OutputString = "<OUT>!Failed!<OUT><MSG>Format error<MSG>";
			}

			if (Transfer.DatabaseConnection.State == ConnectionState.Closed)
			{
				Transfer.SetDatabaseConnection();
				Transfer.DatabaseConnection.Open();
			}

			return OutputString;

		}
		/*
		
			
		 */
	}
}
