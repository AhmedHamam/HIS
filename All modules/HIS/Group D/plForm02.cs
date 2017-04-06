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
    public partial class plForm02 : Form
    {
        SqlConnection con;
        SqlDataReader dr;
        DataTable dt;
        Connection connect;
        BindingSource bs;
        SqlDataAdapter da;
        SqlCommandBuilder ba;

        public plForm02()
        {
            InitializeComponent();
            connect = new Connection(); //
            dt = new DataTable();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (Class1.chkNum(textBox1.Text))
            {
                connect.OpenConection();
                string pName = "planing_planingJob";
                string[] paramNames = { "@j_code" };
                string[] paramValues = { textBox1.Text };
                SqlDbType[] paramType = { SqlDbType.VarChar };
                dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
               
                
                
            }
            else
                MessageBox.Show("قم بادخال الكود كرقم ");
          

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (Class1.chkArabicName(textBox8.Text))
            {
                connect.OpenConection();
                string pName = "planing_planingJob1";
                string[] paramNames = { "@describ" };
                string[] paramValues = { textBox8.Text };
                SqlDbType[] paramType = { SqlDbType.VarChar };

                dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
               


            }
            else
                MessageBox.Show("قم بادخال الوصف  بالعربي ");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }


        private void plForm02_Load(object sender, EventArgs e)
        {
            
           
            connect.OpenConection();
            string pName = "planing_planingJob2";
            dt  = (DataTable)connect.ShowDataInGridViewUsingStoredProc(pName);
            dataGridView1.DataSource = dt;



        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

       // da = new SqlDataAdapter("select prof_code ,describ from profession;", con);
        private void button1_Click(object sender, EventArgs e)
        {
            ba = new SqlCommandBuilder(da);
            if (dataGridView1.DataSource == null)
            {
                DataRow ob1 = dt.NewRow();
                dt.Rows.Add(ob1);
                da = new SqlDataAdapter("select s_code,s_name,prices,num_plo from side;", con);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dataGridView1.DataSource = bs;
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            else
            {
                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                dataGridView1.DataSource = dt;
                
            }
        



        

    }
        private void button3_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
                con.Open();
           
           
           
               
            string describ = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value.ToString();
            string year = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value.ToString();
            string profession_job = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value.ToString();
            string p_state = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value.ToString();
            string date = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Value.ToString();
            string employee_state = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[6].Value.ToString();
            string p_kind = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[7].Value.ToString();
            string j_code = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[8].Value.ToString();
            


            connect.OpenConection();
            string pName = "planing_planingJob4";
            string[] paramNames = { "@describ","@year","@profession_job","@p_state","@date","@employee_state","@p_kind","@j_code" };
            string[] paramValues = { describ,year,profession_job,p_state,date,employee_state,p_kind,j_code };
            SqlDbType[] paramType = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };
            connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames, paramValues, paramType);
            MessageBox.Show("تم الحفظ بنجاح ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Open)
                con.Open();

            for (int i = dataGridView1.Rows.Count - 1; i >= 0; --i)
            {

                if (dataGridView1.Rows[i].Selected == true)
                {
                    string pName = "planing_planingJob5";
                    string[] paramNames = { "@p_code" };

                    SqlDbType[] paramType = { SqlDbType.VarChar };
                    string[] paramValues = {textBox1.Text };
                    connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames,paramValues, paramType);
                    
                }
            }
            if (con.State != ConnectionState.Closed)
                con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
