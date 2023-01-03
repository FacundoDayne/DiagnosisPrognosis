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
    public partial class AddPatientForm : UserControl
    {
        public AddPatientForm()
        {
            InitializeComponent();
			//UpdateData();
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

		private void btnDeletePatient_Click(object sender, EventArgs e)
		{
			
		}

		private void btnEditPatient_Click(object sender, EventArgs e)
		{
			dgPatients.DataSource = null;
		}

		public void UpdateData()
		{
			string[] ends = { "%patientTable%" };
			string[] datas = ConnectServer.GetData(ConnectServer.AskPatientTable(), ends);
			DataSet PatientTable = DataSerial.DeserializeData(datas[0]);
			dgPatients.DataSource = PatientTable.Tables[0];

			DataSet PatientList = DataSerial.DeserializeData(datas[1]);

			cmbSearchPatient.DataSource = PatientList.Tables[0];
			cmbSearchPatient.ValueMember = "ID";
			cmbSearchPatient.DisplayMember = "Name";

			cmbSearchPatient.SelectedIndex = -1;
			cmbSearchPatient.Text = "";

			//dgPatients.Update();
		}

		public void UpdateInfo()
		{
			string[] ends = { "%patientInfo%" };
			string[] data = ConnectServer.GetData(ConnectServer.AskPatientInfo(Convert.ToInt32(cmbSearchPatient.SelectedValue)), ends);

			lblPatient.Text = data[0];
			lblAge.Text = data[1];
			lblGender.Text = data[2];
			lblCourse.Text = data[3];
		}

		private void btnEditPatient_VisibleChanged(object sender, EventArgs e)
		{
			UpdateData();
		}

		private void cmbSearchPatient_SelectionChangeCommitted(object sender, EventArgs e)
		{
			UpdateInfo();
		}

		private void btnNewPatient_Click(object sender, EventArgs e)
		{
			PatientForm form = new PatientForm();
			this.Visible = false;
			form.ShowDialog();
			if (form.ShowDialog() == DialogResult.OK)
			{
				this.Visible = true;
			}
		}
	}
}
