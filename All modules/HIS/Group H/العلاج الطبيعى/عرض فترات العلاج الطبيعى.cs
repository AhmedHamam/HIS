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
    public partial class عرض_فترات_العلاج_الطبيعى : Form
    {
        Connection con = new Connection();

        //SqlConnection con = new SqlConnection(@"Server=AHMEDHKHALIFA\SQLEXPRESS;Database=physiotherapy;Integrated Security=true");
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt=new DataTable();
        غرق_العلاج_الطبيعى op;
        public عرض_فترات_العلاج_الطبيعى(غرق_العلاج_الطبيعى x)
        {
            InitializeComponent();
            op = x;
        }
        private void عرض_فترات_العلاج_الطبيعىcs_Load(object sender, EventArgs e)
        {
            try {
                object x = new object();
                x = con.ShowDataInGridView("physiotherapy_physiotherapy_Treatment_Duration_select");
                dataGridView1.DataSource = (DataTable)x;
            }
            catch(Exception ex)
            {
            MessageBox.Show(ex.Message);
            }
          //  finally{con.Close();}
            }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String x = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                op.SetDurationCode(x);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        }
    }