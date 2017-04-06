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
    public partial class takhen : Form
    {
        SqlConnection con = new SqlConnection(@"Server=DESKTOP-O2AL8TR\SQLEXPRESS;Database=HIS_GROUP_J; Integrated Security=true");
        public takhen()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Inventory_inventoryOperation where type='takhen' ", con);
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
                cmd.CommandText = "SELECT * FROM Inventory_bill";
                cmd.Connection = con;
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    bill_id.Items.Add(dr[0].ToString());
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
            con.Close();
                                                    /*create table Inventory_inventoryOperation(
                                        operation_id int primary key,
                                        condition text,
                                        type varchar(250),
                                        reason varchar(250),
                                        amount int,
                                        date date,
                                        cost float,
                                        employee_id int foreign key references employee(employee_id) on update cascade on delete cascade,
                                        category_id int foreign key references Inventory_categories(category_id) on update cascade on delete cascade,
                                        bill_id int foreign key references Inventory_bill(bill_id) 
                                        )
             */

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Inventory_inventoryOperation (operation_id,category_id,reason,date,amount,bill_id,employee_id,type) values ('" + operation_id.Text + "','" + category_id.Text + "','" + reason.Text + "','" + date.Value.Date.ToString("yyyy-MM-dd") + "','" + amountt.Text + "','" + bill_id.Text + "','" + employee_id.Text + "','takhen')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("takhen from to inventory");
            }
            catch (Exception exe) { MessageBox.Show(exe.Message); }
            finally { con.Close(); }
            try
            {
                /*create table Inventory_categories(
category_id  int  primary key,
categoryName varchar(50) ,
cost_price varchar(50),
categoryState varchar(50),
description text,
amount int,
)*/
                con.Open();
                SqlCommand cmd = new SqlCommand("update Inventory_categories set amount =amount-'"+Convert.ToInt32(amountt.Text)+"'  where category_id='" + category_id.Text + "' ", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("update in category");
            }
            catch (Exception exe) { MessageBox.Show(exe.Message); }
            finally { con.Close(); }

            
        }
        }
    }

