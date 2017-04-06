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
using HIS;

namespace HIS
{
    public partial class Hospital_obligations : Form
    {
        Connection con = new Connection();        
        public Hospital_obligations()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
            this.reportViewer4.RefreshReport();
            this.reportViewer5.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string t = (comboBox2.SelectedIndex +1).ToString();

           string first = t + "-1-"+comboBox1.SelectedItem;
           String []month={" "};
           if (new[] { 1, 3, 5, 7, 8, 10, 12 }.Contains(comboBox2.SelectedIndex + 1)) 
               month[0] = "-31-";
           else if (new[] { 4,6,9,11 }.Contains(comboBox2.SelectedIndex + 1)) 
               month[0] = "-30-";
           else 
            month[0]= "-28-";
           String second =  t + month[0] + comboBox1.SelectedItem;

           string [] name  = {"from","to"};
           string[] value = { first,second};

           // try{

                con.OpenConection();
                //salary
                SqlDbType[] t1 = { SqlDbType.NVarChar, SqlDbType.NVarChar };
                object dt = con.ShowDataInGridViewUsingStoredProc("Salaries_total", name, value, t1);
                DataTable dtt = (DataTable)dt;
                double sum1 = 0;
                if (dtt.Rows.Count == 0 || dtt.Rows[0][0].ToString() =="")
                {
                    sum1 = 0;
                }
                else
                {
                    sum1 = Convert.ToDouble(dtt.Rows[0][0].ToString());
                }
                 TextBox5.Text = sum1.ToString();
                //doctors' fees
                object dt2 = con.ShowDataInGridViewUsingStoredProc("DoctorFees_total", name, value, t1);
                DataTable dtt2 = (DataTable)dt2;
                double sum2 = 0;
                if (dtt2.Rows.Count == 0 || dtt2.Rows[0][0].ToString() == "")
                    sum2 = 0;
                else
                    sum2 = Convert.ToDouble(dtt2.Rows[0][0].ToString());
                TextBox4.Text = sum2.ToString();
               
                //Banks
                object dt3 = con.ShowDataInGridViewUsingStoredProc("Banks_total", name, value, t1);
                DataTable dtt3 = (DataTable)dt3;
                double sum3 = 0;
                if (dtt3.Rows.Count == 0 || dtt3.Rows[0][0].ToString() == "")
                    sum3 = 0;
                else
                    sum3 = Convert.ToDouble(dtt3.Rows[0][0].ToString());
                TextBox3.Text = sum3.ToString();
                
                //clients
                object dt4 = con.ShowDataInGridViewUsingStoredProc("Clients_total", name, value, t1);
                DataTable dtt4 = (DataTable)dt4;
                double sum4 = 0;
                if (dtt4.Rows.Count == 0 || dtt4.Rows[0][0].ToString() == "")
                   sum4 = 0; 
                else
                    sum4 = Convert.ToDouble(dtt4.Rows[0][0].ToString());
                TextBox2.Text = sum4.ToString();

                //suppliers
                object dt5 = con.ShowDataInGridViewUsingStoredProc("Suppliers_total", name, value, t1);
                DataTable dtt5 = (DataTable)dt5;
                double sum5 = 0;
                if (dtt5.Rows.Count == 0 || dtt5.Rows[0][0].ToString() == "")
                    sum5 = 0; 
                else
                   sum5 = Convert.ToDouble(dtt5.Rows[0][0].ToString());
                TextBox1.Text = sum5.ToString();

                generate_reports1(first, second);
                generate_reports2(first, second);
                generate_reports3(first, second);
                generate_reports4(first, second);
                generate_reports5(first, second);
            //}

            //catch (Exception ex) { MessageBox.Show(ex.Message); }
            //finally
            //{
                con.CloseConnection();
            //}

        }



        //supplier's report
        SqlDbType[] t0 = { SqlDbType.NVarChar, SqlDbType.NVarChar };
        public void generate_reports1(String f, String s)
        {
            //SqlDbType[] t0 = { SqlDbType.NVarChar };
            string[] name = { "from", "to" };
            string[] value = { f, s };
            if (comboBox1.SelectedValue == null) return;
            try{
                con.OpenConection();
                reportViewer1.LocalReport.DataSources.Clear();
                var rtds = new ReportDataSource("DataSet1", con.ShowDataInGridViewUsingStoredProc("Suppliers_ob_report", name, value, t0));
                reportViewer1.LocalReport.DataSources.Add(rtds);
                reportViewer1.RefreshReport();


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally {
                con.CloseConnection(); 
            }
        }

        //clients' report
        public void generate_reports2(String f, String s)
        {
            //SqlDbType[] t0 = { SqlDbType.NVarChar };
            string[] name = { "from", "to" };
            string[] value = { f, s };
            if (comboBox1.SelectedValue == null) return;
            try
            {
                con.OpenConection();
                reportViewer2.LocalReport.DataSources.Clear();
                var rtds = new ReportDataSource("DataSet2", con.ShowDataInGridViewUsingStoredProc("Clients_ob_report", name, value, t0));
                reportViewer2.LocalReport.DataSources.Add(rtds);
                reportViewer2.RefreshReport();


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }
        }

        //Banks' obligations
        public void generate_reports3(String f, String s)
        {
            //SqlDbType[] t0 = { SqlDbType.NVarChar };
            string[] name = { "from", "to" };
            string[] value = { f, s };
            if (comboBox1.SelectedValue == null) return;
            try
            {
                con.OpenConection();
                reportViewer3.LocalReport.DataSources.Clear();
                var rtds = new ReportDataSource("DataSet3", con.ShowDataInGridViewUsingStoredProc("Banks_ob_report", name, value, t0));
                reportViewer3.LocalReport.DataSources.Add(rtds);
                reportViewer3.RefreshReport();


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }
        }

        //Doctors' fees report
        public void generate_reports4(String f, String s)
        {
            //SqlDbType[] t0 = { SqlDbType.NVarChar };
            string[] name = { "from", "to" };
            string[] value = { f, s };
            if (comboBox1.SelectedValue == null) return;
            try
            {
                con.OpenConection();
                reportViewer4.LocalReport.DataSources.Clear();
                var rtds = new ReportDataSource("DataSet4", con.ShowDataInGridViewUsingStoredProc("Doctors_fees_report", name, value, t0));
                reportViewer4.LocalReport.DataSources.Add(rtds);
                reportViewer4.RefreshReport();


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }
        }
        
        //salaries report
        public void generate_reports5(String f, String s)
        {
            //SqlDbType[] t0 = { SqlDbType.NVarChar };
            string[] name = { "from", "to" };
            string[] value = { f, s };
            if (comboBox1.SelectedValue == null) return;
            try
            {
                con.OpenConection();
                reportViewer5.LocalReport.DataSources.Clear();
                var rtds = new ReportDataSource("DataSet5", con.ShowDataInGridViewUsingStoredProc("Salaries_report",name, value, t0));
                reportViewer5.LocalReport.DataSources.Add(rtds);
                reportViewer5.RefreshReport();


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }
        }


    }
}
