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
    public partial class دفترالموازنات : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataReader dr;
        public دفترالموازنات()
        {
            InitializeComponent();
        }

       
        private void txtItemname_Click(object sender, EventArgs e)
        {
          con.OpenConection();
            cmd = new SqlCommand("select item_name ,credit_value from items where ' " + textBox1.Text + " ' =item_id", con.con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                txtItemname.Text = dr["item_name"].ToString();
                txtCreditvalue.Text = dr["credit_value"].ToString();
            }
            dr.Close();
            con.CloseConnection();
        }

        private void txtserialNum_Click(object sender, EventArgs e)
        {
          
            con.OpenConection();
            cmd = new SqlCommand("select money_needed,item_id,particular_authorityFrom,particular_authorityTo from document_release  where ' " + txtserialNum.Text + " ' =doc_id", con.con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txtMoney.Text = dr["money_needed"].ToString();
                textBox1.Text = dr["item_id"].ToString();
                txtAuthorityfrom.Text = dr["particular_authorityFrom"].ToString();
                txtAuthorityto.Text = dr["particular_authorityTo"].ToString();
            }
            dr.Close();
            con.CloseConnection();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (txtserialNum.Text == "" || txtMoney.Text == "" || txtCreditvalue.Text == "" || txtItemname.Text == "" || txtAuthorityfrom.Text == "" || txtAuthorityto.Text == "")
            {
                MessageBox.Show("من فضلك ادخل البيانات كاملة ");
            }
            else
            {
              con.OpenConection();
                cmd = new SqlCommand("insert_budget", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("serial_num",txtserialNum.Text);
                cmd.Parameters.AddWithValue("expense",txtMoney.Text );
                cmd.Parameters.AddWithValue("credit_value", txtCreditvalue.Text);
                cmd.Parameters.AddWithValue("particular_authorityFrom",txtAuthorityfrom.Text);
                cmd.Parameters.AddWithValue("particular_authorityTo", txtAuthorityto.Text);
                cmd.Parameters.AddWithValue("item_id", textBox1.Text);
                cmd.Parameters.AddWithValue("it_name", txtItemname.Text);
                cmd.Parameters.AddWithValue("doc_entryDate", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm"));
               // cmd = new MySqlCommand("insert into book_budget(serial_num,expense,credit_value,particular_authorityFrom,particular_authorityTo,item_id,it_name,doc_entryDate) values ('" + txtserialNum.Text + "','" + txtMoney.Text + "','" + txtCreditvalue.Text + "','" + txtAuthorityfrom.Text + "','" + txtAuthorityto.Text + "','" + textBox1.Text + "','" + txtItemname.Text + "','" + dateTimePicker1.Value.Date.ToString("yyyy-MM,dd HH:mm") + "')", con);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم التسجيل");

                }
                catch (Exception ee)
                {
                    MessageBox.Show("خطأ في البيانات");
                }
                con.CloseConnection();
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (txtserialNum.Text == "")
            {
                MessageBox.Show("من فضلك ادخل رقم البند ");
            }
            else
            {
             
                con.OpenConection();
                cmd = new SqlCommand("delete_budget", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", txtserialNum.Text);
                //cmd = new MySqlCommand("delete from book_budget where serial_num=" + txtserialNum.Text, con);
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

        private void txtDocid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
     (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام صحيحة فقط");
            }
        }


     

        }

      
    }

