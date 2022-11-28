using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagnosisPrognosis
{
    public partial class DiagnosisUC : UserControl
    {
        Handler handler;
        public DiagnosisUC()
        {
            handler = new Handler();
            InitializeComponent();
            handler.tempData();
            cmbDiagSymptoms.DataSource = handler.getAllSymptom();
            cmbDiagSymptoms.DisplayMember = "symptomName";
            cmbDiagSymptoms.ValueMember = "symptomID";
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmitSymptoms_Click(object sender, EventArgs e)
        {
            handler.addGivenSymptom(Convert.ToInt32(cmbDiagSymptoms.SelectedValue));
            listView1.Items.Add(cmbDiagSymptoms.Text);
        }

        private void btnSubmitDiagnosis_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Click");
            handler.checkForMatch();
            List<Illness> illnesses = new List<Illness>(handler.getMatchedIllnessesX());
            foreach (Illness x in illnesses)
            {
                double percen = Math.Round((Convert.ToDouble(x.getNumOfMatches()) / Convert.ToDouble(x.getNumOfSymptoms())) * 100.00, 2);
                listView2.Items.Add(x.illnessName + " - " + percen + "%");
            }
        }
    }
}
