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
    public partial class عطلات_الاطباء : Form
    {
        

        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        TextBox t1;
        TextBox t2;
        Button b1;
        int rowIndex1 = 1;
        int rowIndex2 = 1;
        DateTimePicker dtp1;
        DateTimePicker dtp2;
        RowStyle temp_t1;
        RowStyle temp1_t1;
        RowStyle temp_t2;
        RowStyle temp1_t2;

        List<string> l1 = new List<string>();
        List<string> l2 = new List<string>();

        public عطلات_الاطباء()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            محرك_بحث_فريق_العمل_الطبى f2 = new محرك_بحث_فريق_العمل_الطبى();
            if (f2.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = محرك_بحث_فريق_العمل_الطبى.Code;
                textBox4.Text = محرك_بحث_فريق_العمل_الطبى.Name1;
            }

        }
        private void b1_Click(object sender, EventArgs e)
        {
            محرك_بحث_فريق_العمل_الطبى f2 = new محرك_بحث_فريق_العمل_الطبى();
            if (f2.ShowDialog() == DialogResult.OK)
            {
                t1.Text = محرك_بحث_فريق_العمل_الطبى.Code;
                t2.Text = محرك_بحث_فريق_العمل_الطبى.Name1;
            }
        }

        /////////////////////add in table1////////////////////
        private void button2_Click(object sender, EventArgs e)
        {
                t1 = new TextBox();
                t2 = new TextBox();
                b1 = new Button();
                b1.Click += b1_Click;

                t1.Size = textBox3.Size;
                t1.Location = textBox3.Location;
                t1.Font = textBox3.Font;

                t2.Size = textBox4.Size;
                t2.Location = textBox4.Location;
                t2.Font = textBox4.Font;

                b1.Size = button4.Size;
                b1.Location = button4.Location;
                b1.BackgroundImage = button4.BackgroundImage;
                b1.Margin = button4.Margin;

                this.tableLayoutPanel1.AutoSize = true;
                if (tableLayoutPanel1.RowCount > 0)
                {
                    temp_t1 = tableLayoutPanel1.RowStyles[0];
                }
                else
                {
                    temp_t1 = temp1_t1;
                }
                this.tableLayoutPanel1.RowStyles.Add(new RowStyle(temp_t1.SizeType, temp_t1.Height));
                tableLayoutPanel1.RowCount++;
                this.tableLayoutPanel1.Controls.Add(t1, 2, rowIndex1);
                this.tableLayoutPanel1.Controls.Add(b1, 1, rowIndex1);
                this.tableLayoutPanel1.Controls.Add(t2, 0, rowIndex1);
                rowIndex1++;
                while (tableLayoutPanel2.RowCount > 1)
                {
                    tableLayoutPanel2.Controls.Remove(tableLayoutPanel2.GetControlFromPosition(0, tableLayoutPanel2.RowCount - 1));
                    tableLayoutPanel2.Controls.Remove(tableLayoutPanel2.GetControlFromPosition(1, tableLayoutPanel2.RowCount - 1));
                    tableLayoutPanel2.RowStyles.RemoveAt(tableLayoutPanel2.RowCount - 1);
                    tableLayoutPanel2.RowCount--;
                }
                if (tableLayoutPanel2.RowCount == 1)
                {
                    rowIndex2 = 1;
                }

        }

        ///////////////////remove from table1/////////////////
        private void button3_Click(object sender, EventArgs e)
        {
            if(tableLayoutPanel1.RowCount > 0)
            {
                if (tableLayoutPanel1.RowCount == 1)
                {
                    temp1_t1 = tableLayoutPanel1.RowStyles[0];
                    rowIndex1 = 0;
                }
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(0, tableLayoutPanel1.RowCount - 1));
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(1, tableLayoutPanel1.RowCount - 1));
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(2, tableLayoutPanel1.RowCount - 1));
                tableLayoutPanel1.RowStyles.RemoveAt(tableLayoutPanel1.RowCount - 1);
                tableLayoutPanel1.RowCount--;
            }
        }

        /////////////////////add in table2////////////////////
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tableLayoutPanel2.RowCount == 1)
            {
                l2.Add(dateTimePicker1.Value.ToString());
                l2.Add(dateTimePicker2.Value.ToString());
            }
            else
            {
                l2.Add(dtp1.Value.ToString());
                l2.Add(dtp2.Value.ToString());
            }
            dtp1 = new DateTimePicker();
            dtp2 = new DateTimePicker();

            dtp1.Size = dateTimePicker1.Size;
            dtp1.Location = dateTimePicker1.Location;
            dtp1.Format = dateTimePicker1.Format;

            dtp2.Size = dateTimePicker2.Size;
            dtp2.Location = dateTimePicker2.Location;
            dtp2.Format = dateTimePicker2.Format;

            this.tableLayoutPanel2.AutoSize = true;
            if (tableLayoutPanel2.RowCount > 0)
            {
                temp_t2 = tableLayoutPanel2.RowStyles[0];
            }
            else
            {
                temp_t2 = temp1_t2;
            }
            this.tableLayoutPanel2.RowStyles.Add(new RowStyle(temp_t2.SizeType, temp_t2.Height));
            tableLayoutPanel2.RowCount++;
            this.tableLayoutPanel2.Controls.Add(dtp1, 1, rowIndex2);
            this.tableLayoutPanel2.Controls.Add(dtp2, 0, rowIndex2);
            rowIndex2++;
        }

        /////////////////////remove from table2////////////////////
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            if (tableLayoutPanel2.RowCount > 0)
            {
                if (tableLayoutPanel2.RowCount == 1)
                {
                    temp1_t2 = tableLayoutPanel2.RowStyles[0];
                    rowIndex2 = 0;
                }
                tableLayoutPanel2.Controls.Remove(tableLayoutPanel2.GetControlFromPosition(0, tableLayoutPanel2.RowCount - 1));
                tableLayoutPanel2.Controls.Remove(tableLayoutPanel2.GetControlFromPosition(1, tableLayoutPanel2.RowCount - 1));
                tableLayoutPanel2.RowStyles.RemoveAt(tableLayoutPanel2.RowCount - 1);
                tableLayoutPanel2.RowCount--;               
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //////////////////////////////////save/////////////////////////////
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dateTimePicker2.Value.Date >= dateTimePicker1.Value.Date)
            {
                if (tableLayoutPanel1.RowCount == 1)
                {
                    l1.Add(textBox3.Text);
                }
                if (tableLayoutPanel2.RowCount == 1)
                {
                    l2.Add(dateTimePicker1.Value.ToString());
                    l2.Add(dateTimePicker2.Value.ToString());
                }
                if (tableLayoutPanel1.RowCount > 1)
                {
                    l1.Add(t1.Text);
                }
                if (tableLayoutPanel2.RowCount > 1)
                {
                    l2.Add(dtp1.Value.ToString());
                    l2.Add(dtp2.Value.ToString());
                }

                for (int i = 0; i < l1.Count; i++)
                {
                    /*
                     *  create procedure clinic_عطلات_الاطباء_doc_rest_insert
                        (@code int,@s_time datetime,@e_time datetime)
                         as
                         begin
                         insert into doc_rest values(@code,@s_time,@e_time)
                         end
                     */
                    for (int j = 0; j < l2.Count; j += 2)
                    {
                        //con.Open();
                        //cmd.Connection = con;
                        //cmd.CommandText = "clinic_عطلات_الاطباء_doc_rest_insert";
                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@code", l1[i]);
                        //cmd.Parameters.AddWithValue("@s_time", l2[j]);
                        //cmd.Parameters.AddWithValue("@e_time", l2[j+1]);
                        ////cmd.CommandText = "insert into doc_rest values('" + l1[i] + "','" + l2[j] + "','" + l2[j + 1] + "')";
                        //cmd.ExecuteNonQuery();
                        //con.Close();
                        con1.OpenConection();
                        types = new SqlDbType[] { SqlDbType.Int, SqlDbType.DateTime, SqlDbType.DateTime };
                        name_input = new string[] { "@code", "@s_time", "@e_time" };
                        values = new string[] { l1[i], l2[j], l2[j + 1] };
                        con1.ExecuteNonQueryProcedure("clinic_عطلات_الاطباء_doc_rest_insert", name_input, values, types);
                        con1.CloseConnection();

                    }

                }
                MessageBox.Show("تم الحفظ");
                l1.Clear();
                l2.Clear();
            }
            else
            {
                MessageBox.Show("من فضلك قم بتعدل التاريخ");
            }
        }

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
