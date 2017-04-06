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
    public partial class نوع_الحالة : Form
    {
        public static string Des { get; set; }
        public static int Code { get; set; }
       
        public نوع_الحالة()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[1].Value = "اولى ممتاز";
            dataGridView1.Rows[1].Cells[1].Value = "ثانية ممتاز";
            dataGridView1.Rows[0].Cells[0].Value = "1";
            dataGridView1.Rows[1].Cells[0].Value = "2";
            dataGridView1.Rows[0].Cells[2].Value = "اولي ممتاز";
            dataGridView1.Rows[1].Cells[2].Value = "ثانية ممتاز";

        }

        private void cell_doubleclick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Des = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Code = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

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
