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
    public partial class Login : Form
	{
		

		public Login()
        {
            InitializeComponent();
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
			this.Dispose();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
			if (ConnectServer.checkServer(txtIp.Text))
			{
				Homepage home = null;
				if (ConnectServer.CheckServerSuccess() == 1)
				{
					MessageBox.Show("Server failed to connect to database", "Server Error");
					return;
				}
				if (ConnectServer.CheckServerSuccess() == 1)
				{
					MessageBox.Show("An error occured", "Server Error");
					return;
				}

				if ((txtUsername.Text == "") || (txtPassword.Text == ""))
				{
					MessageBox.Show("Fill up the fields", "Login Error");
					return;
				}

				if (ConnectServer.TryLogin(txtUsername.Text, txtPassword.Text) == 0)
				{
					MessageBox.Show("An error occured", "Server Login Error");
					return;
				}
				else if (ConnectServer.TryLogin(txtUsername.Text, txtPassword.Text) == 1)
				{
					MessageBox.Show("Invalid Username", "Login Error");
					return;
				}
				else if (ConnectServer.TryLogin(txtUsername.Text, txtPassword.Text) == 2)
				{
					MessageBox.Show("Invalid Password", "Login Error");
					return;
				}

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
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
    }
}
