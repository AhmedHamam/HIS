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
    public partial class مكان_الملف : Form
    {
        public static string Des { get; set; }
        public static int Code { get; set; }
       

        public مكان_الملف()
        {
            InitializeComponent();
        }

        private void مكان_الملف_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();

            dataGridView1.Rows[0].Cells[1].Value = "بالحفاظ";
            dataGridView1.Rows[1].Cells[1].Value = "منتظرين بالحفظ";
            dataGridView1.Rows[2].Cells[1].Value = "بالعيادات الخارجية";
            dataGridView1.Rows[3].Cells[1].Value = "بالعمليات";
            dataGridView1.Rows[4].Cells[1].Value ="بالطوارئ";
            dataGridView1.Rows[3].Cells[1].Value = "بالرعاية المركزة";
            dataGridView1.Rows[4].Cells[1].Value ="بالاخري";

            dataGridView1.Rows[0].Cells[0].Value = "1";
            dataGridView1.Rows[1].Cells[0].Value = "2";
            dataGridView1.Rows[2].Cells[0].Value = "3";
            dataGridView1.Rows[3].Cells[0].Value = "4";
            dataGridView1.Rows[4].Cells[0].Value = "5";
            dataGridView1.Rows[3].Cells[0].Value = "6";
            dataGridView1.Rows[4].Cells[0].Value = "7";
          
        }

        private void cell_doubleclick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Des = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

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
