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
    public partial class SQLOutput : Form
    {
        string doQuery;
        SqlConnection sconn;
        bool openhere;
        SqlTransaction transc;
        public SQLOutput(string query, SqlConnection sconn, bool here)
        {
            InitializeComponent();
            this.sconn = sconn;
            doQuery = query;
            openhere = here;
            SqlDoStuff();
        }
        public SQLOutput(string query, SqlConnection sconn, bool here, SqlTransaction transc)
        {
            InitializeComponent();
            this.transc = transc;
            this.sconn = sconn;
            doQuery = query;
            openhere = here;
            SqlDoStuff();
        }
        public void SqlDoStuff()
        {
            if (openhere == true)
            {
                Transfer.DatabaseConnection.ConnectionString = @"Data Source=.\SQLEXPRESS;" +
                                                "AttachDbFilename=" + Transfer.DatabasePath + "; " +
                                                "Integrated Security=True; " +
                                                "Connect Timeout=30; " +
                                                "User Instance=True";
                Transfer.DatabaseConnection.Open();
            }
            
            string[] queryArgs = doQuery.Split(' ');
            string queryComm = queryArgs[0].ToUpper();
            try
            {
                switch (queryComm)
                {
                    case "SELECT":
                        if (openhere == true)
                            withTable();
                        else
                            withTable(transc);
                        break;
                    case "INSERT":
                        noTable();
                        break;
                    case "DROP":
                        noTable();
                        break;
                    case "CREATE":
                        noTable();
                        break;
                    default:
                        MessageBox.Show("unknown query", "what");
                        break;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Query Error");
                this.Close();
            }
            if (openhere == true)
            {
                Transfer.DatabaseConnection.Close();
            }
        }
        public void withTable()
        {
            using (SqlDataAdapter datad = new SqlDataAdapter(doQuery, Transfer.DatabaseConnection))
            {
                SqlCommandBuilder scmd = new SqlCommandBuilder(datad);
                DataSet daset = new DataSet();
                
                datad.Fill(daset);
                dataGridView1.ReadOnly = true;

                dataGridView1.DataSource = daset.Tables[0];
            }
        }
        public void withTable(SqlTransaction transc)
        {
            using (SqlDataAdapter datad = new SqlDataAdapter(doQuery, Transfer.DatabaseConnection))
            {
                SqlCommandBuilder scmd = new SqlCommandBuilder(datad);
                DataSet daset = new DataSet();
                datad.SelectCommand.Transaction = transc;
                datad.Fill(daset);
                dataGridView1.ReadOnly = true;

                dataGridView1.DataSource = daset.Tables[0];
            }
        }
        public void noTable()
        {
            SqlTransaction tran = sconn.BeginTransaction("Transact");
            try
            {
                using (SqlCommand scmd = new SqlCommand(doQuery, Transfer.DatabaseConnection, tran))
                {
                    scmd.ExecuteNonQuery();
                }
                tran.Commit();
                MessageBox.Show("Query successful");
                this.Close();
            } catch (SqlException ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message, "SQL Error");
            }
        }
    }
}
