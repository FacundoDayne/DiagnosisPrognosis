using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Windows.Forms;
using System.Reflection;

namespace DiagnosisPrognosis
{
    internal class SQLCommands
    {

        //Opens an OpenFileDialog that looks for the Database's path string
        public static string getDatabaseLocation()
        {
            bool v = true;
            OpenFileDialog ofd = new OpenFileDialog();
            while (v)
            {               
                DialogResult result = ofd.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // Test result.
                {
                    v = false;
                }
                else
                {
                    MessageBox.Show("Please select the Database");
                }
            }
            return ofd.FileName;
        }

        //Absolute Path
        //static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=B:\Programming\Replay\DiagnosisPrognosis\bin\Debug\net6.0-windows\DB\IllnessDB.mdf;";

        //Relative Path, works!
        static string betaString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=";
        static string connectionString = betaString + LandingForm.DatabasePath;

        public static string getSymptom(int ID)
        {
            using (SqlConnection sqlConne = new SqlConnection(connectionString))
            {
                string symptom = "";
                sqlConne.Open();
                SqlCommand findSymptomViaID = new SqlCommand("select symptom_name from SymptomsTable where symptom_id = @symptom_id", sqlConne);
                findSymptomViaID.Parameters.AddWithValue("@symptom_id", ID);

                SqlDataReader reader = findSymptomViaID.ExecuteReader();
                while (reader.Read())
                {
                    symptom = reader["symptom_name"].ToString();
                }
                sqlConne.Close();
                return symptom;
            }
        }

        List<string> symptomArray = new List<string>();
        public class MatchedIllness
        {
            private string Illness_Name;
            private ArrayList Symptom_Name = new ArrayList();
            public MatchedIllness(string Illness_Name, string Symptom_Name)
            {
                this.Illness_Name = Illness_Name;
                this.Symptom_Name.Add(Symptom_Name);
            }
            public string getIllnessName(){return Illness_Name;}
            public ArrayList getSymptomName() { return Symptom_Name; }
        }

        List<MatchedIllness> getIllnesses(List<string> symptomArray)
        {
            int sCounter = symptomArray.Count;
            List<MatchedIllness> mi = new List<MatchedIllness>();
            string currentSymptom;
            using (SqlConnection sqlConne = new SqlConnection(connectionString))
            {
                sqlConne.Open();
                for (int counter = 0; counter < sCounter + 1; counter++)
                {
                    currentSymptom = symptomArray[counter];
                    SqlCommand findIllnessViaID = new SqlCommand(
                    "select " +
                    "i.illness_id as 'Illness ID', " +
                    "i.illness_name as 'Illness Name', " +
                    "s.symptom_name as 'Symptom Name' " +
                    "from IllnessTable i " +
                    "inner join SymptomsTable s " +
                    "on i.symptom_id = s.symptom_id " +
                    "where s.symptom_name = '@symptom_name'", sqlConne);
                    findIllnessViaID.Parameters.AddWithValue("@symptom_name", currentSymptom);

                    SqlDataReader reader = findIllnessViaID.ExecuteReader();
                    while (reader.Read())
                    {
                        MatchedIllness illness = new MatchedIllness(
                        (string)reader["Illness ID"],
                        (string)reader["Symptom Name"],
                        (string)reader["Illness Name"]);
                        mi.Add(illness);
                    }
                    sqlConne.Close();
                }
            }
            return mi;
        }
    }
}
