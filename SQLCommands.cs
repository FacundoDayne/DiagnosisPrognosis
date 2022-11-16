using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;

namespace DiagnosisPrognosis
{
    internal class SQLCommands
    {
        //Absolute Path
        //static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=B:\Programming\Replay\DiagnosisPrognosis\bin\Debug\net6.0-windows\DB\IllnessDB.mdf;";
        
        //Relative Path, Doesn't Work
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
            public string getIllnessName()
            {

            }
        }



        List<MatchedIllness> getIllnesses(List<string> symptomArray)
        {

        }
    }
}
