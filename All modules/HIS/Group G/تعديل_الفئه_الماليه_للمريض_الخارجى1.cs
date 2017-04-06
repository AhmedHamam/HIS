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
    public partial class تعديل_الفئه_الماليه_للمريض_الخارجى : Form
    {
        public static string s1 { get; set; }
        public static string s2 { get; set; } 
        public static string s3 { get; set; }
        public static string s4 { get; set; }
        public static string s5 { get; set; }
        public static string s6 { get; set; }


        public static string ss1 { get; set; }
        public static string ss2 { get; set; }
        public static string ss3 { get; set; }
        public static string ss4 { get; set; }
        public static string ss5 { get; set; }
        public static string ss6 { get; set; }


        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        
        public تعديل_الفئه_الماليه_للمريض_الخارجى()
        {
            InitializeComponent();

        }
        public تعديل_الفئه_الماليه_للمريض_الخارجى(string y1, string y2, string y4, string y5, string y6)
        {
            InitializeComponent();
            label10.Text = y1;
            label12.Text = y2;
            label15.Text = y4;
            label17.Text = y5;
            label19.Text = y6;
        }



        private void Form6_Load(object sender, EventArgs e)
        {

            
            
            //create procedure clinic_select_job_ins(@x int)
            //    as
            //    select job from Registeration_patientRegisteration where patient_id=@x ;
            //     select CE_Id ,CE_AName from tb_Contracting_Entities,Registeration_patientRegisteration where tb_Contracting_Entities.CE_Id=Registeration_patientRegisteration.catogrical_code and patient_id=@x;

            con1.OpenConection();
            types = new SqlDbType[] { SqlDbType.Int };
            name_input = new string[] { "@x" };
            values = new string[] { label10.Text };
            SqlDataReader dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_select_job_ins", name_input, values, types);
             
                dr.Read();
                label11.Text = dr[0].ToString();
                dr.NextResult(); dr.Read();

               s1 = dr[0].ToString();
               s2 = dr[1].ToString();
               dr.Close();
               con1.CloseConnection();

              
                // create procedure clinic_select_sub_family(@x int)
                //as

                //select EB_id ,EB_Aname from tab_Entities_Branches,Registeration_patientRegisteration where sub_institution=tb_Entities_Branches. EB_id  and patient_id=@x ;
                //select PC_id ,PC_Aname from tb_Patients_Categories,Registeration_patientRegisteration where family= PC_id and patient_id=@x; 
 
               con1.OpenConection();
               types = new SqlDbType[] { SqlDbType.Int };
               name_input = new string[] { "@x" };
               values = new string[] { label10.Text };
               SqlDataReader ddr2 = con1.ShowDataInGridViewUsingStoredProcDR("clinic_select_sub_family", name_input, values, types);
                ddr2.Read();
                s4 = ddr2[0].ToString();
                s3 = ddr2[1].ToString();
                ddr2.NextResult(); 
                ddr2.Read(); s6 = ddr2[0].ToString();
                s5 = ddr2[1].ToString();
               ddr2.Close();
             
                textBox1.Text = s1;
                textBox2.Text = s2;
                textBox3.Text = s3;
                textBox4.Text = s4;
                if (textBox4.Text == "0") { textBox4.Text = ""; }
                textBox5.Text = s5;
                textBox6.Text = s6;
                label29.Visible = false;
                label30.Visible = false;
                label31.Visible = false;
                label32.Visible = false;
                label33.Visible = false;
                label34.Visible = false;
                label35.Visible = false;     
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ss1 = textBox1.Text;
            ss2 = textBox2.Text;
            ss3 = textBox3.Text;
            ss4 = textBox4.Text;
            ss5 = textBox5.Text;
            ss6 = textBox6.Text;

            الجهه_الخاص_بالمريض_الخارجى f7 = new الجهه_الخاص_بالمريض_الخارجى();




            if (f7.ShowDialog() == DialogResult.OK)
            {
                label10.Text = محرك_البحث1.xx1;
                label12.Text = محرك_البحث1.xx2;

                label15.Text = محرك_البحث1.xx4;
                label17.Text = محرك_البحث1.xx5;
                label19.Text = محرك_البحث1.xx6;

                textBox1.Text = الجهه_الخاص_بالمريض_الخارجى.v1;
                textBox2.Text = الجهه_الخاص_بالمريض_الخارجى.x2;
                textBox3.Text = الجهه_الخاص_بالمريض_الخارجى.x4;

                textBox4.Text = الجهه_الخاص_بالمريض_الخارجى.x3;
                textBox5.Text = الجهه_الخاص_بالمريض_الخارجى.x6;
                textBox6.Text = الجهه_الخاص_بالمريض_الخارجى.x5;

                label29.Text = تعديل_الفئه_الماليه_للمريض_الخارجى.s2;
                label29.Visible = true;

                label30.Text = الجهه_الخاص_بالمريض_الخارجى.x2;
                label30.Visible = true;

                label31.Text = تعديل_الفئه_الماليه_للمريض_الخارجى.s3;

                label31.Visible = true;

                label32.Text = الجهه_الخاص_بالمريض_الخارجى.x4;
                label32.Visible = true;

                label33.Text = تعديل_الفئه_الماليه_للمريض_الخارجى.s5;
                label33.Visible = true;

                label34.Text = الجهه_الخاص_بالمريض_الخارجى.x6;
                label34.Visible = true;

                label35.Text = الجهه_الخاص_بالمريض_الخارجى.dt;
                label35.Visible = true;
            }
            
        
          
        }

        private void label2_Click(object sender, EventArgs e)
        {
            تاكيد_تعديل_الفئه f10 = new تاكيد_تعديل_الفئه();
            f10.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

      

     
    }
}
