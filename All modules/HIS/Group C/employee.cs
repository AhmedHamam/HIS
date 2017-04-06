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
    public partial class employee : Form
    {

        Connection con = new Connection();
        public static int Code1 { get; set; }
        public static string Code2 { get; set; }
    
        public employee()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            /* string name = dataGridView1.CurrentRow.Cells["emp_code"].Value.ToString();
             تسجيل_بيانات__مريض link = new تسجيل_بيانات__مريض();
             link.textBox2.Text = name;*/
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void employee_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            dataGridView1.DataSource = (DataTable)con.ShowDataInGridViewUsingStoredProc("selectnameemployee");
            con.CloseConnection();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            * 
            * 
           try
           {
               Code = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
               MessageBox.Show(Code.ToString());
               انهاء_زيارة_مريض_خارجى ff = new انهاء_زيارة_مريض_خارجى();
               ff.Focus();
               this.DialogResult = DialogResult.OK;
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message + " dfff");
           }

            * */
  }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
               try
            {
                Code1 = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                Code2 = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                // emp_code = int.Parse(s);
                // MessageBox.Show(emp_code.ToString());
                تسجيل_بيانات__مريض ff = new تسجيل_بيانات__مريض();
                ff.Focus();
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " يوجد خطا");
            }
        }
        }

        
    }
