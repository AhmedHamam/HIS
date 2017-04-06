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
    public partial class زيارات_المريض : Form
    {
        SqlDataReader dr;
        public int id;
        string query;
        Connection con = new Connection();
        public زيارات_المريض()
        {
            InitializeComponent();
            fill_Entites();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {
            if(comboBox3.SelectedIndex==-1)
            {
                return;
            }
            con.OpenConection();
            SqlCommand cmd = new SqlCommand("visit", con.con);
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@v_id",textBox1.Text);
                cmd.Parameters.AddWithValue("@from_peri", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@to_peri", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("@pa_id", textBox2.Text);
                cmd.Parameters.AddWithValue("@ec_id", comboBox3.SelectedItem);
                cmd.Parameters.AddWithValue("@v_type", comboBox12.Text);
                cmd.ExecuteNonQuery();
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            MessageBox.Show("تم الحفظ");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("من فضلك ادخل ارقام !");
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            { e.Handled = true; }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            String d1 = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            String d2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");

            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show(" التاريخ الاول يجب ان يكون اقل من الثانى ");
            }
        }

        ///////////////////////
        private void fill_Entites()
        {
            try
            {
                comboBox1.Items.Clear();
                comboBox1.Text = "";
                listBox1.Items.Clear();
                con.OpenConection();
                query = @"SELECT  CE_Id, CE_AName FROM  tb_Contracting_Entities";

                dr = con.DataReader(query);
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr[0].ToString());
                    listBox1.Items.Add(dr[1].ToString());

                }
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = listBox1.SelectedIndex;

            comboBox2.Items.Clear();
            comboBox2.Text = "";
            listBox2.Items.Clear();

            comboBox3.Items.Clear();
            comboBox3.Text = "";
            listBox3.Items.Clear();

            if (listBox1.SelectedIndex != -1)
            {
                try
                {
                    comboBox2.Items.Clear();
                    comboBox2.Text = "";
                    listBox2.Items.Clear();
                    con.OpenConection();
                    query = @"SELECT  tb_Entities_Branches.EB_id, tb_Entities_Branches.EB_Aname
                            FROM  tb_Contracting_Entities INNER JOIN tb_Entities_Branches ON tb_Contracting_Entities.CE_Id = tb_Entities_Branches.EB_CE_id
                            WHERE tb_Contracting_Entities.CE_Id=" + comboBox1.SelectedItem + "";

                    dr = con.DataReader(query);
                    while (dr.Read())
                    {
                        comboBox2.Items.Add(dr[0].ToString());
                        listBox2.Items.Add(dr[1].ToString());

                    }
                    con.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = listBox2.SelectedIndex;

            comboBox3.Items.Clear();
            comboBox3.Text = "";
            listBox3.Items.Clear();

            if (listBox2.SelectedIndex != -1)
            {
                try
                {
                    comboBox3.Items.Clear();
                    comboBox3.Text = "";
                    listBox3.Items.Clear();
                    con.OpenConection();
                    query = @"SELECT  tb_Entities_Category.EC_id, tb_Entities_Category.EC_Aname
                            FROM  tb_Entities_Branches INNER JOIN
                            tb_Entities_Category ON tb_Entities_Branches.EB_id = tb_Entities_Category.EC_EB_id
                            WHERE tb_Entities_Branches.EB_id=" + comboBox2.SelectedItem + "";

                    dr = con.DataReader(query);
                    while (dr.Read())
                    {
                        comboBox3.Items.Add(dr[0].ToString());
                        listBox3.Items.Add(dr[1].ToString());

                    }
                    con.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.SelectedIndex = listBox3.SelectedIndex;
        }
    }
}
