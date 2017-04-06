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
    public partial class غرق_العلاج_الطبيعى : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataReader dr,dr1,dr2;
        DataTable dt=new DataTable();
        public غرق_العلاج_الطبيعى()
        {
            InitializeComponent();
        }

        private void غرق_العلاج_الطبيعى_Load(object sender, EventArgs e)
        {
            try
            {
                object x = new object();
                x = con.ShowDataInGridView("physiotherapy_physiotherapy_Rooms_select");
                dataGridView1.DataSource = (DataTable)x;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error");
            }
            //finally { con.CloseConnection(); }
            
            }

        private void button1_Click(object sender, EventArgs e)
        {   try
            {
                if (استقبال_العلاج_الطبيعي.ContainsArabicLetters(textBox2.Text) && استقبال_العلاج_الطبيعي.ContainsArabicLetters(textBox3.Text))
                {
                    con.OpenConection();
                    string[] pramname = new string[3];
                        string[] pramvalue = new string[3];
                        SqlDbType[] pramtype = new SqlDbType[3];
                        pramname[0] = "@Room_name";
                        pramname[1] = "@Room_place";
                        pramname[2] = "@Treatment_Duration_code";
                        pramvalue[0] = textBox2.Text;
                        pramvalue[1] = textBox3.Text;
                        pramvalue[2] = textBox1.Text;
                        pramtype[0] = SqlDbType.VarChar;
                        pramtype[1] = SqlDbType.VarChar;
                        pramtype[2] = SqlDbType.Int;
                        con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("physiotherapy_physiotherapy_Rooms_insert", pramname, pramvalue, pramtype);
                        object x = new object();
                        x = con.ShowDataInGridView("physiotherapy_physiotherapy_Rooms_select");
                        dataGridView1.DataSource = (DataTable)x; 
                }
                else {
                    MessageBox.Show("من فضلك ادخل البيانات المطلوبة باللغة العربة ");
                }
            
            }
            catch (Exception ex)
            {
                //if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
                //{
                    MessageBox.Show("من فضلك ادخل البيانات كاملة");
                //}
            }
            finally { con.CloseConnection(); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            عرض_فترات_العلاج_الطبيعى op = new عرض_فترات_العلاج_الطبيعى(this);
            op.Show();
        }
        public void SetDurationCode(String code)
        {

            textBox1.Text = code;        
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
                pramname[0] = "@Room_code";
                pramvalue[0] = x;
                pramtype[0] = SqlDbType.Int;
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("physiotherapy_physiotherapy_Rooms_delete", pramname, pramvalue, pramtype);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally{con.CloseConnection();}  
        }
    }
}