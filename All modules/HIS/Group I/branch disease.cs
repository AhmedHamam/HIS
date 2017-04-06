using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HIS
{
    public partial class branch_disease : Form
    {      Connection con=new Connection();
        //SqlConnection con = new SqlConnection(@"Data Source=HEBA-PC\SQLEXPRESS;AttachDbFilename=C:\Users\Esraa Ibrahim\HIS.mdf;Integrated Security=True;Connect Timeout=30");
       
        public branch_disease()
        {
            InitializeComponent();
        }
        public void display()
        {
            try
            {
                con.OpenConection();
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("diffservdid");
                con.CloseConnection();
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            
            try
            {
                con.OpenConection();
                string[] s = new string[] { "@id_branchd", "@arabic_name", "@english_name", "@describe"  };
                string[] s2 = new string[] { txtId.Text, txtArbName.Text, txtEngName.Text, txtDescribe.Text};
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int, SqlDbType.NVarChar, SqlDbType.NVarChar, SqlDbType.NVarChar };
                con.ShowDataInsertUsingStoredProc("DIFFSERV", s, s2, s3);
                display();
                txtId.Text = "";
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void branch_disease_Load(object sender, EventArgs e)
        {
            display();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtArbName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEngName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescribe_TextChanged(object sender, EventArgs e)
        {

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
                        string[] s = new string[] { "@id_branchd" };
                        string[] s2 = new string[] { dataGridView1.CurrentRow.Cells[0].Value.ToString() };
                        SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                        del = con.ShowDataInGridViewUsingStoredProc("delserv", s, s2, s3);
                        display();
                        con.CloseConnection();
           
                   
                    }
                    if (dia == DialogResult.No)
                    {
                        dia = DialogResult.Cancel;
                        //textBox1.Text = "";
                        //textBox1.Text = "";
                    }
                }
                 }

            catch (Exception g)
            {
                MessageBox.Show(g.Message);
            }
        }
    
        

        private void btn_exit_Click(object sender, EventArgs e)
        {

            //parent.Show();
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
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
                        string[] s = new string[] { "@id_branchd" };
                        string[] s2 = new string[] { dataGridView1.CurrentRow.Cells[0].Value.ToString() };
                        SqlDbType[] s3 = new SqlDbType[] { SqlDbType.Int };
                        del = con.ShowDataInGridViewUsingStoredProc("delserv", s, s2, s3);
                        display();
                   
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

        private void txtArbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)&&!char.IsSeparator(e.KeyChar))
            {
                MessageBox.Show("من فضلك ادخل حروف فقط");
                e.Handled = true;
            }
        }

        private void txtEngName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                MessageBox.Show("من فضلك ادخل حروف فقط");
                e.Handled = true;
            }
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar) )
            {
                MessageBox.Show("من فضلك ادخل ارقام فقط");
                e.Handled = true;
            }
        }

        private void txtDescribe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                MessageBox.Show("من فضلك ادخل حروف فقط");
                e.Handled = true;
            }
        }
    }
        }

       

    

