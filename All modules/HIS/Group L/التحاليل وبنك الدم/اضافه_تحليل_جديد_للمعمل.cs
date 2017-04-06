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
    public partial class اضافه_تحليل_فرعى : Form
    {
        //SqlConnection connection = new SqlConnection("Data Source=peter-pc;Initial Catalog=PHIS;Integrated Security=True");
        SqlCommand cmd;
        int s;
        public اضافه_تحليل_فرعى()
        {
            InitializeComponent();
            fillListbox();
        }

        void fillListbox()
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);

            cmd = new SqlCommand("select sample_name from analysis_samples", connection);
            SqlDataReader dr;
            try
            {
                connection.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string servName = dr.GetString(0);
                    listBox1.Items.Add(servName);
 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
 
        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //      //  if (txt_analysisname != string.Empty || txt_price != string.Empty()) ;
        //        connection.Open();
        //        if (s == 0)
        //        {
        //            //cmd = new SqlCommand("insert into analysis_info(serv_name,price,quantity,notices,sample_id)values(N'" + txt_analysisname.Text + "'," + txt_price.Text + ",'" + text_quantity.Text + "','"+txt_notices.Text+"',1) ", connection);
        //            //cmd = new SqlCommand("insert into analysis_samples", connection);
        //            cmd = new SqlCommand("labAnalysis_analysis_info_insert0", connection);
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@analysisName", txtServName.Text);
        //            cmd.Parameters.AddWithValue("@price", txtPrice.Text);
        //            cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);
        //            cmd.Parameters.AddWithValue("@notice", txtNotices.Text);
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("لقد تمت عمليه الاضافه بنجاح");

        //        }
        //        if (s == 1)
        //        {
        //            // cmd = new SqlCommand("insert into analysis_info(serv_name,price,quantity,notices,sample_id)values(N'" + txt_analysisname.Text + "'," + txt_price.Text + ",'" + text_quantity.Text + "','" + txt_notices.Text + "',2) ", connection);
        //            cmd = new SqlCommand("labAnalysis_analysis_info_insert1", connection);
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@analysisName", txtServName.Text);
        //            cmd.Parameters.AddWithValue("@price", txtPrice.Text);
        //            cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);
        //            cmd.Parameters.AddWithValue("@notice", txtNotices.Text);
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("لقد تمت عمليه الاضافه بنجاح");

        //        }
        //        if (s == 2)
        //        {
        //            //   cmd = new SqlCommand("insert into analysis_info(serv_name,price,quantity,notices,sample_id)values(N'" + txt_analysisname.Text + "'," + txt_price.Text + ",'" + text_quantity.Text + "','" + txt_notices.Text + "',3) ", connection);
        //            cmd = new SqlCommand("labAnalysis_analysis_info_insert2", connection);
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@analysisName", txtServName.Text);
        //            cmd.Parameters.AddWithValue("@price", txtPrice.Text);
        //            cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);
        //            cmd.Parameters.AddWithValue("@notice", txtNotices.Text);
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("لقد تمت عمليه الاضافه بنجاح");


        //        }
        //        if (s == 3)
        //        {
        //            //cmd = new SqlCommand("insert into analysis_info(serv_name,price,quantity,notices,sample_id)values(N'" + txt_analysisname.Text + "'," + txt_price.Text + ",'" + text_quantity.Text + "','" + txt_notices.Text + "',4) ", connection);
        //            cmd = new SqlCommand("labAnalysis_analysis_info_insert3", connection);
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@analysisName", txtServName.Text);
        //            cmd.Parameters.AddWithValue("@price", txtPrice.Text);
        //            cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);
        //            cmd.Parameters.AddWithValue("@notice", txtNotices.Text);
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("لقد تمت عمليه الاضافه بنجاح");

        //        }
        //        if (s == 4)
        //        {
        //            //  cmd = new SqlCommand("insert into analysis_info(serv_name,price,quantity,notices,sample_id)values(N'" + txt_analysisname.Text + "'," + txt_price.Text + ",'" + text_quantity.Text + "','" + txt_notices.Text + "',5) ", connection);
        //            cmd = new SqlCommand("labAnalysis_analysis_info_insert4", connection);
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@analysisName", txtServName.Text);
        //            cmd.Parameters.AddWithValue("@price", txtPrice.Text);
        //            cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);
        //            cmd.Parameters.AddWithValue("@notice", txtNotices.Text);
        //            cmd.ExecuteNonQuery();
        //            MessageBox.Show("لقد تمت عمليه الاضافه بنجاح");


        //        }
          



        //    }
        //    catch
        //    {
        //        // MessageBox.Show(ex.Message);
        //        MessageBox.Show("من فضلك اختر تحليل رئيسي وادخل جميع البيانات في التحليل الفرعي");
        //    }
        //    connection.Close();
        //}

        private void اضافه_تحليل_جديد_للمعمل_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            s = listBox1.SelectedIndex;

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Connection conn = new Connection(); string constr = conn.getconstr();
            SqlConnection connection = new SqlConnection(constr);

            try
            {
                connection.Open();
                for (int i = s; i <= listBox1.Items.Count; i++)
                {
                    //MessageBox.Show(s.ToString() + "   " +i.ToString());
                    cmd = new SqlCommand("insert into analysis_info(serv_name,price,quantity,notices,sample_id) values('"+txtServName.Text+"',"+txtPrice.Text+",'"+txtQuantity.Text+"','"+txtNotices.Text+"',"+(i+1)+") ", connection);
                    i = 100;
                    //MessageBox.Show((i+1).ToString());
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("تم اضافة تحليل فرعى بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
