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
    public partial class اعدادات_متقدمه_للعمليه : Form
    {
        Connection connect;
        public static string y;
        public تعديل_العمليه fff;
        public فريق_العمل fw;
        public SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection con;

        DataSet ds = new DataSet();
       
        public اعدادات_متقدمه_للعمليه()
        {
            InitializeComponent();
            connect = new Connection();

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            connect.OpenConection();
            string s = dateTimePicker1.Value.ToShortDateString();
            string pName = "operation_prep1";
            string[] paramNames = { "@op_date" };
            string[] paramValues = {s};
            SqlDbType[] paramType = { SqlDbType.VarChar };
            dataGridView1.DataSource=connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);

          
           
        
    }

        private void button2_Click(object sender, EventArgs e)
        {/*
            try
            {
                connect.OpenConection();

                for (int i = dataGridView1.Rows.Count - 1; i >= 0; --i)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        string code = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        string pName = "operation_prep2";
                        string[] paramNames = { "@op_code" };
                        string[] paramValues = {code};
                        SqlDbType[] paramType = { SqlDbType.VarChar };
                        connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames, paramValues, paramType);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
           */
        }

        private void button1_Click(object sender, EventArgs e)  //aaa
        {
            try
            {
               connect.OpenConection();

                for (int i = dataGridView1.Rows.Count - 1; i >= 0; --i)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                      
                        string code = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        string pName = "operation_prep3";
                        string[] paramNames = { "@op_code" };
                        string[] paramValues = {code};
                        SqlDbType[] paramType = { SqlDbType.VarChar };
                        connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames, paramValues, paramType);

                     
                        MessageBox.Show("تم انهاء العمليه");
                     
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = dataGridView1.Rows.Count - 1; i >= 0; --i)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        connect.OpenConection();

                        string code = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        string status = "died";
                        string pName = "operation_prep4";
                        string[] paramNames = { "@code","@patient_status"};
                        string[] paramValues = { code, status };
                        SqlDbType[] paramType = { SqlDbType.VarChar,SqlDbType.VarChar };
                        connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames, paramValues, paramType);



                        //
                       // cmd = new SqlCommand("update entranceoffice_internalpatient set patient_states='" + "died'"+" where v_id= '" + code + "' and ", con);
                        MessageBox.Show("تم تسجيل حاله الوفاه");
                   
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
         
    
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
              

                for (int i = dataGridView1.Rows.Count - 1; i >= 0; --i)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        string code = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        y = code;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
           
            fff = new تعديل_العمليه();
        fff.Show();
        
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
              

                for (int i = dataGridView1.Rows.Count - 1; i >= 0; --i)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        string code = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        y = code;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
           
            fw = new فريق_العمل();
            fw.Show();

        }

        private void اعدادات_متقدمه_للعمليه_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
