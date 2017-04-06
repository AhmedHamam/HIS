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
    public partial class صور_مكونات_جسم_الانسان : Form
    {
        static int id;
        Connection con = new Connection();
       // static int[] arrid;
       //// SqlConnection con;
       // SqlCommand cmd;
        SqlDataReader dr;
       // SqlDataAdapter da;
       //// DataSet ds = new DataSet();
        
        DataTable dt = new DataTable();
        
       // BindingSource bs = new BindingSource();
        int count;
        public صور_مكونات_جسم_الانسان()
        {
            InitializeComponent();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void صور_مكونات_جسم_الانسان_Load(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            
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

           // MedicalSheet_BodyComponentPhoto_select_urinary
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

        private void button16_Click(object sender, EventArgs e)
        {
            count = 0;
                  textBox1.Text = dt.Rows[count][0].ToString();
                  pictureBox1.Image = Image.FromFile((string)dt.Rows[count][1]);
                  richTextBox1.Text = (string)dt.Rows[count][2];
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

        private void اضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            اضافه_صوره m = new اضافه_صوره();
            m.Show();
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            con.OpenConection();

            string[] pramname = new string[1];
            string[] pramvalue = new string[2];
            SqlDbType[] pramtype = new SqlDbType[1];
            pramname[0] = "@x";


            pramvalue[0] = textBox1.Text;
            

            pramtype[0] = SqlDbType.Int;
            

            object x = new object();

            con.ShowDataInGridViewUsingStoredProc("MedicalSheet_BodyComponentPhoto_deleteRecord_byID", pramname, pramvalue, pramtype);
            MessageBox.Show("تم عمليه الحذف بنجاح");
            con.CloseConnection();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //con.Open();

            //cmd = new SqlCommand("select image_component_Id from MedicalSheet_BodyComponentPhoto where img=" + pictureBox1.Image + ";", con);
            //// string i = (cmd.ExecuteScalar().ToString());
            //// MessageBox.Show(id.ToString());
            //con.Close();
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        }

        
        }
    

