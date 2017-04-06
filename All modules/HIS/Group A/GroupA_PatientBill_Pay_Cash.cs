using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace HIS
{
    public partial class GroupA_PatientBill_Pay_Cash : UserControl
    {
        int User_ID;
        Connection conn;
        SqlDataReader dr;
        string query;
        string VISIT_ID = "";
        public GroupA_PatientBill_Pay_Cash(int uid)
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
            textBox2.Text = "";
        }

        private void fill_data()
        {
            if (VISIT_ID == "" || VISIT_ID == null)
            {
                return;
            }
            try
            {
                clear();
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

                query = " SELECT (SELECT ISNULL(SUM(value),0) FROM Visit_Payment WHERE type=0 AND visit_id=" + VISIT_ID + ")-(SELECT ISNULL(SUM(value),0) FROM Visit_Payment WHERE type=1 AND visit_id=" + VISIT_ID + ")";
                dr = conn.DataReader(query);
                if (dr.Read())
                {
                    label18.Text = dr[0].ToString();
                }
                dr.Close();

                query = @"SELECT Visit_Payment.ID,Visit_Payment.value, Visit_Payment.date, employee.name FROM  employee INNER JOIN
                         Users ON employee.emp_id = Users.emp_id INNER JOIN
                         Visit_Payment ON Users.User_Code = Visit_Payment.User_code
                        WHERE type=0 AND visit_id=" + VISIT_ID + "";

                dr = conn.DataReader(query);
                dataGridView1.Rows.Clear();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3],"طباعة");
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
        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        DataTable dt = new DataTable();
        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        private void Export(LocalReport report)
        {
            string deviceInfo =
              "<DeviceInfo>" +
              "  <OutputFormat>EMF</OutputFormat>" +
              "  <PageWidth>7.8cm</PageWidth>" +
              "  <PageHeight>8.7cm</PageHeight>" +
              "  <MarginTop>0.0cm</MarginTop>" +
              "  <MarginLeft>0.0in</MarginLeft>" +
              "  <MarginRight>0.0in</MarginRight>" +
              "  <MarginBottom>0.0in</MarginBottom>" +
              "</DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }
        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");

            PrintDocument printDoc = new PrintDocument();

            PageSettings pg = new PageSettings();
            int count = dt.Rows.Count;
            PaperSize size = new PaperSize("KOKO", 300, 330);
            size.RawKind = (int)PaperKind.Custom;
            pg.PaperSize = size;
            printDoc.DefaultPageSettings = pg;

            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }
        private void Run()
        {
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rtds = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rtds);
            this.reportViewer1.RefreshReport();
            Export(reportViewer1.LocalReport);
            try
            {
                Print();
            }
            catch (Exception)
            {
                dt.Reset();
                MessageBox.Show("لا توجد طابعة");
                return;
            }

            dt.Reset();

        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            if (VISIT_ID == "" || VISIT_ID == null)
            {
                MessageBox.Show("حدد الزيارة من زر بحث");
                return;
            }
            try
            {
                conn.OpenConection();
                query = @"INSERT INTO Visit_Payment(visit_ID, type, value, date, User_code) VALUES(@visit_ID, @type, @value,@date, @User_code)";
                string[] Parameters = new string[] { "@visit_ID", "@type", "@value", "@date", "@User_code" };
                string[] Values = new string[] { label6.Text, "0", textBox2.Text, DateTime.Now.ToString(), User_ID.ToString() };
                conn.ExecuteStoredProcQueries(query, Parameters, Values);

                query = " SELECT (SELECT ISNULL(SUM(value),0) FROM Visit_Payment WHERE type=0 AND visit_id=" + label6.Text + ")-(SELECT ISNULL(SUM(value),0) FROM Visit_Payment WHERE type=1 AND visit_id=" + label6.Text + ")";
                dr = conn.DataReader(query);
                if (dr.Read())
                {
                    label18.Text = dr[0].ToString();
                }
                dr.Close();

                query = "UPDATE Visit_Bill SET value_payment =@value_payment WHERE visit_ID=@visit_ID";
                Parameters = new string[] { "@value_payment", "@visit_ID" };
                Values = new string[] { label18.Text, label6.Text };
                conn.ExecuteStoredProcQueries(query, Parameters, Values);
                conn.CloseConnection();
                clear();
                fill_data();
                MessageBox.Show("تم سدد المبلغ بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
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
            if (VISIT_ID == "" || VISIT_ID == null)
            {
                MessageBox.Show("حدد الزيارة من زر بحث");
                return;
            }
            try
            {
                conn.OpenConection();
                query = @"INSERT INTO Visit_Payment(visit_ID, type, value, date, User_code) VALUES(@visit_ID, @type, @value,@date, @User_code)";
                string[] Parameters = new string[] { "@visit_ID", "@type", "@value", "@date", "@User_code" };
                string[] Values = new string[] { label6.Text, "0", textBox2.Text, DateTime.Now.ToString(), User_ID.ToString() };
                conn.ExecuteStoredProcQueries(query, Parameters, Values);

                query = " SELECT (SELECT ISNULL(SUM(value),0) FROM Visit_Payment WHERE type=0 AND visit_id=" + label6.Text + ")-(SELECT ISNULL(SUM(value),0) FROM Visit_Payment WHERE type=1 AND visit_id=" + label6.Text + ")";
                dr = conn.DataReader(query);
                if (dr.Read())
                {
                    label18.Text = dr[0].ToString();
                }
                dr.Close();

                query = "UPDATE Visit_Bill SET value_payment =@value_payment WHERE visit_ID=@visit_ID";
                Parameters = new string[] { "@value_payment", "@visit_ID" };
                Values = new string[] { label18.Text, label6.Text };
                conn.ExecuteStoredProcQueries(query, Parameters, Values);

                query = @"SELECT TOP 1 Visit_Payment.ID, Visit_Payment.visit_ID, Visit_Payment.value, Visit_Payment.date, employee.name, Registeration_patientRegisteration.patient_name
                        FROM  Visit_Payment INNER JOIN
                        Registeration_patientRegisteration INNER JOIN
                        entranceoffice_visit ON Registeration_patientRegisteration.patient_id = entranceoffice_visit.pat_id ON Visit_Payment.visit_ID = entranceoffice_visit.visit_id CROSS JOIN
                        Users INNER JOIN
                        employee ON Users.emp_id = employee.emp_id WHERE Visit_Payment.type=0 AND Visit_Payment.visit_ID=" + label6.Text + @" ORDER BY Visit_Payment.ID DESC";

                dt = (DataTable)conn.ShowDataInGridView(query);
                int c = dt.Rows.Count;
                conn.CloseConnection();
                if (c == 0)
                {
                    MessageBox.Show("error");

                }
                clear();
                fill_data();
                Run();
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
                if (tempForm.Name == "GroupA_PatientBill_Visit_Patients")
                {
                    tempForm.Hide();
                }
            }
            var fo = new GroupA_PatientBill_Visit_Patients(conn);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                try
                {
                    conn.OpenConection();
                    query = @"SELECT  Visit_Payment.ID, Visit_Payment.visit_ID, Visit_Payment.value, Visit_Payment.date, employee.name, Registeration_patientRegisteration.patient_name
                        FROM  Visit_Payment INNER JOIN
                        Registeration_patientRegisteration INNER JOIN
                        entranceoffice_visit ON Registeration_patientRegisteration.patient_id = entranceoffice_visit.pat_id ON Visit_Payment.visit_ID = entranceoffice_visit.visit_id CROSS JOIN
                        Users INNER JOIN
                        employee ON Users.emp_id = employee.emp_id WHERE Visit_Payment.ID=" + dataGridView1.Rows[e.RowIndex].Cells[0].Value + "";

                    dt = (DataTable)conn.ShowDataInGridView(query);
                    int c = dt.Rows.Count;
                    conn.CloseConnection();
                    if (c == 0)
                    {
                        MessageBox.Show("error");

                    }
                    Run();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
