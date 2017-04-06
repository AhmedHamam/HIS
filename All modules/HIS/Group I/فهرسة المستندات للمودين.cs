using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace HIS
{
    public partial class scan_sup : Form
    {

        Connection con = new Connection();
        public string en = "";
        public string ec = "";
        public scan_sup()
        {
            InitializeComponent();
        }


 //**********************عرض******************************************************************

        private void scan_sup_Load(object sender, EventArgs e)
        {
            try
            {
                viewsup();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }



        private void viewsup()
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("viewsup");

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

 //*******************************بحث************************************************
        private void searchsup_Click(object sender, EventArgs e)
        {

            try
            {
                con.OpenConection();
                if (textBox4.Text != "" && textBox1.Text == "")
                {
                    string[] s = new string[] { "@sname" };
                    string[] s2 = new string[] { textBox4.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("searchbynamesup", s, s2, s3);
                }
                else if (textBox4.Text == "" && textBox1.Text != "")
                {
                    string[] s = new string[] { "@id" };
                    string[] s2 = new string[] { textBox1.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("searchbeidsup", s, s2, s3);
                }
                else if (textBox1.Text != "" && textBox4.Text != "")
                {
                    string[] s = new string[] { "@id", "@name" };
                    string[] s2 = new string[] { textBox1.Text, textBox4.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("searchbyidnamesup", s, s2, s3);
                    if (dataGridView1.RowCount == 1)
                    {
                        MessageBox.Show("هذا الكود غير متفق مع الاسم ");
                    }
                }
                else
                {
                    viewsup();
                }
                con.CloseConnection();
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }



//********************************خروج************************************
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

//**********************حذف**************************************************************

        private void delsup_Click(object sender, EventArgs e)
        {
            try
            {

                con.OpenConection();
                if (dataGridView1.CurrentCell.RowIndex >= 0)
                {
                    DialogResult dia = MessageBox.Show("هل انت متاكد من الحذف", "تنبيه", MessageBoxButtons.YesNo);
                    if (dia == DialogResult.Yes)
                    {
                       

                        string[] s = new string[] { "@id" };
                        string[] s2 = new string[] { dataGridView1.CurrentRow.Cells[0].Value.ToString() };
                        SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                        con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delsup", s, s2, s3);
                        viewsup();
                    }
                    if (dia == DialogResult.No)
                    {
                        dia = DialogResult.Cancel;
                        textBox1.Text = "";
                        textBox4.Text = "";
                    }
                }

            }

            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }
        }


//********************************************************************************
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int i = dataGridView1.CurrentRow.Index;
                textBox1.Text = dataGridView1.Rows[i].Cells["الكود"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[i].Cells["اسم المورد"].Value.ToString();

            }
            catch (Exception ss)
            {
                MessageBox.Show(ss.Message);
            }
        }


 //**********************************************ادخال مستند**********************************       
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                en = dataGridView1.CurrentRow.Cells["اسم المورد"].Value.ToString();
                ec = dataGridView1.CurrentRow.Cells["الكود"].Value.ToString();
                عملية_ادخال_مستندات_للموردين f = new عملية_ادخال_مستندات_للموردين(en, ec);
                f.ShowDialog();
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }


//******************************اضافة***********************************************

        private void addsup_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                if(textBox4.Text!="")
                {
                string[] s = new string[] { "@pname" };
                string[] s2 = new string[] { textBox4.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("insertsup", s, s2, s3);
                viewsup();
                textBox4.Text = "";
                }
                else
                {
                    MessageBox.Show("ادخل الاسم ");
                }
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar) )
            {
                MessageBox.Show("الكود يجب ان يكون ارقام");
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                MessageBox.Show("الاسم يجب ان يكون حروف ");
                e.Handled = true;
            }
        }

       
 
    }
}
