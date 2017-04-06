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
    public partial class استقبال_طلبات_عمليات_قسطرة_القلب : Form
    {


        Connection con = new Connection();
        public استقبال_طلبات_عمليات_قسطرة_القلب()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                con.OpenConection();
                string[] parmnames = { "p_number","@states","@CSdate","@approvalDate","@roomNumber","@notes" };
                string[] parmvalues = { patient_id.Text,comboBox1.Text,textBox4.Text, dateTimePicker3.Text,textBox1.Text,"" };
                SqlDbType[] paradbtype = { SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.VarChar };

                con.ShowDataInsertUsingStoredProc("insertHeartcatheterSurgery", parmnames, parmvalues, paradbtype);
                con.CloseConnection();
                con.OpenConection();
                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("[selecteheartCatheterSurgery]");
                con.CloseConnection();
                clear.Clear(this);
            }
            catch (Exception ex)
            {

                MessageBox.Show("ادخل البيانات كاملة");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void استقبال_طلبات_عمليات_قسطرة_القلب_Load(object sender, EventArgs e)
        {

           
           
        
            textBox4.Text = DateTime.Now.ToString(); 
            try{
                
                con.OpenConection();
                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("[selecteheartCatheterSurgery]");
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.CloseConnection();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           }

        private void button1_Click(object sender, EventArgs e)
        {

            string code = this.patient_id.Text;
            string name = this.patient.Text;
            pop frm = new pop();
            frm.showdidi(ref code, ref name, "SELECT patient_id as 'كود المريض',patient_name as 'اسم المريض' FROM Registeration_patientRegisteration;", "المرضي");
            this.patient.Text = name;
            this.patient_id.Text = code;
            
        }

        private void patient_id_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void patient_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.integer(sender, e, this);
        }

        private void patient_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.integer(sender, e, this);
        }
    }
}
