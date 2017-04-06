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
    public partial class supplier : Form
    {
        Connection conn = new Connection();
        public supplier()
        {
            InitializeComponent();
        }



        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

            string[] a = { name.Text, website.Text, address.Text, type.Text, natureOfActivity.Text, e_mail.Text, phoneNumber.Text };
            string[] b = { "@name", "@website", "@address", "@type", "@natureOfActivity", "@e_mail", "@phoneNumberint" };
            SqlDbType[] c = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int };

            conn.OpenConection();
            conn.ShowDataInsertUsingStoredProc("supplier_insert", b, a, c);
            conn.CloseConnection();

            conn.OpenConection();
            dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("supplier_Select");
            clear.Clear(this);
            conn.CloseConnection();
        }

        private void supplier_Load(object sender, EventArgs e)
        {
            conn.OpenConection();
            dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("supplier_select");
            clear.Clear(this);
            conn.CloseConnection();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Close();

        }



        private void button6_Click_1(object sender, EventArgs e)
        {
            string[] aa = { "@supplier_name" };
            string[] bb = { name.Text };
            SqlDbType[] cc = { SqlDbType.VarChar };
            conn.OpenConection();
            dataGridView1.DataSource =
            conn.ShowDataInGridViewUsingStoredProc("supplier_search", aa, bb, cc);
            clear.Clear(this);
            conn.CloseConnection();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("هل انت متأكد من الحذف؟", "حذف", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == result)
                {
                    string[] aa = { "@supplier_id" };
                    string[] bb = { supplier_id.Text };
                    SqlDbType[] cc = { SqlDbType.Int };
                    conn.OpenConection();
                    conn.ShowDataInsertUsingStoredProc("supplier_delete", aa, bb, cc);
                    conn.CloseConnection();

                    clear.Clear(this);

                    conn.OpenConection();
                    dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("supplier_select");
                    conn.CloseConnection();

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

        private void phoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void name_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void phoneNumber_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            validate.integer(sender, e, this);
        }

        private void name_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.OpenConection();
            dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("supplier_select");
            clear.Clear(this);
            conn.CloseConnection();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            supplier_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            address.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            phoneNumber.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            type.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            natureOfActivity.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            e_mail.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            website.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

        }

        private void toolStripLabel8_Click(object sender, EventArgs e)
        {
            try
            {
                if (name.Text != "")
                {
                    conn.OpenConection();
                    string[] parmnames = { "@supplier_id", "@name", "@website", "@address", "@type", "@natureOfActivity", "@e_mail", "@phoneNumber" };
                    string[] parmvalues = { supplier_id.Text, name.Text, website.Text, address.Text, type.Text, natureOfActivity.Text, e_mail.Text, phoneNumber.Text };
                    SqlDbType[] paradbtype = { SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int };

                    conn.ShowDataInsertUsingStoredProc("supplier_update", parmnames, parmvalues, paradbtype);
                    conn.CloseConnection();

                    clear.Clear(this);
                    conn.OpenConection();
                    dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("supplier_Select");
                    conn.CloseConnection();


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

        private void toolStripLabel1_Click_1(object sender, EventArgs e)
        {
            Close();
        }

    }

}
