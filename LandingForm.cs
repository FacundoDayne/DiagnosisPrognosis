using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;

namespace DiagnosisPrognosis
{
    public partial class LandingForm : Form
    {
        //Holds the string of the path to the location of the Database
        public static string DatabasePath;
        public LandingForm()
        {
            InitializeComponent();
            //Code to see whether or not the DatabaseLocation.txt File exists, this file holds the file path of the DataBase
            if (Directory.GetFiles(Program.thisLocation, "DatabaseLocation.txt", SearchOption.AllDirectories).FirstOrDefault() == null)
            {
                //if the DataBaseLocation file is not found, creates one and writes inside it
                FileStream fs = new FileStream(Path.Combine(Program.thisLocation, "DatabaseLocation.txt"), FileMode.CreateNew);
                using (fs)
                {
                    DatabasePath = SQLCommands.getDatabaseLocation();
                    fs.Write(Encoding.UTF8.GetBytes(DatabasePath), 0, DatabasePath.Length);
                }
                MessageBox.Show("DatabaseLocation created", "No Database Location Found");
            }
            else
            {
                //if the DataBaseLocation file is found, reads the information
                FileStream fs = new FileStream(Path.Combine(Program.thisLocation, "DatabaseLocation.txt"), FileMode.Open, FileAccess.Read);
                using var sr = new StreamReader(fs);
                if (sr.ReadLine() != null){DatabasePath = sr.ReadLine();}
                MessageBox.Show("DatabaseLocation Loaded", "Database Location Found");

            }
        }
                
        private void button1_Click(object sender, EventArgs e)
        {
            //this is basically to check whether or not the database works
            SymptomQueue.SymptomList.Enqueue(comboBox1.SelectedItem.ToString());
            DisplaySymptomsList(SymptomQueue.SymptomList);
        }

        void DisplaySymptomsList(IEnumerable Listy)
        {
            symptomList.Items.Clear();
            foreach(Object obj in Listy)
            {
                symptomList.Items.Add(obj.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<MatchIllness> matchIllnesses = SQLCommands.getIllnesses(SymptomQueue.SymptomList.ToList());
            foreach (MatchIllness obj in matchIllnesses)
            {
                symptomList.Items.Add("Illness Name: {0}", obj.illnessName);
            }
        }
    }
}