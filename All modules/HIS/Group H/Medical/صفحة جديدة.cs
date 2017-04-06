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
    public partial class صفحة_جديدة : Form
    {
        صناعة_شيت m;

        Connection con = new Connection();
        static int st;
        public static List<string> a ;
              public صفحة_جديدة()
        {
            InitializeComponent();
        }

              public صفحة_جديدة(صناعة_شيت y)
              {
                  InitializeComponent();
                  y = m;
              }
       
        private void صفحة_جديدة_Load(object sender, EventArgs e)
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
                string[] pramname1 = new string[1];
                string[] pramvalue1 = new string[1];
                SqlDbType[] pramtype1 = new SqlDbType[1];
                pramname1[0] = "@x1";
                pramvalue1[0] = st.ToString();
                pramtype1[0] = SqlDbType.VarChar;
                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("MedicalSheet_NewPage_select", pramname1, pramvalue1, pramtype1);
                con.CloseConnection();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
     

        public void Setvalue(int r)
        {
            try
            {

                st = r;


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void Setv(int r)
        {
            try
            {

                


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void حذفToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                if (cell.Selected)
                {
                    con.OpenConection();
                    string[] name = { "@x" };
                    string[] value = { dataGridView1.Rows[cell.RowIndex].Cells[0].Value.ToString() };
                    SqlDbType[] type = { SqlDbType.VarChar };
                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_Page", name, value, type);

                    dataGridView1.Rows.RemoveAt(cell.RowIndex);
                    con.CloseConnection();
                  
                }
                MessageBox.Show("تم الحذف");
               
            }
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
            if (textBox1.Text.Equals("") && textBox2.Text.Equals(""))
            {

                MessageBox.Show("يرجي ادخال البيانات حتي تتم عمليه الحفظ");
            }
            else
            {

                try
                {
                    con.OpenConection();
                    string[] pramname = new string[4];
                    string[] pramvalue = new string[4];
                    SqlDbType[] pramtype = new SqlDbType[4];
                    pramname[0] = "@x1";
                    pramname[1] = "@x2";
                    pramname[2] = "@x3";
                    pramname[3] = "@x4";

                    pramvalue[0] = st.ToString();
                    pramvalue[1] = textBox1.Text;
                    pramvalue[2] = textBox2.Text;
                    pramvalue[3] = comboBox1.SelectedItem.ToString();

                    pramtype[0] = SqlDbType.VarChar;
                    pramtype[1] = SqlDbType.VarChar;
                    pramtype[2] = SqlDbType.VarChar;
                    pramtype[3] = SqlDbType.VarChar;
                    if (ContainsArabicLetters(textBox1.Text))
                    {
                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("MedicalSheet_NewPage_insert", pramname, pramvalue, pramtype);

                        MessageBox.Show("تم ادخال البيانات بنجاح");
                        con.CloseConnection();

                    }
                    else
                    {
                        MessageBox.Show("يرجي ادخال اسم الصفحة باللغة العربية");
                    }

                    con.OpenConection();
                    string[] pramname1 = new string[1];
                    string[] pramvalue1 = new string[1];
                    SqlDbType[] pramtype1 = new SqlDbType[1];
                    pramname1[0] = "@x1";
                    pramvalue1[0] = st.ToString();
                    pramtype1[0] = SqlDbType.VarChar;
                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("MedicalSheet_NewPage_select", pramname1, pramvalue1, pramtype1);
                    a = new List<string>();
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        a.Add(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    con.CloseConnection();



                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
            
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
    }
}
