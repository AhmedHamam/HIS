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
    public partial class محرك_البحث_للحجز : Form
    {

        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;

        string x1;
        int code, count;
        public string name1, name2;
        public محرك_البحث_للحجز()
        {
            InitializeComponent();
        }




        private void Form3_Load(object sender, EventArgs e)
        {
            rectangleShape2.Visible = false;

            rectangleShape1.Visible = false;
            label2.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            label28.Visible = false;
            label29.Visible = false;
            label30.Visible = false;
            label31.Visible = false;


        }
        public محرك_البحث_للحجز(int c)
        {
            InitializeComponent();
            code = c;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            label28.Visible = false;
            label27.Visible = false;
            label29.Visible = false;
            label30.Visible = false;
            label31.Visible = false;
            label2.Visible = false;
            rectangleShape2.Visible = false;
            rectangleShape1.Visible = false;
            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();


            if (textBox1.Text != "")
            {

                //create procedure p1(@x int)
                //as
                //  select patient_id as'رقم المريض',patient_name as 'اسم المريض',job  as'الرتبه /اللقب',date_of_birth as'تاريخ الميلاد',gender as 'النوع',date_regist as 'تاريخ فتح الملف'  from Registeration_patientRegisteration where patient_id=@x;


                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.Int };
                name_input = new string[] { "@x" };
                values = new string[] { textBox1.Text };
                object ob = con1.ShowDataInGridViewUsingStoredProc("p1", name_input, values, types);
                dataGridView1.DataSource = ob;
                con1.CloseConnection();

            }
            else if (textBox2.Text != "")
            {

                //              create procedure f1(@x nvarchar(50))
                //as
                //  select patient_id as'رقم المريض',patient_name as 'اسم المريض',job  as'الرتبه /اللقب',date_of_birth as'تاريخ الميلاد',gender as 'النوع',date_regist as 'تاريخ فتح الملف'  from Registeration_patientRegisteration where patient_name like  N''+@x+'%'; 

                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.NVarChar };
                name_input = new string[] { "@x" };
                values = new string[] { textBox2.Text };
                object ob = con1.ShowDataInGridViewUsingStoredProc("f1", name_input, values, types);

                dataGridView1.DataSource = ob;
                con1.CloseConnection();

            }
            else if (textBox3.Text != "")
            {
                //create procedure ssn(@x int)
                //as

                //select patient_id as'رقم المريض',patient_name as 'اسم المريض',job  as'الرتبه /اللقب',date_of_birth as'تاريخ الميلاد',gender as 'النوع',date_regist as 'تاريخ فتح الملف'  from Registeration_patientRegisteration where identity_type=@x


                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.Int };
                name_input = new string[] { "@x" };
                values = new string[] { textBox3.Text };
                object ob = con1.ShowDataInGridViewUsingStoredProc("ssn", name_input, values, types);
                dataGridView1.DataSource = ob;
                con1.CloseConnection();


            }
            else if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                //        create procedure pro
                //        as
                //select patient_id as'رقم المريض',patient_name as 'اسم المريض',job  as'الرتبه /اللقب',date_of_birth as'تاريخ الميلاد',gender as 'النوع',date_regist as 'تاريخ فتح الملف'  from Registeration_patientRegisteration;


                con1.OpenConection();
                object ob = con1.ShowDataInGridViewUsingStoredProc("pro");
                dataGridView1.DataSource = ob;
                con1.CloseConnection();

            }












        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label16.Visible = false;

            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            label28.Visible = false;
            label27.Visible = false;
            label29.Visible = false;
            label30.Visible = false;
            label31.Visible = false;
            label2.Visible = false;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            dataGridView2.DataSource = null;
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
            rectangleShape1.Visible = false;
            rectangleShape2.Visible = false;


        }
        //         send data
        private void send(object sender, DataGridViewCellEventArgs e)
        {
            x1 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();


            rectangleShape2.Visible = false;

            rectangleShape1.Visible = false;
            label2.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            label27.Visible = false;
            label28.Visible = false;
            label29.Visible = false;
            label30.Visible = false;
            label31.Visible = false;
            //create procedure sh(@x int)
            //    as
            //    select visit_id  as'رقم الزياره',entrance_date as 'من تاريخ',expected_exit_date as'الى تاريخ' from entranceoffice_visit where pat_id=@x;

            con1.OpenConection();
            types = new SqlDbType[] { SqlDbType.Int };
            name_input = new string[] { "@x" };
            values = new string[] { x1 };
            object ob = con1.ShowDataInGridViewUsingStoredProc("sh", name_input, values, types);
            dataGridView2.DataSource = ob;
            con1.CloseConnection();





        }
        // send details about the visit of patient
        private void visit_details(object sender, DataGridViewCellEventArgs e)
        {
            string n = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();

            rectangleShape2.Visible = true;
            rectangleShape1.Visible = true;
            //create procedure visit_detail(@x int,@y int)
            //       as
            //       select type_of_visit,ordere,patient_status from entranceoffice_visit where visit_id=@x;
            //       select CE_AName from tb_Contracting_Entities ,Registeration_patientRegisteration where catogrical_code=CE_Id and patient_id=@y;
            //       select r_id,degree,floor details from room,entranceoffice_visit where r_id=room_id and visit_id=@x;

            con1.OpenConection();
            types = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int };
            name_input = new string[] { "@x", "@y" };
            values = new string[] { n, x1 };
            SqlDataReader dr = con1.ShowDataInGridViewUsingStoredProcDR("visit_detail", name_input, values, types);

            dr.Read();
            string type_visit = dr[0].ToString();
            string order = dr[1].ToString();

            label31.Text = dr[2].ToString();
            dr.NextResult(); dr.Read();
            string geha = dr[0].ToString();
            dr.NextResult(); dr.Read();
            label27.Text = dr[0].ToString() + "  /" + dr[2].ToString();
            label29.Text = dr[1].ToString();
            dr.Close();
            label19.Text = order;
            label17.Text = type_visit;
            label23.Text = geha;
            label2.Visible = true;
            label17.Visible = true;
            label16.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label22.Visible = true;
            label23.Visible = true;
            if (type_visit == "خارجي")
            {
                label24.Visible = true;
                label25.Visible = true;
                label26.Visible = false;
                label27.Visible = false;
                label28.Visible = false;
                label29.Visible = false;
                label30.Visible = false;
                label31.Visible = false;
            }
            else
            {
                label24.Visible = false;
                label25.Visible = false;
                label26.Visible = true;
                label27.Visible = true;
                label28.Visible = true;
                label29.Visible = true;
                label30.Visible = true;
                label31.Visible = true;
            }



        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }





        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال حروف");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال حروف");
            }
        }


        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال ارقام");
                textBox2.Text = "";

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            //    create procedure clinic_محرك_البحث_للحجز_patient_visit_insert(@pid int,@ordere int,@type nvarchar(50),@type2 nvarchar(50),@date nvarchar(100))
            //as
            //begin
            //declare @i int
            //set @i=(select count(visit_id)+1  from entranceoffice_visit where pat_id=@pid)
            //insert into entranceoffice_visit(visit_id,pat_id,ordere,type_of_visit,type_status,entrance_date) values(@i,@pid,@ordere,@type,  @type2 , @date)
            //end




            //create procedure clinic_محرك_البحث_للحجز_treat_patient_insert(@pid int,@c nvarchar(30))
            //as
            //begin
            //insert into Treat_Patient(pid,c_code) values(@pid,@c)
            //end


            //    create procedure clinic_محرك_البحث_للحجز_patient_visit_insert(@pid int,@ordere int,@type nvarchar(50),@type2 nvarchar(50),@date nvarchar(100))
            //as
            //begin
            //declare @i int
            //set @i=(select count(visit_id)+1  from entranceoffice_visit where pat_id=@pid)
            //insert into entranceoffice_visit(visit_id,pat_id,ordere,type_of_visit,Finish_Type,entrance_date) values(@i,@pid,@ordere,@type,  @type2 , @date)
            //endd



            int order = 1000;
            string type = "خارجي", type2 = "open";
            DateTime dt = DateTime.Now;
            String date = dt.ToString("yyyy-MM-dd hh:mm:ss");
            con1.OpenConection();
            types = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
            name_input = new string[] { "@pid", "@ordere", "@type", "@type2", "@date" };
            values = new string[] { x1, order.ToString(), type, type2, date };
            con1.ExecuteNonQueryProcedure("clinic_محرك_البحث_للحجز_patient_visit_insert", name_input, values, types);
            con1.CloseConnection();

            con1.OpenConection();
            types = new SqlDbType[] { SqlDbType.Int, SqlDbType.VarChar };
            name_input = new string[] { "@pid", "@c" };
            values = new string[] { x1, code.ToString() };
            con1.ExecuteNonQueryProcedure("clinic_محرك_البحث_للحجز_treat_patient_insert1", name_input, values, types);
            con1.CloseConnection();
            //create procedure clinic_محرك_البحث_للحجز_patient_select1(@pid int)
            //as
            //begin
            //select patient_name, catogrical_code from Registeration_patientRegisteration where patient_id=@pid
            //end

            con1.OpenConection();
            types = new SqlDbType[] { SqlDbType.Int };
            name_input = new string[] { "@pid" };
            values = new string[] { x1 };
            SqlDataReader dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_محرك_البحث_للحجز_patient_select1", name_input, values, types);
            dr.Read();
            MessageBox.Show("لفد تم الادخال بنجاح");
            حجز_العياده f = new حجز_العياده();

            name1 = dr[0].ToString() + " " + dr[1].ToString();
            //name2 = dr[2].ToString();
            f.Focus();
            this.DialogResult = DialogResult.OK;

            f.Focus();
            con1.CloseConnection();

            //insert_into_patient_visit();
            //cmd = new SqlCommand("insert into pat_clinic(patient_id,code_clinic) values(" + int.Parse(x1) + "," + code + ");", con);
            //try
            //{

            //    MessageBox.Show("لفد تم الادخال بنجاح");
            //    cmd = new SqlCommand("select fname,sname,institution from patient where patient_id=" + int.Parse(x1) + "", con);
            //     dr = cmd.ExecuteReader();
            //    dr.Read();

            //    حجز_العياده f = new حجز_العياده();

            //   name1 = dr[0].ToString() +" "+ dr[1].ToString();
            //    name2 = dr[2].ToString();
            //    f.Focus();
            //    this.DialogResult = DialogResult.OK;

            //    f.Focus(); 
        }


        /*
         * 
                             *  create procedure [dbo].[clinic_select_vaction_doc](@doc_name varchar(30),@c varchar(50),@time datetime)
                    as
                    begin

                    select   doc_ssn from doctors where full_name like N'%'+@doc_name+'%' and 
                    spec_id=(select specialty_code from clinic where clinic_code=@c)
                     and emp_id  not in (select emp_id from balance_vacation where   @time <=date_end_vacation);
                     end




                    ///////التسجيل

                    create procedure [dbo].[clinic_التسجيل_patient_insert]
                    (@fn varchar(50),@gen varchar(50),@job varchar(50),@ins int,@ssn int,@date varchar(30),
                    @nat varchar(50),@address varchar(100),@age int,@emp int,@reg_date varchar(30))
                    as
                    begin

                    insert into Registeration_patientRegisteration
                    (patient_name,gender,job,catogrical_code,identity_type,date_of_birth,nationality,address_of_patient,age,employ_code,date_Regist) 
                    values(N''+@fn+'',N''+@gen+'',N''+@job+'',@ins,@ssn,@date,N''+@nat+'',N''+@address+'',@age,@emp,@reg_date)
                    declare @pid int
                    set @pid=(select patient_id from Registeration_patientRegisteration where patient_name like N'%'+@fn+'%')

		                    insert into entranceoffice_visit
		                    (pat_id,ordere,type_of_visit,Finish_Type,entrance_date,expected_exit_date) values
		                    (@pid,1000,N'خارجي',  'open' , @reg_date ,@reg_date)
       

                     end
                    ////


                    create procedure [dbo].[clinic_محرك_البحث_للحجز_treat_patient_insert](@fn varchar(50),@c varchar(30))
                    as
                    begin
                    declare @vid int
                    set @vid=(select max(visit_id) from entranceoffice_visit where pat_id=(select patient_id from Registeration_patientRegisteration where patient_name like N'%'+@fn+'%'))
                    insert into Treat_Patient(pid,c_code) values(@vid,@c)
                    end




                    /////محرك البحت
                    create procedure [dbo].[clinic_محرك_البحث_للحجز_patient_visit_insert](@pid int,@ordere int,@type nvarchar(50),@type2 nvarchar(50),@date nvarchar(100))
                            as
                            begin
		                    insert into entranceoffice_visit(pat_id,ordere,type_of_visit,Finish_Type,entrance_date,expected_exit_date) values(@pid,@ordere,@type,  @type2 , @date,@date)
                            end
                    GO




                    ///////
                    create procedure [dbo].[clinic_محرك_البحث_للحجز_treat_patient_insert1](@pid int,@c varchar(30))
                    as
                    begin
                    declare @v_id int
                    set @v_id=(select max(visit_id) from entranceoffice_visit where pat_id=@pid)
                    insert into Treat_Patient(pid,c_code) values(@v_id,@c)
                    end
                    GO
         * 
         * 
         * 
         */



    }
}