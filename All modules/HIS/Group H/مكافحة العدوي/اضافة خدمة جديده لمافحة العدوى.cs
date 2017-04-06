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
    public partial class اضافة_خدمة_جديده_لمافحة_العدوى : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        static string str;
        BindingSource bs;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        public اضافة_خدمة_جديده_لمافحة_العدوى()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            ds.Tables.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();

            try
            {

                cmd = new SqlCommand("insert into Services(Service_Arabic_name,Service_English_name,service_kind,service_appointment) values (@x2,@x3,@x4,@x5);", con);

                cmd.Parameters.AddWithValue("@x2", textBox1.Text);
                cmd.Parameters.AddWithValue("@x3", textBox2.Text);
                cmd.Parameters.AddWithValue("@x4", comboBox1.SelectedItem);
                cmd.Parameters.AddWithValue("@x5", str);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("تم ادخال البيانات بنجاح");
                textBox1.Text = null;
                textBox2.Text = null;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


            try
            {
                con.Open();
                cmd = new SqlCommand("select * from  Services;", con);
                da = new SqlDataAdapter(cmd);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                da.Fill(ds);
                bs = new BindingSource();
                bs.DataSource = ds.Tables[0];
                dataGridView1.DataSource = bs;
                con.Close();



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            con.Close();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            str = dateTimePicker1.Value.ToString();

        }

        private void اضافة_خدمة_جديده_لمافحة_العدوى_Load(object sender, EventArgs e)
        {


            con = new SqlConnection("server=localhost;database=hospital;uid=root;pwd=root");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void حذف_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                if (cell.Selected)
                {
                    dataGridView1.Rows.RemoveAt(cell.RowIndex);
                }
                bs.EndEdit();
                da.Update(ds);

            }
            MessageBox.Show("تم الحذف");
        }





        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {




        }
    }
}
