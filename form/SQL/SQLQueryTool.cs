using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DiagnosisPrognosis.form.SQL
{
    public partial class SQLQueryTool : Form
    {
        SQLOutput sqout;
        string DatabasePath;
        SqlConnection sconn;
        public SQLQueryTool(SqlConnection sconn)
        {
            InitializeComponent();
            this.sconn = sconn;
            //DatabasePath = DiagnosisPrognosis.Transfer.DatabasePath;
            /*sconn = new SqlConnection(@"Data Source=.\SQLEXPRESS;" +
                                                    "AttachDbFilename=" + DatabasePath + "; " +
                                                    "Integrated Security=True; " +
                                                    "Connect Timeout=30; " +
                                                    "User Instance=True");*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = textBox1.Text;
                if (query != "")
                {
                    sqout = new SQLOutput(query, sconn, true);
                    if (sqout.IsDisposed != true)
                        sqout.ShowDialog();
                }
            } catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            } catch (ObjectDisposedException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
