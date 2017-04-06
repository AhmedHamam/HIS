using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HIS
{
    public partial class GroupA_PatientBill_Visit_Patients : Form
    {
        Connection conn;
        SqlDataReader dr;
        string query;

        public GroupA_PatientBill_Visit_Patients(Connection c)
        {
            InitializeComponent();
            conn = c;
            fill_patient();
            comboBox1.SelectedIndex = 0;
            button2_Click(null,null);
        }

        private void fill_patient()
        {
            try
            {
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                comboBox2.Items.Clear();
                comboBox2.Text = "";
                conn.OpenConection();
                query = @"SELECT  Registeration_patientRegisteration.patient_name, Registeration_patientRegisteration.patient_id
                         FROM   entranceoffice_visit INNER JOIN Registeration_patientRegisteration ON 
                         entranceoffice_visit.pat_id = Registeration_patientRegisteration.patient_id
                         WHERE entranceoffice_visit.state_of_visit=0";

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
                    query = @"SELECT entranceoffice_visit.visit_id, Registeration_patientRegisteration.patient_name, entranceoffice_visit.type_of_visit, entranceoffice_visit.entrance_date
                            FROM  entranceoffice_visit INNER JOIN
                            Registeration_patientRegisteration ON entranceoffice_visit.pat_id = Registeration_patientRegisteration.patient_id
                            WHERE entranceoffice_visit.state_of_visit=0 AND  entranceoffice_visit.entrance_date BETWEEN '" + date1.ToString("MM/dd/yyyy 00:00:00.000") + "' AND '" + date2.ToString("MM/dd/yyyy 23:59:59.999") + "'";
                }
                else
                {
                    query = @"SELECT entranceoffice_visit.visit_id, Registeration_patientRegisteration.patient_name, entranceoffice_visit.type_of_visit, entranceoffice_visit.entrance_date
                            FROM  entranceoffice_visit INNER JOIN
                            Registeration_patientRegisteration ON entranceoffice_visit.pat_id = Registeration_patientRegisteration.patient_id
                            WHERE entranceoffice_visit.state_of_visit=0 AND Registeration_patientRegisteration.patient_id=" + comboBox2.SelectedItem + " AND entranceoffice_visit.entrance_date BETWEEN '" + date1.ToString("MM/dd/yyyy 00:00:00.000") + "' AND '" + date2.ToString("MM/dd/yyyy 23:59:59.999") + "'";
                }

                dr = conn.DataReader(query);
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
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
                    query = @"SELECT entranceoffice_visit.visit_id, Registeration_patientRegisteration.patient_name, entranceoffice_visit.type_of_visit, entranceoffice_visit.entrance_date
                            FROM  entranceoffice_visit INNER JOIN
                            Registeration_patientRegisteration ON entranceoffice_visit.pat_id = Registeration_patientRegisteration.patient_id
                            WHERE entranceoffice_visit.state_of_visit=0";
                }
                else
                {
                    query = @"SELECT entranceoffice_visit.visit_id, Registeration_patientRegisteration.patient_name, entranceoffice_visit.type_of_visit, entranceoffice_visit.entrance_date
                            FROM  entranceoffice_visit INNER JOIN
                            Registeration_patientRegisteration ON entranceoffice_visit.pat_id = Registeration_patientRegisteration.patient_id
                            WHERE entranceoffice_visit.state_of_visit=0 AND Registeration_patientRegisteration.patient_id=" + comboBox2.SelectedItem + "";
                }

                dr = conn.DataReader(query);
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
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
            conn.PATIENT_BILL_VID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.Close();
        }

        private void GroupA_PatientBill_Visit_Bills_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}
