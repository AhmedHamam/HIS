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
    public partial class فريق_العمل : Form
    {
        public فريق_العمل fw;
        public string code;
        public SqlDataAdapter da;
        public SqlDataAdapter daa;
     

        
        Connection connect;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        DataSet dss = new DataSet();
     

        public فريق_العمل()
        {


            InitializeComponent();
            connect = new Connection();
            

        }

        private void فريق_العمل_Load(object sender, EventArgs e)
        {




            connect.OpenConection();


            string pName = "op_teamWork1";
            string[] paramNames = { "@doc_operation_op_code" };
            string[] paramValues = { اعدادات_متقدمه_للعمليه.y };
            SqlDbType[] paramType = { SqlDbType.VarChar };
            dataGridView2.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
            comboBox1.Items.Add("Doctor");
            comboBox1.Items.Add("Nurse");

            ///////
            string[] paramNames2 = { "@emp_operation_op_code" };
            string[] paramValues2 = { اعدادات_متقدمه_للعمليه.y };
            SqlDbType[] paramType2 = { SqlDbType.VarChar };
            dataGridView3.DataSource = connect.ShowDataInGridViewUsingStoredProc("op_teamWork2", paramNames2, paramValues2, paramType2);
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connect.OpenConection();
            try
            {

               

                if (comboBox1.SelectedItem.ToString() == "Doctor")
                {

                    dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc("op_teamWork3");

                  

            

                }
                else
                {

                    string pName = "op_teamWork4";
                    string[] paramNames = { "@career_name" };
                    string[] paramValues = { comboBox1.SelectedItem.ToString()};
                    SqlDbType[] paramType = { SqlDbType.VarChar };
                    dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
                   

               
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        


        }

        private void dataGridView2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           

                dataGridView2.DataSource = null;
                ds.Tables.Clear();
                dataGridView2.Rows.Clear();
                dataGridView2.Refresh();


                ////////////////////

                for (int i = dataGridView1.Rows.Count - 1; i >= 0; --i)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                     code = dataGridView1.Rows[i].Cells[0].Value.ToString();
                   
                }
            }

            if (comboBox1.SelectedItem.ToString() == "Doctor")
            {

                string pName = "op_teamWork5";
                string[] paramNames = { "@code","@a"};
                string[] paramValues = { code, اعدادات_متقدمه_للعمليه.y };
                SqlDbType[] paramType = { SqlDbType.VarChar, SqlDbType.VarChar };
                connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames,paramValues,paramType);
                MessageBox.Show("تم ادخال دكنور");


                string[] paramNames1 = { "@doc_ssn"};
                string[] paramValues1 = { code};
                SqlDbType[] paramType1 = { SqlDbType.VarChar };
                dataGridView2.DataSource = connect.ShowDataInGridViewUsingStoredProc("op_teamWork6", paramNames1, paramValues1, paramType1);
                
        
                
            }
            else if (comboBox1.SelectedItem.ToString() == "Nurse")
            {

                dataGridView3.DataSource = null;
                ds.Tables.Clear();
                dataGridView3.Rows.Clear();
                dataGridView3.Refresh();
                string pName = "op_teamWork7";
                string[] paramNames = { "@code", "@x" };
                string[] paramValues = { code, اعدادات_متقدمه_للعمليه.y };
                SqlDbType[] paramType = { SqlDbType.VarChar, SqlDbType.VarChar };
                connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames, paramValues, paramType);
                MessageBox.Show(code);
                MessageBox.Show("تم ادخال ممرض");


                string[] paramNames1 = { "@employee_emp_id" };
                string[] paramValues1 = { code };
                SqlDbType[] paramType1 = { SqlDbType.VarChar };
                dataGridView3.DataSource = connect.ShowDataInGridViewUsingStoredProc("op_teamWork8", paramNames1, paramValues1, paramType1);
                
                
            }
            

            //dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
        }
    }
}
