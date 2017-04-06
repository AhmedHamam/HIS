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
    public partial class المستخدمين1 : Form
    {
        Connection con = new Connection();
        اضافة_شيت  y;
        public المستخدمين1()
        {
            InitializeComponent();
        }
        public المستخدمين1(اضافة_شيت x)
        {
            InitializeComponent();
            y = x;
        }
        
        private void المستخدمين_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 10.25f, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.BorderStyle = 0;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.BackgroundColor = Color.White;
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = con.ShowDataInGridView("MedicalSheet_Users_select");
                con.CloseConnection();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }
     

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            y.Setvalue(row);
            this.Close();
       

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
