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
    public partial class GroupA_PatientBill_bill_discount : UserControl
    {
        int User_ID;
        Connection conn;
        SqlDataReader dr;
        string query;
        string VISIT_ID = "";

        public GroupA_PatientBill_bill_discount(int uid)
        {
            InitializeComponent();
            conn = new Connection();
            User_ID = uid;

        }

        private void clear()
        {
            label6.Text = "";
            label7.Text = "";
            label12.Text = "";
            label14.Text = "";
            label18.Text = "";
            label1.Text = "";
            textBox2.Text = "";
            textBox1.Text = "";
        }

        private void fill_data()
        {
            if (VISIT_ID == "" || VISIT_ID == null)
            {
                return;
            }
            try
            {
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

                query = @"SELECT  value_payment ,((patient_service_amount + patient_residence_amount + patient_medicine_amount)- value_payment-discount_amount) as value_requested
                        FROM Visit_Bill WHERE visit_id=" + VISIT_ID + "";
                dr = conn.DataReader(query);
                if (dr.Read())
                {
                    label18.Text = dr[0].ToString();
                    label1.Text = dr[1].ToString();
                }
                dr.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (VISIT_ID == "" || VISIT_ID == null)
            {
                MessageBox.Show("حدد الفاتورة من زر بحث");
                return;
            }
            int value = 0;
            if (textBox2.Text == "")
            {
                MessageBox.Show("ادخل المبلغ");
                return;
            }
            value = Convert.ToInt32(textBox2.Text);
            if (value <= 0)
            {
                MessageBox.Show("ادخل المبلغ بطريقة صحيحة");
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("ادخل سبب الخصم");
                return;
            }
            try
            {
                conn.OpenConection();
                query = "SELECT  *  FROM   Visit_Discount WHERE visit_id=" + VISIT_ID + "";
                dr = conn.DataReader(query);
                if (dr.Read())
                {
                    conn.CloseConnection();
                    clear();
                    MessageBox.Show("لقد قمت بعمل خصم على نفس الفاتورة من قبل");
                    return;
                }
                dr.Close();

                query = @"INSERT INTO Visit_Discount (visit_ID, reason, User_code) VALUES (@visit_ID, @reason, @User_code)";
                string[] Parameters = new string[] { "@visit_ID", "@reason", "@User_code" };
                string[] Values = new string[] { VISIT_ID, textBox1.Text,User_ID.ToString() };
                conn.ExecuteStoredProcQueries(query, Parameters, Values);

                query = "UPDATE Visit_Bill SET discount_amount =@discount_amount WHERE visit_ID=@visit_ID";
                Parameters = new string[] { "@discount_amount", "@visit_ID" };
                Values = new string[] { value.ToString(), VISIT_ID };
                conn.ExecuteStoredProcQueries(query, Parameters, Values);
                conn.CloseConnection();
                clear();
                MessageBox.Show("تم عمل الخصم بنجاح ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DOUBLE_TextChanged(object sender, EventArgs e)
        {
            TextBox TXB = (TextBox)sender;
            int count = 0;
            string T = "";
            foreach (char c in TXB.Text)
            {
                if ((int)c >= 48 && (int)c <= 57 || (int)c == 46)
                {
                    if ((int)c == 46)
                    {
                        if (count == 0)
                        {
                            if (T == "")
                            {
                                T = "0.";
                                count++;
                            }
                            else
                            {
                                T += c;
                                count++;
                            }
                        }

                    }
                    else
                    {
                        T += c;
                    }
                }
            }
            TXB.Text = T;
            TXB.SelectionStart = TXB.TextLength;
            TXB.SelectionLength = 0;
        }

        private void TXB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.A))
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
                e.Handled = true;
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
            textBox2.Focus();
        }

    }
}
