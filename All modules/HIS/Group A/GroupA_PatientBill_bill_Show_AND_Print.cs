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
    public partial class GroupA_PatientBill_bill_Show_AND_Print : UserControl
    {
        Connection conn;
        SqlDataReader dr;
        string query;

        string VISIT_ID="";

        public GroupA_PatientBill_bill_Show_AND_Print()
        {
            InitializeComponent();
            conn = new Connection();
        }

        private void clear()
        {
            label7.Text = "";
            label12.Text = "";
            label14.Text = "";

            label11.Text = "";
            label2.Text = "";
            label9.Text = "";
            label16.Text = "";

            label27.Text = "";
            label24.Text = "";
            label30.Text = "";
            label21.Text = "";

            label18.Text = "";
            label33.Text = "";
            label20.Text = "";

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
 
        }

        private void dataGridView_MouseEnter(object sender, EventArgs e)
        {
            DataGridView dv = (DataGridView)sender;
            dv.Focus();
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
              "  <PageHeight>14cm</PageHeight>" +
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
            PaperSize size = new PaperSize("KOKO", 300, 530);
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

        private void fill_data()
        {
            if (VISIT_ID == "" || VISIT_ID==null)
            {
                return;
            }
            try
            {
                clear();
                conn.OpenConection();
                query = @"SELECT Registeration_patientRegisteration.patient_name, entranceoffice_visit.type_of_visit, entranceoffice_visit.entrance_date, Visit_Bill.total_service, Visit_Bill.total_residence, Visit_Bill.total_medicine, 
                        (Visit_Bill.total_service + Visit_Bill.total_residence + Visit_Bill.total_medicine),
                        Visit_Bill.patient_service_amount, Visit_Bill.patient_residence_amount, Visit_Bill.patient_medicine_amount, 
                        (Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount),
                         Visit_Bill.value_payment,Visit_Bill.discount_amount,
                        (Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount- Visit_Bill.value_payment -Visit_Bill.discount_amount)
                         FROM  entranceoffice_visit INNER JOIN
                         Registeration_patientRegisteration ON entranceoffice_visit.pat_id = Registeration_patientRegisteration.patient_id INNER JOIN
                         Visit_Bill ON entranceoffice_visit.visit_id = Visit_Bill.visit_ID
                        AND entranceoffice_visit.visit_id=" + VISIT_ID + "";
                dr = conn.DataReader(query);
                if (dr.Read())
                {
                    label7.Text  = dr[0].ToString();
                    label12.Text = dr[1].ToString();
                    label14.Text = dr[2].ToString();

                    label11.Text = dr[3].ToString();
                    label2.Text  = dr[4].ToString();
                    label9.Text  = dr[5].ToString();
                    label16.Text = dr[6].ToString();

                    label27.Text = dr[7].ToString();
                    label24.Text = dr[8].ToString();
                    label30.Text = dr[9].ToString();
                    label21.Text = dr[10].ToString();

                    label18.Text = dr[11].ToString();
                    label33.Text = dr[12].ToString();
                    label20.Text = dr[13].ToString();

                }
                else
                {
                    clear();
                    conn.CloseConnection();
                    return;
                }
                dr.Close();

                query = @"SELECT   Visit_Services_Temp.ID, tb_Second_Level_Service.SLS_Aname,Visit_Services_Temp.price_before_discount, Visit_Services_Temp.date, employee.name
                    FROM Visit_Services_Temp,tb_Second_Level_Service,employee,Users WHERE 
                    Visit_Services_Temp.visit_ID=" + VISIT_ID + @" AND
                    Visit_Services_Temp.SLS_id = tb_Second_Level_Service.SLS_id AND
                    Users.emp_id = employee.emp_id AND
                    Visit_Services_Temp.User_code=Users.User_Code";
                dr = conn.DataReader(query);
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4]);
                }
                dr.Close();
                ///////////////////////////

                query = @"SELECT Visit_Residence_Temp.ID, Visit_Residence_Temp.number_of_room, tb_Accommodation_Degrees.AD_Aname, Visit_Residence_Temp.price_before_discount,
                        Visit_Residence_Temp.start_date, Visit_Residence_Temp.end_date, Visit_Residence_Temp.number_of_days,employee.name 
                        FROM   Users INNER JOIN
                        employee ON Users.emp_id = employee.emp_id INNER JOIN
                        Visit_Residence_Temp ON Users.User_Code = Visit_Residence_Temp.User_code INNER JOIN
                        tb_Accommodation_Degrees INNER JOIN
                        rooms ON tb_Accommodation_Degrees.AD_id = rooms.Service_level ON Visit_Residence_Temp.number_of_room = rooms.Room_code 
                        WHERE Visit_Residence_Temp.visit_ID=" + VISIT_ID + "";

                dr = conn.DataReader(query);
                while (dr.Read())
                {
                    dataGridView2.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6], dr[7]);
                }
                dr.Close();

                //////////////////////////
                query = @"SELECT  Visit_Medicine_Temp.ID, med_medicine.medicine_name, Visit_Medicine_Temp.item_quantity, med_medicine.price,Visit_Medicine_Temp.date, employee.name
                        FROM  Visit_Medicine_Temp,med_medicine,employee,Users WHERE 
                        Visit_Medicine_Temp.visit_ID=" + VISIT_ID + @" AND
                        Visit_Medicine_Temp.item_ID = med_medicine.med_id AND
                        Users.emp_id = employee.emp_id AND
                        Visit_Medicine_Temp.User_code=Users.User_Code";


                dr = conn.DataReader(query);
                while (dr.Read())
                {
                    dataGridView3.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.OpenConection();

                query = @"SELECT Visit_Bill.ID, Visit_Bill.visit_ID, Registeration_patientRegisteration.patient_name, employee.name, Visit_Bill.date, Visit_Bill.total_service, Visit_Bill.total_residence, Visit_Bill.total_medicine,Visit_Bill.discount_amount, 
                        (Visit_Bill.total_service + Visit_Bill.total_residence + Visit_Bill.total_medicine)as total1, 
                        Visit_Bill.patient_service_amount, Visit_Bill.patient_residence_amount, Visit_Bill.patient_medicine_amount,(Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount) as total2,
                        value_payment, (Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount - Visit_Bill.value_payment - Visit_Bill.discount_amount )as value_requested, tb_Contracting_Entities.CE_AName, tb_Entities_Branches.EB_Aname,
                        tb_Entities_Category.EC_Aname,(tb_Contracting_Entities.CE_AName+' - '+ tb_Entities_Branches.EB_Aname +' - '+ tb_Entities_Category.EC_Aname)as full_name          
                        FROM employee INNER JOIN
                        Users ON employee.emp_id = Users.emp_id INNER JOIN
                        Visit_Bill ON Users.User_Code = Visit_Bill.User_code INNER JOIN
                        Registeration_patientRegisteration INNER JOIN
                        entranceoffice_visit ON Registeration_patientRegisteration.patient_id = entranceoffice_visit.pat_id INNER JOIN
                        tb_Entities_Branches INNER JOIN
                        tb_Contracting_Entities ON tb_Entities_Branches.EB_CE_id = tb_Contracting_Entities.CE_Id INNER JOIN
                        tb_Entities_Category ON tb_Entities_Branches.EB_id = tb_Entities_Category.EC_EB_id ON entranceoffice_visit.EC_id = tb_Entities_Category.EC_id ON Visit_Bill.visit_ID = entranceoffice_visit.visit_id AND 
                        Visit_Bill.EB_id = tb_Entities_Branches.EB_id AND Visit_Bill.EB_id = tb_Entities_Branches.EB_id AND Visit_Bill.CE_Id = tb_Contracting_Entities.CE_Id AND Visit_Bill.visit_ID=" + VISIT_ID + "";

                dt.Clear();
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt1=new DataTable();
                DataTable dt2=new DataTable();
                DataTable dt3=new DataTable();
                DataTable dt4=new DataTable();

                conn.OpenConection();

                query = @"SELECT Visit_Bill.ID, Visit_Bill.visit_ID, Registeration_patientRegisteration.patient_name, employee.name, Visit_Bill.date, Visit_Bill.total_service, Visit_Bill.total_residence, Visit_Bill.total_medicine, Visit_Bill.discount_amount,
                    (Visit_Bill.total_service + Visit_Bill.total_residence + Visit_Bill.total_medicine)as total1, 
                    Visit_Bill.patient_service_amount, Visit_Bill.patient_residence_amount, Visit_Bill.patient_medicine_amount,(Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount) as total2,
                    value_payment, (Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount - Visit_Bill.value_payment - Visit_Bill.discount_amount )as value_requested, tb_Contracting_Entities.CE_AName, tb_Entities_Branches.EB_Aname,
                    tb_Entities_Category.EC_Aname,(tb_Contracting_Entities.CE_AName+' - '+ tb_Entities_Branches.EB_Aname +' - '+ tb_Entities_Category.EC_Aname)as full_name          
                    FROM employee INNER JOIN
                    Users ON employee.emp_id = Users.emp_id INNER JOIN
                    Visit_Bill ON Users.User_Code = Visit_Bill.User_code INNER JOIN
                    Registeration_patientRegisteration INNER JOIN
                    entranceoffice_visit ON Registeration_patientRegisteration.patient_id = entranceoffice_visit.pat_id INNER JOIN
                    tb_Entities_Branches INNER JOIN
                    tb_Contracting_Entities ON tb_Entities_Branches.EB_CE_id = tb_Contracting_Entities.CE_Id INNER JOIN
                    tb_Entities_Category ON tb_Entities_Branches.EB_id = tb_Entities_Category.EC_EB_id ON entranceoffice_visit.EC_id = tb_Entities_Category.EC_id ON Visit_Bill.visit_ID = entranceoffice_visit.visit_id AND 
                    Visit_Bill.EB_id = tb_Entities_Branches.EB_id AND Visit_Bill.EB_id = tb_Entities_Branches.EB_id AND Visit_Bill.CE_Id = tb_Contracting_Entities.CE_Id AND Visit_Bill.visit_ID=" + VISIT_ID + "";
              dt1 = (DataTable)conn.ShowDataInGridView(query);

                ////////////////////////////////////

                query = @"SELECT  Visit_Services_Temp.ID, tb_Second_Level_Service.SLS_Aname,Visit_Services_Temp.price_before_discount, Visit_Services_Temp.date, employee.name
                    FROM Visit_Services_Temp,tb_Second_Level_Service,employee,Users WHERE 
                    Visit_Services_Temp.visit_ID=" + VISIT_ID + @" AND
                    Visit_Services_Temp.SLS_id = tb_Second_Level_Service.SLS_id AND
                    Users.emp_id = employee.emp_id AND
                    Visit_Services_Temp.User_code=Users.User_Code";
                dt2 = (DataTable)conn.ShowDataInGridView(query);
                
                ///////////////////////////

                query = @"SELECT Visit_Residence_Temp.ID, Visit_Residence_Temp.number_of_room, tb_Accommodation_Degrees.AD_Aname, Visit_Residence_Temp.price_before_discount,
                        Visit_Residence_Temp.start_date, Visit_Residence_Temp.end_date, Visit_Residence_Temp.number_of_days,employee.name 
                        FROM            Users INNER JOIN
                        employee ON Users.emp_id = employee.emp_id INNER JOIN
                        Visit_Residence_Temp ON Users.User_Code = Visit_Residence_Temp.User_code INNER JOIN
                        tb_Accommodation_Degrees INNER JOIN
                        rooms ON tb_Accommodation_Degrees.AD_id = rooms.Service_level ON Visit_Residence_Temp.number_of_room = rooms.Room_code 
                        WHERE Visit_Residence_Temp.visit_ID=" + VISIT_ID + "";
                dt3 = (DataTable)conn.ShowDataInGridView(query);

                //////////////////////////
                query = @"SELECT  Visit_Medicine_Temp.ID, med_medicine.medicine_name, Visit_Medicine_Temp.item_quantity, med_medicine.price,Visit_Medicine_Temp.date, employee.name
                        FROM  Visit_Medicine_Temp,med_medicine,employee,Users WHERE 
                        Visit_Medicine_Temp.visit_ID=" + VISIT_ID + @" AND
                        Visit_Medicine_Temp.item_ID = med_medicine.med_id AND
                        Users.emp_id = employee.emp_id AND
                        Visit_Medicine_Temp.User_code=Users.User_Code";
                dt4 = (DataTable)conn.ShowDataInGridView(query);
                conn.CloseConnection();

                var fo = new GroupA_PatientBill_bill_report(dt1,dt2,dt3,dt4);
                fo.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GroupA_PatientBill_bill_Show_AND_Print_Resize(object sender, EventArgs e)
        {
            try
            {
                panel1.VerticalScroll.Value = 0;
                panel1.HorizontalScroll.Value = 0;
                int x = panel1.Width / 2 - panel2.Size.Width / 2;
                int y = panel1.Height / 2 - panel2.Size.Height / 2;
                if (x <= 0) { x = 0; }
                if (y <= 0) { y = 0; }
                panel2.Location = new Point(x, y);
            }
            catch
            { }
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
    }
}
