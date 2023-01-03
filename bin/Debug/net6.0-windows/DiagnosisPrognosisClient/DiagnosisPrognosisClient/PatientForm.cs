using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagnosisPrognosisClient
{
    public partial class PatientForm : Form
    {
        public PatientForm()
        {
            InitializeComponent();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void btnSubmit_Click(object sender, EventArgs e)
		{

		}

		private void btnClear_Click(object sender, EventArgs e)
		{

		}

		private void CompileInformation()
		{
			string allergy = "0", consultation = "0", checkup = "0", medicalneeds = "0";
			if (radAllergy.Checked)
				allergy = "1";
			if (chkMedicalConcern1.Checked)
				consultation = "1";
			if (chkMedicalConcern2.Checked)
				checkup = "1";
			if (chkMedicalConcern3.Checked)
				medicalneeds = "1";

			string Data = "%patientInfo%" + txtLastName.Text + "%patientInfo%" + txtFirstName.Text + "%patientInfo%" + txtMiddleName.Text + "%patientInfo%" + 
				txtAge.Text + "%patientInfo%" + cmbSex.SelectedValue.ToString() + "%patientInfo%" + cmbCourse.SelectedValue.ToString() + "%patientInfo%" + 
				txtContactNumber.Text + "%patientInfo%" + dateBirthdate.Value.ToString("yyyy-MM-dd") + "%patientInfo%" + allergy + "%patientInfo%" +
				consultation + "%patientInfo%" + checkup + "%patientInfo%" + medicalneeds + "%patientInfo%" + txtStudentNumber + "%patientInfo%";

			List<string> reply = ConnectServer.AskAddPatient(Data);
			string replyCombined = "";
			foreach (string x in reply)
			{
				replyCombined = replyCombined + x;
			}
			if (replyCombined.IndexOf("!Success!") > -1)
			{
				MessageBox.Show("Patient has been successfully added");
			}
			else
			{
				MessageBox.Show("Transaction failed");
			}
		}
	}
}
