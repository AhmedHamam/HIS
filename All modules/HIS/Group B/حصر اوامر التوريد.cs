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
    public partial class حصراوامرالتوريد : Form
    {
        SqlConnection con = new SqlConnection(@"Server=DEMIANA\SQLEXPRESS;Database=PHIS;integrated security=true");
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        //Form17 f13;
        public حصراوامرالتوريد()
        {
            InitializeComponent();
        }

        private void lineShape2_Click(object sender, EventArgs e)
        {

        }

        private void Form29_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select count(*) from command_supply where date between "+dateTimePicker1.Value+ "and " +dateTimePicker1.Value ;
                dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { con.Close(); }
        }
        }
    }

