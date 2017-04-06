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
    public partial class بححححث : Form
    {


        public static string Code1 { get; set; }
        public static string name { get; set; }
        Connection con = new Connection();
        int id;
        int count = 0;
        int count2 = 0;
        int code1;
        int dd;

        public بححححث()
        {
            InitializeComponent();
        }

        public بححححث(int dd)
        {
            InitializeComponent();
            this.dd=dd;
        }

        private void بححححث_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.OpenConection();

            DataTable dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient1");
            


            con.CloseConnection();
            //if (textBox1.Text != "" && textBox3.Text == "")
            //{
            //    try
            //    {
            //        con.OpenConection();
            //        string[] s = new string[] { "@x" };
            //        string[] s2 = new string[] { textBox1.Text };
            //        SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
            //        dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient1", s, s2, s3);


            //        string[] f = new string[] { "@x" };
            //        string[] f2 = new string[] { textBox1.Text };
            //        SqlDbType[] f3 = new SqlDbType[] { SqlDbType.Int };
            //        dataGridView3.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient1", s, s2, s3);


            //    }

            //    catch (Exception ex) { MessageBox.Show(ex.Message); }
            //    finally { con.CloseConnection(); }
            //}
            //else if (textBox3.Text != "" && textBox1.Text == "")
            //{
            //    try
            //    {
            //        con.OpenConection();
            //        string[] s = new string[] { "@x" };
            //        string[] s2 = new string[] { textBox3.Text };
            //        SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar };
            //        dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient1", s, s2, s3);



            //        string[] f = new string[] { "@x" };
            //        string[] f2 = new string[] { textBox3.Text };
            //        SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar };
            //        dataGridView3.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient1", f, f2, f3);


            //    }

            //    catch (Exception ex) { MessageBox.Show(ex.Message); }
            //    finally { con.CloseConnection(); }
            //}

            //else if (textBox1.Text != "" && textBox3.Text != "")
            //{
            //    try
            //    {

            //        con.OpenConection();
            //        string[] s = new string[] { "@x", "@y" };
            //        string[] s2 = new string[] { textBox3.Text, textBox1.Text };
            //        SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.Int };
            //        dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient1", s, s2, s3);



            //        string[] f = new string[] { "@x", "@y" };
            //        string[] f2 = new string[] { textBox3.Text, textBox1.Text };
            //        SqlDbType[] f3 = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.Int };
            //        dataGridView3.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient1", f, f2, f3);



            //    }

            //    catch (Exception ex) { MessageBox.Show(ex.Message); }
            //    finally { con.CloseConnection(); }
            //}
            //else
            //{
            try
            {

                con.OpenConection();

                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("search_patient1");








            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            // ds.Tables.Clear();
            dataGridView1.Refresh();
            dataGridView1.Rows.Clear();
            count = 0;
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string a = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            id = int.Parse(a);

            if (dd == 10)
            {


              
                حجز_مريض_داخلى d = new حجز_مريض_داخلى(id);

                d.Show();
                Hide();
            }
            else if(dd == 1){


                اجازه_مريض d = new اجازه_مريض(id);

                d.Show();
                Hide();
           }
            else if (dd == 2)
            {


                التصفيه_الماليه_لخروج_مريض d = new التصفيه_الماليه_لخروج_مريض(id);

                d.Show();
                Hide();
            }
            else if (dd == 3)
            {


                الغاء_حجز_مريض_داخلى d = new الغاء_حجز_مريض_داخلى(id);

                d.Show();
                Hide();
            }
            else if (dd == 4)
            {


                الغاء_خروج_المريض_من_فتره d = new الغاء_خروج_المريض_من_فتره(id);

                d.Show();
                Hide();
            }
            else if (dd == 5)
            {


                الغاء_نقل_مريض_لسرير_اخر d = new الغاء_نقل_مريض_لسرير_اخر(id);

                d.Show();
                Hide();
            }
            else if (dd == 6)
            {


                تسجيل_الوفيات d = new تسجيل_الوفيات(id);

                d.Show();
                Hide();
            }
            else if (dd == 7)
            {


                تعديل_بيانات_خروج_مريض d = new تعديل_بيانات_خروج_مريض(id);

                d.Show();
                Hide();
            }
            else if (dd == 8)
            {


                تعديل_بيانات_الحجز_لمريض d = new تعديل_بيانات_الحجز_لمريض(id);

                d.Show();
                Hide();
            }
            else if (dd == 9)
            {


                حجز_مريض_فى_وحده_ثانويه d = new  حجز_مريض_فى_وحده_ثانويه(id);

                d.Show();
                Hide();
            }
            else if (dd == 11)
            {


                حجز_وتعديل_المرافقين d = new حجز_وتعديل_المرافقين(id);

                d.Show();
                Hide();
            }
            else if (dd == 12)
            {


                خروج_مرافق d = new خروج_مرافق(id);

                d.Show();
                Hide();
            }
            else if (dd == 13)
            {


                خروج_مريض d = new خروج_مريض(id);

                d.Show();
                Hide();
            }
            else if (dd == 14)
            {


                خروج_المريض_من_وحده_ثانويه d = new خروج_المريض_من_وحده_ثانويه(id);

                d.Show();
                Hide();
            }
            else if (dd == 15)
            {


                رجوع_مريض_من_اجازه d = new رجوع_مريض_من_اجازه(id);

                d.Show();
                Hide();
            }
            else if (dd == 16)
            {


                نقل_مرافق_من_سرير_لاخر d = new نقل_مرافق_من_سرير_لاخر(id);

                d.Show();
                Hide();
            }
            else if (dd == 17)
            {


                نقل_المريض_من_سرير_لاخر d = new نقل_المريض_من_سرير_لاخر(id);

                d.Show();
                Hide();
            }
        }
    }
}