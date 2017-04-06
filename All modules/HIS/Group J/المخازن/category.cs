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
    public partial class category : Form
    {
        Connection conn = new Connection();
        //SqlConnection con = new SqlConnection(@"Server=DESKTOP-O2AL8TR\SQLEXPRESS;Database=HIS_GROUP_J; Integrated Security=true");

        public category()
        {
            InitializeComponent();
        }

        private void الاصناف_Load(object sender, EventArgs e)
        {
            conn.OpenConection();
            dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("category_show");
            conn.CloseConnection();
            clear.Clear(this);
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            string[] a = { "@categoryName","@cost_price","@categoryState","@barcode","@expiredate","@description","@amount","@inventory_id","@operation_id"};
            string[] c = {categoryName.Text, cost_price.Text, categoryState.Text, barcode.Text, date.Text,description.Text,amount.Text,inventoryid.Text,op_id.Text};
            SqlDbType[] b = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.Date, SqlDbType.Text, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int };

            conn.OpenConection();
            conn.ShowDataInsertUsingStoredProc("category_insert", a, c, b);
            conn.CloseConnection();

            conn.OpenConection();
            dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("category_show");
            conn.CloseConnection();
            clear.Clear(this);
            MessageBox.Show("تمـــت الإضافة");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = this.inventoryid.Text;
            pop frm = new pop();
            frm.showdi(ref code, "select inventory_id as 'الكود',inventoryName as 'الاسم' FROM inventory_inventory;", "المخازن");
            this.inventoryid.Text = code;

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripLabel6_Click(object sender, EventArgs e)
        {
            try
            {
                if (categoryName.Text != "")
                {
                    conn.OpenConection();
                    string[] a = {"@category_id","@categoryName", "@cost_price", "@categoryState", "@barcode", "@expiredate", "@description", "@amount", "@inventory_id", "@operation_id" };
                    string[] c = {textBox1.Text,categoryName.Text, cost_price.Text, categoryState.Text, barcode.Text, date.Text, description.Text, amount.Text, inventoryid.Text, op_id.Text };
                    SqlDbType[] b = {SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.Date, SqlDbType.Text, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int };

                    conn.ShowDataInsertUsingStoredProc("category_Update", a, c, b);
                    conn.CloseConnection();

                    clear.Clear(this);
                    conn.OpenConection();
                    dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("category_show");
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

        private void button2_Click(object sender, EventArgs e)
        {
            string code = this.op_id.Text;
            pop frm = new pop();
            frm.showdi(ref code, "select operation_id as 'كود العملية',type as 'نوع العملية ' FROM Inventory_inventoryOperation;", "العمليات علي الاصناف");
            this.op_id.Text = code;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            categoryName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cost_price.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            categoryState.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            description.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            amount.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            barcode.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            date.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            inventoryid.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            op_id.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            


        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] a = { "@categoryName" };
            SqlDbType[] b = { SqlDbType.VarChar };
            string[] c = { categoryName.Text };

            conn.OpenConection();
            dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("category_search", a, c, b);
            conn.CloseConnection();
            clear.Clear(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("هل انت متأكد من الحذف؟", "حذف", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == result)
                {
                    string[] a = { "@category_id" };
                    SqlDbType[] b = { SqlDbType.Int };
                    string[] c = { textBox1.Text };

                    conn.OpenConection();
                    conn.ShowDataInsertUsingStoredProc("category_delete ", a, c, b);
                    conn.CloseConnection();

                    conn.OpenConection();
                    dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("category_show");
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

        private void button5_Click(object sender, EventArgs e)
        {
            conn.OpenConection();
            dataGridView1.DataSource = conn.ShowDataInGridViewUsingStoredProc("category_show");
            conn.CloseConnection();
            clear.Clear(this);
        }

        private void barcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.integer(sender, e, this);
        }

        private void amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.integer(sender, e, this);
        }

        private void cost_price_KeyPress(object sender, KeyPressEventArgs e)
        {

            validate.Float(sender, e, this);

        }

        private void categoryState_KeyPress(object sender, KeyPressEventArgs e)
        {
            validate.letter(sender, e, this);
        }
        }
    }

