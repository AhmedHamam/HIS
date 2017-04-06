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
    public partial class فترات_العلاج_الطبيعى : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        DataTable dt=new DataTable();
        SqlDataReader dr;
        public فترات_العلاج_الطبيعى()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
         //   bool x = true;
            try
            {
                if(استقبال_العلاج_الطبيعي.ContainsArabicLetters(textBox1.Text))
                {
              
                while (true)
                {
                    con.OpenConection();
                    decimal y = 0;
                    if (numericUpDown1.Value == y || numericUpDown2.Value == y)
                    {
                        MessageBox.Show("من فضلك حدد بداية ونهاية الفترة"); break; //x = false;} 
                    }
                    else
                    {
                        string[] pramname = new string[3];
                        string[] pramvalue = new string[3];
                        SqlDbType[] pramtype = new SqlDbType[3];
                        pramname[0] = "@Duration_name";
                        pramname[1] = "@Duration_satrt";
                        pramname[2] = "@Duration_end";
                        pramvalue[0] = textBox1.Text;
                        pramvalue[1] = numericUpDown1.Value.ToString();
                        pramvalue[2] = numericUpDown2.Value.ToString();
                        pramtype[0] = SqlDbType.VarChar;
                        pramtype[1] = SqlDbType.VarChar;
                        pramtype[2] = SqlDbType.VarChar;
                   con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("physiotherapy_physiotherapy_Treatment_Duration_insert", pramname, pramvalue, pramtype);
                 object x = new object();
                 x = con.ShowDataInGridView("physiotherapy_physiotherapy_Treatment_Duration_select");
                 dataGridView1.DataSource = (DataTable)x; ;
                        break;
                    }
                }
                }
                else 
                {MessageBox.Show("من ضلك ادخل اسم الفترة باللغة العربية");}
            }
            catch (Exception ex)
            { MessageBox.Show("Error"); }
            finally { con.CloseConnection(); }
        }

        private void فترات_العلاج_الطبيعى_Load(object sender, EventArgs e)
        {
            object x = new object();
           x=con.ShowDataInGridView("physiotherapy_physiotherapy_Treatment_Duration_select");
        dataGridView1.DataSource = (DataTable)x;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String x = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
                {

                   if (cell.Selected)
                    {
                        dataGridView1.Rows.RemoveAt(cell.RowIndex);
                    }
                }
                con.OpenConection();
                string[] pramname = new string[1];
                string[] pramvalue = new string[1];
                SqlDbType[] pramtype = new SqlDbType[1];
                pramname[0] = "@Treatment_Duration_code";
                pramvalue[0] = x;
                pramtype[0] = SqlDbType.Int;
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("physiotherapy_physiotherapy_Treatment_Duration_delete", pramname, pramvalue, pramtype);
               
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }
        }

   
    }
}