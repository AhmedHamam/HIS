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
    public partial class التسجيل : Form
    {
        // SqlCommand cmd;
        // SqlConnection con;
        SqlDataReader dr;
        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;

        int clinic_name = 0;
        string f_name;
        public string n;
        public string x;
        public التسجيل(int name)
        {
            InitializeComponent();

            clinic_name = name;

        }

        //For insert the new patient in table of patient
        private void button1_Click(object sender, EventArgs e)
        {


            //create procedure clinic_التسجيل_patient_insert(@id int,@fn nvarchar(50),@sn nvarchar(50),@thn nvarchar(50),
            //@ln nvarchar(50),@gen nvarchar(50),@job nvarchar(50),@ins varchar(50),@ssn int,@date date,@nat nvarchar(50),@ph int,@f_n int,@f_l nvarchar(50))
            //        as
            //        begin
            //insert into patient(patient_id,fname,sname,thname,lname,gender,job,institution,ssn,date_of_birth,nationality,phonenumber,file_number,file_location) 
            //values(@id,@fn,@sn,@thn,@ln,@gen,@job,@ins,@ssn,@date,@nat,@ph,@f_n,@f_l)
            //        end




            //create procedure clinic_التسجيل_patient_insert
            //(@fn varchar(50),@gen varchar(50),@job varchar(50),@ins int,@ssn int,@date varchar(30),
            //@nat varchar(50),@address varchar(100),@age int,@emp int,@reg_date varchar(30))
            //as
            //begin

            //insert into Registeration_patientRegisteration
            //(patient_name,gender,job,catogrical_code,identity_type,date_of_birth,nationality,address_of_patient,age,employ_code,date_Regist) 
            //values(N''+@fn+'%',N''+@gen+'%',N''+@job+'%',@ins,@ssn,@date,N''+@nat+'%',N''+@address+'%',@age,@emp,@reg_date)
            // end
            DateTime datetime = DateTime.Now;
            string date = datetime.ToString("yyyy-MM-dd HH:mm:ss");
            x = textBox2.Text;
            n = textBox3.Text + " " + textBox4.Text;
            f_name = textBox2.Text + "" + textBox3.Text + "" + textBox4.Text + "" + textBox5.Text;
            con1.OpenConection();
            types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.Int, SqlDbType.Date, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.Int, SqlDbType.VarChar };
            name_input = new string[] { "@fn", "@gen", "@job", "@ins", "@ssn", "@date", "@nat", "@address", "@age", "@emp", "@reg_date" };
            values = new string[] { f_name, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text, textBox11.Text, textBox1.Text, textBox12.Text, textBox13.Text, date };
            con1.ExecuteNonQueryProcedure("clinic_التسجيل_patient_insert", name_input, values, types);
            MessageBox.Show("تم اضافه المريض ");
            con1.CloseConnection();

        }
        //For add patient to clinic
        private void button2_Click(object sender, EventArgs e)
        {
            //create procedure clinic_محرك_البحث_للحجز_treat_patient_insert(@fn varchar(50),@c varchar(30))
            //as
            //begin
            //declare @pid int
            //set @pid=(select patient_id from Registeration_patientRegisteration where patient_name like N'%'+@fn+'%')
            //insert into Treat_Patient(pid,c_code) values(@pid,@c)
            //end


            con1.OpenConection();
            types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar };
            name_input = new string[] { "@fn", "@c" };
            values = new string[] { f_name, clinic_name.ToString() };
            con1.ExecuteNonQueryProcedure("clinic_محرك_البحث_للحجز_treat_patient_insert", name_input, values, types);
            con1.CloseConnection();



            //create procedure clinic_محرك_البحث_للحجز_patient_select(@fn varchar(50))
            //as
            //begin
            //select patient_name, catogrical_code from Registeration_patientRegisteration where patient_name like N'%'+@fn+'%'
            //end
            con1.OpenConection();
            types = new SqlDbType[] { SqlDbType.VarChar };
            name_input = new string[] { "@fn" };
            values = new string[] { f_name };
            SqlDataReader dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_محرك_البحث_للحجز_patient_select", name_input, values, types);
            dr.Read();
            MessageBox.Show("لفد تم الادخال بنجاح");
            حجز_العياده f = new حجز_العياده();


            f.Focus();
            this.DialogResult = DialogResult.OK;

            f.Focus();
            dr.Close();
            con1.CloseConnection();
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

        private void check_string_n1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط ");

            }
        }

        private void check_string_n2(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط ");

            }
        }

        private void check_string_n3(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط ");

            }
        }

        private void check_string_n4(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط ");

            }
        }

        private void check_string_g(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط ");

            }
        }

        private void check_string_job(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط ");

            }
        }

        private void check_number_ins(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الارقام فقط ");

            }
        }

        private void check_number_ssn(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الارقام فقط ");

            }
        }

        private void check_string_nat(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط ");

            }

        }

        private void check_number_ph(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الارقام فقط ");

            }

        }

        private void check_number_file(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الارقام فقط ");

            }
        }

        private void check_string_file(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الحروف فقط ");

            }

        }

        private void check_number_code_emp(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الارقام فقط ");

            }
        }

        private void check_number_age(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("قم بادخال الارقام فقط ");

            }
        }


    }
}
