using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HIS
{
    public partial class TRAINING_FRM_REPORT_TRAINEE : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlCommandBuilder ba;
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        TRAINING_FRM_ADVERTISING own = null;
        Connection connect;
        TRAINING_FRM_ADD_COURSE ff;
        public TRAINING_FRM_REPORT_TRAINEE()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            connect.OpenConection();
            cmd = new SqlCommand();

            cmd.CommandText = "select * from trainee,trainer,employee  where trainee_code=emp_id and trainer_code=emp_id and course_name like '" + textBox3.Text + "%'";
            try
            {

                dr = cmd.ExecuteReader();
                dt.Load(dr);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            connect.CloseConnection();
        }
    }
}
