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
    public partial class تعديل_البطاقة_العلاجية_لمريض : Form
    {
        Connection con = new Connection();
        int f;

        تسجيل_بيانات__مريض m = new تسجيل_بيانات__مريض();
        محرك_البحث_عن_مريض_تعديل_البطاقة_العلاجية x = new محرك_البحث_عن_مريض_تعديل_البطاقة_العلاجية();

        public تعديل_البطاقة_العلاجية_لمريض(محرك_البحث_عن_مريض_تعديل_البطاقة_العلاجية y)
        {
            y = x;

            InitializeComponent();
        }

        public تعديل_البطاقة_العلاجية_لمريض(int d)
        {

             f = d;

      
                
            InitializeComponent();
        }


        private void تعديل_البطاقة_العلاجية_لمريض_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            MessageBox.Show(f.ToString());
            try {
                string[] s = new string[] { "@x" };
                string[] s2 = new string[] { f.ToString() };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("update_medical_card", s, s2, s3);            
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            //Connection con = new Connection("server=localhost,database=hospital,uid=);
            //MySqlDataAdapter da = new MySqlDataAdapter("select *from  Registeration_patientRegisteration where  patient_id=f", con);

            //DataSet c= new DataSet();
            //dataGridView1.DataSource = c.Tables[0];

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void اضافة_Click(object sender, EventArgs e)
        {


        }

       
        private void fill(object sender, DataGridViewCellMouseEventArgs e)
        {
            string a = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            int id = int.Parse(a);
            string b = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //  string c = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string c = this.dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            string g = this.dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            string f = this.dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            string h = this.dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            string k = this.dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            /*  تقرير_بيانات_المريض t = new تقرير_بيانات_المريض(id,b);
              t.Show();*/
            //MessageBox.Show(id + " " +b+" "+c+" "+g+""+f+""+h+""+k);
            m.setvalues(id, b,c,g,f,h,k);
            m.Show();

            this.Close();

        }
    }
}
