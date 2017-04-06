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

    public partial class اجهزة_فحوصات_القلب : Form
    {
      
        Connection con = new Connection();

        public اجهزة_فحوصات_القلب()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            


            try
            {
                con.OpenConection();
                string[] parmnames = { "@arabicDescribtion", "@latinDescribtion" ,  "@disciplines", "@roomNumber" , "@deviceType","@devicesID" ,"@film" ,"@expectedTime" ,"@deviceState " };
                string[] parmvalues = {  textBox2.Text  ,textBox3.Text , textBox4.Text,textBox9.Text, textBox8.Text , textBox6.Text,"","","" };
                SqlDbType[] paradbtype = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, };

                con.ShowDataInsertUsingStoredProc("insertHeartExaminationDevices", parmnames, parmvalues, paradbtype);
                con.CloseConnection();
                con.OpenConection();
                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("[selecteheartExaminationDevicesFormLoad]");
                con.CloseConnection();
                clear.Clear(this);
            }
            catch (Exception ex)
            {

                MessageBox.Show("ادخل البيانات كاملة");
            }
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("هل انت متأكد من الحذف؟", "حذف", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == result)
                {
                    con.OpenConection();
                    string[] parmnames = { "@deviceID" };
                    string[] parmvalues = { this.dataGridView1.CurrentRow.Cells[0].Value.ToString() };
                    SqlDbType[] paradbtype = { SqlDbType.Int };

                    con.ShowDataInsertUsingStoredProc("deleteHeartExaminationDevices", parmnames, parmvalues, paradbtype);
                    con.CloseConnection();
                    con.OpenConection();
                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("selecteheartExaminationDevicesFormLoad");
                    con.CloseConnection();
                    MessageBox.Show("تم الحذف");
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

        private void Form3_Load(object sender, EventArgs e)
        {
            
            con.OpenConection();
            dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("[selecteheartExaminationDevicesFormLoad]");
            con.CloseConnection();
        }


        public void dataGridView1_Click(object sender, DataGridViewCellEventArgs e)
        {


        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            اجهزة_فحوصات_القلب frm = new اجهزة_فحوصات_القلب();

            frm.dataGridView1.Visible = false;


            
            frm.dataGridView1.Visible = false;


            this.textBox2.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.textBox3.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.textBox4.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();

            this.textBox9.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            this.textBox8.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();


        }




        private void button4_Click(object sender, EventArgs e)
        {

            
            string name = this.textBox6.Text;
            pop frm = new pop();
            frm.showdi(ref name, "SELECT code as 'الكود',arabic_name as ' الاسم العربي',latin_name as 'الاسم اللاتينى' FROM asset", "الأصول");
            this.textBox6.Text = name;
            
            

           
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.integer(sender, e, this);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
        }

     
        

    }
}
