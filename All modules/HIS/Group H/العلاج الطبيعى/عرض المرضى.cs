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
    public partial class عرض_المرضى : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        استقبال_العلاج_الطبيعي op;
        تقرير_الخطة_العلاجية_لمريض x;
        bool report;
        public عرض_المرضى()
        {
            InitializeComponent();
        }
        public عرض_المرضى(  تقرير_الخطة_العلاجية_لمريض op)
        {
            InitializeComponent();
            this.x = op;
            this.report = true;
        }
        public عرض_المرضى( استقبال_العلاج_الطبيعي x)
        {
            InitializeComponent();
            this.op = x;
            this.report = false;
        }
        private void عرض_المرضى_Load(object sender, EventArgs e)
        {
            try {
                object x = new object();
                x = con.ShowDataInGridView("physiotherapy_displayPatient_select");
                dataGridView1.DataSource = (DataTable)x;
            }
            catch(Exception ex)
            {MessageBox.Show(ex.Message);}
            }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        { String value1 = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String value2 = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            if (report == true)
            {
                x.SetPatient(value1, value2);
                this.Close();
            }
            else
            {
                op.SetPatient(value1, value2);
                this.Close();
            }
        }

     

        }
    }
