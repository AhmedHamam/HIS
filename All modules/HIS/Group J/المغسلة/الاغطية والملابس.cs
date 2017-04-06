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
    public partial class covers_clothes : Form
    {
        Connection conn = new Connection();
        
        public covers_clothes()
        {
            InitializeComponent();
        }

        private void add_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                conn.OpenConection();
                string[] parmnames = { "@cover_name", "@wm_code" };
                string[] parmvalues = { coverName.Text, textBox2.Text };
                SqlDbType[] paradbtype = { SqlDbType.VarChar, SqlDbType.Int };

                conn.ShowDataInsertUsingStoredProc("covers_clothes_Insert", parmnames, parmvalues, paradbtype);
                conn.CloseConnection();
                conn.OpenConection();
                dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("covers_clothes_Select");
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
           
            try
            {
                DialogResult result = MessageBox.Show("هل انت متأكد من الحذف؟", "حذف", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == result)
                {
                    conn.OpenConection();
                    string[] parmnames = { "@cover_id" };
                    string[] parmvalues = { coverId.Text };
                    SqlDbType[] paradbtype = { SqlDbType.Int };

                    conn.ShowDataInsertUsingStoredProc("covers_clothes_Delete", parmnames, parmvalues, paradbtype);
                    conn.CloseConnection();
                    conn.OpenConection();
                    dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("covers_clothes_Select");
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

        private void Form1_Load(object sender, EventArgs e)
        {
         ;
            try
            {
                conn.OpenConection();
                dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("covers_clothes_Select");
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

        private void exit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void coverId_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void description_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (coverId.Text != "")
                {
                    conn.OpenConection();
                    string[] parmnames = { "@cover_id", "@cover_name", "@wm_code" };
                    string[] parmvalues = {coverId.Text, coverName.Text, textBox2.Text };
                    SqlDbType[] paradbtype = {SqlDbType.Int, SqlDbType.VarChar, SqlDbType.Int };

                    conn.ShowDataInsertUsingStoredProc("covers_clothes_Update", parmnames, parmvalues, paradbtype);
                    conn.CloseConnection();


                    conn.OpenConection();
                    dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("covers_clothes_Select");
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
       
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            this.coverId.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.coverName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.textBox2.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = this.textBox2.Text;

            pop frm = new pop();
            frm.showdi(ref code, "select wm_code as 'كود الجهاز', wm_name as 'اسم الجهاز', max_temp as ' حرارة الجهاز', wm_type as 'نوع الجهاز', description as 'وصف الجهاز', colors as 'لون الجهاز', condition as 'حالة الجهاز' from washing_machine", "اجهزة المغسلة");

            this.textBox2.Text = code;
           
        }

        private void coverName_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
               
        }   
    }
}