using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS
{
    public partial class نتيجة_الزيارة : Form
    {
        int code;


        public static string Des { get; set; }
        public static int Code { get; set; }
        

        public نتيجة_الزيارة()
        {
            InitializeComponent();
        }

        private void نتيجة_الزيارة_Load(object sender, EventArgs e)
        {
             
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();

            dataGridView1.Rows[0].Cells[1].Value = "الشفاء";
            dataGridView1.Rows[1].Cells[1].Value = "الوفاة";
            dataGridView1.Rows[2].Cells[1].Value = "تحويل الي مستشفي اخر";
            dataGridView1.Rows[3].Cells[1].Value = "تحويل للداخلي";
            dataGridView1.Rows[4].Cells[1].Value = "بناء علي طلب المريض";


            dataGridView1.Rows[0].Cells[0].Value = "1";
            dataGridView1.Rows[1].Cells[0].Value = "2";
            dataGridView1.Rows[2].Cells[0].Value = "3";
            dataGridView1.Rows[3].Cells[0].Value = "4";
            dataGridView1.Rows[4].Cells[0].Value = "5";
             
        }

        private void Data_Double_Click(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Des = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Code = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
               // MessageBox.Show(Des.ToString());
                //MessageBox.Show(Code.ToString());

                انهاء_زيارة_مريض_خارجى ff = new انهاء_زيارة_مريض_خارجى();
               ff.Focus();
               this.DialogResult = DialogResult.OK;
        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " dfff");
            }

        }

        

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
       
        

      
    }
}
