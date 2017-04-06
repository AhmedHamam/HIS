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
    public partial class detergentForm : Form
    {
        Connection conn = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=(local);Database=HIS; Integrated Security=true");
        public detergentForm()
        {
            InitializeComponent();
        }

        private void exit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void add_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           // try
           // {
           //     if (quantity.Text != "" && price.Text != "")
           //     {
           // con.Open();
           // SqlCommand cmd4 = new SqlCommand("insert into  detergents(detergent_quantity,price) values('" + quantity.Text + "','" + price.Text + "' )", con);
           // cmd4.ExecuteNonQuery();
           // Utilities.ResetAllControls(this);
           // cmd4 = new SqlCommand("select detergent_id as 'كود المسحوق' ,detergent_quantity as 'كمية المسحوق',price as 'سعر المسحوق' from detergents", con);
           // SqlDataReader da;
           // DataTable dt = new DataTable();
           // da = cmd4.ExecuteReader();
           // dt.Load(da);
           // dataGridView1.DataSource = dt;
           // da.Close();
           // clear();
           //}
           //     else MessageBox.Show("الرجاء إدخال البيانات ");
           // }
           // catch (Exception ex)
           // {
           //     MessageBox.Show(ex.Message);
           // }
           // finally { con.Close(); }
            try
            {
                conn.OpenConection();
                string[] parmnames = { "@detName", "@detergent_quantity", "@price" };
                string[] parmvalues = { detName.Text, quantity.Text, price.Text};
                SqlDbType[] paradbtype = { SqlDbType.VarChar, SqlDbType.Float, SqlDbType.Int };

                conn.ShowDataInsertUsingStoredProc("detergents_Insert", parmnames, parmvalues, paradbtype);
                conn.CloseConnection();
                conn.OpenConection();
                dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("detergents_Select");
                conn.CloseConnection();
                clear.Clear(this);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //con.Open();
            //SqlCommand cmd4 = new SqlCommand("select detergent_id as 'كود المسحوق' ,detergent_quantity as 'كمية المسحوق',price as 'سعر المسحوق' from detergents", con);
            //SqlDataReader da;
            //DataTable dt = new DataTable();
            //da = cmd4.ExecuteReader();
            //dt.Load(da);
            //dataGridView1.DataSource = dt;
            //da.Close();
            //con.Close();
            try
            {
                conn.OpenConection();
                dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("detergents_Select");
                conn.CloseConnection();
                clear.Clear(this);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        private void delete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // try
            //{
            //    if (det_id.Text != "")
            //    {
            //DialogResult result = MessageBox.Show("هل انت متأكد من الحذف؟","حذف",MessageBoxButtons.YesNo);
            // if (DialogResult.Yes == result)
            // {
            //con.Open();
            //SqlCommand cmd4 = new SqlCommand("delete from detergents where detergent_id='" + det_id.Text + "'", con);
            //cmd4.ExecuteNonQuery();
            //Utilities.ResetAllControls(this);
            //cmd4 = new SqlCommand("select detergent_id as 'كود المسحوق' ,detergent_quantity as 'كمية المسحوق',price as 'سعر المسحوق' from detergents", con);
            //SqlDataReader da;
            //DataTable dt = new DataTable();
            //da = cmd4.ExecuteReader();
            //dt.Load(da);
            //dataGridView1.DataSource = dt;
            //da.Close();
            // }
            // else
            // {
            //     con.Close();
            // }
            //    }
            //    else MessageBox.Show("الرجاء إدخال كود المراد حذفه  ");
            //}
            // catch (Exception ex)
            // {
            //     MessageBox.Show(ex.Message);
            // }
            // finally { con.Close(); };
            try
            {
                DialogResult result = MessageBox.Show("هل انت متأكد من الحذف؟", "حذف", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == result)
                {
                    conn.OpenConection();
                    string[] parmnames = { "@detergent_id" };
                    string[] parmvalues = { det_id.Text };
                    SqlDbType[] paradbtype = { SqlDbType.Int };

                    conn.ShowDataInsertUsingStoredProc("detergents_Delete", parmnames, parmvalues, paradbtype);
                    conn.CloseConnection();
                    conn.OpenConection();
                    dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("detergents_Select");
                    conn.CloseConnection();
                    clear.Clear(this);
                    MessageBox.Show("تم الحذف");
                }
                else
                {
                    conn.CloseConnection();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }

        }

        private void help_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //try
            //{
            //    if (det_id.Text != "" && quantity.Text != "" && price.Text != "")
            //    {
            //        con.Open();
            //        SqlCommand cmd4 = new SqlCommand("update detergents set  detergent_quantity='" + quantity.Text + "', price='" + price.Text + "' where  detergent_id='" + det_id.Text + "'", con);
            //        cmd4.ExecuteNonQuery();
            //        cmd4 = new SqlCommand("select detergent_id as 'كود المسحوق' ,detergent_quantity as 'كمية المسحوق',price as 'سعر المسحوق' from detergents", con);
            //        SqlDataReader da;
            //        DataTable dt = new DataTable();
            //        da = cmd4.ExecuteReader();
            //        dt.Load(da);
            //        dataGridView1.DataSource = dt;
            //        da.Close();
            //        MessageBox.Show("تم التعديل");
            //        Utilities.ResetAllControls(this);
            //    }
            //    else MessageBox.Show("الرجاء إدخال البيانات المراد تعديله ");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally { con.Close(); }
            try
            {
                if (det_id.Text != "")
                {
                    conn.OpenConection();
                    string[] parmnames = { "@detergent_id", "@det_Name", "@detergent_quantity", "@price" };
                    string[] parmvalues = {det_id.Text, detName.Text, quantity.Text, price.Text };
                    SqlDbType[] paradbtype = { SqlDbType.Int,SqlDbType.VarChar, SqlDbType.Float, SqlDbType.Int };

                    conn.ShowDataInsertUsingStoredProc("detergents_Update", parmnames, parmvalues, paradbtype);
                    conn.CloseConnection();


                    conn.OpenConection();
                    dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("detergents_Select");
                    conn.CloseConnection();

                    clear.Clear(this);
                    MessageBox.Show("تم التعديل");
                }
                else MessageBox.Show("الرجاء إدخال كود الجهاز المراد تعديله ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.CloseConnection(); }

        }

        private void det_id_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                int VisibleTime = 1000;  //in milliseconds
                ToolTip tt = new ToolTip();

                tt.Show(" الرجاء ادخال حروف", this, ((Control)sender).Location.X, ((Control)sender).Location.Y, VisibleTime);
            }  
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            this.det_id.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.detName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.quantity.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.price.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
      

        private void detName_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
        }

        private void quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.Float(sender, e, this);
        }

        private void price_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.integer(sender, e, this);
        }
    }
   
    }

