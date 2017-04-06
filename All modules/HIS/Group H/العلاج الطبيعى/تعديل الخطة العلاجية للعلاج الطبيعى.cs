using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HIS
{
    public partial class تعديل_الخطة_العلاجية_للعلاج_الطبيعى : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        public تعديل_الخطة_العلاجية_للعلاج_الطبيعى()
        {
            InitializeComponent();
        }

        private void تعديل_الخطة_العلاجية_للعلاج_الطبيعى_Load(object sender, EventArgs e)
        {
            try
            {
              
                object x = new object();
                x = con.ShowDataInGridView("physiotherapy_plan_edit_select");
                dataGridView1.DataSource = (DataTable)x;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //finally { con.CloseConnection(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        try
        {
            if (!textBox1.Text.Equals(""))
            {
                
                    dt.Clear();
                    con.OpenConection();
                    string[] pramname = new string[1];
                    string[] pramvalue = new string[1];
                    SqlDbType[] pramtype = new SqlDbType[1];
                    pramname[0] = "@patient_name";
                    pramvalue[0] = textBox1.Text;
                    pramtype[0] = SqlDbType.VarChar;
                    dataGridView1.DataSource=con.ShowDataInGridViewUsingStoredProc("physiotherapy_plan_edit_select2", pramname, pramvalue, pramtype);
                }
            else if(!textBox2.Text.Equals(""))
            {
                //dt.Clear();
                //con.OpenConection();
                //int emp_code = int.Parse(textBox2.Text);
                //cmd = new SqlCommand("select physiotherapy_patient_code as 'رقم الطلب',patient_name as 'اسم المريض',name as 'الطبيب الطالب',patient_case as 'حالة المريض',Entering_Date 'تاريخ الطلب'  from Registeration_patientRegisteration,physiotherapy_Reception,Employe,physiotherapy_Employee where Registeration_patientRegisteration.patient_id=physiotherapy_Reception.patient_id AND Employe.emp_id=physiotherapy_Employee.emp_id AND physiotherapy_Employee.physiotherapy_Employee_code=physiotherapy_Reception.physiotherapy_Employee_code AND physiotherapy_Employee.physiotherapy_Employee_code="+emp_code, con.returnObject());
                //dr = cmd.ExecuteReader();
                //dt.Load(dr);
                //dataGridView1.DataSource = dt;
                dt.Clear();
                con.OpenConection();


                string[] pramname = new string[1];
                string[] pramvalue = new string[1];
                SqlDbType[] pramtype = new SqlDbType[1];
                pramname[0] = "@doc_ssn";
                pramvalue[0] = textBox2.Text;
                pramtype[0] = SqlDbType.VarChar;
                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("physiotherapy_plan_edit_select3", pramname, pramvalue, pramtype);
           


            }
            
           else
                {
                    MessageBox.Show("Error");
                }
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally { con.CloseConnection(); }
            }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            عرض_موظفى_العلاج_الطبيعي op=new عرض_موظفى_العلاج_الطبيعي(this);
            op.Show();
        }
        public void SetDoctor(String x,String y)
        {
            textBox2.Text = x;
            textBox3.Text = y;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String patient_name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String emp_name=dataGridView1.CurrentRow.Cells[2].Value.ToString();

            عمل_خطة_علاجية_لمريض op = new عمل_خطة_علاجية_لمريض();
            op.textBox1.Text = patient_name;
            op.textBox2.Text = emp_name;
            try
            {
                con.OpenConection();
                cmd = new SqlCommand("select doctors.doc_ssn from doctors,physiotherapy_Reception where doctors.doc_ssn=physiotherapy_Reception.physiotherapy_Employee_code AND doctors.full_name='" + emp_name + "'", con.returnObject());
                String x = cmd.ExecuteScalar().ToString();
                int emp_code = int.Parse(x);
            op.phys_emp_code=emp_code;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message);}
            finally { con.CloseConnection(); }
                op.phys_pat_code =int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()); ;
            op.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

    
    }
}