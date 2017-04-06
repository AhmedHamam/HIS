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
    public partial class opForm11 : Form
    {
        public string s;
        public SqlDataAdapter da;
        
        SqlDataReader dr;
        SqlConnection con;
        DataSet ds = new DataSet();
        Connection connect;
        public opForm11()
        {
            InitializeComponent();
            connect = new Connection();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {

                if (radioButton3.Checked)
                {


                    connect.OpenConection();
                    string pName = "op_scedualOperation3";
                    string[] paramNames = { "@op_date " };
                    string[] paramValues = { dateTimePicker1.Value.ToString() };
                    SqlDbType[] paramType = { SqlDbType.VarChar };
                 dataGridView1.DataSource= connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);

                    /*
                     * connect.ShowDataInGridViewUsingStoredProc(pName);
                     * connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
                     * connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames, paramValues, paramType);
                     */


                }


                else if (radioButton2.Checked)
                {
                  


                    connect.OpenConection();
                    string pName = "op_scedualOperation2";
                    string[] paramNames = { "@op_code " };
                    string[] paramValues = { textBox1.Text };
                    SqlDbType[] paramType = { SqlDbType.VarChar };
                    dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);

                    /*
                     * connect.ShowDataInGridViewUsingStoredProc(pName);
                     * connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
                     * connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames, paramValues, paramType);
                     */



                }

                else if (radioButton1.Checked)
                {
                  
                  
                    connect.OpenConection();
                    string pName = "op_scedualOperation1";
                    string[] paramNames = { "@op_name " };
                    string[] paramValues = { textBox2.Text };
                    SqlDbType[] paramType = { SqlDbType.VarChar };
                    dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);

                    /*
                     * connect.ShowDataInGridViewUsingStoredProc(pName);
                     * connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
                     * connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames, paramValues, paramType);
                     */

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void opForm11_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                opForm12 fr12 = new opForm12(textBox1.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
