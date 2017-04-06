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
    public partial class plForm04 : Form
    {
       
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        SqlDataAdapter da;
        Connection connect; //M
        public plForm04()
        {
            InitializeComponent();
            connect = new Connection(); //M
            dt = new DataTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Add("الاداره العليا");
            treeView1.Nodes[0].Nodes.Add("رئيس مجلس الاداره");
            treeView1.Nodes[0].Nodes.Add("مدير المستشفى");
            treeView1.Nodes.Add("اداره نظم المعلومات");
            treeView1.Nodes[0].Nodes.Add("التوجيه المالى والادارى");


        }

        private void plForm04_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_spicialization_Click(object sender, EventArgs e)
        {

           if (Class1.chkNum(textBox5.Text))
           {

               {
                  try
                   {
                       connect.OpenConection();
                       string[] paramNames = {"@p_profession_year"};
                       string[] paramValues = {textBox5.Text};
                       SqlDbType[]paramType= {SqlDbType.VarChar};
                       dataGridView1.DataSource = connect.ShowDataInGridViewUsingStoredProc("planing_organiz_struc1", paramNames , paramValues , paramType );
                       
                   }
                   catch (Exception ee)
                   {
                      MessageBox.Show(ee.Message);
                   }

               }
           }
               else
                MessageBox.Show("قم بادخال السنه كرقم ");
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                connect.OpenConection();
                string pName = "planing_organiz_struc2";
                string[] paramNames = { "@year", "@target_num", "@existStaff_num", "@estimated_salary" };
                string[] paramValues = { textBox5.Text, textBox1.Text, textBox3.Text, textBox2.Text };
                SqlDbType[] paramType = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };
                connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames, paramValues, paramType);

                /*
                 * connect.ShowDataInGridViewUsingStoredProc(pName);
                 * connect.ShowDataInGridViewUsingStoredProc(pName, paramNames, paramValues, paramType);
                 * connect.ExecuteInsertOrUpdateOrDeleteUsingStoredProc(pName, paramNames, paramValues, paramType);
                 */


                MessageBox.Show("تم الاضافه ");
                
            }
            catch (Exception ee)

            {
                MessageBox.Show(ee.Message);
            }
            connect.CloseConnection();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
