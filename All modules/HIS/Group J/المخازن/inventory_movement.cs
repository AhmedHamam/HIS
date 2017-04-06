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
    public partial class inventory_movement : Form
    {
        SqlConnection con = new SqlConnection(@"Server=DESKTOP-O2AL8TR\SQLEXPRESS;Database=HIS_GROUP_J; Integrated Security=true");

        public inventory_movement()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Inventory_inventoryOperation", con);
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch (Exception exe) { MessageBox.Show(exe.Message); }
            finally { con.Close(); }
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

                    inventory_name.Items.Add(dr[2].ToString());
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
                cmd.CommandText = "SELECT * FROM Inventory_inventoryOperation";
                cmd.Connection = con;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    operation_id.Items.Add(dr[0].ToString());
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
                cmd.CommandText = "SELECT * FROM Inventory_inventoryOperation";
                cmd.Connection = con;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    operation_id.Items.Add(dr[2].ToString());
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
        private void button2_Click(object sender, EventArgs e)
        {
            add_inventory f34 = new add_inventory();
            f34.Show();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Inventory_inventoryOperation where operation_id='" + operation_id.Text + "' or type='" + type.Text + "' or date='" + date.Value.Date.ToString("yyyy-MM-dd") + "' or employee_id='"+employee_id.Text+"' ";
                cmd.Connection = con;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    operation_id.Items.Add(dr[0].ToString());
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
    }
}
