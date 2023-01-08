using System;
using System.Diagnostics;
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

		private void dgPatients_SelectionChanged(object sender, EventArgs e)
		{
			int id = -1;
			try
			{
				id = Convert.ToInt32(dgPatients.CurrentRow.Cells[0].Value);
			}
			catch (NullReferenceException)
			{
				id = -1;
			}
			catch (IndexOutOfRangeException)
			{
				id = -1;
			}
			catch (InvalidCastException)
			{
				id = -1;
			}
			if (id == -1)
				return;
			UpdateInfo(id);
			Debug.WriteLine(id);
		}

		public void UpdateData()
		{
			dgPatients.ClearSelection();

			string[] ends = { "%patientTable%" };
			string[] datas = ConnectServer.GetData(ConnectServer.AskPatientTable(), ends);
			DataSet PatientTable = DataSerial.DeserializeData(datas[0]);
			dgPatients.DataSource = PatientTable.Tables[0];
			dgPatients.Columns[0].Width = 1;
			dgPatients.Columns[0].Visible = false;
			dgPatients.Columns[1].Width = 464;

			DataSet PatientList = DataSerial.DeserializeData(datas[1]);

			cmbSearchPatient.DataSource = PatientList.Tables[0];
			cmbSearchPatient.ValueMember = "ID";
			cmbSearchPatient.DisplayMember = "Name";

			cmbSearchPatient.SelectedIndex = -1;
			cmbSearchPatient.Text = "";

			//dgPatients.Update();
		}

		public void UpdateInfo(int id)
		{
			string[] ends = { "%patientInfo%" };
			string[] data = ConnectServer.GetData(ConnectServer.AskPatientInfo(id), ends);

			lblPatient.Text = data[0];
			lblAge.Text = data[1];
			lblGender.Text = data[2];
			lblCourse.Text = data[3];
		}

		private void btnDeletePatient_Click(object sender, EventArgs e)
		{
			UpdateData();
		}

		private void btnNewPatient_Click(object sender, EventArgs e)
		{
			PatientForm frm = new PatientForm();
			frm.ShowDialog();
			if (frm.DialogResult == DialogResult.OK)
			{
				UpdateData();
			}
		}

		private void btnEditPatient_Click(object sender, EventArgs e)
		{
			if (Convert.ToInt32(dgPatients.CurrentRow.Cells[0].Value) < 0)
			{
				return;
			}
			PatientForm frm = new PatientForm(Convert.ToInt32(dgPatients.CurrentRow.Cells[0].Value));
			
			frm.ShowDialog();

			if (frm.DialogResult == DialogResult.OK)
			{
				UpdateData();
			}
		}

		private void AddPatientForm_VisibleChanged(object sender, EventArgs e)
		{

		}
	}
}
