using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace HIS
{
    public partial class GroupA_PatientBill_bill_report : Form
    {
        DataTable dt1;
        DataTable dt2;
        DataTable dt3;
        DataTable dt4;
        public GroupA_PatientBill_bill_report(DataTable d1, DataTable d2, DataTable d3, DataTable d4)
        {
            InitializeComponent();
            dt1 = d1;
            dt2 = d2;
            dt3 = d3;
            dt4 = d4;
        }

        private void GroupA_PatientBill_bill_report_Load(object sender, System.EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            var rtds1 = new ReportDataSource("DataSet1", dt1);
            reportViewer1.LocalReport.DataSources.Add(rtds1);

            var rtds2 = new ReportDataSource("DataSet2", dt2);
            reportViewer1.LocalReport.DataSources.Add(rtds2);

            var rtds3 = new ReportDataSource("DataSet3", dt3);
            reportViewer1.LocalReport.DataSources.Add(rtds3);

            var rtds4 = new ReportDataSource("DataSet4", dt4);
            reportViewer1.LocalReport.DataSources.Add(rtds4);

            reportViewer1.RefreshReport();
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
        }


    }
}
