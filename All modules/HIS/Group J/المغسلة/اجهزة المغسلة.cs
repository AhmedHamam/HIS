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
    public partial class WM_device : Form
    {
       // SqlConnection con = new SqlConnection(@"Server=(local);Database=HIS; Integrated Security=true");


        Connection conn = new Connection();
        
        public WM_device()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //try{
            //con.Open();
            //SqlCommand cmd4 = new SqlCommand("select wm_code as 'كود الجهاز', wm_name as 'اسم الجهاز', max_temp as ' حرارة الجهاز', wm_type as 'نوع الجهاز', description as 'وصف الجهاز', colors as 'لون الجهاز', condition as 'حالة الجهاز' from washing_machine", con);
            //SqlDataReader da;
            //DataTable dt = new DataTable();
            //da = cmd4.ExecuteReader();
            //dt.Load(da);
            //dataGridView1.DataSource = dt;
            //da.Close();
            // }catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally {con.Close(); }

            try
            {
                conn.OpenConection();
                dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("washing_machine_select");
                conn.CloseConnection();
                clear.Clear(this);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally { 
                conn.CloseConnection(); 
            }
        }

        private void exit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void add_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            //try
            //{
            //    if (devName.Text != "")
            //    {
            //        con.Open();
            //        SqlCommand cmd = new SqlCommand("INSERT INTO washing_machine (wm_name, max_temp, wm_type, description, colors, condition) VALUES ('" + devName.Text + "','" + temp.Text + "','" + kind.Text + "','" + descriptions.Text + "','" + colores.Text + "','" + conditions.Text + "')", con);
            //        cmd.ExecuteNonQuery();
            //        MessageBox.Show("تم الاضافة");
            //        cmd = new SqlCommand("select wm_code as 'كود الجهاز', wm_name as 'اسم الجهاز', max_temp as ' حرارة الجهاز', wm_type as 'نوع الجهاز', description as 'وصف الجهاز', colors as 'لون الجهاز', condition as 'حالة الجهاز' from washing_machine", con);
            //        SqlDataReader da;
            //        DataTable dt = new DataTable();
            //        da = cmd.ExecuteReader();
            //        dt.Load(da);
            //        dataGridView1.DataSource = dt;
            //        da.Close();
            //        clear();
            //    }
            //    else MessageBox.Show("الرجاء إدخال البيانات ");
            //}catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally {  con.Close(); }


            try
            {
                conn.OpenConection();
                string []parmnames={"@WM_Name","@temp","@type","@des","@colors","@con"};
                string []parmvalues={devName.Text, temp.Text , kind.Text, descriptions.Text , colores.Text , conditions.Text };
                SqlDbType []paradbtype={SqlDbType.VarChar,SqlDbType.Float,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar};

                conn.ShowDataInsertUsingStoredProc("washing_machine_insert", parmnames, parmvalues, paradbtype);
                conn.CloseConnection();
                conn.OpenConection();
                dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("washing_machine_select");
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

        private void delete_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            //try{
            // DialogResult result = MessageBox.Show("هل انت متأكد من الحذف؟","حذف",MessageBoxButtons.YesNo);
            // if (DialogResult.Yes == result)
            // {
            //     con.Open();
            //     SqlCommand cmd4 = new SqlCommand("delete from washing_machine where wm_code='" + dev_id.Text + "'", con);
            //     cmd4.ExecuteNonQuery();
            //     cmd4 = new SqlCommand("select wm_code as 'كود الجهاز', wm_name as 'اسم الجهاز', max_temp as ' حرارة الجهاز', wm_type as 'نوع الجهاز', description as 'وصف الجهاز', colors as 'لون الجهاز', condition as 'حالة الجهاز' from washing_machine", con);
            //     SqlDataReader da;
            //     DataTable dt = new DataTable();
            //     da = cmd4.ExecuteReader();
            //     dt.Load(da);
            //     dataGridView1.DataSource = dt;
            //     da.Close();
            //     con.Close();
            //     MessageBox.Show("تم الحذف");
            // }
            // else {
            //     con.Close();
            // }
            //}catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            try
            {
                DialogResult result = MessageBox.Show("هل انت متأكد من الحذف؟", "حذف", MessageBoxButtons.YesNo);
                 if (DialogResult.Yes == result)
                 {
                conn.OpenConection();
                string[] parmnames = { "@wm_code" };
                string[] parmvalues = { dev_id.Text };
                SqlDbType[] paradbtype = { SqlDbType.Int};

                conn.ShowDataInsertUsingStoredProc("washing_machine_delete", parmnames, parmvalues, paradbtype);
                conn.CloseConnection();
                conn.OpenConection();
                dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("washing_machine_select");
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

        private void help_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            //try{
            //    if (dev_id.Text != "")
            //    {
            //        con.Open();
            //        SqlCommand cmd4 = new SqlCommand("update washing_machine set  wm_name='" + devName.Text + "', max_temp='" + temp.Text + "', wm_type='" + kind.Text + "', description='" + descriptions.Text + "', colors='" + colores.Text + "', condition='" + conditions.Text + "' where  wm_code='" + dev_id.Text + "'", con);
            //        cmd4.ExecuteNonQuery();
            //        cmd4 = new SqlCommand("select wm_code as 'كود الجهاز', wm_name as 'اسم الجهاز', max_temp as ' حرارة الجهاز', wm_type as 'نوع الجهاز', description as 'وصف الجهاز', colors as 'لون الجهاز', condition as 'حالة الجهاز' from washing_machine", con);
            //        SqlDataReader da;
            //        DataTable dt = new DataTable();
            //        da = cmd4.ExecuteReader();
            //        dt.Load(da);
            //        dataGridView1.DataSource = dt;
            //        da.Close();
            //        MessageBox.Show("تم التعديل");
            //    }
            //    else MessageBox.Show("الرجاء إدخال كود الجهاز المراد تعديله ");
            //}catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}finally{ con.Close();}

            try
            {
                if (dev_id.Text != "")
                {
                    conn.OpenConection();
                    string[] parmnames = { "@wm_code","@WM_Name","@temp","@type","@des","@colors","@con"};
                    string[] parmvalues = { dev_id.Text, devName.Text, temp.Text, kind.Text, descriptions.Text, colores.Text, conditions.Text };
                    SqlDbType[] paradbtype = {SqlDbType.Int,SqlDbType.VarChar,SqlDbType.Float,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar};

                    conn.ShowDataInsertUsingStoredProc("washing_machine_update", parmnames, parmvalues, paradbtype);
                    conn.CloseConnection();


                    conn.OpenConection();
                    dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("washing_machine_select");
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

        private void temp_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            validate.Float(sender, e, this);
        }

        private void dev_id_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.dev_id.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.devName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.temp.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.descriptions.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.colores.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            this.kind.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            this.conditions.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }
     

        private void kind_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
          
        }

        private void colores_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            validate.letter(sender, e, this);
        }

        private void conditions_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            validate.letter(sender, e, this);
        }

        private void descriptions_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

            validate.letter(sender, e, this);
        }

        private void devName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

        }

    }
}
