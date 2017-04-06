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
    public partial class صناعة_شيت : Form
    {
        Connection con = new Connection();
        عنوان_جديد y = new عنوان_جديد();
        List<ComboBox> dataType = new List<ComboBox>();
        static int st;

        TextBox t7 = new TextBox();
        // static bool y1=true;
        شيتات asd = new شيتات();
        static string strr;
        public صناعة_شيت()
        {
            InitializeComponent();
        }
        public صناعة_شيت(عنوان_جديد x)
        {
            InitializeComponent();
            y = x;
        }

        
        private void صناعة_شيت_Load(object sender, EventArgs e)
        {
            con.OpenConection();

        }

        public void SetValue(int r)
        {
            st = r;

        }
        public void SetValue3(DataGridViewRow r)
        {
            try
            {
                t7.Text = r.Cells[1].Value.ToString();
                MessageBox.Show(r.Cells[1].Value.ToString());

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


       
        private void اضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {
     
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {}

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewComboBoxEditingControl comboControl
           = e.Control as DataGridViewComboBoxEditingControl;
            if (comboControl != null)
            {
                // Set the DropDown style to get an editable ComboBox
                if (comboControl.DropDownStyle != ComboBoxStyle.DropDown)
                {
                    comboControl.DropDownStyle = ComboBoxStyle.DropDown;
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        private void صفحةجديدةToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            صفحة_جديدة M = new صفحة_جديدة();
            M.Show();
       
        }

        private void صفحةجديدةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            عنوان_جديد M = new عنوان_جديد();
            M.Show();
       
        }

        private void طباعةToolStripMenuItem_Click_1(object sender, EventArgs e)
        { 
            طباعة_شيت p = new طباعة_شيت();
            p.Show();
        
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          

        }

        int counter = 0;
        private void اضافةToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                Label a = new Label();
                a.Text = "Description";
                strr = a.Text;
                Label a1 = new Label();
                a1.Text = "Data Type";
                TextBox t1 = new TextBox();
                ComboBox c1 = new ComboBox();
                c1.Name = "ComboBox" + ++counter;
                c1.Items.AddRange(new object[] {
            "Date time",
            "Number",
            "Table",
            "Image",
            "Radio Button",
            "Text",
            "Large Text",
            "List Box",
            "Check Box",
            });

                // a.Location = new System.Drawing.Point(10, 10);
                flowLayoutPanel1.Controls.Add(a);
                flowLayoutPanel2.Controls.Add(t1);
                flowLayoutPanel1.Controls.Add(a1);
                flowLayoutPanel2.Controls.Add(c1);
                Control[] controls = flowLayoutPanel2.Controls.Find("ComboBox" + counter, true);//

                ((ComboBox)controls[0]).SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
                dataType.Add(c1);
            }
            else 
            {
                MessageBox.Show(". يجب عليك اختيار عنوان لاضافة عناصر له ");
            }
          
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox test = (ComboBox)sender;
            if (test.Text == "Table")
            {

                TextBox t = new TextBox();
                t.Size = new Size(50, 50);
                t.Name = "txt1";
                t.Enabled = true;
                t.TextChanged += new System.EventHandler(this.textBox_TextChanged);
                flowLayoutPanel3.Controls.Add(t);
                TextBox t2 = new TextBox();
                t2.Size = new Size(50, 50);
                t2.Name = "txt2";
                t2.Enabled = true;

                t2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
                flowLayoutPanel3.Controls.Add(t2);
                // y1 = true;
            }
            else if (test.Text == "Image")
            {
                PictureBox p = new PictureBox();

                p.Size = new Size(100, 100);
                p.Enabled = true;
                p.Name = "p1";
                صور_مكونات_جسم_الانسان a = new صور_مكونات_جسم_الانسان();
                a.Show();
            }
            else if (test.Text == "Number")
            {
                TextBox t6 = new TextBox();
                t6.Size = new Size(30, 30);
                t6.Name = "txt1";
                t6.Enabled = true;

                t7.Size = new Size(70, 70);
                t7.Name = "txt2";
                t7.Enabled = true;
                t7.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);

                t7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
                t6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
                flowLayoutPanel3.Controls.Add(t6);
                flowLayoutPanel3.Controls.Add(t7);




            }
         
         
        }
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            اعداد_وحدات_القياس a = new اعداد_وحدات_القياس();
            a.Show();
            // MessageBox.Show(st1);
            // t7.Text = st1;
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            TextBox tt = (TextBox)sender;

            asd.setval7(tt.Text);


        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            TextBox tt = (TextBox)sender;

            asd.setval6(Convert.ToInt32(tt.Text.ToString()));


        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tt = (TextBox)sender;

            asd.setval(Convert.ToInt32(tt.Text.ToString()));


        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox tt = (TextBox)sender;
            asd.setval2(Convert.ToInt32(tt.Text.ToString()));

        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
       
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void صناعة_شيت_MouseHover(object sender, EventArgs e)
        {
       
            
                if (صفحة_جديدة.a != null)
                    listBox1.DataSource = صفحة_جديدة.a;
            
        }

        private void listBox1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            y.Setvalue(listBox1.SelectedItem.ToString());  
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            con.OpenConection();
            string[] pramname2 = new string[1];
            string[] pramvalue2 = new string[1];
            SqlDbType[] pramtype2 = new SqlDbType[1];
            pramname2[0] = "@x1";
            pramvalue2[0] = listBox1.SelectedItem.ToString();
            pramtype2[0] = SqlDbType.VarChar;
            //con.OpenConection();
            listBox2.DataSource = con.ShowDataInGridViewUsingStoredProc("MedicalSheet_NewHeader_headerselect", pramname2, pramvalue2, pramtype2);
            con.CloseConnection();

            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                List<string> str = new List<string>();
                foreach (ComboBox c in dataType)
                    str.Add(c.Text);
                شيتات a = new شيتات(str, strr);
                a.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void مسحToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
