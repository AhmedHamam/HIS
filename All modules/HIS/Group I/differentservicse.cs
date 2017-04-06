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
    public partial class differentservicse : Form
    {
        Connection con = new Connection();
       
        
        public differentservicse()
        {
            

            InitializeComponent();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            con.OpenConection();
            if (radioButton3.Checked == true)
            {
                dataGridView2.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("diffserv1");
            }
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                dataGridView2.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("diffsevc2");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                string[] s = new string[] { "@name" };
                string[] s2 = new string[] { dataGridView2.CurrentRow.Cells[0].Value.ToString() };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("diffservseces2", s, s2, s3);
            }
            else 
            {
                string[] s = new string[] { "@name" };
                string[] s2 = new string[] { dataGridView2.CurrentRow.Cells[0].Value.ToString() };
                SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
                dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("diffservse", s, s2, s3);
            }

        }

        private void differentservicse_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //try {
            //    con.OpenConection();
            //    if (textBox1.Text != "" && textBox16.Text == "")
            //    {
            //        string[] s = new string[] { "@pname" };
            //        string[] s2 = new string[] { textBox1.Text };
            //        SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
            //        dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("serchbynameemp", s, s2, s3);
            //    }
            //    else if (textBox1.Text == "" && textBox16.Text != "")
            //    {
            //        string[] s = new string[] { "@id" };
            //        string[] s2 = new string[] { textBox16.Text };
            //        SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar };
            //        dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("searchbyidemp", s, s2, s3);
            //    }
            //    else if (textBox1.Text != "" && textBox16.Text != "")
            //    {
            //        string[] s = new string[] {"@id","@name"};
            //        string[] s2 = new string[] {textBox16.Text, textBox1.Text};
            //        SqlDbType[] s3 = new SqlDbType[] { SqlDbType.NVarChar, SqlDbType.NVarChar };
            //        dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("searchbyidnameemp", s, s2, s3);
            //        if (dataGridView1.RowCount == 1)
            //        {
            //            MessageBox.Show("هذا الكود غير متفق مع الاسم ");
            //        }
        }

    }
}

        
