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
    public partial class المناظير : Form
    {
        public المناظير()
        {
            InitializeComponent();
        }
        Connection con = new Connection();
        private void بحث_Click(object sender, EventArgs e)
        {
            con.OpenConection();
          SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Endoscope123";
            cmd.Connection = con.con;
            
            try
            {
            cmd.Parameters.AddWithValue("@doctor_name", textBox2.Text);
                var fees = cmd.Parameters.Add("@doctor_fees", SqlDbType.Float);
            fees.Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            var date = cmd.Parameters.Add("@Endscop_date", SqlDbType.Date);
            date.Direction = ParameterDirection.Output;
            label9.Text = fees.Value.ToString();
            label10.Text = date.Value.ToString();
            }
                   catch( SqlException ex)
            {
                ex.ToString();
                MessageBox.Show("حاول ادخال داتا صحيحة");
    }
            con.CloseConnection();
     }
        private void label9_Click(object sender, EventArgs e)
        {

        }
        }
}




