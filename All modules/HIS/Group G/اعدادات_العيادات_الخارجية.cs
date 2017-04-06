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
    public partial class اعدادات_العيادات_الخارجية : Form
    {
        SqlDataReader dr;
        
        
       
        

        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        public اعدادات_العيادات_الخارجية()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            اضافه_عياده f2 = new اضافه_عياده();
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             
             *  create procedure clinic_اعدادات_العيادات_الخارجية_clinic_hosptial_service
                    as
                    begin
                    select code as 'الكود', arabic_des as 'الاسم العربى' , english_des as 'الاسم الانجليزى'  from hospital_service where arabic_des='ex_clinic';
                    
                    end
             * create procedure clinic_search_all_select
                as
                begin
                 select Clinic_code  as 'الكود', arabic_name as 'الاسم العربى' , english_name as 'الاسم الانجليزى' from Clinic;
                 end


             * */

            //cmd.Connection = con;
            //da = new SqlDataAdapter("select code as 'الكود', arabic_des as 'الاسم العربى' , english_des as 'الاسم الانجليزى'  from hospital_service where arabic_des='ex_clinic';select Clinic_code as 'الكود', Arabic_name as 'الاسم العربى' , English_name as 'الاسم الانجليزى' from clinic;", con);
            //cmd.CommandText = "select code as 'الكود', arabic_des as 'الاسم العربى' , english_des as 'الاسم الانجليزى'  from service where arabic_des='ex_clinic'";
            //dr = cmd.ExecuteReader();
            //dt.Load(dr);

            //con.Open();
            //da = new SqlDataAdapter("clinic_اعدادات_العيادات_الخارجية_clinic_hosptial_service", con);
            //da.Fill(ds);
            con1.OpenConection();
            dr = con1.DataReader("clinic_اعدادات_العيادات_الخارجية_clinic_hosptial_service");
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView2.DataSource = dt;
            dr.Close();
           
            con1.CloseConnection();
            con1.OpenConection();
            dr = con1.DataReader("clinic_search_all_select");
            DataTable dt1 = new DataTable();
            dt1.Load(dr);
            dataGridView1.DataSource = dt1;
           // dataGridView1.DataSource = ds.Tables[1];
           // dataGridView2.DataSource = ds.Tables[0];
            //dr.NextResult();
          //  dataGridView1.DataSource = dr[1];
            
            /*dr.Close();
            con.Close();

            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select code as 'الكود', arabic_des as 'الاسم العربى' , english_des as 'الاسم الانجليزى' from clinic";
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Close();*/
            con1.CloseConnection();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        

       

    }
}
