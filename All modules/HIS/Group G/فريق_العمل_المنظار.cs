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
    public partial class فريق_العمل_المنظار : Form
    {
        SqlDataAdapter da1;
        SqlDataAdapter da2;
        SqlDataAdapter da3;
        SqlDataAdapter da4;
        SqlDataReader dr;

        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        
        TextBox t1;
        TextBox t2;
        Button b1;

        int rowIndex = 1;
        RowStyle temp;
        RowStyle temp1;

        public static string selected { get; set; }

        List<string> l1 = new List<string>();
        List<string> l2 = new List<string>();
        List<string> l3 = new List<string>();

        public فريق_العمل_المنظار()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem!=null)
                selected = listBox1.SelectedItem.ToString();            
            محرك_بحث_فريق_العمل_الطبى_للمنظار f7 = new محرك_بحث_فريق_العمل_الطبى_للمنظار();
            if (f7.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = محرك_بحث_فريق_العمل_الطبى_للمنظار.Do_id;
                textBox2.Text = محرك_بحث_فريق_العمل_الطبى_للمنظار.Name1;
            }
        }


        //////////////////////////////add////////////////////////////////
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (selected == "تخدير")
            {
                if (tableLayoutPanel1.RowCount > l1.Count)
                {
                    l1.Add(t1.Text);
                }
            }
            if (selected == "جراح مساعد")
            {
                if (tableLayoutPanel1.RowCount > l2.Count)
                {
                    l2.Add(t1.Text);
                }
            }
            if (selected == "تمريض")
            {
                if (tableLayoutPanel1.RowCount > l3.Count)
                {
                    l3.Add(t1.Text);
                }
            }
            
            
            t1 = new TextBox();
            t2 = new TextBox();
            b1 = new Button();
            b1.Click += b1_Click;

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
            this.tableLayoutPanel1.Controls.Add(t1, 2, rowIndex);
            this.tableLayoutPanel1.Controls.Add(b1, 1, rowIndex);
            this.tableLayoutPanel1.Controls.Add(t2, 0, rowIndex);
            rowIndex++;
        }

        private void b1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
                selected = listBox1.SelectedItem.ToString(); 
            محرك_بحث_فريق_العمل_الطبى_للمنظار f7 = new محرك_بحث_فريق_العمل_الطبى_للمنظار();
            if (f7.ShowDialog() == DialogResult.OK)
            {
                t1.Text = محرك_بحث_فريق_العمل_الطبى_للمنظار.Do_id;
                t2.Text = محرك_بحث_فريق_العمل_الطبى_للمنظار.Name1;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = listBox1.SelectedItem.ToString();
            if (selected == "تخدير")
            {
                if (tableLayoutPanel1.RowCount > 1)
                {
                    for (int j = tableLayoutPanel1.RowCount - 1; j > 0; j--)
                    {
                        tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(0, j));
                        tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(1, j));
                        tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(2, j));
                        tableLayoutPanel1.RowStyles.RemoveAt(j);
                        tableLayoutPanel1.RowCount--;
                    }
                }
                con1.OpenConection();
                //create procedure select_docs(@id int,@type nvarchar(50))
                //as

                //select d.Do_id, d.name from doctor_operation o,doctors d where o.id_op=@id and o.Do_id=d.Do_id and jop=@type;
                //cmd = new SqlCommand("select_docs", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@id", Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid));
                //cmd.Parameters.AddWithValue("@type", "Anesthesia");
                types = new SqlDbType[] { SqlDbType.Int, SqlDbType.NVarChar };
                name_input = new string[] { "@id", "@type" };
                values = new string[] { "Anesthesia", الصفحه_الرئيسيه_للمنظار.opid };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("select_docs", name_input, values, types);
               
                
                
                DataTable dt1 = new DataTable();
                dt1.Load(dr);
                    int i;
                    for (i = 0; i < dt1.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            textBox1.Text = dt1.Rows[0][0].ToString();
                            textBox2.Text = dt1.Rows[0][1].ToString();
                            l1.Add(textBox1.Text);
                        }
                        else
                        {
                            t1 = new TextBox();
                            t2 = new TextBox();
                            b1 = new Button();
                            b1.Click += b1_Click;

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
                            this.tableLayoutPanel1.Controls.Add(t1, 2, i);
                            this.tableLayoutPanel1.Controls.Add(b1, 1, i);
                            this.tableLayoutPanel1.Controls.Add(t2, 0, i);
                            t1.Text = dt1.Rows[i][0].ToString();
                            t2.Text = dt1.Rows[i][1].ToString();
                            l1.Add(t1.Text);
                        }
                    }
                    rowIndex = i;
                    dr.Close();
                con1.CloseConnection();
            }
            if (selected == "جراح مساعد")
            {
                if (tableLayoutPanel1.RowCount > 1)
                {
                    for (int j = tableLayoutPanel1.RowCount - 1; j > 0; j--)
                    {
                        tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(0, j));
                        tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(1, j));
                        tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(2, j));
                        tableLayoutPanel1.RowStyles.RemoveAt(j);
                        tableLayoutPanel1.RowCount--;
                    }
                }
                con1.OpenConection();
                //create procedure select_docs(@id int,@type nvarchar(50))
                //as

                //select d.Do_id, d.name from doctor_operation o,doctors d where o.id_op=@id and o.Do_id=d.Do_id and jop=@type;

                //cmd = new SqlCommand("select_docs", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@id", Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid));
                //cmd.Parameters.AddWithValue("@type", "surgeon");
                types = new SqlDbType[] { SqlDbType.Int, SqlDbType.NVarChar };
                name_input = new string[] { "@id", "@type" };
                values = new string[] { الصفحه_الرئيسيه_للمنظار.opid, "surgeon" };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("select_docs", name_input, values, types);
                DataTable dt2 = new DataTable();
                dt2.Load(dr);
               
                
                    int i;
                    for (i = 1; i < dt2.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            textBox1.Text = dt2.Rows[1][0].ToString();
                            textBox2.Text = dt2.Rows[1][1].ToString();
                            l2.Add(textBox1.Text);
                        }
                        else
                        {
                            t1 = new TextBox();
                            t2 = new TextBox();
                            b1 = new Button();
                            b1.Click += b1_Click;

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
                            this.tableLayoutPanel1.Controls.Add(t1, 2, i-1);
                            this.tableLayoutPanel1.Controls.Add(b1, 1, i-1);
                            this.tableLayoutPanel1.Controls.Add(t2, 0, i-1);
                            t1.Text = dt2.Rows[i][0].ToString();
                            t2.Text = dt2.Rows[i][1].ToString();
                            l2.Add(t1.Text);
                        }
                    }
                    rowIndex = i-1;
                    dr.Close();
                con1.CloseConnection();
            }
            if (selected == "تمريض")
            {
                if (tableLayoutPanel1.RowCount > 1)
                {
                    for (int j = tableLayoutPanel1.RowCount - 1; j > 0; j--)
                    {
                        tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(0, j));
                        tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(1, j));
                        tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(2, j));
                        tableLayoutPanel1.RowStyles.RemoveAt(j);
                        tableLayoutPanel1.RowCount--;
                    }
                }
                con1.OpenConection();

            //                create procedure select_docs(@id int,@type nvarchar(50))
            //as

            //select d.Do_id, d.name from doctor_operation o,doctors d where o.id_op=@id and o.Do_id=d.Do_id and jop=@type;
                //cmd = new SqlCommand("select_docs", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@id", Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid));
                //cmd.Parameters.AddWithValue("@type", "Nursing");
                //da3= new SqlDataAdapter(cmd);
                //DataSet ds3 = new DataSet();
                //da3.Fill(ds3);
                types = new SqlDbType[] { SqlDbType.Int, SqlDbType.NVarChar };
                name_input = new string[] { "@id", "@type" };
                values = new string[] { الصفحه_الرئيسيه_للمنظار.opid, "Nursing"};
                dr = con1.ShowDataInGridViewUsingStoredProcDR("select_docs", name_input, values, types);
                DataTable dt3 = new DataTable();
                dt3.Load(dr);
               
                    int i;
                    for (i = 0; i < dt3.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            textBox1.Text = dt3.Rows[0][0].ToString();
                            textBox2.Text = dt3.Rows[0][1].ToString();
                            l3.Add(textBox1.Text);
                        }
                        else
                        {
                            t1 = new TextBox();
                            t2 = new TextBox();
                            b1 = new Button();
                            b1.Click += b1_Click;

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
                            this.tableLayoutPanel1.Controls.Add(t1, 2, i);
                            this.tableLayoutPanel1.Controls.Add(b1, 1, i);
                            this.tableLayoutPanel1.Controls.Add(t2, 0, i);
                            t1.Text = dt3.Rows[i][0].ToString();
                            t2.Text = dt3.Rows[i][1].ToString();
                            l3.Add(t1.Text);
                        }
                    }
                    rowIndex = i;
                    dr.Close();
                con1.CloseConnection();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            con1.OpenConection();

                //            create procedure select_detail(@id int)
                //as
                //select  bof ,gender ,last_visit_num from patient_endo where id = @id;
            //cmd = new SqlCommand("select_detail", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@id", الصفحه_الرئيسيه_للمنظار.pid);

            //da4 = new SqlDataAdapter(cmd);
            //    DataSet ds=new DataSet();
            //da4.Fill(ds); 

            types = new SqlDbType[] { SqlDbType.Int };
            name_input = new string[] { "@id" };
            values = new string[] {الصفحه_الرئيسيه_للمنظار.opid };
            dr = con1.ShowDataInGridViewUsingStoredProcDR("select_detail", name_input, values, types);
            DataTable dt3 = new DataTable();
            dt3.Load(dr);
            label8.Text = الصفحه_الرئيسيه_للمنظار.pid;
            label9.Text = الصفحه_الرئيسيه_للمنظار.pname;
            label10.Text = dt3.Rows[0][0].ToString();
            label11.Text = dt3.Rows[0][1].ToString();
            label12.Text = dt3.Rows[0][2].ToString();
            dr.Close();
            con1.CloseConnection();
        }

        //////////////////////////////remove////////////////////////////////
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tableLayoutPanel1.RowCount > 0)
            {
                if (tableLayoutPanel1.RowCount == 1)
                {
                    temp1 = tableLayoutPanel1.RowStyles[0];
                }
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(0, tableLayoutPanel1.RowCount - 1));
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(1, tableLayoutPanel1.RowCount - 1));
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(2, tableLayoutPanel1.RowCount - 1));
                tableLayoutPanel1.RowStyles.RemoveAt(tableLayoutPanel1.RowCount - 1);
                tableLayoutPanel1.RowCount--;
                rowIndex = tableLayoutPanel1.RowCount;
            }
            if (selected == "تخدير")
            { 
                l1.Remove(l1[l1.Count - 1]); 
            }
            if (selected == "جراح مساعد")
            {
                l2.Remove(l2[l2.Count - 1]);
            }
            if (selected == "تمريض")
            {
                l3.Remove(l3[l3.Count - 1]);
            }
            
        }


        //////////////////////////////save////////////////////////////////
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (selected == "تخدير")
            {
                if (tableLayoutPanel1.RowCount > l1.Count)
                {
                    if (tableLayoutPanel1.RowCount == 1)
                    {
                        l1.Add(textBox1.Text);
                    }
                    else
                    {
                        l1.Add(t1.Text);
                    }
                    
                }
                con1.OpenConection();

                //create procedure dele(@p_id int, @type nvarchar(30))
                //as
                //delete from doctor_operation where id_op=@p_id and Do_id in (select d.Do_id from doctors d,doctor_operation o where d.Do_id = o.Do_id and jop=@type)

                //cmd = new SqlCommand("dele", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@p_id", Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid));
                //cmd.Parameters.AddWithValue("@type", "Anesthesia");
                //cmd.ExecuteNonQuery();
                types = new SqlDbType[] { SqlDbType.Int, SqlDbType.NVarChar };
                name_input = new string[] { "@p_id", "@type" };
                values = new string[] { الصفحه_الرئيسيه_للمنظار.opid, "Anesthesia" };
                con1.ExecuteNonQueryProcedure("dele", name_input, values, types);
                for (int i = 0; i < l1.Count; i++)
                {
                    
            // create procedure ins(@id1 int,@id2 int)
            //as
            //insert into doctor_operation values(@id1,@id2)
                    //cmd = new SqlCommand("ins", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@id1", Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid));
                    //cmd.Parameters.AddWithValue("@id2", Convert.ToInt32(l1[i]));
                    //cmd.ExecuteNonQuery();
                    types = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int };
                    name_input = new string[] { "@id1", "@id2" };
                    values = new string[] { الصفحه_الرئيسيه_للمنظار.opid, l1[i] };
                    con1.ExecuteNonQueryProcedure("ins", name_input, values, types);
                }
                con1.CloseConnection();
                MessageBox.Show("تم الحفظ");
            }

            if (selected == "جراح مساعد")
            {
                if (tableLayoutPanel1.RowCount > l2.Count)
                {
                    if (tableLayoutPanel1.RowCount == 1)
                    {
                        l2.Add(textBox1.Text);
                    }
                    else
                    {
                        l2.Add(t1.Text);
                    }
                }
                con1.OpenConection();
                /*
                 * 
                        create procedure  procedurselect_doc_details(@id int)
                        as
                        select 
                        o.Do_id from doctors d,doctor_operation o where o.id_op=@id and d.Do_id =o.Do_id and jop='surgeon' ORDER BY o.id_op  DESC ;



                 * 
                 */
                //cmd = new SqlCommand("procedurselect_doc_details",con);
                //cmd.Parameters.AddWithValue("@id", Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid));
                //da2 = new SqlDataAdapter(cmd);
                types = new SqlDbType[] { SqlDbType.Int };
                name_input = new string[] { "@id" };
                values = new string[] { الصفحه_الرئيسيه_للمنظار.opid };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("procedurselect_doc_details", name_input, values, types);

                        DataTable dt2 = new DataTable();
                        dt2.Load(dr);

               
                //cmd = new SqlCommand("dele", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@p_id", Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid));
                //cmd.Parameters.AddWithValue("@type", "surgeon");
                //cmd.ExecuteNonQuery();
                        types = new SqlDbType[] { SqlDbType.Int, SqlDbType.NVarChar };
                        name_input = new string[] { "@p_id", "@type" };
                        values = new string[] { الصفحه_الرئيسيه_للمنظار.opid, "surgeon" };
                        con1.ExecuteNonQueryProcedure("dele", name_input, values, types);
                
                for (int i = 0; i < l2.Count; i ++)
                {

                    //cmd = new SqlCommand("ins", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@id1", Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid));
                    //cmd.Parameters.AddWithValue("@id2", Convert.ToInt32(l2[i]));
                    //cmd.ExecuteNonQuery();
                    types = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int };
                    name_input = new string[] { "@id1", "@id2" };
                    values = new string[] { الصفحه_الرئيسيه_للمنظار.opid, l2[i] };
                    con1.ExecuteNonQueryProcedure("ins", name_input, values, types);
                }
                dr.Close();
                con1.CloseConnection();
                MessageBox.Show("تم الحفظ");
            }
            if (selected == "تمريض")
            {
                if (tableLayoutPanel1.RowCount > l3.Count)
                {
                    if (tableLayoutPanel1.RowCount == 1)
                    {
                        l3.Add(textBox1.Text);
                    }
                    else
                    {
                        l3.Add(t1.Text);
                    }
                }
                con1.OpenConection();
                //cmd.Connection = con;
                //cmd = new SqlCommand("dele", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@p_id", Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid));
                //cmd.Parameters.AddWithValue("@type", "Nursing");
                //cmd.ExecuteNonQuery();
                types = new SqlDbType[] { SqlDbType.Int, SqlDbType.NVarChar };
                name_input = new string[] { "@p_id", "@type" };
                values = new string[] { الصفحه_الرئيسيه_للمنظار.opid, "Nursing" };
                con1.ExecuteNonQueryProcedure("dele", name_input, values, types);
                for (int i = 0; i < l3.Count; i++)
                {
                    //cmd = new SqlCommand("ins", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@id1", Convert.ToInt32(الصفحه_الرئيسيه_للمنظار.opid));
                    //cmd.Parameters.AddWithValue("@id2", Convert.ToInt32(l3[i]));
                    //cmd.ExecuteNonQuery();
                    types = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int };
                    name_input = new string[] { "@id1", "@id2" };
                    values = new string[] { الصفحه_الرئيسيه_للمنظار.opid, l3[i] };
                    con1.ExecuteNonQueryProcedure("ins", name_input, values, types);
                    
                }
                dr.Close();
                con1.CloseConnection();
                MessageBox.Show("تم الحفظ");
            }
        }
    }
}
