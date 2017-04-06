using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS
{
    public partial class عرض_المرضى_لعمل_خطة_علاجية : Form
    {
        Connection con = new Connection();
        public عرض_المرضى_لعمل_خطة_علاجية()
        {
            InitializeComponent();
        }
        تنفيذ_خطه_HIS y;

        public عرض_المرضى_لعمل_خطة_علاجية(تنفيذ_خطه_HIS x)
        {
            InitializeComponent();
            this.y = x;
        }
        private void عرض_المرضى_لعمل_خطة_علاجية_Load(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = con.ShowDataInGridView("Hemodialysis_patient_select");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            y.setValue(row);
            this.Close();
        }
    }
}
