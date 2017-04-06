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
    public partial class Intial_Assessment : Form
    {
        Connection con = new Connection();
        SqlDataReader dr;
        ArrayList code = new ArrayList();
        string s = "";
        public Intial_Assessment()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Intial_Assessment_Load(object sender, EventArgs e)
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
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Connection con = new Connection();
            con.OpenConection();


            string[] param_names = new string[] {  
           "@intial_assesment_date"
            ,"@inventry_id"
          ,"@doc_code"
           ,"@weightt" 
           ,"@head"
           ,"@lenght" 
           ,"@abdominalc" 
           ,"@void_urine "
           ,"@tempreture "
           ,"@heart_rate" 
           ,"@respiratory" 
           ,"@pass_stool" 
           ,"@physical_examination_color" 
           ,"@physical_examination_head" 
           ,"@physical_examination_fontanels"
           ,"@physical_examination_eyes" 
           ,"@physical_examination_ears" 
           ,"@physical_examination_nose" 
           ,"@physical_examination_mouth"
           ,"@physical_examination_neck" 
           ,"@physical_examination_calavicles "
           ,"@physical_examination_breast "
           ,"@physical_examination_thorax "
           ,"@physical_examination_activity" 
           ,"@physical_examination_heart "
           ,"@physical_examination_abdomen" 
           ,"@physical_examination_liver "
           ,"@physical_examination_spleen "
           ,"@physical_examination_lungs "
           ,"@physical_examination_hernia "
           ,"@physical_examination_umbilicus "
           ,"@physical_examination_genitilia "
           ,"@physical_examination_anus "
           ,"@physical_examination_deformit" 
           ,"@physical_examination_skin "
           ,"@physical_examination_extemities" 
           ,"@physical_examination_solo_crease "
           ,"@physical_examination_reflexes "
           ,"@physical_examination_moro "
           ,"@physical_examination_grasp "
           ,"@physical_examination_light "
           ,"@physical_examination_glabellar" 
           ,"@physical_examination_rooting "
           ,"@physical_examination_suckling "
           ,"@immpression_tatitional_age "
           ,"@immpression_weeks "
           ,"@immpression_provisional_diagnosis "
           ,"@immpression_date"
               
            }; // الامراض الوراثسيه والعائليه للمريض 


            //@doc_code            @age   اسم الدكتور               @name       اسمالمريض             @iventry id                @date                                 @present                          @past                            @family 
            string[] param_values = new string[]
            
            { 
               
                    dateTimePicker1.Value.ToString("yyyy-MM-dd"),  
                                 textBox45.Text,            //   "@initial_assessment_date" ,        
                                 textBox46.Text,                       //    "@doc_code" ,                                                  //   weight ,
		                         textBox15.Text,                                        // head
                                 textBox1.Text, 
                                 textBox14.Text,                            //   length
		                         textBox2.Text,                                //   "@patient_id"  ,
                                 textBox7.Text,                                      //    "@general_apperance_age" ,
                                 textBox8.Text,                                       //   "@general_apperance_conscious_level" ,
                                 textBox3.Text,                                       //   "@general_apperance_glass_coma_score" ,
                                 textBox4.Text,                                       //   "@general_apperance_h_r" ,
                                 textBox6.Text,                                       //   "@general_apperance_r_r" ,
                                 textBox5.Text,                                       //   "@general_apperance_tempreture" ,
                                 textBox17.Text,                                       //   "@general_apperance_blood_pressure" ,
                                 textBox16.Text,                                       //   "@general_apperance_color" ,
                                 textBox11.Text,                                       //   "@general_apperance_turgor",
                                 textBox9.Text,                                        //  "@general_apperance_eruption" ,
                                 textBox10.Text,                                       //   "@head_neck_fascies" ,
                                 textBox18.Text,                                      //    "@head_neck_eyes" ,
                                 textBox12.Text,                                       //   "@head_neck_mouth_tongue" ,
                                 textBox13.Text,                                       //   "@head_neck_pharynx" ,
                                 textBox19.Text,                                       //   "@head_neck_lymph_nodes" ,
                                 textBox40.Text,                                       //   "@head_neck_oters" ,
                                 textBox29.Text,                                      //   "@heart_precordial_bulge" ,
                                 textBox27.Text,                                       //   "@heart_apex_beat" ,
                                 textBox28.Text,                                       //   "@heart_thrill",
                                 textBox26.Text,                                      //    "@heart_heart_sound" ,
                                 textBox24.Text,                                      //    "@heart_murmurs",
                                 textBox25.Text,                                      //    "@heart_others" ,
                                 textBox21.Text,                                      //    "@chest_shape" ,
                                 textBox22.Text,                                      //    "@chest_movement" ,
                                 textBox20.Text,
                                  textBox23.Text,//     "@chest_reactions" ,
                                 textBox39.Text,                                     //     "@chest_air_entry" ,
                                 textBox37.Text,                                      //    "@chest_breath_sounds" ,
                                 textBox38.Text,                                      //    "@chest_adventure_sounds" ,
                                 textBox36.Text,                                      //    "@abdomen_liver",
                                 textBox34.Text,                                      //    "@abdomen_spleen" ,
                                 textBox35.Text,                                     //     "@abdomen_kidneys" ,
                                 textBox33.Text,                                      //    "@abdomen_ascites" ,
                                 textBox31.Text,                                       //   "@abdomen_others" ,
                                 textBox32.Text,                                      //    "@back_spine_deformity" ,
                                 textBox30.Text,                                     //     "@back_spine_sweling" ,
                                 textBox43.Text,                                     //     "@neurological_examination_mentality" ,
                                 textBox44.Text ,
                                    textBox42.Text ,
                                           textBox41.Text ,
                                           dateTimePicker2.Value.ToString("yyyy-MM-dd")
                                 //     "@neurological_examination_cranial_nerves" 
               };
            SqlDbType[] param_types = new SqlDbType[]
            {
                SqlDbType.Date,
                SqlDbType.Int,
                SqlDbType.VarChar,
                SqlDbType.Float,
                SqlDbType.VarChar,
                SqlDbType.Float,
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
                SqlDbType.VarChar, 
                SqlDbType.VarChar,
                SqlDbType.VarChar, 
				SqlDbType.VarChar,
                SqlDbType.VarChar, 
                SqlDbType.VarChar,
                SqlDbType.VarChar, 
				SqlDbType.Date
            };
            con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("insert_initial_assessment", param_names, param_values, param_types);










            validation v = new validation();
            
            v.numbervalidation(textBox15, "this value");
            v.numbervalidation(textBox8, "this value");
            v.numbervalidation(textBox1, "this value");
            v.numbervalidation(textBox3, "this value");
            v.numbervalidation(textBox6, "this value");
            v.numbervalidation(textBox14, "this value");
            v.numbervalidation(textBox4, "this value");
            v.numbervalidation(textBox2, "this value");
            v.numbervalidation(textBox6, "this value");
            v.numbervalidation(textBox7, "this value");
            v.stringvalidation(textBox5, "this value");
            v.stringvalidation(textBox17, "this value");
            v.stringvalidation(textBox16, "this value");
            v.stringvalidation(textBox11, "this value");
            v.stringvalidation(textBox9, "this value");
            v.stringvalidation(textBox10, "this value");
            v.stringvalidation(textBox18, "this value");
            v.stringvalidation(textBox12, "this value");
            v.stringvalidation(textBox13, "this value");
            v.stringvalidation(textBox19, "this value");
            v.stringvalidation(textBox40, "this value");
            v.stringvalidation(textBox23, "this value");
            v.stringvalidation(textBox20, "this value");
            v.stringvalidation(textBox22, "this value");
            v.stringvalidation(textBox21, "this value");
            v.stringvalidation(textBox25, "this value");
            v.stringvalidation(textBox24, "this value");
            v.stringvalidation(textBox23, "this value");
            v.stringvalidation(textBox24, "this value");
            v.stringvalidation(textBox27, "this value");
            v.stringvalidation(textBox28, "this value");
            v.stringvalidation(textBox29, "this value");
            v.stringvalidation(textBox30, "this value");
            v.stringvalidation(textBox31, "this value");
            v.stringvalidation(textBox32, "this value");
            v.stringvalidation(textBox33, "this value");
            v.stringvalidation(textBox34, "this value");
            v.stringvalidation(textBox35, "this value");
            v.stringvalidation(textBox36, "this value");
            v.stringvalidation(textBox37, "this value");
            v.stringvalidation(textBox38, "this value");
            v.stringvalidation(textBox39, "this value");
            v.stringvalidation(textBox40, "this value");
            v.stringvalidation(textBox41, "this value");
            v.stringvalidation(textBox42, "this value");
            v.stringvalidation(textBox43, "this value");
            v.stringvalidation(textBox44, "this value");

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = ""; 
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = ""; 
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = ""; 
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = ""; 
            textBox26.Text = "";
            textBox27.Text = "";
            textBox28.Text = "";
            textBox29.Text = ""; 
            textBox30.Text = "";
            textBox31.Text = "";
            textBox32.Text = "";
            textBox33.Text = "";
            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
            textBox37.Text = "";
            textBox38.Text = "";
            textBox39.Text = "";
            textBox40.Text = "";
            textBox41.Text = "";
            textBox42.Text = "";
            textBox43.Text = "";
            textBox44.Text = "";
           
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.OpenConection();
            int x = Int32.Parse(comboBox1.SelectedIndex.ToString());
            textBox47.Text = code[x].ToString();

            dr = con.DataReader("select visit_id from entranceoffice_visit where pat_id = '" + textBox47.Text + "'");
            while (dr.Read())
                textBox45.Text = dr[0].ToString();
            dr.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.OpenConection();
            dr = con.DataReader("select doc_ssn from doctors  where doctors.full_name = '" + comboBox2.SelectedItem.ToString() + "'");

            while (dr.Read())
                textBox46.Text = dr[0].ToString();


            dr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.OpenConection();
            dr.Close();
            dr = con.DataReader(" select * from initial_assessment where inventry_id= '" + textBox45.Text + "' and doc_code= '" + textBox46.Text + "' and intial_assesment_date =  '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' ");
            while (dr.Read())
            {


                textBox45.Text = dr[1].ToString();             //   "@initial_assessment_date" ,        
                textBox46.Text = dr[2].ToString();                        //    "@doc_code" ,                                                  //   weight ,
                textBox15.Text = dr[3].ToString();                                         // head
                textBox1.Text = dr[4].ToString();
                textBox14.Text = dr[5].ToString();                             //   length
                textBox2.Text = dr[6].ToString();                                 //   "@patient_id"  ,
                textBox7.Text = dr[7].ToString();                                       //    "@general_apperance_age" ,
                textBox8.Text = dr[8].ToString();                                        //   "@general_apperance_conscious_level" ,
                textBox3.Text = dr[9].ToString();                                        //   "@general_apperance_glass_coma_score" ,
                textBox4.Text = dr[10].ToString();                                        //   "@general_apperance_h_r" ,
                textBox6.Text = dr[11].ToString();                                        //   "@general_apperance_r_r" ,
                textBox5.Text = dr[12].ToString();                                        //   "@general_apperance_tempreture" ,
                textBox17.Text = dr[13].ToString();                                        //   "@general_apperance_blood_pressure" ,
                textBox16.Text = dr[14].ToString();                                        //   "@general_apperance_color" ,
                textBox11.Text = dr[15].ToString();                                        //   "@general_apperance_turgor",
                textBox9.Text = dr[16].ToString();                                         //  "@general_apperance_eruption" ,
                textBox10.Text = dr[17].ToString();                                        //   "@head_neck_fascies" ,
                textBox18.Text = dr[18].ToString();                                       //    "@head_neck_eyes" ,
                textBox12.Text = dr[19].ToString();                                        //   "@head_neck_mouth_tongue" ,
                textBox13.Text = dr[20].ToString();                                        //   "@head_neck_pharynx" ,
                textBox19.Text = dr[21].ToString();                                        //   "@head_neck_lymph_nodes" ,
                textBox40.Text = dr[22].ToString();                                        //   "@head_neck_oters" ,
                textBox29.Text = dr[23].ToString();                                      //   "@heart_precordial_bulge" ,
                textBox27.Text = dr[24].ToString();                                        //   "@heart_apex_beat" ,
                textBox28.Text = dr[25].ToString();                                        //   "@heart_thrill",
                textBox26.Text = dr[26].ToString();                                       //    "@heart_heart_sound" ,
                textBox24.Text = dr[27].ToString();                                      //    "@heart_murmurs",
                textBox25.Text = dr[28].ToString(); //    "@heart_others" ,
                textBox21.Text = dr[29].ToString();                                       //    "@chest_shape" ,
                textBox22.Text = dr[30].ToString();                                      //    "@chest_movement" ,
                textBox20.Text = dr[31].ToString();
                textBox23.Text = dr[32].ToString(); //     "@chest_reactions" ,
                textBox39.Text = dr[33].ToString();                                      //     "@chest_air_entry" ,
                textBox37.Text = dr[34].ToString();                                      //    "@chest_breath_sounds" ,
                textBox38.Text = dr[35].ToString();                                       //    "@chest_adventure_sounds" ,
                textBox36.Text = dr[36].ToString();                                       //    "@abdomen_liver",
                textBox34.Text = dr[37].ToString();                                       //    "@abdomen_spleen" ,
                textBox35.Text = dr[38].ToString();                                      //     "@abdomen_kidneys" ,
                textBox33.Text = dr[39].ToString();                                       //    "@abdomen_ascites" ,
                textBox31.Text = dr[40].ToString();                                        //   "@abdomen_others" ,
                textBox32.Text = dr[41].ToString();                                       //    "@back_spine_deformity" ,
                textBox30.Text = dr[42].ToString();                                      //     "@back_spine_sweling" ,
                textBox43.Text = dr[43].ToString();                                      //     "@neurological_examination_mentality" ,
                textBox44.Text = dr[44].ToString();
                textBox42.Text = dr[45].ToString();
                textBox41.Text = dr[46].ToString();
            }
        }
    }
}
