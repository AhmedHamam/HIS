using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; using System.Configuration;

namespace HIS
{

    public partial class الروشتة : Form
    {
        //SqlConnection connection = new SqlConnection("Data Source=DESKTOP-FV2OEH6;Initial Catalog=HIS;Integrated Security=True")
        //SqlConnection connection = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
       SqlCommand cmd;
        int j=1 ;

        // data of requested anaylsis sample
        string analID = "";
        string analName = "";
        string analPrice = "";
        string analNote = "";
        string analQuantity = "";

        // data of patient
        string patientID = "";
        string patientName = "";
        string patientAge = "";
        string patientGender = "";

        // data of request
        string reqDate = "";
        string reqPlace = "";

        public الروشتة(string a,string b,string c,string d,string e,string f,string g,string h,string i,string j,string k )
        {
            InitializeComponent();
            analID=a;
            analName=b;
            analPrice=c;
            analQuantity=d;
            analNote=e;
            patientID = f;
            patientName = g;
            patientAge = h;
            patientGender = i;
            reqDate = j;
            reqPlace = k;

            //MessageBox.Show(analID+analName+analPrice+analQuantity+analNote+patientID+patientName+patientAge+patientGender+reqDate+reqPlace);
           

        }

        private void الروشتة_Load(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
            

            try
            {
                connection.Open();
                for (int i = j; i < 100000000; i++)
                {
                    labBillID.Text = i.ToString();
                    //i++;
                    if (i == j)
                        break;
                }
                j++;


                labReqDate.Text = reqDate;
                labReqPlace.Text = reqPlace;
                labPatientName.Text = patientName;
                labPatientID.Text = patientID;
                labAnalName.Text = analName;
                labAnalPrice.Text = analPrice;


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);
               try
            {
                connection.Open();
                cmd = new SqlCommand("truncate table bill", connection);
                cmd.ExecuteNonQuery();
              //  cmd = new SqlCommand("insert into bill(req_date,req_place,patient_name,patient_id,anal_name,anal_price)values(N'" + labReqDate.Text + "',N'" + labReqPlace.Text + "',N'" + labPatientName.Text + "'," + labPatientID.Text + ",N'" + labAnalName.Text + "'," + labAnalPrice.Text + ")", connection);
               // cmd.ExecuteNonQuery();
                cmd = new SqlCommand("labAnalysis_bill_insert", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("req_date", reqDate);
                cmd.Parameters.AddWithValue("req_place", reqPlace);
                cmd.Parameters.AddWithValue("patient_name", patientName);
                cmd.Parameters.AddWithValue("patient_id", patientID);
                cmd.Parameters.AddWithValue("anal_name", analName);
                cmd.Parameters.AddWithValue("anal_price", analPrice);
                cmd.ExecuteNonQuery();
              // استلام__الفاتوره f2=new استلام__الفاتوره();
             //   f2.Show();
                طباعه_الفاتوره___التحاليل nw = new طباعه_الفاتوره___التحاليل();
                nw.Show();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        }

       
    }

