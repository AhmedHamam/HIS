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
    public partial class طلب_فحوصات_القلب : Form
    {

        Connection con = new Connection();

      
        public طلب_فحوصات_القلب()
        {
            InitializeComponent();
        }

        private void طلب_فحوصات_القلب_Load(object sender, EventArgs e)
        {
        
            con.OpenConection();
            dataGridView2.DataSource = con.ShowDataInGridViewUsingStoredProc("[selectalleheartExaminationOrder]");
            con.CloseConnection();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            con.OpenConection();
            string[] parmnames = { "@p_number" };
            string[] parmvalues = { textBox2.Text};
            SqlDbType[] paradbtype = { SqlDbType.Int };

            con.ShowDataInsertUsingStoredProc("selecteheartExaminationOrderByPatient", parmnames, parmvalues, paradbtype);
            con.CloseConnection();
            clear.Clear(this);

        }

        private void button2_Click(object sender, EventArgs e)
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
                    dataGridView2.DataSource = con.ShowDataInGridViewUsingStoredProc("selectalleheartExaminationOrder");
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

            textBox3.Text = dataGridView2.RowCount.ToString();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string code = this.textBox1.Text;
            string name = this.textBox2.Text;
            pop frm = new pop();
            frm.showdidi(ref code, ref name, "SELECT patient_id as 'كود المريض',patient_name as 'اسم المريض' FROM Registeration_patientRegisteration;", "المرضي");
            this.textBox2.Text = name;
            this.textBox1.Text = code;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.integer(sender, e, this);
        }
    }
}
