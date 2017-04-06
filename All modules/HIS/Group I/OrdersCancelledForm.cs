using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace HIS
{
    public partial class OrdersCancelledForm : Form
    {
         

        
        public OrdersCancelledForm(OrdersForm p)
        {
             
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void OrdersCancelledForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetShow.orders_deleted_service' table. You can move, or remove it, as needed.
          // TODO: This line of code loads data into the 'DataSetShow.orders_deleted_service' table. You can move, or remove it, as needed.
           
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            //Parent.Show();
            //this.Close();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Parent.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPNumber.Text == "")
            { MessageBox.Show("من فضلك ادخل كود المريض", "خطأ");
            txtPNumber.Focus();
            }
            else
            {
                try
                {
                    Connection conn = new Connection();
                    string query;
                    DataTable dt = new DataTable();
                    conn.OpenConection();

                    query = @"SELECT id, MealID, mealType, [_date], station, account_number FROM dbo.orders_patientHasMeal where account_number='" + txtPNumber.Text + "'";
                    dt.Clear();
                    dt = (DataTable)conn.ShowDataInGridView(query);

                    conn.CloseConnection();
                    reportViewer1.LocalReport.DataSources.Clear();
                    var rtds = new ReportDataSource("DataSet1", dt);
                    reportViewer1.LocalReport.DataSources.Add(rtds);
                    reportViewer1.RefreshReport();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void txtPNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                btnSearch.Enabled = false;
                int VisibleTime = 1000;  //in milliseconds
                ToolTip tt = new ToolTip();
                tt.Show("كود المرافق " + " يجب ان يكون رقم ", txtPNumber, 0, 0, VisibleTime);
                //   MessageBox.Show("كود المريض يجب ان يكون ارقام فقط , رجاء لا تكتب حروف ");
                e.Handled = true;
            }
            else
            {
                btnSearch.Enabled = true;
                
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtPNumber.Text = "";
        }
    }
}