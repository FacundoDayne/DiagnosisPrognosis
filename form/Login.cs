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
    public partial class Login : Form
    {
        Homepage home;

        //SqlConnection sconn;

        public Login()
        {
            InitializeComponent();
            /*
            sconn = new SqlConnection(@"Data Source=.\SQLEXPRESS;" +
                                                    "AttachDbFilename=" + DatabasePath + "; " +
                                                    "Integrated Security=True; " +
                                                    "Connect Timeout=30; " +
                                                    "User Instance=True");

            PassHash pass = new PassHash("admin");
            byte[] urk = pass.ToArray();
            string la = "";
            foreach(byte x in urk)
            {
                la = la + x.ToString();
            }
            PassHash pass2 = new PassHash(urk);

            System.Diagnostics.Debug.WriteLine(la);
            System.Diagnostics.Debug.WriteLine(pass2.Verify("Nampa"));
            System.Diagnostics.Debug.WriteLine(pass2.Verify("Faren"));
            System.Diagnostics.Debug.WriteLine(pass2.Verify("SetungHaliff"));
            */
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            home = new Homepage();
            this.Visible = false;
            home.ShowDialog();
            if (home.DialogResult == DialogResult.OK)
                this.Visible = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
