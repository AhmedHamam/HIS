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
    public partial class االغاء_تسجيل_مريض : Form
    {
        Connection con = new Connection();
      

        public االغاء_تسجيل_مريض()
        {
            InitializeComponent();
        }
     

        private void االغاء_تسجيل_مريض_Load(object sender, EventArgs e)
        {
            
            con.OpenConection();

        }


        public void setValue1(int id, String name) {

            textBox11.Text = id.ToString();
            textBox7.Text = name;
            
        }
    
       
        private void button3_Click(object sender, EventArgs e)
        {
            
           الجهات11 d = new الجهات11(this);
            d.Show();
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try{
            dataGridView1.DataSource = null;
            //ds.Tables.Clear();
            dataGridView1.Refresh();
            dataGridView1.Rows.Clear();
         

            if (textBox3.Text.Length != 0 )
            {

                MessageBox.Show("1");
                try
                {


                     string[] s = new string[] {"@x1"};
                     string[] s2 = new string[] { textBox3.Text };
                         SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar};
                         dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("selectdata101213", s, s2, s3);
                }
                catch(Exception ex){MessageBox.Show(ex.ToString());}

               
            }
            else if(textBox10.Text.Length !=0){ 
               MessageBox.Show("2");


                string[] s = new string[] { "@x2"};
                string[] s2 = new string[] { textBox10.Text };
                SqlDbType[] s3 = new SqlDbType[] {SqlDbType.VarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("selectdatt", s, s2, s3);  
            }
            else if(textBox1.Text.Length !=0){
                MessageBox.Show("3");
                string[] s = new string[] { "@x1" };
                string[] s2 = new string[] { textBox1.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("selectdattt", s, s2, s3);
     

            }          
            else if (textBox11.Text.Length != 0)
            {
                MessageBox.Show("4");
                string[] s = new string[] { "@x1" };
                string[] s2 = new string[] { textBox11.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.VarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("select_patient_data", s, s2, s3);
               

            }

            }
            catch(Exception ex){MessageBox.Show(ex.Message);}
          
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.Rows.Clear();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
          try{
                foreach (DataGridViewCell Cell in dataGridView1.SelectedCells)
                {
                    if (Cell.Selected)
                    {


                        string[] pName = { "@x" };

                        string[] Pvalues = { dataGridView1.Rows[Cell.RowIndex].Cells[0].Value.ToString() };
                        
                        SqlDbType[] Ptype = { SqlDbType.VarChar };

                        con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("delete_patient_from_canel", pName, Pvalues, Ptype);

                        dataGridView1.Rows.RemoveAt(Cell.RowIndex);
                    }
                }
                MessageBox.Show("deleted");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void اضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {
          



        }

        private void button4_Click(object sender, EventArgs e)
        {
            فئة_المريض c = new فئة_المريض(this);
            c.Show();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("patient_cancel4");

      

        }

        private void fill(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {

                string c = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                int y = int.Parse(c);
                textBox11.Text = y.ToString();
                string d = this.dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox7.Text = d.ToString();
                string t = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                int w = int.Parse(t);
                //textBox8.Text = w.ToString();
                string q = this.dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                //textBox9.Text = q.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int x;
            if (!int.TryParse(textBox1.Text, out x))
            {


                MessageBox.Show("قم بادخال رقم ");
                textBox1.Text = null;
                return;
            }


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
            int x;
            if(int.TryParse(textBox3.Text,out x))
            {


                MessageBox.Show("قم بادخال اسم ");
                textBox3.Text = null;
                return;
                

            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
           
           
            
        }

       
    }
}
