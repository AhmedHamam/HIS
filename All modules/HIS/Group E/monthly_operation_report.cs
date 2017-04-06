using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace HIS
{
    public partial class monthly_operation_report : Form
    {
        Connection sqlCon = new Connection();
        public monthly_operation_report()
        {
            InitializeComponent();
        }

        private void monthly_operation_report_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlCon.OpenConection();
            SqlDbType[] type = { SqlDbType.VarChar };
            string[] name = { "@x" };
            string[] value = { comboBox1.SelectedItem.ToString() };
            var dt = sqlCon.ShowDataInGridViewUsingStoredProc("select_monthly_op", name, value, type);

            //sqlCon.OpenConection();
            //SqlCommand cmd = new SqlCommand("select_monthly_op", sqlCon.con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("x", comboBox1.SelectedItem.ToString());
            //SqlDataReader dr = cmd.ExecuteReader();
            //DataTable dt = new DataTable();
            //dt.Load(dr);

            reportViewer1.LocalReport.DataSources.Clear();
            var rtds = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rtds);
            reportViewer1.RefreshReport();
            
        }
    }
}


//--------------------- This Report Procedure ----------------------------------------
//create procedure select_monthly_op( @x varchar(4))
//as 
//begin
//select op_skill , 
//count(case when  op_date between '1/1/'+@x and '1/31/'+@x then  op_date end) as jan,
//count(case when  op_date between '2/1/'+@x and '2/28/'+@x then  op_date end) as feb,
//count(case when  op_date between '3/1/'+@x and '3/31/'+@x then  op_date end) as mar,
//count(case when  op_date between '4/1/'+@x and '4/30/'+@x then  op_date end) as apr,
//count(case when  op_date between '5/1/'+@x and '5/31/'+@x then  op_date end) as may,
//count(case when  op_date between '6/1/'+@x and '6/30/'+@x then  op_date end) as jun,
//count(case when  op_date between '7/1/'+@x and '7/31/'+@x then  op_date end) as jul,
//count(case when  op_date between '8/1/'+@x and '8/31/'+@x then  op_date end) as aug,
//count(case when  op_date between '9/1/'+@x and '9/30/'+@x then  op_date end) as sep,
//count(case when  op_date between '10/1/'+@x and '10/31/'+@x then  op_date end) as oct,
//count(case when  op_date between '11/1/'+@x and '11/30/'+@x then  op_date end) as nov,
//count(case when  op_date between '12/1/'+@x and '12/31/'+@x then  op_date end) as decm
//from operations group by op_skill;
//end
//go