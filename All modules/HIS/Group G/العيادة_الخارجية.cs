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
    public partial class العيادة_الخارجية : Form
    {
       
        SqlDataReader dr;
        DataTable dt;

        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        public static string name { get; set; }
        public static int id { get; set; }

        public العيادة_الخارجية()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void العيادة_الخارجية_Load(object sender, EventArgs e)
        {
            //con = new SqlConnection("server=localhost;database=graduationDB;uid=root;pwd=root");
            //con.Open();

            //cmd = new SqlCommand("select Clinic_code as كود_العيادة ,Arabic_name as الاسم_العربي ,English_name as  الاسم_الانجليزي from Clinic;", con);
            //cmd = new SqlCommand();
            //cmd.Connection = con;

            //cmd.CommandText = "clinic_select";

            //cmd.CommandType = CommandType.StoredProcedure;
            //dr = cmd.ExecuteReader();

            /*
             * create procedure clinic_select
                    as
                    begin
                     select Clinic_code as 'كود_العيادة' ,Arabic_name as 'الاسم_العربي' ,English_name as 'الاسم_الانجليزي' from Clinic
                     end

             */
            con1.OpenConection();
            dr = con1.DataReader("clinic_select");
            dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        private void cellclick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                name = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                بحث_حجوزات_المرضى ff = new بحث_حجوزات_المرضى();
                ff.Focus();
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show("يجب اختيار عيادة");
            }
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
