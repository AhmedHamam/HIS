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
    public partial class scan_emp : Form
    {
        Connection con = new Connection();
       public  string en= "";
       public string ec = "";
     //   public sanner_prosess otherform = new sanner_prosess();
       
        public scan_emp()
        {
            InitializeComponent();
        }

        private void scan_emp_Load(object sender, EventArgs e)
        {
            viewemp();
        }


//*******************عرض****************************************
        private void viewemp()
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("viewemp");
                con.CloseConnection();
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }




//********************************بحث*************************************************
        private void searchemp_Click(object sender, EventArgs e)
        {
            
            try {
                con.OpenConection();
                if (textBox1.Text != "" && textBox16.Text == "")
                {
                    string[] s = new string[] { "@pname" };
                    string[] s2 = new string[] { textBox1.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("serchbynameemp", s, s2, s3);
                }
                else if (textBox1.Text == "" && textBox16.Text != "")
                {
                    string[] s = new string[] { "@id" };
                    string[] s2 = new string[] { textBox16.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("searchbyidemp", s, s2, s3);
                }
                else if (textBox1.Text != "" && textBox16.Text != "")
                {
                    string[] s = new string[] {"@id","@name"};
                    string[] s2 = new string[] {textBox16.Text, textBox1.Text};
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar };
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("searchbyidnameemp", s, s2, s3);
                    if (dataGridView1.RowCount == 1)
                    {
                        MessageBox.Show("هذا الكود غير متفق مع الاسم ");
                    }
                }
                else 
                {
                    viewemp();
                }
                con.CloseConnection();
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }
        }


//************************************ادخال مستند******************************************************
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            en= dataGridView1.CurrentRow.Cells["اسم الموظف"].Value.ToString();
            ec = dataGridView1.CurrentRow.Cells["الكود"].Value.ToString();
            scanner_prosess f = new scanner_prosess(en,ec);
            f.Show();
          
        }



//***************************************خروج******************************************
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

//*******************************اضافة**************************
        private void addemp_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                if (textBox1.Text != "")
                {
                    string[] s = new string[] { "@pname" };
                    string[] s2 = new string[] { textBox1.Text };
                    SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("insertemp", s, s2, s3);
                    viewemp();
                    textBox1.Text = "";
                    textBox16.Text = "";
                }
                else
                {
                    MessageBox.Show("ادخل الاسم ");
                }
                con.CloseConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }




//****************************************************************************************
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int i = dataGridView1.CurrentRow.Index;
                textBox16.Text = dataGridView1.Rows[i].Cells["الكود"].Value.ToString();
                textBox1.Text = dataGridView1.Rows[i].Cells["اسم الموظف"].Value.ToString();

            }
            catch (Exception ss)
            {
                MessageBox.Show(ss.Message);
            }
        }



//**********************مسح*********************************************

        private void delemp_Click(object sender, EventArgs e)
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
                        con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delemp", s, s2, s3);
                        viewemp();
                        textBox1.Text = "";
                        textBox16.Text = "";
                    }
                    if (dia == DialogResult.No)
                    {
                        dia = DialogResult.Cancel;
                        textBox1.Text = "";
                        textBox16.Text = "";
                    }
                }
                con.CloseConnection();
            }

            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }

        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                MessageBox.Show("الاسم يجب ان يكون حروف ");
                e.Handled = true;
            }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar) )
            {
                MessageBox.Show("الكود يجب ان يكون ارقام");
                e.Handled = true;
            }
        }

       
        }

  
}
