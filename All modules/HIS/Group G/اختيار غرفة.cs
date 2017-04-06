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
    public partial class اختيار_غرفة : Form
    {
        public اختيار_غرفة()
        {
            InitializeComponent();
        }

        Connection con = new Connection();
        //SqlCommand cmd;
        //DataSet ds = new DataSet();
        //SqlConnection con = new SqlConnection(@"server=.\SQLEXPRESS;database=manal;Integrated Security=true;");
        private void Form2_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("setescope_rooms_select");
            con.CloseConnection();
            //dataGridView1.DataSource = null;
            //ds.Tables.Clear();
            //con.Open();
            //try
            //{
            //    cmd = new SqlCommand("setescope_Endoscope_room_select", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.ExecuteNonQuery();

            //}           
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //SqlDataReader dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //dataGridView1.DataSource = dt;
            //dr.Close();
            //con.Close();
            //con.Close();
        }
        public static int x { get; set; }
        private void data_Double_Click(object sender, DataGridViewCellEventArgs e)
        {
            x = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            //MessageBox.Show(x.ToString());
            صيانة_طلب_غرفة_منظار f = new صيانة_طلب_غرفة_منظار();
            f.Focus();
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }






    }
}
