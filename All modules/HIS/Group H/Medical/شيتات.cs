using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS
{
    public partial class شيتات : Form
    {
        List<string> str = new List<string>();
        static string strr;
        static string str2;
        static int w, z;
        static string z2;
        static int z1;
        صناعة_شيت s1;
        public شيتات()
        {
            InitializeComponent();
        }
        public شيتات(صناعة_شيت s)
        {
            InitializeComponent();
            s1 = s;
        }
        public شيتات(List<string> str,string strr)
        {
            InitializeComponent();

            TextBox ttt = new TextBox();
            ttt.Text = strr;
            this.tableLayoutPanel1.Controls.Add(ttt);
            this.str = str;
            tableLayoutPanel1.BackColor = Color.DarkGray;
            for (int i = 0; i < str.Count; i++)
            {
                if (str[i] == "Date time")
                {
                    this.tableLayoutPanel1.Controls.Add(new DateTimePicker());
                }
                else if (str[i] == "Number")
                {
                    this.tableLayoutPanel1.Controls.Add(new NumericUpDown());
                }
                else if (str[i] == "Table")
                {
                    TableLayoutPanel table = new TableLayoutPanel();
                    table.RowCount = w;
                    table.ColumnCount = z;
                    for (int p = 0; p < w; p++)
                    {
                        for (int j = 0; j < z; j++)
                        {
                            TextBox t = new TextBox();

                            table.Controls.Add(t);
                        }

                    }

                    this.tableLayoutPanel1.Controls.Add(table);

                }
                else if (str[i] == "Image")
                {
                    صور_مكونات_جسم_الانسان a = new صور_مكونات_جسم_الانسان();
                    a.Show();

                    PictureBox p = new PictureBox();
                    p.Image = Image.FromFile(str2);

                    this.tableLayoutPanel1.Controls.Add(p);

                }
                else if (str[i] == "Radio Button")
                    this.tableLayoutPanel1.Controls.Add(new RadioButton());
                else if (str[i] == "Text")
                    this.tableLayoutPanel1.Controls.Add(new TextBox());
                else if (str[i] == "Large Text")
                {
                    TextBox t = new TextBox();
                    t.Multiline = true;
                    this.tableLayoutPanel1.Controls.Add(t);
                }
                else if (str[i] == "List Box")
                    this.tableLayoutPanel1.Controls.Add(new ListBox());

                else if (str[i] == "Check Box")
                    this.tableLayoutPanel1.Controls.Add(new CheckBox());
                else if (str[i] == "Number")
                {
                    TextBox t1 = new TextBox();
                    t1.Text = z1.ToString();
                    this.tableLayoutPanel1.Controls.Add(t1);
                    TextBox t2 = new TextBox();
                    t2.Text = z2;
                    this.tableLayoutPanel1.Controls.Add(t2);
                }
                tableLayoutPanel1.RowCount++;

            }
         
         
        }
        public void SetValue2(string ss)
        {
            str2 = ss;

        }
        public void setval(int x)
        {
            w = x;
          
        }
        public void setval2(int x1)
        {
            z= x1;
           
        }
        public void setval6(int x4)
        {
            z1 = x4;

        }
        public void setval7(string x5)
        {
            z2 = x5;

        }
        private void شيتات_Load(object sender, EventArgs e)
        {

        }
    }
}
