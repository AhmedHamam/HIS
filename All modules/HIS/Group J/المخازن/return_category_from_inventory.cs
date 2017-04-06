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
    public partial class return_category_from_inventory : Form
    {
        SqlConnection con = new SqlConnection(@"Server=DESKTOP-O2AL8TR\SQLEXPRESS;Database=HIS_GROUP_J; Integrated Security=true");
        public return_category_from_inventory()
        {
            InitializeComponent();
        }

        private void return_category_from_inventory_Load(object sender, EventArgs e)
        {
 
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Inventory_inventoryOperation where from_='department%' ", con);
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

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Inventory_inventoryOperation (operation_id,category_id,amount,cost,condition,date,from_,employee_id,type) values ('" + operation_id.Text + "','" + category_id.Text + "','" + amount.Text + "','" + cost.Text + "','" + condition.Text + "','" + date.Value.Date.ToString("yyyy-MM-dd") + "','employee '+'" + depart_id.Text + "','" + employee_id.Text + "','return_from_employee')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("erturn to inventory");
        }
        catch (Exception exe) { MessageBox.Show(exe.Message); }
        finally { con.Close(); }
        try
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("update Inventory_categories set amount =amount+'" + Convert.ToInt32(amount.Text) + "'  where category_id='" + category_id.Text + "' ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("update in category");
        }
        catch (Exception exe) { MessageBox.Show(exe.Message); }
        finally { con.Close(); }
        }
        }
    }

