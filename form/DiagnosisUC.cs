using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagnosisPrognosis
{
    public partial class DiagnosisUC : UserControl
    {
        Handler handler;
        SqlConnection sconn;
        List<Symptom> symptoms;

        public DiagnosisUC(SqlConnection sconn)
        {
            this.sconn = sconn;

            handler = new Handler();

            InitializeComponent();
            symptoms = new List<Symptom>();

            try
            {
                using (SqlConnection sconne = sconn)
                {
                    form.Transfer.sconn.ConnectionString = @"Data Source=.\SQLEXPRESS;" +
                                                "AttachDbFilename=" + form.Transfer.DatabasePath + "; " +
                                                "Integrated Security=True; " +
                                                "Connect Timeout=30; " +
                                                "User Instance=True";
                    sconne.Open();
                    using (SqlDataAdapter datad = new SqlDataAdapter("SELECT patient_id AS 'ID', CONCAT(patient_lastname, ', ', patient_firstname, ' ', SUBSTRING(patient_middlename, 1, 1)) AS 'Name' FROM PatientTable", sconne))
                    {
                        SqlCommandBuilder scmd = new SqlCommandBuilder(datad);
                        DataSet daset = new DataSet();
                        datad.Fill(daset);

                        cmbDiagPatient.DataSource = daset.Tables[0];
                        cmbDiagPatient.ValueMember = "ID";
                        cmbDiagPatient.DisplayMember = "Name";

                        cmbDiagPatient.SelectedIndex = -1;
                        cmbDiagPatient.Text = "";
                    }
                    using (SqlDataAdapter datad = new SqlDataAdapter("SELECT * FROM SymptomsTable", sconne))
                    {
                        SqlCommandBuilder scmd = new SqlCommandBuilder(datad);
                        DataSet daset = new DataSet();
                        datad.Fill(daset);

                        cmbDiagSymptoms.DataSource = daset.Tables[0];
                        cmbDiagSymptoms.ValueMember = "symptom_id";
                        cmbDiagSymptoms.DisplayMember = "symptom_name";

                        cmbDiagSymptoms.SelectedIndex = -1;
                        cmbDiagSymptoms.Text = "";
                    }
                    sconn.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }

            cmbDiagSymptoms.Enabled = false;
            btnSubmitDiagnosis.Enabled = false;
            btnSubmitSymptoms.Enabled = false;

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmitSymptoms_Click(object sender, EventArgs e)
        {
            // Add Symptoms
            if (cmbDiagSymptoms.SelectedIndex != -1)
            {
                if (!btnSubmitDiagnosis.Enabled)
                    btnSubmitDiagnosis.Enabled = true;
                bool exists = false;
                if (symptoms.Count != 0)
                {
                    foreach (Symptom x in symptoms)
                    {
                        if (Convert.ToInt32(cmbDiagSymptoms.SelectedValue) == x.symptomID)
                        {
                            exists = true;
                        }
                    }
                }
                if (!exists)
                {
                    symptoms.Add(new Symptom(Convert.ToInt32(cmbDiagSymptoms.SelectedValue), cmbDiagSymptoms.Text));
                    listView1.Items.Add(cmbDiagSymptoms.Text);
                }
            }
        }

        private void btnSubmitDiagnosis_Click(object sender, EventArgs e)
        {
            List<Illness> matched = SQLCommands.GetIllness(symptoms);
            
            BindingList<displayItems> toDisplay = new BindingList<displayItems>();

            foreach(Illness x in matched)
            {
                toDisplay.Add(new displayItems(x.illnessName, Math.Round((x.getNumOfMatches())/Convert.ToDouble(x.getNumOfSymptoms())*100.00, 2), x.virality));
            }
            dgDiagnosis.DataSource = toDisplay;
            dgDiagnosis.Columns[1].Width = 60;
            dgDiagnosis.Columns[2].Width = 60;
            //dgDiagnosis.Sort(dgDiagnosis.Columns[1], ListSortDirection.Descending);
        }

        protected class displayItems
        {
            private string _name;
            private double _factor;
            private int _virality;

            public string name { get => _name; }
            public double factor {  get => _factor; }
            public int virality { get => _virality; }

            public displayItems(string name, double factor, int viral)
            {
                _name = name;
                _factor = factor;
                _virality = viral;
            }
        }

        private void cmbDiagPatient_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbDiagPatient.SelectedIndex != -1)
            {
                cmbDiagSymptoms.Enabled = true;
                btnSubmitSymptoms.Enabled = true;
            }
            try
            {
                form.Transfer.sconn.ConnectionString = @"Data Source=.\SQLEXPRESS;" +
                                                "AttachDbFilename=" + form.Transfer.DatabasePath + "; " +
                                                "Integrated Security=True; " +
                                                "Connect Timeout=30; " +
                                                "User Instance=True";
                using (form.Transfer.sconn)
                {
                    if (form.Transfer.sconn.State == ConnectionState.Closed)
                    {
                        form.Transfer.sconn.Open();
                    }
                    using (SqlCommand scmd = new SqlCommand("SELECT a.patient_id, CONCAT(a.patient_lastname, ', ', a.patient_firstname, ' ', SUBSTRING(a.patient_middlename, 1, 1)) AS 'Name', a.patient_contactnumber AS 'Contact', b.course_name AS 'Course', a.patient_birthdate AS 'DOB' FROM PatientTable a INNER JOIN CourseTable b ON a.patient_course_id = b.course_id WHERE a.patient_id = @cID", form.Transfer.sconn))
                    {
                        scmd.Parameters.AddWithValue("@cID", SqlDbType.Int).Value = cmbDiagPatient.SelectedValue;
                        SqlDataReader sread = scmd.ExecuteReader();
                        while (sread.Read())
                        {
                            lblDiagPatient.Text = sread.GetString(1);
                            lblDiagContact.Text = sread.GetString(2);
                            lblDiagCourse.Text = sread.GetString(3);
                            lblDiagDOB.Text = sread.GetDateTime(4).ToString("yyyy-MM-dd");
                        }
                    }
                    form.Transfer.sconn.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgDiagnosis.DataSource = null;
            listView1.Clear();
            symptoms.Clear();
            cmbDiagPatient.SelectedIndex = -1;
            cmbDiagPatient.Text = "";
            cmbDiagSymptoms.SelectedIndex = -1;
            cmbDiagSymptoms.Text = "";
            btnSubmitDiagnosis.Enabled = false;
            btnSubmitSymptoms.Enabled = false;
        }
    }
}
