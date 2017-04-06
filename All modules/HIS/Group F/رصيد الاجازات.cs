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
    public partial class رصيد_الاجازات : Form
    {
        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt_types = new DataTable();
        DataTable dt_category = new DataTable();
        TextBox balance_txt = new TextBox();
        TextBox remaning_txt = new TextBox();
        TextBox length_txt = new TextBox();
        Panel p1 = new Panel();

        DateTimePicker start_date_pic = new DateTimePicker();
        DateTimePicker end_date_pic = new DateTimePicker();
        DataGridView dgd = new DataGridView();



        string type_id = "";
        string categoty_id = "";
        int balance1 = 0;
        int remaning1 = 0;
        public رصيد_الاجازات()
        {
            InitializeComponent();
        }
        private void رصيد_الاجازات_Load(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand com = new SqlCommand("select_vactype", con.con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "vac_name";
            comboBox1.ValueMember = "vactype_id";
            dr.Close();
            con.CloseConnection();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {  con.OpenConection();
            dt_category.Clear();
            SqlCommand com = new SqlCommand("select_category", con.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("vac_name", comboBox1.Text);
            SqlDataReader dr = com.ExecuteReader();
            dt_category.Load(dr);
            comboBox2.DataSource = dt_category;
            comboBox2.DisplayMember = "category_name";
            comboBox2.ValueMember = "category_id";
            dr.Close();
            con.CloseConnection();
        }



        int l = 0;

        private void new_btn_click(object sender, EventArgs e)
        {
            l++;
            p1.Location = new Point(20, 187);
            p1.Size = new Size(480, 233);
            if (l == 1)
            {
                Controls.Add(p1);

                p1.Controls.Clear();
                Label balance = new Label();
                balance.Location = new Point(400, 16);
                balance.Size = new Size(50, 13);
                balance.Text = "الرصيد";
                p1.Controls.Add(balance);


                balance_txt.Location = new Point(365, 67);
                balance_txt.Size = new Size(100, 20);
                balance_txt.KeyPress += balance_txt_KeyPress;
                p1.Controls.Add(balance_txt);



                Label remaning = new Label();
                remaning.Location = new Point(304, 16);
                remaning.Size = new Size(37, 13);
                remaning.Text = "الباقي";
                p1.Controls.Add(remaning);




                remaning_txt.Location = new Point(252, 67);
                remaning_txt.Size = new Size(100, 20);
                remaning_txt.KeyDown += remaning_txt_KeyDown;
                remaning_txt.KeyPress += remaning_txt_KeyPress;
                p1.Controls.Add(remaning_txt);



                Label length = new Label();
                length.Location = new Point(149, 16);
                length.Size = new Size(57, 13);
                length.Text = "مدة الأجازة";
                p1.Controls.Add(length);




                length_txt.Location = new Point(122, 67);
                length_txt.Size = new Size(100, 20);
                length_txt.KeyPress += length_txt_KeyPress;
                p1.Controls.Add(length_txt);



                Label start_date = new Label();
                start_date.Location = new Point(295, 124);
                start_date.Size = new Size(51, 13);
                start_date.Text = "تاريخ البدء";
                p1.Controls.Add(start_date);


                start_date_pic.Location = new Point(77, 122);
                start_date_pic.Size = new Size(200, 20);
                p1.Controls.Add(start_date_pic);

                Label end_date = new Label();
                end_date.Location = new Point(289, 191);
                end_date.Size = new Size(65, 13);
                end_date.Text = "تاريخ الانتهاء";
                p1.Controls.Add(end_date);

                end_date_pic.Location = new Point(77, 185);
                end_date_pic.Size = new Size(200, 20);
                p1.Controls.Add(end_date_pic);
            }

            try
            {
                con.OpenConection();
                SqlCommand com = new SqlCommand("remaning_balance", con.con);
                com.CommandType = CommandType.StoredProcedure;
                
                com.Parameters.AddWithValue("vac_name", comboBox1.Text);
                com.Parameters.AddWithValue("category_name", comboBox2.Text);
                com.Parameters.AddWithValue("emp_id", textBox2.Text);

                if (com.ExecuteScalar() == null)
                {
                    remaning1 = 0;
                }

                else
                {
                    remaning1 = Convert.ToInt32(com.ExecuteScalar());
                }

                remaning_txt.Text = remaning1.ToString();

                com = new SqlCommand("original_balance", con.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("vac_name", comboBox1.Text);
                com.Parameters.AddWithValue("category_name", comboBox2.Text);
                com.Parameters.AddWithValue("emp_id", textBox2.Text);
                if (com.ExecuteScalar() == null)
                {
                    balance1 = 0;
                }

                else
                {
                    balance1 = Convert.ToInt32(com.ExecuteScalar());
                }

                balance_txt.Text = balance1.ToString();
            }
            catch
            {

                if (textBox1.Text == null || textBox2.Text == null || textBox5.Text == null || textBox6.Text == null || textBox7.Text == null || balance_txt.Text == null || remaning_txt.Text == null || comboBox2.SelectedValue == null || comboBox1.SelectedValue == null)
                {
                    MessageBox.Show("الرجاء ادخال البيانات كاملة");
                }


            }
            con.CloseConnection();
        }

        private void show_btn_click(object sender, EventArgs e)
        {
            try
            {
                dgd.Location = new Point(511, 262);
                dgd.Size = new Size(511, 213);
                Controls.Add(dgd);

                con.OpenConection();

                //cmd = new SqlCommand(" select vactype_id from vacation_types where vac_name='" + comboBox1.Text + "';", con);
                //type_id = cmd.ExecuteScalar().ToString();

                //cmd = new SqlCommand(" select category_id from category where category_name='" + comboBox2.Text + "';", con);
                //categoty_id = cmd.ExecuteScalar().ToString();
                //cmd = new SqlCommand("select balance_id as 'رقم الرصيد', original_balance as 'الرصيد الأصلي', remaning_balance as 'الرصيد الباقي', date_start_vacation as 'تاريخ بداية الأجازة', date_end_vacation as 'تاريخ نهاية الأجازة', vacation_length as 'مدة الأجازة' from balance_vacation where emp_id='" + textBox2.Text + "'and vactype_id='" + type_id + "'and category_id='" + categoty_id + "'", con);

                SqlCommand com = new SqlCommand("show_vacations", con.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("vac_name", comboBox1.Text);
                com.Parameters.AddWithValue("category_name", comboBox2.Text);
                com.Parameters.AddWithValue("emp_id", textBox2.Text);


                try
                {
                    SqlDataReader dr = com.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dgd.DataSource = dt;
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            catch
            {

                if (textBox1.Text == null || textBox2.Text == null || textBox5.Text == null || textBox6.Text == null || textBox7.Text == null || balance_txt.Text == null || remaning_txt.Text == null || length_txt.Text == null || comboBox2.SelectedValue == null || comboBox1.SelectedValue == null)
                {
                    MessageBox.Show("الرجاء ادخال البيانات كاملة");
                }

            }
            con.CloseConnection();
        }


        private void add_btn_click(object sender, EventArgs e)
        {

            con.OpenConection();

            if (textBox1.Text == null || textBox2.Text == null || textBox5.Text == null || textBox6.Text == null || textBox7.Text == null || balance_txt.Text == null || remaning_txt.Text == null || length_txt.Text == null || comboBox2.SelectedValue == null || comboBox1.SelectedValue == null)
            {
                MessageBox.Show("الرجاء ادخال البيانات كاملة");
            }

            else
            {

                cmd = new SqlCommand(" select vactype_id from vacation_types where vac_name='" + comboBox1.Text + "';", con.con);
                type_id = cmd.ExecuteScalar().ToString();

                cmd = new SqlCommand(" select category_id from category where category_name='" + comboBox2.Text + "';", con.con);
                categoty_id = cmd.ExecuteScalar().ToString();

                try
                {

                    SqlCommand com = new SqlCommand("insert_blance_vacation", con.con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("emp_id", textBox2.Text);
                    com.Parameters.AddWithValue("vactype_id", type_id);
                    com.Parameters.AddWithValue("category_id", categoty_id);
                    com.Parameters.AddWithValue("original_balance", balance_txt.Text);
                    com.Parameters.AddWithValue("remaning_balance", remaning_txt.Text);
                    com.Parameters.AddWithValue("date_start_vacation", start_date_pic.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                    com.Parameters.AddWithValue("date_end_vacation", end_date_pic.Value.Date.ToString("yyyy-MM-dd HH:mm"));
                    com.Parameters.AddWithValue("vacation_length", length_txt.Text);
                    com.ExecuteNonQuery();
                    MessageBox.Show("تم إضافة الأجازة");
                }

                catch
                {
                    MessageBox.Show("الرجاء كتابة البيانات كاملة");
                }
            }


            con.CloseConnection();


        }



        private void delete_btn_click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                cmd = new SqlCommand(" select vactype_id from vacation_types where vac_name='" + comboBox1.Text + "';", con.con);
                type_id = cmd.ExecuteScalar().ToString();

                cmd = new SqlCommand(" select category_id from category where category_name='" + comboBox2.Text + "';", con.con);
                categoty_id = cmd.ExecuteScalar().ToString();
                SqlCommand com = new SqlCommand("delete_blance_vacation", con.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("emp_id", textBox2.Text);
                com.Parameters.AddWithValue("vac_id", type_id);
                com.Parameters.AddWithValue("category_id", categoty_id);

                try
                {
                    com.ExecuteNonQuery();
                    MessageBox.Show("تم حذف الموظف");
                }

                catch
                {

                    MessageBox.Show("الرجاء التأكد من البيانات");
                }
            }
            catch
            {

                if (textBox1.Text == null || textBox2.Text == null || textBox5.Text == null || textBox6.Text == null || textBox7.Text == null || balance_txt.Text == null || remaning_txt.Text == null || length_txt.Text == null || comboBox2.SelectedValue == null || comboBox1.SelectedValue == null)
                {
                    MessageBox.Show("الرجاء ادخال البيانات كاملة");
                }

            }
            con.CloseConnection();

        }


        private void reset_click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            balance_txt.Clear();
            remaning_txt.Clear();
            length_txt.Clear();
            dgd.ClearSelection();
            p1.AllowDrop = true;


        }


        private void click_text(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand com = new SqlCommand("select_name_dep", con.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("id", textBox2.Text);
            var a = com.Parameters.Add("name", SqlDbType.VarChar, 255);
            a.Direction = ParameterDirection.Output;
            var b = com.Parameters.Add("dep_name", SqlDbType.VarChar, 255);
            b.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            textBox1.Text = a.Value.ToString();
            textBox5.Text = b.Value.ToString();
            con.CloseConnection();
        }

        private void click2_text(object sender, EventArgs e)
        {
            con.OpenConection();
            SqlCommand com = new SqlCommand("select_id_dep", con.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("name", textBox1.Text);
            var a = com.Parameters.Add("id", SqlDbType.Int);
            a.Direction = ParameterDirection.Output;
            var b = com.Parameters.Add("dep_name", SqlDbType.VarChar, 255);
            b.Direction = ParameterDirection.Output;
            com.ExecuteNonQuery();
            textBox2.Text = a.Value.ToString();
            textBox5.Text = b.Value.ToString();
            con.CloseConnection();


        }

        

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام فقط");
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || (char.IsWhiteSpace(e.KeyChar))))
            {
                e.Handled = true;
                MessageBox.Show(" من فضلك ادخل حروف فقط");
            }

        }
        void length_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام فقط");
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        void remaning_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام فقط");
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }


        private void remaning_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    remaning_txt.Text = (Convert.ToInt64(remaning_txt.Text) - Convert.ToInt64(length_txt.Text)).ToString();
                }
                catch
                {
                    MessageBox.Show("الرجاء ادخال المدة صحيحة");
                }

            }


        }
        void  balance_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام فقط");
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

    }
}

