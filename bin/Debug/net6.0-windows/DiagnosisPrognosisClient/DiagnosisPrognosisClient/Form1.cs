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
            inventoryUC1.Visible = false;

        }

        private void btnPatientInfo_Click(object sender, EventArgs e)
        {
            addPatientForm1.Visible = !addPatientForm1.Visible;
            diagnosisUC1.Visible = false;
            inventoryUC1.Visible = false;
        }

        private void btnDiagnosis_Click(object sender, EventArgs e)
        {
            diagnosisUC1.Visible = !diagnosisUC1.Visible;
            addPatientForm1.Visible = false;
            inventoryUC1.Visible = false;
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            inventoryUC1.Visible = !inventoryUC1.Visible;
            addPatientForm1.Visible = false;
            diagnosisUC1.Visible = false;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pbSTIlogo_Click(object sender, EventArgs e)
        {
            pbSTICampus.Visible = true;
            addPatientForm1.Visible = false;
            diagnosisUC1.Visible = false;
            inventoryUC1.Visible = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
			this.Visible = false;
			log.Visible = true;
        }
    }
}
