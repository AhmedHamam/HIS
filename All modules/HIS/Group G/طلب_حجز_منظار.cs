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
    public partial class طلب_حجز_منظار : Form
    {
        public طلب_حجز_منظار()
        {
            InitializeComponent();
        }
        Connection con = new Connection();
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int parsedValue;
                if (!int.TryParse(textBox1.Text, out parsedValue))
                {
                    MessageBox.Show("يجب ادخال ارقام فقط");
                    return;
                }
            }
            if (textBox2.Text != "")
            {
                int parsedValue;
                if (!int.TryParse(textBox2.Text, out parsedValue))
                {
                    MessageBox.Show("يجب ادخال ارقام فقط");
                    return;
                }
            }
            if (textBox3.Text != "")
            {
                int parsedValue;
                if (int.TryParse(textBox3.Text, out parsedValue))
                {
                    MessageBox.Show("يجب ادخال حروف فقط");
                    return;
                }
            }

           
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            
            con.OpenConection();
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                //create procedure setescope_patient_select
                //as
                //begin
                //select id as 'الكود',nickname as 'اللقب/الرتبة',name as'الاسم',bof as 'تاريخ الميلاد',gender as ' النوع',open_file_date as 'تاريخ فتح الملف' from patient_endo;
                //end
                dataGridView1.Visible = true;
                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("setescope_patient_select");
                
            }
            else
            {
                if (textBox1.Text != "")
                {
                    try
                    {
                        //create procedure setescope_patient_select_by_id(@id1 int)
                        //as
                        //begin
                        // select id as 'الكود',nickname as 'اللقب/الرتبة',name as'الاسم',bof as 'تاريخ الميلاد',gender as ' النوع',open_file_date as 'تاريخ فتح الملف' from patient_endo where id=@id1;
                        //end
                        string[] pramname = new string[1];
                        string[] pramvalue = new string[1];
                        SqlDbType[] pramtype = new SqlDbType[1];
                        pramname[0] = "@id1";
                        pramvalue[0] = textBox1.Text;
                        pramtype[0] = SqlDbType.Int;
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("setescope_patient_select_by_id", pramname, pramvalue, pramtype);

                        


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (textBox2.Text != "")
                {
                    //create procedure setescope_patient_select_by_ssn(@ssn1 int)
                    //as
                    //begin
                    // select id as 'الكود',nickname as 'اللقب/الرتبة',name as'الاسم',bof as 'تاريخ الميلاد',gender as ' النوع',open_file_date as 'تاريخ فتح الملف' from patient_endo where nss=@ssn1;
                    //end 
                    string[] pramname = new string[1];
                    string[] pramvalue = new string[1];
                    SqlDbType[] pramtype = new SqlDbType[1];
                    pramname[0] = "@ssn1";
                    pramvalue[0] = textBox2.Text;
                    pramtype[0] = SqlDbType.Int;
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("setescope_patient_select_by_ssn", pramname, pramvalue, pramtype);

                }
                else if (textBox3.Text != "")
                {
                    //create procedure setescope_patient_select_by_name(@name1 nvarchar(50))
                    //as
                    //begin
                    // select id as 'الكود',nickname as 'اللقب/الرتبة',name as'الاسم',bof as 'تاريخ الميلاد',gender as ' النوع',open_file_date as 'تاريخ فتح الملف' from patient_endo where name=@name1;
                    //end 
                    string[] pramname = new string[1];
                    string[] pramvalue = new string[1];
                    SqlDbType[] pramtype = new SqlDbType[1];
                    pramname[0] = "@name1";
                    pramvalue[0] = textBox3.Text;
                    pramtype[0] = SqlDbType.VarChar;
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("setescope_patient_select_by_name", pramname, pramvalue, pramtype);

                    
                }


               


            }
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static int c { get; set; }
        private void cellclick(object sender, DataGridViewCellEventArgs e)
        {
            c = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            حجز_عمليه_منظار f = new حجز_عمليه_منظار();
            f.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";
            textBox2.Text = "";
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }
    }
}
