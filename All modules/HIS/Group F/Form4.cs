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
    public partial class Form4 : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();
        BindingSource bs;
        SqlDataReader dr;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            con.OpenConection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            cmd = new SqlCommand("select * from operationreward", con.con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label6.Text = Convert.ToString(dr[0]);
                label7.Text = Convert.ToString(dr[1]);
                label8.Text = Convert.ToString(dr[2]);
                label9.Text = Convert.ToString(dr[3]);
                label11.Text = Convert.ToString(dr[4]);
                
            }
        }
    }
}

/*da = new MySqlDataAdapter("select * from operationreward",con);
           DataSet ds = new DataSet();
           da.Fill(ds);
           label6.Text = Convert.ToString(ds.Tables[0].Rows[0][0]);
           label7.Text = Convert.ToString(ds.Tables[0].Rows[0][1]);
           label8.Text = Convert.ToString(ds.Tables[0].Rows[0][2]);
           label9.Text = Convert.ToString(ds.Tables[0].Rows[0][3]);
           label11.Text = Convert.ToString(ds.Tables[0].Rows[0][4]);
           con.CloseConnection();*/


/*If your query returns a result set then you can pick a single cell from the DataTable and assign it to the label.
SqlConnection con = new SqlConnection("ConnectionString");
        SqlDataAdapter da = new SqlDataAdapter("select * from TableName", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        Label1.Text = Convert.ToString(ds.Tables[0].Rows[0][1]);


If the query returns a single value, then you may use ExecuteScalar() method.


SqlConnection con = new SqlConnection("ConnectionString");
        string query = "select max(name) from TableName where id='someid'";
        SqlCommand com = new SqlCommand(query, con);
        DataSet ds = new DataSet();
        con.OpenConection();
        Label1.Text = Convert.ToString(com.ExecuteScalar());
        con.CloseConnection();
*/