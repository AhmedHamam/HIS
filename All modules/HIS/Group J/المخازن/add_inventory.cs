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
    public partial class add_inventory : Form
    {
        Connection conn = new Connection();
        public add_inventory()
        {
            InitializeComponent();
        }
        //بحث من غير متغيرات
        private void button2_Click(object sender, EventArgs e)
        {
            string[] a = {"@inventoryName"};
            SqlDbType[] b = { SqlDbType.VarChar};
            string[] c = {inventoryName.Text};

            conn.OpenConection();
            dataGridView1.DataSource= conn.ShowDataInGridViewUsingStoredProc("Inventory_inventory_search", a, c, b);
            conn.CloseConnection();
            clear.Clear(this);
            
        }
        
        //الفورم لوووود
        private void Form34_Load(object sender, EventArgs e)

        {
            conn.OpenConection();
            dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("Inventory_inventory_show");
            conn.CloseConnection();

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //كود الاضافة
        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            string [] a={"@manager","@inventoryName","@place","@inventoryType","@emp_id"};
            string [] c={manager.Text,inventoryName.Text,place.Text,inventoryType.Text,employee_id.Text};
            SqlDbType[] b = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int };

            conn.OpenConection();
            conn.ShowDataInsertUsingStoredProc("Inventory_inventory_insert", a, c, b);
            conn.CloseConnection();
            
            conn.OpenConection();
            dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("Inventory_inventory_show");
            conn.CloseConnection();
            clear.Clear(this);
            MessageBox.Show("تمـــت الإضافة");
        }

        private void toolStripLabel7_Click(object sender, EventArgs e)
        {
        }

        //كود الحذف
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("هل انت متأكد من الحذف؟", "حذف", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == result)
                {
                    string[] a = { "@inventory_id" };
                    SqlDbType[] b = { SqlDbType.Int };
                    string[] c = { inv_id.Text };

                    conn.OpenConection();
                    conn.ShowDataInsertUsingStoredProc("Inventory_inventory_delete ", a, c, b);
                    conn.CloseConnection();

                    conn.OpenConection();
                    dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("Inventory_inventory_show");
                    conn.CloseConnection();
                    clear.Clear(this);
                    MessageBox.Show("تم الحذف");
                    
                }
                else
                {
                    conn.CloseConnection();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.CloseConnection();
            }

            }
        string str1 = "";
        public void showdi(ref string code)
        {
            this.ShowDialog();
            if (str1 != "")
            {
                code = str1;

            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

       //دوبل كليك جراد فيييو
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            inv_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            inventoryName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            manager.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            place.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            inventoryType.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

        }
        
        //انده البوب
        private void button1_Click(object sender, EventArgs e)
        {
    
            string code = this.employee_id.Text;
            string name = this.manager.Text;
            pop frm = new pop();
            frm.showdidi(ref code, ref name,"SELECT emp_id as 'الكود',name as 'الاسم' FROM employee","الموظفين");
            this.manager.Text = name;
            this.employee_id.Text = code;
        }

        //كود التعديل
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                if (inventoryName.Text != "")
                {
                    conn.OpenConection();
                    string[] parmnames = { "@inventory_id", "@manager", "@inventoryName", "@place", "@inventoryType" };
                    string[] parmvalues = {inv_id.Text,manager.Text, inventoryName.Text, place.Text, inventoryType.Text};
                    SqlDbType[] paradbtype = {SqlDbType.Int,SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };

                    conn.ShowDataInsertUsingStoredProc("Inventory_inventory_update", parmnames, parmvalues, paradbtype);
                    conn.CloseConnection();

                    clear.Clear(this);
                    conn.OpenConection();
                    dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("Inventory_inventory_show");
                    conn.CloseConnection();


                    MessageBox.Show("تم التعديل");
                }
                else MessageBox.Show("الرجاء إدخال كود الجهاز المراد تعديله ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { conn.CloseConnection(); }
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        //عرض الكل 
        private void button4_Click(object sender, EventArgs e)
        {
            conn.OpenConection();
            dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("Inventory_inventory_show");
            conn.CloseConnection();
        }

        
        //لادخال الحروف فقط
        private void inventoryName_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void inventoryType_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void place_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void inventoryName_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender,e,this);
        }
        }
    }

