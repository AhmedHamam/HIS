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
    public partial class بحث_موظف : Form
    {
        public بحث_موظف()
        {
            InitializeComponent();
        }
        Connection con = new Connection();
        //SqlCommand cmd;
        //DataTable dt;
        //SqlConnection con = new SqlConnection(@"server=.\SQLEXPRESS;database=manal;Integrated Security=true;");
        private void بحث_موظف_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            //MessageBox.Show(صيانة_طلب_غرفة_منظار .item+ "      ");
            try
            {
                string[] pramname = new string[1];
                string[] pramvalue = new string[1];
                SqlDbType[] pramtype = new SqlDbType[1];
                pramname[0] = "@j";
                pramvalue[0] = صيانة_طلب_غرفة_منظار.item;
                pramtype[0] = SqlDbType.VarChar;

                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("setescope_employee_id", pramname, pramvalue, pramtype);
                //cmd = new SqlCommand("setescope_employee_id", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@j", صيانة_طلب_غرفة_منظار.item);
                //SqlDataReader dr = cmd.ExecuteReader();
                //dt = new DataTable();
                //dt.Load(dr);

                //dr.Close();
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        public static int code { get; set; }
        public static string name { get; set; }
        private void cellcontent(object sender, DataGridViewCellEventArgs e)
        {
            code = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            صيانة_طلب_غرفة_منظار f = new صيانة_طلب_غرفة_منظار();
            f.Focus();
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public static int x { get; set; }
        public static string y { get; set; }
        private void data_Double_Click(object sender, DataGridViewCellEventArgs e)
        {
            x = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            y = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //MessageBox.Show(x.ToString());
            صيانة_طلب_غرفة_منظار f = new صيانة_طلب_غرفة_منظار();
            f.Focus();
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }
    }
}
