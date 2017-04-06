using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HIS.Group_H.Medical
{
    public partial class صور_مكونات_جسم_الانسان : Form
    {
        static int id;
        static string ss;
        Connection con = new Connection();
        SqlDataReader dr;
        object s = new object();
        DataTable dt = new DataTable();
        int count;
        public صور_مكونات_جسم_الانسان()
        {
            InitializeComponent();
        }

        private void صور_مكونات_جسم_الانسان_Load(object sender, EventArgs e)
        {
            textBox1.Visible = false;
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"server=DESKTOP-O8UNQHD\SQLEXPRESS;database=hh;Integrated Security=true");
            conn.Open();
            SqlCommand cmd = new SqlCommand("select imgpath from MedicalSheet_BodyComponentPhoto where  image_component_Id=@x", conn);
            cmd.Parameters.AddWithValue("@x", textBox1.Text);
            ss = (cmd.ExecuteScalar().ToString());
            شيتات a = new شيتات();
            a.SetValue2(ss);
            conn.Close();
          
        }

        private void button19_Click(object sender, EventArgs e)
        {
            count = dt.Rows.Count - 1;
            if (count < dt.Rows.Count)
            {
                textBox1.Text = dt.Rows[count][0].ToString();
                pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                richTextBox1.Text = (string)dt.Rows[count][2];
            }
            else
                MessageBox.Show("لايوجد صور اخرى ");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            count--;
            if (count >= 0)
            {
                textBox1.Text = dt.Rows[count][0].ToString();
                pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                richTextBox1.Text = (string)dt.Rows[count][2];
            }
            else
                MessageBox.Show("لايوجد صور اخرى ");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            count++;
            if (count < dt.Rows.Count)
            {
                textBox1.Text = dt.Rows[count][0].ToString();
                pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                richTextBox1.Text = (string)dt.Rows[count][2];
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            count = 0;
            textBox1.Text = dt.Rows[count][0].ToString();
            pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
            richTextBox1.Text = (string)dt.Rows[count][2];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();

                dr = con.DataReader("MedicalSheet_BodyComponentPhoto_select_Muscular");

                dt.Clear();
                dt.Load(dr);
                count = 0;
                textBox1.Text = dt.Rows[count][0].ToString();
                pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                richTextBox1.Text = (string)dt.Rows[count][2];



                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show("لاتوجد صور");
            }  

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();

                dr = con.DataReader("MedicalSheet_BodyComponentPhoto_select_lymphatic ");
                dt.Clear();
                dt.Load(dr);

                textBox1.Clear();
                pictureBox1.Refresh();
                richTextBox1.Clear();
                count = 0;
                textBox1.Text = dt.Rows[count][0].ToString();
                pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                richTextBox1.Text = (string)dt.Rows[count][2];



                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show("لاتوجد صور");
            }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();

                dr = con.DataReader("MedicalSheet_BodyComponentPhoto_select_eye");
                dt.Clear();
                dt.Load(dr);
                textBox1.Clear();
                pictureBox1.Refresh();
                richTextBox1.Clear();
                count = 0;
                textBox1.Text = dt.Rows[count][0].ToString();
                pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                richTextBox1.Text = (string)dt.Rows[count][2];



                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show("لاتوجد صور");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                con.OpenConection();

                dr = con.DataReader("MedicalSheet_BodyComponentPhoto_select_ear");
                dt.Clear();
                dt.Load(dr);

                count = 0;
                textBox1.Text = dt.Rows[count][0].ToString();
                pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                richTextBox1.Text = (string)dt.Rows[count][2];



                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show("لاتوجد صور");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();

                dr = con.DataReader("MedicalSheet_BodyComponentPhoto_select_digestive");
                dt.Clear();
                dt.Load(dr);

                count = 0;
                textBox1.Text = dt.Rows[count][0].ToString();
                pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                richTextBox1.Text = (string)dt.Rows[count][2];



                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show("لاتوجد صور");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                con.OpenConection();

                dr = con.DataReader("MedicalSheet_BodyComponentPhoto_select_cardiovascular");
                dt.Clear();
                dt.Load(dr);

                count = 0;
                textBox1.Text = dt.Rows[count][0].ToString();
                pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                richTextBox1.Text = (string)dt.Rows[count][2];



                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show("لاتوجد صور");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();

                dr = con.DataReader("MedicalSheet_BodyComponentPhoto_select_mouth");
                dt.Clear();
                dt.Load(dr);

                count = 0;
                textBox1.Text = dt.Rows[count][0].ToString();
                pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                richTextBox1.Text = (string)dt.Rows[count][2];



                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show("لاتوجد صور");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();

                dr = con.DataReader("MedicalSheet_BodyComponentPhoto_selecting_urinary");
                dt.Clear();
                dt.Load(dr);

                count = 0;
                textBox1.Text = dt.Rows[count][0].ToString();
                pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                richTextBox1.Text = (string)dt.Rows[count][2];



                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show("لاتوجد صور");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();

                dr = con.DataReader("MedicalSheet_BodyComponentPhoto_select_skeletal");
                dt.Clear();
                dt.Load(dr);

                count = 0;
                textBox1.Text = dt.Rows[count][0].ToString();
                pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                richTextBox1.Text = (string)dt.Rows[count][2];



                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show("لاتوجد صور");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();

                dr = con.DataReader("MedicalSheet_BodyComponentPhoto_select_respiratory");
                dt.Clear();
                dt.Load(dr);

                count = 0;
                textBox1.Text = dt.Rows[count][0].ToString();
                pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                richTextBox1.Text = (string)dt.Rows[count][2];



                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show("لاتوجد صور");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            try
            {
                con.OpenConection();

                dr = con.DataReader("MedicalSheet_BodyComponentPhoto_select_reproductive");
                dt.Clear();
                dt.Load(dr);

                count = 0;
                textBox1.Text = dt.Rows[count][0].ToString();
                pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                richTextBox1.Text = (string)dt.Rows[count][2];



                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show("لاتوجد صور");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();

                dr = con.DataReader("MedicalSheet_BodyComponentPhoto_select_nervous");
                dt.Clear();
                dt.Load(dr);

                count = 0;
                textBox1.Text = dt.Rows[count][0].ToString();
                pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                richTextBox1.Text = (string)dt.Rows[count][2];



                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show("لاتوجد صور");
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();

                dr = con.DataReader("MedicalSheet_BodyComponentPhoto_select_neck_and_head");
                dt.Clear();
                dt.Load(dr);

                count = 0;
                textBox1.Text = dt.Rows[count][0].ToString();
                pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                richTextBox1.Text = (string)dt.Rows[count][2];



                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show("لاتوجد صور");
            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();

                dr = con.DataReader("MedicalSheet_BodyComponentPhoto_select_rhinology");
                dt.Clear();
                dt.Load(dr);

                count = 0;
                textBox1.Text = dt.Rows[count][0].ToString();
                pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                richTextBox1.Text = (string)dt.Rows[count][2];



                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show("لاتوجد صور");
            }
       
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();

                dr = con.DataReader("MedicalSheet_BodyComponentPhoto_select_otology");
                dt.Clear();
                dt.Load(dr);

                count = 0;
                textBox1.Text = dt.Rows[count][0].ToString();
                pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                richTextBox1.Text = (string)dt.Rows[count][2];



                con.CloseConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show("لاتوجد صور");
            }
        
        }
    }
}
