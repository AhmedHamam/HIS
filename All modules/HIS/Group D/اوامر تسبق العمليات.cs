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
    public partial class opForm12 : Form
    {
        public SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlConnection con;
        Connection connect;
        DataSet ds = new DataSet();
        public opForm12()
        {
            InitializeComponent();
            connect = new Connection();
           
        }

        public opForm12(string x)
        {
            try
            {
                /*
                InitializeComponent();
                con = new SqlConnection(@"Server=DESKTOP-LSC6L8E\SQLEXPRESS; Database=phis; Integrated Security=true");
                if (con.State != ConnectionState.Open) con.Open();
                textBox1.Text = x;
                da = new SqlDataAdapter(" select * from pre_order where op_code='" + x + "'", con);

                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                 * */

                connect.OpenConection();
                string pName = "op_orderpre_operation1";
                string[] paramNames = { "@op_code" };
                string[] paramValues = { textBox1.Text};
                SqlDbType[] paramType = { SqlDbType.VarChar };
                dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void opForm12_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                /*string sql = "insert into pre_order values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox1.Text + "');";
                
                cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();*/
                connect.OpenConection();
                string pName = "op_orderpre_operation2";
                string[] paramNames = { "@var1","@var2", "@var3", "@var4","@var5" };
                string[] paramValues = { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text };
                SqlDbType[] paramType = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };
                connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames, paramValues, paramType);
                MessageBox.Show("preorder saved is saved");
                //textBox1.Text = "";
                //textBox2.Text = "";
                //textBox3.Text = "";
                //textBox4.Text = "";
                //textBox5.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked &&
                    !radioButton4.Checked && !radioButton5.Checked)
                {
                    /*da = new SqlDataAdapter(" select * from pre_order where name='" + textBox2.Text + "'", con);
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];*/
                    connect.OpenConection();
                    string pName = "op_orderpre_operation3";
                    string[] paramNames = { "@name" };
                    string[] paramValues = { textBox2.Text };
                    SqlDbType[] paramType = { SqlDbType.VarChar };
                    dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);


                    this.Show();
                }
                else if (!radioButton1.Checked && radioButton2.Checked && !radioButton3.Checked &&
                    !radioButton4.Checked && !radioButton5.Checked)
                {
                    /*
                    da = new SqlDataAdapter(" select * from pre_order where day_before_operation=" + textBox4.Text + "", con);
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];*/
                    connect.OpenConection();
                    string pName = "op_orderpre_operation4";
                    string[] paramNames = { "@day_before_operation" };
                    string[] paramValues = { textBox4.Text };
                    SqlDbType[] paramType = { SqlDbType.VarChar };
                    dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);

                    this.Show();
                }
                else if (!radioButton1.Checked && !radioButton2.Checked && radioButton3.Checked &&
                    !radioButton4.Checked && !radioButton5.Checked)
                {
                    /*da = new SqlDataAdapter(" select * from pre_order where mandatory='" + textBox5.Text + "'", con);
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];*/
                    connect.OpenConection();
                    string pName = "op_orderpre_operation5";
                    string[] paramNames = { "@mandatory" };
                    string[] paramValues = { textBox5.Text };
                    SqlDbType[] paramType = { SqlDbType.VarChar };
                    dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);

                   
                    this.Show();
                }
                else if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked &&
                    radioButton4.Checked && !radioButton5.Checked)
                {
                    /*da = new SqlDataAdapter(" select * from pre_order where place='" + textBox3.Text + "'", con);
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];*/
                    connect.OpenConection();
                    string pName = "op_orderpre_operation6";
                    string[] paramNames = { "@place" };
                    string[] paramValues = { textBox3.Text };
                    SqlDbType[] paramType = { SqlDbType.VarChar };
                    dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);

                    this.Show();
                }
                else if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked &&
                    !radioButton4.Checked && radioButton5.Checked)
                {
                   /* da = new SqlDataAdapter(" select * from pre_order where op_code='" + textBox1.Text + "'", con);
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    ds.Clear();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];*/
                    connect.OpenConection();
                    string pName = "op_orderpre_operation7";
                    string[] paramNames = { "@op_code" };
                    string[] paramValues = { textBox1.Text };
                    SqlDbType[] paramType = { SqlDbType.VarChar };
                    dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);


                    this.Show();
                }
                else
                    MessageBox.Show("Please select one value");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {

               

                for (int i = dataGridView1.Rows.Count - 1; i >= 0; --i)
                {
                    if (dataGridView1.Rows[i].Selected == true)
                    {
                        /*
                        
                        cmd = new SqlCommand("delete from pre_order where order_code = '" + code + "'", con);
                        dataGridView1.Rows.RemoveAt(i);
                        cmd.ExecuteNonQuery();*/
                        connect.OpenConection();
                        string code = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        string pName = "op_orderpre_operation8";
                        string[] paramNames = { "@order_code"};
                        string[] paramValues = { code };
                        SqlDbType[] paramType = { SqlDbType.VarChar };
                        connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames, paramValues, paramType);


                        MessageBox.Show("تم حذف الاوامر التى تسبق العمليه ");
                    }
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
