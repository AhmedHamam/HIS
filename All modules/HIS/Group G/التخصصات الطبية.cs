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
    public partial class التخصصات_الطبية : Form
    {
        SqlDataReader dr;
       
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();


        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        Label l1;
        Label l2;
        Label l3;

        RowStyle temp;

        public static string Arab { get; set; }
        public التخصصات_الطبية()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

            /*
             * 
                create procedure clinic_التخصصات_الطبية_speciality_select
                as
                begin
                select code as 'الكود', arabic_des as 'الاسم العربى' , latini_des as 'الاسم اللاتينى' from speciality
                end

             * 
             */
            //con.Open();
            //    cmd.Connection = con;
            //   // cmd.CommandText = "select code as 'الكود', arabic_des as 'الاسم العربى' , latini_des as 'الاسم اللاتينى' from speciality";
            //    cmd.CommandText = "clinic_التخصصات_الطبية_speciality_select";
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    dr = cmd.ExecuteReader();

             con1.OpenConection();
            dr = con1.DataReader("clinic_التخصصات_الطبية_speciality_select");
            dt.Load(dr);
            dataGridView2.DataSource = dt;
            dr.Close();
            con1.CloseConnection();
            }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            محرك_بحث_فريق_العمل_الطبى f2 = new محرك_بحث_فريق_العمل_الطبى();
            f2.Focus();
            this.DialogResult = DialogResult.OK;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Arab = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
        //Validatin
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

