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
    public partial class سبب_الالغاء_المنظار1 : Form
    {
        public static string reason { get; set; }

        public سبب_الالغاء_المنظار1()
        {
            InitializeComponent();
        }


        private void سبب_الالغاء_Load(object sender, EventArgs e)
        {

            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();

            dataGridView1.Rows[0].Cells[1].Value = "بناء علي طلب المريض";
            dataGridView1.Rows[1].Cells[1].Value = "بناء علي طلب الطبيب";
            dataGridView1.Rows[2].Cells[1].Value = " خطأ";
            dataGridView1.Rows[3].Cells[1].Value = "خطأ كبير";
            dataGridView1.Rows[4].Cells[1].Value = "الغاء الدخول";


            dataGridView1.Rows[0].Cells[0].Value = "1";
            dataGridView1.Rows[1].Cells[0].Value = "2";
            dataGridView1.Rows[2].Cells[0].Value = "3";
            dataGridView1.Rows[3].Cells[0].Value = "4";
            dataGridView1.Rows[4].Cells[0].Value = "5";
            
        }

        private void cellclick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                reason = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                الغاء_زيارة_مريض_خارجى f = new الغاء_زيارة_مريض_خارجى();
                f.Focus();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        

        private void اضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Add();

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
