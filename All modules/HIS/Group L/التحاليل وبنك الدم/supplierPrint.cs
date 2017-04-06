using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace HIS
{
    public partial class supplierPrint : Form
    {
        DataTable dt;
        public supplierPrint()
        {
            InitializeComponent();
        }
        public supplierPrint(DataTable d)
        {
            InitializeComponent();
            dt = d;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.DataSources.Clear();
            var rtds=new ReportDataSource("DataSet1",dt);
            reportViewer1.LocalReport.DataSources.Add(rtds);
            this.reportViewer1.RefreshReport();
        }
    }
}
