using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace  HIS

{
    public partial class العياده : Form
    {
        SqlDataReader dr;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        

        Label l1;
        Label l2;
        Label l3;
        RowStyle temp;

        public static string Code { get; set; }
        public static string Arab { get; set; }
        public العياده()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            خدمات_العيادات f1 = new خدمات_العيادات();
            f1.Focus();
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (textBox1.Text == "" && textBox2.Text == "")
            {
                /*
                * 
                        create procedure clinic_العياده_clinic_select
                        as 
                        begin
                        select Clinic_code as 'الكود', Arabic_name as 'الاسم العربى' , english_name as 'الاسم الانجليزى' from clinic
                        end
                 * */
               // con.Open();
               // cmd.Connection = con;
               //// class_con.OpenConection();
               // cmd.CommandText = "clinic_العياده_clinic_select";
               // cmd.CommandType = CommandType.StoredProcedure;
               // //cmd.CommandText = "select Clinic_code as 'الكود', Arabic_name as 'الاسم العربى' , english_name as 'الاسم الانجليزى' from clinic";
               // dr = cmd.ExecuteReader();
                con1.OpenConection();
                dr = con1.DataReader("clinic_العياده_clinic_select");
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
               
            }

            if (textBox1.Text != "" && textBox2.Text == "")
            {
                /* create procedure clinic_العياده_clinic_code_select(@c nvarchar(50))
                    as 
                    begin
                    select clinic_code as 'الكود', Arabic_name as 'الاسم العربى' , english_name as 'الاسم الانجليزى' from clinic where clinic_code=@c
                    end

                 */
                //con.Open();
                //cmd.Connection = con;
                ////class_con.OpenConection();
                //cmd.CommandText = "clinic_العياده_clinic_code_select";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@c", textBox1.Text);
                ////cmd.CommandText = "select clinic_code as 'الكود', Arabic_name as 'الاسم العربى' , english_name as 'الاسم الانجليزى' from clinic where clinic_code='" + textBox1.Text + "'";
                //dr = cmd.ExecuteReader();
                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar };
                name_input = new string[] { "@c" };
                values = new string[] { textBox1.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_العياده_clinic_code_select",name_input,values,types);
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
               
            }

            if (textBox1.Text == "" && textBox2.Text != "")
            {
                /*
                                     *      
                    create procedure clinic_العياده_clinic_name_select(@arabic nvarchar(50))
						as 
						begin
						
						select clinic_code as 'الكود', Arabic_name as 'الاسم العربى' , english_name as 'الاسم الانجليزى' from clinic where Arabic_name  like  N'%'+@arabic+'%'
						end
                  */
               // con.Open();
               // cmd.Connection = con;
               // //class_con.OpenConection();
               // cmd.CommandText = "clinic_العياده_clinic_name_select";
               // cmd.CommandType = CommandType.StoredProcedure;
               // cmd.Parameters.Add("@arabic", SqlDbType.NVarChar).Value = textBox2.Text;
               //// cmd.CommandText = "select clinic_code as 'الكود', Arabic_name as 'الاسم العربى' , english_name as 'الاسم الانجليزى' from clinic where Arabic_name='" + textBox2.Text + "'";
               // dr = cmd.ExecuteReader();

                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar };
                name_input = new string[] { "@arabic" };
                values = new string[] { textBox2.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_العياده_clinic_name_select", name_input, values, types);
                DataTable dt = new DataTable();
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
               con1.CloseConnection();
               
            }

            if (textBox2.Text != "" && textBox1.Text != "")
            {
                /*create procedure clinic_العياده_clinic_All_select(@c nvarchar(50),@arabic nvarchar(50))
                        as
                        begin
                        select 
                        clinic_code as 'الكود', Arabic_name as 'الاسم العربى' , english_name as 'الاسم الانجليزى' from clinic where 
                        clinic_code=@c and Arabic_name like N'%'+@arabic+'%'
                        end
                 * 
                 */ 
                //con.Open();
                //cmd.Connection = con;
                ////class_con.OpenConection();
                //cmd.CommandText = "select clinic_code as 'الكود', Arabic_name as 'الاسم العربى' , english_name as 'الاسم الانجليزى' from clinic where clinic_code='" + textBox1.Text + "' and Arabic_name='" + textBox2.Text + "'";
                //dr = cmd.ExecuteReader();
                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar,SqlDbType.NVarChar };
                name_input = new string[] { "@c","@arabic" };
                values = new string[] { textBox1.Text,textBox2.Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_العياده_clinic_All_select", name_input, values, types);
                DataTable dt = new DataTable();
                
                dt.Load(dr);
                if (dt.Rows.Count > 0)
                {
                    dataGridView2.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("لا توجد نتائج بحث");
                }
                dr.Close();
                con1.CloseConnection();
                
            }
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Code = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            Arab = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        //validation
        private void check_number_code(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الارقام فقط ");

            }

        }

        private void check_string_name(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط ");

            }
        }

    }
    /* private void l1_Click(object sender, EventArgs e)
     {
         Code = (sender as Label).Text;
     }
     private void l2_Click(object sender, EventArgs e)
     {
         Arab = (sender as Label).Text;
     }
     private void label12_Click_1(object sender, EventArgs e)
     {
         Code = (sender as Label).Text;
     }

     private void label13_Click_1(object sender, EventArgs e)
     {
         Arab = (sender as Label).Text;
     }*/

}

//}
