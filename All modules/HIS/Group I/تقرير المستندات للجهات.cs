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
    public partial class rep_clint : Form
    {
        Connection con = new Connection();
        public rep_clint()
        {
            InitializeComponent();
        }

       

//*******************************************************************************************       

        private void load_combox()
        {
            try
            {
                con.OpenConection();

                DataTable dt = new DataTable();
                dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("loadcombox");
                comboBox1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; ++i)
                    comboBox1.Items.Add(dt.Rows[i][0].ToString());

            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
            try
            {
                con.OpenConection();

                DataTable dt = new DataTable();
                dt = (DataTable)con.ShowDataInGridViewUsingStoredProc("loadcomboxc");
                comboBox2.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; ++i)
                    comboBox2.Items.Add(dt.Rows[i][0].ToString());
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }


//*********************************************************************************************************
        private void rep_clint_Load(object sender, EventArgs e)
        {
            load_combox();

        }

//********************************************************************************

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

       
    }
}
