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
    public partial class عرض_أطباء_الطوارئ : Form
    {
        public static string Code1 { get; set; }
        public static string day { get; set; }
        public static string per { get; set; }
        public static string name { get; set; }
        Connection con = new Connection();

        //MySqlConnection con;
        //MySqlCommand cmd1;
        //MySqlDataReader dr;
        
        public عرض_أطباء_الطوارئ()
        {
            InitializeComponent();
        }

        private void حToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void عرض_أطباء_الطوارئ_Load(object sender, EventArgs e)
        {
            //con = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital1");

            con.OpenConection();

            try
            {
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("display_emergency_doctor");

                //string s = "select doc_code as 'كود الطبيب',arabic_day as 'اليوم بالعربي',English_day as 'اليوم بالانجليزيه',period as 'الفتره',doc_name as 'اسم الطبيب' from emergency_emergency_doctors;";
                //cmd1 = new MySqlCommand(s, con);
                //dr = cmd1.ExecuteReader();
                //DataTable d = new DataTable();
                //d.Load(dr);
                //dataGridView1.DataSource = d;
                //dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.CloseConnection();
        }

        private void حToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Code1 =dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                day = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                per = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                name = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                حجز_حالات_الحوادث_بالطوارىء ff = new حجز_حالات_الحوادث_بالطوارىء(Code1, day, per,name);
                ff.Focus();
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "");
            }
        }

       
    }
}
