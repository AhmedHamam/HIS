using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIS
{
    public partial class shifts : Form
    {  
        Connection con=new Connection();
        
        public shifts()
        {
           
            InitializeComponent();
        }
             public void display()
        {

            try
            {
                con.OpenConection();
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("viewshift");
                con.CloseConnection();
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }

            
      
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            //parent.Show();
            this.Close();
        }

        private void shifts_Load(object sender, EventArgs e)
        {
            display();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                string[] s = new string[] { "@id","@aname","ename","stime","etime" };
                string[] s2 = new string[] { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.Time, SqlDbType.Time };
                con.ShowDataInsertUsingStoredProc("insertshift", s, s2, s3);
                display();
                textBox1.Text = "";
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                if (dataGridView1.CurrentCell.RowIndex >= 0)
                {
                    DialogResult dia = MessageBox.Show("هل انت متاكد من الحذف", "تنبيه", MessageBoxButtons.YesNo);
                    if (dia == DialogResult.Yes)
                    {
                        object del = new Object();
                        string[] s = new string[] { "@id" };
                        string[] s2 = new string[] { dataGridView1.CurrentRow.Cells[0].Value.ToString() };
                        SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                        del = con.ShowDataInGridViewUsingStoredProc("delshift", s, s2, s3);
                        display();
                        //textBox1.Text = "";
                        //textBox1.Text = "";
                    }
                    if (dia == DialogResult.No)
                    {
                        dia = DialogResult.Cancel;
                        //textBox1.Text = "";
                        //textBox1.Text = "";
                    }
                }
                con.CloseConnection();
            }

            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                MessageBox.Show("من فضلك ادخل ارقام فقط");
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                MessageBox.Show("من فضلك ادخل حروف فقط");
                e.Handled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                MessageBox.Show("من فضلك ادخل حروف فقط");
                e.Handled = true;
            }
        }
    }
}
