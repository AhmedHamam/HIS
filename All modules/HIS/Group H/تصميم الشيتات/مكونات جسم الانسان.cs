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
    public partial class مكونات_جسم_الانسان : Form
    {
        Connection con = new Connection();
        public مكونات_جسم_الانسان()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void مكونات_جسم_الانسان_Load(object sender, EventArgs e)
        {

            dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 10.25f, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.BorderStyle = 0;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.BackgroundColor = Color.White;
            
            con.OpenConection();
            

            try
            {

                con.DataReader("MedicalSheet_BodyComponent_select");
                dataGridView1.DataSource = con.ShowDataInGridView("MedicalSheet_BodyComponent_select");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            con.CloseConnection();
            
               
               
               
           
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void خروجToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
