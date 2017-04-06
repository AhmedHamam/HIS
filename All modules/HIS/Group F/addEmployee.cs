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
    public partial class addEmployee : Form
    {

        Connection con = new Connection();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        
        public addEmployee()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            

        }

        private void addEmployee_Load(object sender, EventArgs e)
        {
         
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                SqlCommand cmd = new SqlCommand("add_employee", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("name", textBox2.Text);
                cmd.Parameters.AddWithValue("addreess", textBox3.Text);
                cmd.Parameters.AddWithValue("phone", textBox4.Text);
                cmd.Parameters.AddWithValue("statuus",comboBox2.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("email", textBox6.Text);
                cmd.Parameters.AddWithValue("gender", comboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("birth_date", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("religion", textBox7.Text);
                cmd.Parameters.AddWithValue("birth_place", textBox8.Text);
                cmd.Parameters.AddWithValue("nationality", textBox9.Text);
                cmd.Parameters.AddWithValue("card_id", int.Parse(textBox10.Text));
                cmd.Parameters.AddWithValue("card_realease_place", textBox11.Text);
                cmd.Parameters.AddWithValue("card_realease_date", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("qualification", textBox13.Text);
                cmd.Parameters.AddWithValue("qualification_date", dateTimePicker3.Value);
                cmd.Parameters.AddWithValue("years_of_experience", int.Parse(textBox16.Text));
                cmd.Parameters.AddWithValue("experience", textBox17.Text);
                cmd.Parameters.AddWithValue("prevoius_jobs", textBox19.Text);
                cmd.Parameters.AddWithValue("hiring_date", dateTimePicker4.Value);
                cmd.Parameters.AddWithValue("personal_picture", textBox12.Text);
                cmd.Parameters.AddWithValue("career_level", comboBox3.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("career_name", textBox23.Text);
                cmd.Parameters.AddWithValue("career_state", comboBox4.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("dep_code", textBox5.Text);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

            }
            con.CloseConnection();
            

        }
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.OpenConection();
                SqlCommand cmd = new SqlCommand("update_employee", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("emp_id", textBox1.Text);
                cmd.Parameters.AddWithValue("name", textBox2.Text);
                cmd.Parameters.AddWithValue("addreess", textBox3.Text);
                cmd.Parameters.AddWithValue("phone", textBox4.Text);
                cmd.Parameters.AddWithValue("statuus", comboBox2.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("email", textBox6.Text);
                cmd.Parameters.AddWithValue("gender", comboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("birth_date", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("religion", textBox7.Text);
                cmd.Parameters.AddWithValue("birth_place", textBox8.Text);
                cmd.Parameters.AddWithValue("nationality", textBox9.Text);
                cmd.Parameters.AddWithValue("card_id", int.Parse(textBox10.Text));
                cmd.Parameters.AddWithValue("card_realease_place", textBox11.Text);
                cmd.Parameters.AddWithValue("card_realease_date", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("qualification", textBox13.Text);
                cmd.Parameters.AddWithValue("qualification_date", dateTimePicker3.Value);
                cmd.Parameters.AddWithValue("years_of_experience",int.Parse(textBox16.Text));
                cmd.Parameters.AddWithValue("experience", textBox17.Text);
                cmd.Parameters.AddWithValue("prevoius_jobs", textBox19.Text);
                cmd.Parameters.AddWithValue("hiring_date", dateTimePicker4.Value);
                cmd.Parameters.AddWithValue("personal_picture", textBox12.Text);
                cmd.Parameters.AddWithValue("career_level", comboBox3.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("career_name", textBox23.Text);
                cmd.Parameters.AddWithValue("career_state", comboBox4.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("dep_code", textBox5.Text);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);

            }
            con.CloseConnection();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("هل تريد حذف الموظف?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                try
                {
                    con.OpenConection();
                    SqlCommand cmd = new SqlCommand("delete_emp", con.con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("emp_id", textBox1.Text);
                    cmd.ExecuteNonQuery();
                    con.CloseConnection();
                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("لم يتم الحذف");
            }
           

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if(op.ShowDialog()==DialogResult.OK)
            {
                textBox12.Text = op.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string code = this.textBox1.Text;
            string name = this.textBox2.Text;
            employees frm = new employees();
            frm.showdi(ref code, ref name);
            this.textBox2.Text = name;
            this.textBox1.Text = code;
            try
            {
                con.OpenConection();
                SqlCommand cmd = new SqlCommand("fill_emp", con.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("emp_id", Int32.Parse(textBox1.Text));
                var b = cmd.Parameters.Add("name", SqlDbType.VarChar, 255);
                b.Direction = ParameterDirection.Output;
                var c = cmd.Parameters.Add("addreess", SqlDbType.VarChar, 255);
                c.Direction = ParameterDirection.Output;
                var d = cmd.Parameters.Add("phone", SqlDbType.VarChar, 255);
                d.Direction = ParameterDirection.Output;
                var a = cmd.Parameters.Add("statuus", SqlDbType.VarChar, 255);
                a.Direction = ParameterDirection.Output;
                var f = cmd.Parameters.Add("email", SqlDbType.VarChar, 255);
                f.Direction = ParameterDirection.Output;
                var g = cmd.Parameters.Add("gender", SqlDbType.VarChar, 255);
                g.Direction = ParameterDirection.Output;
                var h = cmd.Parameters.Add("birth_date", SqlDbType.Date);
                h.Direction = ParameterDirection.Output;
                var i = cmd.Parameters.Add("religion", SqlDbType.VarChar, 255);
                i.Direction = ParameterDirection.Output;
                var j = cmd.Parameters.Add("birth_place", SqlDbType.VarChar, 255);
                j.Direction = ParameterDirection.Output;
                var k = cmd.Parameters.Add("nationality", SqlDbType.VarChar, 255);
                k.Direction = ParameterDirection.Output;
                var l = cmd.Parameters.Add("card_id", SqlDbType.Int);
                l.Direction = ParameterDirection.Output;
                var m = cmd.Parameters.Add("card_realease_place", SqlDbType.VarChar, 255);
                m.Direction = ParameterDirection.Output;
                var n = cmd.Parameters.Add("card_realease_date", SqlDbType.Date);
                n.Direction = ParameterDirection.Output;
                var o = cmd.Parameters.Add("qualification", SqlDbType.VarChar, 255);
                o.Direction = ParameterDirection.Output;
                var p = cmd.Parameters.Add("qualification_date", SqlDbType.Date);
                p.Direction = ParameterDirection.Output;
                var q = cmd.Parameters.Add("years_of_experience", SqlDbType.Int);
                q.Direction = ParameterDirection.Output;
                var r = cmd.Parameters.Add("experience", SqlDbType.VarChar, 255);
                r.Direction = ParameterDirection.Output;
                var s = cmd.Parameters.Add("prevoius_jobs", SqlDbType.VarChar, 255);
                s.Direction = ParameterDirection.Output;
                var t = cmd.Parameters.Add("hiring_date", SqlDbType.Date);
                t.Direction = ParameterDirection.Output;
                var u = cmd.Parameters.Add("personal_picture", SqlDbType.VarChar, 255);
                u.Direction = ParameterDirection.Output;
                var v = cmd.Parameters.Add("career_level", SqlDbType.VarChar, 255);
                v.Direction = ParameterDirection.Output;
                var w = cmd.Parameters.Add("career_name", SqlDbType.VarChar, 255);
                w.Direction = ParameterDirection.Output;
                var x = cmd.Parameters.Add("career_state", SqlDbType.VarChar, 255);
                x.Direction = ParameterDirection.Output;
                var y = cmd.Parameters.Add("dep_code", SqlDbType.Int);
                y.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                textBox2.Text = b.Value.ToString();
                textBox3.Text = c.Value.ToString();
                textBox4.Text = d.Value.ToString();
                comboBox2.SelectedItem = a.Value.ToString();
                textBox6.Text = f.Value.ToString();
                comboBox1.SelectedItem = g.Value.ToString();
                dateTimePicker1.Value = (DateTime)h.Value;
                textBox7.Text = i.Value.ToString();
                textBox8.Text = j.Value.ToString();
                textBox9.Text = k.Value.ToString();
                textBox10.Text = l.Value.ToString();
                textBox11.Text = m.Value.ToString();
                dateTimePicker2.Value = (DateTime)n.Value;
                textBox13.Text = o.Value.ToString();
                dateTimePicker3.Value = (DateTime)p.Value;
                textBox16.Text = q.Value.ToString();
                textBox17.Text = r.Value.ToString();
                textBox19.Text = s.Value.ToString();
                dateTimePicker4.Value = (DateTime)t.Value;
                textBox12.Text = u.Value.ToString();
                comboBox3.SelectedItem = v.Value.ToString();
                textBox23.Text = w.Value.ToString();
                comboBox4.SelectedItem = x.Value.ToString();
                textBox5.Text = y.Value.ToString();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

            
            
            con.CloseConnection();

        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            string code = this.textBox5.Text;
            string name = this.textBox14.Text;
            departements_search frm = new departements_search();
            frm.showdi(ref code, ref name);
            this.textBox14.Text = name;
            this.textBox5.Text = code;
        }
    }
    }
