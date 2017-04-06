using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HIS
{
    public partial class بحث_العياده : Form
    {
        //SqlCommand cmd;
        //SqlConnection con;
        //SqlDataReader dr;

        Connection con1 = new Connection();
        int count = 0;
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        


        public static int c { set; get; }
        public static string name { set; get; }
        public بحث_العياده()
        {
            InitializeComponent();
            //con = new SqlConnection(@"server=SANDRA-PC\SQLEXPRESS;database=project_db; Integrated Security=true;");
            //con.Open();
        }
        //For search Clinic
        private void button1_Click(object sender, EventArgs e)
        {
            

            /*
             * create procedure clinic_search_all_select
                as
                begin
                select Clinic_code  as 'الكود', arabic_name as 'الاسم العربى' , english_name as 'الاسم الانجليزى' from Clinic;
                end
             */


            if (textBox1.Text == "" && textBox2.Text == "")
                    {

                        //try
                        //{
                        //    cmd = new SqlCommand("clinic_search_all_select", con);
                        //    cmd.CommandType = CommandType.StoredProcedure;
                        //    dr = cmd.ExecuteReader();
                        //    DataTable dt = new DataTable();
                        //    dt.Load(dr);
                        //    dataGridView1.DataSource = dt;
                        //    //dataGridView1.ColumnHeadersVisible = false;

                        //    dataGridView1.AllowUserToAddRows = false;
                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show(ex.Message);
                        //}
                        //finally
                        //{
                        //    con.Close();
                        //}
                        con1.OpenConection();
                        object dt = con1.ShowDataInGridViewUsingStoredProc("clinic_search_all_select");
                        if (dt != null)
                        {
                            dataGridView1.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("لا توجد نتائج بحث");
                        }
                        con1.CloseConnection();

                    }
                    else if (textBox1.Text == "" && textBox2.Text != "")
                    {
                        


                            // CREATE PROCEDURE clinic_بحث_العياده_clinic_name_select(@name nvarchar(50)) 
                            //as
                            //begin
                            //select Clinic_code  as 'الكود', arabic_name as 'الاسم العربى' , english_name as 'الاسم الانجليزى' from Clinic where Arabic_name like N'%'+@name+'%';
                            //end
                        
                        //c = 0;
                        
                        //try
                        //{
                        //    cmd = new SqlCommand("clinic_search_clinic_name_select1", con);
                        //    cmd.CommandType = CommandType.StoredProcedure;
                        //    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox2.Text;
                        //    //cmd.Parameters.AddWithValue("@name", textBox2.Text);
                        //    dr = cmd.ExecuteReader();
                        //    DataTable dt = new DataTable();
                        //    dt.Load(dr);
                        //    dataGridView1.DataSource = dt;
                        //    dataGridView1.ColumnHeadersVisible = false;

                        //    dataGridView1.AllowUserToAddRows = false;
                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageBox.Show(ex.Message);
                        //}
                        //finally
                        //{
                        //    con.Close();
                        //}
                        con1.OpenConection();
                        types = new SqlDbType[] { SqlDbType.NVarChar };
                        name_input = new string[] { "" };
                        values = new string[] { "" };
                        types[count] = SqlDbType.NVarChar;
                        name_input[count] = "@name";
                        values[count] = textBox2.Text;
                        object ob = con1.ShowDataInGridViewUsingStoredProc("clinic_بحث_العياده_clinic_name_select", name_input, values, types);
                        if (ob != null)
                        {
                            dataGridView1.DataSource = ob;
                        }
                        else
                        {
                            MessageBox.Show("لا توجد نتائج بحث");
                        }
                        con1.CloseConnection();
                        count = 0;

                    }

                    else if (textBox1.Text != null && textBox2.Text == "")
                    {
                        /*
                         * create procedure clinic_search_clinic_code (@num nvarchar(50))
                            As 
                            Begin
                            select  Clinic_code  ,arabic_name  from clinic where Clinic_code  = @num ;
                            end
                         * 
                         * 
                         */
                        c = int.Parse(textBox1.Text);
                        
                       /* try
                        {
                          cmd = new SqlCommand("clinic_search_clinic_code", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@num", textBox1.Text);
                            dr = cmd.ExecuteReader();
                            DataTable dt = new DataTable();
                            dt.Load(dr);
                            dataGridView1.DataSource = dt;
                            dataGridView1.ColumnHeadersVisible = false;

                            dataGridView1.AllowUserToAddRows = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            con.Close();
                        }*/
                        con1.OpenConection();
                        types = new SqlDbType[] { SqlDbType.NVarChar };
                        name_input = new string[] { "" };
                        values = new string[] { "" };
                        types[count] = SqlDbType.NVarChar;
                        name_input[count] = "@num";
                        values[count] = textBox1.Text;
                        object ob = con1.ShowDataInGridViewUsingStoredProc("clinic_search_clinic_code", name_input, values, types);
                        if (ob != null)
                        {
                            dataGridView1.DataSource = ob;
                        }
                        else
                        {
                            MessageBox.Show("لا توجد نتائج بحث");
                        }
                        con1.CloseConnection();
                        count = 0;

                    }
            
            
        }
        //For Quit from this form
        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            //جدولة_العيادات f = new جدولة_العيادات(0, "");
            //f.Show();
        }
        //For Print In textbox1 and in textbox2
        private void dataGridView1_(object sender, DataGridViewCellEventArgs e)
        {
            c = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["الكود"].Value.ToString());

            name = dataGridView1.Rows[e.RowIndex].Cells["الاسم العربى"].Value.ToString();
            جدولة_العيادات f = new جدولة_العيادات(c, name);
            f.Focus();
            this.DialogResult = DialogResult.OK;
            f.ShowListBox();
            f.Refresh();
            f.Focus();
               
            
        }
        //For input number only
        private void check_number(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الارقام فقط في خانه رقم العياده");

            }
            
        }
        //For check string input
        private void check_string(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط في خانه اسم العياده");

            }
        }

       

        

       
    }
}
