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
    public partial class محرك_البحث_عن_المرضى : Form
    {

        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        
        string x1;
        public محرك_البحث_عن_المرضى()
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

                  //    create procedure p1(@x int)
                  //as
                  //  select patient_id as'رقم المريض',patient_name as 'اسم المريض',job  as'الرتبه /اللقب',date_of_birth as'تاريخ الميلاد',gender as 'النوع',date_regist as 'تاريخ فتح الملف'  from Registeration_patientRegisteration where identity_type=@x  patient_id;



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

                  //create procedure f1(@x nvarchar(50))
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
                      // create procedure ssn(@x int)
                      //as
                      //  select patient_id as'رقم المريض',patient_name as 'اسم المريض',job  as'الرتبه /اللقب',date_of_birth as'تاريخ الميلاد',gender as 'النوع',date_regist as 'تاريخ فتح الملف'  from Registeration_patientRegisteration where identity_type=@x

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
              //  as
              //  select visit_id  as'رقم الزياره',entrance_date as 'من تاريخ',expected_exit_date as'الى تاريخ' from entranceoffice_visit where pat_id=@x;


                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.Int };
                name_input = new string[] { "@x" };
                values = new string[] { x1};
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
               //    as
               //    select type_of_visit,ordere,patient_status from entranceoffice_visit where visit_id=@x;
               //    select CE_AName from tb_Contracting_Entities ,Registeration_patientRegisteration where catogrical_code=CE_Id and patient_id=@y;
               //    select r_id,degree,floor details from room,entranceoffice_visit where r_id=room_id and visit_id=@x;

                con1.OpenConection();
                types = new SqlDbType[] { SqlDbType.Int ,SqlDbType.Int};
                name_input = new string[] { "@x","@y" };
                values = new string[] { n,x1 };
                SqlDataReader dr = con1.ShowDataInGridViewUsingStoredProcDR("visit_detail", name_input, values, types);
               
                dr.Read();
                string type_visit = dr[0].ToString();
                string order = dr[1].ToString();
               
                label31.Text = dr[2].ToString();
                dr.NextResult(); dr.Read(); 
                string geha = dr[0].ToString();
                dr.NextResult(); dr.Read();
                label27.Text = dr[0].ToString()+"  /"+dr[2].ToString();
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
                if (type_visit=="خارجي") 
                { 
                    label24.Visible = true; 
                    label25.Visible = true; 
                    label26.Visible = false; 
                    label27.Visible = false; 
                    label28.Visible = false; 
                    label29.Visible = false; 
                    label30.Visible =false; 
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

        

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar !='.') )
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
           
            if(!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || char.IsWhiteSpace(e.KeyChar)))   
            
            {
                e.Handled = true;
                MessageBox.Show("لا يمكن ادخال ارقام");
                textBox2.Text = "";
           
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

     
      

      

    }
}