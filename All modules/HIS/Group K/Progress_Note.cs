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
    public partial class Progress_Note : Form
    {
        Connection con = new Connection();
        SqlDataReader dr;
        ArrayList code = new ArrayList();
        public Progress_Note()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Progress_Note_Load(object sender, EventArgs e)
        {

            Connection con = new Connection();
            con.OpenConection();
            textBox15.Enabled = false;
            textBox16.Enabled = false;
            textBox17.Enabled = false;

            // اسم كل الدكاتره  
            if (comboBox2.Items.Count > 0)
                comboBox2.Items.Clear();

            dr = con.DataReader("select full_name from doctors  ");
            while (dr.Read())
                comboBox2.Items.Add(dr[0].ToString());
            dr.Close();

            // اسماء كل المرضي 

            if (comboBox1.Items.Count > 0)
                comboBox1.Items.Clear();

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
            "@doc_code"
           ,"@inventry_id "
           ,"@examination "
           ,"@examination_weight "
           ,"@examination_cosiciouslevl "
           ,"@vitalsign_hr "
           ,"@vitalsign_rr "
           ,"@vitalsign_tempreture "
           ,"@vitalsign_blood_pressure "
           ,"@progress_note_date "
           ,"@head_neck "
           ,"@chest "
           ,"@heart "
           ,"@abdomen"
           ,"@upper_and_lower_limbs "
           ,"@current_medicine "
           ,"@observer_doctor "
               
      }; // الامراض الوراثسيه والعائليه للمريض 




                                                     //  @doc_code1      @iventry id2    @examonation3          @weight4            @cosiciouslevl5        @hr 6             @rr 7              @tempreture 8          @blood pressure  9           @date10                                @head_neck11          @chest 12             @heart13            @abdomen 14            @limbs15          @current_medicine16  @DOCTOR17               
            string[] param_values = new string[]      { textBox16.Text , textBox17.Text, textBox1.Text       , textBox6.Text    , textBox8.Text    , textBox2.Text    , textBox5.Text     , textBox3.Text     , textBox4.Text     , dateTimePicker1.Value.ToString("yyyy-MM-dd") ,  textBox9.Text    , textBox10.Text   , textBox11.Text   ,  textBox12.Text   ,textBox13.Text   ,textBox14.Text   , comboBox2.SelectedItem.ToString()   };
            SqlDbType[] param_types = new SqlDbType[] { SqlDbType.VarChar , SqlDbType.Int , SqlDbType.VarChar   , SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar  , SqlDbType.VarChar , SqlDbType.Date                               ,  SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar,  SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar                   };
            con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("insert_progress_notes", param_names, param_values, param_types);
        
           
            validation v = new validation();
            v.stringvalidation(textBox1, "this value ");
            v.numbervalidation(textBox2, "this value");
            v.numbervalidation(textBox3, "this value");
            v.numbervalidation(textBox4, "this value");
            v.numbervalidation(textBox5, "this value");
            v.numbervalidation(textBox6, "this value");
          
            v.numbervalidation(textBox8, "this value");
            v.stringvalidation(textBox9, "this value");
            v.stringvalidation(textBox10, "this value");
            v.stringvalidation(textBox11, "this value");
            v.stringvalidation(textBox12, "this value");
            v.stringvalidation(textBox14, "this value");
            v.stringvalidation(textBox13, "this value");


            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
          
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.OpenConection();
            dr = con.DataReader("select doc_ssn from doctors  where doctors.full_name = '" + comboBox2.SelectedItem.ToString() + "'");

            while (dr.Read())
                textBox16.Text = dr[0].ToString();


            dr.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.OpenConection();
            int x = Int32.Parse(comboBox1.SelectedIndex.ToString());
            textBox15.Text = code[x].ToString();

            dr = con.DataReader("select visit_id from entranceoffice_visit where pat_id = '" + textBox15.Text + "'");
            while (dr.Read())
                textBox17.Text = dr[0].ToString();
            dr.Close();
        }
    }
}
