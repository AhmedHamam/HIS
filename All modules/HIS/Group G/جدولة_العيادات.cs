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
    public partial class جدولة_العيادات : Form
    {
        int code = 0, shift1 = 1, shift2 = 2, shift3 = 3, idDoc = 0, idDoc1 = 0, idDoc2=0;
        string name="",to,from,to2,from2,to3,from3;
        char to1;
        int count_clinic = 0;
        
        //SqlCommand cmd;
       // SqlConnection con;
        SqlDataReader dr;

        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        

        public جدولة_العيادات( int c,string n)
        {
            InitializeComponent();
            code = c;
            name = n;
            textBox1.Text = code.ToString();
            textBox2.Text = name;
            panel4.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
          //  ShowListBox();
            set_dates(true, 1);
        }
        //For Add the clinic
        public جدولة_العيادات()
        {
            InitializeComponent();
            panel4.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            set_dates(true, 1);
        }

        //Set dates for or mouth
        void set_dates(bool flage,int index)
        {
            DateTime today = DateTime.Today;
            int saturday = (int)DayOfWeek.Saturday;
            int current = (int)today.DayOfWeek;
            DateTime sat = today.AddDays(-current + saturday);
            DateTime sat1 = today.AddDays(-current);
            DateTime mon = sat.AddDays(1);
            DateTime mon1 = sat1.AddDays(1);
            //For make only next week
            if (current >= 0 && flage == true)
            {
                mon = mon.AddDays(-index);
                
                var dates = Enumerable.Range(0, 7).Select(days => mon.AddDays(days)).ToList();

                label24.Text = dates[0].Date.ToString("yyyy-MM-dd");
                label25.Text = dates[1].Date.ToString("yyyy-MM-dd");
                label26.Text = dates[2].Date.ToString("yyyy-MM-dd");
                label27.Text = dates[3].Date.ToString("yyyy-MM-dd");
                label69.Text = dates[4].Date.ToString("yyyy-MM-dd");
                label70.Text = dates[5].Date.ToString("yyyy-MM-dd");
                label71.Text = dates[6].Date.ToString("yyyy-MM-dd");
            }
                //for make only current week
            else if(current>=0 &&flage==false) 
            {
                mon1 = mon1.AddDays(-current);
                var dates1 = Enumerable.Range(0, 7).Select(days => mon1.AddDays(days)).ToList();

                label24.Text = dates1[0].Date.ToString("yyyy-MM-dd");
                label25.Text = dates1[1].Date.ToString("yyyy-MM-dd");
                label26.Text = dates1[2].Date.ToString("yyyy-MM-dd");
                label27.Text = dates1[3].Date.ToString("yyyy-MM-dd");
                label69.Text = dates1[4].Date.ToString("yyyy-MM-dd");
                label70.Text = dates1[5].Date.ToString("yyyy-MM-dd");
                label71.Text = dates1[6].Date.ToString("yyyy-MM-dd");
            }
                //For make next week
            else if (current >= 0 && flage == true && index <= 0)
            {
                
                
                    mon = mon.AddDays(index);
                    //index += 5;
                var dates = Enumerable.Range(0, 7).Select(days => mon.AddDays(days)).ToList();


                label24.Text = dates[0].Date.ToString("yyyy-MM-dd");
                label25.Text = dates[1].Date.ToString("yyyy-MM-dd");
                label26.Text = dates[2].Date.ToString("yyyy-MM-dd");
                label27.Text = dates[3].Date.ToString("yyyy-MM-dd");
                label69.Text = dates[4].Date.ToString("yyyy-MM-dd");
                label70.Text = dates[5].Date.ToString("yyyy-MM-dd");
                label71.Text = dates[6].Date.ToString("yyyy-MM-dd");
            }
            

        }

        //For put in comboBox the list of doctors 
    public    void ShowListBox()
        {
           
            //          create procedure [dbo].[clinic_select_all_of_doctors](@num as varchar(50))
            //as
            //begin
            //select full_name from doctors where spec_id=(select specialty_code from clinic where clinic_code=@num )
            //end


            int count = 0;
            con1.OpenConection();
            types = new SqlDbType[] { SqlDbType.VarChar };
            name_input = new string[] { "@num" };
            values = new string[] { textBox1.Text };
            //types[count] = SqlDbType.NVarChar;
           // name_input[count] = "@num";
            //values[count] = textBox1.Text;
            dr = con1.ShowDataInGridViewUsingStoredProcDR("dbo.clinic_select_all_of_doctors", name_input, values, types);
            while (dr.Read())
            {
                
                comboBox1.Items.Add(dr[0].ToString());
                comboBox2.Items.Add(dr[0].ToString());
                comboBox3.Items.Add(dr[0].ToString());
                comboBox4.Items.Add(dr[0].ToString());
                comboBox5.Items.Add(dr[0].ToString());
                comboBox6.Items.Add(dr[0].ToString());
                comboBox7.Items.Add(dr[0].ToString());
                comboBox8.Items.Add(dr[0].ToString());
                comboBox9.Items.Add(dr[0].ToString());
                comboBox10.Items.Add(dr[0].ToString());
                comboBox11.Items.Add(dr[0].ToString());
                comboBox12.Items.Add(dr[0].ToString());
                comboBox13.Items.Add(dr[0].ToString());
                comboBox14.Items.Add(dr[0].ToString());
                comboBox15.Items.Add(dr[0].ToString());
                comboBox16.Items.Add(dr[0].ToString());
                comboBox17.Items.Add(dr[0].ToString());
                comboBox18.Items.Add(dr[0].ToString());
                comboBox19.Items.Add(dr[0].ToString());
                comboBox20.Items.Add(dr[0].ToString());
                comboBox21.Items.Add(dr[0].ToString());
            }
            
            con1.CloseConnection();
            count = 0;

        }
        //For get ID from table doctors and insert into table shift_time
     
     public int getIDOfDoctors(string y,string timeofshift)
     {
         //create procedure clinic_select_vaction_doc(@doc_name varchar(30),@c varchar(50),@time datetime)
         //   as
         //   begin

         //   select   doc_ssn from doctors where full_name =N'%'+@doc_name+'%' and 
         //   spec_id=(select specialty_code from clinic where clinic_code=@c)
         //    and emp_id  not in (select emp_id from balance_vacation where   @time <=date_end_vacation);
         //    end

         int id = 0;
         int count = 0;
         con1.OpenConection();
         types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.DateTime };
         name_input = new string[] { "@doc_name", "@c", "@time" };
         values = new string[] { y, code.ToString(), timeofshift };
         //types[count] = SqlDbType.NVarChar;
         
         dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_select_vaction_doc", name_input, values, types);

                   while (dr.Read())
                 { 
                     id = Convert.ToInt32(dr[0]);
                 
                 }
                 if (dr==null)
                 {

                     id = 0;
                 
                 }
                 else
                 {
                 
                     return id;


                 }
                 con1.CloseConnection();
                 count = 0;
                 return id;
        
     }

     bool Check_input_time()
     {
         DateTime t1 = Convert.ToDateTime(maskedTextBox1.Text);
         DateTime t2 = Convert.ToDateTime(maskedTextBox2.Text);
         DateTime t3 = Convert.ToDateTime(maskedTextBox3.Text);
         DateTime t4 = Convert.ToDateTime(maskedTextBox4.Text);
         DateTime t5 = Convert.ToDateTime(maskedTextBox5.Text);
         DateTime t6 = Convert.ToDateTime(maskedTextBox6 .Text);
         if (t2 <= t1 | t4<=t3 | t6<=t5)
         {
             MessageBox.Show("من فضلك قم بادخال الوقت المناسب");
             return false;
         }
         else
         {
             return true;
         }
     }

        //For Go to Form3 to create clinic
        private void button1_Click(object sender, EventArgs e)
        {
            بحث_العياده f = new بحث_العياده();
            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = بحث_العياده.c.ToString();
                code = Convert.ToInt32(textBox1.Text);
                textBox2.Text = بحث_العياده.name;
                name = textBox2.Text;
                ShowListBox();
            }
            

        }
        //For week radio button
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton3.Visible = true;
            radioButton4.Visible = true;
        }
        

        //For show the month of the data
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            panel4.Visible = true;
            button4.Visible = true;
            
        }


        //For Save the data of clinic and go back to the form1
        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("تم الحفظ");

        }


        //For button the next button التالي
        int index1 =-6;
        private void button4_Click(object sender, EventArgs e)
        {
                 button5.Visible = true;
                set_dates(true, index1);
                panel4.Visible = true;
               index1 -= 7;
        }


        //For previous button السابق 
        private void button5_Click(object sender, EventArgs e)
        {

            index1 += 7;
            set_dates(true, index1); 
        }

        /// <summary>
        /// For radio button حالي
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            set_dates(false, 1);
            panel4.Visible = true;
            
        }


        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            
            set_dates(true, 1);
            panel4.Visible = true;
            
        }



        //The first Saturday day to insert in table shift_time
        private void button6_Click(object sender, EventArgs e)
        {
            //con = new SqlConnection(@"server=SANDRA-PC\SQLEXPRESS;database=project_db; Integrated Security=true;");
           // con.Open();
            /*
             * create procedure clinic_insert_shift_time (@code nvarchar(30),@doctor_id int,@shift int ,@s_date nvarchar(100),@e_date nvarchar(100),@days  int)
                As 
                Begin
                insert into shift_time(c_code,d_id,shift_num,start_time,end_time,daysfor) values(@code,@doctor_id,@shift,@s_date,@e_date,@days)
                end
             */

            if (maskedTextBox1.MaskFull && maskedTextBox2.MaskFull && maskedTextBox3.MaskFull && maskedTextBox4.MaskFull && maskedTextBox5.MaskFull && maskedTextBox6.MaskFull)
            {
                if (Check_input_time() == true)
                {
                    to = label24.Text + " " + maskedTextBox1.Text;
                    from = label24.Text + " " + maskedTextBox2.Text;
                    to2 = label24.Text + " " + maskedTextBox3.Text;
                    from2 = label24.Text + " " + maskedTextBox4.Text;
                    to3 = label24.Text + " " + maskedTextBox5.Text;
                    from3 = label24.Text + " " + maskedTextBox6.Text;
                    if (comboBox1.SelectedItem != null && comboBox2.SelectedItem == null && comboBox3.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox1.Text, label24.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox1.Text);
                        }
                        else
                        {
                            
                            // create procedure [dbo].[clinic_insert_shift_time] (@code varchar(30),@doctor_id varchar(30),@shift varchar(30) ,@s_date nvarchar(100),@e_date nvarchar(100),@days  int)
                            //As 
                            //Begin
                            //insert into shift_time(c_code,d_id,Shift_name,start_time,end_time,daysfor) values(@code,@doctor_id,@shift,@s_date,@e_date,@days)
                            //end

                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "" ,"","","","",""};
                            values = new string[] {  "" ,"","","","",""};
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                             count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                             count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                             count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                             count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown6.Value.ToString();
                             con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                             MessageBox.Show("تم اضافه يوم السبت يتاريخ" + label24.Text.ToString());
                             con1.CloseConnection();
                            count = 0;
                        }
                    }
                    else if (comboBox1.SelectedItem == null && comboBox2.SelectedItem != null && comboBox3.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox2.Text, label24.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox2.Text);
                        }
                        else
                        {
                           
           
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown1.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم السبت يتاريخ" + label24.Text.ToString());
                            con1.CloseConnection();
                            count = 0;
                        }
                    }
                    else if (comboBox1.SelectedItem == null && comboBox2.SelectedItem == null && comboBox3.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox3.Text, label24.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox3.Text);
                        }
                        else
                        {
                            
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown2.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم السبت يتاريخ" + label24.Text.ToString());
                            con1.CloseConnection();
                            count = 0;
                        }
                    }

                    else if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox1.Text, label24.Text);
                        idDoc1 = getIDOfDoctors(comboBox2.Text, label24.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox1.Text);
                        }
                        else if (idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox2.Text);
                        }
                        else
                        {
                            
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown6.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown1.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم السبت يتاريخ" + label24.Text.ToString());
                            con1.CloseConnection();
                            count = 0;

                        }
                    }
                    else if (comboBox1.SelectedItem != null && comboBox2.SelectedItem == null && comboBox3.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox1.Text, label24.Text);
                        idDoc1 = getIDOfDoctors(comboBox3.Text, label24.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox1.Text);
                        }
                        if (idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox3.Text);
                        }
                        else
                        {
                            
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown6.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown2.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم السبت يتاريخ" + label24.Text.ToString());
                            con1.CloseConnection();
                            count = 0;
                        }
                    }



                    else if (comboBox1.SelectedItem == null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox3.Text, label24.Text);
                        idDoc1 = getIDOfDoctors(comboBox2.Text, label24.Text);
                        if (idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox2.Text);
                        }
                        else if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox3.Text);
                        }
                        else
                        {
                          
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown2.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown1.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم السبت يتاريخ" + label24.Text.ToString());
                            con1.CloseConnection();
                            count = 0;
                        }
                    }




                    else if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && comboBox3.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox1.Text, label24.Text);
                        idDoc1 = getIDOfDoctors(comboBox2.Text, label24.Text);
                        idDoc2 = getIDOfDoctors(comboBox3.Text, label24.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox1.Text);
                        }
                        else   if (idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox2.Text);
                        }
                        else if (idDoc2 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox3.Text);
                        }


                        else
                        {
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown6.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown1.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);

                            count = 0;
                            types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc2.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown2.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم السبت يتاريخ" + label24.Text.ToString());
                            con1.CloseConnection();
                            count = 0;
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("من فضلك قم بادخال مواعيد المناوبات");
            }
        }

        //For Sunday Inthe table
        private void button7_Click(object sender, EventArgs e)
        {

           // con = new SqlConnection(@"server=SANDRA-PC\SQLEXPRESS;database=project_db; Integrated Security=true;");
 

            if (maskedTextBox1.MaskFull && maskedTextBox2.MaskFull && maskedTextBox3.MaskFull && maskedTextBox4.MaskFull && maskedTextBox5.MaskFull && maskedTextBox6.MaskFull)
            {
                if (Check_input_time() == true)
                {
                    to = label25.Text + " " + maskedTextBox1.Text;
                    from = label25.Text + " " + maskedTextBox2.Text;
                    to2 = label25.Text + " " + maskedTextBox3.Text;
                    from2 = label25.Text + " " + maskedTextBox4.Text;
                    to3 = label25.Text + " " + maskedTextBox5.Text;
                    from3 = label25.Text + " " + maskedTextBox6.Text;
                    if (comboBox4.SelectedItem != null && comboBox5.SelectedItem == null && comboBox6.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox4.Text, label25.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " +comboBox4.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{
                                

                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown5.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الاحد يتاريخ" + label25.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown5.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاحد يتاريخ" + label25.Text.ToString());
                            con1.CloseConnection();
                            count = 0;
                        }
                    }
                    else  if (comboBox4.SelectedItem == null && comboBox5.SelectedItem != null && comboBox6.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox5.Text, label25.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox5.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown4.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الاحد يتاريخ" + label25.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown4.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاحد يتاريخ" + label25.Text.ToString());
                            con1.CloseConnection();
                            count = 0;
                        }
                    }
                    else if (comboBox4.SelectedItem == null && comboBox5.SelectedItem == null && comboBox6.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox6.Text, label25.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox6.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown3.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الاحد يتاريخ" + label25.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown3.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاحد يتاريخ" + label25.Text.ToString());
                            con1.CloseConnection();
                            count = 0;
                        }
                    }

                    else if (comboBox4.SelectedItem != null && comboBox5.SelectedItem != null && comboBox6.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox4.Text, label25.Text);
                        idDoc1 = getIDOfDoctors(comboBox5.Text, label25.Text);
                        if (idDoc == 0 )
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox4.Text);
                        }
                        else   if (idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox5.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown5.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown4.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الاحد يتاريخ" + label25.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown5.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown4.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاحد يتاريخ" + label25.Text.ToString());
                            con1.CloseConnection();
                            count = 0;


                        }
                    }
                    else if (comboBox4.SelectedItem != null && comboBox5.SelectedItem == null && comboBox6.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox4.Text, label25.Text);
                        idDoc1 = getIDOfDoctors(comboBox6.Text, label25.Text);
                        if (idDoc == 0 || idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox4.Text);
                        }
                        else  if ( idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox6.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown5.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown3.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الاحد يتاريخ" + label25.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown5.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown3.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاحد يتاريخ" + label25.Text.ToString());
                            con1.CloseConnection();
                            count = 0;
                        }
                    }



                    else if (comboBox4.SelectedItem == null && comboBox5.SelectedItem != null && comboBox6.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox6.Text, label25.Text);
                        idDoc1 = getIDOfDoctors(comboBox5.Text, label25.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox4.Text);
                        }
                        else   if (idDoc1 == 0 )
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox6.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown3.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown4.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الاحد يتاريخ" + label25.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown3.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown4.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاحد يتاريخ" + label25.Text.ToString());
                            con1.CloseConnection();
                            count = 0;
                        }
                    }




                    else if (comboBox4.SelectedItem != null && comboBox5.SelectedItem != null && comboBox6.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox4.Text, label25.Text);
                        idDoc1 = getIDOfDoctors(comboBox5.Text, label25.Text);
                        idDoc2 = getIDOfDoctors(comboBox6.Text, label25.Text);
                        if (idDoc == 0 || idDoc1 == 0 || idDoc2==0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox4.Text);
                        }
                        else  if ( idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox5.Text);
                        }
                        else if ( idDoc2 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox6.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown5.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown4.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc2);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown3.Value);
                            //    cmd.ExecuteNonQuery();
                            //    MessageBox.Show("تم اضافه يوم الاحد يتاريخ" + label25.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown6.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown1.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);

                            count = 0;
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc2.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown2.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم السبت يتاريخ" + label24.Text.ToString());
                            con1.CloseConnection();
                            count = 0;

                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("من فضلك قم بادخال مواعيد المناوبات");
            }

        }

        //For Monday
        private void button8_Click(object sender, EventArgs e)
        {
            //con = new SqlConnection(@"server=SANDRA-PC\SQLEXPRESS;database=project_db; Integrated Security=true;");
            //con.Open();
            

            if (maskedTextBox1.MaskFull && maskedTextBox2.MaskFull && maskedTextBox3.MaskFull && maskedTextBox4.MaskFull && maskedTextBox5.MaskFull && maskedTextBox6.MaskFull)
            {
                if (Check_input_time() == true)
                {
                    to = label26.Text + " " + maskedTextBox1.Text;
                    from = label26.Text + " " + maskedTextBox2.Text;
                    to2 = label26.Text + " " + maskedTextBox3.Text;
                    from2 = label26.Text + " " + maskedTextBox4.Text;
                    to3 = label26.Text + " " + maskedTextBox5.Text;
                    from3 = label26.Text + " " + maskedTextBox6.Text;
                    if (comboBox7.SelectedItem != null && comboBox8.SelectedItem == null && comboBox9.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox7.Text, label26.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox7.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown9.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الاثنين يتاريخ" + label26.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown9.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاثنين يتاريخ" + label26.Text.ToString());
                            con1.CloseConnection();
                            count = 0;

                           
                        }
                    }
                    else if (comboBox7.SelectedItem == null && comboBox8.SelectedItem != null && comboBox9.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox8.Text, label26.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox8.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown8.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الاثنين يتاريخ" + label26.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown8.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاثنين يتاريخ" + label26.Text.ToString());
                            con1.CloseConnection();
                            count = 0; 


                        }
                    }
                    else if (comboBox7.SelectedItem == null && comboBox8.SelectedItem == null && comboBox9.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox9.Text, label26.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox9.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown7.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الاثنين يتاريخ" + label26.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown7.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاثنين يتاريخ" + label26.Text.ToString());

                            con1.CloseConnection();
                            count = 0;
                        }
                    }

                    else if (comboBox7.SelectedItem != null && comboBox8.SelectedItem != null && comboBox9.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox7.Text, label26.Text);
                        idDoc1 = getIDOfDoctors(comboBox8.Text, label26.Text);
                        if (idDoc == 0 || idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox7.Text);
                        }
                        else if ( idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox8.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown9.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown8.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الاثنين يتاريخ" + label26.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown9.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown8.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاثنين يتاريخ" + label26.Text.ToString());
                            con1.CloseConnection();
                            count = 0;







                        }
                    }
                    else if (comboBox7.SelectedItem != null && comboBox8.SelectedItem == null && comboBox9.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox7.Text, label26.Text);
                        idDoc1 = getIDOfDoctors(comboBox9.Text, label26.Text);
                        if (idDoc == 0 || idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox7.Text);
                        }
                        else   if (idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox9.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown9.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown7.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الاثنين يتاريخ" + label26.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown9.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown7.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاثنين يتاريخ" + label26.Text.ToString());
                            con1.CloseConnection();
                            count = 0;




                        }
                    }



                    else if (comboBox7.SelectedItem == null && comboBox8.SelectedItem != null && comboBox9.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox9.Text, label26.Text);
                        idDoc1 = getIDOfDoctors(comboBox8.Text, label26.Text);
                        if ( idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox8.Text);
                        }
                        else if ( idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox9.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown7.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown8.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم السبت يتاريخ" + label26.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown7.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown8.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاثنين يتاريخ" + label26.Text.ToString());
                            con1.CloseConnection();
                            count = 0;

                        }
                    }




                    else if (comboBox7.SelectedItem != null && comboBox8.SelectedItem != null && comboBox9.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox7.Text, label26.Text);
                        idDoc1 = getIDOfDoctors(comboBox8.Text, label26.Text);
                        idDoc2 = getIDOfDoctors(comboBox9.Text, label26.Text);
                        if (idDoc == 0 || idDoc1 == 0 || idDoc2 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox7.Text);
                        }
                        else if ( idDoc1 == 0 )
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox8.Text);
                        }
                        else if (idDoc2 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox9.Text);
                        }

                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown9.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown8.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc2);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown7.Value);
                            //    cmd.ExecuteNonQuery();
                            //    MessageBox.Show("تم اضافه يوم الاثنين يتاريخ" + label26.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown9.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown8.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);

                            count = 0;
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc2.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown7.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاثنين يتاريخ" + label26.Text.ToString());
                            con1.CloseConnection();
                            count = 0;
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("من فضلك قم بادخال مواعيد المناوبات");
            }
        }


        //For TuesDay
        private void button9_Click(object sender, EventArgs e)
        {
            //con = new SqlConnection(@"server=SANDRA-PC\SQLEXPRESS;database=project_db; Integrated Security=true;");
           // con.Open();
            

            if (maskedTextBox1.MaskFull && maskedTextBox2.MaskFull && maskedTextBox3.MaskFull && maskedTextBox4.MaskFull && maskedTextBox5.MaskFull && maskedTextBox6.MaskFull)
            {
                if (Check_input_time() == true)
                {
                    to = label27.Text + " " + maskedTextBox1.Text;
                    from = label27.Text + " " + maskedTextBox2.Text;
                    to2 = label27.Text + " " + maskedTextBox3.Text;
                    from2 = label27.Text + " " + maskedTextBox4.Text;
                    to3 = label27.Text + " " + maskedTextBox5.Text;
                    from3 = label27.Text + " " + maskedTextBox6.Text;
                    if (comboBox10.SelectedItem != null && comboBox11.SelectedItem == null && comboBox12.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox10.Text, label27.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox10.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown12.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الثلاثاء يتاريخ" + label27.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown12.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الثلاثاء يتاريخ" + label27.Text.ToString());
                            con1.CloseConnection();
                            count = 0;

                        }
                    }
                    else if (comboBox10.SelectedItem == null && comboBox11.SelectedItem != null && comboBox12.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox11.Text, label27.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox11.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown11.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الثلاثاء يتاريخ" + label27.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown11.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الثلاثاء يتاريخ" + label27.Text.ToString());
                            con1.CloseConnection();
                            count = 0; 






                        }
                    }
                    else if (comboBox10.SelectedItem == null && comboBox11.SelectedItem == null && comboBox12.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox12.Text, label27.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox12.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown10.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الثلاثاء يتاريخ" + label27.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown11.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الثلاثاء يتاريخ" + label27.Text.ToString());
                            con1.CloseConnection();
                            count = 0;


                        }
                    }

                    else if (comboBox10.SelectedItem != null && comboBox11.SelectedItem != null && comboBox12.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox10.Text, label27.Text);
                        idDoc1 = getIDOfDoctors(comboBox11.Text, label27.Text);
                        if (idDoc == 0 || idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox10.Text);
                        }
                        else if ( idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox11.Text);
                        }
                        else
                        {
                        //    con.Open();
                        //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                        //    try
                        //    {


                        //        cmd.CommandType = CommandType.StoredProcedure;
                        //        cmd.Parameters.AddWithValue("@code", code);
                        //        cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                        //        cmd.Parameters.AddWithValue("@shift", shift1);
                        //        cmd.Parameters.AddWithValue("@s_date", to);
                        //        cmd.Parameters.AddWithValue("@e_date", from);
                        //        cmd.Parameters.AddWithValue("@days", (int)numericUpDown12.Value);
                        //        cmd.ExecuteNonQuery();

                        //        cmd = new SqlCommand("clinic_insert_shift_time", con);
                        //        cmd.CommandType = CommandType.StoredProcedure;
                        //        cmd.Parameters.AddWithValue("@code", code);
                        //        cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                        //        cmd.Parameters.AddWithValue("@shift", shift2);
                        //        cmd.Parameters.AddWithValue("@s_date", to2);
                        //        cmd.Parameters.AddWithValue("@e_date", from2);
                        //        cmd.Parameters.AddWithValue("@days", (int)numericUpDown11.Value);
                        //        cmd.ExecuteNonQuery();

                        //        MessageBox.Show("تم اضافه يوم الثلاثاء يتاريخ" + label27.Text.ToString());

                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        MessageBox.Show(ex.Message);
                        //    }
                        //    finally
                        //    {
                        //        con.Close();

                        //    }
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown12.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown11.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الثلاثاء يتاريخ" + label27.Text.ToString());
                            con1.CloseConnection();
                            count = 0;


                        }
                    }
                    else if (comboBox10.SelectedItem != null && comboBox11.SelectedItem == null && comboBox12.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox10.Text, label27.Text);
                        idDoc1 = getIDOfDoctors(comboBox12.Text, label27.Text);
                        if (idDoc == 0 || idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox10.Text);
                        }
                        else  if ( idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox12.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown12.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown10.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الثلاثاء يتاريخ" + label27.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown12.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown10.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الثلاثاء يتاريخ" + label27.Text.ToString());
                            con1.CloseConnection();
                            count = 0;

                        }
                    }



                    else if (comboBox10.SelectedItem == null && comboBox11.SelectedItem != null && comboBox12.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox12.Text, label27.Text);
                        idDoc1 = getIDOfDoctors(comboBox11.Text, label27.Text);
                        if (idDoc == 0 || idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox12.Text);
                        }
                        else if ( idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox11.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown10.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown11.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الثلاثاء يتاريخ" + label27.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown12.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown11.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الثلاثاء يتاريخ" + label27.Text.ToString());
                            con1.CloseConnection();
                            count = 0;

                        }
                    }




                    else if (comboBox10.SelectedItem != null && comboBox11.SelectedItem != null && comboBox12.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox10.Text, label27.Text);
                        idDoc1 = getIDOfDoctors(comboBox11.Text, label27.Text);
                        idDoc2 = getIDOfDoctors(comboBox12.Text, label27.Text);
                        if (idDoc == 0 || idDoc1 == 0 || idDoc2 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox10.Text);
                        }
                        else   if ( idDoc1 == 0 )
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox11.Text);
                        }
                        else if (idDoc2 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox12.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown12.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown11.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc2);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown10.Value);
                            //    cmd.ExecuteNonQuery();
                            //    MessageBox.Show("تم اضافه يوم الثلاثاء يتاريخ" + label27.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown12.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown11.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);

                            count = 0;
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc2.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown10.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الثلاثاء يتاريخ" + label27.Text.ToString());
                            con1.CloseConnection();
                            count = 0;

                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("من فضلك قم بادخال مواعيد المناوبات");
            }
        }

        //For weduesday
        private void button10_Click(object sender, EventArgs e)
        {
           // con = new SqlConnection(@"server=SANDRA-PC\SQLEXPRESS;database=project_db; Integrated Security=true;");
            //con.Open();


            if (maskedTextBox1.MaskFull && maskedTextBox2.MaskFull && maskedTextBox3.MaskFull && maskedTextBox4.MaskFull && maskedTextBox5.MaskFull && maskedTextBox6.MaskFull)
            {
                if (Check_input_time() == true)
                {
                    to = label69.Text + " " + maskedTextBox1.Text;
                    from = label69.Text + " " + maskedTextBox2.Text;
                    to2 = label69.Text + " " + maskedTextBox3.Text;
                    from2 = label69.Text + " " + maskedTextBox4.Text;
                    to3 = label69.Text + " " + maskedTextBox5.Text;
                    from3 = label69.Text + " " + maskedTextBox6.Text;
                    if (comboBox13.SelectedItem != null && comboBox14.SelectedItem == null && comboBox15.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox13.Text, label69.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox13.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown15.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الاربعاء يتاريخ" + label69.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown15.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاربعاء يتاريخ" + label69.Text.ToString());
                            con1.CloseConnection();
                            count = 0;


                        }
                    }
                    else if (comboBox13.SelectedItem == null && comboBox14.SelectedItem != null && comboBox15.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox14.Text, label69.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox14.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown14.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الاربعاء يتاريخ" + label69.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown14.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاربعاء يتاريخ" + label69.Text.ToString());
                            con1.CloseConnection();
                            count = 0; 


                        }
                    }
                    else if (comboBox13.SelectedItem == null && comboBox14.SelectedItem == null && comboBox15.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox15.Text, label69.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox15.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown13.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الاربعاء يتاريخ" + label69.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown13.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاربعاء يتاريخ" + label69.Text.ToString());
                            con1.CloseConnection();
                            count = 0;


                        }
                    }

                    else if (comboBox13.SelectedItem != null && comboBox14.SelectedItem != null && comboBox15.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox13.Text, label69.Text);
                        idDoc1 = getIDOfDoctors(comboBox14.Text, label69.Text);
                        if (idDoc == 0 || idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox13.Text);
                        }
                        else if ( idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox14.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown15.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown14.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الاربعاء يتاريخ" + label69.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown15.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown14.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاربعاء يتاريخ" + label69.Text.ToString());
                            con1.CloseConnection();
                            count = 0;



                        }
                    }
                    else if (comboBox13.SelectedItem != null && comboBox14.SelectedItem == null && comboBox15.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox13.Text, label69.Text);
                        idDoc1 = getIDOfDoctors(comboBox15.Text, label69.Text);
                        if (idDoc == 0 )
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox13.Text);
                        }
                        else   if ( idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox15.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown15.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown13.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الاربعاء يتاريخ" + label69.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown15.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown13.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاربعاء يتاريخ" + label69.Text.ToString());
                            con1.CloseConnection();
                            count = 0;
                        }
                    }



                    else if (comboBox13.SelectedItem == null && comboBox14.SelectedItem != null && comboBox15.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox15.Text, label69.Text);
                        idDoc1 = getIDOfDoctors(comboBox14.Text, label69.Text);
                        if (idDoc == 0 || idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox14.Text);
                        }
                        else    if (idDoc == 0 )
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox15.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown13.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown14.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الاربعاء يتاريخ" + label69.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown13.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown14.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاربعاء يتاريخ" + label69.Text.ToString());
                            con1.CloseConnection();
                            count = 0;

                        }
                    }




                    else if (comboBox13.SelectedItem != null && comboBox14.SelectedItem != null && comboBox15.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox13.Text, label69.Text);
                        idDoc1 = getIDOfDoctors(comboBox14.Text, label69.Text);
                        idDoc2 = getIDOfDoctors(comboBox15.Text, label69.Text);
                        if (idDoc == 0 || idDoc1 == 0 || idDoc2 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox13.Text);
                        }
                        else if ( idDoc1 == 0 )
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox14.Text);
                        }
                        else if (idDoc2 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox15.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown15.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown14.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc2);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown13.Value);
                            //    cmd.ExecuteNonQuery();
                            //    MessageBox.Show("تم اضافه يوم الاربعاء يتاريخ" + label69.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown15.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown14.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);

                            count = 0;
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc2.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown13.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الاربعاء يتاريخ" + label69.Text.ToString());
                            con1.CloseConnection();
                            count = 0;
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("من فضلك قم بادخال مواعيد المناوبات");
            }

        }



        //For Thursday
        private void button11_Click(object sender, EventArgs e)
        {
           // con = new SqlConnection(@"server=SANDRA-PC\SQLEXPRESS;database=project_db; Integrated Security=true;");
           // con.Open();


            if (maskedTextBox1.MaskFull && maskedTextBox2.MaskFull && maskedTextBox3.MaskFull && maskedTextBox4.MaskFull && maskedTextBox5.MaskFull && maskedTextBox6.MaskFull)
            {
                if (Check_input_time() == true)
                {
                    to = label70.Text + " " + maskedTextBox1.Text;
                    from = label70.Text + " " + maskedTextBox2.Text;
                    to2 = label70.Text + " " + maskedTextBox3.Text;
                    from2 = label70.Text + " " + maskedTextBox4.Text;
                    to3 = label70.Text + " " + maskedTextBox5.Text;
                    from3 = label70.Text + " " + maskedTextBox6.Text;
                    if (comboBox16.SelectedItem != null && comboBox17.SelectedItem == null && comboBox18.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox16.Text, label70.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox16.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown16.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الخميس يتاريخ" + label70.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown16.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الخميس يتاريخ" + label70.Text.ToString());
                            con1.CloseConnection();
                            count = 0;
                        }
                    }
                    else if (comboBox16.SelectedItem == null && comboBox17.SelectedItem != null && comboBox18.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox17.Text, label70.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox17.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown17.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الخميس يتاريخ" + label70.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown17.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الخميس يتاريخ" + label70.Text.ToString());
                            con1.CloseConnection();
                            count = 0; 


                        }
                    }
                    else if (comboBox16.SelectedItem == null && comboBox17.SelectedItem == null && comboBox18.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox18.Text, label70.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox18.Text);
                        }
                        else
                        {
                        //    con.Open();
                        //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                        //    try
                        //    {


                        //        cmd.CommandType = CommandType.StoredProcedure;
                        //        cmd.Parameters.AddWithValue("@code", code);
                        //        cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                        //        cmd.Parameters.AddWithValue("@shift", shift3);
                        //        cmd.Parameters.AddWithValue("@s_date", to3);
                        //        cmd.Parameters.AddWithValue("@e_date", from3);
                        //        cmd.Parameters.AddWithValue("@days", (int)numericUpDown18.Value);
                        //        cmd.ExecuteNonQuery();

                        //        MessageBox.Show("تم اضافه يوم الخميس يتاريخ" + label70.Text.ToString());

                        //    }
                        //    catch (Exception ex)
                        //    {
                        //        MessageBox.Show(ex.Message);
                        //    }
                        //    finally
                        //    {
                        //        con.Close();

                        //    }
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown18.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الخميس يتاريخ" + label70.Text.ToString());
                            con1.CloseConnection();
                            count = 0;

                        }
                    }

                    else if (comboBox16.SelectedItem != null && comboBox17.SelectedItem != null && comboBox18.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox16.Text, label70.Text);
                        idDoc1 = getIDOfDoctors(comboBox17.Text, label70.Text);
                        if (idDoc == 0 || idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox16.Text);
                        }
                        else if ( idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox17.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown16.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown17.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الخميس يتاريخ" + label70.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown16.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown17.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الخميس يتاريخ" + label70.Text.ToString());
                            con1.CloseConnection();
                            count = 0;

                        }
                    }
                    else if (comboBox16.SelectedItem != null && comboBox17.SelectedItem == null && comboBox18.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox16.Text, label70.Text);
                        idDoc1 = getIDOfDoctors(comboBox18.Text, label70.Text);
                        if (idDoc == 0 || idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox16.Text);
                        }
                        
                        else  if ( idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox18.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown16.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown18.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الخميس يتاريخ" + label70.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown16.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown18.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الخميس يتاريخ" + label70.Text.ToString());
                            con1.CloseConnection();
                            count = 0;



                        }
                    }



                    else if (comboBox16.SelectedItem == null && comboBox17.SelectedItem != null && comboBox18.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox18.Text, label70.Text);
                        idDoc1 = getIDOfDoctors(comboBox17.Text, label70.Text);
                        if (idDoc == 0 || idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox17.Text);
                        }
                        else if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox18.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown18.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown17.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الخميس يتاريخ" + label70.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown18.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown17.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الخميس يتاريخ" + label70.Text.ToString());
                            con1.CloseConnection();
                            count = 0;

                        }
                    }




                    else if (comboBox16.SelectedItem != null && comboBox17.SelectedItem != null && comboBox18.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox16.Text, label70.Text);
                        idDoc1 = getIDOfDoctors(comboBox17.Text, label70.Text);
                        idDoc2 = getIDOfDoctors(comboBox18.Text, label70.Text);
                        if (idDoc == 0 )
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox16.Text);
                        }
                        else  if ( idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox17.Text);
                        }
                        else if (idDoc2 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox18.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown16.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown17.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc2);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown18.Value);
                            //    cmd.ExecuteNonQuery();
                            //    MessageBox.Show("تم اضافه يوم الخميس يتاريخ" + label70.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown16.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown17.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);

                            count = 0;
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc2.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown18.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الخميس يتاريخ" + label70.Text.ToString());
                            con1.CloseConnection();
                            count = 0;
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("من فضلك قم بادخال مواعيد المناوبات");
            }


        }
        

        //For Friday
        private void button12_Click(object sender, EventArgs e)
        {

           // con = new SqlConnection(@"server=SANDRA-PC\SQLEXPRESS;database=project_db; Integrated Security=true;");
          //  con.Open();


            if (maskedTextBox1.MaskFull && maskedTextBox2.MaskFull && maskedTextBox3.MaskFull && maskedTextBox4.MaskFull && maskedTextBox5.MaskFull && maskedTextBox6.MaskFull)
            {
                if (Check_input_time() == true)
                {
                    to = label71.Text + " " + maskedTextBox1.Text;
                    from = label71.Text + " " + maskedTextBox2.Text;
                    to2 = label71.Text + " " + maskedTextBox3.Text;
                    from2 = label71.Text + " " + maskedTextBox4.Text;
                    to3 = label71.Text + " " + maskedTextBox5.Text;
                    from3 = label71.Text + " " + maskedTextBox6.Text;
                    if (comboBox19.SelectedItem != null && comboBox20.SelectedItem == null && comboBox21.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox19.Text, label71.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox19.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown19.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الجمعه يتاريخ" + label71.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown19.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الجمعه يتاريخ" + label71.Text.ToString());
                            con1.CloseConnection();
                            count = 0;
                        }
                    }
                    else if (comboBox19.SelectedItem == null && comboBox20.SelectedItem != null && comboBox21.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox20.Text, label71.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox20.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown20.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الجمعه يتاريخ" + label71.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown20.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الجمعه يتاريخ" + label71.Text.ToString());
                            con1.CloseConnection();
                            count = 0; 



                        }
                    }
                    else if (comboBox19.SelectedItem == null && comboBox20.SelectedItem == null && comboBox21.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox21.Text, label71.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox21.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown21.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الجمعه يتاريخ" + label71.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown21.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الجمعه يتاريخ" + label71.Text.ToString());
                            con1.CloseConnection();
                            count = 0;




                        }
                    }

                    else if (comboBox19.SelectedItem != null && comboBox20.SelectedItem != null && comboBox21.SelectedItem == null)
                    {
                        idDoc = getIDOfDoctors(comboBox19.Text, label71.Text);
                        idDoc1 = getIDOfDoctors(comboBox20.Text, label71.Text);
                        if (idDoc == 0 || idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox19.Text);
                        }
                        else   if ( idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox20.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown19.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown20.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الجمعه يتاريخ" + label71.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown19.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown20.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الجمعه يتاريخ" + label71.Text.ToString());
                            con1.CloseConnection();
                            count = 0;

                        }
                    }
                    else if (comboBox19.SelectedItem != null && comboBox20.SelectedItem == null && comboBox21.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox19.Text, label71.Text);
                        idDoc1 = getIDOfDoctors(comboBox21.Text, label71.Text);
                        if (idDoc == 0 || idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox19.Text);
                        }
                        else if ( idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox21.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown19.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown21.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الجمعه يتاريخ" + label71.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown19.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown21.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الجمعه يتاريخ" + label71.Text.ToString());
                            con1.CloseConnection();
                            count = 0;
                        }
                    }



                    else if (comboBox19.SelectedItem == null && comboBox20.SelectedItem != null && comboBox21.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox21.Text, label71.Text);
                        idDoc1 = getIDOfDoctors(comboBox20.Text, label71.Text);
                        if (idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox20.Text);
                        }
                        else if (idDoc == 0 )
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox21.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown21.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown20.Value);
                            //    cmd.ExecuteNonQuery();

                            //    MessageBox.Show("تم اضافه يوم الجمعه يتاريخ" + label71.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown21.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown20.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الجمعه يتاريخ" + label71.Text.ToString());
                            con1.CloseConnection();
                            count = 0;


                        }
                    }




                    else if (comboBox19.SelectedItem != null && comboBox20.SelectedItem != null && comboBox21.SelectedItem != null)
                    {
                        idDoc = getIDOfDoctors(comboBox19.Text, label71.Text);
                        idDoc1 = getIDOfDoctors(comboBox20.Text, label71.Text);
                        idDoc2 = getIDOfDoctors(comboBox21.Text, label71.Text);
                        if (idDoc == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox19.Text);
                        }
                        else if (idDoc1 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox20.Text);
                        }
                        else if (idDoc2 == 0)
                        {

                            MessageBox.Show("من فضلك قم باختيار اي طبيب اخر غير الدكتور " + " " + comboBox21.Text);
                        }
                        else
                        {
                            //con.Open();
                            //cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //try
                            //{


                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc);
                            //    cmd.Parameters.AddWithValue("@shift", shift1);
                            //    cmd.Parameters.AddWithValue("@s_date", to);
                            //    cmd.Parameters.AddWithValue("@e_date", from);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown19.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc1);
                            //    cmd.Parameters.AddWithValue("@shift", shift2);
                            //    cmd.Parameters.AddWithValue("@s_date", to2);
                            //    cmd.Parameters.AddWithValue("@e_date", from2);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown20.Value);
                            //    cmd.ExecuteNonQuery();

                            //    cmd = new SqlCommand("clinic_insert_shift_time", con);
                            //    cmd.CommandType = CommandType.StoredProcedure;
                            //    cmd.Parameters.AddWithValue("@code", code);
                            //    cmd.Parameters.AddWithValue("@doctor_id", idDoc2);
                            //    cmd.Parameters.AddWithValue("@shift", shift3);
                            //    cmd.Parameters.AddWithValue("@s_date", to3);
                            //    cmd.Parameters.AddWithValue("@e_date", from3);
                            //    cmd.Parameters.AddWithValue("@days", (int)numericUpDown21.Value);
                            //    cmd.ExecuteNonQuery();
                            //    MessageBox.Show("تم اضافه يوم الاحد يتاريخ" + label25.Text.ToString());

                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show(ex.Message);
                            //}
                            //finally
                            //{
                            //    con.Close();

                            //}
                            int count = 0;
                            con1.OpenConection();
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift1.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown19.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            count = 0;

                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc1.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift2.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to2;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from2;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown20.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);

                            count = 0;
                            types = new SqlDbType[] { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.NVarChar,SqlDbType.NVarChar,SqlDbType.Int };
                            name_input = new string[] { "", "", "", "", "", "" };
                            values = new string[] { "", "", "", "", "", "" };
                            name_input[count] = "@code";
                            values[count] = code.ToString();
                            count++;
                            name_input[count] = "@doctor_id";
                            values[count] = idDoc2.ToString();
                            count++;
                            name_input[count] = "@shift";
                            values[count] = shift3.ToString();
                            count++;
                            name_input[count] = "@s_date";
                            values[count] = to3;
                            count++;
                            name_input[count] = "@e_date";
                            values[count] = from3;
                            count++;
                            name_input[count] = "@days";
                            values[count] = numericUpDown21.Value.ToString();
                            con1.ExecuteNonQueryProcedure("clinic_insert_shift_time", name_input, values, types);
                            MessageBox.Show("تم اضافه يوم الجمعه يتاريخ" + label71.Text.ToString());
                            con1.CloseConnection();
                            count = 0;
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("من فضلك قم بادخال مواعيد المناوبات");
            }


        }




/// <summary>
/// For Back to Form1 to return the name of clinic
/// </summary>
/// <param name="sender"></param>
/// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("من فضلك قم بختيار عياده");
            }
            else
            {
                حجز_العياده f = new حجز_العياده();
                f.Focus();
                this.DialogResult = DialogResult.OK;
                حجز_العياده.names = textBox2.Text;
            }
           
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            maskedTextBox4.Text = "";
            maskedTextBox5.Text = "";
            maskedTextBox6.Text = "";
            panel4.Visible = false;
        }
        

       
        

        


        
       
        

       
        
    
    



    }




}
