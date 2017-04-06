using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; using System.Configuration;

namespace HIS
{
    public partial class المنصرف_من_بنك_الدم : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public المنصرف_من_بنك_الدم()
        {
            InitializeComponent();
        }

        private void المنصرف_من_بنك_الدم_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);

            
            try
            {
                connection.Open();
                //cmd = new SqlCommand("select * from whichProcess where process_state='yes'", con);
                cmd = new SqlCommand("bloodBank_whichProcess_select ", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();

            //using (outPackageEntities nw = new outPackageEntities())
            //{
            //    whichProcessBindingSource.DataSource = nw.whichProcesses.ToList();
 
            //}
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            //DGVPrinter printer = new DGVPrinter();
            //printer.Title = "outgoing from blood bank";
            //printer.SubTitle = DateTime.Now.Date.ToString();
            //printer.PageNumbers = true;
            //printer.PageNumberInHeader = false;
            //printer.PorportionalColumns = true;
            //printer.HeaderCellAlignment = StringAlignment.Near;
            //printer.FooterSpacing = 15;
            //printer.PrintDataGridView(dataGridView1);
            //printer.ColumnStyles.Values.Any();
        }

            
    }
}
