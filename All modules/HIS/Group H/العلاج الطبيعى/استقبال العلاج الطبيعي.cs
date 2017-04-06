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
    public partial class استقبال_العلاج_الطبيعي : Form
    {
        Connection con = new Connection();
        int patientCode;
        String DoctorCode;
        public استقبال_العلاج_الطبيعي()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            عرض_المرضى op = new عرض_المرضى(this);
            op.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (استقبال_العلاج_الطبيعي.ContainsArabicLetters(textBox3.Text))
                {
                    String d = monthCalendar1.TodayDate.Date.ToString();
                     con.OpenConection();
                    string[] pramname = new string[4];
                    string[] pramvalue = new string[4];
                    SqlDbType[] pramtype = new SqlDbType[4];
                    pramname[0] = "@patient_case";
                    pramname[1] = "@Entering_Date";
                    pramname[2] = "@physiotherapy_Employee_code";
                    pramname[3] = "@patient_id";
                    pramvalue[0] = textBox3.Text;
                    pramvalue[1] = monthCalendar1.TodayDate.ToString();
                    pramvalue[2] = DoctorCode;
                    pramvalue[3] = patientCode.ToString() ;
                    pramtype[0] = SqlDbType.VarChar;
                    pramtype[1] = SqlDbType.VarChar;
                    pramtype[2] = SqlDbType.VarChar;
                    pramtype[3] = SqlDbType.Int;
                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("physiotherapy_physiotherapy_Reception_insert", pramname, pramvalue, pramtype);
                    //object x = new object();
                    //x = con.ShowDataInGridView("physiotherapy_physiotherapy_Rooms_select");
                    //dataGridView1.DataSource = (DataTable)x; 
                    MessageBox.Show("تم اضافة البيانات بنجاح ");
                }
                else
                {
                    MessageBox.Show("من فضلك ادخل حالة المريض باللغة العربية");
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            عرض_موظفى_العلاج_الطبيعي op = new عرض_موظفى_العلاج_الطبيعي(this);
            op.Show();
        }

        public void SetPatient(String value1,String value2)
        {
            this.patientCode = int.Parse(value1);
            textBox1.Text = value2;
        }
        public void setDoctor(String value1, String value2)
            {
                this.DoctorCode = value1;
                textBox4.Text = value2;
    
            }

        private void استقبال_العلاج_الطبيعي_Load(object sender, EventArgs e)
        {

            try
            {
                object x = new object();
                x = con.ShowDataInGridView("physiotherapy_physiotherapy_hasplan_select");
                dataGridView1.DataSource = (DataTable)x;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }
        }

        internal static bool ContainsArabicLetters(string text)
        {
            foreach (char character in text.ToCharArray())
            {
                if (character >= 0x600 && character <= 0x6ff)
                    return true;

                if (character >= 0x750 && character <= 0x77f)
                    return true;

                if (character >= 0xfb50 && character <= 0xfc3f)
                    return true;

                if (character >= 0xfe70 && character <= 0xfefc)
                    return true;
            }

            return false;
        }
    }
}
