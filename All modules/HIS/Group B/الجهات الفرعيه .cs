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
    public partial class الجهاتالفرعيه : Form
    {
        Connection con = new Connection();
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
        public الجهاتالفرعيه()
        {
            InitializeComponent();  
        }
        public الجهاتالفرعيه(Inpatientclaim x)
        {
            InitializeComponent();
            y = x;
        }
        
        public الجهاتالفرعيه(cancelclaim x)
        {
            InitializeComponent();
            y2 = x;
        }
        public الجهاتالفرعيه(Cancelclaimsdelivery x)
        {
            InitializeComponent();
            y3 = x;
        }
        public الجهاتالفرعيه(Cancelnotices x)
        {
            InitializeComponent();
            y4 = x;
        }
        public الجهاتالفرعيه(Outpatientclaim x)
        {
            InitializeComponent();
            y5 = x;
        }
        public الجهاتالفرعيه(Medicineclaim x)
        {
            InitializeComponent();
            y6 = x;
        }
     
        public الجهاتالفرعيه(NoticedeleteoraddBillClaim x)
        {
            InitializeComponent();
            y8 = x;
        }
        public الجهاتالفرعيه(ClaimsPayment x)
        {
            InitializeComponent();
            y9 = x;
        }
        public الجهاتالفرعيه(ClaimsDelivery x)
        {
            InitializeComponent();
            y10 = x;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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

        private void Form17_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                con.OpenConection();

                con.DataReader("select_from_tb_Entites_Branches");
                dataGridView1.DataSource = con.ShowDataInGridView("select_from_tb_Entites_Branches");
                con.CloseConnection();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            con.CloseConnection(); 

            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (y != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y.setValue(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
           
            else if (y2 != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y2.setValue(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
            else if (y3 != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y3.setValue(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
            else if (y4 != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y4.setValue(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
            else if (y5 != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y5.setValue(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
            else if (y6 != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y6.setValue(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
            //else if (y7 != null)
            //{
              //  DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                //y7.setValue(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                //this.Close();
           // }
            else if (y8 != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y8.setValue(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
            else if (y9 != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y9.setValue(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
                this.Close();
            }
            else if (y10 != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                y10.setValue(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString());
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
                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("select_tb_Entites_Branches", pramname, pramvalue, pramtype);
                   
                    con.CloseConnection();

                

            }
            catch (Exception)
            {

                MessageBox.Show("من فضلك ادخل البيانات كاملة ");

            }
          
            
              
        }
    }
}

