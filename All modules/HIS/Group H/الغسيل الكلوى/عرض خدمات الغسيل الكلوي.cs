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
    public partial class عرض_خدمات_الغسيل_الكلوى : Form
    {
        
        Connection con = new Connection();

        تنفيذ_خطه_HIS y;
        public عرض_خدمات_الغسيل_الكلوى(تنفيذ_خطه_HIS x)
        {
            InitializeComponent();
            this.y = x;
        }

        private void عرض_خدمات_الغسيل_الكلوى_Load(object sender, EventArgs e)
        {
        
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = con.ShowDataInGridView("Hemodialysis_services_select");


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            con.CloseConnection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            y.setValue3(row);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
