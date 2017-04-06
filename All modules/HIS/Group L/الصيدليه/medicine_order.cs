using HIS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HIS
{
    public partial class medicine_order : Form
    {
        string med_id = "";
        public medicine_order()
        {
            InitializeComponent();
        }

        private void medicine_order_Load(object sender, EventArgs e)
        {

        }

        private void اضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {
                  Regex r = new Regex("^[0-9]");
                  int q = int.Parse(textBox1.Text);
                  if (r.Match(textBox1.Text).Success == true)
                  {
                      if (med_id != string.Empty)
                      {
                          Connection con = new Connection();
                          con.OpenConection();
                          DateTime date, date1;
                          date = dateTimePicker1.Value;
                          date1 = dateTimePicker2.Value;
                          con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("pharamacy_insert_into_medicine_oredr", new string[] { "@med_id","@order_date", "@med_quantity", "@order_need_date " }, new string[] { med_id.ToString(),date.ToString(), q.ToString(), date1.ToString() }, new SqlDbType[] {SqlDbType.Int,  SqlDbType.Date, SqlDbType.Int, SqlDbType.Date });

                      }

                      else

                          MessageBox.Show("من فضلك اختر طلب علي الاقل");
                  }
                  else
                  {
                      MessageBox.Show("يجب ادخال الكميه بالارقام");
                  }
    
    }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            med_id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        

                Connection conn = new Connection();
                conn.OpenConection();
                dataGridView1.DataSource = (DataTable)conn.ShowDataInGridViewUsingStoredProc("pharamacy_ph_ALL_med_credit");

           
           
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
            
        }
    
        }

