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
    public partial class الصفحه_الرئيسيه_للمنظار : Form
    {
        Connection con1 = new Connection();
        int count = 0;
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        public static string date;
        public static string d;
        public static int doc_id;

        public static string doc;
        public static string start { get; set; }
        public static string end { get; set; }
        public static string pid { get; set; }
        public static string pname { get; set; }
        public static string opid { get; set; }
        public static string op { get; set; }
        public static string did { get; set; }
        public static string d_id;
        public static string dname { get; set; }
        
        public static string endo="";
        public static string flag;
      
        Panel p,p1;
        Label l1, l2, l3, l4, l5, l6,lshape;
        
        
        RowStyle temp;

        public الصفحه_الرئيسيه_للمنظار()
        {
            InitializeComponent();
        }
        

        private void label12_Click(object sender, EventArgs e)
        {
            فريق_العمل_المنظار f3 = new فريق_العمل_المنظار();
            f3.Show();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            
        }

      
        private void monthCalendar1_DateSelected_1(object sender, DateRangeEventArgs e)
        {
            int c = 0;
            for (int j = 0; j < tableLayoutPanel1.RowCount; j++)
            {
                for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
                {
                    tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(i, j));
                    tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(i, j));
                    tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(i, j));
                    tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(i, j));
                }
            }

            date = monthCalendar1.SelectionRange.Start.ToShortDateString();

            DateTime dtm = Convert.ToDateTime(date);

             d = dtm.Year.ToString() + '-' + dtm.Month.ToString() + '-' + dtm.Day.ToString();
            try
            {
                /*
                 * create procedure setescope_select_dat(@x nvarchar(50),@end_name nvarchar(50))

                    as
                    begin
                     select  o.Datee,o.start_time,o.end_time,o.flag 
                     from setescope_operation o,Endoscope_settings_data e
                      where o.Datee = @x and e.EndoscopeCode=o.EndoscopeCode and e.EndoscopeName=@end_name; 

                     select p.id,p.name from 
                     patient_endo p ,setescope_operation s,Endoscope_settings_data e 
                     where p.id=s.patient_id and  s.Datee = @x and e.EndoscopeCode=s.EndoscopeCode and e.EndoscopeName=@end_name;

                      select e.EndoscopeName from Endoscope_settings_data e,setescope_operation s 
                       where e.EndoscopeCode=s.EndoscopeCode and e.EndoscopeName=@end_name;

                     select d.name 
                     from doctors d,doctor_operation o,setescope_operation s,Endoscope_settings_data e  
                     where o.Do_id=d.Do_id and o.id_op=s.id and s.Datee = @x and e.EndoscopeCode=s.EndoscopeCode and e.EndoscopeName=@end_name and d.jop='surgeon' ;
                       end
                 * 
                 */
                con1.OpenConection();
               
                types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar,SqlDbType.NVarChar };
                name_input = new string[] { "@x", "@end_name" ,"@s"};
                values = new string[] { d, endo, p1.Controls[0].Text };
                dr = con1.ShowDataInGridViewUsingStoredProcDR("setescope_select_dat", name_input, values, types);
                DataTable dt = new DataTable();
                dt.Load(dr);
              if(dt.Rows.Count != 0)
                {
                    c++;
                }
                for (int i = 0; i < dt.Rows.Count;i+=4 )
                {
                    this.tableLayoutPanel1.AutoSize = true;
                    temp = tableLayoutPanel1.RowStyles[0];
                    this.tableLayoutPanel1.RowStyles.Add(new RowStyle(temp.SizeType, temp.Height));
                    tableLayoutPanel1.RowCount++;
                }
                if(c !=0)
                tableLayoutPanel1.RowCount--;
                int n = 0;
                for (int j = 0; j < tableLayoutPanel1.RowCount; j++)
                {
                    int i = 0;                    
                    for (i = 0; i < tableLayoutPanel1.ColumnCount; i++)
                    {
                        if (i+n < dt.Rows.Count)
                        {
                            p = new Panel();
                            p.Click += p_Click;
                            p.Size = new System.Drawing.Size(149, 101);
                            p.Location = new Point(250, 9);
                            p.BorderStyle = BorderStyle.FixedSingle;
                            p.BackColor = Color.AliceBlue;
                            p.Visible = true;
                            this.tableLayoutPanel1.Controls.Add(p, i, j);

                            l1 = new Label();
                            l1.Text = dt.Rows[i+n][1].ToString();
                            l1.AutoSize = false;
                            l1.Left = 45;
                            l1.Top = 3;
                            p.Controls.Add(l1);

                            l2 = new Label();
                            l2.Text = dt.Rows[i+n][2].ToString();
                            l2.AutoSize = false;
                            l2.Left = -50;
                            l2.Top = 3;
                            p.Controls.Add(l2);

                            l3 = new Label();
                            l3.Text = dt.Rows[i][0].ToString();
                            l3.AutoSize = false;
                            l3.Left = -20;
                            l3.Top = l1.Height;
                            p.Controls.Add(l3);
                            l4 = new Label();
                            l4.Text = dt.Rows[i][1].ToString();
                            l4.AutoSize = false;
                            l4.Left = -10;
                            l4.Top = l3.Height + 20;
                            p.Controls.Add(l4);

                            l5 = new Label();
                            l5.Text = dt.Rows[i][0].ToString();
                            l5.AutoSize = false;
                            l5.Left = 15;
                            l5.Top = l4.Height + 40;
                            p.Controls.Add(l5);

                            l6 = new Label();
                            l6.Text = dt.Rows[i][0].ToString();
                            l6.AutoSize = false;
                            l6.Left = -5;
                            l6.Top = l5.Height + 60;
                            doc = l6.Text;


                            //create procedure setescope_do_id(@x nvarchar(50))
                            //    as

                            //    select doc_ssn from doctors where name=@x

                            //cmd = new SqlCommand("setescope_do_id ", con);

                            //cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.Parameters.AddWithValue("@x", l6.Text);
                            types = new SqlDbType[] { SqlDbType.NVarChar};
                            name_input = new string[] { "@x" };
                            values = new string[] { l6.Text };
                            SqlDataReader dhr;
                           dhr= con1.ShowDataInGridViewUsingStoredProcDR("setescope_do_id", name_input, values, types);
                           
                            dhr.Read();
                            doc_id = int.Parse(dhr[0].ToString());
                            dhr.Close();
                            p.Controls.Add(l6);

                            flag = dt.Rows[i + n][3].ToString();
                            lshape = new Label();
                            lshape.Text = "";
                            lshape.AutoSize = false;
                            lshape.Size = new System.Drawing.Size(20, 20);
                            if (flag == "7agz")
                            {
                                lshape.BackColor = Color.Yellow;
                            }
                            else if (flag == "taked")
                            {
                                lshape.BackColor = Color.Green;

                            }
                            else if (flag == "start")
                            {
                                lshape.BackColor = Color.Cyan;

                            }
                            else if (flag == "finish")
                            {
                                lshape.BackColor = Color.Blue;

                            }
                            lshape.BorderStyle = BorderStyle.FixedSingle;
                            lshape.Left = 110;
                            lshape.Top = l1.Height;
                            p.Controls.Add(lshape);
                      
                        }
                        else
                            break;
                    }
                    if (i == dt.Rows.Count)
                        break;
                    else
                        n += 4;
                    
                }
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    dt.Rows.RemoveAt(i);
                }
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    dt.Rows.RemoveAt(i);
                }
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    dt.Rows.RemoveAt(i);
                }
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    dt.Rows.RemoveAt(i);
                }
            }
            catch (Exception v) { MessageBox.Show(v.Message); }
            finally
            {
                con1.CloseConnection();

            }
        }
        private void p_Click(object sender, EventArgs e)
        {
            p1 = sender as Panel;
            p1.BackColor = Color.DeepSkyBlue;

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] != p1)
                    tableLayoutPanel1.Controls[i].BackColor = Color.AliceBlue;
            }
     
            start = p1.Controls[0].Text;
            end = p1.Controls[1].Text;
            pid = p1.Controls[2].Text;
            pname = p1.Controls[3].Text;            
            op = p1.Controls[4].Text;
            dname = p1.Controls[5].Text;
            //create procedure setescope_endescope(@x nvarchar(50),@s nvarchar(50),@end nvarchar(50),@n nvarchar(50))
            //        as
            // select o.id from setescope_operation o,Endoscope_settings_data e where Datee=@x and start_time=@s and e.EndoscopeCode=o.EndoscopeCode and e.EndoscopeName=@end; 
            //        select doc_ssn from doctors where name=@n;

             
            con1.OpenConection();
            //cmd = new SqlCommand("setescope_endescope", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@x", d);
            //cmd.Parameters.AddWithValue("@s", p1.Controls[0].Text);
            //cmd.Parameters.AddWithValue("@end", endo);
            //cmd.Parameters.AddWithValue("@n", dname);
            //SqlDataAdapter da2 = new SqlDataAdapter(cmd);
            //DataSet ds2 = new DataSet();
            //da2.Fill(ds2);
            types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
            name_input = new string[] { "@x", "@s", "@end", "@n" };
            values = new string[] { d, p1.Controls[0].Text, endo, dname };
            dr = con1.ShowDataInGridViewUsingStoredProcDR("setescope_endescope", name_input, values, types);
            DataTable dt = new DataTable();
            dt.Load(dr);
            opid = dt.Rows[0][0].ToString();

           //d_id = ds2.Tables[1].Rows[0][0].ToString();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            تخدير f = new تخدير();
            f.Show();
        }

        
        private void label20_Click(object sender, EventArgs e)
        {
            Label pp = sender as Label;
            pp.BorderStyle = BorderStyle.FixedSingle;
                endo = "liver Endoscope";            
        }

        private void label21_Click(object sender, EventArgs e)
        {
            endo = "kk Endoscope";            
        }

        

        private void label15_Click(object sender, EventArgs e)
        {
            if (flag == "7agz")
            {

                p1.Controls[6].BackColor = Color.Green;
                try
                {
                    con1.OpenConection();

            //          create procedure updat(@f nvarchar(50),@d nvarchar(50),@s nvarchar(50) ,@n nvarchar(50))
            //            as

            //            update  setescope_operation set flag= @f where Datee = @d and start_time=@s and EndoscopeCode in(select EndoscopeCode from Endoscope_settings_data where EndoscopeName=@n );
            //escope_operation set flag= @f where Datee = @d and start_time=@s and EndoscopeCode in(select EndoscopeCode from Endoscope_settings_data where EndoscopeName=@n );

                    //cmd = new SqlCommand("updat", con);

                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@f", "taked");
                    //cmd.Parameters.AddWithValue("@d", d);
                    //cmd.Parameters.AddWithValue("@s",start);
                    //cmd.Parameters.AddWithValue("@n",endo);
                    //cmd.ExecuteNonQuery(); 
                    types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
                    name_input = new string[] { "@f", "@d", "@s", "@n" };
                    values = new string[] { "taked", d, start, endo };
                    con1.ExecuteNonQueryProcedure("updat", name_input, values, types);
                    flag = "taked";

                    

                }
                catch (Exception v) { MessageBox.Show(v.Message); }
                finally { con1.CloseConnection(); }

            }

            else if (flag == "start")
            {
                MessageBox.Show("لا يمكن  تاكيد الحجز لقد تم بدء العمليه ");
            }
            else if (flag == "finish")
            {
                MessageBox.Show("لا يمكن  تاكيد الحجز لقد تم انهاء العمليه");
            }
            else if (flag == "taked")
            {

                MessageBox.Show("لقد تم التأكيد مسبقا");
            }
               
        }

        private void label14_Click(object sender, EventArgs e)
        {

            if (flag== "7agz" || flag == "taked")
                {
                    p1.Controls[6].BackColor = Color.Cyan;
                    
                    try
                    {
                        con1.OpenConection();
                        //cmd = new SqlCommand("update  setescope_operation set flag= 'start' where Datee = '" + d + "' and start_time='" + start + "'", con);
                               //cmd.ExecuteNonQuery(); flag = "start";
        // create procedure updat(@f nvarchar(50),@d nvarchar(50),@s nvarchar(50) ,@n nvarchar(50))
        //as

        //update  setescope_operation set flag= @f where Datee = @d and start_time=@s and EndoscopeCode in(select EndoscopeCode from Endoscope_settings_data where EndoscopeName=@n );

                        //cmd = new SqlCommand("updat", con);

                        //cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@f", "start");
                        //cmd.Parameters.AddWithValue("@d", d);
                        //cmd.Parameters.AddWithValue("@s", start);
                        //cmd.Parameters.AddWithValue("@n", endo);
                        //cmd.ExecuteNonQuery();
                        types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
                        name_input = new string[] { "@f", "@d", "@s", "@n" };
                        values = new string[] { "start", d, start, endo };
                        con1.ExecuteNonQueryProcedure("updat", name_input, values, types);
                        flag = "start";
                    }
                    catch (Exception v) { MessageBox.Show(v.Message); }
                    finally { con1.CloseConnection(); }
                }
                else if (flag == "finish")
                {
                     MessageBox.Show("لقد تم انهاء العمليه");
                }
                else if (flag == "start")
                {
                     MessageBox.Show("لقد تم بدء العمليه مسبقا");
                }


            }

        private void label16_Click(object sender, EventArgs e)
        {
            if (flag == "7agz" || flag == "taked" || flag == "start")
            {

                con1.CloseConnection();
                con1.OpenConection();
               

                   اداء_عمليه f = new اداء_عمليه();
                   if (f.ShowDialog() == DialogResult.OK)
                    {

                        p1.Controls[1].Text = اداء_عمليه.end;
                        p1.Controls[6].BackColor = Color.Blue;
                    }

            
            }
            else if (flag == "finish")
            {
                MessageBox.Show("لقد تم تنفيذ العمليه من قبل");
            }

       }

       
        private void label17_Click(object sender, EventArgs e)
        {


            //int c = 0;
            //con.Close();
            //con.Open();

            //cmd = new SqlCommand("mostl", con);

            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@x", pid);
            //SqlDataAdapter daa = new SqlDataAdapter(cmd);

            //DataSet sd = new DataSet();
            //daa.Fill(sd);
            //if (sd.Tables[0].Rows.Count != 0)
            //{
            //    c++;
            //}
            //if (c >= 1)
            //{
            //    MessageBox.Show("يلزم سداد تمن المسلتزمات قبل الالغاء");
            //}
            //else
            //{

            Form9 f = new Form9();
            f.Show();


            //}
            //con.Close();
            
        }

        private void label19_Click(object sender, EventArgs e)
        {

            if (flag == "taked" || flag == "7agz")
            {

                تعديل_موعد_العمليه f = new تعديل_موعد_العمليه();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    p1.Controls[0].Text = تعديل_موعد_العمليه.t1;
                    p1.Controls[1].Text = تعديل_موعد_العمليه.t2;


                }

            }
            else if (flag == "start")
            {
                MessageBox.Show("لا يمكنك تعديل الموعد لقد تم البدء فى العمليه");

            }
            else
            {
                MessageBox.Show("لا يمكنك تعديل الموعد لقد تم تنفيذ العمليه");

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        
        

          }

      
       
        
    }

