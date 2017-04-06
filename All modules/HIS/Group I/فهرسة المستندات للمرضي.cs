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
    public partial class scan_patient : Form
    {
        Connection con = new Connection();
        public string en = "";
        public string ec = "";
        public static Boolean add=false;
        public scan_patient()
        {
            InitializeComponent();
        }


//*****************************بحث**************************************************

        private void searchpat_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                if (textBox3.Text != "" && textBox1.Text == "")
                {
                    string[] s = new string[] { "@pname" };
                    string[] s2 = new string[] { textBox3.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("searchbynamepat", s, s2, s3);
                }
                else if (textBox3.Text == "" && textBox1.Text != "")
                {
                    string[] s = new string[] { "@id" };
                    string[] s2 = new string[] { textBox1.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("searchbyidpatient", s, s2, s3);
                }
                else if (textBox1.Text != "" && textBox3.Text != "")
                {
                    string[] s = new string[] { "@id", "@name" };
                    string[] s2 = new string[] { textBox1.Text, textBox3.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("searchbyidnamepatient", s, s2, s3);
                    if (dataGridView1.RowCount == 1)
                    {
                        MessageBox.Show("هذا الكود غير متفق مع الاسم ");
                    }
                }
                else
                {
                    viewpatient();
                }
                con.CloseConnection();
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }

  
//***********************************************عرض*****************

        private void scan_patient_Load(object sender, EventArgs e)
        {
            viewpatient();

        }

        private void viewpatient()
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("viewpatient");

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

//************************************خروج****************************************

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


//******************************تسجيل مريض***************************************

       
       

 //*********************************************************************************************      

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try 
            {
                int i = dataGridView1.CurrentRow.Index;
                textBox1.Text = dataGridView1.Rows[i].Cells["الكود"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells["اسم المريض"].Value.ToString();
                
            }
            catch(Exception ss)
            {
                MessageBox.Show(ss.Message);
            }

        }

//****************************************************************************

        

       

//*************************************ادخال مستند****************************************
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }


//********************************حذف**********************************************

        private void delpatient_Click(object sender, EventArgs e)
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
                      con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delpat", s, s2, s3);
                        viewpatient();
                        textBox1.Text = "";
                        textBox3.Text = "";
                    }
                    if (dia == DialogResult.No)
                    {
                        dia = DialogResult.Cancel;
                        textBox1.Text = "";
                        textBox3.Text = "";
                    }
                }

            }

            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }
        }


//********************************اضافة**************************************************

        private void addpatient_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                if(textBox3.Text!="")
                {
                string[] s = new string[] { "@pname" };
                string[] s2 = new string[] { textBox3.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("insertpatient", s, s2, s3);
                viewpatient();
                textBox1.Text = "";
                textBox3.Text = "";
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
                MessageBox.Show("الكود يجب ان يكون ارقام ");
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                MessageBox.Show("الاسم يجب ان يكون حروف ");
                e.Handled = true;
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                en = dataGridView1.CurrentRow.Cells["اسم المريض"].Value.ToString();
                ec = dataGridView1.CurrentRow.Cells["الكود"].Value.ToString();
                عملية_ادخال_مستند_للمرضيcs f = new عملية_ادخال_مستند_للمرضيcs (en, ec);
                f.ShowDialog();
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }

        
    }
}
