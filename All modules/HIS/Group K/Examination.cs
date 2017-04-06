using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace HIS
{
    public partial class Examination : Form
    {
        Connection con = new Connection();
        SqlDataReader dr;
        ArrayList code = new ArrayList();
        string s="";
        public Examination()
        {
            InitializeComponent();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Examination_Load(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.OpenConection();
            
            // اسم كل الدكاتره  
            if (comboBox2.Items.Count > 0)
                comboBox2.Items.Clear();

            dr = con.DataReader("select full_name from doctors  ");
            while (dr.Read())
                comboBox2.Items.Add(dr[0].ToString());
            dr.Close();

            if (comboBox1.Items.Count > 0)
                comboBox1.Items.Clear();

            // اسماء كل المرضي 


            dr = con.DataReader("SELECT patient_name, patient_id FROM [dbo].[Registeration_patientRegisteration]");
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
                code.Add(dr[1].ToString());

            }
            dr.Close();

            if (radioButton1.Checked)
            { s = "Inter Costal"; }
            else if (radioButton1.Checked)
            { s = "Sub Costal"; }


          

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



            Connection con = new Connection();
            con.OpenConection();

         
                string[] param_names = new string[] {  
           "@doc_code" ,
           "@inventry_id" ,
		   "@Examination_date" ,
		   "@patient_id"  ,
		   "@general_apperance_built" ,
           "@general_apperance_weight" ,
           "@general_apperance_age" ,
           "@general_apperance_conscious_level" ,
           "@general_apperance_glass_coma_score" ,
           "@general_apperance_h_r" ,
           "@general_apperance_r_r" ,
           "@general_apperance_tempreture" ,
           "@general_apperance_blood_pressure" ,
           "@general_apperance_color" ,
           "@general_apperance_turgor",
           "@general_apperance_eruption" ,
           "@head_neck_fascies" ,
           "@head_neck_eyes" ,
           "@head_neck_mouth_tongue" ,
           "@head_neck_pharynx" ,
           "@head_neck_lymph_nodes" ,
           "@head_neck_oters" ,
           "@heart_precordial_bulge" ,
           "@heart_apex_beat" ,
           "@heart_thrill",
           "@heart_heart_sound" ,
           "@heart_murmurs",
           "@heart_others" ,
           "@chest_shape" ,
           "@chest_movement" ,
           "@chest_reactions" ,
           "@chest_air_entry" ,
           "@chest_breath_sounds" ,
           "@chest_adventure_sounds" ,
           "@chest_costal" ,
           "@abdomen_liver",
           "@abdomen_spleen" ,
           "@abdomen_kidneys" ,
           "@abdomen_ascites" ,
           "@abdomen_others" ,
           "@back_spine_deformity" ,
           "@back_spine_sweling" ,
           "@neurological_examination_mentality" ,
           "@neurological_examination_cranial_nerves"
               
            }; // الامراض الوراثسيه والعائليه للمريض 


                //@doc_code            @age   اسم الدكتور               @name       اسمالمريض             @iventry id                @date                                 @present                          @past                            @family 
                string[] param_values = new string[]
            
            { 
               
                            
                                 textBox7.Text,                       //    "@doc_code" ,
                                 textBox1.Text,                       //   "@inventry_id" ,
		            dateTimePicker1.Value.ToString("yyyy-MM-dd"),    //   "@Examination_date" ,
		                         textBox45.Text,                                //   "@patient_id"  ,
		                         textBox2.Text,                                        //  "@general_apperance_built" ,
                                 textBox14.Text,                                       //   "@general_apperance_weight" ,
                                 textBox13.Text,                                      //    "@general_apperance_age" ,
                                 textBox12.Text,                                       //   "@general_apperance_conscious_level" ,
                                 textBox11.Text,                                       //   "@general_apperance_glass_coma_score" ,
                                 textBox10.Text,                                       //   "@general_apperance_h_r" ,
                                 textBox9.Text,                                       //   "@general_apperance_r_r" ,
                                 textBox8.Text,                                       //   "@general_apperance_tempreture" ,
                                 textBox6.Text,                                       //   "@general_apperance_blood_pressure" ,
                                 textBox5.Text,                                       //   "@general_apperance_color" ,
                                 textBox4.Text,                                       //   "@general_apperance_turgor",
                                 textBox3.Text,                                        //  "@general_apperance_eruption" ,
                                 textBox20.Text,                                       //   "@head_neck_fascies" ,
                                 textBox15.Text,                                      //    "@head_neck_eyes" ,
                                 textBox16.Text,                                       //   "@head_neck_mouth_tongue" ,
                                 textBox17.Text,                                       //   "@head_neck_pharynx" ,
                                 textBox18.Text,                                       //   "@head_neck_lymph_nodes" ,
                                 textBox19.Text,                                       //   "@head_neck_oters" ,
                                 textBox22.Text,                                      //   "@heart_precordial_bulge" ,
                                 textBox21.Text,                                       //   "@heart_apex_beat" ,
                                 textBox23.Text,                                       //   "@heart_thrill",
                                 textBox25.Text,                                      //    "@heart_heart_sound" ,
                                 textBox26.Text,                                      //    "@heart_murmurs",
                                 textBox23.Text,                                      //    "@heart_others" ,
                                 textBox28.Text,                                      //    "@chest_shape" ,
                                 textBox29.Text,                                      //    "@chest_movement" ,
                                 textBox27.Text,                                     //     "@chest_reactions" ,
                                 textBox31.Text,                                     //     "@chest_air_entry" ,
                                 textBox32.Text,                                      //    "@chest_breath_sounds" ,
                                 textBox33.Text,                                      //    "@chest_adventure_sounds" ,
                                  s,                                    //     "@chest_costal" ,
                                 textBox34.Text,                                      //    "@abdomen_liver",
                                 textBox30.Text,                                      //    "@abdomen_spleen" ,
                                 textBox35.Text,                                     //     "@abdomen_kidneys" ,
                                 textBox36.Text,                                      //    "@abdomen_ascites" ,
                                 textBox37.Text,                                       //   "@abdomen_others" ,
                                 textBox40.Text,                                      //    "@back_spine_deformity" ,
                                 textBox39.Text,                                     //     "@back_spine_sweling" ,
                                 textBox43.Text,                                     //     "@neurological_examination_mentality" ,
                                 textBox44.Text                                     //     "@neurological_examination_cranial_nerves" 
               };
                SqlDbType[] param_types = new SqlDbType[]
            {
                SqlDbType.VarChar,
                SqlDbType.Int,
                SqlDbType.Date,
                SqlDbType.Int,
                SqlDbType.VarChar, 
                SqlDbType.Float,
                SqlDbType.Int,
                SqlDbType.VarChar, 
                SqlDbType.VarChar,
                SqlDbType.VarChar, 
                SqlDbType.VarChar,
                SqlDbType.Float, 
                SqlDbType.VarChar,
                SqlDbType.VarChar, 
                SqlDbType.VarChar,
                SqlDbType.VarChar, 
                SqlDbType.VarChar,
                SqlDbType.VarChar, 
                SqlDbType.VarChar,
                SqlDbType.VarChar, 
                SqlDbType.VarChar,
                SqlDbType.VarChar, 
                SqlDbType.VarChar,
                SqlDbType.VarChar, 
                SqlDbType.VarChar,
                SqlDbType.VarChar, 
                SqlDbType.VarChar,
                SqlDbType.VarChar, 
                SqlDbType.VarChar,
                SqlDbType.VarChar, 
                SqlDbType.VarChar,
				SqlDbType.VarChar,
                SqlDbType.VarChar, 
                SqlDbType.VarChar,
                SqlDbType.VarChar, 
                SqlDbType.VarChar,
                SqlDbType.VarChar, 
                SqlDbType.VarChar,
                SqlDbType.VarChar, 
				SqlDbType.VarChar,
                SqlDbType.VarChar, 
                SqlDbType.VarChar,
                SqlDbType.VarChar, 
				SqlDbType.VarChar
            };
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("insert_Examination", param_names, param_values, param_types);

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.OpenConection();
            int x = Int32.Parse(comboBox1.SelectedIndex.ToString());
            textBox45.Text = code[x].ToString();

            dr = con.DataReader("select visit_id from entranceoffice_visit where pat_id = '" + textBox45.Text + "'");
            while (dr.Read())
                textBox1.Text = dr[0].ToString();
            dr.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.OpenConection();
            dr = con.DataReader("select doc_ssn from doctors  where doctors.full_name = '" + comboBox2.SelectedItem.ToString() + "'");

            while (dr.Read())
                textBox7.Text = dr[0].ToString();


            dr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.OpenConection();
            dr.Close();
            dr = con.DataReader(" select * from Examination where inventry_id= '" + textBox1.Text + "' and doc_code= '" + textBox7.Text + "' and Examination_date=  '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' ");
            while (dr.Read())
            {
                

                 textBox7.Text=   dr[0].ToString();                    //    "@doc_code" ,
                 textBox1.Text=dr[1].ToString();                       //   "@inventry_id" ,
		                                                              //   "@Examination_date" ,
		                         textBox45.Text = dr[3].ToString();                                  //   "@patient_id"  ,
		                         textBox2.Text = dr[4].ToString();                                       //  "@general_apperance_built" ,
                                 textBox14.Text = dr[5].ToString();                                       //   "@general_apperance_weight" ,
                                 textBox13.Text= dr[6].ToString();                                      //    "@general_apperance_age" ,
                                 textBox12.Text= dr[7].ToString();                                       //   "@general_apperance_conscious_level" ,
                                 textBox11.Text= dr[8].ToString();                                       //   "@general_apperance_glass_coma_score" ,
                                 textBox10.Text= dr[9].ToString();                                       //   "@general_apperance_h_r" ,
                                 textBox9.Text= dr[10].ToString();                                      //   "@general_apperance_r_r" ,
                                 textBox8.Text= dr[11].ToString();                                       //   "@general_apperance_tempreture" ,
                                 textBox6.Text= dr[12].ToString();                                       //   "@general_apperance_blood_pressure" ,
                                 textBox5.Text= dr[13].ToString();                                       //   "@general_apperance_color" ,
                                 textBox4.Text= dr[14].ToString();                                       //   "@general_apperance_turgor",
                                 textBox3.Text= dr[15].ToString();                                        //  "@general_apperance_eruption" ,
                                 textBox20.Text= dr[16].ToString();                                       //   "@head_neck_fascies" ,
                                 textBox15.Text= dr[17].ToString();                                      //    "@head_neck_eyes" ,
                                 textBox16.Text = dr[18].ToString();                                       //   "@head_neck_mouth_tongue" ,
                                 textBox17.Text= dr[19].ToString();                                      //   "@head_neck_pharynx" ,
                                 textBox18.Text= dr[20].ToString();                                       //   "@head_neck_lymph_nodes" ,
                                 textBox19.Text= dr[21].ToString();                                       //   "@head_neck_oters" ,
                                 textBox22.Text= dr[22].ToString();                                     //   "@heart_precordial_bulge" ,
                                 textBox21.Text= dr[23].ToString();                                       //   "@heart_apex_beat" ,
                                 textBox23.Text= dr[24].ToString();                                       //   "@heart_thrill",
                                 textBox25.Text= dr[25].ToString();                                      //    "@heart_heart_sound" ,
                                 textBox26.Text= dr[26].ToString();                                      //    "@heart_murmurs",
                                 textBox23.Text= dr[27].ToString();                                      //    "@heart_others" ,
                                 textBox28.Text= dr[28].ToString();                                     //    "@chest_shape" ,
                                 textBox29.Text= dr[29].ToString();                                     //    "@chest_movement" ,
                                 textBox27.Text= dr[30].ToString();                                    //     "@chest_reactions" ,
                                 textBox31.Text= dr[31].ToString();                                     //     "@chest_air_entry" ,
                                 textBox32.Text= dr[32].ToString();                                      //    "@chest_breath_sounds" ,
                                 textBox33.Text= dr[33].ToString();                                      //    "@chest_adventure_sounds" ,
                                  s= dr[34].ToString();                                   //     "@chest_costal" ,
                                 textBox34.Text= dr[35].ToString();                                      //    "@abdomen_liver",
                                 textBox30.Text= dr[36].ToString();                                      //    "@abdomen_spleen" ,
                                 textBox35.Text= dr[37].ToString();                                    //     "@abdomen_kidneys" ,
                                 textBox36.Text= dr[38].ToString();                                     //    "@abdomen_ascites" ,
                                 textBox37.Text= dr[39].ToString();                                      //   "@abdomen_others" ,
                                 textBox40.Text= dr[40].ToString();                                     //    "@back_spine_deformity" ,
                                 textBox39.Text= dr[41].ToString();                                     //     "@back_spine_sweling" ,
                                 textBox43.Text= dr[42].ToString();                                     //     "@neurological_examination_mentality" ,
                                 textBox44.Text = dr[43].ToString();                                     //     "@neurological_examination_cranial_nerves" 
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.numbervalidation(textBox2, "this value");
            //      textBox2.Text = "";
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.numbervalidation(textBox14, "this value");
            //      textBox14.Text = "";
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.numbervalidation(textBox13, "this value");
            //      textBox13.Text = "";
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.numbervalidation(textBox12, "this value");
            //    textBox12.Text = "";
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.numbervalidation(textBox11, "this value");
            //       textBox11.Text = "";
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.numbervalidation(textBox10, "this value");
            //     textBox10.Text = "";
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.numbervalidation(textBox9, "this value");
            //     textBox9.Text = "";
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.numbervalidation(textBox8, "this value");
            //    textBox8.Text = "";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.numbervalidation(textBox6, "this value");
            //    textBox6.Text = "";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.numbervalidation(textBox5, "this value");
            //     textBox5.Text = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.numbervalidation(textBox4, "this value");
            //     textBox4.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.numbervalidation(textBox3, "this value");
            //     textBox3.Text = "";
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox20, "this value");
            //     textBox20.Text = "";
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox15, "this value");
            //      textBox15.Text = "";
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox16, "this value");
            //    textBox16.Text = "";
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox17, "this value");
            //     textBox17.Text = "";
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox18, "this value");
            //    textBox18.Text = "";
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox19, "this value");
            //    textBox19.Text = "";
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox22, "this value");
            //    textBox22.Text = "";
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox21, "this value");
            //      textBox21.Text = "";
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox23, "this value");
            //    textBox23.Text = "";
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox25, "this value");
            //    textBox25.Text = "";
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox26, "this value");
            //    textBox26.Text = "";
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox24, "this value");
            //    textBox24.Text = "";
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox28, "this value");
            //   textBox28.Text = "";
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox27, "this value");
            //    textBox27.Text = "";
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox29, "this value");
            //    textBox29.Text = "";
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox31, "this value");
            //   textBox31.Text = "";
        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox32, "this value");
            //   textBox32.Text = "";
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox33, "this value");
            //     textBox33.Text = "";
        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox34, "this value");
            //      textBox34.Text = "";
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox30, "this value");
            //
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox35, "this value");
           
        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox36, "this value");
            
        }

        private void textBox37_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox37, "this value");
            
        }

        private void textBox38_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox38, "this value");
          
        }

        private void textBox40_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox40, "this value");
           
        }

        private void textBox39_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox39, "this value");
           
        }

        private void textBox43_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox43, "this value");
           
        }

        private void textBox44_TextChanged(object sender, EventArgs e)
        {
            validation v = new validation();

            v.stringvalidation(textBox44, "this value");
            
        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }
    }
}
