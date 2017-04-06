using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HIS
{
    public partial class GroupA_PatientBill_Visit_Bills : Form
    {
        Connection conn;
        SqlDataReader dr;
        string query;

        public GroupA_PatientBill_Visit_Bills(Connection c)
        {
            InitializeComponent();
            conn = c;
            fill_Visit();
            comboBox1.SelectedIndex = 0;
        }

        private void fill_Visit()
        {
            try
            {
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                comboBox2.Items.Clear();
                comboBox2.Text = "";
                conn.OpenConection();
                query = @"SELECT DISTINCT patient_id, patient_name FROM  Registeration_patientRegisteration";

                dr = conn.DataReader(query);
                comboBox2.Items.Add("0");
                comboBox1.Items.Add("الكــــل");
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr[0].ToString());
                    comboBox1.Items.Add(dr[1].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = comboBox1.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                dataGridView1.Rows.Clear();
                return;
            }
            try
            {
                dataGridView1.Rows.Clear();
                var date1 = Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                var date2 = Convert.ToDateTime(dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                if (date1 > date2)
                {
                    MessageBox.Show("حدد التاريخ بطريقة صحيحة");
                    return;
                }

                conn.OpenConection();
                if (comboBox1.SelectedIndex == 0)
                {
                    query = @"SELECT Visit_Bill.ID, Visit_Bill.visit_ID, Registeration_patientRegisteration.patient_name, (tb_Contracting_Entities.CE_AName+' - '+ tb_Entities_Branches.EB_Aname +' - '+ tb_Entities_Category.EC_Aname),
                         (Visit_Bill.total_service + Visit_Bill.total_residence + Visit_Bill.total_medicine), (Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount), 
                         Visit_Bill.value_payment,(Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount - Visit_Bill.value_payment),Visit_Bill.date, employee.name
                         FROM   employee INNER JOIN
                         Users ON employee.emp_id = Users.emp_id INNER JOIN
                         Visit_Bill ON Users.User_Code = Visit_Bill.User_code INNER JOIN
                         Registeration_patientRegisteration INNER JOIN
                         entranceoffice_visit ON Registeration_patientRegisteration.patient_id = entranceoffice_visit.pat_id INNER JOIN
                         tb_Entities_Branches INNER JOIN
                         tb_Contracting_Entities ON tb_Entities_Branches.EB_CE_id = tb_Contracting_Entities.CE_Id INNER JOIN
                         tb_Entities_Category ON tb_Entities_Branches.EB_id = tb_Entities_Category.EC_EB_id ON entranceoffice_visit.EC_id = tb_Entities_Category.EC_id AND entranceoffice_visit.EC_id = tb_Entities_Category.EC_id ON
                         Visit_Bill.visit_ID = entranceoffice_visit.visit_id AND Visit_Bill.EB_id = tb_Entities_Branches.EB_id AND Visit_Bill.EB_id = tb_Entities_Branches.EB_id AND Visit_Bill.CE_Id = tb_Contracting_Entities.CE_Id
                         WHERE Visit_Bill.date BETWEEN '" + date1.ToString("MM/dd/yyyy 00:00:00.000") + "' AND '" + date2.ToString("MM/dd/yyyy 23:59:59.999") + "'";
                }
                else
                {
                    query = @"SELECT Visit_Bill.ID, Visit_Bill.visit_ID, Registeration_patientRegisteration.patient_name, (tb_Contracting_Entities.CE_AName+' - '+ tb_Entities_Branches.EB_Aname +' - '+ tb_Entities_Category.EC_Aname),
                         (Visit_Bill.total_service + Visit_Bill.total_residence + Visit_Bill.total_medicine), (Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount), 
                         Visit_Bill.value_payment,(Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount - Visit_Bill.value_payment),Visit_Bill.date, employee.name
                         FROM   employee INNER JOIN
                         Users ON employee.emp_id = Users.emp_id INNER JOIN
                         Visit_Bill ON Users.User_Code = Visit_Bill.User_code INNER JOIN
                         Registeration_patientRegisteration INNER JOIN
                         entranceoffice_visit ON Registeration_patientRegisteration.patient_id = entranceoffice_visit.pat_id INNER JOIN
                         tb_Entities_Branches INNER JOIN
                         tb_Contracting_Entities ON tb_Entities_Branches.EB_CE_id = tb_Contracting_Entities.CE_Id INNER JOIN
                         tb_Entities_Category ON tb_Entities_Branches.EB_id = tb_Entities_Category.EC_EB_id ON entranceoffice_visit.EC_id = tb_Entities_Category.EC_id AND entranceoffice_visit.EC_id = tb_Entities_Category.EC_id ON
                         Visit_Bill.visit_ID = entranceoffice_visit.visit_id AND Visit_Bill.EB_id = tb_Entities_Branches.EB_id AND Visit_Bill.EB_id = tb_Entities_Branches.EB_id AND Visit_Bill.CE_Id = tb_Contracting_Entities.CE_Id
                         WHERE Registeration_patientRegisteration.patient_id=" + comboBox2.SelectedItem + " AND Visit_Bill.date BETWEEN '" + date1.ToString("MM/dd/yyyy 00:00:00.000") + "' AND '" + date2.ToString("MM/dd/yyyy 23:59:59.999") + "'";
                }

                dr = conn.DataReader(query);
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8], dr[9]);
                }
                dr.Close();
                conn.CloseConnection();
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("لا توجد نتائج");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                dataGridView1.Rows.Clear();
                return;
            }
            try
            {
                dataGridView1.Rows.Clear();
                conn.OpenConection();
                if (comboBox1.SelectedIndex == 0)
                {
                    query = @"SELECT Visit_Bill.ID, Visit_Bill.visit_ID, Registeration_patientRegisteration.patient_name, (tb_Contracting_Entities.CE_AName+' - '+ tb_Entities_Branches.EB_Aname +' - '+ tb_Entities_Category.EC_Aname),
                         (Visit_Bill.total_service + Visit_Bill.total_residence + Visit_Bill.total_medicine), (Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount), 
                         Visit_Bill.value_payment,(Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount - Visit_Bill.value_payment),Visit_Bill.date, employee.name
                         FROM   employee INNER JOIN
                         Users ON employee.emp_id = Users.emp_id INNER JOIN
                         Visit_Bill ON Users.User_Code = Visit_Bill.User_code INNER JOIN
                         Registeration_patientRegisteration INNER JOIN
                         entranceoffice_visit ON Registeration_patientRegisteration.patient_id = entranceoffice_visit.pat_id INNER JOIN
                         tb_Entities_Branches INNER JOIN
                         tb_Contracting_Entities ON tb_Entities_Branches.EB_CE_id = tb_Contracting_Entities.CE_Id INNER JOIN
                         tb_Entities_Category ON tb_Entities_Branches.EB_id = tb_Entities_Category.EC_EB_id ON entranceoffice_visit.EC_id = tb_Entities_Category.EC_id AND entranceoffice_visit.EC_id = tb_Entities_Category.EC_id ON
                         Visit_Bill.visit_ID = entranceoffice_visit.visit_id AND Visit_Bill.EB_id = tb_Entities_Branches.EB_id AND Visit_Bill.EB_id = tb_Entities_Branches.EB_id AND Visit_Bill.CE_Id = tb_Contracting_Entities.CE_Id";
                }
                else
                {
                    query = @"SELECT Visit_Bill.ID, Visit_Bill.visit_ID, Registeration_patientRegisteration.patient_name, (tb_Contracting_Entities.CE_AName+' - '+ tb_Entities_Branches.EB_Aname +' - '+ tb_Entities_Category.EC_Aname),
                         (Visit_Bill.total_service + Visit_Bill.total_residence + Visit_Bill.total_medicine), (Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount), 
                         Visit_Bill.value_payment,(Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount - Visit_Bill.value_payment),Visit_Bill.date, employee.name
                         FROM   employee INNER JOIN
                         Users ON employee.emp_id = Users.emp_id INNER JOIN
                         Visit_Bill ON Users.User_Code = Visit_Bill.User_code INNER JOIN
                         Registeration_patientRegisteration INNER JOIN
                         entranceoffice_visit ON Registeration_patientRegisteration.patient_id = entranceoffice_visit.pat_id INNER JOIN
                         tb_Entities_Branches INNER JOIN
                         tb_Contracting_Entities ON tb_Entities_Branches.EB_CE_id = tb_Contracting_Entities.CE_Id INNER JOIN
                         tb_Entities_Category ON tb_Entities_Branches.EB_id = tb_Entities_Category.EC_EB_id ON entranceoffice_visit.EC_id = tb_Entities_Category.EC_id AND entranceoffice_visit.EC_id = tb_Entities_Category.EC_id ON
                         Visit_Bill.visit_ID = entranceoffice_visit.visit_id AND Visit_Bill.EB_id = tb_Entities_Branches.EB_id AND Visit_Bill.EB_id = tb_Entities_Branches.EB_id AND Visit_Bill.CE_Id = tb_Contracting_Entities.CE_Id
                         WHERE Registeration_patientRegisteration.patient_id=" + comboBox2.SelectedItem + "";
                }

                dr = conn.DataReader(query);
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7], dr[8],dr[9]);
                }
                dr.Close();
                conn.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             if (dataGridView1.Rows.Count == 0)
            {
                return;
            }
            conn.PATIENT_BILL_VID = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.Close();
        }

        private void GroupA_PatientBill_Visit_Bills_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

    }
}
