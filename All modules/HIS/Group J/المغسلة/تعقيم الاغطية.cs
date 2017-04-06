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
    public partial class coverPreperations : Form
    {
        Connection conn = new Connection();
        public coverPreperations()
        {

            InitializeComponent();
        }

              
        private void Form1_Load(object sender, EventArgs e)
        {
            
            //con.Open();
            //SqlCommand cmd = new SqlCommand("select order_id as 'رقم الطلب' , services_name as 'الخدمة' , quantitiy as 'الكمية' , demander_place as 'المكان الطالب' , started_date as 'من تاريخ' , end_date as 'الى تاريخ' , wm_employee_id as 'عامل المغسلة' from WM_coversPrep", con);
            //SqlDataReader da;
            //DataTable dt = new DataTable();
            //da = cmd.ExecuteReader();
            //dt.Load(da);
            //dataGridView1.DataSource = dt;
            //cmd = new SqlCommand("select *  from wm_employees", con);
            //SqlDataReader dr = cmd.ExecuteReader();
            ////while (dr.Read())
            ////{
            ////    comboBox1.Items.Add(dr[0].ToString());

            ////}
            ////comboBox1.DisplayMember = "wm_employee_id";
            ////comboBox1.ValueMember = "wm_employee_id";
            ////dr.Close();
            //con.Close();
            try
            {
                conn.OpenConection();
                dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("WM_coversPrep_Select");
                conn.CloseConnection();
                clear.Clear(this);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }

        }

      
        private void add_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //try
            //{
            //    if (order_id.Text != "" && place.Text != "")
            //    {
            //con.Open();
            //SqlCommand cmd4 = new SqlCommand("insert into  WM_coversPrep (order_id,services_name,quantitiy,demander_place,started_date,end_date,wm_employee_id) values('" + order_id.Text + "','" + serv.Text + "','" + quantity.Text + "','" + place.Text + "','" + fromdate.Value.Date.ToString("MM/dd/yyyy") + "','" + todate.Value.Date.ToString("MM/dd/yyyy") + "','" + empId.Text + "')", con);
            //cmd4.ExecuteNonQuery();
            //MessageBox.Show("تم الاضافة ");
            //cmd4 = new SqlCommand("select order_id as 'رقم الطلب' , services_name as 'الخدمة' , quantitiy as 'الكمية' , demander_place as 'المكان الطالب' , started_date as 'من تاريخ' , end_date as 'الى تاريخ' , wm_employee_id as 'عامل المغسلة' from WM_coversPrep", con);
            //SqlDataReader da;
            //DataTable dt = new DataTable();
            //da = cmd4.ExecuteReader();
            //dt.Load(da);
            //dataGridView1.DataSource = dt;
            //da.Close();
            //}
            //    else MessageBox.Show("الرجاء إدخال البيانات ");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally { con.Close(); }
            try
            {
 
                conn.OpenConection();
                string[] parmnames = { "@services_name", "@quantitiy", "@demander_place", "@started_date","@end_date","@wm_employee_id" };
                string[] parmvalues = {  serv.Text, quantity.Text, place.Text, fromdate.Text, todate.Text,empId.Text};
                SqlDbType[] paradbtype = { SqlDbType.VarChar, SqlDbType.Int, SqlDbType.VarChar,SqlDbType.DateTime,SqlDbType.DateTime,SqlDbType.Int };

                conn.ShowDataInsertUsingStoredProc("WM_coversPrep_Insert", parmnames, parmvalues, paradbtype);
                conn.CloseConnection();
                conn.OpenConection();
                dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("WM_coversPrep_Select");
                conn.CloseConnection();
                clear.Clear(this);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        private void exit_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void linkLabel3_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("هل انت متأكد من الحذف؟", "حذف", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == result)
                {
                    conn.OpenConection();
                    string[] parmnames = { "@or_id" };
                    string[] parmvalues = { order_id.Text };
                    SqlDbType[] paradbtype = { SqlDbType.Int };

                    conn.ShowDataInsertUsingStoredProc("WM_coversPrep_Delete", parmnames, parmvalues, paradbtype);
                    conn.CloseConnection();
                    conn.OpenConection();
                    dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("WM_coversPrep_Select");
                    conn.CloseConnection();
                    clear.Clear(this);
                    MessageBox.Show("تم الحذف");
                }
                else
                {
                    conn.CloseConnection();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        private void linkLabel6_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            try
            {
                if (order_id.Text != "")
                {
                    conn.OpenConection();
                    string[] parmnames = { "@order_id", "@services_name", "@quantitiy", "@demander_place", "@started_date", "@end_date", "@wm_employee_id" };
                    string[] parmvalues = {order_id.Text, serv.Text, quantity.Text, place.Text, fromdate.Text, todate.Text, empId.Text };
                    SqlDbType[] paradbtype = {SqlDbType.Int, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.DateTime, SqlDbType.DateTime, SqlDbType.Int };

                    conn.ShowDataInsertUsingStoredProc("WM_coversPrep_Update", parmnames, parmvalues, paradbtype);
                    conn.CloseConnection();

                    clear.Clear(this);
                    conn.OpenConection();
                    dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("WM_coversPrep_Select");
                    conn.CloseConnection();

                    clear.Clear(this);
                    MessageBox.Show("تم التعديل");
                }
                else MessageBox.Show("الرجاء إدخال كود الجهاز المراد تعديله ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.CloseConnection(); }
        }

        private void order_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.integer(sender, e, this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string code = this.empId.Text;
            

            pop frm = new pop();
            frm.showdi(ref code, "select wm_employee_id as ' كود عامل المغسلة',emplyee_name as 'اسم العامل ' from wm_employees;", "موظفي المغسلة");
            
            this.empId.Text = code;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.order_id.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.empId.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            this.quantity.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.place.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.serv.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void place_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);

        }

        private void serv_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
            
        }
    }
   
    }

