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
    public partial class اعدادات_المناظير : Form
    {

        SqlDataReader dr;
        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
        int isequal = 0;
        int doctor_feed;
        int do_in_hospital;
        int Code;
        int isclean;
        DataGridView dgv;
        int can_selest = 0;
        int can_selest_ = 0;
        int can_selest__ = 0;
        int can_delete = 0;
        int can_delete_ = 0;
        int first_open = 1;
        int first_open_ = 1;
        public static String set_name { set; get; }
        public اعدادات_المناظير()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (can_selest__ == 1)
            {
                can_selest__ = 0;
                textBox1.Text = "";

                try
                {

                    con1.OpenConection();
                    types = new SqlDbType[] { SqlDbType.Text };
                    name_input = new string[] { "@set_name" };
                    values = new string[] { set_name };
                    dr = con1.ShowDataInGridViewUsingStoredProcDR("setscope_Endoscope_settings_data_select", name_input, values, types);
                    while (dr.Read())
                    {
                        textBox1.Text = dr[0].ToString();
                        textBox4.Text = dr[1].ToString();
                        textBox5.Text = dr[2].ToString();
                        comboBox2.SelectedItem = dr[5].ToString();

                        if (int.Parse(dr[3].ToString()) == 1)
                        {
                            checkBox1.Checked = true;
                        }
                        if (int.Parse(dr[4].ToString()) == 1)
                        {
                            radioButton1.Checked = true;
                        }
                        else
                        {
                            radioButton2.Checked = true;
                        }
                    }
                    dr.Close();
                    con1.CloseConnection();

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message + "  error");
                }

            }


            اضافةToolStripMenuItem.Visible = true;
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
            }
            if (panel3.Visible == true)
            {
                panel3.Visible = false;
            }




            panel1.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            can_delete = 1;


            if (can_selest == 1)
            {
                //if (comboBox1.SelectedIndex == -1)
                //{ set_name = ""; }

                dataGridView2.Visible = true;
                dataGridView2.Columns.Clear();
                can_selest = 0;

                try
                {

                    con1.OpenConection();


                    DataGridViewButtonColumn Mostlzm_Choise = new DataGridViewButtonColumn();
                    Mostlzm_Choise.HeaderText = "اختيار_مستلزم";
                    Mostlzm_Choise.Text = "fcfv";
                    this.dataGridView2.Columns.Add(Mostlzm_Choise);


                    types = new SqlDbType[] { SqlDbType.Text };
                    name_input = new string[] { "@set_name" };
                    values = new string[] { set_name };
                    dr = con1.ShowDataInGridViewUsingStoredProcDR("setscope_Catgories_select", name_input, values, types);

                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    this.dataGridView2.DataSource = dt;


                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        this.dataGridView2.Rows[i].Cells[0].Value = "اختيار__مستلزم";

                    }

                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "ERROR");
                }
                dr.Close();
                con1.CloseConnection();

            }

            else
            {
                if (first_open == 1)
                {
                    first_open = 0;
                    dataGridView2.Visible = true;
                    dataGridView2.Columns.Clear();
                    DataGridViewButtonColumn Mostlzm_Choise = new DataGridViewButtonColumn();
                    Mostlzm_Choise.HeaderText = "اختيار_مستلزم";
                    Mostlzm_Choise.Text = "fcfv";
                    this.dataGridView2.Columns.Add(Mostlzm_Choise);
                    DataGridViewTextBoxColumn Mostlzm_id = new DataGridViewTextBoxColumn();
                    Mostlzm_id.HeaderText = "كود المستلزم";
                    this.dataGridView2.Columns.Add(Mostlzm_id);
                    DataGridViewTextBoxColumn Mostlzm_name = new DataGridViewTextBoxColumn();
                    Mostlzm_name.HeaderText = "اسم المستلزم";
                    this.dataGridView2.Columns.Add(Mostlzm_name);
                    DataGridViewTextBoxColumn Mostlzm_number = new DataGridViewTextBoxColumn();
                    Mostlzm_number.HeaderText = "الكمية";
                    this.dataGridView2.Columns.Add(Mostlzm_number);
                    //  this.dataGridView2.Rows.Add();
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        this.dataGridView2.Rows[i].Cells[0].Value = "اختيار__مستلزم";
                    }
                }
            }



            اضافةToolStripMenuItem.Visible = false;
            if (panel3.Visible == true)
            {
                panel3.Visible = false;
            }
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
            }

            foreach (DataGridViewColumn dc in this.dataGridView2.Columns)
            {

                if (dc.Index.Equals(1) || dc.Index.Equals(2))
                {

                    dc.ReadOnly = true;

                }
                else
                {
                    dc.ReadOnly = false;
                }

            }

            panel2.Visible = true;
            panel2.Location = panel1.Location;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            can_delete_ = 1;

            if (can_selest_ == 1)
            {
                dataGridView1.Visible = true;
                dataGridView1.Columns.Clear();
                can_selest_ = 0;


                try
                {


                    con1.OpenConection();


                    types = new SqlDbType[] { SqlDbType.Text };
                    name_input = new string[] { "@set_name" };
                    values = new string[] { set_name };
                    dr = con1.ShowDataInGridViewUsingStoredProcDR("setscope_Instrument_and_tools", name_input, values, types);
                    DataGridViewButtonColumn Choise_Devise = new DataGridViewButtonColumn();
                    Choise_Devise.HeaderText = "اختيار_جهاز";
                    this.dataGridView1.Columns.Add(Choise_Devise);



                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    this.dataGridView1.DataSource = dt;

                    //   MessageBox.Show(dataGridView1.Rows.Count + "  CounteRow_DataGrid_2 " + "    ");

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        this.dataGridView1.Rows[i].Cells[0].Value = "اختيار_جهاز";

                    }




                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "ERROR");
                }
                dr.Close();
                con1.CloseConnection();
            }

            else
            {
                if (first_open_ == 1)
                {
                    first_open_ = 0;
                    dataGridView1.Visible = true;
                    dataGridView1.Columns.Clear();
                    DataGridViewButtonColumn Choise_Devise = new DataGridViewButtonColumn();
                    Choise_Devise.HeaderText = "اختيار_جهاز";
                    this.dataGridView1.Columns.Add(Choise_Devise);
                    DataGridViewTextBoxColumn device_id = new DataGridViewTextBoxColumn();
                    device_id.HeaderText = "كود الجهاز";
                    this.dataGridView1.Columns.Add(device_id);
                    DataGridViewTextBoxColumn time = new DataGridViewTextBoxColumn();
                    time.HeaderText = "وقت الاستخدام";
                    this.dataGridView1.Columns.Add(time);
                    DataGridViewTextBoxColumn salahea = new DataGridViewTextBoxColumn();
                    salahea.HeaderText = "الصلاحية";
                    this.dataGridView1.Columns.Add(salahea);
                    DataGridViewTextBoxColumn type = new DataGridViewTextBoxColumn();
                    type.HeaderText = "نوع الجهاز";
                    this.dataGridView1.Columns.Add(type);
                    //  this.dataGridView1.Rows.Add();
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        this.dataGridView1.Rows[i].Cells[0].Value = "اختيار_جهاز";

                    }

                }
            }
            اضافةToolStripMenuItem.Visible = false;

            if (panel2.Visible == true)
            {
                panel2.Visible = false;
            }
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
            }


            foreach (DataGridViewColumn dc in this.dataGridView1.Columns)
            {

                if (dc.Index.Equals(1) || dc.Index.Equals(2))
                {

                    dc.ReadOnly = true;

                }
                else
                {
                    dc.ReadOnly = false;
                }
            }






            panel3.Visible = true;
            panel3.Location = panel1.Location;



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            can_selest = 1;
            can_selest_ = 1;
            can_selest__ = 1;
            if (comboBox1.SelectedIndex == -1)
            { set_name = ""; }
            else
            {
                set_name = comboBox1.SelectedItem.ToString();
            }

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void اعدادات_المناظير__Load(object sender, EventArgs e)
        {
            try
            {

                con1.OpenConection();

                dr = con1.DataReader("setscope_EndoscopeName_select");
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[0].ToString());
                }
            }

            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "  error");
            }
            dr.Close();
            con1.CloseConnection();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                doctor_feed = 1;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                doctor_feed = 0;
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                do_in_hospital = 1;
            }
            else
            {
                do_in_hospital = 0;
            }
        }




        private void اضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {

            textBox1.Text = "";

            textBox4.Text = "";
            textBox5.Text = "";

            radioButton1.Checked = false;
            radioButton2.Checked = false;
            checkBox1.Checked = false;
            //checkBox2.Checked = false;
            comboBox2.SelectedIndex = -1;
            comboBox1.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;

        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                con1.OpenConection();

                dr = con1.DataReader("setscope_EndoscopeCode_select");


                if (textBox1.Text != "")
                {
                    while (dr.Read())
                    {

                        if (int.Parse(dr[0].ToString()) == int.Parse(textBox1.Text))
                        {
                            Code = int.Parse(dr[0].ToString());
                            isequal = 1;
                            dr.Close();

                            break;
                        }
                    }
                }


                if (isequal == 1)
                {
                    dr.Close();

                    types = new SqlDbType[] { SqlDbType.Text, SqlDbType.Text, SqlDbType.Text, SqlDbType.Int };
                    name_input = new string[] { "@sett_name", "@latin_name", "@bill", "@code" };
                    values = new string[] { textBox4.Text, textBox5.Text, Convert.ToString(comboBox2.SelectedItem), Convert.ToString(Code) };
                    con1.ExecuteNonQueryProcedure("setscope_Endoscope_settings_data_Update1", name_input, values, types);


                    types = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int };
                    name_input = new string[] { "@do_in_hospital", "@code" };
                    values = new string[] { Convert.ToString(do_in_hospital), Convert.ToString(Code) };
                    con1.ExecuteNonQueryProcedure("setscope_Endoscope_settings_data_Update2", name_input, values, types);


                    types = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int };
                    name_input = new string[] { "@doctor_feed", "@code" };
                    values = new string[] { Convert.ToString(doctor_feed), Convert.ToString(Code) };
                    con1.ExecuteNonQueryProcedure("setscope_Endoscope_settings_data_Update3", name_input, values, types);

                    ///////
                    if (can_delete_ == 1)
                    {

                        types = new SqlDbType[] { SqlDbType.Int };
                        name_input = new string[] { "@code" };
                        values = new string[] { Convert.ToString(Code) };
                        con1.ExecuteNonQueryProcedure("setscope_Instruments_setescope_delete", name_input, values, types);

                    }
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {

                        string Code_dev = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                        string Type = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
                        double time_use = double.Parse(this.dataGridView1.Rows[i].Cells[3].Value.ToString());
                        int Time_salhea = int.Parse(this.dataGridView1.Rows[i].Cells[4].Value.ToString());


                        types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.Decimal, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.Int };
                        name_input = new string[] { "@Code_dev", "@time_use", "@Type", "@Time_salhea", "@Code_" };
                        values = new string[] { Code_dev, Convert.ToString(time_use), Type, Convert.ToString(Time_salhea), Convert.ToString(Code) };
                        con1.ExecuteNonQueryProcedure("setscope_", name_input, values, types);
                    }




                    if (can_delete == 1)
                    {

                        types = new SqlDbType[] { SqlDbType.Int };
                        name_input = new string[] { "@code" };
                        values = new string[] { Convert.ToString(Code) };
                        con1.ExecuteNonQueryProcedure("setscope_Mostlzmat_operation_delete", name_input, values, types);

                    }
                    for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                    {
                        int Mostlzmat_code = int.Parse(this.dataGridView2.Rows[i].Cells[1].Value.ToString());
                        string Mostlzmat_name = this.dataGridView2.Rows[i].Cells[2].Value.ToString();
                        int amount = int.Parse(this.dataGridView2.Rows[i].Cells[3].Value.ToString());


                        types = new SqlDbType[] { SqlDbType.Int, SqlDbType.Int, SqlDbType.Int };
                        name_input = new string[] { "@amount", "@Mostlzmat_code", "@Code" };
                        values = new string[] { Convert.ToString(amount), Convert.ToString(Mostlzmat_code), Convert.ToString(Code) };
                        con1.ExecuteNonQueryProcedure("setscope_Mostlzmat", name_input, values, types);
                    }



                }
                else
                {
                    dr.Close();

                    MessageBox.Show(do_in_hospital + "        " + doctor_feed);



                    types = new SqlDbType[] { SqlDbType.Text, SqlDbType.Text, SqlDbType.Int, SqlDbType.Int, SqlDbType.Text };
                    name_input = new string[] { "@sett_name", "@latin_name", "@do_in_hospital", "@doctor_feed", "@bill" };
                    values = new string[] { textBox4.Text, textBox5.Text, Convert.ToString(do_in_hospital), Convert.ToString(doctor_feed), Convert.ToString(comboBox2.SelectedItem) };
                    con1.ExecuteNonQueryProcedure("setscope_Endoscope_settings_data_insert", name_input, values, types);



                    int max_EndoscopeCode;
                    types = new SqlDbType[] { SqlDbType.Int };
                    name_input = new string[] { "@max_EndoscopeCode" };
                    values = new string[] { "" };
                    dr = con1.ShowDataInGridViewUsingStoredProcDR("setscope_Endoscope_settings_data_select_SET_code", name_input, values, types);
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    max_EndoscopeCode = Convert.ToInt32(dt);
                    // int max_EndoscopeCode = int.Parse(cmd.ExecuteScalar().ToString());

                    ////////////////////////////////////////////////////////////////
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {

                        string Code_dev = this.dataGridView1.Rows[i].Cells[1].Value.ToString();
                        string Ttype = this.dataGridView1.Rows[i].Cells[5].Value.ToString();
                        double timee_use = double.Parse(this.dataGridView1.Rows[i].Cells[3].Value.ToString());
                        int Time_salhea = int.Parse(this.dataGridView1.Rows[i].Cells[4].Value.ToString());


                        types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.Int, SqlDbType.Int, SqlDbType.Decimal, SqlDbType.VarChar };
                        name_input = new string[] { "@Code_dev", "@timee_use", "@max_EndoscopeCode", "@Time_salhea", "@Ttype" };
                        values = new string[] { Code_dev, Convert.ToString(timee_use), Convert.ToString(max_EndoscopeCode), Convert.ToString(Time_salhea), Ttype };
                        con1.ExecuteNonQueryProcedure("setscope_Instruments_setescope_insert", name_input, values, types);



                    }

                    for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                    {

                        int Mount_used = int.Parse(this.dataGridView2.Rows[i].Cells[3].Value.ToString());
                        string Moztlzm_name = this.dataGridView2.Rows[i].Cells[2].Value.ToString();
                        int Code_Moz = int.Parse(this.dataGridView2.Rows[i].Cells[1].Value.ToString());


                        types = new SqlDbType[] { SqlDbType.VarChar, SqlDbType.Int, SqlDbType.Int };
                        name_input = new string[] { "@max_EndoscopeCode", "@Code_Moz", "@Mount_used" };
                        values = new string[] { Convert.ToString(max_EndoscopeCode), Convert.ToString(Code_Moz), Convert.ToString(Mount_used) };
                        con1.ExecuteNonQueryProcedure("setscope_Mostlzmat_operation_insert", name_input, values, types);



                    }



                }

                MessageBox.Show(اعدادات_المناظير.set_name);

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "  error");
            }
        }


        private void Button_Click_Choice(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (e.ColumnIndex == 0 && e.RowIndex >= 0 && e.RowIndex != dataGridView1.Rows.Count)
                {


                    بحث_الجهاز f = new بحث_الجهاز();



                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[1].Value = بحث_الجهاز.Code.ToString();
                        dataGridView1.Rows[e.RowIndex].Cells[2].Value = بحث_الجهاز.Arabic_name;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                if (e.ColumnIndex == 0 && e.RowIndex >= 0 && e.RowIndex != dataGridView2.Rows.Count)
                {

                    مخزن_مستلزمات f = new مخزن_مستلزمات();

                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        dataGridView2.Rows[e.RowIndex].Cells[1].Value = مخزن_مستلزمات.Code.ToString();
                        dataGridView2.Rows[e.RowIndex].Cells[2].Value = مخزن_مستلزمات.Arabic_name;

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }




    }
}
