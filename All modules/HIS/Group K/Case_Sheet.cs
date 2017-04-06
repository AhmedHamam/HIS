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
    public partial class Case_Sheet : Form
    {
        Connection con = new Connection();
        SqlDataReader dr;
        ArrayList code  = new ArrayList();
        string s;
               
        public Case_Sheet()
        {
            InitializeComponent();
        }

        private void Case_Sheet_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            if (comboBox1.Items.Count > 0)
                comboBox1.Items.Clear();

            textBox2.Enabled = false;
            // اسماء كل المرضي 
            dr = con.DataReader("SELECT patient_name, patient_id FROM [dbo].[Registeration_patientRegisteration]");
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
                code.Add(dr[1].ToString());

            }
         //   textBox1.Text = code[0].ToString();
            //////////////
            dr.Close();
        
            ///////////////////////////////////////////////////////////////////////
            // اسم كل الدكاتره  
                       if (comboBox2.Items.Count > 0)
                            comboBox2.Items.Clear();

                     dr = con.DataReader("select full_name , doc_ssn from doctors  ");
                        while (dr.Read())
                            comboBox2.Items.Add(dr[0].ToString());
                        dr.Close();

        }





        private void button1_Click(object sender, EventArgs e)
        {
           
          
            Connection con = new Connection();
            con.OpenConection();





  
        
            string[] param_names = new string[] {  
                "@doc_code"
            ,    "@age" // دا اسم الدكتور بس مش عاوز اغير الاسم في الداتا بيز 
        , "@name"
           ,"@inventry_id"
     
           ,"@admission_Date" // تاريخ كتابة الحاله الصحيه للمريض 
           ,"@present_history" // الحاله الصحيه الحاليه للمريض 
           ,"@past_history "  // التاريخ المرضي للمريض 
           ,"@familay_history"
               
            }; // الامراض الوراثسيه والعائليه للمريض 
            s = comboBox1.SelectedItem.ToString();

            textBox6.Text = s;

                                                     //@doc_code            @age   اسم الدكتور               @name       اسمالمريض             @iventry id                @date                                 @present                          @past                            @family 
            string[] param_values = new string[]      { textBox3.Text    , comboBox2.SelectedItem.ToString() , comboBox1.SelectedItem.ToString()   , textBox2.Text          , dateTimePicker1.Value.ToString("yyyy-MM-dd"), textBox4.Text                   , textBox5.Text               , textBox6.Text                    };
            SqlDbType[] param_types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar                 , SqlDbType.VarChar                   , SqlDbType.Int          ,   SqlDbType.Date                            ,  SqlDbType.VarChar              , SqlDbType.VarChar           , SqlDbType.VarChar                };
            con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("insert_case_sheet", param_names, param_values, param_types);
        
           
            validation v = new validation();
             

            v.stringvalidation(textBox4, "this value ");
            v.stringvalidation(textBox5, "this value ");
            v.stringvalidation(textBox6, "this value ");

         
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

         int x=   Int32.Parse(comboBox1.SelectedIndex.ToString());
         textBox1.Text = code[x].ToString();
         s = comboBox1.SelectedItem.ToString();

            dr = con.DataReader("select visit_id from entranceoffice_visit where pat_id = '"+textBox1.Text+"'");
           
            while (dr.Read()) 
               textBox2.Text= dr[0].ToString();
            dr.Close();
             
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dr = con.DataReader("select doc_ssn from doctors  where doctors.full_name = '" + comboBox2.SelectedItem.ToString() + "'");

            while (dr.Read())
                textBox3.Text = dr[0].ToString();

          
            dr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dr.Close();
            dr = con.DataReader( " select [present_history] ,[past_history],[familay_history] FROM [dbo].[case_sheet] where inventry_id= '" + textBox2.Text + "' and doc_code= '" + textBox3.Text + "'  ");
            while (dr.Read())
            {
                textBox4.Text = dr[0].ToString();
                textBox5.Text = dr[1].ToString();
                textBox6.Text = dr[2].ToString();
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                textBox6.Enabled = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

  
    }
}
