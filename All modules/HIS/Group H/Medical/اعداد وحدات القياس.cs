using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HIS.Group_H.Medical
{
    public partial class اعداد_وحدات_القياس : Form
    {
        Connection con = new Connection();
        صناعة_شيت a = new صناعة_شيت();
       
        public اعداد_وحدات_القياس(صناعة_شيت a1)
        {
            InitializeComponent();
            a = a1;
        }
        public اعداد_وحدات_القياس()
        {
            InitializeComponent();
        }

        private void اعداد_وحدات_القياس_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Calibri", 10.25f, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Calibri", 11, FontStyle.Regular);

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;

            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.BorderStyle = 0;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.BackgroundColor = Color.White;
            con.OpenConection();

            con.DataReader("MedicalSheet_MeasurementUnits_select_names");
            dataGridView1.DataSource = con.ShowDataInGridView("MedicalSheet_MeasurementUnits_select_names");
            con.CloseConnection();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            a.SetValue3(row);
            this.Close();
        }
    }
}
