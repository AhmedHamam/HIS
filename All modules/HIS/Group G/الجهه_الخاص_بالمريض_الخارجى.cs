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
    public partial class الجهه_الخاص_بالمريض_الخارجى : Form
    {
        
        SqlDataReader dr;
        SqlDataReader drr2;
        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        public static string x2 { get; set; }

        public static string x1 { get; set; }
        public static string v1 { get; set; }
        public static string x3 { get; set; }
      
        public static string x4 { get; set; }
        public static string x5 { get; set; }
   
        public static string x6 { get; set; }

        public static string dt;
        public الجهه_الخاص_بالمريض_الخارجى()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
            if (textBox8.Text != "")
            {
                /*
                 * create procedure clinic_select_ins_code(@x int)
                        as
                        select ins_code as 'كود الجهة', ins_name as 'اسم الجهة' from institution where ins_code=@x;
                                         */
                //cmd = new SqlCommand("clinic_select_ins_code", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@x", textBox8.Text); 
                //dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);

                //dataGridView1.DataSource = dt;

                // create procedure clinic_select_ins_code(@x int)
                //    as
                //select CE_Id  as 'كود الجهة', CE_AName as 'اسم الجهة' from tb_Contracting_Entities where CE_Id =@x;

                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.Int };
                name_input = new string[] { "@x" };
                values = new string[] { textBox8.Text };
                object ob = con1.ShowDataInGridViewUsingStoredProc("clinic_select_ins_code", name_input, values, types);
                dataGridView1.DataSource = ob;
                con1.CloseConnection();
            }
            else if (textBox7.Text != "")
            {
                //cmd = new SqlCommand("clinic_select_ins_code_ins_nam", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@x", textBox7.Text);
                //dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;


            //create procedure clinic_select_ins_code_ins(@x nvarchar(30))
            //as

            //select CE_Id  as 'كود الجهة', CE_AName as 'اسم الجهة' from tb_Contracting_Entities where CE_Id like N''+@x+'%';

                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar };
                name_input = new string[] { "@x" };
                values = new string[] { textBox7.Text };
                object ob = con1.ShowDataInGridViewUsingStoredProc("clinic_select_ins_code_ins", name_input, values, types);
                dataGridView1.DataSource = ob;
                con1.CloseConnection();
            }
            else 
            {
                /*
                 * create procedure clinic_select_institution
                    as
                    select ins_code as 'كود الجهة', ins_name as 'اسم الجهة' from institution ;
                 */
                //cmd = new SqlCommand("clinic_select_institution", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;


                   // create procedure clinic_select_institution
                   //as
                   //select CE_Id  as 'كود الجهة', CE_AName as 'اسم الجهة' from tb_Contracting_Entities

                con1.OpenConection();
                
                dr = con1.DataReader("clinic_select_institution");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con1.CloseConnection();

            }
           
            
            
            
       
        }

       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            v1 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            x2 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            /*
             * create procedure clinic_select_family(@x int)
                as
                select f_code as 'كود الفئة', f_name as 'اسم الفئة' from family_branche,sub_branche where  f_code=bcode and subcode=@x ;
                             * 
             */

            //cmd = new SqlCommand("clinic_select_family", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@x", v1);
                
            //    dr = cmd.ExecuteReader();
               
            //    DataTable dt = new DataTable();
            //    dt.Load(dr);
            //    dataGridView3.DataSource = dt;
            //    dr.Close();

            //create procedure clinic_select_sus(@x nvarchar(20))
            //  as
            //    select *  from tb_Entities_Branches where EB_Aname=@x;


            con1.OpenConection();
            types = new SqlDbType[] { SqlDbType.Int };
            name_input = new string[] { "@x" };
            values = new string[] { v1 };
            object ob = con1.ShowDataInGridViewUsingStoredProc("clinic_select_family", name_input, values, types);
            dataGridView3.DataSource = ob;
            con1.CloseConnection();

                //cmd = new SqlCommand("clinic_select_substitution", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@x", v1);

                //dr = cmd.ExecuteReader();

                //DataTable dt2 = new DataTable();
                //dt2.Load(dr);
                //dataGridView2.DataSource = dt2;
            /*
             * create procedure clinic_select_substitution(@x int)
                as
                select sub_code as 'كود الجهة الفرعية', sub_name as 'اسم الجهة الفرعية' from sub_institution where incode=@x;
             * 
             */
            con1.OpenConection();
            types = new SqlDbType[] { SqlDbType.Int };
            name_input = new string[] { "@x" };
            values = new string[] { v1 };
             ob = con1.ShowDataInGridViewUsingStoredProc("clinic_select_substitution", name_input, values, types);
            dataGridView2.DataSource = ob;
            con1.CloseConnection();

               
            
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            x5 = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();

            x6 = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
            
             if (x3 == null)
                {

                    x4 = x2;
                 /*
                  * create procedure clinic_select_sus(@x nvarchar(20))
                        as
                        select *  from sub_institution where sub_name=@x;
                                          
                  */
                    
                        //cmd = new SqlCommand("clinic_select_sus", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@x", x4);
                        // dr = cmd.ExecuteReader();

                 //create procedure clinic_select_sus(@x nvarchar(20))
                 // as
                 //   select *  from tb_Entities_Branches where EB_Aname=@x;

                 con1.OpenConection();
            types = new SqlDbType[] { SqlDbType.NVarChar};
            name_input = new string[] { "@x" };
            values = new string[] { x4 };
            dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_select_sus", name_input, values, types);

                         while (dr.Read())
                         { x3 = dr["sub_code"].ToString(); }
                        
                    

                }
            /*create procedure clinic_select_current_date
                as
                select GETDATE() ; 
                exec clinic_select_current_date;
             * 
             */
                //cmd.Connection = con;
                //con.Open();
                //cmd = new SqlCommand("clinic_select_current_date", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //drr2 = cmd.ExecuteReader();
                //drr2.Read();
                //dt = drr2[0].ToString();
                //drr2.Close();
            con1.OpenConection();
           
            drr2 = con1.DataReader("clinic_select_current_date");
            drr2.Read();
                dt = drr2[0].ToString();
                drr2.Close();
                تعديل_الفئه_الماليه_للمريض_الخارجى ff6 = new تعديل_الفئه_الماليه_للمريض_الخارجى();
                ff6.Focus();
                this.DialogResult = DialogResult.OK;
                ff6.Focus();
       


            }

       

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            x3 = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            x4 = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            // x3 = SubCode; x4 = Sub;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            textBox8.Text = "";
            
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            
            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال حروف");
            }
        }

       

    }
}
