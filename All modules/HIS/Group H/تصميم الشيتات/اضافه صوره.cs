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
    public partial class اضافه_صوره : Form
    {


        OpenFileDialog op = new OpenFileDialog();
        static string listitem;
        Connection con = new Connection();
        public اضافه_صوره()
        {
            InitializeComponent();
        }

        private void اضافه_صوره_Load(object sender, EventArgs e)
        {
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                //op = new OpenFileDialog();
                if (op.ShowDialog() == DialogResult.OK)
                    pictureBox1.Image = Image.FromFile(op.FileName);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // op = new OpenFileDialog();
           
            if (listBox1.SelectedIndex < 0 )
                MessageBox.Show("الرجاء اختيار اسم العضو");

            else if (op.FileName.ToString()=="")
                MessageBox.Show("الرجاء ادخال الصوره");
            else
            {
                listitem = listBox1.SelectedItem.ToString();

                if (listitem == "عضل")
                {
                    try
                    {

                        con.OpenConection();
                        string[] pramname = new string[2];
                        string[] pramvalue = new string[2];
                        SqlDbType[] pramtype = new SqlDbType[2];
                        pramname[0] = "@x";
                        pramname[1] = "@y";

                        pramvalue[0] = op.FileName;
                        pramvalue[1] = richTextBox1.Text;

                        pramtype[0] = SqlDbType.VarChar;
                        pramtype[1] = SqlDbType.VarChar;

                        object x = new object();
                        con.ShowDataInGridViewUsingStoredProc("MedicalSheet_BodyComponentphoto_insert", pramname, pramvalue, pramtype);
                        MessageBox.Show("تم ادخال البيانات بنجاح");

                        con.CloseConnection();




                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                }

                else if (listitem == "وعاء لنفاوى")
                {
                    try
                    {

                        con.OpenConection();
                        string[] pramname = new string[2];
                        string[] pramvalue = new string[2];
                        SqlDbType[] pramtype = new SqlDbType[2];
                        pramname[0] = "@x";
                        pramname[1] = "@y";

                        pramvalue[0] = op.FileName;
                        pramvalue[1] = richTextBox1.Text;

                        pramtype[0] = SqlDbType.VarChar;
                        pramtype[1] = SqlDbType.VarChar;

                        object x = new object();
                        con.ShowDataInGridViewUsingStoredProc("MedicalSheet_BodyComponentphoto_lymphatic_insert", pramname, pramvalue, pramtype);
                        MessageBox.Show("تم ادخال البيانات بنجاح");

                        con.CloseConnection();


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                }



                if (listitem == "العين")
                {
                    try
                    {

                        con.OpenConection();
                        string[] pramname = new string[2];
                        string[] pramvalue = new string[2];
                        SqlDbType[] pramtype = new SqlDbType[2];
                        pramname[0] = "@x";
                        pramname[1] = "@y";

                        pramvalue[0] = op.FileName;
                        pramvalue[1] = richTextBox1.Text;

                        pramtype[0] = SqlDbType.VarChar;
                        pramtype[1] = SqlDbType.VarChar;

                        object x = new object();
                        con.ShowDataInGridViewUsingStoredProc("MedicalSheet_BodyComponentphoto_eye_insert", pramname, pramvalue, pramtype);
                        MessageBox.Show("تم ادخال البيانات بنجاح");

                        con.CloseConnection();


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                }




                if (listitem == "الاذن")
                {
                    try
                    {

                        con.OpenConection();
                        string[] pramname = new string[2];
                        string[] pramvalue = new string[2];
                        SqlDbType[] pramtype = new SqlDbType[2];
                        pramname[0] = "@x";
                        pramname[1] = "@y";

                        pramvalue[0] = op.FileName;
                        pramvalue[1] = richTextBox1.Text;

                        pramtype[0] = SqlDbType.VarChar;
                        pramtype[1] = SqlDbType.VarChar;

                        object x = new object();
                        con.ShowDataInGridViewUsingStoredProc("MedicalSheet_BodyComponentphoto_ear_insert", pramname, pramvalue, pramtype);
                        MessageBox.Show("تم ادخال البيانات بنجاح");

                        con.CloseConnection();


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                }




                if (listitem == "هضمى ")
                {
                    try
                    {

                        con.OpenConection();
                        string[] pramname = new string[2];
                        string[] pramvalue = new string[2];
                        SqlDbType[] pramtype = new SqlDbType[2];
                        pramname[0] = "@x";
                        pramname[1] = "@y";

                        pramvalue[0] = op.FileName;
                        pramvalue[1] = richTextBox1.Text;

                        pramtype[0] = SqlDbType.VarChar;
                        pramtype[1] = SqlDbType.VarChar;

                        object x = new object();
                        con.ShowDataInGridViewUsingStoredProc("MedicalSheet_BodyComponentphoto_digestive_insert", pramname, pramvalue, pramtype);
                        MessageBox.Show("تم ادخال البيانات بنجاح");

                        con.CloseConnection();


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                }



                if (listitem == "وعائى")
                {
                    try
                    {

                        con.OpenConection();
                        string[] pramname = new string[2];
                        string[] pramvalue = new string[2];
                        SqlDbType[] pramtype = new SqlDbType[2];
                        pramname[0] = "@x";
                        pramname[1] = "@y";

                        pramvalue[0] = op.FileName;
                        pramvalue[1] = richTextBox1.Text;

                        pramtype[0] = SqlDbType.VarChar;
                        pramtype[1] = SqlDbType.VarChar;

                        object x = new object();
                        con.ShowDataInGridViewUsingStoredProc("MedicalSheet_BodyComponentphoto_cardiovascular_insert", pramname, pramvalue, pramtype);
                        MessageBox.Show("تم ادخال البيانات بنجاح");

                        con.CloseConnection();


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                }

                if (listitem == "الفم")
                {
                    try
                    {

                        con.OpenConection();
                        string[] pramname = new string[2];
                        string[] pramvalue = new string[2];
                        SqlDbType[] pramtype = new SqlDbType[2];
                        pramname[0] = "@x";
                        pramname[1] = "@y";

                        pramvalue[0] = op.FileName;
                        pramvalue[1] = richTextBox1.Text;

                        pramtype[0] = SqlDbType.VarChar;
                        pramtype[1] = SqlDbType.VarChar;

                        object x = new object();
                        con.ShowDataInGridViewUsingStoredProc("MedicalSheet_BodyComponentphoto_mouth_insert", pramname, pramvalue, pramtype);
                        MessageBox.Show("تم ادخال البيانات بنجاح");

                        con.CloseConnection();


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                }

                if (listitem == "بولى")
                {
                    try
                    {

                        con.OpenConection();
                        string[] pramname = new string[2];
                        string[] pramvalue = new string[2];
                        SqlDbType[] pramtype = new SqlDbType[2];
                        pramname[0] = "@x";
                        pramname[1] = "@y";

                        pramvalue[0] = op.FileName;
                        pramvalue[1] = richTextBox1.Text;

                        pramtype[0] = SqlDbType.VarChar;
                        pramtype[1] = SqlDbType.VarChar;

                        object x = new object();
                        con.ShowDataInGridViewUsingStoredProc("MedicalSheet_BodyComponentphoto_urinary_insert", pramname, pramvalue, pramtype);
                        MessageBox.Show("تم ادخال البيانات بنجاح");

                        con.CloseConnection();


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                }



                if (listitem == "هيكلى")
                {
                    try
                    {

                        con.OpenConection();
                        string[] pramname = new string[2];
                        string[] pramvalue = new string[2];
                        SqlDbType[] pramtype = new SqlDbType[2];
                        pramname[0] = "@x";
                        pramname[1] = "@y";

                        pramvalue[0] = op.FileName;
                        pramvalue[1] = richTextBox1.Text;

                        pramtype[0] = SqlDbType.VarChar;
                        pramtype[1] = SqlDbType.VarChar;

                        object x = new object();
                        con.ShowDataInGridViewUsingStoredProc("MedicalSheet_BodyComponentphoto_skeletal_insert", pramname, pramvalue, pramtype);
                        MessageBox.Show("تم ادخال البيانات بنجاح");

                        con.CloseConnection();


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                }





                if (listitem == "جهاز التنفس")
                {
                    try
                    {

                        con.OpenConection();
                        string[] pramname = new string[2];
                        string[] pramvalue = new string[2];
                        SqlDbType[] pramtype = new SqlDbType[2];
                        pramname[0] = "@x";
                        pramname[1] = "@y";

                        pramvalue[0] = op.FileName;
                        pramvalue[1] = richTextBox1.Text;

                        pramtype[0] = SqlDbType.VarChar;
                        pramtype[1] = SqlDbType.VarChar;

                        object x = new object();
                        con.ShowDataInGridViewUsingStoredProc("MedicalSheet_BodyComponentphoto_respiratory_insert", pramname, pramvalue, pramtype);
                        MessageBox.Show("تم ادخال البيانات بنجاح");

                        con.CloseConnection();


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                }




                if (listitem == "تناسلى")
                {
                    try
                    {

                        con.OpenConection();
                        string[] pramname = new string[2];
                        string[] pramvalue = new string[2];
                        SqlDbType[] pramtype = new SqlDbType[2];
                        pramname[0] = "@x";
                        pramname[1] = "@y";

                        pramvalue[0] = op.FileName;
                        pramvalue[1] = richTextBox1.Text;

                        pramtype[0] = SqlDbType.VarChar;
                        pramtype[1] = SqlDbType.VarChar;

                        object x = new object();
                        con.ShowDataInGridViewUsingStoredProc("MedicalSheet_BodyComponentphoto_reproductive_insert", pramname, pramvalue, pramtype);
                        MessageBox.Show("تم ادخال البيانات بنجاح");

                        con.CloseConnection();


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                }


                if (listitem == "اعصاب")
                {
                    try
                    {

                        con.OpenConection();
                        string[] pramname = new string[2];
                        string[] pramvalue = new string[2];
                        SqlDbType[] pramtype = new SqlDbType[2];
                        pramname[0] = "@x";
                        pramname[1] = "@y";

                        pramvalue[0] = op.FileName;
                        pramvalue[1] = richTextBox1.Text;

                        pramtype[0] = SqlDbType.VarChar;
                        pramtype[1] = SqlDbType.VarChar;

                        object x = new object();
                        con.ShowDataInGridViewUsingStoredProc("MedicalSheet_BodyComponentphoto_nervous_insert", pramname, pramvalue, pramtype);
                        MessageBox.Show("تم ادخال البيانات بنجاح");

                        con.CloseConnection();


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                }



                if (listitem == "الرأس والرقبة")
                {
                    try
                    {

                        con.OpenConection();
                        string[] pramname = new string[2];
                        string[] pramvalue = new string[2];
                        SqlDbType[] pramtype = new SqlDbType[2];
                        pramname[0] = "@x";
                        pramname[1] = "@y";

                        pramvalue[0] = op.FileName;
                        pramvalue[1] = richTextBox1.Text;

                        pramtype[0] = SqlDbType.VarChar;
                        pramtype[1] = SqlDbType.VarChar;

                        object x = new object();
                        con.ShowDataInGridViewUsingStoredProc("MedicalSheet_BodyComponentphoto_neck_and_head_insert", pramname, pramvalue, pramtype);
                        MessageBox.Show("تم ادخال البيانات بنجاح");

                        con.CloseConnection();


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                }
                if (listitem == "Rhinology")
                {
                    try
                    {

                        con.OpenConection();
                        string[] pramname = new string[2];
                        string[] pramvalue = new string[2];
                        SqlDbType[] pramtype = new SqlDbType[2];
                        pramname[0] = "@x";
                        pramname[1] = "@y";

                        pramvalue[0] = op.FileName;
                        pramvalue[1] = richTextBox1.Text;

                        pramtype[0] = SqlDbType.VarChar;
                        pramtype[1] = SqlDbType.VarChar;

                        object x = new object();
                        con.ShowDataInGridViewUsingStoredProc("MedicalSheet_BodyComponentphoto_rhinology_insert", pramname, pramvalue, pramtype);
                        MessageBox.Show("تم ادخال البيانات بنجاح");

                        con.CloseConnection();


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                }



                if (listitem == "otology")
                {
                    try
                    {

                        con.OpenConection();
                        string[] pramname = new string[2];
                        string[] pramvalue = new string[2];
                        SqlDbType[] pramtype = new SqlDbType[2];
                        pramname[0] = "@x";
                        pramname[1] = "@y";

                        pramvalue[0] = op.FileName;
                        pramvalue[1] = richTextBox1.Text;

                        pramtype[0] = SqlDbType.VarChar;
                        pramtype[1] = SqlDbType.VarChar;

                        object x = new object();
                        con.ShowDataInGridViewUsingStoredProc("MedicalSheet_BodyComponentphoto_otology_insert", pramname, pramvalue, pramtype);
                        MessageBox.Show("تم ادخال البيانات بنجاح");

                        con.CloseConnection();


                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }

                }
            }      
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
