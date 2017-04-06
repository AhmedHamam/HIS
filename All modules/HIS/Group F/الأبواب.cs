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
    public partial class الابواب : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        
   
        public الابواب()
        {
            InitializeComponent();
           
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
        private void add_Click_1(object sender, EventArgs e)
        {
          if (txtSecid.Text == "" || txtsecName.Text == "")
                        {
                            MessageBox.Show("من فضلك ادخل البيانات كاملة ");
                        }
             else
                        {
           
                con.OpenConection();
                cmd = new SqlCommand("add_section", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("section_id", txtSecid.Text);
                cmd.Parameters.AddWithValue("section_name", txtsecName.Text);
                // cmd = new MySqlCommand("insert into sections(section_id,section_name) values ('" + txtSecid.Text + "','" + txtsecName.Text + "')", con);
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

        private void search_Click_1(object sender, EventArgs e)
        {
            if (txtSecid.Text == "")
            {
                MessageBox.Show("من فضلك ادخل رقم الباب ");
            }
            else
            {
         
                con.OpenConection();
                cmd = new SqlCommand("search_section", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", txtSecid.Text);
               // cmd = new MySqlCommand("select section_id as'رقم الباب',section_name as'اسم الباب' from sections where section_id=" + txtSecid.Text, con);
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
            if (txtSecid.Text == "")
            {
                MessageBox.Show("من فضلك ادخل رقم الباب ");
            }
            else
            {
               
                con.OpenConection();
                cmd = new SqlCommand("delete_section", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", txtSecid.Text);
                //cmd = new MySqlCommand("delete from sections where section_id=" + txtSecid.Text, con);
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
            dataGridView1.ClearSelection();
        }

        private void txtSecid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام صحيحة فقط");
            }
        }

      

        private void txtsecName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show(" من فضلك ادخل حروف فقط ");
            }

        }

       
       
    }
}
