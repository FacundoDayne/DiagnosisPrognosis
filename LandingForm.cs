using System.Drawing;
using System.IO;
using System.Text;

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
            label1.Text = SQLCommands.getSymptom(1).ToString();
        }
    }
}