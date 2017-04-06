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
    public partial class follow_up_sheet : Form
    {
        Connection con = new Connection();
        SqlDataReader dr;
        ArrayList code = new ArrayList();
        public follow_up_sheet()
        {

            InitializeComponent();

        }

        private void Follow_Up_Sheet_Load(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.OpenConection();
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;

            comboBox8.Items.Add("مريض مقيم ");
            comboBox8.Items.Add("مريض عيادات خارجيه  ");
           
            // اسم كل الدكاتره  
            if (comboBox7.Items.Count > 0)
                comboBox7.Items.Clear();

            dr = con.DataReader("select full_name from doctors  ");
            while (dr.Read())
                comboBox7.Items.Add(dr[0].ToString());
            dr.Close();

            if (comboBox2.Items.Count > 0)
                comboBox2.Items.Clear();
            
                 // اسماء كل المرضي 
   
         
           dr = con.DataReader("SELECT patient_name, patient_id FROM [dbo].[Registeration_patientRegisteration]");
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
                code.Add(dr[1].ToString());

            }
            dr.Close();
        
            ///////////////////////////////////////////////////////////////////////
       
                       // الادويه 
            if (comboBox4.Items.Count > 0)
                comboBox4.Items.Clear();

            // listbox selected event multi item

            dr = con.DataReader("select medicine_name from med_medicine ");
            while (dr.Read())
                comboBox4.Items.Add(dr[0].ToString());
            dr.Close();
           
            //
            if (comboBox5.Items.Count > 0)
                comboBox5.Items.Clear();

            // listbox selected event multi item
            // العمليات 
            dr = con.DataReader("SELECT op_name FROM [dbo].[operations] ");
            while (dr.Read())
                comboBox5.Items.Add(dr[0].ToString());
            // 
            dr.Close();

            //
            if (comboBox6.Items.Count > 0)
                comboBox6.Items.Clear();

            // listbox selected event multi item
            // المناظير
            dr = con.DataReader("SELECT [EndoscopeName]  FROM [dbo].[Endoscope_settings_data] ");
            while (dr.Read())
                comboBox6.Items.Add(dr[0].ToString());
            // 
            dr.Close();

            //
            if (comboBox2.Items.Count > 0)
                comboBox2.Items.Clear();

            // listbox selected event multi item

            dr = con.DataReader("SELECT [EndoscopeName]  FROM [dbo].[Endoscope_settings_data] ");
            while (dr.Read())
                comboBox2.Items.Add(dr[0].ToString());
            // 

            dr.Close();

            //
            if (comboBox3.Items.Count > 0)
                comboBox3.Items.Clear();

            // listbox selected event multi item

            dr = con.DataReader("SELECT [sample_name ]  FROM [dbo].[analysis_samples] ");
            while (dr.Read())
                comboBox3.Items.Add(dr[0].ToString());
            // 

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var items = new ArrayList(listBox3.Items);
            listBox3.Items.Clear();


            listBox3.Items.Add(comboBox4.SelectedItem);
            foreach (var item in items)
            {
                if (item.ToString().StartsWith(""))
                    listBox3.Items.Add(item.ToString());
            }


            // عاوز اعمل insert جوا الداتا بيز الجدول اسمه  (follow_up_sheet_slected_med)
            // بياخد القيم بتاعته من ال selected list box 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBox3);
            selectedItems = listBox3.SelectedItems;

            if (listBox3.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listBox3.Items.Remove(selectedItems[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            for (int i = 0; i < listBox3.Items.Count; i++)
            {

                string st1 = listBox3.Items[i].ToString();
                con.ExecuteQueries("INSERT INTO [dbo].[follow_up_sheet_slected_med] ([med_name])VALUES( '" + st1 + "'  )");



            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            for (int i = 0; i < listBox5.Items.Count; i++)
            {

                string st1 = listBox5.Items[i].ToString();
                con.ExecuteQueries("INSERT INTO [dbo].[follow_up_operation] ([surgery_name ])VALUES( '" + st1 + "'  )");

            }




        }

        private void button15_Click(object sender, EventArgs e)
        {

            var items = new ArrayList(listBox5.Items);
            listBox5.Items.Clear();


            listBox5.Items.Add(comboBox5.SelectedItem);
            foreach (var item in items)
            {
                if (item.ToString().StartsWith(""))
                    listBox5.Items.Add(item.ToString());
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBox5);
            selectedItems = listBox5.SelectedItems;

            if (listBox5.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listBox5.Items.Remove(selectedItems[i]);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            for (int i = 0; i < listBox6.Items.Count; i++)
            {

                string st1 = listBox6.Items[i].ToString();
                con.ExecuteQueries("INSERT INTO [dbo].[follow_up_Endoscopes_setting_data] ([Endoscope_name ])VALUES( '" + st1 + "'  )");

            }
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

            var items = new ArrayList(listBox6.Items);
            listBox6.Items.Clear();


            listBox6.Items.Add(comboBox6.SelectedItem);
            foreach (var item in items)
            {
                if (item.ToString().StartsWith(""))
                    listBox6.Items.Add(item.ToString());
            }

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBox6);
            selectedItems = listBox6.SelectedItems;

            if (listBox6.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listBox6.Items.Remove(selectedItems[i]);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {

                string st1 = listBox1.Items[i].ToString();
                con.ExecuteQueries("INSERT INTO [dbo].[follow_up_sol] ([sol_name])VALUES( '" + st1 + "'  )");



            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var items = new ArrayList(listBox1.Items);
            listBox1.Items.Clear();


            listBox1.Items.Add(comboBox2.SelectedItem);
            foreach (var item in items)
            {
                if (item.ToString().StartsWith(""))
                    listBox1.Items.Add(item.ToString());
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBox1);
            selectedItems = listBox1.SelectedItems;

            if (listBox1.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listBox1.Items.Remove(selectedItems[i]);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            con.OpenConection();
            for (int i = 0; i < listBox4.Items.Count; i++)
            {

                string st1 = listBox4.Items[i].ToString();
                con.ExecuteQueries("INSERT INTO [dbo].[follow_up_sol] ([sol_name])VALUES( '" + st1 + "'  )");



            }
        }

        private void button12_Click(object sender, EventArgs e)
        {

            var items = new ArrayList(listBox4.Items);
            listBox4.Items.Clear();


            listBox4.Items.Add(comboBox3.SelectedItem);
            foreach (var item in items)
            {
                if (item.ToString().StartsWith(""))
                    listBox4.Items.Add(item.ToString());
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedItems = new ListBox.SelectedObjectCollection(listBox4);
            selectedItems = listBox4.SelectedItems;

            if (listBox4.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listBox4.Items.Remove(selectedItems[i]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.OpenConection();







            string[] param_names = new string[] {  
             "@doc_code"  // كود الدكتور فورن كي من الدكتور 
           ,"@inventry_id " // كود الزياره من جدول الزياره 
           ,"@follow_up_sheet_date " // تاريخ الروشته 
           ,"@observer_doctor" // اسم الدكتور اللي كتب الروشته 
           ,"@examination_notes"  // الملاحظات الطبيه في الروشته 
           ,"@medicin " // الادويه 
           ,"@sol " // التحاليل 
           ,"@investigation" // التشخيص // المنظار مش عارفه فين 
           ,"@operations " // العمليات 
           ,"@rays" // الاشعه 
            }; // الامراض الوراثسيه والعائليه للمريض 
        
                                                  //@doc_code            @age   اسم الدكتور               @name       اسمالمريض             @iventry id                @date                                 @present                          @past                            @family 
            string[] param_values = new string[]      { textBox3.Text     , textBox4.Text     , dateTimePicker1.Value.ToString("yyyy-MM-dd"), comboBox7.SelectedItem.ToString(), textBox1.Text     ,  listBox3.Items.ToString()  ,  listBox4.Items.ToString(),   listBox6.Items.ToString() ,listBox5.Items.ToString()  , listBox1.Items.ToString()  };
            SqlDbType[] param_types = new SqlDbType[] {  SqlDbType.VarChar, SqlDbType.VarChar , SqlDbType.Date                              , SqlDbType.VarChar                , SqlDbType.VarChar ,  SqlDbType.VarChar          , SqlDbType.VarChar         ,  SqlDbType.VarChar          , SqlDbType.VarChar         , SqlDbType.VarChar          };
            con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("insert_follow_up_sheet", param_names, param_values, param_types);


            validation v = new validation();


        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.OpenConection();
            dr = con.DataReader("select doc_ssn from doctors  where doctors.full_name = '" + comboBox7.SelectedItem.ToString() + "'");

            while (dr.Read())
                textBox3.Text = dr[0].ToString();


            dr.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Connection con = new Connection();
            con.OpenConection();
            int x = Int32.Parse(comboBox1.SelectedIndex.ToString());
            textBox2.Text = code[x].ToString();
           
            dr = con.DataReader("select visit_id from entranceoffice_visit where pat_id = '" + textBox2.Text + "'");
            while (dr.Read())
                textBox4.Text = dr[0].ToString();
            dr.Close();
        }
    }
}
