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
    public partial class تقاريرالايراد : Form
    {

        public تقاريرالايراد()
        {
            InitializeComponent();
        }
        Connection con = new Connection();
        private void button1_Click(object sender, EventArgs e)
        {



            con.OpenConection();
           
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "hospital1";
            cmd.Connection = con.con;
            //  cmd.Parameters.AddWithValue("DepName", textBox6.Text);
          
            
           
            // int y=Convert.ToInt32(textBox7.Text);
            int y1 = Convert.ToInt32(textBox5.Text);
            int y2 = Convert.ToInt32(textBox4.Text);
            int y3 = Convert.ToInt32(textBox3.Text);
            // string saveStaff = "INSERT into student (stud_id,stud_name) " + " VALUES ('" + SI + "', '" + SN + "');";
            //  Insert_quary2 = "INSERT into inreport22(DepName,DepIncomeTotal,moneyPercentage,rewardTotalAfterDiscount,item ,income_date)" + " VALUES('" + textBox6.Text + "', " + y1 + ", " + y2 + ", " + y3 + ", '" + textBox2.Text + "', '" + textBox1.Text + "');";
            //  string Insert_quary2 = "INSERT into income_report(DepName,DepIncomeTotal,moneyPercentage,rewardTotalAfterDiscount,item ,income_date)" + " VALUES('" + textBox6.Text + "', " + y1 + ", " + y2 + ", " + y3 + ", '" + textBox2.Text + "', '" + textBox1.Text + "');";
            
            
            cmd.Parameters.AddWithValue("@DepName",textBox6.Text);
            cmd.Parameters.AddWithValue("@DepIncomeTotal", y1);
           // cmd.Parameters.Add("@DepIncomeTotal", SqlDbType.Int).Value = y1;
           cmd.Parameters.AddWithValue("@moneyPercentage", y2);
           // cmd.Parameters.Add("@moneyPercentage", SqlDbType.Int).Value = y2;
            cmd.Parameters.AddWithValue("@rewardTotalAfterDiscount", y3);
            //cmd.Parameters.Add("@rewardTotalAfterDiscount", SqlDbType.Int).Value = y3;
            cmd.Parameters.AddWithValue("@item", textBox2.Text);
            //cmd.Parameters.Add("@item", SqlDbType.VarChar,45).Value = textBox2.Text;
            cmd.Parameters.AddWithValue("@income_date", textBox1.Text);
            //cmd.Parameters.Add("@income_date", SqlDbType.Date).Value = textBox1.Text;
           // SqlCommand cmd2 = new SqlCommand("hospital1", con);
            
          // 
            try
             {cmd.ExecuteNonQuery();
                
                     MessageBox.Show("data inserted");
                
             }
             catch (SqlException ex)
             {
                 MessageBox.Show(ex.ToString());


             }
           // dataReader.Close();
            con.CloseConnection();

        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
       

          


