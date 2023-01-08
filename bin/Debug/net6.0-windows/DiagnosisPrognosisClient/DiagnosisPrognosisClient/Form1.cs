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
    public partial class Homepage : Form
    {
		Login log;
        public Homepage(Login log)
        {
			this.log = log;
            InitializeComponent();
            addPatientForm1.Visible = false;
            diagnosisUC1.Visible = false;
			inventoryuc1.Visible = false;
            

        }
        private void Homepage_Load(object sender, EventArgs e)
        {

        }
        
        
        private void pbSTIlogo_Click(object sender, EventArgs e)
        {
            pbSTICampus.Visible = true;
            addPatientForm1.Visible = false;
            diagnosisUC1.Visible = false;
            inventoryuc1.Visible = false;
        }


        private void pbClose_Click_1(object sender, EventArgs e)
		{
			CloseThis();
		}

        private void pbPatient_Click(object sender, EventArgs e)
        {
            addPatientForm1.Visible = !addPatientForm1.Visible;
            diagnosisUC1.Visible = false;
			inventoryuc1.Visible = false;
			if (addPatientForm1.Visible == false)
				pbSTICampus.Visible = true;
			else
				pbSTICampus.Visible = false;
		}

        private void pbDiagnosis_Click(object sender, EventArgs e)
        {

            diagnosisUC1.Visible = !diagnosisUC1.Visible;
            addPatientForm1.Visible = false;
			inventoryuc1.Visible = false;
			if (diagnosisUC1.Visible == false)
				pbSTICampus.Visible = true;
			else
				pbSTICampus.Visible = false;
		}

        private void pbInventory_Click(object sender, EventArgs e)
        {
			inventoryuc1.Visible = !inventoryuc1.Visible;
            addPatientForm1.Visible = false;
            diagnosisUC1.Visible = false;
			if (inventoryuc1.Visible == false)
				pbSTICampus.Visible = true;
			else
				pbSTICampus.Visible = false;
		}

        private void pbLogout_Click(object sender, EventArgs e)
		{
        }

		private void Homepage_FormClosing(object sender, FormClosingEventArgs e)
		{
			CloseThis();
		}
		
		private void CloseThis()
		{
			log.Visible = true;
			this.Dispose();
		}
	}
}
