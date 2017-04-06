namespace HIS
{
    partial class WM_Worker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.help = new System.Windows.Forms.LinkLabel();
            this.delete = new System.Windows.Forms.LinkLabel();
            this.add = new System.Windows.Forms.LinkLabel();
            this.exit = new System.Windows.Forms.LinkLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.empName = new System.Windows.Forms.TextBox();
            this.emp_id = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.notes = new System.Windows.Forms.TextBox();
            this.job = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.LinkLabel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // help
            // 
            this.help.AutoSize = true;
            this.help.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help.Location = new System.Drawing.Point(587, 9);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(42, 16);
            this.help.TabIndex = 29;
            this.help.TabStop = true;
            this.help.Text = "تعديل";
            this.help.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.help_LinkClicked);
            // 
            // delete
            // 
            this.delete.AutoSize = true;
            this.delete.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.Location = new System.Drawing.Point(648, 9);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(38, 16);
            this.delete.TabIndex = 24;
            this.delete.TabStop = true;
            this.delete.Text = "حذف";
            this.delete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.delete_LinkClicked);
            // 
            // add
            // 
            this.add.AutoSize = true;
            this.add.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add.Location = new System.Drawing.Point(706, 9);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(44, 16);
            this.add.TabIndex = 25;
            this.add.TabStop = true;
            this.add.Text = "اضافة";
            this.add.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.add_LinkClicked);
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(768, 9);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(41, 16);
            this.exit.TabIndex = 26;
            this.exit.TabStop = true;
            this.exit.Text = "خروج";
            this.exit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.exit_LinkClicked);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 305);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(780, 150);
            this.dataGridView1.TabIndex = 22;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // empName
            // 
            this.empName.Location = new System.Drawing.Point(109, 147);
            this.empName.Name = "empName";
            this.empName.Size = new System.Drawing.Size(200, 20);
            this.empName.TabIndex = 20;
            this.empName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.empName_KeyPress);
            // 
            // emp_id
            // 
            this.emp_id.Enabled = false;
            this.emp_id.Location = new System.Drawing.Point(486, 147);
            this.emp_id.Name = "emp_id";
            this.emp_id.ReadOnly = true;
            this.emp_id.Size = new System.Drawing.Size(200, 20);
            this.emp_id.TabIndex = 19;
            this.emp_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.emp_id_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(743, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "الوظيفة";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "ملاحظات";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "اسم الموظف";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(736, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "رقم الموظف";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 45);
            this.label1.TabIndex = 17;
            this.label1.Text = "عمال المغسلة";
            // 
            // notes
            // 
            this.notes.Location = new System.Drawing.Point(109, 213);
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(200, 20);
            this.notes.TabIndex = 32;
            this.notes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.notes_KeyPress);
            // 
            // job
            // 
            this.job.Location = new System.Drawing.Point(486, 213);
            this.job.Name = "job";
            this.job.Size = new System.Drawing.Size(200, 20);
            this.job.TabIndex = 31;
            this.job.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.job_KeyPress);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(486, 265);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(159, 20);
            this.textBox1.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(724, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "اسم المغسلة";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(324, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "كود العامل";
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(473, 9);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(87, 16);
            this.description.TabIndex = 28;
            this.description.TabStop = true;
            this.description.Text = "وصف الحقول";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(112, 272);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(145, 20);
            this.textBox2.TabIndex = 36;
            // 
            // button1
            // 
            this.button1.Image = global::HIS.Properties.Resources.search_scale_100_contrast_white;
            this.button1.Location = new System.Drawing.Point(263, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 23);
            this.button1.TabIndex = 37;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Image = global::HIS.Properties.Resources.search_scale_100_contrast_white;
            this.button2.Location = new System.Drawing.Point(651, 262);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 23);
            this.button2.TabIndex = 38;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // WM_Worker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 466);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.notes);
            this.Controls.Add(this.job);
            this.Controls.Add(this.description);
            this.Controls.Add(this.help);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.empName);
            this.Controls.Add(this.emp_id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "WM_Worker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "عمال المغسلة";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.LinkLabel help;
        public System.Windows.Forms.LinkLabel delete;
        public System.Windows.Forms.LinkLabel add;
        public System.Windows.Forms.LinkLabel exit;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.TextBox empName;
        public System.Windows.Forms.TextBox emp_id;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox notes;
        public System.Windows.Forms.TextBox job;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.LinkLabel description;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;

    }
}

