using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagnosisPrognosis
{
    public partial class Homepage : Form
    {
        //Holds the string of the path to the location of the Database
        public static string DatabasePath;
        public Homepage()
        {
            InitializeComponent();
            addPatientForm1.Visible = false;
            diagnosisUC1.Visible = false;
            inventoryUC1.Visible = false;
            //Code to see whether or not the DatabaseLocation.txt File exists, this file holds the file path of the DataBase
            if (Directory.GetFiles(Program.thisLocation, "DatabaseLocation.txt", SearchOption.AllDirectories).FirstOrDefault() == null)
            {
                MessageBox.Show("Please select the location of the database", "No Database Location Found");
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
                if (sr.ReadLine() != null) { DatabasePath = sr.ReadLine(); }
                MessageBox.Show("DatabaseLocation Loaded", "Database Location Found");

            }

        }

        private void btnPatientInfo_Click(object sender, EventArgs e)
        {
            addPatientForm1.Visible = true;
            diagnosisUC1.Visible = false;
            inventoryUC1.Visible = false; 
        }

        private void btnDiagnosis_Click(object sender, EventArgs e)
        {
            diagnosisUC1.Visible = true;
            addPatientForm1.Visible = false;
            inventoryUC1.Visible = false;
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            inventoryUC1.Visible = true;
            addPatientForm1.Visible = false;
            diagnosisUC1.Visible = false;

        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void pbSTIlogo_Click(object sender, EventArgs e)
        {
            pbSTICampus.Visible = true;
            addPatientForm1.Visible = false;
            diagnosisUC1.Visible = false;
            inventoryUC1.Visible = false;
        }
    }
}
