using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIS
{
    public partial class administration : Form
    {

        SqlConnection con ;

        public administration()
        {
            InitializeComponent();
            Connection conn = new Connection();
            string constr = conn.getconstr();
            con = new SqlConnection(constr);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {


            //Connection mycon = new Connection();
            con.Open();




            if (txt_Code.Text != "" && txt_Name.Text != "")
            {
                try
                {
                    //string[] argsNmae = { "@id", "@name" };
                    //string[] argsValue = { txt_Code.Text, txt_Name.Text };

                    SqlCommand cmd = new SqlCommand("p1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", txt_Code.Text);
                    cmd.Parameters.AddWithValue("@name", txt_Name.Text);
                    cmd.ExecuteNonQuery();
                    SqlCommand cmd1 = new SqlCommand("p4", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dr = new SqlDataAdapter(cmd1);
                    DataSet ds = new DataSet();
                    dr.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    MessageBox.Show("تم الاضافه بنجاح", "اضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch 
                {
                    MessageBox.Show("لم تتم الاضافه بنجاح", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                finally
                {
                    txt_Code.Text = " ";
                      txt_Name.Text = " ";

                      con.Close();

                }

            }
            else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
               
                try
                {
                    SqlCommand cmm = new SqlCommand("dep", con);
                    cmm.CommandType = CommandType.StoredProcedure;
                    cmm.Parameters.AddWithValue("@code", textBox1.Text);
                    cmm.Parameters.AddWithValue("@eng_name", textBox3.Text);
                    cmm.Parameters.AddWithValue("@ar_name", textBox4.Text);
                    cmm.Parameters.AddWithValue("@de_lev", textBox2.Text);
                    cmm.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand("s", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dr = new SqlDataAdapter(cmd2);
                    DataSet ds = new DataSet();
                    dr.Fill(ds);
                    // dataGridView2.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0];
                        dataGridView2.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1];
                        dataGridView2.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2];
                        dataGridView2.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3];
                        dataGridView2.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4];

                       
                    }
                    MessageBox.Show("تم الاضافه بنجاح", "اضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch 
                {
                   MessageBox.Show("لم تتم الاضافه بنجاح", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                finally
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    con.Close();
                }









                //  MessageBox.Show("تم الاضافه بنجاح", "اضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);





                // MessageBox.Show("لم تتم الاضافه بنجاح", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //  MessageBox.Show(ex.Message);

                //finally
                //{
                //    txt_Code.Text = "";
                //    txt_Name.Text = ""; 
                //    con.Close();}
                ////try
                //{
                //    con.Open();

                //SqlCommand cm = new SqlCommand("insert into adminstration (id_admin,admin_name) values(" + txt_Code.Text + ",'" + txt_Name.Text + "') ", con);
                //cm.ExecuteNonQuery();
                //SqlCommand cmd2 = new SqlCommand("select * from adminstration;select * from departs;", con);
                //SqlDataAdapter da = new SqlDataAdapter(cmd2);
                //DataSet ds = new DataSet();
                //da.Fill(ds);
                //dataGridView1.DataSource = ds.Tables[0];
                //    MessageBox.Show("تم التسجيل بنجاح");
                //}
                //catch (Exception)
                //{

                //    MessageBox.Show("هذا الكود موجود مسبقا نرجو تغير الكود");

                //}
                //finally
                //{
                //    txt_Code.Text = " ";
                //    txt_Name.Text = " ";

                //    con.Close();

                //}
            }
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            //Connection mycon = new Connection();
            //mycon.OpenConection();
            con.Open();
            if (txt_Code.Text != "" && txt_Name.Text != "")
            {
            try
            {

                SqlCommand cmd = new SqlCommand("p2", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", txt_Code.Text);

                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("p4", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dr = new SqlDataAdapter(cmd1);
                DataSet ds = new DataSet();
                dr.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("تم الحذف بنجاح", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch 
            {

                MessageBox.Show("لم تتم الحذف بنجاح", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally
            {
                txt_Code.Text = "";
                txt_Name.Text = "";
                con.Close();
            }
            }

            else{







                try
                {
                    SqlCommand cmm = new SqlCommand("p2",con);
                    cmm.CommandType = CommandType.StoredProcedure;
                    cmm.Parameters.AddWithValue("@id", textBox1.Text);
                   // cmm.Parameters.AddWithValue("@eng_name", textBox3.Text);
                  //  cmm.Parameters.AddWithValue("@ar_name", textBox4.Text);
                  //  cmm.Parameters.AddWithValue("@de_lev", textBox2.Text);
                    cmm.ExecuteNonQuery();
                    SqlCommand cmm3 = new SqlCommand("p15", con);
                    cmm3.CommandType = CommandType.StoredProcedure;
                    cmm3.Parameters.AddWithValue("@id", txt_Code.Text);
                    cmm3.ExecuteNonQuery();

                    SqlCommand cmd4 = new SqlCommand("p4",con);
                    cmd4.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dr2 = new SqlDataAdapter(cmd4);
                    DataSet ds2 = new DataSet();
                    dr2.Fill(ds2);
                    dataGridView1.DataSource = ds2.Tables[0];


                    SqlCommand cmd2 = new SqlCommand("s", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dr = new SqlDataAdapter(cmd2);
                    DataSet ds = new DataSet();
                    dr.Fill(ds);
                    // dataGridView2.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0];
                        dataGridView2.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1];
                        dataGridView2.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2];
                        dataGridView2.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3];
                        dataGridView2.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4];


                    }
                    MessageBox.Show("تم الحذف بنجاح", "اضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch 
                {
                    MessageBox.Show("لم تتم الحذف بنجاح", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                finally
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    con.Close();
                }













            }
            //try
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("delete from adminstration where id_admin=" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + " ", con);
            //    cmd.ExecuteNonQuery();
            //    SqlCommand cmd1 = new SqlCommand("select * from adminstration;select * from departs;", con);
            //    SqlDataAdapter da = new SqlDataAdapter(cmd1);
            //    DataSet ds = new DataSet();
            //    da.Fill(ds);
            //    dataGridView1.DataSource = ds.Tables[0];

            //    MessageBox.Show("تم الحذف بنجاح");

            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("لا يمكن حذف هذه الادارة ");
            //}
            //finally
            //{
            //    txt_Code.Text = " ";
            //    con.Close();

            //}
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //Connection mycon = new Connection();
            con.Open();
            if (txt_Code.Text != "" && txt_Name.Text != "")
            {
               
            try
            {

                SqlCommand cmd = new SqlCommand("p3",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", txt_Code.Text);
                cmd.Parameters.AddWithValue("@name", txt_Name.Text);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("p4", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dr = new SqlDataAdapter(cmd1);
                DataSet ds = new DataSet();
                dr.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                MessageBox.Show("تم التعديل بنجاح", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

                MessageBox.Show("لم تتم التعديل بنجاح", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                txt_Code.Text = "";
                txt_Name.Text = "";
                con.Close();
            }
            }
            else
            {


                try
                {
                    SqlCommand cmm = new SqlCommand("dd",con);
                    cmm.CommandType = CommandType.StoredProcedure;
                    cmm.Parameters.AddWithValue("@code", textBox1.Text);
                    cmm.Parameters.AddWithValue("@eng_name", textBox3.Text);
                    cmm.Parameters.AddWithValue("@ar_name", textBox4.Text);
                    cmm.Parameters.AddWithValue("@de_lev", textBox2.Text);
                    cmm.ExecuteNonQuery();
                    SqlCommand cmd2 = new SqlCommand("s", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dr = new SqlDataAdapter(cmd2);
                    DataSet ds = new DataSet();
                    dr.Fill(ds);
                    // dataGridView2.DataSource = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells[0].Value = ds.Tables[0].Rows[i][0];
                        dataGridView2.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i][1];
                        dataGridView2.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i][2];
                        dataGridView2.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i][3];
                        dataGridView2.Rows[i].Cells[4].Value = ds.Tables[0].Rows[i][4];


                    }
                    MessageBox.Show("تم التعديل بنجاح", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("لم تتم التعديل بنجاح", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                finally
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    con.Close();
                }




            }
            //try
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("update adminstration set admin_name ='" + txt_Name.Text + "' where id_admin=" + txt_Code.Text + "    ", con);
            //    cmd.ExecuteNonQuery();
            //    SqlCommand cmd1 = new SqlCommand("select * from adminstration;select * from departs;", con);
            //    SqlDataAdapter da = new SqlDataAdapter(cmd1);
            //    DataSet ds = new DataSet();
            //    da.Fill(ds);
            //    dataGridView1.DataSource = ds.Tables[0];

            //    MessageBox.Show("تم التعديل بنجاح");

            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("هذا الكود غير موجود ,يرجي المحاوله مرة اخرى!");

            //}
            //finally
            //{
            //    txt_Code.Text = "";
            //    txt_Name.Text = "";
            //    con.Close();



            //}

        }

        private void administration_Load(object sender, EventArgs e)
        {

            con.Open();
            try
            {


                //  SqlCommand cmd = new SqlCommand("select * from adminstration;select * from departs;", con);
                SqlCommand cmd = new SqlCommand("p19", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
              //  dataGridView2.DataSource = ds.Tables[1];
               for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
               {
                  dataGridView2.Rows.Add();
               dataGridView2.Rows[i].Cells[0].Value = ds.Tables[1].Rows[i][0];
                  dataGridView2.Rows[i].Cells[1].Value = ds.Tables[1].Rows[i][1];
               dataGridView2.Rows[i].Cells[2].Value = ds.Tables[1].Rows[i][2];
                dataGridView2.Rows[i].Cells[3].Value = ds.Tables[1].Rows[i][5];
                dataGridView2.Rows[i].Cells[4].Value = ds.Tables[1].Rows[i][4];
               }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            finally { con.Close(); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Connection mycon = new Connection();
            //mycon.OpenConection();
            con.Open();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into departs (id,name,name_ar,depart_Level) values (" + textBox1.Text + ",'" + textBox3.Text + "','" + textBox4.Text + "','" + textBox2.Text + "'); ", con);
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("select * from departs;",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd1);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
                MessageBox.Show("تم التسجيل بنجاح!");



            }
            catch (Exception)
            {
                MessageBox.Show("هذا الكود موجود مسبقا,يرجى المحاوله مره اخرى!");
            }
            finally
            {
                textBox1.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox2.Text = "";
                con.Close();

            }
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Connection mycon = new Connection();
            //mycon.OpenConection();
            con.Open();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from departs where id=" + textBox1.Text + "; ", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم الحذف بنجاح");
            }
            catch (Exception)
            {
                MessageBox.Show(" هذا الكود غير موجود");



            }
            finally
            {
                textBox1.Text = "";
                con.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Connection mycon = new Connection();
            //mycon.OpenConection();
            con.Open();
            try{
                con.Open();
            SqlCommand cmd = new SqlCommand("update departs set name='" + textBox3.Text + "',name_ar='" + textBox4.Text + "',depart_Level='" + textBox2.Text + "' where id=" + textBox1.Text + " ", con);
            cmd.ExecuteNonQuery();
              MessageBox.Show("تم التعديل بنجاح");
            }
            catch (Exception)
            {
                MessageBox.Show(" هذا الكود غير موجود");



            }
            finally
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                con.Close();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //private void groupBox3_Enter(object sender, EventArgs e)
        //{

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        conn.Open();

        //            string cmdInsert = "INSERT INTO [dbo].[Manegments]([name],[Code]) VALUES(@name,@Code)";
        //            using (SqlCommand cmd = new SqlCommand(cmdInsert, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@name", txt_Name.Text);
        //                cmd.Parameters.AddWithValue("@Code", txt_Code.Text);
        //                cmd.ExecuteNonQuery();
        //            }
        //            conn.Close();

        //            MessageBox.Show("تم التسجيل بنجاح");

        //        loodManegment();
        //    }
        //    catch (Exception )
        //    {
        //        MessageBox.Show("هذا الكود موجود مسبقا نرجو تغير الكود");

        //    }
        //}

        //private void groupBox1_Enter(object sender, EventArgs e)
        //{

        //}

        //private void loodManegment()
        //{
        //    dataGridView1.DataSource = null;

        //    var select = "SELECT * FROM departs";
        //    var c = new SqlConnection(connString); 
        //    // Your Connection String here
        //    var dataAdapter = new SqlDataAdapter(select, c);

        //    var commandBuilder = new SqlCommandBuilder(dataAdapter);
        //    var ds = new DataSet();
        //    dataAdapter.Fill(ds);
        //    dataGridView1.ReadOnly = true;
        //    dataGridView1.DataSource = ds.Tables[0];
            
        //    dataGridView1.Columns[0].HeaderText = "رقم المسلسل";
        //    dataGridView1.Columns[1].HeaderText = "الوصف"; 
        //    dataGridView1.Columns[2].HeaderText = "الكود";
        //}

        //private void administration_Load(object sender, EventArgs e)
        //{
        //    conn = new SqlConnection(connString);
        //    loodManegment();
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int RowIndex = dataGridView1.CurrentCell.RowIndex;
                
        //        int id = Int32.Parse(dataGridView1.Rows[RowIndex].Cells[0].Value.ToString());

        //        conn.Open();

        //        string cmdDelete = "delete from [Manegments] where id = @id ";
        //        using (SqlCommand cmd = new SqlCommand(cmdDelete , conn))
        //        {
        //            cmd.Parameters.AddWithValue("@id", id);
        //            cmd.ExecuteNonQuery();
        //        }
        //        conn.Close();

        //        MessageBox.Show("تم الحذف بنجاح");

        //        loodManegment();
        //    }
        //    catch (Exception )
        //    {
        //        MessageBox.Show("لا يمكن حذف هذه الادارة ");

        //    }
        //}

        //private void btn_add_Click(object sender, EventArgs e)
        //{
        //    try{

        //    SqlCommand c = new SqlCommand("insert into [dbo].[adminstration] (id_admin,admin_name) values (" + txt_Code.Text + ",'" + txt_Name.Text + "')");

        //}

        //private void btn_exit_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
    }
}
