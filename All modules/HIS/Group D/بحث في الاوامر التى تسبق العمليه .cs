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
namespace HIS
{
    public partial class opForm10 : Form
    {
        public SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection con;
        DataSet ds = new DataSet();
        Connection connect;
        public opForm10()
        {
            InitializeComponent();
            connect = new Connection();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {


            /*
           connect.OpenConection();
           string pName = "planing_organiz_struc2";
           string[] paramNames = { "@year", "@target_num", "@existStaff_num", "@estimated_salary" };
           string[] paramValues = { textBox5.Text, textBox1.Text, textBox3.Text, textBox2.Text };
           SqlDbType[] paramType = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };
           connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames, paramValues, paramType);

           
            * connect.ShowDataInGridViewUsingStoredProc(pName);
            * connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
            * connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames, paramValues, paramType);
            */

           
           
            try
            {
                connect.OpenConection();
                if (textBox2.Text != "")
                {
                    string pName = "op_orderpre_operation1";
                    string[] paramNames = { "@op_code" };
                    string[] paramValues = { textBox2.Text };
                    SqlDbType[] paramType = { SqlDbType.Int};
                    dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
                }
                    
                else
                {
                    string pName = "op_orderBeforeOperation2";
                    dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void opForm10_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
