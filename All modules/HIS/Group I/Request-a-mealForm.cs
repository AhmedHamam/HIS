using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HIS
{
    public partial class Request_a_mealForm : Form
    {
        Connection c = new Connection();
      

        public Request_a_mealForm(OrdersForm p)
        {
           
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbStation.Text == "الافطار")
                txtMealID.Text = "1";
            else if (cbStation.Text == "الغداء")
                txtMealID.Text = "2";
            else if (cbStation.Text == "العشاء")
                txtMealID.Text = "3";
        }

        private void Request_a_mealForm_Load(object sender, EventArgs e)
        {
            rbPatient.Focus();
            try
            {
                c.OpenConection();
                SqlDataReader dr = c.DataReader("select account_number from entranceoffice_internalpatient  ");
                while (dr.Read())
                {
                   cb_account_number.Items.Add(dr["account_number"].ToString());
                }
                c.CloseConnection();
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
            
        


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dgv_patient.Hide();
            dgv_partner.Show();
            cb_partner_number.Enabled = true;
            cb_partner_number.Show();
            cb_account_number.Enabled = false;
            try
            {
                c.OpenConection();
                SqlDataReader dr = c.DataReader("select SSN from entranceoffice_partner ");
                while (dr.Read())
                {
                    cb_account_number.Items.Add(dr["SSN"].ToString());
                }
                c.CloseConnection();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void Request_a_mealForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //  parent.Show();
            // this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //parent.Show();
            this.Close();
        }

        private void rbPatient_CheckedChanged(object sender, EventArgs e)
        {
            dgv_partner.Hide();
            dgv_patient.Show();
            cb_partner_number.Enabled = false;
            cb_account_number.Enabled = true;


        }
        //Add meal button 
        private void btnMealExchange_Click(object sender, EventArgs e)
        {
            //check if radio button-partner- checked 
            if (rbPatient.Checked)
            {
               
                //check empty fields 
                if (txtMealID.Text == "" || cb_account_number.Text == "")
                { MessageBox.Show("من فضلك ادخل جميع البيانات بطريقة صحيحة بعض الحقول فارغة ! "); }
                else
                {
                    try
                    {
                        //open connection then define paramters names ,values and types finnaly execue
                        c.OpenConection();
                        string[] param_names = new string[] { "@MealID", "@MealType", "@Station", "@_date", "@account_number" };
                        string[] param_values = new string[] { txtMealID.Text, cbMealType.Text, cbStation.Text, dateExchange.Text, cb_account_number.Text };
                        SqlDbType[] param_types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.DateTime, SqlDbType.Int };
                        c.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("add_a_meal", param_names, param_values, param_types);
                     
                        //display success messege 
                        MessageBox.Show("تم إضافة وجبة بنجاح", "رسالة");
                      
                        //close connection 
                        c.CloseConnection();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { c.CloseConnection(); }

                }
            }

            else if (rbFollower.Checked)
            {
                //check empty fields 
                if (txtMealID.Text == "" || cb_partner_number.Text == "")
                { MessageBox.Show("من فضلك ادخل جميع البيانات بطريقة صحيحة بعض الحقول فارغة ! "); }
                else
                {
                    try
                    {

                        c.OpenConection();
                        string[] param_names = new string[] { "@MealID", "@MealType", "@Station", "@_date", "@partner_id" };
                        string[] param_values = new string[] { txtMealID.Text, cbMealType.Text, cbStation.Text, dateExchange.Text, cb_partner_number.Text };
                        SqlDbType[] param_types = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.DateTime, SqlDbType.BigInt };
                        c.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("add_partner_meal", param_names, param_values, param_types);
                        MessageBox.Show("تم إضافة وجبة بنجاح", "رسالة");
                        c.CloseConnection();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { c.CloseConnection(); }

                }
            }

        }

        // btnSearch_click  try to display meal's details in dataGridView 
        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (rbPatient.Checked)
            {
                if (cb_account_number.Text == "")
                { MessageBox.Show(" من فضلك ادخل رقم المريض "); }
                else
                {
                    try
                    {

                        c.OpenConection();
                        string[] param_names = new string[] { "@account_number" };
                        string[] param_values = new string[] { cb_account_number.Text };
                        SqlDbType[] param_types = new SqlDbType[] { SqlDbType.Int };
                        DataTable dt = new DataTable();
                        dgv_patient.DataSource = (DataTable)c.ShowDataInGridViewUsingStoredProc("showw_current_meal");
                        c.CloseConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally { c.CloseConnection(); }
                }
            }
            else
            {
                if (rbFollower.Checked)
                {

                    if (cb_partner_number.Text == "")
                    { MessageBox.Show(" من فضلك ادخل رقم المرافق "); }
                    else
                    {
                        try
                        {
                            c.OpenConection();
                            string[] param_names = new string[] { "@account_number" };
                            string[] param_values = new string[] { cb_account_number.Text };
                            SqlDbType[] param_types = new SqlDbType[] { SqlDbType.Int };
                            DataTable dt = new DataTable();
                            dgv_partner.DataSource = (DataTable)c.ShowDataInGridViewUsingStoredProc("show_current_partner_meal");
                            c.CloseConnection();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally { c.CloseConnection(); }

                    }
                }

            }
        }

        private void dtaGpatient_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int i = dgv_patient.CurrentRow.Index;
                txtmealCancelCode.Text = dgv_patient.Rows[i].Cells["كود الوجبة"].Value.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void dtaGfollower_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int i = dgv_partner.CurrentRow.Index;
                txtmealCancelCode.Text = dgv_partner.Rows[i].Cells["كود الوجبة"].Value.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbPatient.Checked == true)
            {
                try
                {
                    if (txtmealCancelCode.Text == "")
                    { MessageBox.Show("من فضلك اختر الخدمة المراد إلغاؤها  !", "تنبيه"); }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("هل انت متأكد من إلغاء الخدمة المحددة ؟", "تنبيه", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            c.OpenConection();
                            string[] param_names = new string[] { "@MealID" };
                            string[] param_values = new string[] { txtmealCancelCode.Text };
                            SqlDbType[] param_type = new SqlDbType[] { SqlDbType.NVarChar };
                            c.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_patient_meal", param_names, param_values, param_type);
                            c.CloseConnection();

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
            else if (rbFollower.Checked == true)
            {
                try
                {
                    if (txtmealCancelCode.Text == "")
                    { MessageBox.Show("من فضلك اختر الخدمة المراد إلغاؤها  !", "تنبيه"); }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("هل انت متأكد من إلغاء الخدمة المحددة ؟", "تنبيه", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //do something
                            c.OpenConection();
                            string[] param_names = new string[] { "@MealID" };
                            string[] param_values = new string[] { txtmealCancelCode.Text };
                            SqlDbType[] param_type = new SqlDbType[] { SqlDbType.NVarChar };
                            c.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_partner_meal", param_names, param_values, param_type);
                            c.CloseConnection();
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
        }

        private void cbMealType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbMealType.SelectedIndex == 0)
                txtMealID.Text = "1";
            else if (cbMealType.SelectedIndex == 1)
                txtMealID.Text = "2";
            else if (cbMealType.SelectedIndex == 2)
                txtMealID.Text = "3";
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void txtPNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            //{
            //    btnMealExchange.Enabled = false;
            //    btnSearch.Enabled = false;
            //    // MessageBox.Show("كود المريض يجب ان يكون ارقام فقط ,رجاء لا تكتب حروف ");
            //    int VisibleTime = 1000;  //in milliseconds
            //    ToolTip tt = new ToolTip();

            //    tt.Show("كود المريض" + " يجب ان يكون رقم ", cb_account_number, 0, 0, VisibleTime);

            //    e.Handled = true;

            //}
            //else
            //{
            //    btnMealExchange.Enabled = true;
            //    btnSearch.Enabled = true;
            //}

        }

        private void txtFollowerNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            //{
            //    btnMealExchange.Enabled = false;
            //    btnSearch.Enabled = false;
            //    int VisibleTime = 1000;  //in milliseconds
            //    ToolTip tt = new ToolTip();
            //    tt.Show("كود المرافق " + " يجب ان يكون رقم ", cb_account_number, 0, 0, VisibleTime);
            //    //   MessageBox.Show("كود المرافق يجب ان يكون ارقام فقط , رجاء لا تكتب حروف ");
            //    e.Handled = true;
            //}
            //else
            //{
            //    btnMealExchange.Enabled = true;
            //    btnSearch.Enabled = true;
            //}
        }

        private void cb_account_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.integer(sender, e, this);

        }

        private void cb_partner_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.integer(sender, e, this);

        }

        private void txtmealCancelCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.integer(sender, e, this);

        }

        
     


    }
}
    
