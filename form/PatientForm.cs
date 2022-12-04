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
using System.Text.RegularExpressions;

namespace DiagnosisPrognosis
{
    public partial class PatientForm : Form
    {

        static string betaString = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True;AttachDbFilename=";
        static string connectionString = betaString + LandingForm.DatabasePath;
        string DatabasePath;
        SqlConnection sconn;
        Regex contactRx;
        Regex stNumRx;

        public PatientForm()
        {
            InitializeComponent();

            //contactRx = new Regex(@"([0-9]{11})||(+[0-9]{12})");
            contactRx = new Regex(@"([0-9]{11})||([+]{1}[0-9]{12})");
            stNumRx = new Regex(@"(0-9){10,11}");

            try
            {
                DatabasePath = DiagnosisPrognosis.form.Transfer.DatabasePath;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }

            sconn = new SqlConnection(@"Data Source=.\SQLEXPRESS;" +
                                                    "AttachDbFilename=" + DatabasePath + "; " +
                                                    "Integrated Security=True; " +
                                                    "Connect Timeout=30; " +
                                                    "User Instance=True");
            /*
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

            */

            try
            {
                form.Transfer.sconn.Open();

                using (SqlDataAdapter scmd = new SqlDataAdapter("SELECT sex_id, sex_name FROM SexTable;", form.Transfer.sconn))
                {
                    SqlCommandBuilder scmbld = new SqlCommandBuilder(scmd);
                    DataSet datset = new DataSet();
                    scmd.Fill(datset);

                    cmbSex.DataSource = datset.Tables[0];
                    cmbSex.ValueMember = "sex_id";
                    cmbSex.DisplayMember = "sex_name";

                }

                using (SqlDataAdapter scmd = new SqlDataAdapter("SELECT course_id, course_name FROM CourseTable;", form.Transfer.sconn))
                {
                    SqlCommandBuilder scmbld = new SqlCommandBuilder(scmd);
                    DataSet datset = new DataSet();
                    scmd.Fill(datset);

                    cmbCourse.DataSource = datset.Tables[0];
                    cmbCourse.ValueMember = "course_id";
                    cmbCourse.DisplayMember = "course_name";

                }
                form.Transfer.sconn.Close();
            } catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }

            cmbCourse.SelectedIndex = -1;
            cmbCourse.ResetText();
            cmbSex.SelectedIndex = -1;
            cmbSex.ResetText();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtLastName.Text != "" && txtFirstName.Text != "" && txtMiddleName.Text != "" &&
                txtAge.Text != "" && txtContact.Text != "" && cmbCourse.Text != "" && cmbSex.Text != "")
            {
                if (contactRx.IsMatch(txtContact.Text))
                {
                    try
                    {

                        using (form.Transfer.sconn)
                        {

                            //lname, fname, mname, age, sex, course, contactnum, bday, ch1, ch2, ch3, rb

                            try
                            {
                                Int32.Parse(txtAge.Text);
                            } catch(FormatException ex)
                            {
                                MessageBox.Show("Age wust be numerical");
                            }

                            form.Transfer.sconn.Open();
                            SqlTransaction transc = form.Transfer.sconn.BeginTransaction();

                            SqlCommand sqlAddPatient = new SqlCommand(
                                "INSERT INTO PatientTable values(@LastName, @FirstName, @MiddleName," +
                                "@Age, @Sex, @Course, @Contact, @Birthdate, @Allergy, @Consult, @Checkup, @Medicalneeds, @StudentNum)"
                                , form.Transfer.sconn, transc);

                            sqlAddPatient.Parameters.AddWithValue("@LastName", txtLastName.Text);
                            sqlAddPatient.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                            sqlAddPatient.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                            sqlAddPatient.Parameters.AddWithValue("@Age", Convert.ToInt32(txtAge.Text));
                            sqlAddPatient.Parameters.AddWithValue("@Sex", Convert.ToByte(cmbSex.SelectedValue));
                            sqlAddPatient.Parameters.AddWithValue("@Course", Convert.ToInt16(cmbCourse.SelectedValue));
                            sqlAddPatient.Parameters.AddWithValue("@Contact", txtContact.Text);
                            sqlAddPatient.Parameters.AddWithValue("@Birthdate", SqlDbType.Date).Value = datepickerBirthDate.Value.Date;
                            sqlAddPatient.Parameters.AddWithValue("@Allergy", radAllergyYes.Checked);
                            sqlAddPatient.Parameters.AddWithValue("@Consult", chkConcern1.Checked);
                            sqlAddPatient.Parameters.AddWithValue("@Checkup", chkConcern2.Checked);
                            sqlAddPatient.Parameters.AddWithValue("@Medicalneeds", chkConcern3.Checked);
                            sqlAddPatient.Parameters.AddWithValue("@StudentNum", Convert.ToInt32(txtStudentNum.Text));

                            sqlAddPatient.ExecuteNonQuery();

                            //form.SQL.SQLOutput frm = new form.SQL.SQLOutput("SELECT * FROM PatientTable;", form.Transfer.sconn, false, transc);
                            //frm.ShowDialog();

                            transc.Commit();
                            
                            form.Transfer.sconn.Close();
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, ex.ToString());
                        
                    }
                }
                else if (!contactRx.IsMatch(txtContact.Text))
                {
                    MessageBox.Show("Contact number not in correct format");
                }
            } else
            {
                MessageBox.Show("Fill up the empty fields");
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

        private void pbClose_Click(object sender, EventArgs e)
        {
            if (sconn.State == ConnectionState.Open)
            {
                sconn.Close();
            }
            this.Dispose();
        }

        private void PatientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
