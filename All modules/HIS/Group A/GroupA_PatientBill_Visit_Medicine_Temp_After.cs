﻿using System;
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
    public partial class GroupA_PatientBill_Visit_Medicine_Temp_After : UserControl
    {
        int User_ID;
        Connection conn;
        SqlDataReader dr;
        string query;
        string VISIT_ID;


        public GroupA_PatientBill_Visit_Medicine_Temp_After(int uid)
        {
            InitializeComponent();
            conn = new Connection();
            User_ID = uid;
        }


        private void calculate()
        {
            try
            {
                int num3 = dataGridView3.Rows.Count;
                double total3 = 0.0;

                for (int i = 0; i < num3; i++)
                {
                    total3 += Convert.ToDouble(dataGridView3.Rows[i].Cells[2].Value.ToString()) * Convert.ToDouble(dataGridView3.Rows[i].Cells[3].Value.ToString());
                }
                label9.Text = total3.ToString();
                label2.Text = (discount_percentage * total3 / 100).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int discount_percentage = 0;

        private void get_percentage()
        {
            try
            {
                query = @"SELECT (patient_medicine_amount/total_medicine*100) FROM  Visit_Bill WHERE visit_ID=" + VISIT_ID + "";
                dr = conn.DataReader(query);
                if (dr.Read())
                {
                    discount_percentage = Convert.ToInt32(dr[0].ToString());
                }
                dr.Close();
            }
            catch
            {
            }
        }

        private void fill_data()
        {
            if (VISIT_ID == "" || VISIT_ID == null)
            {
                return;
            }
            try
            {
                dataGridView3.Rows.Clear();
                conn.OpenConection();
                query = @"SELECT  Registeration_patientRegisteration.patient_name, entranceoffice_visit.type_of_visit, entranceoffice_visit.entrance_date
                        FROM entranceoffice_visit INNER JOIN
                        Registeration_patientRegisteration ON entranceoffice_visit.pat_id = Registeration_patientRegisteration.patient_id
                        WHERE entranceoffice_visit.visit_id=" + VISIT_ID + "";

                dr = conn.DataReader(query);
                if (dr.Read())
                {
                    label6.Text = VISIT_ID;
                    label7.Text = dr[0].ToString();
                    label12.Text = dr[1].ToString();
                    label14.Text = dr[2].ToString();

                }
                dr.Close();
                dataGridView3.Rows.Clear();

                query = @"SELECT  Visit_Medicine_Temp.ID, med_medicine.medicine_name, Visit_Medicine_Temp.item_quantity, Visit_Medicine_Temp.price_before_discount,Visit_Medicine_Temp.date, employee.name
                        FROM  Visit_Medicine_Temp,med_medicine,employee,Users WHERE 
                        Visit_Medicine_Temp.visit_ID=" + VISIT_ID + @" AND
                        Visit_Medicine_Temp.item_ID = med_medicine.med_id AND
                        Users.emp_id = employee.emp_id AND
                        Visit_Medicine_Temp.User_code=Users.User_Code";


                dr = conn.DataReader(query);
                while (dr.Read())
                {
                    dataGridView3.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], "حذف");
                }
                dr.Close();
                get_percentage();
                calculate();
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

        private void dataGridView_MouseEnter(object sender, EventArgs e)
        {
            DataGridView dv = (DataGridView)sender;
            dv.Focus();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                var dialogResult = MessageBox.Show("  هل تريد حذف الدواء المحدد من حساب المريض ؟", string.Empty, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        conn.OpenConection();
                        query = "DELETE FROM Visit_Medicine_Temp WHERE ID=" + dataGridView3.Rows[e.RowIndex].Cells[0].Value + "";
                        conn.ExecuteQueries(query);
                        dataGridView3.Rows.RemoveAt(e.RowIndex);
                        calculate();

                        query = "UPDATE Visit_Bill SET total_medicine=" + label9.Text + ", patient_medicine_amount=" + label2.Text + " WHERE visit_ID=" + VISIT_ID + "";
                        conn.ExecuteQueries(query);
                        conn.CloseConnection();
                        MessageBox.Show("تم حذف الدواء المحدد من حساب المريض");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                else
                {
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var forms = Application.OpenForms.Cast<Form>().ToArray();
            foreach (Form tempForm in forms)
            {
                if (tempForm.Name == "GroupA_PatientBill_Visit_Bills")
                {
                    tempForm.Hide();
                }
            }
            var fo = new GroupA_PatientBill_Visit_Bills(conn);
            fo.FormClosed += new FormClosedEventHandler(fo_FormClosed);
            fo.Show();
        }

        void fo_FormClosed(object sender, FormClosedEventArgs e)
        {
            VISIT_ID = conn.PATIENT_BILL_VID;
            label6.Text = VISIT_ID;
            fill_data();
        }

        private void INT_TextChanged(object sender, EventArgs e)
        {
            TextBox TXB = (TextBox)sender;
            string T = "";
            foreach (char c in TXB.Text)
            {
                if ((int)c >= 48 && (int)c <= 57)
                {
                    T += c;
                }
            }
            TXB.Text = T;
            TXB.SelectionStart = TXB.TextLength;
            TXB.SelectionLength = 0;
        }
    }
}
