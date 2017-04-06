using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIS
{
    public partial class work_direction : Form
    {
        SqlConnection con ;
        
       
        public work_direction()
        {
            
            InitializeComponent();
            Connection conn = new Connection();
            string constr = conn.getconstr();
            con = new SqlConnection(constr);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //Connection mycon = new Connection();
            //mycon.OpenConection();
            con.Open();
            try
            {

                SqlCommand cmd = new SqlCommand("pro", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Code", txt_Code.Text);
                cmd.Parameters.AddWithValue("@latin", textBox1.Text);
                cmd.Parameters.AddWithValue("@arabic", txt_Latin.Text);
                cmd.ExecuteNonQuery();



                MessageBox.Show("تم التسجيل بنجاح");
                con.Close();
                loodManegment();
            }
            catch (Exception)
            {
                MessageBox.Show("هذا الكود موجود مسبقا نرجو تغير الكود");

            }
            finally
            {
                txt_Code.Text = "";
                txt_Latin.Text = "";
                textBox1.Text = "";

                con.Close();
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            //Connection mycon = new Connection();
            //mycon.OpenConection();
            con.Open();
            try
            {
                int RowIndex = dataGridView1.CurrentCell.RowIndex;

                int code = Int32.Parse(dataGridView1.Rows[RowIndex].Cells[0].Value.ToString());


                SqlCommand cmd = new SqlCommand("p13",con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Code", txt_Code.Text);


                cmd.ExecuteNonQuery();



                MessageBox.Show("تم الحذف بنجاح");
                con.Close();
                loodManegment();
            }
            catch (Exception)
            {
                MessageBox.Show("لا يمكن حذف هذه الادارة ");

            }
            finally
            {
                txt_Code.Text = "";
                txt_Latin.Text = "";
                textBox1.Text = "";
                con.Close();
            }
        }

        private void work_direction_Load(object sender, EventArgs e)
        {
            //conn = new SqlConnection(@"Server=.;Database=HIS;Trusted_Connection=True;");
           
            loodManegment();
        }


        private void loodManegment()
        {
            //Connection mycon = new Connection();
            //mycon.OpenConection();
            con.Open();
            dataGridView1.DataSource = null;
            
           // var c = new SqlConnection(@"Server=.;Database=HIS;Trusted_Connection=True;");
            SqlCommand cmd = new SqlCommand("p16", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //var select = "SELECT * FROM workdirection";
            //var c = new SqlConnection(@"Server=.;Database=HIS;Trusted_Connection=True;");
            // Your Connection String here
            var dataAdapter = new SqlDataAdapter(cmd);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            
            //dataGridView1.Columns[0].HeaderText = "رقم المسلسل";
            //dataGridView1.Columns[1].HeaderText = "الكود";
            //dataGridView1.Columns[2].HeaderText = "الاسم العربى";
            //dataGridView1.Columns[3].HeaderText = "الاسم اللاتينى";
            con.Close();
        }


        private void txt_Latin_TextChanged(object sender, EventArgs e)
        {
        }
        private void txt_Code_TextChanged(object sender, EventArgs e)
        { 
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void showData()
        {
            Connection mycon = new Connection();
            mycon.OpenConection();
            //con.Open();

            DataTable dt = (DataTable)mycon.ShowDataInGridView("select id_workdirection,[arabic name],[english name] from workdirection;");

            dataGridView1.DataSource = dt;
            mycon.CloseConnection();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //con.Open();
            try
            {

                Connection mycon = new Connection();
                string[] pname = {"@Code" , "@latin", "@arabic"};
            string[] pvalue = {txt_Code.Text, textBox1.Text, txt_Latin.Text};
            SqlDbType[] ptype = {SqlDbType.Int, SqlDbType.NChar, SqlDbType.NChar};
            mycon.OpenConection();
            mycon.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("pp", pname, pvalue, ptype);
            mycon.CloseConnection();
                /*SqlCommand cmd = new SqlCommand("pp", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Code", txt_Code.Text);
                cmd.Parameters.AddWithValue("@latin", textBox1.Text);
                cmd.Parameters.AddWithValue("@arabic", txt_Latin.Text);
                
                cmd.ExecuteNonQuery();*/
                showData();
                MessageBox.Show("  يتم التعديل", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {

                MessageBox.Show(" لم يتم التعديل", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally
            {
                txt_Code.Text = "";
                txt_Latin.Text = "";
                textBox1.Text = "";
                //conn.Close();
            }
        }

    }
}
