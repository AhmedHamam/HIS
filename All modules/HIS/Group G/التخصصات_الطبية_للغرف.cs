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
    public partial class التخصصات_الطبية_للغرف : Form
    {
        //SqlDataReader dr;
        //SqlCommand cmd = new SqlCommand();
        //SqlConnection con = new SqlConnection(@"server=SANDRA-PC\SQLEXPRESS;database=project_db; Integrated Security=true;");
        //DataTable dt = new DataTable();
        //DataSet ds = new DataSet();

        Connection con1=new Connection();
        int count = 0;
      
        string[] name_input  ;
        string[] values ;
        SqlDbType[] types;
        

        Label l1;
        Label l2;
        Label l3;

        RowStyle temp;

        public static string Arab { get; set; }
        public التخصصات_الطبية_للغرف()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*da = new MySqlDataAdapter("select code from speciality;select arabic_des from speciality;select latini_des from speciality;", con);
            da.Fill(ds);
            dt = ds.Tables[0];
            label12.Text = dt.Rows[0][0].ToString();
            dt = ds.Tables[1];
            label13.Text = dt.Rows[0][0].ToString();
            dt = ds.Tables[2];
            label14.Text = dt.Rows[0][0].ToString();

            for (int i = 1; i < ds.Tables[0].Rows.Count; i++)
            {
                l1 = new Label();
                l2 = new Label();
                l2.Click += l2_Click;
                l3 = new Label();

                l1.Size = label12.Size;
                l1.Location = label12.Location;
                l1.Padding = label12.Padding;
                l1.Anchor = label12.Anchor;
                l1.Font = label12.Font;
                l1.TextAlign = label12.TextAlign;

                l2.Size = label13.Size;
                l2.Location = label13.Location;
                l2.Padding = label13.Padding;
                l2.Anchor = label13.Anchor;
                l2.Font = label13.Font;
                l2.TextAlign = label13.TextAlign;

                l3.Size = label14.Size;
                l3.Location = label14.Location;
                l3.Padding = label14.Padding;
                l3.Anchor = label14.Anchor;
                l3.Font = label14.Font;
                l3.TextAlign = label14.TextAlign;

                dt = ds.Tables[0];
                l1.Text = dt.Rows[i][0].ToString();
                dt = ds.Tables[1];
                l2.Text = dt.Rows[i][0].ToString();
                dt = ds.Tables[2];
                l3.Text = dt.Rows[i][0].ToString();

                this.tableLayoutPanel1.AutoSize = true;
                temp = tableLayoutPanel1.RowStyles[0];
                this.tableLayoutPanel1.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                this.tableLayoutPanel1.Controls.Add(l1, 2, i);
                this.tableLayoutPanel1.Controls.Add(l2, 1, i);
                this.tableLayoutPanel1.Controls.Add(l3, 0, i);*/

                if (textBox1.Text == "" && textBox2.Text == "")
                {
                    /*
                     * create procedure clinic_التخصصات_الطبية_speciality_select
                        as
                        begin
                        select code as 'الكود', arabic_des as 'الاسم العربى' , latini_des as 'الاسم اللاتينى' from speciality
                        end

                     * */
                    //con.Open();
                    //cmd.Connection = con;
                    ////cmd.CommandText = "select code as 'الكود', arabic_des as 'الاسم العربى' , latini_des as 'الاسم اللاتينى' from speciality";
                    //cmd.CommandText = "clinic_التخصصات_الطبية_speciality_select";
                    //dr = cmd.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Load(dr);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    dataGridView2.DataSource = dt;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("لا توجد نتائج بحث");
                    //}
                    //dr.Close();
                    //con.Close();
                    con1.OpenConection();
                    object dt = con1.ShowDataInGridViewUsingStoredProc("clinic_التخصصات_الطبية_speciality_select");
                    if (dt!=null)
                    {
                        dataGridView2.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد نتائج بحث");
                    }
                    con1.CloseConnection();

                }

                if (textBox1.Text != "" && textBox2.Text == "")
                {
                    /*
                     * 

                            create procedure clinic_التخصصات_الطبية_للغرف_sepcialty_code_select(@c nvarchar(10))
                            as
                            begin
                            select code as 'الكود', arabic_des as 'الاسم العربى' , latini_des as 'الاسم اللاتينى' from speciality where code=@c
                            end

                     * */
                    //con.Open();
                    //cmd.Connection = con;
                    //cmd.CommandText = "select code as 'الكود', arabic_des as 'الاسم العربى' , latini_des as 'الاسم اللاتينى' from speciality where code='" + textBox1.Text + "'";
                    //dr = cmd.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Load(dr);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    dataGridView2.DataSource = dt;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("لا توجد نتائج بحث");
                    //}
                    //dr.Close();
                    //con.Close();
                    con1.OpenConection();
                    types = new SqlDbType[] { SqlDbType.NVarChar };
                    name_input = new string[] { "" };
                    values = new string[] { "" };
                    types[count] = SqlDbType.NVarChar;
                    name_input[count] = "@c";
                    values[count] = textBox1.Text;
                    object ob=con1.ShowDataInGridViewUsingStoredProc("clinic_التخصصات_الطبية_للغرف_sepcialty_code_select", name_input, values, types);
                    if (ob != null)
                    {
                        dataGridView2.DataSource = ob;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد نتائج بحث");
                    }
                    con1.CloseConnection();
                    count = 0;
                }

                if (textBox1.Text == "" && textBox2.Text != "")
                {
                    /*
                     * 

                    create procedure clinic_التخصصات_الطبية_للغرف_sepcialty_name_select(@arabic nvarchar(100))
                    as
                    begin
                    select code as 'الكود', arabic_des as 'الاسم العربى' , latini_des as 'الاسم اللاتينى' from speciality where arabic_des like N'%'+@arabic+'%'
                    end
                     */
                    //con.Open();
                    //cmd.Connection = con;
                    //cmd.CommandText = "select code as 'الكود', arabic_des as 'الاسم العربى' , latini_des as 'الاسم اللاتينى' from speciality where arabic_des='" + textBox2.Text + "'";
                    //dr = cmd.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Load(dr);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    dataGridView2.DataSource = dt;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("لا توجد نتائج بحث");
                    //}
                    //dr.Close();
                    //con.Close();
                    con1.OpenConection();
                    types = new SqlDbType[] { SqlDbType.NVarChar };
                    name_input = new string[] { "" };
                    values = new string[] { "" };
                    types[count] = SqlDbType.NVarChar;
                    name_input[count] = "@arabic";
                    values[count] = textBox2.Text;
                    object ob = con1.ShowDataInGridViewUsingStoredProc("clinic_التخصصات_الطبية_للغرف_sepcialty_name_select", name_input, values, types);
                    if (ob != null)
                    {
                        dataGridView2.DataSource = ob;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد نتائج بحث");
                    }
                    con1.CloseConnection();
                    count = 0;
                }

                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    /*
                     * 

                            create procedure clinic_التخصصات_الطبية_للغرف_sepcialty_code_name_select(@c nvarchar(50),@arabic nvarchar(100))
                            as
                            begin

                            select code as 'الكود', arabic_des as 'الاسم العربى' , latini_des as 'الاسم اللاتينى' from speciality where code=@c and  arabic_des like N'%'+@arabic+'%'
                            end
                     * 
                     * */
                    //con.Open();
                    //cmd.Connection = con;
                    //cmd.CommandText = "select code as 'الكود', arabic_des as 'الاسم العربى' , latini_des as 'الاسم اللاتينى' from speciality where code='" + textBox1.Text + "' and arabic_des='" + textBox2.Text + "'";
                    //dr = cmd.ExecuteReader();
                    //DataTable dt = new DataTable();
                    //dt.Load(dr);
                    //if (dt.Rows.Count > 0)
                    //{
                    //    dataGridView2.DataSource = dt;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("لا توجد نتائج بحث");
                    //}
                    //dr.Close();
                    //con.Close();
                    con1.OpenConection();
                    types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar };
                    types[count] = SqlDbType.NVarChar;
                    name_input = new string[] { "" ,""};
                    values = new string[] { "", "" };
                    name_input[count] = "@c";
                    values[count] = textBox1.Text;
                    count++;
                    types[count] = SqlDbType.NVarChar;
                    name_input[count] = "@arabic";
                    values[count] = textBox2.Text;
                    object ob = con1.ShowDataInGridViewUsingStoredProc("clinic_التخصصات_الطبية_للغرف_sepcialty_code_name_select", name_input, values, types);
                    if (ob != null)
                    {
                        dataGridView2.DataSource = ob;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد نتائج بحث");
                    }
                    con1.CloseConnection();
                    count = 0;

                }
            }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            غرف_العيادات_الخارجية f1 = new غرف_العيادات_الخارجية();
            f1.Focus();
            this.DialogResult = DialogResult.OK;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Arab = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
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
        /*private void label13_Click(object sender, EventArgs e)
        {
            Arab = (sender as Label).Text;
        }
        private void l2_Click(object sender, EventArgs e)
        {
            Arab = (sender as Label).Text;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Focus();
            this.DialogResult = DialogResult.OK;
        }*/

        
    }
//}
