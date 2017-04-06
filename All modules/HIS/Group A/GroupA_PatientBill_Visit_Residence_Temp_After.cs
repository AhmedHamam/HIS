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
    public partial class GroupA_PatientBill_Visit_Residence_Temp_After : UserControl
    {
        int User_ID;
        Connection conn;
        SqlDataReader dr;
        string query;

        string VISIT_ID;

        public GroupA_PatientBill_Visit_Residence_Temp_After(int uid)
        {
            InitializeComponent();
            conn = new Connection();
            User_ID = uid;
        }

        private void fill_data()
        {
			if (VISIT_ID == "" || VISIT_ID == null)
            {
                return;
            }
            try
            {
                dataGridView2.Rows.Clear();
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
                dataGridView2.Rows.Clear();

                query = @"SELECT Visit_Residence_Temp.ID, Visit_Residence_Temp.number_of_room, tb_Accommodation_Degrees.AD_Aname, Visit_Residence_Temp.price_before_discount,Visit_Residence_Temp.start_date, 
                        Visit_Residence_Temp.end_date,Visit_Residence_Temp.number_of_days,Visit_Residence_Temp.type,employee.name
                        FROM   Users INNER JOIN
                        employee ON Users.emp_id = employee.emp_id INNER JOIN
                        Visit_Residence_Temp ON Users.User_Code = Visit_Residence_Temp.User_code INNER JOIN
                        tb_Accommodation_Degrees INNER JOIN
                        rooms ON tb_Accommodation_Degrees.AD_id = rooms.Service_level ON Visit_Residence_Temp.number_of_room = rooms.Room_code 
                        WHERE Visit_Residence_Temp.visit_ID=" + VISIT_ID + "";

                dr = conn.DataReader(query);
                string type = "";
                while (dr.Read())
                {
                    if (dr[7].ToString() == "0")
                    {
                        type = "مريض";
                    }
                    if (dr[7].ToString() == "1")
                    {
                        type = "مرافق على كرسى";
                    }
                    if (dr[7].ToString() == "2")
                    {
                        type = "مرافق على سرير";
                    }
                    dataGridView2.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], type, dr[8],"حذف");
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

        private int NumOfDay(string d1, string d2)
        {
            DateTime start = DateTime.Parse(d1);
            DateTime end = DateTime.Parse(d2);
            if (start >= end)
            {
                return 1;
            }
            int count = 0;
            if (start.Hour < 12)
            {
                count++;
                start = new DateTime(start.Year, start.Month, start.Day, 12, 0, 0);
            }
            else if (start.Hour >= 12)
            {
                start = new DateTime(start.Year, start.Month, start.Day, 12, 0, 0);
            }
            if (end.Hour <= 12)
            {
                end = new DateTime(end.Year, end.Month, end.Day, 12, 0, 0);
            }
            else if (end.Hour > 12)
            {
                count++;
                end = new DateTime(end.Year, end.Month, end.Day, 12, 0, 0);
            }
            count += (int)(end - start).TotalDays;
            return count;
        }

        private void calculate()
        {
            try
            {
                int num2 = dataGridView2.Rows.Count;
                double total2 = 0.0;
                for (int i = 0; i < num2; i++)
                {
                    total2 += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value.ToString()) * Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value.ToString());
                }
                label2.Text = total2.ToString();
                label8.Text = (discount_percentage * total2 / 100).ToString();
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
                query = @"SELECT (patient_residence_amount/total_residence*100) FROM  Visit_Bill WHERE visit_ID=" + VISIT_ID + "";
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

        private void dataGridView_MouseEnter(object sender, EventArgs e)
        {
            DataGridView dv = (DataGridView)sender;
            dv.Focus();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                var dialogResult = MessageBox.Show("هل تريد حذف الاقامة المحددة من حساب المريض ؟", string.Empty, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        conn.OpenConection();
                        query = "DELETE FROM Visit_Residence_Temp WHERE ID=" + dataGridView2.Rows[e.RowIndex].Cells[0].Value + "";
                        conn.ExecuteQueries(query);
                        dataGridView2.Rows.RemoveAt(e.RowIndex);
                        calculate();

                        query = "UPDATE Visit_Bill SET total_residence=" + label2.Text + ", patient_residence_amount=" + label8.Text + " WHERE visit_ID=" + VISIT_ID + "";
                        conn.ExecuteQueries(query);
                        conn.CloseConnection();
                        MessageBox.Show("تم حذف الاقامة المحددة من حساب المريض");                  
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
            else if (e.ColumnIndex == 10)
            {
                var dialogResult = MessageBox.Show("هل تريد اغلاق فترة الاقامة المحددة ؟", string.Empty, MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        conn.OpenConection();
                        string date = DateTime.Now.ToString();
                        dataGridView2.Rows[e.RowIndex].Cells[5].Value = date;
                        int numofday = NumOfDay(dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString(), dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString());
                        dataGridView2.Rows[e.RowIndex].Cells[6].Value = numofday;
                        query = "UPDATE Visit_Residence_Temp SET  number_of_days =" + numofday + " , end_date = GETDATE() WHERE ID=" + dataGridView2.Rows[e.RowIndex].Cells[0].Value + "";
                        conn.ExecuteQueries(query);
                        calculate();
                        query = "UPDATE Visit_Bill SET total_residence=" + label2.Text + ", patient_residence_amount=" + label8.Text + " WHERE visit_ID=" + VISIT_ID + "";
                        conn.ExecuteQueries(query);
                        conn.CloseConnection();
                        MessageBox.Show("تم اغلاق فترة الاقامة المحددة");
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
