using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace HIS
{
    public partial class OrdersAddedForm : Form
    {
       
        public OrdersAddedForm()
        {
           // parent = p;
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void OrdersAddedForm_Load(object sender, EventArgs e)
        {
                
        }

        private void OrdersAddedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //parent.Show();
            this.Close();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           // parent.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //parent.Show();
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txt_patient_code.Clear();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txt_patient_code.Text == "")
            { MessageBox.Show("من فضلك ادخل كود المريض", "خطأ");
            txt_patient_code.Focus();
            }
            else
            {
                try
                {
                    Connection conn = new Connection();
                    string query;
                    DataTable dt1 = new DataTable();
                    DataTable dt2 = new DataTable();
                    conn.OpenConection();

                    query = @"SELECT id, account_number, Service_code, [_date], Quantity FROM dbo.orders_patient_has_service where account_number='" + txt_patient_code.Text + "'";
                    dt1.Clear();
                    dt1 = (DataTable)conn.ShowDataInGridView(query);

                    query = @"SELECT id, MealID, mealType, [_date], station, account_number FROM dbo.orders_patientHasMeal where account_number='" + txt_patient_code.Text + "'";
                    dt2.Clear();
                    dt2 = (DataTable)conn.ShowDataInGridView(query);

                    conn.CloseConnection();
                    reportViewer1.LocalReport.DataSources.Clear();
                    var rtds1 = new ReportDataSource("DataSet1", dt1);
                    reportViewer1.LocalReport.DataSources.Add(rtds1);
                    var rtds2 = new ReportDataSource("DataSet2", dt2);
                    reportViewer1.LocalReport.DataSources.Add(rtds2);
                    reportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



        }

        private void txtPName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                btnSearch.Enabled = false;
                int VisibleTime = 1000;  //in milliseconds
                ToolTip tt = new ToolTip();
                tt.Show("كود المرافق " + " يجب ان يكون رقم ", txt_patient_code, 0, 0, VisibleTime);
                //   MessageBox.Show("كود المريض يجب ان يكون ارقام فقط , رجاء لا تكتب حروف ");
                e.Handled = true;
            }
            else
            {
                btnSearch.Enabled = true;

            }
        }
    }
}
