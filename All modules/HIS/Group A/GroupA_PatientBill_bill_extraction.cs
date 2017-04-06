
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
    public partial class UserControl_bill_extraction : UserControl
    {
        int User_ID;
        Connection conn;
        SqlDataReader dr;
        string query;
        string EntityID;      //كود الجهة
        string BranchEntityID;//كود الجهة الفرعية
        string GroupID;       //كود الفئة
        string RegulationID;  ////كود الائحة

        int Patient_service_percentage = 0;
        int Patient_medicine_percentage = 0;
        int Patient_residence_percentage = 0;

        int Entity_service_percentage = 0;
        int Entity_medicine_percentage = 0;
        int Entity_residence_percentage = 0;

        string VISIT_ID = "";

        public UserControl_bill_extraction(int uid)
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

            label11.Text = "";
            label2.Text = "";
            label9.Text = "";
            label16.Text = "";

            label27.Text = "";
            label24.Text = "";
            label30.Text = "";
            label21.Text = "";

            label18.Text = "";
            label20.Text = "";

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
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

                query = @"SELECT  entranceoffice_visit.visit_id, Registeration_patientRegisteration.patient_name, entranceoffice_visit.type_of_visit,
                        entranceoffice_visit.entrance_date, tb_Contracting_Entities.CE_Id, tb_Entities_Branches.EB_id, tb_Entities_Category.EC_id
                        FROM tb_Entities_Branches INNER JOIN
                         tb_Contracting_Entities ON tb_Entities_Branches.EB_CE_id = tb_Contracting_Entities.CE_Id INNER JOIN
                         tb_Entities_Category ON tb_Entities_Branches.EB_id = tb_Entities_Category.EC_EB_id INNER JOIN
                         entranceoffice_visit INNER JOIN
                         Registeration_patientRegisteration ON entranceoffice_visit.pat_id = Registeration_patientRegisteration.patient_id ON tb_Entities_Category.EC_id = entranceoffice_visit.EC_id AND 
                         tb_Entities_Category.EC_id = entranceoffice_visit.EC_id WHERE entranceoffice_visit.visit_id=" + VISIT_ID + "";
                    dr = conn.DataReader(query);
                if (dr.Read())
                {
                    label6.Text = dr[0].ToString();
                    label7.Text = dr[1].ToString();
                    label12.Text = dr[2].ToString();
                    label14.Text = dr[3].ToString();

                    EntityID=dr[4].ToString();      //كود الجهة
                    BranchEntityID=dr[5].ToString();//كود الجهة الفرعية
                    GroupID = dr[6].ToString();       //كود الفئة

                }
                dr.Close();

                query = @"SELECT  EC_Service_Contribution,  EC_Drugs_Contribution, EC_Accomodation_Contribution, EC_Service_Disprecent, EC_Drugs_Disprecent, EC_Accomodation_Disprecent
                      FROM tb_Entities_Category WHERE EC_Id='" + GroupID + "'";
                dr = conn.DataReader(query);
                if (dr.Read())
                {
                    Patient_service_percentage = Convert.ToInt32(dr[0]);
                    Patient_medicine_percentage = Convert.ToInt32(dr[1]);
                    Patient_residence_percentage = Convert.ToInt32(dr[2]);

                    Entity_service_percentage = Convert.ToInt32(dr[3]);
                    Entity_medicine_percentage = Convert.ToInt32(dr[4]);
                    Entity_residence_percentage = Convert.ToInt32(dr[5]);
                }
                dr.Close();


                query = " SELECT (SELECT ISNULL(SUM(value),0) FROM Visit_Payment WHERE type=0 AND visit_ID=" + VISIT_ID + ")-(SELECT ISNULL(SUM(value),0) FROM Visit_Payment WHERE type=1 AND visit_ID=" + VISIT_ID + ")";
                dr = conn.DataReader(query);
                if (dr.Read())
                {
                    label18.Text = dr[0].ToString();
                }
                dr.Close();

                query = "SELECT  CE_RP_id FROM tb_Contracting_Entities WHERE CE_Id='" + EntityID + "'";
                dr = conn.DataReader(query);
                if (dr.Read())
                {
                    RegulationID = dr[0].ToString();
                }
                dr.Close();



                query = @"SELECT   Visit_Services_Temp.ID,  tb_Second_Level_Service.SLS_Aname,("+ Entity_service_percentage + @" * tb_Service_Pricing.SP_Service_Price / 100), Visit_Services_Temp.date, employee.name
                    FROM Visit_Services_Temp,tb_Second_Level_Service,tb_Service_Pricing,employee,Users WHERE 
                    Visit_Services_Temp.visit_ID=" + VISIT_ID + @" AND
                    Visit_Services_Temp.SLS_id = tb_Second_Level_Service.SLS_id AND
                    tb_Second_Level_Service.SLS_id=tb_Service_Pricing.SP_SLS_id AND 
                    tb_Service_Pricing.SP_RP_id=" + RegulationID + @" AND
                    Users.emp_id = employee.emp_id AND
                    Visit_Services_Temp.User_code=Users.User_Code";
                dr = conn.DataReader(query);
                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr[0],dr[1],dr[2],dr[3],dr[4]);
                }
                dr.Close();
                ///////////////////////////

                query = @"SELECT Visit_Residence_Temp.ID, Visit_Residence_Temp.number_of_room, tb_Accommodation_Degrees.AD_Aname, Visit_Residence_Temp.start_date, 
                        Visit_Residence_Temp.end_date,employee.name,tb_Accommodation_Degrees.AD_id,Visit_Residence_Temp.type FROM Visit_Residence_Temp,rooms,tb_Accommodation_Degrees,employee,Users WHERE 
                        Visit_Residence_Temp.visit_ID=" + VISIT_ID + @" AND
                        Visit_Residence_Temp.number_of_room = rooms.Room_code AND 
                        tb_Accommodation_Degrees.AD_id = rooms.Service_level AND
                        Users.emp_id = employee.emp_id AND
                        Visit_Residence_Temp.User_code=Users.User_Code";

               dr = conn.DataReader(query);
               while (dr.Read())
               {
                   dataGridView2.Rows.Add(dr[0], dr[1], dr[2], "0", dr[3], dr[4], NumOfDay(dr[3].ToString(), dr[4].ToString()), dr[5],dr[6],dr[7]);
               }
               dr.Close();

                for(int i=0;i<dataGridView2.Rows.Count;i++)
                {
                    if (dataGridView2.Rows[i].Cells[9].Value.ToString() == "0")
                    {
                        query = @"SELECT (" + Entity_residence_percentage + @" * AP_accommodate_of_patient / 100) FROM tb_Accommodation_Pricing WHERE AP_RP_id =" + RegulationID + "AND AP_AD_id =" + dataGridView2.Rows[i].Cells[8].Value;
                        dr = conn.DataReader(query);
                        if (dr.Read())
                        {
                            dataGridView2.Rows[i].Cells[3].Value = dr[0].ToString();
                        }
                        dr.Close();
                    }
                    else if (dataGridView2.Rows[i].Cells[9].Value.ToString() == "1")
                    {
                        query = @"SELECT (" + Entity_residence_percentage + @" * AP_lieutenant_on_chair / 100)  FROM tb_Accommodation_Pricing WHERE AP_RP_id =" + RegulationID + "AND AP_AD_id =" + dataGridView2.Rows[i].Cells[8].Value;
                        dr = conn.DataReader(query);
                        if (dr.Read())
                        {
                            dataGridView2.Rows[i].Cells[3].Value = dr[0].ToString();
                        }
                        dr.Close();
                    }
                    else if (dataGridView2.Rows[i].Cells[9].Value.ToString() == "2")
                    {
                        query = @"SELECT (" + Entity_residence_percentage + @" * AP_lieutenant_on_bed / 100)  FROM tb_Accommodation_Pricing WHERE AP_RP_id =" + RegulationID + "AND AP_AD_id =" + dataGridView2.Rows[i].Cells[8].Value;
                        dr = conn.DataReader(query);
                        if (dr.Read())
                        {
                            dataGridView2.Rows[i].Cells[3].Value = dr[0].ToString();
                        }
                        dr.Close();
                    }
                }
                //////////////////////////
                query = @"SELECT  Visit_Medicine_Temp.ID, med_medicine.medicine_name, Visit_Medicine_Temp.item_quantity, (" + Entity_medicine_percentage + @" * med_medicine.price / 100),Visit_Medicine_Temp.date, employee.name
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

        private int NumOfDay(string d1,string d2)
        {
            DateTime start=DateTime.Parse(d1);
            DateTime end=DateTime.Parse(d2);
            if (start >= end)
            {
                return 1;
            }
            int count = 0;
            if(start.Hour<12)
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

                int num1 = dataGridView1.Rows.Count;
                int num2 = dataGridView2.Rows.Count;
                int num3 = dataGridView3.Rows.Count;
                double total1 = 0.0;
                double total2 = 0.0;
                double total3 = 0.0;
                for (int i = 0; i < num1; i++)
                {
                    total1 += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value.ToString());
                }
                for (int i = 0; i < num2; i++)
                {
                    total2 += Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value.ToString()) * Convert.ToDouble(dataGridView2.Rows[i].Cells[6].Value.ToString());
                }

                for (int i = 0; i < num3; i++)
                {
                    total3 += Convert.ToDouble(dataGridView3.Rows[i].Cells[2].Value.ToString()) * Convert.ToDouble(dataGridView3.Rows[i].Cells[3].Value.ToString());
                }
                label11.Text = total1.ToString();
                label2.Text = total2.ToString();
                label9.Text = total3.ToString();
                label16.Text = (total1 + total2 + total3).ToString();

                label27.Text = (Patient_service_percentage * total1 / 100).ToString();
                label24.Text = (Patient_residence_percentage * total2 / 100).ToString();
                label30.Text = (Patient_medicine_percentage * total3 / 100).ToString();
                label21.Text = ((Patient_service_percentage * total1 / 100) + (Patient_residence_percentage * total2 / 100) + (Patient_medicine_percentage * total3 / 100)).ToString();

                label20.Text = (Convert.ToDouble(label21.Text) - Convert.ToDouble(label18.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_MouseEnter(object sender, EventArgs e)
        {
            DataGridView dv = (DataGridView)sender;
            dv.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (VISIT_ID == "" || VISIT_ID == null)
            {
                return;
            }
            try
            {
                conn.OpenConection();
                string[] Parameters;
                string[] Values; 
                int c = 0;
                double temp_price = 0;
                c = dataGridView1.Rows.Count;
                for (int i = 0; i < c; i++)
                {
                    query = @"UPDATE Visit_Services_Temp SET price_before_discount=@price_before_discount, price_after_discount=@price_after_discount WHERE ID=@ID";

                    temp_price=Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                    Parameters = new string[3];
                    Values = new string[3];
                    Parameters[0] = "@price_before_discount";
                    Values[0]=temp_price.ToString();
                    Parameters[1] = "@price_after_discount";
                    Values[1] = (Patient_service_percentage * temp_price / 100).ToString();
                    Parameters[2] = "@ID";
                    Values[2] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    conn.ExecuteStoredProcQueries(query,Parameters,Values);
                }

                c = dataGridView2.Rows.Count;
                for (int i = 0; i < c; i++)
                {
                    query = @"UPDATE Visit_Residence_Temp SET number_of_days=@number_of_days,price_before_discount=@price_before_discount, price_after_discount=@price_after_discount WHERE ID=@ID";

                    temp_price = Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                    Parameters = new string[4];
                    Values = new string[4];
                    Parameters[0] = "@number_of_days";
                    Values[0] = dataGridView2.Rows[i].Cells[6].Value.ToString();
                    Parameters[1] = "@price_before_discount";
                    Values[1] = temp_price.ToString();
                    Parameters[2] = "@price_after_discount";
                    Values[2] = (Patient_residence_percentage * temp_price / 100).ToString();
                    Parameters[3] = "@ID";
                    Values[3] = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    conn.ExecuteStoredProcQueries(query, Parameters, Values);
                }

                c = dataGridView3.Rows.Count;
                for (int i = 0; i < c; i++)
                {
                    query = @"UPDATE Visit_Medicine_Temp SET price_before_discount=@price_before_discount, price_after_discount=@price_after_discount WHERE ID=@ID";

                    temp_price = Convert.ToDouble(dataGridView3.Rows[i].Cells[3].Value);
                    Parameters = new string[3];
                    Values = new string[3];
                    Parameters[0] = "@price_before_discount";
                    Values[0] = temp_price.ToString();
                    Parameters[1] = "@price_after_discount";
                    Values[1] = (Patient_medicine_percentage * temp_price / 100).ToString();
                    Parameters[2] = "@ID";
                    Values[2] = dataGridView3.Rows[i].Cells[0].Value.ToString();
                    conn.ExecuteStoredProcQueries(query, Parameters, Values);
                }
                ///////////////////////////////////////////

                query = @"INSERT INTO Visit_Bill (visit_ID,CE_Id,EB_id,EC_id, total_service, total_residence, total_medicine, patient_service_amount, patient_residence_amount, patient_medicine_amount,value_payment,date, User_code)
                          VALUES  (@visit_ID,@CE_Id,@EB_id,@EC_id,@total_service,@total_residence,@total_medicine,@patient_service_amount,@patient_residence_amount,@patient_medicine_amount,@value_payment,@date,@User_code)";

                Parameters = new string[] { "@visit_ID", "@CE_Id", "@EB_id", "@EC_id", "@total_service", "@total_residence", "@total_medicine", "@patient_service_amount", "@patient_residence_amount", "@patient_medicine_amount", "@value_payment", "@date", "@User_code" };
                Values = new string[] { label6.Text, EntityID, BranchEntityID, GroupID, label11.Text, label2.Text, label9.Text,label27.Text, label24.Text, label30.Text,label18.Text, DateTime.Now.ToString(), User_ID.ToString() };
                conn.ExecuteStoredProcQueries(query, Parameters, Values);

                query = "UPDATE entranceoffice_visit SET state_of_visit =1 WHERE visit_id=" + VISIT_ID + "";
                conn.ExecuteQueries(query);
                /////////////////////////////////////

                query = @"SELECT Visit_Bill.ID, Visit_Bill.visit_ID, Registeration_patientRegisteration.patient_name, employee.name, Visit_Bill.date, Visit_Bill.total_service, Visit_Bill.total_residence, Visit_Bill.total_medicine, Visit_Bill.discount_amount,
                        (Visit_Bill.total_service + Visit_Bill.total_residence + Visit_Bill.total_medicine)as total1, 
                        Visit_Bill.patient_service_amount, Visit_Bill.patient_residence_amount, Visit_Bill.patient_medicine_amount,(Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount) as total2,
                        value_payment, (Visit_Bill.patient_service_amount + Visit_Bill.patient_residence_amount + Visit_Bill.patient_medicine_amount - Visit_Bill.value_payment - Visit_Bill.discount_amount)as value_requested, tb_Contracting_Entities.CE_AName, tb_Entities_Branches.EB_Aname,
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
                c = dt.Rows.Count;
                conn.CloseConnection();
                if (c == 0)
                {
                    MessageBox.Show("error");
                    
                }
                clear();
                Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            PaperSize size = new PaperSize("KOKO", 300, 430);
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
            if (VISIT_ID == "" || VISIT_ID == null)
            {
                return;
            }
            try
            {
                conn.OpenConection();
                string[] Parameters;
                string[] Values;
                int c = 0;
                double temp_price = 0;
                c = dataGridView1.Rows.Count;
                for (int i = 0; i < c; i++)
                {
                    query = @"UPDATE Visit_Services_Temp SET price_before_discount=@price_before_discount, price_after_discount=@price_after_discount WHERE ID=@ID";

                    temp_price = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
                    Parameters = new string[3];
                    Values = new string[3];
                    Parameters[0] = "@price_before_discount";
                    Values[0] = temp_price.ToString();
                    Parameters[1] = "@price_after_discount";
                    Values[1] = (Patient_service_percentage * temp_price / 100).ToString();
                    Parameters[2] = "@ID";
                    Values[2] = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    conn.ExecuteStoredProcQueries(query, Parameters, Values);
                }

                c = dataGridView2.Rows.Count;
                for (int i = 0; i < c; i++)
                {
                    query = @"UPDATE Visit_Residence_Temp SET number_of_days=@number_of_days,price_before_discount=@price_before_discount, price_after_discount=@price_after_discount WHERE ID=@ID";

                    temp_price = Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value);
                    Parameters = new string[4];
                    Values = new string[4];
                    Parameters[0] = "@number_of_days";
                    Values[0] = dataGridView2.Rows[i].Cells[6].Value.ToString();
                    Parameters[1] = "@price_before_discount";
                    Values[1] = temp_price.ToString();
                    Parameters[2] = "@price_after_discount";
                    Values[2] = (Patient_residence_percentage * temp_price / 100).ToString();
                    Parameters[3] = "@ID";
                    Values[3] = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    conn.ExecuteStoredProcQueries(query, Parameters, Values);
                }

                c = dataGridView3.Rows.Count;
                for (int i = 0; i < c; i++)
                {
                    query = @"UPDATE Visit_Medicine_Temp SET price_before_discount=@price_before_discount, price_after_discount=@price_after_discount WHERE ID=@ID";

                    temp_price = Convert.ToDouble(dataGridView3.Rows[i].Cells[3].Value);
                    Parameters = new string[3];
                    Values = new string[3];
                    Parameters[0] = "@price_before_discount";
                    Values[0] = temp_price.ToString();
                    Parameters[1] = "@price_after_discount";
                    Values[1] = (Patient_medicine_percentage * temp_price / 100).ToString();
                    Parameters[2] = "@ID";
                    Values[2] = dataGridView3.Rows[i].Cells[0].Value.ToString();
                    conn.ExecuteStoredProcQueries(query, Parameters, Values);
                }
                ///////////////////////////////////////////

                query = @"INSERT INTO Visit_Bill (visit_ID,CE_Id,EB_id,EC_id, total_service, total_residence, total_medicine, patient_service_amount, patient_residence_amount, patient_medicine_amount,value_payment,date, User_code)
                          VALUES  (@visit_ID,@CE_Id,@EB_id,@EC_id,@total_service,@total_residence,@total_medicine,@patient_service_amount,@patient_residence_amount,@patient_medicine_amount,@value_payment,@date,@User_code)";

                Parameters = new string[] { "@visit_ID", "@CE_Id", "@EB_id", "@EC_id", "@total_service", "@total_residence", "@total_medicine", "@patient_service_amount", "@patient_residence_amount", "@patient_medicine_amount", "@value_payment", "@date", "@User_code" };
                Values = new string[] { label6.Text, EntityID, BranchEntityID, GroupID, label11.Text, label2.Text, label9.Text, label27.Text, label24.Text, label30.Text, label18.Text, DateTime.Now.ToString(), User_ID.ToString() };
                conn.ExecuteStoredProcQueries(query, Parameters, Values);

                query = "UPDATE entranceoffice_visit SET state_of_visit =1 WHERE visit_id=" + VISIT_ID + "";
                conn.ExecuteQueries(query);

                conn.CloseConnection();
                if (c == 0)
                {
                    MessageBox.Show("error");

                }
                clear();
                MessageBox.Show("تم الحفظ بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
        }
    }
}
