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
    public partial class AddPatientForm : UserControl
    {
        SqlConnection sconn;

        public AddPatientForm(SqlConnection sconn)
        {
            this.sconn = sconn;
            InitializeComponent();
            UpdateData();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnNewPatient_Click(object sender, EventArgs e)
        {
            PatientForm ptFrm = new PatientForm();
            ptFrm.ShowDialog();
            if (ptFrm.DialogResult == DialogResult.OK)
            {
                UpdateData();
            }
        }
        private void UpdateData()
        {
            try
            {
                form.Transfer.sconn.ConnectionString = @"Data Source=.\SQLEXPRESS;" +
                                                "AttachDbFilename=" + form.Transfer.DatabasePath + "; " +
                                                "Integrated Security=True; " +
                                                "Connect Timeout=30; " +
                                                "User Instance=True";
                form.Transfer.sconn.Open();
                using (SqlDataAdapter datad = new SqlDataAdapter("SELECT patient_id AS 'ID', CONCAT(patient_lastname, ', ', patient_firstname, ' ', SUBSTRING(patient_middlename, 1, 1)) AS 'Name' FROM PatientTable", form.Transfer.sconn))
                {
                    SqlCommandBuilder scmd = new SqlCommandBuilder(datad);
                    DataSet daset = new DataSet();
                    datad.Fill(daset);
                    dgPatients.ReadOnly = true;
                    dgPatients.DataSource = daset.Tables[0];
                    dgPatients.Columns[1].Width = 250;
                }
                /*
                    patient_lastname varchar(30), 
	                patient_firstname varchar(30),
	                patient_middlename varchar(30), 
                */
                using (SqlDataAdapter datad = new SqlDataAdapter("SELECT patient_id AS 'ID', CONCAT(patient_lastname, ', ', patient_firstname, ' ', SUBSTRING(patient_middlename, 1, 1)) AS 'Name' FROM PatientTable", form.Transfer.sconn))
                {
                    SqlCommandBuilder scmd = new SqlCommandBuilder(datad);
                    DataSet daset = new DataSet();
                    datad.Fill(daset);

                    cmbSearchPatient.DataSource = daset.Tables[0];
                    cmbSearchPatient.ValueMember = "ID";
                    cmbSearchPatient.DisplayMember = "Name";

                    cmbSearchPatient.SelectedIndex = -1;
                    cmbSearchPatient.Text = "";
                }
                form.Transfer.sconn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }
            //cmbSearchPatient.DataSource
        }

        private void cmbSearchPatient_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (form.Transfer.sconn.State == ConnectionState.Closed)
                {
                    form.Transfer.sconn.ConnectionString = @"Data Source=.\SQLEXPRESS;" +
                                                "AttachDbFilename=" + form.Transfer.DatabasePath + "; " +
                                                "Integrated Security=True; " +
                                                "Connect Timeout=30; " +
                                                "User Instance=True";
                    form.Transfer.sconn.Open();
                }
                using (SqlCommand scmd = new SqlCommand("SELECT a.patient_id, CONCAT(a.patient_lastname, ', ', a.patient_firstname, ' ', SUBSTRING(a.patient_middlename, 1, 1)) AS 'Name', a.patient_age AS 'Age', c.sex_name as 'Sex', b.course_name AS 'Course' FROM PatientTable a INNER JOIN CourseTable b ON a.patient_course_id = b.course_id INNER JOIN SexTable c ON c.sex_id = a.patient_sex_id WHERE a.patient_id = @cID", form.Transfer.sconn))
                {
                    scmd.Parameters.AddWithValue("@cID", SqlDbType.Int).Value = cmbSearchPatient.SelectedValue;
                    SqlDataReader sread = scmd.ExecuteReader();
                    while (sread.Read())
                    {
                        lblPatient.Text = sread.GetString(1);
                        lblAge.Text = Convert.ToString(sread.GetInt32(2));
                        lblGender.Text = sread.GetString(3);
                        lblCourse.Text = sread.GetString(4);
                    }
                }
                form.Transfer.sconn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }
        }
    }
}
