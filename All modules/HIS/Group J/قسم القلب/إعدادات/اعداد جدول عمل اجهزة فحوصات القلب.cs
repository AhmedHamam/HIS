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
    public partial class اعداد_جدول_عمل_اجهزة_فحوصات_القلب : Form
    {
     //   SqlConnection con1 = new SqlConnection(@"Server=(local);Database=HIS_Group_J; Integrated Security=true");
        Connection con = new Connection();
        string s;
        public اعداد_جدول_عمل_اجهزة_فحوصات_القلب()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                con.OpenConection();
                string[] parmnames = { "@states", "@deviceID", "@types", "@startTime", "@endTime", "@startDate", "@endDate" };
                string[] parmvalues = { "", deviceText.Text, comboBox1.Text, textBox2.Text, textBox4.Text, dateTimePicker3.Text,dateTimePicker4.Text };
                SqlDbType[] paradbtype = { SqlDbType.VarChar, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.Time, SqlDbType.Time,  SqlDbType.VarChar, SqlDbType.VarChar};

                con.ShowDataInsertUsingStoredProc("insertHeatrExaminationScheduale", parmnames, parmvalues, paradbtype);
                con.CloseConnection();
                con.OpenConection();
                dataGridView2.DataSource = con.ShowDataInGridViewUsingStoredProc("[selectalleheartExaminationSchedual]");
                con.CloseConnection();
                clear.Clear(this);
            }
            catch (Exception ex)
            {

                MessageBox.Show("ادخل البيانات كاملة");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void اعداد_جدول_عمل_اجهزة_فحوصات_القلب_Load(object sender, EventArgs e)
        {

            con.OpenConection();
            dataGridView2.DataSource = con.ShowDataInGridViewUsingStoredProc("[selectalleheartExaminationSchedual]");
            con.CloseConnection();

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("هل انت متأكد من الحذف؟", "حذف", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == result)
                {
                    con.OpenConection();
                    string[] parmnames = { "@sechedualID" };
                    string[] parmvalues = { this.dataGridView2.CurrentRow.Cells[0].Value.ToString() };
                    SqlDbType[] paradbtype = { SqlDbType.Int };

                    con.ShowDataInsertUsingStoredProc("[deleteHeatrExaminationScheduale]", parmnames, parmvalues, paradbtype);
                    con.CloseConnection();
                    con.OpenConection();
                    dataGridView2.DataSource = con.ShowDataInGridViewUsingStoredProc("[selectalleheartExaminationSchedual]");
                    con.CloseConnection();
                    MessageBox.Show("تم الحذف");
                    clear.Clear(this);
                }
                else
                {
                    con.CloseConnection();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("لم يتم الحذف! ");
            }

        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = this.deviceText.Text;
            
            pop frm = new pop();
            frm.showdi(ref code, "SELECT * FROM heartExaminationDvices;", "الأجهزة");
            
            this.deviceText.Text = code;
        }
        private void deviceText_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
       
           
        
    }
}
