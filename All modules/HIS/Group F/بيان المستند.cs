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

namespace HIS
{
    public partial class بيانمستند : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        int num;
        public بيانمستند()
        {
            InitializeComponent();
            
            con.OpenConection();
            da = new SqlDataAdapter("select item_name,item_id from items", con.con);
            dt = new DataTable();
            da.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "item_name";
            comboBox2.ValueMember = "item_id";


            con.CloseConnection();
        }
     

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDocid.Text == "" || txtDocname.Text == "" || txtMoney.Text == "" || txtAuthorityto.Text == "")
            {
                MessageBox.Show("من فضلك ادخل البيانات كاملة ");
            }
            else
            {
               
                con.OpenConection();
                cmd = new SqlCommand("pay", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("doc_id", txtDocid.Text);
                cmd.Parameters.AddWithValue("doc_date", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("doc_name", txtDocname.Text);
                cmd.Parameters.AddWithValue("money_needed", txtMoney.Text);
                cmd.Parameters.AddWithValue("particular_authorityFrom", comboBox3.Text);
                cmd.Parameters.AddWithValue("particular_authorityTo", txtAuthorityto.Text);
                cmd.Parameters.AddWithValue("name1", comboBox2.Text);
                try
                {
                    num = cmd.ExecuteNonQuery();
                    if (num > 0)
                    {
                        MessageBox.Show("تم السحب");
                    }


                    else if (num <= 0)
                    {
                        
                        MessageBox.Show("عفوا,الميزانية لا تكفي");
                    }
                   
                    
                }
                catch (Exception ee)
                {
                    MessageBox.Show("خطأ في البيانات");
                }
                con.CloseConnection();
            }

        }

        private void txtDocid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام صحيحة فقط");
            }
        }

        private void txtDocname_KeyPress(object sender, KeyPressEventArgs e)
        {
          
              if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show(" من فضلك ادخل حروف فقط ");
            }
        }


      

        private void txtMoney_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام فقط");
            }
        }
       
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            e.Graphics.DrawString("بيان المستند", new Font("Arial", 30, FontStyle.Bold), Brushes.Black, new Point(400, 90));
            e.Graphics.DrawString("رقم المستند:"+txtDocid.Text,new Font("arial",15,FontStyle.Regular),Brushes.Black,800,180,format);
            e.Graphics.DrawString("تاريخ المستند:" + dateTimePicker1.Text, new Font("arial", 15, FontStyle.Regular), Brushes.Black,800,240,format);
            e.Graphics.DrawString("اسم صاحب المستند:" + txtDocname.Text, new Font("arial", 15, FontStyle.Regular), Brushes.Black,800, 300,format);
            e.Graphics.DrawString("المبلغ المراد سحبه:" + txtMoney.Text, new Font("arial", 15, FontStyle.Regular), Brushes.Black,800,360,format);
            e.Graphics.DrawString("الجهة المختصة :      من :" + comboBox3.Text, new Font("arial", 15, FontStyle.Regular), Brushes.Black, 800, 420, format);
            e.Graphics.DrawString("   الى : " + txtAuthorityto.Text, new Font("arial", 15, FontStyle.Regular), Brushes.Black,400,420,format);
            e.Graphics.DrawString("اسم البند:" + comboBox2.Text, new Font("arial", 15, FontStyle.Regular), Brushes.Black,800,480,format);

        }
       
     
        private void btnprint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }

     

        private void txtAuthorityto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show(" من فضلك ادخل حروف فقط ");
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (txtDocid.Text == "")
            {
                MessageBox.Show("من فضلك ادخل رقم المستند ");
            }
            else
            {
        
                con.OpenConection();
                cmd = new SqlCommand("delete_document", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", txtDocid.Text);
                //cmd = new MySqlCommand("delete from document_release where doc_id=" + txtDocid.Text, con);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم الحذف");
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
                con.CloseConnection();
            }
        }
        public void CleartextBoxes1()
        {
            foreach (Control Cleartext in this.Controls)
            {

                if (Cleartext is TextBox)
                {

                    ((TextBox)Cleartext).Text = string.Empty;

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CleartextBoxes1();
        }

      

       

        }
      
    }

