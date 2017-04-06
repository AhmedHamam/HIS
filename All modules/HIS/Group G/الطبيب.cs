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
    public partial class الطبيب : Form
    {
        
        SqlDataReader dr;
        DataTable dt;

        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        

        public static string name { get; set; }
        public static int id { get; set; }
         
        public الطبيب()
        {
            InitializeComponent();
        }

        private void الطبيب_Load(object sender, EventArgs e)
        {

          //  //con = new SqlConnection("server=localhost;database=graduationDB;uid=root;pwd=root");

          ////  con.Open();
          //  //cmd = new SqlCommand("select doctor_id as كود_الطبيب ,doc_name as اسم_الدكتور ,specialization as التخصص  from doctor;", con);
          //  cmd = new SqlCommand();
          //  cmd.Connection = con;

            //cmd.CommandText = "clinic_Doctor_select";
            //cmd.CommandType = CommandType.StoredProcedure;

            /*
             * create procedure clinic_Doctor_select
            as
            begin
              select doctor_id  ,doc_name ,specialization  from doctor;
            end

             */

            con1.OpenConection();
            dr = con1.DataReader("clinic_Doctor_select");
            dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            con1.CloseConnection();
        }

        private void cellclick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                بحث_حجوزات_المرضى ff = new بحث_حجوزات_المرضى();
                ff.Focus();
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(" يجب اختيار طبيب");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
