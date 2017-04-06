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
    public partial class Maintenance_report : Form
    {
        public Maintenance_report()
        {
            InitializeComponent();
        }

        

        private void Maintenance_report_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            Connection sqlCon = new Connection();
            try
            {
                sqlCon.OpenConection();
                object xx=sqlCon.ShowDataInGridViewUsingStoredProc("asset_main_select");
                comboBox1.DataSource = xx;
                comboBox1.ValueMember = "code";
                comboBox1.DisplayMember = "arabic_name";
                label2.DataBindings.Add("text", xx, "code");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { sqlCon.CloseConnection(); }
            
        }


        public void generate_reports()
        {
            Connection sqlCon = new Connection();
            if (comboBox1.SelectedValue == null) return;
            try
            {
                sqlCon.OpenConection();
                String[] a = { "@code" };
                String[] b = { comboBox1.SelectedValue.ToString() };
                SqlDbType[] c = { SqlDbType.Int };
                object dt = sqlCon.ShowDataInGridViewUsingStoredProc("asset_main_conditional_report", a, b, c);
                reportViewer1.LocalReport.DataSources.Clear();
                var rtds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rtds);
                reportViewer1.RefreshReport();


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { sqlCon.CloseConnection(); }
        }

        public void generate_reports1()
        {
            Connection sqlCon = new Connection();
            try
            {
                sqlCon.OpenConection();
                object dt = sqlCon.ShowDataInGridViewUsingStoredProc("asset_main_report");
                reportViewer1.LocalReport.DataSources.Clear();
                var rtds = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(rtds);
                reportViewer1.RefreshReport();


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { sqlCon.CloseConnection(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("بعض الخانات مفقودة !");
                return;
            }
            generate_reports();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            generate_reports1();
        }

        
    }
}
