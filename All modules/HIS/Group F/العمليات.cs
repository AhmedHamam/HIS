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
    public partial class العمليات : Form
    {
        public العمليات()
        {
            InitializeComponent();
        }
        Connection con = new Connection();
        private void button1_Click(object sender, EventArgs e)
        {
            double x = Convert.ToDouble(textBox1.Text);
            double y = Convert.ToDouble(label10.Text);
            label3.Text = (y * (x / 100)).ToString() + "%";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.OpenConection();
             SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = " operation12345";
            cmd.Connection = con.con;
           
            try
            {
          cmd.Parameters.AddWithValue("@doctor_name",textBox2.Text);
           var date= cmd.Parameters.Add("@op_date",SqlDbType.Date);
           date.Direction = ParameterDirection.Output;
            var fees = cmd.Parameters.Add("@doctor_fees", SqlDbType.Float);
            fees.Direction = ParameterDirection.Output;
            var op_name = cmd.Parameters.Add("@op_name", SqlDbType.VarChar,50);
            op_name.Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            label5.Text = op_name.Value.ToString();
            label9.Text = date.Value.ToString();
            label10.Text = fees.Value.ToString();
            }
            catch( SqlException ex)
            {
                ex.ToString();
                MessageBox.Show("حاول ادخال داتا صحيحة");
            
    }
            con.CloseConnection();
           
     }
          
        
        }
        
}

            