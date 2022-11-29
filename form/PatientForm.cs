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
    public partial class PatientForm : Form
    {

        static string betaString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=";
        static string connectionString = betaString + LandingForm.DatabasePath;

        public PatientForm()
        {
            InitializeComponent();
            Sex[] sexes = new Sex[]
            {
                new Sex(0, "Not Known"),
                new Sex(1, "Male"),
                new Sex(2, "Female"),
                new Sex(9, "Not Applicable")
            };
            Course[] courses = new Course[]
            {
                new Course(0, "Not Applicable"),
                new Course(1, "BSIT"),
                new Course(2, "BACOMM"),
                new Course(3, "BSHM")
            };
            cmbSex.DataSource = sexes;
            cmbSex.ValueMember = "id";
            cmbSex.DisplayMember = "name";
            cmbCourse.DataSource = courses;
            cmbCourse.ValueMember = "id";
            cmbCourse.DisplayMember = "name";

            cmbCourse.SelectedIndex = -1;
            cmbCourse.ResetText();
            cmbSex.SelectedIndex = -1;
            cmbSex.ResetText();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConne = new SqlConnection(connectionString))
            {
                
                sqlConne.Open();

                SqlCommand sqlAddPatient = new SqlCommand(
                    "INSERT INTO PatientTable valuse('@LastName', '@FirstName', '@MiddleName'," +
                    "@Age, @Sex, @Course, '@Contact', '@Birthdate', @Allergy, @Consult, @Checkup, @Medicalneeds)"
                    , sqlConne); 
                
                sqlAddPatient.Parameters.AddWithValue("@LastName", txtLastName.Text);
                sqlAddPatient.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                sqlAddPatient.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                sqlAddPatient.Parameters.AddWithValue("@Age", Convert.ToInt32(txtAge.Text));
                sqlAddPatient.Parameters.AddWithValue("@Sex", Convert.ToByte(cmbSex.SelectedValue));
                sqlAddPatient.Parameters.AddWithValue("@Course", Convert.ToInt16(cmbCourse.SelectedValue));
                sqlAddPatient.Parameters.AddWithValue("@Contact", txtContact.Text);
                sqlAddPatient.Parameters.AddWithValue("@Birthdate", datepickerBirthDate.Value.ToString("yyyy-MM-dd"));
                sqlAddPatient.Parameters.AddWithValue("@Allergy", radAllergyYes.Checked);
                sqlAddPatient.Parameters.AddWithValue("@Consult", chkConcern1.Checked);
                sqlAddPatient.Parameters.AddWithValue("@Checkup", chkConcern2.Checked);
                sqlAddPatient.Parameters.AddWithValue("@Medicalneeds", chkConcern3.Checked);
                
                sqlConne.Close();
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLastName.ResetText();
            txtFirstName.ResetText();
            txtMiddleName.ResetText();
            txtAge.ResetText();
            txtContact.ResetText();

            cmbCourse.SelectedIndex = -1;
            cmbCourse.ResetText();
            cmbSex.SelectedIndex = -1;
            cmbSex.ResetText();

            radAllergyNo.Checked = true;
            radAllergyYes.Checked = false;

            datepickerBirthDate.ResetText();

            chkConcern1.Checked = false;
            chkConcern2.Checked = false;
            chkConcern3.Checked = false;
        }

        internal class Sex
        {
            private byte _id;
            private string _name;

            public byte id { get => _id; set => _id = value; }
            public string name { get => _name; set => _name = value; }

            public Sex(byte id, string name)
            {
                this._id = id;
                this._name = name;
            }
        }
        internal class Course
        {
            private short _id;
            private string _name;

            public short id { get => _id; set => _id = value; }
            public string name { get => _name; set => _name = value; }

            public Course(short id, string name)
            {
                this._id = id;
                this._name = name;
            }
        }
    }
}
