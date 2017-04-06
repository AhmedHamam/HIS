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
    public partial class عرض_غرف_العلاج_الطبيعى : Form
    {
        Connection con = new Connection();
        اجهزة_العلاج_الطبيعى x=new اجهزة_العلاج_الطبيعى();
        public عرض_غرف_العلاج_الطبيعى()
        {
            InitializeComponent();
        }
        public عرض_غرف_العلاج_الطبيعى(اجهزة_العلاج_الطبيعى op)
        {
            InitializeComponent();
            x = op;
        }

        private void عرض_غرف_العلاج_الطبيعى_Load(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                object x = new object();
                x = con.ShowDataInGridView("physiotherapy_physiotherapy_Rooms_select");
                dataGridView1.DataSource = (DataTable)x;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            finally { con.CloseConnection(); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String code = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            x.SetRoomCode(code);
            this.Close();
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    
        
    }
}
