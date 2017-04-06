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
    public partial class عرض_المرضى_للغسل_الكلوى : Form
    {
        Connection con = new Connection();

        استقبال_HIS y;
        public عرض_المرضى_للغسل_الكلوى(استقبال_HIS x)
        {
            InitializeComponent( );
             this.y = x;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            y.setValue(row);
            this.Close();
        }

        private void عرض_المرضى_للغسل_الكلوى_Load(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = con.ShowDataInGridView("Registeration_patientRegisteration_select3");


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            con.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
