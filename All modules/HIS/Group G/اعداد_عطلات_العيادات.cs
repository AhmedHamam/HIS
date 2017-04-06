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
    public partial class اعداد_عطلات_العيادات : Form
    {

        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        TextBox t1;
        TextBox t2;
        Button b1;
        DateTimePicker dtp1;
        DateTimePicker dtp2;

        int rowIndex = 1;
        RowStyle temp;
        RowStyle temp1;

        List<string> l1 = new List<string>();

        public اعداد_عطلات_العيادات()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            العياده_المضافه_للعطلات f2 = new العياده_المضافه_للعطلات();
            if (f2.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = العياده_المضافه_للعطلات.Code;
                textBox2.Text = العياده_المضافه_للعطلات.Arab;
            }
        }

        //////////////////////////////add///////////////////////////////////
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tableLayoutPanel1.RowCount == 1)
            {
                l1.Add(textBox1.Text);
                l1.Add(dateTimePicker1.Value.ToString());
                l1.Add(dateTimePicker2.Value.ToString());
            }
            if (tableLayoutPanel1.RowCount > 1)
            {
                l1.Add(t1.Text);
                l1.Add(dtp1.Value.ToString());
                l1.Add(dtp2.Value.ToString());
            }

            t1 = new TextBox();
            t2 = new TextBox();
            b1 = new Button();
            b1.Click += b1_Click;
            dtp1 = new DateTimePicker();
            dtp2 = new DateTimePicker();

            t1.Size = textBox1.Size;
            t1.Location = textBox1.Location;
            t1.Font = textBox1.Font;

            t2.Size = textBox2.Size;
            t2.Location = textBox2.Location;
            t2.Font = textBox2.Font;

            b1.Size = button1.Size;
            b1.Location = button1.Location;
            b1.BackgroundImage = button1.BackgroundImage;
            b1.Margin = button1.Margin;

            dtp1.Size = dateTimePicker1.Size;
            dtp1.Location = dateTimePicker1.Location;
            dtp1.Format = dateTimePicker1.Format;
            dtp1.Font = dateTimePicker1.Font;

            dtp2.Size = dateTimePicker2.Size;
            dtp2.Location = dateTimePicker2.Location;
            dtp2.Format = dateTimePicker2.Format;
            dtp2.Font = dateTimePicker2.Font;

            this.tableLayoutPanel1.AutoSize = true;
            if (tableLayoutPanel1.RowCount > 0)
            {
                temp = tableLayoutPanel1.RowStyles[0];
            }
            else
            {
                temp = temp1;
            }
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
            tableLayoutPanel1.RowCount++;
            this.tableLayoutPanel1.Controls.Add(t1, 4, rowIndex);
            this.tableLayoutPanel1.Controls.Add(b1, 3, rowIndex);
            this.tableLayoutPanel1.Controls.Add(t2, 2, rowIndex);
            this.tableLayoutPanel1.Controls.Add(dtp1, 1, rowIndex);
            this.tableLayoutPanel1.Controls.Add(dtp2, 0, rowIndex);
            rowIndex++;
        }
        //////////////////////////////remove////////////////////////////////
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tableLayoutPanel1.RowCount > 0)
            {
                if (tableLayoutPanel1.RowCount == 1)
                {
                    temp1 = tableLayoutPanel1.RowStyles[0];
                    rowIndex = 0;
                }
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(0, tableLayoutPanel1.RowCount - 1));
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(1, tableLayoutPanel1.RowCount - 1));
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(2, tableLayoutPanel1.RowCount - 1));
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(3, tableLayoutPanel1.RowCount - 1));
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(4, tableLayoutPanel1.RowCount - 1));
                tableLayoutPanel1.RowStyles.RemoveAt(tableLayoutPanel1.RowCount - 1);
                tableLayoutPanel1.RowCount--;
            }

        }
        private void b1_Click(object sender, EventArgs e)
        {
            العياده_المضافه_للعطلات f2 = new العياده_المضافه_للعطلات();
            if (f2.ShowDialog() == DialogResult.OK)
            {
                t1.Text = العياده_المضافه_للعطلات.Code;
                t2.Text = العياده_المضافه_للعطلات.Arab;
            }
        }

        //////////////////////////////////save/////////////////////////////
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dateTimePicker2.Value.Date >= dateTimePicker1.Value.Date)
            {
                if (tableLayoutPanel1.RowCount > 1)
                {
                    l1.Add(t1.Text);
                    l1.Add(dtp1.Value.ToString());
                    l1.Add(dtp2.Value.ToString());
                }

                if (l1.Count == 0)
                {
                    l1.Add(textBox1.Text);
                    l1.Add(dateTimePicker1.Value.ToString());
                    l1.Add(dateTimePicker2.Value.ToString());
                }



                for (int i = 0; i < l1.Count; i += 3)
                {
                    /*
                     * 
                        create procedure clinic_اعداد_عطلات_العيادات_clinic_rest_insert(@c nvarchar(50),@s_time nvarchar(100),@e_time nvarchar(100))
                        as
                        begin
                        insert into clinic_rest values(@c,@s_time,@e_time)
                        end

                     * */
                    //con.Open();
                    //cmd.Connection = con;
                    ////cmd.CommandText = "insert into clinic_rest values('" + l1[i] + "','" + l1[i + 1] + "','" + l1[i + 2] + "')";
                    //cmd.CommandText = "clinic_اعداد_عطلات_العيادات_clinic_rest_insert";
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@c",l1[i]);
                    //cmd.Parameters.AddWithValue("@s_time", l1[i + 1]);
                    //cmd.Parameters.AddWithValue("e_time",l1[i + 2]);
                    //cmd.ExecuteNonQuery();
                    //con.Close();

                    con1.OpenConection();
                    types=new SqlDbType[]{SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.NVarChar};
                    name_input=new string[]{"@c","@s_time","@e_time"};
                    values=new string[]{l1[i],l1[i + 1],l1[i + 2]};
                    con1.ExecuteNonQueryProcedure("clinic_اعداد_عطلات_العيادات_clinic_rest_insert", name_input, values, types);
                    con1.CloseConnection();
                }
     
                MessageBox.Show("تم الحفظ");
                l1.Clear();
            }
        
            else
            {
                MessageBox.Show("من فضلك قم بتعديل التاريخ");
            }
        }

        //Validation
        private void check_number_code(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الارقام فقط ");

            }
        }

        private void check_string_name(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط ");

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        

       

        

        

       

        
    }
}
