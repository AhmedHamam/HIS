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
    public partial class مواعيد_فحوصات_القلب : Form
    {
        Connection con = new Connection();
  
      
        public مواعيد_فحوصات_القلب()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            con.OpenConection();
            string[] parmnames = { "@p_number" };
            string[] parmvalues = { textBox3.Text };
            SqlDbType[] paradbtype = { SqlDbType.Int };

            con.ShowDataInsertUsingStoredProc("selecteheartExaminationOrderByPatient", parmnames, parmvalues, paradbtype);
            con.CloseConnection();

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           

            try
            {
                DialogResult result = MessageBox.Show("هل انت متأكد من الحذف؟", "حذف", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == result)
                {
                    con.OpenConection();
                    string[] parmnames = { "@orderID" };
                    string[] parmvalues = { this.dataGridView2.CurrentRow.Cells[0].Value.ToString() };
                    SqlDbType[] paradbtype = { SqlDbType.Int };

                    con.ShowDataInsertUsingStoredProc("deleteteheartExaminationOrder", parmnames, parmvalues, paradbtype);
                    con.CloseConnection();
                    con.OpenConection();
                    dataGridView2.DataSource = con.ShowDataInGridViewUsingStoredProc("[selectalleheartExaminationOrder]");
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
        private void مواعيد_فحوصات_القلب_Load(object sender, EventArgs e)
        {
            
            con.OpenConection();
            dataGridView2.DataSource = con.ShowDataInGridViewUsingStoredProc("[selectalleheartExaminationOrder]");
            con.CloseConnection();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.integer(sender, e, this);
        }
    }
}
