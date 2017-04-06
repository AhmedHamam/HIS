using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HIS
{


    public partial class opForm03 : Form
    {
        public opForm02 own = null;
        public SqlDataAdapter da;
        public string OperationName="" , OperationCode="";
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection con;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        BindingSource bs;
        SqlCommandBuilder ba;
        Connection connect;
        public opForm03()
        {
            InitializeComponent();
            connect = new Connection();
        }
        public opForm03(opForm02 own)
        {
            InitializeComponent();
            this.own = own;
            connect = new Connection();
        }

        private void opForm03_Load(object sender, EventArgs e)
        {
            try
            {
                //con = new SqlConnection(@"Server=DESKTOP-LSC6L8E\SQLEXPRESS; Database=phis; Integrated Security=true");
                //if (con.State != ConnectionState.Open) con.Open();

                //cmd = new SqlCommand("select SO_id as 'الكود',SO_Ename as 'الاسم بالانجليزي',SO_Aname as 'الاسم بالعربي',SO_Type as 'الفئه' from tb_Skills_Operations ", con);
                //cmd.Connection = con;
                //SqlDataAdapter da = new SqlDataAdapter(cmd);

                //ds = new DataSet();
                //da.Fill(ds);



                //dataGridView2.DataSource = ds.Tables[0];
                //int x = ds.Tables[0].Rows.Count;

                connect.OpenConection();
                string pName = "op_operation_searc1";
              
               dataGridView2.DataSource= connect.ShowDataInGridViewUsingStoredProc(pName);

                /*
                 * connect.ShowDataInGridViewUsingStoredProc(pName);
                 * connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
                 * connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames, paramValues, paramType);
                 */


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                //dataGridView2.DataSource = null;
                //ds.Tables.Clear();
                //dataGridView2.Rows.Clear();
                //dataGridView2.Refresh();

                //da = new SqlDataAdapter(" select * from  tb_Skills_Operations  where SO_Ename='" + textBox2.Text + "'", con);
                //// cmd.Parameters.AddWithValue("@u", textBox2.Text);
                //SqlCommandBuilder cb = new SqlCommandBuilder(da);
                //da.Fill(ds);
                //dataGridView2.DataSource = ds.Tables[0];


                //if (con.State != ConnectionState.Closed) con.Close();

                connect.OpenConection();
                string pName = "op_operation_searc2";
                string[] paramNames = { "@SO_Ename" };
                string[] paramValues = { textBox2.Text };
                SqlDbType[] paramType = {SqlDbType.VarChar};
                dataGridView2.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);

                /*
                 * connect.ShowDataInGridViewUsingStoredProc(pName);
                 * connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
                 * connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames, paramValues, paramType);
                 */

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                textBox2.Text = " ";

                //cmd = new SqlCommand("select SO_id as 'الكود',SO_Ename as 'الاسم بالانجليزي',SO_Aname as 'الاسم بالعربي',SO_Type as 'الفئه' from tb_Skills_Operations ", con);
                //cmd.Connection = con;
                //dr = cmd.ExecuteReader();
                //dt = new DataTable();
                //dt.Load(dr);
                //dataGridView2.DataSource = dt;
                //dr.Close();


                /*
                 * connect.ShowDataInGridViewUsingStoredProc(pName);
                 * connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
             */
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_field_describtion_Click(object sender, EventArgs e)
        {
            /*
            try { 
            if (con.State != ConnectionState.Open)
                if(con.State!=ConnectionState.Open)con.Open();

            for (int i = dataGridView2.Rows.Count - 1; i >= 0; --i)
            {
                if (dataGridView2.Rows[i].Selected == true)
                {
                    string code = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    cmd = new SqlCommand("delete from side where s_code= '" + code + "'", con);
                    dataGridView2.Rows.RemoveAt(i);
                    cmd.ExecuteNonQuery();
                }
            }
           
               
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            if (con.State != ConnectionState.Closed)
                if(con.State!=ConnectionState.Closed)con.Close();
                */
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                connect.OpenConection();
                string pName = "op_operation_searc5";
                string[] paramNames = { "@opl_arabic_name" };
                string[] paramValues = { textBox2.Text };
                SqlDbType[] paramType = { SqlDbType.VarChar };
                dataGridView2.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
                /*
                cmd = new SqlCommand("select SO_id as 'الكود',SO_Ename as 'الاسم بالانجليزي',SO_Aname as 'الاسم بالعربي',SO_Type as 'الفئه' from tb_Skills_Operations where SO_Aname like '" + textBox2.Text + "%'", con);
                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                dataGridView2.DataSource = dt;
                dr.Close();*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

       

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OperationCode = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            OperationName = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            Close();

        }
        

    }
}

