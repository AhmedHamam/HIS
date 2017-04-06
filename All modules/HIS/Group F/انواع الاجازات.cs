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
    public partial class انواع_الاجازات : Form
    {
        Connection con = new Connection();
        DataTable dt_types = new DataTable();
        TextBox textcategory_id = new TextBox();
        TextBox textcategory_name = new TextBox();
        TextBox textdays = new TextBox();
        ComboBox combovac_type = new ComboBox();
        Panel p1 = new Panel();

        
        
        public انواع_الاجازات()
        {
            InitializeComponent();
        }
        private void انواع_الاجازات_Load(object sender, EventArgs e)
        {
           
            con.OpenConection();
            SqlCommand com = new SqlCommand("select_vactype", con.con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            combovac_type.DataSource = dt;
            combovac_type.DisplayMember = "vac_name";
            combovac_type.ValueMember = "vactype_id";
            dr.Close();
            con.CloseConnection();
            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            con.OpenConection();

            SqlCommand com = new SqlCommand("radion_button_vactype1", con.con);
            try
            {
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch 
            {
                MessageBox.Show("ادخل البيانات صحيحة");
            }
            con.CloseConnection();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            con.OpenConection();

            SqlCommand com = new SqlCommand("radion_button_vactype2", con.con);
            try
            {
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = com.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("ادخل البيانات صحيحة");
            }
            con.CloseConnection();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            p1.Location = new Point(12, 87);
            p1.Size = new Size(448, 142);
            Controls.Add(p1);

            Label category_id = new Label();
            category_id.Location = new Point(378, 18);
            category_id.Size = new Size(56, 13);
            category_id.Text = "رقم الأجازة";
            p1.Controls.Add(category_id);


            textcategory_id.Location = new Point(253, 13);
            textcategory_id.Size = new Size(100, 20);
            p1.Controls.Add(textcategory_id);

            textcategory_id.KeyPress += textcategory_id_KeyPress;



            Label category_name = new Label();
            category_name.Location = new Point(165, 18);
            category_name.Size = new Size(61, 13);
            category_name.Text = "اسم الأجازة";
            p1.Controls.Add(category_name);



            textcategory_name.Location = new Point(50, 18);
            textcategory_name.Size = new Size(100, 20);
            p1.Controls.Add(textcategory_name);

            textcategory_name.KeyPress += textcategory_name_KeyPress;


            Label days = new Label();
            days.Location = new Point(378, 81);
            days.Size = new Size(54, 13);
            days.Text = "عدد الأيام";
            p1.Controls.Add(days);



            textdays.Location = new Point(253, 78);
            textdays.Size = new Size(100, 20);
            p1.Controls.Add(textdays);

            textdays.KeyPress += textdays_KeyPress;

            Label vac_type = new Label();
            vac_type.Location = new Point(165, 81);
            vac_type.Size = new Size(54, 13);
            vac_type.Text = "نوع الأجازة";
            p1.Controls.Add(vac_type);


            combovac_type.Location = new Point(50, 81);
            combovac_type.Size = new Size(100, 20);
            p1.Controls.Add(combovac_type);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
               
                 SqlCommand com = new SqlCommand("insert_category", con.con);
                 com.CommandType = CommandType.StoredProcedure;
                 com.Parameters.AddWithValue("category_id", textcategory_id.Text);
                 com.Parameters.AddWithValue("category_name", textcategory_name.Text);
                 com.Parameters.AddWithValue("primitted_Days", textdays.Text);
                 com.Parameters.AddWithValue("vac_name", combovac_type.Text);
                 

                    try
                    {
                        com.ExecuteNonQuery();
                        MessageBox.Show("تم إضافة الأجازة");


                    }

                    catch
                    {
                        
                        MessageBox.Show("تأكد من البيانات");

                    }
                    con.CloseConnection();
                }
            
            catch
            {

                if (textcategory_id.Text == null || textcategory_name.Text == null || textdays.Text == null || combovac_type.SelectedValue == null)
                {
                    MessageBox.Show("الرجاء ادخال البيانات كاملة");
                }
                p1.AllowDrop = true;
                
            }



            con.CloseConnection(); 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (textcategory_id.Text == "")
            {
                MessageBox.Show("الرجاء ادخال رقم الأجازة");
            }
            else
            {
                //تعديل
                con.OpenConection();
                SqlCommand com = new SqlCommand("delete_vac", con.con);
            try
            {
                
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("category_id", textcategory_id.Text);
                com.ExecuteNonQuery();
                MessageBox.Show("تم حذف الأجازة");
            }
            catch
            {
                MessageBox.Show("الرجاء التأكد من البيانات");
            }
            }
            con.CloseConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textcategory_id.Clear();
            textcategory_name.Clear();
            textdays.Clear();
            
        }
        void textcategory_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام صحيحة فقط");
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        void textcategory_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || (char.IsWhiteSpace(e.KeyChar))))
            {
                e.Handled = true;
                MessageBox.Show(" من فضلك ادخل حروف فقط");
            }

        }

        void textdays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام صحيحة فقط");
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

    }
}
