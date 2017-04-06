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
    public partial class patient_statues : Form
    {
        Connection con = new Connection();
       
        public patient_statues()
        {
            
             
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            
             //MessageBox.Show(selected);
            try
            {con.OpenConection();

            if (selected == "الاولى الممتازه ")
               {
                   dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("parexe1");
                
               }
                else if (selected == "الثانيه الممتازه")
                {
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("parexe2");

                }
                else
                {
                    dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("parexe");
                }
                    
                    
            }
            catch (Exception s)
            {
                MessageBox.Show(s.Message);
            }

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            //parent.Show();
            this.Close();
        }

        private void patient_statues_Load(object sender, EventArgs e)
        {

        }
    }
}
