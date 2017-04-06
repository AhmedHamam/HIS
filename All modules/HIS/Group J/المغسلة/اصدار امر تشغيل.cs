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
    public partial class wm_operating_order : Form
    {
        Connection conn = new Connection();
        public wm_operating_order()
        {
            InitializeComponent();
        }
        private void exit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void add_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                conn.OpenConection();
                string[] parmnames = { "@op_s", "@begin_date", "@end_date", "@wm_num_of_hours", "@operating_order_type","@demander_place","@num_of_detergentss","@order_id","@emp_id" };
                string[] parmvalues = { service.Text, fromdate.Text, todate.Text, numHoures.Text, opOrderType.Text,demanderPlace.Text,detergentsesQuantity.Text,empId.Text };
                SqlDbType[] paradbtype = { SqlDbType.VarChar, SqlDbType.DateTime, SqlDbType.DateTime, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.Int };

                conn.ShowDataInsertUsingStoredProc("wm_operating_order_Insert", parmnames, parmvalues, paradbtype);
                conn.CloseConnection();
                conn.OpenConection();
                dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("wm_operating_order_Select");
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

        private void delete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //try
            //{
            //    if (order_num.Text != "")
            //    {
            //        con.Open();
            //        SqlCommand cmd4 = new SqlCommand("delete from wm_operating_order where opo_id='" + order_num.Text + "'", con);
            //        cmd4.ExecuteNonQuery();
            //        MessageBox.Show("تم الحذف");
            //        Utilities.ResetAllControls(this);
            //        cmd4 = new SqlCommand("select opo_id as 'رقم الطلب',operating_order_service as 'الخدمة',begin_date as 'من تاريخ',end_date as 'الى تاريخ',wm_num_of_hours as 'عدد ساعات التشغيل',operating_order_type as 'نوع الخدمة',demander_place as 'المكان الطالب',num_of_detergentss as 'كمية المسحوق',order_id as 'كود الطلب',emp_id as 'كود الموظف' from wm_operating_order", con);
            //        SqlDataReader da;
            //        DataTable dt = new DataTable();
            //        da = cmd4.ExecuteReader();
            //        dt.Load(da);
            //        dataGridView1.DataSource = dt;
            //        da.Close();
            //    }
            //    else MessageBox.Show("الرجاء إدخال كود امر الشغل المراد حذفه ");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally { con.Close(); }
            try
            {
                DialogResult result = MessageBox.Show("هل انت متأكد من الحذف؟", "حذف", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == result)
                {
                    conn.OpenConection();
                    string[] parmnames = { "@opo_id" };
                    string[] parmvalues = { order_num.Text };
                    SqlDbType[] paradbtype = { SqlDbType.Int };

                    conn.ShowDataInsertUsingStoredProc("wm_operating_order_Delete", parmnames, parmvalues, paradbtype);
                    conn.CloseConnection();
                    conn.OpenConection();
                    dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("wm_operating_order_Select");
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

        private void wm_operating_order_Load(object sender, EventArgs e)
        {

            //con.Open();
            //SqlCommand cmd = new SqlCommand("select opo_id as 'رقم الطلب',operating_order_service as 'الخدمة',begin_date as 'من تاريخ',end_date as 'الى تاريخ',wm_num_of_hours as 'عدد ساعات التشغيل',operating_order_type as 'نوع الخدمة',demander_place as 'المكان الطالب',num_of_detergents as 'كمية المسحوق',order_id as 'كود الطلب',emp_id as 'كود الموظف' from wm_operating_order", con);
            //SqlDataReader da;
            //DataTable dt = new DataTable();
            //da = cmd.ExecuteReader();
            //dt.Load(da);
            //dataGridView1.DataSource = dt;

            //cmd = new SqlCommand("select *  from WM_coversPrep", con);
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    comboBox1.Items.Add(dr[0].ToString());

            //}
            //comboBox1.DisplayMember = "order_id";
            //comboBox1.ValueMember = "order_id";
            //dr.Close();

            //cmd = new SqlCommand("select *  from employee", con);
            //dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    comboBox2.Items.Add(dr[0].ToString());

            //}
            //comboBox2.DisplayMember = "emp_id";
            //comboBox2.ValueMember = "emp_id";
           // dr.Close();
           // con.Close();
            try
            {
                conn.OpenConection();
                dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("wm_operating_order_Select");
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

        private void help_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //try
            //{
            //    if (order_num.Text != "")
            //    {
            //        con.Open();                                                                                                                                                                                                             //,,,,,
            //        SqlCommand cmd4 = new SqlCommand("update wm_operating_order set  operating_order_service='" + service.Text + "', begin_date='" + fromdate.Value.Date.ToString("MM/dd/yyyy") + "', end_date='" + todate.Value.Date.ToString("MM/dd/yyyy") + "',wm_num_of_hours='" + numHoures.Text + "',operating_order_type='" + opOrderType.Text + "',demander_place='" + demanderPlace.Text + "',num_of_detergentss='" + detergentsesQuantity.Text + "',emp_id='" + empId.Text + "' where  opo_id='" + order_num.Text + "' ", con);
            //        cmd4.ExecuteNonQuery();
            //        cmd4 = new SqlCommand("select opo_id as 'رقم الطلب',operating_order_service as 'الخدمة',begin_date as 'من تاريخ',end_date as 'الى تاريخ',wm_num_of_hours as 'عدد ساعات التشغيل',operating_order_type as 'نوع الخدمة',demander_place as 'المكان الطالب',num_of_detergents as 'كمية المسحوق',order_id as 'كود الطلب',emp_id as 'كود الموظف' from wm_operating_order", con);
            //        SqlDataReader da;
            //        DataTable dt = new DataTable();
            //        da = cmd4.ExecuteReader();
            //        dt.Load(da);
            //        dataGridView1.DataSource = dt;
            //        da.Close();
            //        MessageBox.Show("تم التعديل");
            //        Utilities.ResetAllControls(this);
            //    }
            //    else MessageBox.Show("الرجاء إدخال كود امر الشغل المراد تعديله ");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally { con.Close(); }
            try
            {
                if (order_num.Text != "")
                {
                    conn.OpenConection();
                    string[] parmnames = { "@opo_id", "@op_s", "@begin_date", "@end_date", "@wm_num_of_hours", "@operating_order_type", "@demander_place", "@num_of_detergentss", "@emp_id" };
                    string[] parmvalues = {order_num.Text, service.Text, fromdate.Value.Date.ToString("MM/dd/yyyy"), todate.Value.Date.ToString("MM/dd/yyyy"), numHoures.Text, opOrderType.Text, demanderPlace.Text, detergentsesQuantity.Text, empId.Text };
                    SqlDbType[] paradbtype = {SqlDbType.Int, SqlDbType.VarChar, SqlDbType.DateTime, SqlDbType.DateTime, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.Int };

                    conn.ShowDataInsertUsingStoredProc("wm_operating_order_Update", parmnames, parmvalues, paradbtype);
                    conn.CloseConnection();


                    conn.OpenConection();
                    dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("wm_operating_order_Select");
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

        private void order_num_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.integer(sender, e, this);
        }

        private void numHoures_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.Float(sender, e, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string code = this.empId.Text;
            
            pop frm = new pop();
            frm.showdi(ref code, "select emp_id  as ' كود العامل ',name as 'اسم الموظف' from employee;", "الموظفين");
            
            this.empId.Text = code;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.order_num.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.detergentsesQuantity.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
            this.opOrderType.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            this.service.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.numHoures.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.demanderPlace.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
            //this.fromdate.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //this.todate.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.empId.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void opOrderType_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void service_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void demanderPlace_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void service_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);

        }

        private void detergentsesQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.Float(sender, e, this);
	
        }

        private void opOrderType_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
        }

        private void demanderPlace_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
        }

        private void numHoures_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            validate.Float(sender, e, this);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string code = this.service.Text;
            string name = this.opOrderType.Text;

            pop frm = new pop();
            frm.showdidi(ref code,ref name, "select order_id  as ' كود الخدمة ',services_name as 'اسم الخدمة' from WM_coversPrep;", "الخدمات");
            this.opOrderType.Text = name;
            this.service.Text = code;
        }

    }
    public class Utilities
    {
        public static void ResetAllControls(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }

                if (control is ListBox)
                {
                    ListBox listBox = (ListBox)control;
                    listBox.ClearSelected();
                }

            }
        }
    }
}
