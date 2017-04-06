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
    public partial class الجهات : Form
    {
        Connection con = new Connection();
        DataSet ds = new DataSet();
        Inpatientclaim y;
       
        cancelclaim y2;
        Cancelclaimsdelivery y3;
        Cancelnotices y4;
        Outpatientclaim y5;
        Medicineclaim y6;
        //Form6 y7;
        NoticedeleteoraddBillClaim y8;
        ClaimsPayment y9;
        ClaimsDelivery y10;
        public الجهات()
        {
            InitializeComponent();
        }
        public الجهات(Inpatientclaim x)
        {
            InitializeComponent();
            y = x;
        }
        
        
        public الجهات(cancelclaim x)
        {
            InitializeComponent();
            y2 = x;
        }

        public الجهات(Cancelclaimsdelivery x)
        {
            InitializeComponent();
            y3 = x;
        }
        public الجهات(Cancelnotices x)
        {
            InitializeComponent();
            y4 = x;
        }
        public الجهات(Outpatientclaim x)
        {
            InitializeComponent();
            y5 = x;
        }
        public الجهات(Medicineclaim x)
        {
            InitializeComponent();
            y6 = x;
        }
        //public Form9(Form6 x)
        //{
        //    InitializeComponent();
        //    y7 = x;
        //}
        public الجهات(NoticedeleteoraddBillClaim x)
        {
            InitializeComponent();
            y8 = x;
        }
        public الجهات(ClaimsPayment x)
        {
            InitializeComponent();
            y9 = x;
        }
        public الجهات(ClaimsDelivery x)
        {
            InitializeComponent();
            y10 = x;
        }
        private void Form9_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                con.OpenConection();

                con.DataReader("select_from_tb_contracting_Entites");
                dataGridView1.DataSource = con.ShowDataInGridView("select_from_tb_contracting_Entites");
                con.CloseConnection();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            con.CloseConnection(); 

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (y != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y.setV(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
           
            else if (y2 != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y2.setV(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
            else if (y3 != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y3.setV(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
            else if (y4 != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y4.setV(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
            else if (y5 != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y5.setV(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
            else if (y6 != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y6.setV(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
            //else if (y7 != null)
            //{
            //    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            //    y7.setV(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
            //    this.Close();
            //}
            else if (y8 != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y8.setV(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
            else if (y9 != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y9.setV(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
            else if (y10 != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y10.setV(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                con.OpenConection();
                //not find table [0]
                string[] pramname = new string[2];
                string[] pramvalue = new string[2];
                SqlDbType[] pramtype = new SqlDbType[2];
                pramname[0] = "@x1";
                pramname[1] = "@x2";

                pramvalue[0] = textBox1.Text;
                pramvalue[1] = textBox2.Text;

                pramtype[0] = SqlDbType.Int;
                pramtype[1] = SqlDbType.VarChar;
                object x = new object();
                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("select_tb_contracting_Entites", pramname, pramvalue, pramtype);
                //MessageBox.Show("");
                con.CloseConnection();
            }
            catch (Exception)
            {

                MessageBox.Show("من فضلك ادخل البيانات كاملة ");

            }
        }

        private void button2_Click(object sender, EventArgs e)
       
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                textBox1.Text = "";
                textBox2.Text = "";
            
                dataGridView1.DataSource = "";
            }
        
        }
    }
}
