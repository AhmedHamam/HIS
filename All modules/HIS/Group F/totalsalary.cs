using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;
using System.Data.SqlClient;
namespace HIS
{
    public partial class totalsalary : Form
    {
        Connection con = new Connection();
        public totalsalary()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            con.OpenConection();
        }
       public int count1 = 1;
        public int count2 = 0;
        private void button1_Click(object sender, EventArgs e)
        {

            count1 = count1 + 1;
            Label label = new Label();
            int count = panel1.Controls.OfType<Label>().ToList().Count;
            label.Location = new Point(900, (30 * count) + 2);
            label.Size = new Size(40, 20);
            label.Name = "label_" + (count + 1);
            label.Text = "" + (count + 1);
            panel1.Controls.Add(label);

            TextBox name = new TextBox();
            name.Location = new Point(705, 30 * count);
            name.Size = new Size(140, 20);
            name.Name = "textbox_" + ((count * 5) + 1);
            panel1.Controls.Add(name);

            TextBox basesalary = new TextBox();
            basesalary.Location = new Point(580, 30 * count);
            basesalary.Size = new Size(60, 20);
            basesalary.Name = "textbox_" + ((count * 5) + 2);
            panel1.Controls.Add(basesalary);

         

            TextBox val1 = new TextBox();
            val1.Location = new Point(465, 30 * count);
            val1.Size = new Size(60, 20);
            val1.Name = "textbox_" + ((count * 5) + 3);
            val1.ReadOnly = true;
            panel1.Controls.Add(val1);

         
            TextBox val2 = new TextBox();
            val2.Location = new Point(340, 30 * count);
            val2.Size = new Size(60, 20);
            val2.Name = "textbox_" + ((count * 5) + 4);
            val2.ReadOnly = true;
            panel1.Controls.Add(val2);


            TextBox totalsalary = new TextBox();
            totalsalary.Location = new Point(215, 30 * count);
            totalsalary.Size = new Size(60, 20);
            totalsalary.Name = "textbox_" + ((count * 5) + 5);
            totalsalary.ReadOnly = true;
            panel1.Controls.Add(totalsalary);

            count2 = count + 1;
        }

        private void add_Click(object sender, EventArgs e)
        {

            con.OpenConection();
            TextBox[] txts = new TextBox[5 * count1];
            int j = 0;
            try
                {
            for (int i = 0; i < panel1.Controls.Count; i++)
                if (panel1.Controls[i] is TextBox)
                {
                    txts[j] = (TextBox)panel1.Controls[i];
                    j++;
                }

            for (int i = 0; i < count2; i++)
            {

                SqlCommand cmd = new SqlCommand("add_totalsalary");
                cmd.Connection = con.con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@n1", txts[i * 5 + 0].Text);
                cmd.Parameters.AddWithValue("@b1", float.Parse(txts[i * 5 + 1].Text));
                cmd.Parameters.AddWithValue("@d1", dateTimePicker1.Value);
                var a = cmd.Parameters.Add("@inc1", SqlDbType.Float);
                a.Direction = ParameterDirection.Output;
                var b = cmd.Parameters.Add("@de1", SqlDbType.Float);
                b.Direction = ParameterDirection.Output;
                var c = cmd.Parameters.Add("@total1", SqlDbType.Float);
                c.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                txts[i * 5 + 2].Text = a.Value.ToString();
                txts[i * 5 + 3].Text = b.Value.ToString();
                txts[i * 5 + 4].Text = c.Value.ToString();
                MessageBox.Show("تم بنجاح");


            }
         }
                    catch (Exception )
                {
                    MessageBox.Show("خطأ في الادخال");
                }
            

            con.CloseConnection();


        }

        private void totalsalary_Load(object sender, EventArgs e)
        {

        }
        
     
    }
}

     

       

       
    
