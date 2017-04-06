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
    public partial class حاله_موافقات_الحجز : Form
    {

        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataSet ds;
        BindingSource bs;
        DataTable dt;
        int count;
        public حاله_موافقات_الحجز()
        {
            InitializeComponent();
        }

        private void حاله_موافقات_الحجز_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            الجههات f = new الجههات();


            if (f.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = الجههات.Code1.ToString();
                textBox3.Text = الجههات.Code2.ToString();
            }
        }

        private void حفظ_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                con.OpenConection();
                try
                {

                    string s = "select Registeration_patientRegisteration.patient_id ,Registeration_patientRegisteration.patient_name,entranceoffice_visit.visit_id,entranceoffice_internalpatient.direction_name from Registeration_patientRegisteration,entranceoffice_visit,entranceoffice_internalpatient where patient_name=@p";
                    cmd = new SqlCommand(s, con.con);
                    cmd.Parameters.AddWithValue("@p", textBox1.Text);

                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { con.CloseConnection(); }
            }



            else if (textBox3.Text != "" && textBox2.Text != "")
            {
                con.OpenConection();
                try
                {

                    string s = "select Registeration_patientRegisteration.patient_id ,Registeration_patientRegisteration.patient_name,entranceoffice_visit.visit_id,entranceoffice_internalpatient.direction_name from Registeration_patientRegisteration,entranceoffice_visit,entranceoffice_internalpatient where direction_name=@p and direction_id=@c";
                    cmd = new SqlCommand(s, con.con);
                    cmd.Parameters.AddWithValue("@p", textBox3.Text);
                    cmd.Parameters.AddWithValue("@c", textBox2.Text);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { con.CloseConnection(); }
            }
            else 
            {
                con.OpenConection();
                try
                {
                    string s = "select Registeration_patientRegisteration.patient_id ,Registeration_patientRegisteration.patient_name,entranceoffice_visit.visit_id,entranceoffice_internalpatient.direction_name from Registeration_patientRegisteration,entranceoffice_visit,entranceoffice_internalpatient ";
                    cmd = new SqlCommand(s, con.con);

                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { con.CloseConnection(); }
            }

        }
    }
}
