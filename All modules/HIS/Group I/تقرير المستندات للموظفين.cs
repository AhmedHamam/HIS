using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HIS
{
    public partial class rep_emp : Form
    {
        Connection con = new Connection();
        public rep_emp()
        {
            InitializeComponent();
        }

      
//***************************************************************************
        private void load_combox()
        {
            try
            {
                con.OpenConection();

                DataTable dt = new DataTable();
                dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("loadcombox");
                comboBox1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; ++i)
                    comboBox1.Items.Add(dt.Rows[i][0].ToString());

            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            try
            {
                con.OpenConection();

                DataTable dt = new DataTable();
                dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("loadcomboxc");
                comboBox2.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; ++i)
                    comboBox2.Items.Add(dt.Rows[i][0].ToString());
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }

        private void rep_emp_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.document_group' table. You can move, or remove it, as needed.
           


            load_combox();
            this.reportViewer1.RefreshReport();
        }
       

//**************************************************************************************
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string x = "";
                string y="" ,z="",q="",w="",h="";
                con.OpenConection();
                SqlConnection con1 = new SqlConnection(@"server=(localdb)\v11.0;Initial Catalog=PHIS;Integrated Security=True");
                con1.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con1;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select emp_id from employee where name = @name";
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox2.Text;
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    x = dr["emp_id"].ToString();
                    dr.Close();
                    //*******************************************************************************
                    cmd.CommandText = "select catagory_id,document_history from employee_has_catagory where emp_id = @n";
                    cmd.Parameters.Add("@n", SqlDbType.Int).Value = x;
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        y = dr["catagory_id"].ToString();
                        h = dr["document_history"].ToString();
                        dateTimePicker3.Text = h;
                        dr.Close();

                        //****************************************************************************************************
                        cmd.CommandText = "select arabic_name,group_id from document_catagory where catagory_id =@a";
                        cmd.Parameters.Add("@a", SqlDbType.Int).Value = y;
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        z = dr["arabic_name"].ToString();
                        q = dr["group_id"].ToString();
                        comboBox2.Text = z;
                        dr.Close();
                        //********************************************************
                        cmd.CommandText = "select arabic_name from document_group where group_id =@i";
                        cmd.Parameters.Add("@i", SqlDbType.Int).Value = q;
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        w = dr["arabic_name"].ToString();
                        comboBox1.Text = w;
                        textBox3.Text = "تم ادخال " + comboBox2.Text + "من نوع " + comboBox1.Text + "للموظف" + textBox2.Text;
                        dr.Close();
                    }
                    else
                    {
                        MessageBox.Show("لم يتم ادخال اي مستندات لهذا الموظف");
                    }

                }
               
                

                con1.Close();
               

                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //reportViewer.LocalReport.ReportPath = @"Report Path";
            //reportViewer.LocalReport.EnableExternalImages = true;
            //ReportParameter parameter = new ReportParameter("ImagePath", imagePath);
            //ReportParameter[] param = new ReportParameter[1];
            //param[0] = parameter;
            //reportViewer.LocalReport.SetParameters(param);
            //reportViewer.RefreshReport();  

        }
    }
}
