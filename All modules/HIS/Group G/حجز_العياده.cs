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
    public partial class حجز_العياده : Form
    {
        int number_patient, code;
        string name, patient_name, geha, service, p_name, p_name2;

        public static int count { get; set; }
        public static string names = "";

        SqlDataReader dr;
        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        Button[] btn = new Button[6];


        Label clinic_name = new Label();

        public حجز_العياده(int c, string n)
        {
            InitializeComponent();
            name = n;
            code = c;


        }


        public حجز_العياده()
        {
            InitializeComponent();
            clinic_name.Text = number_patient.ToString() + "" + dateTimePicker1.Text + "" + patient_name + "" + geha;
            panel3.Controls.Add(clinic_name);


        }












        //For button جدوله عياده
        private void button32_Click(object sender, EventArgs e)
        {
            جدولة_العيادات f = new جدولة_العيادات();
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (listBox1.Items.Contains(names))
                {
                    MessageBox.Show("انت قمت بادخال هذه العياده");
                }
                else
                {
                    listBox1.Items.Add(names);
                    code = Convert.ToInt32(f.textBox1.Text);
                    // con = new SqlConnection(@"server=SANDRA-PC\SQLEXPRESS;database=project_db; Integrated Security=true;");
                    // con.Open();

                    // cmd = new SqlCommand("select arabic_des from clinic_service where ccode=" + code + "", con);
                    con1.OpenConection();
                    dr = con1.DataReader("select SLS_Aname from tb_Second_Level_Service where [SLS_Service_Category]='Outer_Clinic' and [SLS_Status]=1");
                    try
                    {
                        //dr = cmd.ExecuteReader();
                        service = "";
                        while (dr.Read())
                        {
                            service = dr[0].ToString();
                        }
                        if (String.IsNullOrEmpty(service))
                        {
                            service = "لا توجد خدمه في هذه العياده";
                            listBox3.Items.Add(service);
                        }
                        else
                        {
                            listBox3.Items.Add(service);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con1.CloseConnection();
                    }
                }


            }

        }
        //For button add new patient
        private void التسجيلوالحجزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            التسجيل f = new التسجيل(code);
            if (f.ShowDialog() == DialogResult.OK)
            {
                //label10.Text = f.x.ToString();
                //label10.Visible = true;
                //label11.Text = f.n;
                //label11.Visible = true;
                listBox2.Items.Add(f.x.ToString() + "     " + f.n);
                p_name = f.x.ToString();
                p_name2 = f.n;

            }
        }

        //For open form البحث_الحجز
        private void البحثوالحجزToolStripMenuItem_Click(object sender, EventArgs e)
        {
            محرك_البحث_للحجز f = new محرك_البحث_للحجز(code);
            if (f.ShowDialog() == DialogResult.OK)
            {
                //label10.Text = f.name1;
                //label10.Visible = true;
                //label11.Text = f.name2;
                //label11.Visible = true;
                listBox2.Items.Add(f.name1 + "    " + f.name2);
                p_name = f.name1;
                p_name2 = f.name2;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * create procedure [dbo].[clinic_حجز_العياده_clinic_service](@c int)
            as
            begin
            select SLS_Aname from tb_Second_Level_Service where [SLS_Service_Category]='Outer_Clinic' and [SLS_Status]=1 and c_code=@c
            end

             */
            names = listBox1.Text;
            con1.OpenConection();
            // types = new SqlDbType[] {SqlDbType.NVarChar };
            //name_input = new string[] { "@ser" };
            //values = new string[] { names };
            types = new SqlDbType[] { SqlDbType.Int };
            name_input = new string[] { "@c" };
            values = new string[] { code.ToString() };
            dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_حجز_العياده_clinic_service", name_input, values, types);

            //con = new SqlConnection(@"server=SANDRA-PC\SQLEXPRESS;database=project_db; Integrated Security=true;");
            //con.Open();
            //cmd = new SqlCommand("select clinic_code from clinic where arabic_name like'" + names + "%'"+"select arabic_des from clinic_service where ccode=" + code + "" , con);

            while (dr.Read())
            {
                listBox3.Items.Clear();
                service = dr[0].ToString();
                listBox3.Items.Add(service);

            }
            MessageBox.Show("انت قمت باختيار عيادة " + " " + names);
            dr.Close();
            con1.CloseConnection();

        }
        //For exit
        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //For add service for patient
        void count_insert()
        {



            //create procedure clinic_حجز_العياده_count_num_of_visit(@fn nvarchar(50),@ln nvarchar(50))
            //as
            //begin
            //select Max(num_Of_visit)+1 
            //from patient_visit,patient 
            //where P_id =patient_id and fname like N'%'+@fn+'%' and lname like N'%'+@ln+'%'
            //end
            // cmd = new SqlCommand("select count(num_of_visit) from patient_visit where p_id=select patient_id from patient where fname=" +p_name+"and lname= "+p_name2+" ", con);
            //dr = cmd.ExecuteReader();

            //create procedure clinic_حجز_العياده_count_num_of_visit(@fn varchar(50))
            //as
            //begin
            //select Max(visit_id)+1 
            //from entranceoffice_visit,Registeration_patientRegisteration 
            //where pat_id =patient_id and patient_name like N'%'+@fn+'%'
            //end
            con1.OpenConection();
            string f_name = p_name + "" + p_name2;
            types = new SqlDbType[] { SqlDbType.VarChar };
            name_input = new string[] { "@fn" };
            values = new string[] { f_name };
            dr = con1.ShowDataInGridViewUsingStoredProcDR("clinic_حجز_العياده_count_num_of_visit", name_input, values, types);
            while (dr.Read())
            {
                count = Convert.ToInt32(dr[0].ToString());

            }
            dr.Close();
            con1.CloseConnection();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //cmd = new SqlCommand("update patient_visit set service_name="+service+" where num_of_visit=" + count + " and p_id=select patient_id from patient where fname=" + p_name + "and lname= " + p_name2 + "  ", con);
            //con1.ExecuteQueries("update patient_visit set service_name="+service+" where num_of_visit=" + count + " and p_id=select patient_id from patient where fname=" + p_name + "and lname= " + p_name2 );

            //create procedure update_service_to_patient(@ser nvarchar(60),@count int,@name varchar(50))
            //    as
            //    begin
            //    update entranceoffice_visit set service_name=N'%'+@ser+'%' where visit_id=@count and pat_id=(select patient_id from Registeration_patientRegisteration  where patient_name like N'%' + @name +'%') 
            //    end
            string f_name = p_name + "" + p_name2;
            con1.OpenConection();
            name_input = new string[] { "@ser", "@count", "@name" };
            types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.Int, SqlDbType.VarChar };
            values = new string[] { service, Convert.ToString(count), f_name };
            con1.ExecuteNonQueryProcedure("update_service_to_patient", name_input, values, types);
            try
            {
                // cmd.ExecuteNonQuery();
                MessageBox.Show("تم اضافه الخدمه ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con1.CloseConnection();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            اعدادات_العيادات_الخارجية f = new اعدادات_العيادات_الخارجية();
            f.Show();
        }





    }
}
