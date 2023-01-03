using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;	
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace DiagnosisPrognosisClient
{
	internal static class DataSerial
	{
		public static DataSet DeserializeData(string Data)
		{
			DataSet OutputDataset = new DataSet();

			char[] separator = { '.' };
			string[] separated = Data.Split(separator, StringSplitOptions.RemoveEmptyEntries);

			List<byte> UnconvertedBytes = new List<byte>();
			byte[] byteArray = null;

			foreach (string x in separated)
			{
				Console.WriteLine(x);
			}
			foreach (string x in separated)
			{
				//Debug.WriteLine(x);
				int temp = Int32.Parse(x);
				byte temp2 = (byte)temp;
				UnconvertedBytes.Add(temp2);
			}
			byteArray = UnconvertedBytes.ToArray();
			DataTable dataTable;
			using (MemoryStream stream = new MemoryStream(byteArray))
			{
				BinaryFormatter binFormatter = new BinaryFormatter();
				//dataTable = (DataSet) binFormatter.Deserialize(stream);
				OutputDataset = (DataSet)binFormatter.Deserialize(stream);
				Debug.WriteLine("HELVETE");
			}
			//OutputDataset.Tables.Add(dataTable);
			return OutputDataset;
		}
	}
}
