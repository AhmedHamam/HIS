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
    public partial class غرف_العيادات_الخارجية : Form
    {
        
        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        

        TextBox t1;
        TextBox t2;
        TextBox t3;
        TextBox t4;
        Button b1;
        CheckBox check;
        int rowIndex = 1;
        RowStyle temp;
        RowStyle temp1;
        List<string> l1 = new List<string>();
        public غرف_العيادات_الخارجية()
        {
            InitializeComponent();
            textBox1.Text = "1";
        }
        //////////////////////////////add///////////////////////////////////
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tableLayoutPanel1.RowCount == 1)
            {
                l1.Add(textBox1.Text);
                l1.Add(textBox2.Text);
                l1.Add(textBox3.Text);
                l1.Add(textBox4.Text);
                l1.Add(checkBox1.Checked.ToString());
            }
            if (tableLayoutPanel1.RowCount > 1)
            {
                l1.Add(t1.Text);
                l1.Add(t2.Text);
                l1.Add(t3.Text);
                l1.Add(t4.Text);
                l1.Add(check.Checked.ToString());
            }

            t1 = new TextBox();
            t2 = new TextBox();
            t3 = new TextBox();
            t4 = new TextBox();
            b1 = new Button();
            check = new CheckBox();
            b1.Click += b1_Click;

            t1.Text = (rowIndex + 1).ToString();

            t1.Size = textBox1.Size;
            t1.Location = textBox1.Location;
            t1.Font = textBox1.Font;

            t2.Size = textBox2.Size;
            t2.Location = textBox2.Location;
            t2.Font = textBox2.Font;

            t3.Size = textBox3.Size;
            t3.Location = textBox3.Location;
            t3.Font = textBox3.Font;

            t4.Size = textBox4.Size;
            t4.Location = textBox4.Location;
            t4.Font = textBox4.Font;

            b1.Size = button1.Size;
            b1.Location = button1.Location;
            b1.BackgroundImage = button1.BackgroundImage;
            b1.Margin = button1.Margin;

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
            this.tableLayoutPanel1.Controls.Add(t1, 5, rowIndex);
            this.tableLayoutPanel1.Controls.Add(t2, 4, rowIndex);
            this.tableLayoutPanel1.Controls.Add(t3, 3, rowIndex);
            this.tableLayoutPanel1.Controls.Add(b1, 2, rowIndex);
            this.tableLayoutPanel1.Controls.Add(t4, 1, rowIndex);
            this.tableLayoutPanel1.Controls.Add(check, 0, rowIndex);
            rowIndex++;
        }

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
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(5, tableLayoutPanel1.RowCount - 1));
                tableLayoutPanel1.RowStyles.RemoveAt(tableLayoutPanel1.RowCount - 1);
                tableLayoutPanel1.RowCount--;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            التخصصات_الطبية_للغرف f2 = new التخصصات_الطبية_للغرف();
            if (f2.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = التخصصات_الطبية_للغرف.Arab;
            }
        }

        private void b1_Click(object sender, EventArgs e)
        {
            التخصصات_الطبية_للغرف f2 = new التخصصات_الطبية_للغرف();
            if (f2.ShowDialog() == DialogResult.OK)
            {
                t4.Text = التخصصات_الطبية_للغرف.Arab;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //////////////////////////////////save/////////////////////////////
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tableLayoutPanel1.RowCount > 1)
            {
                l1.Add(t1.Text);
                l1.Add(t2.Text);
                l1.Add(t3.Text);
                l1.Add(t4.Text);
                l1.Add(check.Checked.ToString());
            }
            if (tableLayoutPanel1.RowCount == 1)
            {
                l1.Add(textBox1.Text);
                l1.Add(textBox2.Text);
                l1.Add(textBox3.Text);
                l1.Add(textBox4.Text);
                l1.Add(checkBox1.Checked.ToString());
            }
            for (int i = 0; i < l1.Count; i += 5)
            {
                //texts[i] = l1[i];
                
                /*create procedure clinic_غرف_العيادات_الخارجية_room_insert(@r int,@arabic nvarchar(100),@english nvarchar(100),@sep nvarchar(100),@main nvarchar(100))
                    as
                    begin
                    insert into room(r_id,arabic_des,english_des,specialty,maintenance) values(@r,@arabic,@english,@sep,@main)
                    end
                 */

                //con.Open();
                //cmd.Connection = con;
                ////cmd.CommandText = "insert into room(r_id,arabic_des,english_des,specialty,maintenance) values('" + l1[i] + "','" + l1[i + 1] + "','" + l1[i + 2] + "','" + l1[i + 3] + "','" + l1[i + 4] + "')";
                //cmd.CommandText = "clinic_غرف_العيادات_الخارجية_room_insert";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@r", SqlDbType.Int).Value = l1[i];
                //cmd.Parameters.Add("@arabic", SqlDbType.NVarChar).Value = l1[i + 1];
                //cmd.Parameters.Add("@english", SqlDbType.NVarChar).Value = l1[i + 2];
                //cmd.Parameters.Add("@sep", SqlDbType.NVarChar).Value = l1[i + 3];
                //cmd.Parameters.Add("@main", SqlDbType.NVarChar).Value = l1[i + 4];
                //cmd.ExecuteNonQuery();
                //con.Close();
                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.Int, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
                name_input = new string[] { "@r", "@arabic", "@english", "@sep", "@main" };
                values = new string[] { l1[i], l1[i + 1], l1[i + 2], l1[i + 3], l1[i + 4] };
                con1.ExecuteNonQueryProcedure("clinic_غرف_العيادات_الخارجية_room_insert", name_input, values, types);
                con1.CloseConnection();
                
            }
            //con.OpenConection();
            //con.ShowDataInGridViewUsingStoredProc("clinic_غرف_العيادات_الخارجية_room_insert", inputs, texts, types);
            MessageBox.Show("تم الحفظ");
            l1.Clear();
        }

        private void check_number_code(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الارقام فقط ");

            }
        }

        private void check_string_en_name(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط ");

            }
        }

        private void check_string_sep(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط ");

            }
        }

        private void check_string_ar(object sender, KeyPressEventArgs e)
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
