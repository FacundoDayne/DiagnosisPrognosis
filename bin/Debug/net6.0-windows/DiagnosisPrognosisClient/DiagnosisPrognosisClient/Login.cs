using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagnosisPrognosisClient
{
    public partial class Login : Form
    {
		Homepage home;

        public Login()
        {
            InitializeComponent();

		}
		
        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

			if (ConnectServer.checkServer())
			{
				Thread.Sleep(5000);
				if (home == null)
				{
					home = new Homepage(this);
					home.Show();
				}
				txtUsername.ResetText();
				txtPassword.ResetText();
				home.Visible = true;
				this.Visible = false;
				return;
			}
			MessageBox.Show("Server is offline", "Connection Error");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
			//ConnectServer.searchIpAddresses();
			//ConnectServer.PrintProcess();
			ConnectServer.AskPatientTable();
        }
    }
}
