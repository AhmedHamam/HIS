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
    public partial class scan_clint : Form
    {
        Connection con = new Connection();
        public string en = "";
        public string ec = "";
        public scan_clint()
        {
            InitializeComponent();
        }


//****************************بحث*******************************
        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                con.OpenConection();
                if (textBox2.Text != "" && textBox1.Text == "")
                {
                    string[] s = new string[] { "@pname" };
                    string[] s2 = new string[] { textBox2.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("serchbynameclient", s, s2, s3);
                }
                else if (textBox2.Text == "" && textBox1.Text != "")
                {
                    string[] s = new string[] { "@id" };
                    string[] s2 = new string[] { textBox1.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("searchbyidclient", s, s2, s3);
                }
                else if (textBox1.Text != "" && textBox2.Text != "")
                {
                    string[] s = new string[] { "@id", "@name" };
                    string[] s2 = new string[] { textBox1.Text, textBox2.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("searchbyidnameclient", s, s2, s3);
                    if (dataGridView1.RowCount == 1)
                    {
                        MessageBox.Show("هذا الكود غير متفق مع الاسم ");
                    }
                }
                else
                {
                    viewclient();
                }
                con.CloseConnection();
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
            
        }


//**************************************خروج*********************************

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
//****************************عرض********************************
        private void scan_clint_Load(object sender, EventArgs e)
        {
            viewclient();
        }

        private void viewclient()
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("viewclient");
               
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }



//***************************************************************************************
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int i = dataGridView1.CurrentRow.Index;
                textBox1.Text = dataGridView1.Rows[i].Cells["الكود"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells["اسم العميل"].Value.ToString();

            }
            catch (Exception ss)
            {
                MessageBox.Show(ss.Message);
            }
        }


//****************************************************************************
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                if (textBox2.Text!="")
                {
            string[] s = new string[] { "@pname" };
            string[] s2 = new string[] { textBox2.Text };
            SqlDbType[] s3 = new SqlDbType[] {SqlDbType.NVarChar };
            con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("insertclient", s, s2, s3);
            textBox2.Text = "";
            textBox1.Text = "";  
            viewclient();
                }
                else
                {
                    MessageBox.Show("ادخل الاسم ");
                }
             con.CloseConnection();
             }

            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }
        }

       
//***************************حذف*******************************************
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {

                con.OpenConection();
                if (dataGridView1.CurrentCell.RowIndex >= 0)
                {
                    DialogResult dia = MessageBox.Show("هل انت متاكد من الحذف", "تنبيه", MessageBoxButtons.YesNo);
                    if (dia == DialogResult.Yes)
                    {
                        //object del = new Object();
                        string[] s = new string[] { "@id" };
                        string[] s2 = new string[] { dataGridView1.CurrentRow.Cells[0].Value.ToString() };
                        SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                         con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delclient", s, s2, s3);
                        viewclient();
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                    if (dia == DialogResult.No)
                    {
                        dia = DialogResult.Cancel;
                        textBox1.Text = "";
                        textBox2.Text = "";
                    }
                }

            }

            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }

        }


//************************************ادخال مستند*********************************************
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                en = dataGridView1.CurrentRow.Cells["اسم العميل"].Value.ToString();
                ec = dataGridView1.CurrentRow.Cells["الكود"].Value.ToString();
                عملية_ادخال_مستند_للجهات f = new عملية_ادخال_مستند_للجهات(en, ec);
                f.ShowDialog();
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar) )
            {
                MessageBox.Show("الكود يجب ان يكون ارقام ");
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                MessageBox.Show("الاسم يجب ان يكون حروف ");
                e.Handled = true;
            }
        }
    }
}
