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
    public partial class الادرات_و_الاقسام : Form
    {
        SqlDataReader dr;
        
        DataTable dt = new DataTable();
        Connection con1 = new Connection();
        DataSet ds = new DataSet();
        public static string Code { get; set; }
        public static string Arab { get; set; }
        public الادرات_و_الاقسام()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            /*create procedure clinic_الادرات_و_الاقسام_dept_select
                as
                begin
                select code as'الكود', arabic_des as 'الاسم العربى', latini_des as 'الاسم اللاتينى',level as 'مستوى الادارة' from dept
                end
             * 
             */
            //con.Open();
            //cmd.Connection = con;
            //cmd.CommandText = "select code as'الكود', arabic_des as 'الاسم العربى', latini_des as 'الاسم اللاتينى',level as 'مستوى الادارة' from dept";
            //dr = cmd.ExecuteReader();
            //dt.Load(dr);
            //dataGridView1.DataSource = dt;
            //dr.Close();
            //con.Close();
            con1.OpenConection();
           dr=con1.DataReader("clinic_الادرات_و_الاقسام_dept_select");
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            con1.CloseConnection();
            //dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Red;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            اضافه_عياده f2 = new اضافه_عياده();
            f2.Focus();
            this.DialogResult = DialogResult.OK;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Code = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Arab = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        

        
        
        
    }
}
