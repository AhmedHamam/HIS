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
    public partial class اضافة_شيت : Form
    {
        
        Connection con = new Connection();
        public اضافة_شيت()
        {
            InitializeComponent();
        }

        private void اضافة_شيت_Load(object sender, EventArgs e)
        {
           
            dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 10.25f, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.BorderStyle = 0;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.BackgroundColor = Color.White;
            try
            {
                con.OpenConection();
                SqlDataReader dr = con.DataReader("MedicalSheet_Special_get");
            while (dr.Read())
                {
                 comboBox3.Items.Add(dr[0].ToString());
                 
                }
                con.CloseConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

        }
        void recursiveComboboxValidator(Control cntrl)
        {
            foreach (Control c in cntrl.Controls)
            {
                if (c is ComboBox)
                {
                    ComboBox textBox = c as ComboBox;
                    if (textBox.SelectedValue == null)
                    {
                        MessageBox.Show("ادخل البيانات صحيحة");
                        break;
                    }
                }
                else
                    recursiveComboboxValidator(c);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
           المستخدمين1 u = new المستخدمين1(this);
            u.Show();
        }
        public void Setvalue(DataGridViewRow r)
        {
            try
            {
                textBox4.Text = r.Cells[0].Value.ToString();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            con.OpenConection();
            foreach (Control c in this.Controls)
            {
                if (c is ComboBox)
                {
                    ComboBox textBox = c as ComboBox;
                    if (textBox.SelectedItem == null)
                    {

                        MessageBox.Show("الرجاء ادخال البيانات الناقصة");
                        break;
                    }

                }
                else
                { recursiveComboboxValidator(c); }
            }
            if (textBox1.Text.Equals("") && textBox2.Text.Equals("") && textBox4.Text.Equals(""))
                    {

                        MessageBox.Show("يرجي ادخال البيانات حتي تتم عمليه الحفظ");
                    }
                 else
                {

                    con.OpenConection();
                
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            try
            {
                
                string[] pramname = new string[8];
                string[] pramvalue = new string[8];
                SqlDbType[] pramtype = new SqlDbType[8];
                pramname[0] = "@x1";
                pramname[1] = "@x2";
                pramname[2] = "@x3";
                pramname[3] = "@x4";
                pramname[4] = "@x5";
                pramname[5] = "@x6";
                pramname[6] = "@x7";
                pramname[7] = "@x8";

                pramvalue[0] = textBox1.Text;
                pramvalue[1] = textBox2.Text;
                if (checkBox1.Checked == true)
                    pramvalue[2] = "yes";
                else
                    pramvalue[2] = "no";

                pramvalue[3] = comboBox4.SelectedItem.ToString();
                pramvalue[4] =comboBox2.SelectedItem.ToString();
                pramvalue[5] = comboBox1.SelectedItem.ToString();
                pramvalue[6] = comboBox3.SelectedItem.ToString();
                pramvalue[7] = textBox4.Text;


                pramtype[0] = SqlDbType.VarChar;
                pramtype[1] = SqlDbType.VarChar;
                pramtype[2] = SqlDbType.VarChar;
                pramtype[3] = SqlDbType.VarChar;
                pramtype[4] = SqlDbType.VarChar;
                pramtype[5] = SqlDbType.VarChar;
                pramtype[6] = SqlDbType.VarChar;
                pramtype[7] = SqlDbType.Int;
                
                if (ContainsArabicLetters(textBox1.Text))
                {

                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("MedicalSheet_SheetSetup_Sheet_insert", pramname, pramvalue, pramtype);
                    MessageBox.Show("تم ادخال البيانات بنجاح");
                   
                }
                else
                {
                    MessageBox.Show("يرجي ادخال اسم الشيت باللغة العربية");
                }

                con.CloseConnection();  

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
               try
              {
                  con.OpenConection();
                  SqlDataReader dr = con.DataReader("MedicalSheet_SheetSetup_Selectall");
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.CloseConnection();
   
               }
                  catch (Exception ex)
                 {
                MessageBox.Show(ex.Message);
                }
                 
            }
    
            con.CloseConnection(); 
                
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            المستخدمين1 a = new المستخدمين1(this);
            a.Show();
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال ارقام");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال ارقام");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        internal static bool ContainsArabicLetters(string text)
        {
            foreach (char character in text.ToCharArray())
            {
                if (character >= 0x600 && character <= 0x6ff)
                    return true;

                if (character >= 0x750 && character <= 0x77f)
                    return true;

                if (character >= 0xfb50 && character <= 0xfc3f)
                    return true;

                if (character >= 0xfe70 && character <= 0xfefc)
                    return true;
            }

            return false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
        

                 
        }
    }
}
