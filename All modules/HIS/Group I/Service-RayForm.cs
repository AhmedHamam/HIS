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
    public partial class Service_Ray : Form
    {
        Connection c = new Connection();

        
        public Service_Ray(OrdersForm p)
        {
           
            InitializeComponent();
        }

        private void Service_Ray_FormClosed(object sender, FormClosedEventArgs e)
        {
            // parent.Show();
            //            this.Close();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Parent.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
           // parent.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked_2(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //parent.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtpatient_code.Text == "" || txtServiceCode.Text == "" || txtArabic_name.Text == "")
            { MessageBox.Show("من فضلك قم بإختيار المريض والخدمة المطلوبة من قائمة الخدمات ", "رسالة"); }
            else
            {

                try
                {
                    c.OpenConection();
                    string[] para_names = new string[] { "@service_code,@account_number,@Quantity,@_date " };
                    string[] para_values = new string[] { txtServiceCode.Text, txtpatient_code.Text, numQuantity.Value.ToString(), dateTimePicker1.Text };
                    SqlDbType[] data_types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.Int, SqlDbType.Int, SqlDbType.Date };
                    c.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("add_ray_service", para_names, para_values, data_types);
                    MessageBox.Show("تم إضافة الخدمة بنجاح");
                    c.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
            }
        }



        private void Service_Ray_Load(object sender, EventArgs e)
        {

            try
            {
                c.OpenConection();
                string query = "select patient_id as 'كود المريض', patient_name as 'الاسم', gender as 'النوع',bed as 'السرير' from Registeration_patientRegisteration,entranceoffice_internalpatient ";
                SqlDataReader dr;
                dr = c.DataReader(query);
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgv_patient_info.DataSource = dt;
                lbox_Ray_cato.Items.Add("lll");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void dgv_patient_info_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int i = dgv_patient_info.CurrentRow.Index;
                txtpatient_code.Text = dgv_patient_info.Rows[i].Cells["كود المريض"].Value.ToString();
                txtArabic_name.Text = dgv_patient_info.Rows[i].Cells["الاسم"].Value.ToString();
                cbGender.Text = dgv_patient_info.Rows[i].Cells["النوع"].Value.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void dgv_ray_service_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int i = dgv_ray_service.CurrentRow.Index;
                txtServiceCode.Text = dgv_ray_service.Rows[i].Cells["كود الخدمة"].Value.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void lbox_Ray_cato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbox_Ray_cato_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lbox_Ray_cato.SelectedIndex == 0)
                {
                    c.OpenConection();
                    string query = "select Service_code as 'كود الخدمة', Service_name as 'اسم الخدمة',Repeat as 'التكرار', price as 'السعر', Notes as 'ملاحظات' from orders_ray_service where lap_code='ray_lap1'";

                    DataTable dt = (DataTable)c.ShowDataInGridView(query);
                    dgv_ray_service.DataSource = dt;
                    c.CloseConnection();
                }
                else if (lbox_Ray_cato.SelectedIndex == 1)
                {
                    c.OpenConection();
                    string query = "select Service_code as 'كود الخدمة', Service_name as 'اسم الخدمة',Repeat as 'التكرار', price as 'السعر', Notes as 'ملاحظات' from orders_ray_service where lap_code='ray_lap2'";

                    DataTable dt = (DataTable)c.ShowDataInGridView(query);
                    dgv_ray_service.DataSource = dt;
                    c.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_current_Click(object sender, EventArgs e)
        {
            if (txtpatient_code.Text == "")
            { MessageBox.Show("من فضلك اختر المريض الذي تود ان تستعلم عن الخدمات الحالية لديه ", "تنبيه"); }
            else
            {
                try
                {
                    c.OpenConection();
                    string[] param_names = new string[] { "@account_number" };
                    string[] param_values = new string[] { txtServiceCode.Text };
                    SqlDbType[] param_types = new SqlDbType[] { SqlDbType.NVarChar };
                    DataTable dt = new DataTable();
                    dgv_current_sevice.DataSource = (DataTable)c.ShowDataInGridViewUsingStoredProc("show_current_service");
                    c.CloseConnection();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtcurrent.Text == "")
                { MessageBox.Show("من فضلك اختر الخدمة المراد إلغاؤها  !", "تنبيه"); }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("هل انت متأكد من إلغاء الخدمة المحددة ؟", "تنبيه", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        //do something
                        c.OpenConection();
                        string[] param_names = new string[] { "@service_code" };
                        string[] param_values = new string[] { txtcurrent.Text };
                        SqlDbType[] param_type = new SqlDbType[] { SqlDbType.NVarChar };
                        c.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_service", param_names, param_values, param_type);
                        string[] param_name = new string[] { "@account_number", "@Service_code", "@_date", "@Quantity" };
                        string[] param_value = new string[] { txtpatient_code.Text, txtServiceCode.Text, dateTimePicker1.Text, numQuantity.Value.ToString() };
                        SqlDbType[] types = new SqlDbType[] { SqlDbType.Int, SqlDbType.NVarChar, SqlDbType.Date, SqlDbType.Int };
                        c.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("add_deleted_service", param_name, param_value, types);
                        c.CloseConnection();
                        MessageBox.Show("تم إلغاءالخدمة بنجاح");
                        txtcurrent.Clear();

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        dialogResult = DialogResult.Cancel;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgv_current_sevice_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int i = dgv_current_sevice.CurrentRow.Index;
                txtcurrent.Text = dgv_current_sevice.Rows[i].Cells["كود الخدمة"].Value.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void Service_Ray_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtArabic_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
        }

        private void txtpatient_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.integer(sender, e, this);
        }

        private void txtServiceCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.integer(sender, e, this);
        }

        private void txtcurrent_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.integer(sender, e, this);

        }

    }
}

