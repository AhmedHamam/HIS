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
    public partial class WM_Worker : Form
    {
        Connection conn = new Connection();
        public WM_Worker()
        {
            InitializeComponent();
        }

        private void exit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void add_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //try
            //{
            //    if (job.Text !="")
            //    {
            //con.Open();
            //SqlCommand cmd4 = new SqlCommand("insert into  wm_employees(emplyee_name,wm_name,job,notes,emp_id) values
            //('" + empName.Text + "','" + textBox1.Text + "','" + job.Text + "','" + notes.Text + "','" + textBox2.Text + "')", con);
            //cmd4.ExecuteNonQuery();
            //cmd4 = new SqlCommand("select wm_employee_id as ' كود عامل المغسلة',emplyee_name as 'اسم العامل ',wm_name as 'اسم المغسلة ',job as 'الوظيفة ',notes as ' ملاحظات',emp_id as 'كود الموظف' from wm_employees", con);
            //SqlDataReader da;
            //DataTable dt = new DataTable();
            //da = cmd4.ExecuteReader();
            //dt.Load(da);
            //dataGridView1.DataSource = dt;
            //da.Close();
            //    }
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
                string[] parmnames = { "@emplyee_name", "@wm_name", "@job", "@notes", "@emp_id"};
                string[] parmvalues = { empName.Text, textBox1.Text, job.Text, notes.Text, textBox2.Text};
                SqlDbType[] paradbtype = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int };

                conn.ShowDataInsertUsingStoredProc("wm_employees_Insert", parmnames, parmvalues, paradbtype);
                conn.CloseConnection();
                conn.OpenConection();
                dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("wm_employees_Select");
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

        private void Form1_Load(object sender, EventArgs e)
        {
          
            //con.Open();
            //SqlCommand cmd = new SqlCommand("select wm_employee_id as ' كود عامل المغسلة',emplyee_name as 'اسم العامل ',wm_name as 'اسم المغسلة ',job as 'الوظيفة ',notes as ' ملاحظات',emp_id as 'كود الموظف' from wm_employees", con);
            //SqlDataReader da;
            //DataTable dt = new DataTable();
            //da = cmd.ExecuteReader();
            //dt.Load(da);
            //dataGridView1.DataSource = dt;
            //con.Close();
            try
            {
                conn.OpenConection();
                dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("wm_employees_Select");
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
            //    if (emp_id.Text != "")
            //    {
            //        DialogResult result = MessageBox.Show("هل انت متأكد من الحذف؟", "حذف", MessageBoxButtons.YesNo);
            //        if (DialogResult.Yes == result)
            //        {
            //            con.Open();
            //            SqlCommand cmd4 = new SqlCommand("delete from wm_employees where wm_employee_id='" + emp_id.Text + "'", con);
            //            cmd4.ExecuteNonQuery();
            //            cmd4 = new SqlCommand("select wm_employee_id as ' كود عامل المغسلة',emplyee_name as 'اسم العامل ',wm_name as 'اسم المغسلة ',job as 'الوظيفة ',notes as ' ملاحظات',emp_id as 'كود الموظف' from wm_employees", con);
            //            SqlDataReader da;
            //            DataTable dt = new DataTable();
            //            da = cmd4.ExecuteReader();
            //            dt.Load(da);
            //            dataGridView1.DataSource = dt;
            //            da.Close();

            //        }
            //        else { con.Close(); }
            //    }
            //    else MessageBox.Show("الرجاء إدخال كود المراد حذفه  ");
                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            try
            {
                DialogResult result = MessageBox.Show("هل انت متأكد من الحذف؟", "حذف", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == result)
                {
                    conn.OpenConection();
                    string[] parmnames = { "@wm_employee_id" };
                    string[] parmvalues = { emp_id.Text };
                    SqlDbType[] paradbtype = { SqlDbType.Int };

                    conn.ShowDataInsertUsingStoredProc("wm_employees_Delete", parmnames, parmvalues, paradbtype);
                    conn.CloseConnection();
                    conn.OpenConection();
                    dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("wm_employees_Select");
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

        private void help_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //try
            //{
            //    if (emp_id.Text != "" )
            //    {
            //con.Open();
            //SqlCommand cmd4 = new SqlCommand("update wm_employees set emp_id='" + textBox2.Text + "',wm_name='" + textBox1.Text + "',emplyee_name='" + empName.Text + "',job='" + job.Text + "',notes='" + notes.Text + "'  where wm_employee_id='" + emp_id.Text + "'", con);
            //cmd4.ExecuteNonQuery();
            //cmd4 = new SqlCommand("select wm_employee_id as ' كود عامل المغسلة',emplyee_name as 'اسم العامل ',wm_name as 'اسم المغسلة ',job as 'الوظيفة ',notes as ' ملاحظات',emp_id as 'كود الموظف' from wm_employees", con);
            //SqlDataReader da;
            //DataTable dt = new DataTable();
            //da = cmd4.ExecuteReader();
            //dt.Load(da);
            //dataGridView1.DataSource = dt;
            //da.Close();
            //MessageBox.Show("تم التعديل");

            //    }
            //    else MessageBox.Show("الرجاء إدخال الكود والاسم المراد تعديله ");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally { con.Close(); }
            try
            {
                if (emp_id.Text != "")
                {
                    conn.OpenConection();
                    string[] parmnames = { "@emplyee_name", "@wm_name", "@job", "@notes", "@emp_id" };
                    string[] parmvalues = { empName.Text, textBox1.Text, job.Text, notes.Text,textBox2.Text };
                    SqlDbType[] paradbtype = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar,SqlDbType.Int };

                    conn.ShowDataInsertUsingStoredProc("wm_employees_Update", parmnames, parmvalues, paradbtype);
                    conn.CloseConnection();


                    conn.OpenConection();
                    dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("wm_employees_Select");
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

        private void emp_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); 
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.emp_id.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.empName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.job.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.notes.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.textBox1.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.textBox2.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = this.textBox2.Text;

            pop frm = new pop();
            frm.showdi(ref code, "select emp_id  as ' كود العامل ',name as 'اسم الموظف' from employee;", "الموظفين");

            this.textBox2.Text = code;
        }

        private void empName_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
        }

        private void job_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
        }

        private void notes_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string code = this.textBox1.Text;

            pop frm = new pop();
            frm.showdi(ref code, "select wm_code  as ' كود المغسلة ',wm_name as 'اسم المغسلة' from washing_machine;", "اجهزة المغسلة");

            this.textBox1.Text = code;
        }
    }
   
}
