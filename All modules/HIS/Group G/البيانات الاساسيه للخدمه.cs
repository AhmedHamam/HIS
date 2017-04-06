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
    public partial class البيانات_الاساسيه_للخدمه : Form
    {
        Connection con1 = new Connection();
        string[] name_input;
        string[] values;
        SqlDbType[] types;
       SqlDataReader dr;
        int isequal = 0;
        int doctor_feed;
        int do_in_hospital;
        int Code;
        public البيانات_الاساسيه_للخدمه()
        {
            InitializeComponent();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //try
            //{
                
                con1.OpenConection();
               
                //cmd.CommandText = "select EndoscopeCode from Endoscope_settings_data";
                //dr = cmd.ExecuteReader();
                dr = con1.DataReader("select EndoscopeCode from Endoscope_settings_data");
                if (textBox1.Text != "")
                {
                    while (dr.Read())
                    {
                        //MessageBox.Show(textBox1.Text);
                        if (int.Parse(dr[0].ToString()) == int.Parse(textBox1.Text))
                        {
                            Code = int.Parse(dr[0].ToString());
                            isequal = 1;
                            dr.Close();
                            //MessageBox.Show(isequal.ToString());
                            break;
                        }
                    }
                }
                //MessageBox.Show(isequal.ToString());
                       
                if (isequal == 1)
                {
                    //cmd.CommandText = "update Endoscope_settings_data set EndoscopeName  = '" + textBox4.Text + "' , DescriptionLatino  = '" + textBox5.Text + "' , Bill = '" + comboBox2.SelectedItem +"'   where  EndoscopeCode  = " + Code;
                    //cmd.ExecuteNonQuery();
                    con1.ExecuteQueries("update Endoscope_settings_data set EndoscopeName  = '" + textBox4.Text + "' , DescriptionLatino  = '" + textBox5.Text + "' , Bill = '" + comboBox2.SelectedItem + "'   where  EndoscopeCode  = " + Code);
                    if (checkBox1.Checked)
                    {
                        //cmd.CommandText = " update Endoscope_settings_data set do_in_hospital = 1  where  EndoscopeCode  = " + Code;
                        //cmd.ExecuteNonQuery();
                        con1.ExecuteQueries(" update Endoscope_settings_data set do_in_hospital = 1  where  EndoscopeCode  = " + Code);
                    }
                    else
                    {
                        //cmd.CommandText = " update Endoscope_settings_data set do_in_hospital = 0  where  EndoscopeCode  = " + Code;
                        //cmd.ExecuteNonQuery();
                        con1.ExecuteQueries(" update Endoscope_settings_data set do_in_hospital = 0  where  EndoscopeCode  = " + Code);
                    }

                    if (radioButton1.Checked)
                    {
                        //cmd.CommandText = " update Endoscope_settings_data set doctor_fees  = 1  where  EndoscopeCode  = " + Code;
                        //cmd.ExecuteNonQuery();
                        con1.ExecuteQueries(" update Endoscope_settings_data set doctor_fees  = 1  where  EndoscopeCode  = " + Code);
                    }
                    else if (radioButton2.Checked)
                    {
                        //cmd.CommandText = " update Endoscope_settings_data set doctor_fees  = 0  where  EndoscopeCode  = " + Code;
                        //cmd.ExecuteNonQuery();
                        con1.ExecuteQueries(" update Endoscope_settings_data set doctor_fees  = 0  where  EndoscopeCode  = " + Code);
                    }

                   
                }
                else
                {
                    dr.Close();
                    
                    if (checkBox1.Checked)
                    {
                        do_in_hospital = 1;
                    }
                    else
                    {
                        do_in_hospital = 0;
                    }

                    if (radioButton1.Checked)
                    {
                        doctor_feed = 1;
                    }
                    else if (radioButton2.Checked)
                    {
                        doctor_feed = 0;
                    }
                   // cmd.CommandText = "insert into Endoscope_settings_data (EndoscopeName, DescriptionLatino, do_in_hospital, doctor_fees, Bill)  values ( '" + textBox4.Text + "' , '" + textBox5.Text + "' , " + do_in_hospital + "," + doctor_feed + ",'" + comboBox2.SelectedItem + "')";
                    //cmd.ExecuteNonQuery();
                    con1.ExecuteQueries("insert into Endoscope_settings_data (EndoscopeName, DescriptionLatino, do_in_hospital, doctor_fees, Bill)  values ( '" + textBox4.Text + "' , '" + textBox5.Text + "' , " + do_in_hospital + "," + doctor_feed + ",'" + comboBox2.SelectedItem );
                }

                //MessageBox.Show(اعدادات_المناظير.set_name);
                con1.CloseConnection();
            
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

        private void البيانات_الاساسيه_للخدمه_Load(object sender, EventArgs e)
        {

            textBox1.Text = "";
            try
            {
                
                con1.OpenConection();
                //cmd = new SqlCommand();
                //cmd.Connection = con;
                //cmd.CommandText = "select * from Endoscope_settings_data where EndoscopeName = '" + اعدادات_المناظير.set_name + "'";
                //dr = cmd.ExecuteReader();
                dr = con1.DataReader("select * from Endoscope_settings_data where EndoscopeName = '" + اعدادات_المناظير.set_name + "'");
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

        private void اضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            checkBox1.Checked = false;
            comboBox2.SelectedIndex = -1;

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
