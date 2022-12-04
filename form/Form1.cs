using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DiagnosisPrognosis
{
    public partial class Homepage : Form
    {

        //Holds the string of the path to the location of the Database
        public static string DatabasePath;
        SqlConnection sconn;

        public Homepage()
        {
            //Code to see whether or not the DatabaseLocation.txt File exists, this file holds the file path of the DataBase
            /*
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
                //MessageBox.Show("DatabaseLocation created", "No Database Location Found");
            }
            else
            {
                //if the DataBaseLocation file is found, reads the information
                //FileStream fs = new FileStream(Path.Combine(Program.thisLocation, "DatabaseLocation.txt"), FileMode.Open, FileAccess.Read);
                //using var sr = new StreamReader(fs);
                //if (sr.ReadLine() != null) { DatabasePath = sr.ReadLine(); }
                //MessageBox.Show("DatabaseLocation Loaded", "Database Location Found");
                //MessageBox.Show(Program.thisLocation);
                //DiagnosisPrognosis.form.Transfer.DatabasePath = DatabasePath;
                /*
                sconn = new SqlConnection(@"Data Source=.\SQLEXPRESS;" +
                                                    "AttachDbFilename=" + DatabasePath + "; " +
                                                    "Integrated Security=True; " +
                                                    "Connect Timeout=30; " +
                                                    "User Instance=True");
                
                DatabasePath = @"\SafeDP_Database.mdf";
                sconn = new SqlConnection(@"Data Source=.\SQLEXPRESS;" +
                                                    "AttachDbFilename=" + DatabasePath + "; " +
                                                    "Integrated Security=True; " +
                                                    "Connect Timeout=30; " +
                                                    "User Instance=True");
            }
            */
            string appLoc = System.Environment.CurrentDirectory;
            DatabasePath = appLoc + @"\SafeDP_Database.mdf";
            SqlConnection sconn = new SqlConnection();
            sconn.ConnectionString = @"Data Source=.\SQLEXPRESS;" +
                                                "AttachDbFilename=" + DatabasePath + "; " +
                                                "Integrated Security=True; " +
                                                "Connect Timeout=30; " +
                                                "User Instance=True";
            form.Transfer.DatabasePath = DatabasePath;
            System.Diagnostics.Debug.WriteLine(sconn.ConnectionString);
            sconn.Open();
            sconn.Close();
            form.Transfer.sconn = new SqlConnection();
            form.Transfer.sconn.ConnectionString = @"Data Source=.\SQLEXPRESS;" +
                                                "AttachDbFilename=" + form.Transfer.DatabasePath + "; " +
                                                "Integrated Security=True; " +
                                                "Connect Timeout=30; " +
                                                "User Instance=True";

            InitializeComponent(sconn);

            addPatientForm1.Visible = false;
            diagnosisUC1.Visible = false;
            inventoryUC1.Visible = false;


        }

        public void YA()
        {
            System.Diagnostics.Debug.WriteLine("HELVETE");
            SqlConnection sconn = new SqlConnection(@"Data Source=.\SQLEXPRESS;" +
                                                    "AttachDbFilename=" + DatabasePath + "; " +
                                                    "Integrated Security=True; " +
                                                    "Connect Timeout=30; " +
                                                    "User Instance=True");
            /*
            try
            {
                sconn.Open();
                System.Diagnostics.Debug.WriteLine("Connected");
            } catch
            {

                System.Diagnostics.Debug.WriteLine("NO");
            }
            */
            
            sconn.Open();
            SqlTransaction tran = sconn.BeginTransaction("Transact1");
            tran.Save("SavePoint1");

            string sql2 = "";

            System.Diagnostics.Debug.WriteLine(Environment.CurrentDirectory);
            
            using (FileStream filest = new FileStream(@"..\..\..\SQL Stuff\Create and Inserts.sql", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader stread = new StreamReader(filest))
                {
                    sql2 = stread.ReadToEnd();
                    System.Diagnostics.Debug.WriteLine(sql2);
                }
            }
            try
            {
                using (SqlCommand scmd = new SqlCommand(sql2, sconn, tran))
                {
                    scmd.ExecuteNonQuery();
                }
            } catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Dunno what the fuck just happened :P");
            }
            using (SqlCommand scmd = new SqlCommand("if OBJECT_ID(N'dbo.SymptomsTable', N'U') is not null\n" +
                "\tselect 'EXISTS'", sconn, tran))
            {
                SqlDataReader sqlred = scmd.ExecuteReader();
                while (sqlred.Read())
                {
                    System.Diagnostics.Debug.WriteLine(sqlred.GetString(0));
                }
                sqlred.Close();

            }
            using (SqlCommand scmd = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES", sconn, tran))
            {
                SqlDataReader sqlred = scmd.ExecuteReader();
                while (sqlred.Read())
                {
                    System.Diagnostics.Debug.WriteLine(sqlred.GetString(0));
                }
                sqlred.Close();
                
            }
            using (SqlCommand scmd = new SqlCommand("SELECT * FROM IllnessTable", sconn, tran))
            {
                SqlDataReader sqlred = scmd.ExecuteReader();
                while (sqlred.Read())
                {
                    System.Diagnostics.Debug.WriteLine(sqlred.GetString(1));
                }
                sqlred.Close();
            }
            using (SqlCommand scmd = new SqlCommand("SELECT * FROM SymptomsTable", sconn, tran))
            {
                SqlDataReader sqlred = scmd.ExecuteReader();
                while (sqlred.Read())
                {
                    System.Diagnostics.Debug.WriteLine(sqlred.GetString(1));
                }
                sqlred.Close();
            }
            using (SqlCommand scmd = new SqlCommand("SELECT b.illness_name, c.symptom_name FROM IllnessSymptomsTable a INNER JOIN IllnessTable b ON a.illness_id = b.illness_id INNER JOIN SymptomsTable c ON a.symptom_id = c.symptom_id", sconn, tran))
            {
                SqlDataReader sqlred = scmd.ExecuteReader();
                while (sqlred.Read())
                {
                    System.Diagnostics.Debug.WriteLine(sqlred.GetString(1));
                }
                sqlred.Close();
            }
            tran.Rollback("SavePoint1");
            sconn.Close();
            
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

        private void btnSQL_Click(object sender, EventArgs e)
        {
            form.SQL.SQLQueryTool sq = new form.SQL.SQLQueryTool(sconn);
            sq.Show();
        }

        private void Homepage_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
