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
    public partial class عرض_موظفى_العلاج_الطبيعي : Form
    {
        Connection con = new Connection();
        DataTable dt = new DataTable();
        تقرير_تنفيذ_خطة_العلاج_الطبيعى op;
        استقبال_العلاج_الطبيعي op1=new استقبال_العلاج_الطبيعي();
        تعديل_الخطة_العلاجية_للعلاج_الطبيعى op2;
        int x;
        public عرض_موظفى_العلاج_الطبيعي()
        {
            InitializeComponent();
        }
        public عرض_موظفى_العلاج_الطبيعي(تقرير_تنفيذ_خطة_العلاج_الطبيعى x)
        {
            InitializeComponent();
            op = x;
            this.x = 0;
        }
        public عرض_موظفى_العلاج_الطبيعي(استقبال_العلاج_الطبيعي x)
        {
            InitializeComponent();
            op1 = x;
            this.x = 1;
        }
        public عرض_موظفى_العلاج_الطبيعي(تعديل_الخطة_العلاجية_للعلاج_الطبيعى x)
        {
            InitializeComponent();
            op2 = x;
            this.x = 2;
        }

        private void عرض_موظفى_العلاج_الطبيعي_Load(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                object x = new object();
                x = con.ShowDataInGridView("physiotherapy_Doctors_select");
                dataGridView1.DataSource = (DataTable)x;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }
            }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String x = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                String y = dataGridView1.CurrentRow.Cells[1].Value.ToString();
              
                if (this.x==0)
                {
                    op.SetValues(x, y);
                    this.Close();
                }
                else if (this.x == 1)
                {
                    op1.setDoctor(x, y);
                    this.Close();
                }
                else
                {
                    op2.SetDoctor(x, y);
                    this.Close();
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        }
    }
