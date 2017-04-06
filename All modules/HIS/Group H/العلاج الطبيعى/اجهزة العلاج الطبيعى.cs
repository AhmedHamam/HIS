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
    public partial class اجهزة_العلاج_الطبيعى : Form
    {
        Connection con = new Connection();
        SqlCommand cmd,cmd1;
        SqlDataReader dr, dr1, dr2,dr3;
        DataTable dt=new DataTable();
        public اجهزة_العلاج_الطبيعى()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                dt.Clear();

                if (استقبال_العلاج_الطبيعي.ContainsArabicLetters(AR_N.Text))
                {
                    string[] pramname = new string[3];
                    string[] pramvalue = new string[3];
                    SqlDbType[] pramtype = new SqlDbType[3];
                    pramname[0] = "@Arabic_name";
                    pramname[1] = "@English_name";
                    pramname[2] = "@Room_code";
                    pramvalue[0] = AR_N.Text;
                    pramvalue[1] = EN_N.Text;
                    pramvalue[2] = Room_code.Text;
                    pramtype[0] = SqlDbType.VarChar;
                    pramtype[1] = SqlDbType.VarChar;
                    pramtype[2] = SqlDbType.Int;
                    con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("physiotherapy_physiotherapy_Devices_insert", pramname, pramvalue, pramtype);
                    object x = new object();
                    x = con.ShowDataInGridView("physiotherapy_physiotherapy_Devices_select");
                    dataGridView1.DataSource = (DataTable)x;
           
                }
                else
                { MessageBox.Show("من فضلك ادخل اسم الجهاز باللغة العربية"); }
          
                }
            catch (Exception ex)
            {
                if (AR_N.Text.Equals("") || EN_N.Text.Equals("") || Room_code.Text.Equals(""))
                    MessageBox.Show("من فضلك ادخل البيانات كاملة");
                else
                    MessageBox.Show("خطأ فى النظام ");
            }
            finally { con.CloseConnection(); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            عرض_غرف_العلاج_الطبيعى op = new عرض_غرف_العلاج_الطبيعى(this);
            op.Show();
        }
        public void SetRoomCode(String z)
        {
            Room_code.Text = z;
        }

        private void اجهزة_العلاج_الطبيعى_Load(object sender, EventArgs e)
        {
            try {
                object x = new object();
                x = con.ShowDataInGridView("physiotherapy_physiotherapy_Devices_select");
                dataGridView1.DataSource = (DataTable)x;
            }
            catch (Exception ex) { MessageBox.Show("Error"); }

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

                con.OpenConection();
                string[] pramname = new string[1];
                string[] pramvalue = new string[1];
                SqlDbType[] pramtype = new SqlDbType[1];
                pramname[0] = "@Device_code";
                pramvalue[0] = x;
                pramtype[0] = SqlDbType.Int;
                con.ExecuteInsertOrUpdateOrDeleteUsingStoredProc("physiotherapy_physiotherapy_Devices_delete", pramname, pramvalue, pramtype);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        
    }
}
