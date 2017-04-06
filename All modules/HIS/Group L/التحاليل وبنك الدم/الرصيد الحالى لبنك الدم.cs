using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; using System.Configuration;
//using PagedList;

namespace HIS
{
    public partial class الرصيد_الحالى_لبنك_الدم : Form
    {
        //SqlConnection con = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public الرصيد_الحالى_لبنك_الدم()
        {
            InitializeComponent();
        }

        private void الرصيد_الحالى_لبنك_الدم_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);

            
            try
            {
                connection.Open();
                //cmd = new SqlCommand("select * from bloodpackage", con);
                cmd = new SqlCommand("bloodBank_bloodpackage_select5", connection);
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
            ////this.reportViewer1.RefreshReport();

            //using (currentPackageEntities nw = new currentPackageEntities())
            //{
            //    IPagedList<bloodPackage> List = nw.bloodPackages.ToPagedList(1,40);
            //    bloodPackageBindingSource.DataSource = List.ToList();
            //}
        }

        Bitmap b;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //reportViewer1.Visible = true;
            //btnPrint.Visible = false;

            //int height = dataGridView1.Height;
            //dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            //b = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            //dataGridView1.DrawToBitmap(b, new Rectangle(0, 0, dataGridView1.Width * 2, dataGridView1.Height * 2));
            //dataGridView1.Height = height;
            //printPreviewDialog1.ShowDialog();

            bloodPackagePrint nw = new bloodPackagePrint();
            nw.Show();
        }

        //private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    e.Graphics.DrawImage(b, 0, 0);
        //}
    }
}
