using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace HIS
{
    public partial class employment_documents : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        public employment_documents()
        {
            InitializeComponent();
            fill_employee();
        }
        private void fill_employee()
        {
            try
            {
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                comboBox2.Items.Clear();
                comboBox2.Text = "";
                con.OpenConection();
                string query = @"SELECT   applicant_id, applicant_name FROM   applicant_data";

                SqlDataReader dr = con.DataReader(query);
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr[0].ToString());
                    comboBox1.Items.Add(dr[1].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }
        string path_birthdocument;
        string path_graduatedocument;
        string path_conscriptiondocument;
        string path_experincedocument;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog imageopenfile = new OpenFileDialog();
            imageopenfile.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif|PNGs|*.png";
            imageopenfile.FilterIndex = 2;

            if (imageopenfile.ShowDialog() == DialogResult.OK)
            {
                //Image image1 = Bitmap.FromFile(imageopenfile.FileName);
                path_birthdocument = imageopenfile.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog imageopenfile = new OpenFileDialog();
            imageopenfile.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif|PNGs|*.png";
            imageopenfile.FilterIndex = 2;
            if (imageopenfile.ShowDialog() == DialogResult.OK)
            {
                //Image image2 = Bitmap.FromFile(imageopenfile.FileName);
                path_graduatedocument = imageopenfile.FileName;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog imageopenfile = new OpenFileDialog();
            imageopenfile.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif|PNGs|*.png";
            imageopenfile.FilterIndex = 2;
            if (imageopenfile.ShowDialog() == DialogResult.OK)
            {
                // Image image3 = Bitmap.FromFile(imageopenfile.FileName);
                path_conscriptiondocument = imageopenfile.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog imageopenfile = new OpenFileDialog();
            imageopenfile.Filter = "All Files|*.*|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif|PNGs|*.png";
            imageopenfile.FilterIndex = 2;
            if (imageopenfile.ShowDialog() == DialogResult.OK)
            {
                // Image image4 = Bitmap.FromFile(imageopenfile.FileName);
                path_experincedocument = imageopenfile.FileName;

            }
        }

        private void employment_documents_Load(object sender, EventArgs e)
        {

            con.OpenConection();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                return;
            }
            //MemoryStream ms=new MemoryStream();
            cmd = new SqlCommand("document_select", con.con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@birth_document", path_birthdocument);
            cmd.Parameters.AddWithValue("@graduate_document", path_graduatedocument);
            cmd.Parameters.AddWithValue("@conscription_document", path_conscriptiondocument);
            cmd.Parameters.AddWithValue("@experince_document", path_experincedocument);
            cmd.Parameters.AddWithValue("@applicant_id", comboBox2.SelectedItem);

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("لقد تم ادخال البيانات بنجاح");
            }

            catch (Exception ee)
            {
                MessageBox.Show("لقد حدث خطأ فى ادخال البيانات");

            }
            con.CloseConnection();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = comboBox1.SelectedIndex;
        }

    }
}

