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
    public class SQLCommands
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
        static string connectionString = betaString + Homepage.DatabasePath;
        /*
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
        */
        /*
        List<string> symptomArray = new List<string>();
        public static List<MatchIllness> getIllnesses(List<string> symptomArray)
        {
            int sCounter = symptomArray.Count;
            List<MatchIllness> mi = new List<MatchIllness>();
            string currentSymptom;
            using (SqlConnection sqlConne = new SqlConnection(connectionString))
            {
                sqlConne.Open();
                for (int counter = 0; counter < sCounter; counter++)
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
                        List<Symptom> sus = new List<Symptom>();
                        sus.Add(new Symptom((int)reader["Symptom ID"], (string)reader["Symptom Name"]));
                        MatchIllness illness = new MatchIllness(
                        (int)reader["Illness ID"], 
                        (string)reader["Illness Name"], 
                        sus);
                        mi.Add(illness);
                    }
                    sqlConne.Close();
                }
            }
            return mi;
        }
        */
        
        List<Illness> Illnesses = new List<Illness>();

        public static List<Illness> GetIllness(List<Symptom> symptoms)
        {
            List<Illness> MatchIllnesses = new List<Illness>();
            try
            {
                form.Transfer.sconn.ConnectionString = @"Data Source=.\SQLEXPRESS;" +
                                                "AttachDbFilename=" + form.Transfer.DatabasePath + "; " +
                                                "Integrated Security=True; " +
                                                "Connect Timeout=30; " +
                                                "User Instance=True";
                using (form.Transfer.sconn)
                {
                    // ** opens sql connection ** //
                    form.Transfer.sconn.Open();

                    // ** Loops through all given symptoms
                    foreach (Symptom x in symptoms)
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
                            , form.Transfer.sconn
                        );

                        findIllnessViaID.Parameters.AddWithValue("@symptomID", x.symptomID);
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
                                        MatchIllnesses[loop].AddMatchSymptoms(new Symptom((int)reader["symptom id"], (string)reader["symptom name"]));
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
                            , form.Transfer.sconn);

                        getIllnessSymptoms.Parameters.AddWithValue("@illnessID", MatchIllnesses[ill].illnessID);
                        SqlDataReader reader2 = getIllnessSymptoms.ExecuteReader();

                        while (reader2.Read())
                        {
                            MatchIllnesses[ill].addSymptom(new Symptom((int)reader2["symptom id"], (string)reader2["symptom name"]));
                        }
                        reader2.Close();
                    }

                    form.Transfer.sconn.Close();
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }
            return MatchIllnesses;
        }
    }
    public class Symptom 
    {
        private int _symptomID;
        private string _symptomName;

        public int symptomID { get => _symptomID; set => _symptomID = value; }
        public string symptomName { get => _symptomName; set => _symptomName = value; }

        public Symptom(int symptomID, string symptomName)
        {
            _symptomID = symptomID;
            _symptomName = symptomName;
        }
    }
    public class Illness
    {
        private int _illnessID;
        private string _illnessName;
        private List<Symptom> _symptoms;
        private List<Symptom> _MatchSymptoms;

        private int _virality;
        public int virality { get => _virality; set => _virality = value; }

        public int illnessID { get => _illnessID; set => _illnessID = value; }
        public string illnessName { get => _illnessName; set => _illnessName = value; }

        public Illness(int illnessID, string illnessName, List<Symptom> matchedSymptoms)
        {
            _illnessID = illnessID;
            _illnessName = illnessName;
            _symptoms = new List<Symptom>(matchedSymptoms);
        }

        public Illness(int illnessID, string illnessName, Symptom initialMatch, int viral)
        {
            _illnessID = illnessID;
            _illnessName = illnessName;
            _symptoms = new List<Symptom>();
            _MatchSymptoms = new List<Symptom>();
            _MatchSymptoms.Add(initialMatch);
            _virality = viral;
        }

        public Illness(int illnessID, string illnessName)
        {
            _illnessID = illnessID;
            _illnessName = illnessName;
        }

        public Illness(MatchIllness old)
        {
            _illnessID = old.illnessID;
            _illnessName = old.illnessName;
            _symptoms = new List<Symptom>();
            foreach (OldSymptom x in old.getAllSymptom())
            {
                _symptoms.Add(new Symptom(x.symptomID, x.symptomName));
            }
            _MatchSymptoms = new List<Symptom>();
            foreach (OldSymptom x in old.getAllMatches())
            {
                _MatchSymptoms.Add(new Symptom(x.symptomID, x.symptomName));
            }
        }

        public List<Symptom> returnSymptoms()
        {
            return _symptoms;
        }

        public Symptom getSymptom(int index)
        {
            return _symptoms[index];
        }

        public List<Symptom> getAllSymptom()
        {
            return _symptoms;
        }

        public void addSymptom(Symptom symptom)
        {
            _symptoms.Add(symptom);
        }

        public int getNumOfSymptoms()
        {
            return _symptoms.Count;
        }

        public void AddMatchSymptoms(Symptom symptom)
        {
            _MatchSymptoms.Add(symptom);
        }

        public void AddMatchSymptoms(Symptom[] symptoms)
        {
            _MatchSymptoms.AddRange(symptoms);
        }

        public List<Symptom> getAllMatches()
        {
            return _MatchSymptoms;
        }

        public int getNumOfMatches()
        {
            return _MatchSymptoms.Count;
        }
    }
}
