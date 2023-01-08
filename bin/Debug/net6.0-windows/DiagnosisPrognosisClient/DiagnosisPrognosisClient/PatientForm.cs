using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace DiagnosisPrognosisClient
{
    public partial class PatientForm : Form
    {
		private bool editmode = false;
		private int id = -1;
		public PatientForm()
		{
			InitializeComponent();
			FillComboBox();
			btnClear.Enabled = true;
			btnClear.Visible = true;
			txtStudentNum.Enabled = true;
			dateBirthdate.Enabled = true;
			cmbSex.Enabled = true;
		}
        public PatientForm(int id)
        {
			editmode = true;
			this.id = id;
			InitializeComponent();
			AddData();
			btnClear.Enabled = false;
			btnClear.Visible = false;
			txtStudentNum.Enabled = false;
			dateBirthdate.Enabled = false;
			cmbSex.Enabled = false;
		}

		private void FillComboBox()
		{
			string[] ends = { "%sexCourseInfo%" };
			string[] datas = ConnectServer.GetData(ConnectServer.AskSexCourse(), ends);


			DataSet datset1 = DataSerial.DeserializeData(datas[0]);

			cmbSex.DataSource = datset1.Tables[0];
			cmbSex.ValueMember = "sex_id";
			cmbSex.DisplayMember = "sex_name";

			DataSet datset2 = DataSerial.DeserializeData(datas[1]);

			cmbCourse.DataSource = datset2.Tables[0];
			cmbCourse.ValueMember = "course_id";
			cmbCourse.DisplayMember = "course_name";
		}

		private void AddData()
		{
			if (id == -1)
			{
				return;
			}

			string[] ends = { "%patientAllInfoSC%" };
			string[] datas = ConnectServer.GetData(ConnectServer.AskSexCoursePatientAllInfo(id), ends);


			DataSet datset1 = DataSerial.DeserializeData(datas[13]);

			cmbSex.DataSource = datset1.Tables[0];
			cmbSex.ValueMember = "sex_id";
			cmbSex.DisplayMember = "sex_name";

			DataSet datset2 = DataSerial.DeserializeData(datas[14]);

			cmbCourse.DataSource = datset2.Tables[0];
			cmbCourse.ValueMember = "course_id";
			cmbCourse.DisplayMember = "course_name";

			bool allergy = false, consultation = false, checkup = false, medicalneeds = false;
			if (datas[8] == "1")
				allergy = true;
			if (datas[9] == "1")
				consultation = true;
			if (datas[10] == "1")
				checkup = true;
			if (datas[11] == "1")
				medicalneeds = true;

			txtLastName.Text = datas[0];
			txtFirstName.Text = datas[1];
			txtMiddleName.Text = datas[2];
			txtAge.Text = datas[3];
			cmbSex.SelectedIndex = Convert.ToInt32(datas[4]);
			cmbSex.Text = cmbSex.Items[cmbSex.SelectedIndex].ToString();
			cmbCourse.SelectedIndex = Convert.ToInt32(datas[5]);
			cmbCourse.Text = cmbCourse.Items[cmbCourse.SelectedIndex].ToString();
			txtContactNum.Text = datas[6];
			dateBirthdate.Value = DateTime.Parse(datas[7]);
			chkMed1.Checked = consultation;
			chkMed2.Checked = checkup;
			chkMed3.Checked = medicalneeds;
			chkAllergy.Checked = allergy;
			txtStudentNum.Text = datas[12];
			
		}

		private void EditModeUi()
		{
			btnClear.Enabled = false;
			btnClear.Visible = false;
			dateBirthdate.Enabled = false;
		}

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void btnSubmit_Click(object sender, EventArgs e)
		{
			int allergy = 0, consultation = 0, checkup = 0, medicalneeds = 0;
			if (chkAllergy.Checked == true)
				allergy = 1;
			if (chkMed1.Checked == true)
				consultation = 1;
			if (chkMed2.Checked == true)
				checkup = 1;
			if (chkMed3.Checked == true)
				medicalneeds = 1;

			if (editmode == false)
			{
				string data = "";
				data += txtLastName.Text + "%patientInfo%";
				data += txtFirstName.Text + "%patientInfo%";
				data += txtMiddleName.Text + "%patientInfo%";
				data += txtAge.Text + "%patientInfo%";
				data += cmbSex.SelectedValue + "%patientInfo%";
				data += cmbCourse.SelectedValue + "%patientInfo%";
				data += txtContactNum.Text + "%patientInfo%";
				data += dateBirthdate.Value.ToString("yyyy-MM-dd") + "%patientInfo%";
				data += allergy.ToString() + "%patientInfo%";
				data += consultation.ToString() + "%patientInfo%";
				data += checkup.ToString() + "%patientInfo%";
				data += medicalneeds.ToString() + "%patientInfo%";
				data += txtStudentNum.Text + "";
				ConnectServer.AskAddPatient(data);
			}
			else if (editmode == true)
			{
				string data = this.id + "%patientInfo%";
				data += txtLastName.Text + "%patientInfo%";
				data += txtFirstName.Text + "%patientInfo%";
				data += txtMiddleName.Text + "%patientInfo%";
				data += txtAge.Text + "%patientInfo%";
				data += cmbSex.SelectedValue + "%patientInfo%";
				data += cmbCourse.SelectedValue+ "%patientInfo%";
				data += txtContactNum.Text + "%patientInfo%";
				data += dateBirthdate.Value.ToString("yyyy-MM-dd") + "%patientInfo%";
				data += allergy.ToString() + "%patientInfo%";
				data += consultation.ToString() + "%patientInfo%";
				data += checkup.ToString() + "%patientInfo%";
				data += medicalneeds.ToString() + "%patientInfo%";
				data += txtStudentNum.Text + "";
				ConnectServer.AskUpdatePatient(data);
			}
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void PatientForm_FormClosed(object sender, FormClosedEventArgs e)
		{

		}

		private void PatientForm_FormClosing(object sender, FormClosingEventArgs e)
		{
		}
	}
}
