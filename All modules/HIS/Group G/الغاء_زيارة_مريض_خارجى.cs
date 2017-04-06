using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
namespace HIS
{
    public partial class الغاء_زيارة_مريض_خارجى : Form
    {
        DateTime date;
        DateTime datet;
        int s, s1;
        //SqlConnection con;
        //SqlCommand cmd;
        //SqlDataReader dr;
        Connection con1 = new Connection();
        int count = 0;

        string[] name_input;
        string[] values;
        SqlDbType[] types;

        public الغاء_زيارة_مريض_خارجى()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            سبب_الالغاء_المنظار1 f = new سبب_الالغاء_المنظار1();
            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = سبب_الالغاء_المنظار1.reason;
            }
        }


        private void الغاء_زيارة_مريض_خارجى_Load(object sender, EventArgs e)
        {
            s = int.Parse(محرك_البحث_عن_المرضى_الغاء.Code.ToString());
            s1 = int.Parse(محرك_البحث_عن_المرضى_الغاء.max_visit.ToString());
            con1.OpenConection();

            string query = "select patient_id,patient_name, gender,job from Registeration_patientRegisteration where patient_id = " + s + " ;";
            SqlDataReader dr = con1.DataReader(query);

            while (dr.Read())
            {
                label10.Visible = true;
                label11.Visible = true;
                //   label12.Visible = true;
                label13.Visible = true;
                label15.Visible = true;
                label10.Text = dr[0].ToString();
                label11.Text = dr[1].ToString();
                //label12.Text = dr[2].ToString();
                label13.Text = dr[2].ToString();
                label15.Text = dr[3].ToString();

            }
            dr.Close();
            con1.CloseConnection();
            /*
             * create procedure clinic_patient_visit_time_select(@s1 int)
                    as
                    begin
                    select start_date from patient_visit where num_of_visit = @s1
                    end
             * 
             */

            con1.OpenConection();
            types = new SqlDbType[] { SqlDbType.Int };
            name_input = new string[] { "@s1" };
            values = new string[] { s1.ToString() };

            object ob = con1.ShowDataInGridViewUsingStoredProc("clinic_entranceoffice_visit_time_select", name_input, values, types);

            ////////////  date = Convert.ToDateTime(ob.ToString());
            //////////////  date = (DateTime)ob;
            ////////////  string dd = date.Date.ToString("yyyy-MM-dd");

            ////////////  label14.Visible = true;
            ////////////  label14.Text = dd;

            datet = DateTime.Now;

            label17.Visible = true;
            label17.Text = datet.ToString("yyyy-MM-dd");

            textBox1.Text = datet.ToString("yyyy-MM-dd");
            con1.CloseConnection();

        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int f;
            if (int.TryParse(textBox3.Text, out f))
            {
                MessageBox.Show("يجب ادخال نص مناسب");
            }
            else
            {
                if (textBox3.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("يجب ادخال البيانات الناقصة");
                }
                else
                {
                    /*create procedure clinic_patient_visit_update_cancel_date(@c_date date,@s int, @s1 int)
                        as
                        begin
                         update patient_visit set cancel_date =@c_date,cancel_type ='canceled' where P_id =@s and num_of_visit =@s1;
                        end

                     */
                    //con.Open();
                    //cmd = new SqlCommand();
                    //cmd.Connection = con;
                    ////cmd.CommandText = "update patient_visit set cancel_date = ' " + datet.ToString("yyyy-MM-dd") + " ' where P_id = " + s + " and num_of_visit = " + s1;
                    //cmd.CommandText = "clinic_patient_visit_update_cancel_date";
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@s", s);
                    //cmd.Parameters.AddWithValue("@s1", s1);
                    //cmd.Parameters.AddWithValue("@c_date", datet.ToString("yyyy-MM-dd"));
                    //cmd.ExecuteNonQuery();
                    //con.Close();
                    con1.OpenConection();
                    types = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.Date };
                    name_input = new string[] { "@s", "@s1", "@c_date" };
                    values = new string[] { s.ToString(), s1.ToString(), datet.ToString("yyyy-MM-dd") };
                    con1.ExecuteNonQueryProcedure("clinic_entranceoffice_visit_update_cancel_date", name_input, values, types);
                    con1.CloseConnection();
                    MessageBox.Show(" تم عملية الحفظ بنجاح ");
                }

            }
        }

        private void اتنااهعهعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int f;
            if (!int.TryParse(textBox3.Text, out f))
            {

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


    }
}
