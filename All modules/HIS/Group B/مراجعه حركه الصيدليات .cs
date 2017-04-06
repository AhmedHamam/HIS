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
    public partial class مراجعهحركهالصيدليات : Form
    {
        Connection con = new Connection();
        /*
        DataTable dt;
        sqlDataReader dataReader;
        sqlCommand cmd;
        sqlConnection con = new sqlConnection("server=localhost;database=final;uid=root;pwd=root");*/
        private Button button2;
        private Button button1;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label9;
        private ComboBox comboBox3;
        private Label label8;
        private ComboBox comboBox2;
        private Label label6;
        private ComboBox comboBox1;
        private Label label5;
        private TextBox textBox3;
        private Label label2;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Label label4;
        private Label label3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button3;
        private Button button4;
       // private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        //private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem خروجToolStripMenuItem;
        private DataGridView dataGridView1;
        private Label label1;
    
        public مراجعهحركهالصيدليات()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.خروجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.button2.Location = new System.Drawing.Point(27, 205);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 39);
            this.button2.TabIndex = 117;
            this.button2.Text = "مسح";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.button1.Location = new System.Drawing.Point(27, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 33);
            this.button1.TabIndex = 116;
            this.button1.Text = "بحث";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(181, 95);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(121, 20);
            this.textBox5.TabIndex = 114;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(308, 94);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 113;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label9.Location = new System.Drawing.Point(446, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 19);
            this.label9.TabIndex = 112;
            this.label9.Text = "المستخدم";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "الوارد",
            "المنصرف",
            "لا يؤثر"});
            this.comboBox3.Location = new System.Drawing.Point(414, 179);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 111;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label8.Location = new System.Drawing.Point(548, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 19);
            this.label8.TabIndex = 110;
            this.label8.Text = "تأثير الحركه";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "مراجع",
            "غير مراجع"});
            this.comboBox2.Location = new System.Drawing.Point(673, 223);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 107;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label6.Location = new System.Drawing.Point(817, 225);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 19);
            this.label6.TabIndex = 106;
            this.label6.Text = "الحاله";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "open Balance,الارصده الافتتاحيه",
            "return To Supplier,ارتجاع لمورد",
            "Return From Patient,ارتجاع من مريض",
            "Return From Department,ارتجاع من قسم"});
            this.comboBox1.Location = new System.Drawing.Point(181, 135);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 105;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label5.Location = new System.Drawing.Point(323, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 19);
            this.label5.TabIndex = 104;
            this.label5.Text = "نوع الحركه";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(673, 179);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(113, 20);
            this.textBox3.TabIndex = 103;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(792, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 19);
            this.label2.TabIndex = 102;
            this.label2.Text = "رقم الحركه";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(408, 133);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(149, 20);
            this.dateTimePicker2.TabIndex = 100;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(652, 133);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(149, 20);
            this.dateTimePicker1.TabIndex = 99;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.Location = new System.Drawing.Point(563, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 98;
            this.label4.Text = "الي تاريخ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Location = new System.Drawing.Point(817, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 19);
            this.label3.TabIndex = 97;
            this.label3.Text = "من تاريخ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(552, 92);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(121, 20);
            this.textBox2.TabIndex = 96;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(679, 92);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 95;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(817, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 94;
            this.label1.Text = "المخزن";
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::HIS.Properties.Resources._16402011_512263402277211_425787835_n;
            this.button3.Location = new System.Drawing.Point(785, 87);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 26);
            this.button3.TabIndex = 119;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::HIS.Properties.Resources._16402011_512263402277211_425787835_n;
            this.button4.Location = new System.Drawing.Point(414, 91);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(26, 26);
            this.button4.TabIndex = 120;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.خروجToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(836, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(55, 24);
            this.menuStrip1.TabIndex = 123;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // خروجToolStripMenuItem
            // 
            this.خروجToolStripMenuItem.Name = "خروجToolStripMenuItem";
            this.خروجToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.خروجToolStripMenuItem.Text = "خروج ";
            this.خروجToolStripMenuItem.Click += new System.EventHandler(this.خروجToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(141, 282);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(752, 180);
            this.dataGridView1.TabIndex = 124;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // مراجعهحركهالصيدليات
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(907, 474);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "مراجعهحركهالصيدليات";
            this.Text = "مراجعة حركة الصيدليات";
            this.Load += new System.EventHandler(this.Form8_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        public void setV(string s, string l)
        {
            textBox1.Text = s;
            textBox2.Text = l;
        }
        public void setValue(string s, string l)
        {
            textBox6.Text = s;
            textBox5.Text = l;
        }
        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void حفظToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {

                textBox3.Text = "";
                textBox1.Text = "";
                textBox6.Text = "";
                comboBox1.Text = "";
                textBox2.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                textBox5.Text = "";
                dataGridView1.DataSource = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowData();      
        }
        private void ShowData()
        {
            if (String.IsNullOrEmpty(textBox1.Text) && String.IsNullOrEmpty(textBox6.Text) && String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("من فضلك ادخل رقم المخزن و رقم المستخدم ورقم الحركه  ");
                textBox1.Focus();
            }
            else
            if (String.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("من فضلك ادخل رقم المخزن");
                    textBox1.Focus();
                }
            else
             if (textBox1.Text.Any(c => Char.IsLetter(c)))
                {
                    MessageBox.Show("من فضلك ادخل رقم المخزن بشكل صحيح");
                    textBox1.Focus();
                }
            else
             if (String.IsNullOrEmpty(textBox6.Text))
                {
                    MessageBox.Show("من فضلك ادخل رقم المستخدم ");
                    textBox6.Focus();
                }
             else
               if (textBox6.Text.Any(c => Char.IsLetter(c)))
                  {
                      MessageBox.Show("من فضلك ادخل رقم المستخدم بشكل صحيح");
                      textBox6.Focus();
                  }
               else
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("من فضلك ادخل رقم الحركه ");
                textBox3.Focus();
            }
            else
                if (textBox3.Text.Any(c => Char.IsLetter(c)))
                {
                    MessageBox.Show("من فضلك ادخل رقم الحركه بشكل صحيح");
                    textBox3.Focus();
                }
              else
                    if (textBox2.Text.Any(c => Char.IsNumber(c)))
                    {
                        MessageBox.Show("من فضلك ادخل اسم المخزن بشكل صحيح");
                        textBox2.Focus();
                    }
                    else
                        if (textBox5.Text.Any(c => Char.IsNumber(c)))
                        {
                            MessageBox.Show("من فضلك ادخل اسم المستخدم بشكل صحيح");
                            textBox5.Focus();
                        }
                    else
                    {
                      
                        if (comboBox1.Text != null)
                        {
                            if (comboBox1.Text == "مراجع")
                            {
                                try
                                {

                                    con.OpenConection();
                                    //not find table [0]
                                    string[] pramname = new string[8];
                                    string[] pramvalue = new string[8];
                                    SqlDbType[] pramtype = new SqlDbType[8];
                                    pramname[0] = "@x1";
                                    pramname[1] = "@x2";
                                    pramname[2] = "@x3";
                                    pramname[3] = "@x4";
                                    pramname[4] = "@x5";
                                    pramname[5] = "@x6";
                                    pramname[6] = "@x7";
                                    pramname[7] = "@x8";

                                    pramvalue[0] = dateTimePicker1.Value.ToString();
                                    pramvalue[1] = dateTimePicker2.Value.ToString();
                                    pramvalue[2] = textBox3.Text;
                                    pramvalue[3] = textBox1.Text;
                                    pramvalue[4] = comboBox1.Text;
                                    pramvalue[5] = textBox2.Text;
                                    pramvalue[6] = comboBox3.Text;
                                    pramvalue[7] = textBox6.Text;

                                    pramtype[0] = SqlDbType.VarChar;
                                    pramtype[1] = SqlDbType.VarChar;
                                    pramtype[2] = SqlDbType.Int;
                                    pramtype[3] = SqlDbType.VarChar;
                                    pramtype[4] = SqlDbType.Int;
                                    pramtype[5] = SqlDbType.VarChar;
                                    pramtype[6] = SqlDbType.VarChar;
                                    pramtype[7] = SqlDbType.VarChar;

                                    dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("review_pharmacy_movementT", pramname, pramvalue, pramtype);
                                    //MessageBox.Show("");
                                    con.CloseConnection();

                                }
                                catch (Exception)
                                {

                                    MessageBox.Show("من فضلك ادخل البيانات كاملة ");

                                }
                            }
                        }
                        else
                        {
                            try
                            {

                                con.OpenConection();
                                //not find table [0]
                                string[] pramname = new string[8];
                                string[] pramvalue = new string[8];
                                SqlDbType[] pramtype = new SqlDbType[8];
                                pramname[0] = "@x1";
                                pramname[1] = "@x2";
                                pramname[2] = "@x3";
                                pramname[3] = "@x4";
                                pramname[4] = "@x5";
                                pramname[5] = "@x6";
                                pramname[6] = "@x7";
                                pramname[7] = "@x8";

                                pramvalue[0] = dateTimePicker1.Value.ToString();
                                pramvalue[1] = dateTimePicker2.Value.ToString();
                                pramvalue[2] = textBox3.Text;
                                pramvalue[3] = textBox1.Text;
                                pramvalue[4] = comboBox1.Text;
                                pramvalue[5] = textBox2.Text;
                                pramvalue[6] = comboBox3.Text;
                                pramvalue[7] = textBox6.Text;

                                pramtype[0] = SqlDbType.VarChar;
                                pramtype[1] = SqlDbType.VarChar;
                                pramtype[2] = SqlDbType.Int;
                                pramtype[3] = SqlDbType.VarChar;
                                pramtype[4] = SqlDbType.Int;
                                pramtype[5] = SqlDbType.VarChar;
                                pramtype[6] = SqlDbType.VarChar;
                                pramtype[7] = SqlDbType.VarChar;

                                dataGridView1.DataSource = con.ShowDataInGridViewUsingStoredProc("review_pharmacy_movementF", pramname, pramvalue, pramtype);
                                //MessageBox.Show("");
                                con.CloseConnection();
                            }
                            catch (Exception)
                            {

                                MessageBox.Show("من فضلك ادخل البيانات كاملة ");

                            }
                        }
        }
    }

        private void button3_Click(object sender, EventArgs e)
        {
            المخازن1 f = new المخازن1(this);
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            المستخدميين1 f = new المستخدميين1(this);
            f.Show();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //int x = dataGridView1.Rows[e.RowIndex].Cells[0].EditedFormattedValue;
            if (e.RowIndex == -1)
            { return; }
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells[0];
            if ((bool)dataGridView1.Rows[e.RowIndex].Cells[0].EditedFormattedValue)
            {
                int n = Int32.Parse(dataGridView1[1, e.RowIndex].Value.ToString());
                int k = Int32.Parse(dataGridView1[2, e.RowIndex].Value.ToString());
                string sql = "update inventory_movement set review=true where inventory_movement.inventory_id =" + k + " and inventory_movement.movement_Code = " + n;
                try
                {
                    con.OpenConection();
                        //cmd = new sqlCommand(sql, con);
                        //cmd.ExecuteNonQuery();
                        con.ExecuteQueries(sql);

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        con.CloseConnection();
                    }
            }
        }
    }
}
