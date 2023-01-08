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
    public partial class DiagnosisUC : UserControl
    {
		private bool allergy = false, consultation = false, checkup = false, medicalneeds = false;
		private DataTable selectedSymptoms, symptomTable;
		private List<int> selectedIds;

		private string toSaveSymptom;
		private string toSaveIllness;

		public DiagnosisUC()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

		private void label7_Click_1(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void label6_Click(object sender, EventArgs e)
		{

		}

		private void label8_Click(object sender, EventArgs e)
		{

		}

		private void DiagnosisUC_VisibleChanged(object sender, EventArgs e)
		{

		}

		private void DiagnosisUC_Load(object sender, EventArgs e)
		{
			if (Transfer.usertype == 0)
			{
				pnlDoctorPanel.Enabled = false;
				pnlDoctorPanel.Visible = false;
				pnlPatientPanel.Enabled = true;
				pnlPatientPanel.Visible = true;
				lblUserPatientName.Visible = false;
				btnSelectPatient.Visible = false;
				btnSelectPatient.Enabled = false;
				updatePatientInfo(Transfer.userid);
			}
			else
			{
				if (Transfer.selectedPatient != -1)
				{

				}
				pnlDoctorPanel.Enabled = true;
				pnlDoctorPanel.Visible = true;
				pnlPatientPanel.Enabled = false;
				pnlPatientPanel.Visible = false;
				lblUserPatientName.Visible = false;
				btnSelectPatient.Visible = true;
				btnSelectPatient.Enabled = true;
			}

			ConnectServer.AskSymptomTable();

			string[] ends = { "%symptomTable%" };
			string[] datas = ConnectServer.GetData(ConnectServer.AskSymptomTable(), ends);
			DataSet PatientTable = DataSerial.DeserializeData(datas[0]);
			dgSymptomsList.DataSource = PatientTable.Tables[0];
			symptomTable = PatientTable.Tables[0];
			dgSymptomsList.Columns[0].Width = 1;
			dgSymptomsList.Columns[0].Visible = false;
			dgSymptomsList.Columns[1].Width = 200;

			selectedSymptoms = ((DataTable)dgSymptomsList.DataSource).Clone();
			dgSelectedSymptoms.DataSource = selectedSymptoms;
			dgSelectedSymptoms.Columns[0].Width = 1;
			dgSelectedSymptoms.Columns[0].Visible = false;
			dgSelectedSymptoms.Columns[1].Width = 200;

			selectedIds = new List<int>();
		}

		private void btnSubmitSymptom_Click(object sender, EventArgs e)
		{
			if (selectedIds == null)
			{
				return;
			}
			if (selectedIds.Count == 0)
			{
				return;
			}
			string[] ends = { "%IllnessTable%" };
			string[] datas = ConnectServer.GetData(ConnectServer.SubmitSymptoms(selectedIds), ends);
			DataSet IllnessTable = DataSerial.DeserializeData(datas[0]);
			DataTable DisplayIllness = new DataTable();
			DisplayIllness.Columns.Add("ID");
			DisplayIllness.Columns.Add("Name");
			DisplayIllness.Columns.Add("Symptoms");
			foreach(DataRow x in IllnessTable.Tables[0].Rows)
			{
				string symptomsString = x[2].ToString();
				string matchedString = x[3].ToString();
				string[] symptoms = symptomsString.Split('.');
				string[] matched = matchedString.Split('.');
				string matchsymptom = (matched.Length).ToString() + "/" + (symptoms.Length).ToString();
				DisplayIllness.Rows.Add(x[0], x[1], matchsymptom);
			}
			dgResultIllness.DataSource = DisplayIllness;
		}

		private void btnSaveDiagnosis_Click(object sender, EventArgs e)
		{
			// Save diagnosis
			toSaveIllness = "";
			toSaveSymptom = "";
			
			for (int x = 0; x < selectedIds.Count; x++)
			{
				toSaveSymptom += selectedIds[x];
				if (x != selectedIds.Count-1)
				{
					toSaveSymptom += ".";
				}
			}
			DataTable tempData = (DataTable)dgResultIllness.DataSource;
			for (int x = 0; x < tempData.Rows.Count; x++)
			{
				toSaveIllness += (tempData.Rows[x])[0].ToString();
				if (x != tempData.Rows.Count-1)
				{
					toSaveIllness += ".";
				}
			}
			//Debug.WriteLine(toSaveSymptom + " " + toSaveIllness);
			ConnectServer.SubmitDiagnosis(toSaveSymptom, toSaveIllness);
		}

		private void btnAddSymptom_Click(object sender, EventArgs e)
		{
			//Add symptom`
			int id = -1;
			try
			{
				id = Convert.ToInt32(dgSymptomsList.CurrentRow.Cells[0].Value);
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
			int index = dgSymptomsList.CurrentRow.Index;

			int symptomId = Convert.ToInt32(symptomTable.Rows[index].ItemArray.ToArray()[0]);

			if (!selectedIds.Contains(symptomId))
			{
				selectedSymptoms.Rows.Add(symptomTable.Rows[index].ItemArray);
				dgSelectedSymptoms.DataSource = selectedSymptoms;
				dgSelectedSymptoms.Columns[0].Width = 1;
				dgSelectedSymptoms.Columns[0].Visible = false;
				dgSelectedSymptoms.Columns[1].Width = 200;
				selectedIds.Add(symptomId);
			}
		}

		private void updateSymptomList()
		{

		}

		private void updatePatientInfo(int id)
		{
			if (id == -1)
			{
				return;
			}

			string[] ends = { "%patientAllInfo%" };
			string[] datas = ConnectServer.GetData(ConnectServer.AskPatientAllInfo(id), ends);

			
			if (datas[8] == "1")
				allergy = true;
			if (datas[9] == "1")
				consultation = true;
			if (datas[10] == "1")
				checkup = true;
			if (datas[11] == "1")
				medicalneeds = true;

			string name = $"{datas[1]} {datas[2]} {datas[0]}";
			lblDiagPatient.Text = name;
			lblDiagAge.Text = datas[3];
			lblSex.Text = datas[13];
			chkConsultation.Checked = consultation;
			chkCheckup.Checked = checkup;
			chkMedical.Checked = medicalneeds;
			chkAllergies.Checked = allergy;
		}

		private void chkConsultation_CheckedChanged(object sender, EventArgs e)
		{
			chkConsultation.Checked = consultation;
			chkCheckup.Checked = checkup;
			chkMedical.Checked = medicalneeds;
			chkAllergies.Checked = allergy;
		}
	}
}
