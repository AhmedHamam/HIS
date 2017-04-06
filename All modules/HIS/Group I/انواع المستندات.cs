using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace HIS
{
    public partial class kind_fils : Form
    {

        Connection con = new Connection();
        public kind_fils()
        {
            InitializeComponent();
        }

  //********************************************************************************     

        private void display()
        {
            try
            {
                con.OpenConection();
                groupview.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("disblay");
                con.CloseConnection();
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
            
        }
        private void kind_fils_Load(object sender, EventArgs e)
        {
            display();

        }


//*******************************************************************************
        private void display2()
        {
            try
            {
                con.OpenConection();
                string[] s = new string[] { "@id" };
                string[] s2 = new string[] { textBox1.Text};
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                dataGridView2.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("viewcatagory", s, s2, s3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
            
        
//**************************************اضافة نوع مستند ******************************************
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                string[] s = new string[] {  "@pnamea", "@pnamee" };
                string[] s2 = new string[] {  textBox3.Text, textBox4.Text };
                SqlDbType[] s3 = new SqlDbType[] {  SqlDbType.NVarChar, SqlDbType.NVarChar };
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("insertfile", s, s2, s3);
                display();
                //textBox1.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        


//********************************************************************************
        private void group(string id)
        {
            try
            {
                con.OpenConection();
                string[] s = new string[] { "@id" };
                string[] s2 = new string[] { id };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                dataGridView2.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("viewcatagory", s, s2, s3);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        

  //*******************************************************************************     
        private void groupview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        
            group(groupview.CurrentRow.Cells[0].Value.ToString());
            
        }

        

       
//*************************************************************************************
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


//***********************************الحذف******************************
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                if (groupview.CurrentCell.RowIndex > 0)
                {
                    DialogResult dia = MessageBox.Show("هل انت متاكد من الحذف", "تنبيه", MessageBoxButtons.YesNo);
                    if (dia == DialogResult.Yes)
                    {
                        string se = groupview.CurrentRow.Cells[0].Value.ToString();
                        con.OpenConection();
                        string[] s = new string[] { "@id" };
                        string[] s2 = new string[] { se };
                        SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                        con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delfile", s, s2, s3);
                        display();
                        display2();
                        con.CloseConnection();
                    }
                    else
                    {
                        dia = DialogResult.Cancel;
                        textBox1.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("غير قابل للحذف");
                }
                con.CloseConnection();
            }

            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            } 
}


//***********************************اضافة فئة مستند************************************************

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                string[] s = new string[] { "@cnamea","@cnamee","@gid" };
                string[] s2 = new string[] { textBox5.Text, textBox6.Text,textBox1.Text };
                SqlDbType[] s3 = new SqlDbType[] {  SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("addcat", s, s2, s3);
                //display();
                //textBox1.Text = "";
                textBox2.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                display2();
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

                    }


//**********************************حذف فئة***********************************

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                if (dataGridView2.CurrentCell.RowIndex >= 0)
                {
                    DialogResult dia = MessageBox.Show("هل انت متاكد من الحذف", "تنبيه", MessageBoxButtons.YesNo);
                    if (dia == DialogResult.Yes)
                    {
                        string se = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                        con.OpenConection();
                        string[] s = new string[] { "@id" };
                        string[] s2 = new string[] { se };
                        SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                        con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delcatagory", s, s2, s3);
                        //display();
                        display2();
                        con.CloseConnection();
                    }
                    else
                    {
                        dia = DialogResult.Cancel;
                        textBox1.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("غير قابل للحذف");
                }
                con.CloseConnection();
            }

            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            } 
            //try
            //{
            //   int  id = int.Parse(dataGridView2.CurrentRow.Cells[3].Value.ToString());
            //   SqlConnection con = new SqlConnection(@"server=(localdb)\v11.0;Initial Catalog=PHIS;Integrated Security=True");
            //    con.Open();
            //    SqlCommand cmd = con.CreateCommand();
            //    cmd.Connection = con;
            //    if (id > 6)
            //    {
            //        DialogResult dia = MessageBox.Show("هل انت متاكد من الحذف", "تنبيه", MessageBoxButtons.YesNo);
            //        if (dia == DialogResult.Yes)
            //        {

            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.CommandText = "delcatagory";
            //            cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
            //            cmd.ExecuteNonQuery();
            //            textBox1.Text = "";
            //            textBox3.Text = "";
            //            MessageBox.Show("تم الحذف  ");
            //            display2();



            //        }
            //        else
            //        {
            //            dia = DialogResult.Cancel;
            //            textBox1.Text = "";
            //            textBox3.Text = "";
            //        }
            //    }
               
            //    else
            //    {
            //        MessageBox.Show("غير قابل للحذف");
            //    }
            //    con.Close();
            //}




            //catch (Exception g)
            //{
            //    MessageBox.Show(g.Message);
            //}

        }
           }

        

    }


