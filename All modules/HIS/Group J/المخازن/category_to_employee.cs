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
    public partial class category_to_employee : Form
    {
        SqlConnection con = new SqlConnection(@"Server=DESKTOP-O2AL8TR\SQLEXPRESS;Database=HIS_GROUP_J; Integrated Security=true");
        public category_to_employee()
        {
            InitializeComponent();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("select amount from Inventory_categories where category_id='" + category_id.Text + "' ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                int x = Convert.ToInt32(dr[0]);
                dr.Close();
                if (x < Convert.ToInt32(leaving_amount.Text))
                {
                    MessageBox.Show("الكمية المنصرفة لهذا الصنف اكبر من الكمية الموجودة بالمخزن");
                }
                else
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd1 = new SqlCommand("insert into Inventory_inventoryOperation (operation_id,category_id,required_amount,leaving_amount,authorized_amount,cost,condition,date,to_,employee_id,type) values ('" + operation_id.Text + "','" + category_id.Text + "','" + required_amount.Text + "','" + leaving_amount.Text + "','" + authorized_amount.Text + "','" + cost.Text + "','" + condition.Text + "','" + date.Value.Date.ToString("yyyy-MM-dd") + "','employee '+'" + depart_id.Text + "','" + employee_id.Text + "','out_to_department')", con);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("leaving from inventory");
                    }
                    catch (Exception exe) { MessageBox.Show(exe.Message); }
                    finally { con.Close(); }
                    try
                    {

                        con.Open();
                        SqlCommand cmd2 = new SqlCommand("update Inventory_categories set amount =amount-'" + Convert.ToInt32(leaving_amount.Text) + "'  where category_id='" + category_id.Text + "' ", con);
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("update in category");
                    }
                    catch (Exception exe) { MessageBox.Show(exe.Message); }
                    finally { con.Close(); }
                }//end else
            }
            catch (Exception exe) { MessageBox.Show(exe.Message); }
            finally { con.Close(); }
        }

        private void category_to_employee_Load(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Inventory_inventoryOperation where type='out_to_department' ", con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView2.DataSource = dt;
                dr.Close();
                con.Close();
            }
            catch (Exception exe) { MessageBox.Show(exe.Message); }
            finally { con.Close(); }
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Inventory_categories";
                cmd.Connection = con;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    category_id.Items.Add(dr[0].ToString());
                }

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            finally
            {
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM employee";
                cmd.Connection = con;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    employee_id.Items.Add(dr[0].ToString());
                }

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            finally
            {
                con.Close();
            }
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Inventory_inventory";
                cmd.Connection = con;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    inventory_id.Items.Add(dr[0].ToString());
                }

            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
