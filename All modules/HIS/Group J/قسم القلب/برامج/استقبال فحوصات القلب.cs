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
    public partial class استقبال_فحوصات_القلب : Form
    {
        Connection con = new Connection();

      
        public استقبال_فحوصات_القلب()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void استقبال_فحوصات_القلب_Load(object sender, EventArgs e)
        {
           
            con.OpenConection();
            dataGridView2.DataSource = con.ShowDataInGridViewUsingStoredProc("[selectalleheartExaminationOrder]");
            con.CloseConnection();
            clear.Clear(this);

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
       

            bool agree;
            try
            {
                con.OpenConection();
                if (checkBox1.Checked == true)
                {
                    agree = true;
                }
                else { agree = false; }
                string[] parmnames = { "@p_number","@id","@openingFileDate","@approvalstate" };
                string[] parmvalues = { textBox6.Text, textBox3.Text, dateTimePicker1.Text, agree.ToString() };
                SqlDbType[] paradbtype = { SqlDbType.Int, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Bit };

                con.ShowDataInsertUsingStoredProc("[insertHeartExaminationOrder]", parmnames, parmvalues, paradbtype);
                con.CloseConnection();
                con.OpenConection();
                dataGridView2.DataSource = con.ShowDataInGridViewUsingStoredProc("[selectalleheartExaminationOrder]");
                con.CloseConnection();
                clear.Clear(this);
            }
            catch (Exception ex)
            {

                MessageBox.Show("ادخل البيانات كاملة");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string code = this.textBox6.Text;
            string name = this.textBox1.Text;
            pop frm = new pop();
            frm.showdidi(ref code, ref name, "SELECT patient_id as 'كود المريض',patient_name as 'اسم المريض' FROM Registeration_patientRegisteration;", "المرضي");
            this.textBox1.Text = name;
            this.textBox6.Text = code;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = this.textBox3.Text;
            string name = this.textBox4.Text;
            pop frm = new pop();
            frm.showdidi(ref code, ref name, "SELECT doc_ssn as 'كود الطبيب',full_name as 'اسم الطبيب' FROM Doctors;", "الأطباء");
            this.textBox4.Text = name;
            this.textBox3.Text = code;
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.integer(sender, e, this);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validate.integer(sender, e, this);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
        }
    }
}
