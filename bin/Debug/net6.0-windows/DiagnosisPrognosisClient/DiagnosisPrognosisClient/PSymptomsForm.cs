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
    public partial class PSymptomsForm : Form
    {
        public PSymptomsForm()
        {
            InitializeComponent();
        }

        private void btnSubmitSymp_Click(object sender, EventArgs e)
        {
            QueueingForm qf = new QueueingForm();
            qf.Show();
            PSymptomsForm psf = new PSymptomsForm();
            psf.Close();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
