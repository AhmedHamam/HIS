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
    public partial class GroupA_PatientBill_Pay_Cash_Back : UserControl
    {
        int User_ID;
        Connection conn;
        SqlDataReader dr;
        string query;
        public GroupA_PatientBill_Pay_Cash_Back(int uid)
        {
            InitializeComponent();
            conn = new Connection();
            fill_Visit();
            User_ID = uid;

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
                query = @"SELECT   entranceoffice_visit.visit_id, Registeration_patientRegisteration.patient_name
                        FROM  entranceoffice_visit,Registeration_patientRegisteration WHERE
                        entranceoffice_visit.state_of_visit=1 AND entranceoffice_visit.pat_id = Registeration_patientRegisteration.patient_id
                        AND entranceoffice_visit.visit_id=ANY(SELECT visit_ID FROM Visit_Bill WHERE (value_payment + discount_amount) > (Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount ))";

                dr = conn.DataReader(query);
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

        private void clear()
        {
            label7.Text = "";
            label12.Text = "";
            label14.Text = "";
            label18.Text = "";
            label3.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                clear();
                return;
            }
            comboBox2.SelectedIndex = comboBox1.SelectedIndex;
            try
            {
                clear();
                conn.OpenConection();

                query = @"SELECT visit_id, entrance_date, type_of_visit FROM entranceoffice_visit WHERE entranceoffice_visit.visit_id=" + comboBox2.SelectedItem + "";
                dr = conn.DataReader(query);
                if (dr.Read())
                {
                    label7.Text = dr[0].ToString();
                    label12.Text = dr[2].ToString();
                    label14.Text = dr[1].ToString();

                }
                dr.Close();

                query = @"SELECT  value_payment ,(value_payment - patient_service_amount - patient_residence_amount - patient_medicine_amount + discount_amount) as value_requested
                        FROM Visit_Bill WHERE visit_id=" + comboBox2.SelectedItem + "";
                dr = conn.DataReader(query);
                if (dr.Read())
                {
                    label18.Text = dr[0].ToString();
                    label3.Text = dr[1].ToString();
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
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("حدد اسم المريض");
                return;
            }
            try
            {
                conn.OpenConection();
                query = @"INSERT INTO Visit_Payment(visit_ID, type, value, date, User_code) VALUES(@visit_ID, @type, @value,@date, @User_code)";
                string[] Parameters = new string[] {"@visit_ID","@type","@value","@date","@User_code"};
                string[] Values = new string[] { label7.Text,"1",label3.Text,DateTime.Now.ToString(),User_ID.ToString()};
                conn.ExecuteStoredProcQueries(query, Parameters, Values);

                query = "UPDATE Visit_Bill SET value_payment = (Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount - Visit_Bill.discount_amount) WHERE visit_ID=@visit_ID";
                Parameters = new string[] {"@visit_ID"};
                Values = new string[] { label7.Text };
                conn.ExecuteStoredProcQueries(query, Parameters, Values);
                conn.CloseConnection();
                comboBox1.SelectedIndex = -1;
                comboBox1.Text = "";
                fill_Visit();
                MessageBox.Show("تم رد المبلغ بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("حدد اسم المريض");
                return;
            }
            try
            {
                conn.OpenConection();
                query = @"INSERT INTO Visit_Payment(visit_ID, type, value, date, User_code) VALUES(@visit_ID, @type, @value,@date, @User_code)";
                string[] Parameters = new string[] { "@visit_ID", "@type", "@value", "@date", "@User_code" };
                string[] Values = new string[] { label7.Text, "1", label3.Text, DateTime.Now.ToString(), User_ID.ToString() };
                conn.ExecuteStoredProcQueries(query, Parameters, Values);

                query = "UPDATE Visit_Bill SET value_payment = (Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount - Visit_Bill.discount_amount ) WHERE visit_ID=@visit_ID";
                Parameters = new string[] { "@visit_ID" };
                Values = new string[] { label7.Text };
                conn.ExecuteStoredProcQueries(query, Parameters, Values);

                query = @"SELECT TOP 1 Visit_Payment.ID, Visit_Payment.visit_ID, Visit_Payment.value, Visit_Payment.date, employee.name, Registeration_patientRegisteration.patient_name
                        FROM  Visit_Payment INNER JOIN
                        Registeration_patientRegisteration INNER JOIN
                        entranceoffice_visit ON Registeration_patientRegisteration.patient_id = entranceoffice_visit.pat_id ON Visit_Payment.visit_ID = entranceoffice_visit.visit_id CROSS JOIN
                        Users INNER JOIN
                        employee ON Users.emp_id = employee.emp_id WHERE Visit_Payment.type=1 AND Visit_Payment.visit_ID=" + label7.Text + @" ORDER BY Visit_Payment.ID DESC";

                dt = (DataTable)conn.ShowDataInGridView(query);
                int c = dt.Rows.Count;
                conn.CloseConnection();
                if (c == 0)
                {
                    MessageBox.Show("error");
                }
                clear();
                Run();
                fill_Visit();
                comboBox1.SelectedIndex = -1;
                comboBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
