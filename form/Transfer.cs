using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DiagnosisPrognosis
{
    public static class Transfer
    {
		public static string DatabaseFileName = "";
        public static string DatabasePath = "";
		public static string DatabaseConnectionString = "";
        public static SqlConnection DatabaseConnection = null;

		public static void SetDatabaseFileName(string FileName)
		{
			DatabaseFileName = FileName;
		}
		public static void SetDatabasePath()
		{
			if (DatabaseFileName == "")
			{
				Console.WriteLine("Error: No Database File has been set");
				return;
			}
			DatabasePath = Environment.CurrentDirectory + DatabaseFileName;
		}
		public static void SetDatabaseConnection()
		{
			
			DatabaseConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
			$"AttachDbFilename={DatabasePath};Integrated Security=True;Connect Timeout=30";
			DatabaseConnection = new SqlConnection(DatabaseConnectionString);
		}
    }
}
