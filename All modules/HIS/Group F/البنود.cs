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
    public partial class البنود : Form
    {
      Connection con = new Connection();
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataTable dt;
        
        public البنود()
        {
            InitializeComponent();
           
            con.OpenConection();
            da = new SqlDataAdapter("select section_id,section_name from sections;", con.con);
            dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;

            comboBox1.DisplayMember = "section_name";
            comboBox1.ValueMember = "section_id";
          

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

        private void add_Click(object sender, EventArgs e)
        {
            if (txtItemid.Text == "" || txtIemname.Text == "" || txtCreditvalue.Text == "")
            {
                MessageBox.Show("من فضلك ادخل البيانات كاملة ");
            }
            else
            {
                con.OpenConection();
                cmd = new SqlCommand("add_item", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("item_id", txtItemid.Text);
                cmd.Parameters.AddWithValue("item_name", txtIemname.Text);
                cmd.Parameters.AddWithValue("credit_value", txtCreditvalue.Text);
                cmd.Parameters.AddWithValue("name1", comboBox1.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تمت الاضافة");

                }
                catch (Exception ee)
                {
                    MessageBox.Show("خطأ في البيانات");
                }
                con.CloseConnection();
            }
            
        }

        private void search_Click(object sender, EventArgs e)
        {
            if (txtItemid.Text == "")
            {
                MessageBox.Show("من فضلك ادخل رقم البند ");
            }
            else
            {
                
                con.OpenConection();
                cmd = new SqlCommand("search_item", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", txtItemid.Text);
               // cmd = new MySqlCommand("select item_id as 'رقم البند', item_name as 'اسم البند',credit_value as 'قيمة الاعتماد',section_id as 'رقم الباب' from items where item_id=" + txtItemid.Text, con);
                try
                {
                    dr = cmd.ExecuteReader();
                    dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }

                con.CloseConnection();
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (txtItemid.Text == "")
            {
                MessageBox.Show("من فضلك ادخل رقم البند ");
            }
            else
            {
               
                con.OpenConection();
                cmd = new SqlCommand("delete_item", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id",txtItemid.Text);
              // cmd = new MySqlCommand("delete from items where item_id=" + txtItemid.Text, con);
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

        private void clear_Click(object sender, EventArgs e)
        {
            CleartextBoxes1();
         
            

        }

      

        private void txtItemid_KeyPress(object sender, KeyPressEventArgs e)
        {  

    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
    {
            e.Handled = true;
        MessageBox.Show("من فضلك ادخل ارقام صحيحة فقط");
    }

   
}

     

        private void txtIemname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show(" من فضلك ادخل حروف فقط ");
            }

        }



        private void txtCreditvalue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
      (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام فقط");
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (txtItemid.Text == "" || txtIemname.Text == "" || txtCreditvalue.Text == "")
            {
                MessageBox.Show("من فضلك ادخل البيانات كاملة ");
            }
            else
            {
                
                con.OpenConection();
                cmd = new SqlCommand("update items set item_name=N'" + txtIemname.Text.ToString() + "',credit_value='" + txtCreditvalue.Text + "',section_id='" + comboBox1.SelectedValue + "' where item_id=" + txtItemid.Text, con.con);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم  التعديل");
                }
                catch (Exception ee)
                {
                    MessageBox.Show("خطأ في البيانات");
                }
                con.CloseConnection();
            }
        }

       

       

      
        }
      
    }

