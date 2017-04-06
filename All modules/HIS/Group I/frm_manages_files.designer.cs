namespace HIS
{
    partial class frm_manages_files
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.examination = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_date = new System.Windows.Forms.Button();
            this.btn_emp = new System.Windows.Forms.Button();
            this.btn_task = new System.Windows.Forms.Button();
            this.btn_name = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_activity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_employee_name = new System.Windows.Forms.TextBox();
            this.txt_patiant_name = new System.Windows.Forms.TextBox();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.ملفToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.إنشاءنسخةإحتياطيةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.إستعادةنسخةإحتياطيةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.patient_data = new System.Windows.Forms.DataGridView();
            this.خروجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.examination)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patient_data)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(945, 0);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(12, 0);
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.examination);
            this.groupBox1.Controls.Add(this.menuStrip1);
            this.groupBox1.Location = new System.Drawing.Point(12, 354);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(945, 112);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "نتائج البحث";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // examination
            // 
            this.examination.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.examination.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.examination.Location = new System.Drawing.Point(6, 19);
            this.examination.Name = "examination";
            this.examination.Size = new System.Drawing.Size(933, 79);
            this.examination.TabIndex = 6;
            this.examination.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btn_date);
            this.groupBox2.Controls.Add(this.btn_emp);
            this.groupBox2.Controls.Add(this.btn_task);
            this.groupBox2.Controls.Add(this.btn_name);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.date);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_activity);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txt_employee_name);
            this.groupBox2.Controls.Add(this.txt_patiant_name);
            this.groupBox2.Location = new System.Drawing.Point(393, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(564, 167);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btn_date
            // 
            this.btn_date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_date.Location = new System.Drawing.Point(6, 123);
            this.btn_date.Name = "btn_date";
            this.btn_date.Size = new System.Drawing.Size(75, 32);
            this.btn_date.TabIndex = 16;
            this.btn_date.Text = "بحث";
            this.btn_date.UseVisualStyleBackColor = true;
            this.btn_date.Click += new System.EventHandler(this.btn_date_Click);
            // 
            // btn_emp
            // 
            this.btn_emp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_emp.Location = new System.Drawing.Point(5, 85);
            this.btn_emp.Name = "btn_emp";
            this.btn_emp.Size = new System.Drawing.Size(75, 32);
            this.btn_emp.TabIndex = 16;
            this.btn_emp.Text = "بحث";
            this.btn_emp.UseVisualStyleBackColor = true;
            this.btn_emp.Click += new System.EventHandler(this.btn_emp_Click);
            // 
            // btn_task
            // 
            this.btn_task.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_task.Location = new System.Drawing.Point(6, 53);
            this.btn_task.Name = "btn_task";
            this.btn_task.Size = new System.Drawing.Size(75, 31);
            this.btn_task.TabIndex = 16;
            this.btn_task.Text = "بحث";
            this.btn_task.UseVisualStyleBackColor = true;
            this.btn_task.Click += new System.EventHandler(this.btn_task_Click);
            // 
            // btn_name
            // 
            this.btn_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_name.Location = new System.Drawing.Point(5, 15);
            this.btn_name.Name = "btn_name";
            this.btn_name.Size = new System.Drawing.Size(75, 30);
            this.btn_name.TabIndex = 16;
            this.btn_name.Text = "بحث";
            this.btn_name.UseVisualStyleBackColor = true;
            this.btn_name.Click += new System.EventHandler(this.btn_name_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoEllipsis = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(478, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 30);
            this.label1.TabIndex = 11;
            this.label1.Text = "اسم المريض";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // date
            // 
            this.date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date.Location = new System.Drawing.Point(239, 125);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(209, 20);
            this.date.TabIndex = 15;
            this.date.ValueChanged += new System.EventHandler(this.time_ValueChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoEllipsis = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(478, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 30);
            this.label3.TabIndex = 12;
            this.label3.Text = "اسم الموظف";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoEllipsis = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(478, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 30);
            this.label4.TabIndex = 13;
            this.label4.Text = "النشاط";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txt_activity
            // 
            this.txt_activity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_activity.Location = new System.Drawing.Point(239, 53);
            this.txt_activity.Multiline = true;
            this.txt_activity.Name = "txt_activity";
            this.txt_activity.Size = new System.Drawing.Size(209, 31);
            this.txt_activity.TabIndex = 8;
            this.txt_activity.TextChanged += new System.EventHandler(this.txt_activity_TextChanged);
            this.txt_activity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_activity_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoEllipsis = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(478, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 30);
            this.label5.TabIndex = 14;
            this.label5.Text = "التاريخ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_employee_name
            // 
            this.txt_employee_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_employee_name.Location = new System.Drawing.Point(239, 87);
            this.txt_employee_name.Multiline = true;
            this.txt_employee_name.Name = "txt_employee_name";
            this.txt_employee_name.Size = new System.Drawing.Size(209, 30);
            this.txt_employee_name.TabIndex = 9;
            this.txt_employee_name.TextChanged += new System.EventHandler(this.txt_employee_name_TextChanged);
            this.txt_employee_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_activity_KeyPress);
            // 
            // txt_patiant_name
            // 
            this.txt_patiant_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_patiant_name.Location = new System.Drawing.Point(239, 15);
            this.txt_patiant_name.Multiline = true;
            this.txt_patiant_name.Name = "txt_patiant_name";
            this.txt_patiant_name.Size = new System.Drawing.Size(209, 30);
            this.txt_patiant_name.TabIndex = 10;
            this.txt_patiant_name.TextChanged += new System.EventHandler(this.txt_patiant_name_TextChanged);
            this.txt_patiant_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_patiant_name_KeyPress);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ملفToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip2.Size = new System.Drawing.Size(963, 24);
            this.menuStrip2.TabIndex = 10;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip2_ItemClicked);
            // 
            // ملفToolStripMenuItem
            // 
            this.ملفToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.إنشاءنسخةإحتياطيةToolStripMenuItem,
            this.إستعادةنسخةإحتياطيةToolStripMenuItem,
            this.خروجToolStripMenuItem});
            this.ملفToolStripMenuItem.Name = "ملفToolStripMenuItem";
            this.ملفToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.ملفToolStripMenuItem.Text = "ملف";
            // 
            // إنشاءنسخةإحتياطيةToolStripMenuItem
            // 
            this.إنشاءنسخةإحتياطيةToolStripMenuItem.Name = "إنشاءنسخةإحتياطيةToolStripMenuItem";
            this.إنشاءنسخةإحتياطيةToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.إنشاءنسخةإحتياطيةToolStripMenuItem.Text = "إنشاء نسخة إحتياطية";
            // 
            // إستعادةنسخةإحتياطيةToolStripMenuItem
            // 
            this.إستعادةنسخةإحتياطيةToolStripMenuItem.Name = "إستعادةنسخةإحتياطيةToolStripMenuItem";
            this.إستعادةنسخةإحتياطيةToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.إستعادةنسخةإحتياطيةToolStripMenuItem.Text = "إستعادة نسخة إحتياطية";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.patient_data);
            this.groupBox3.Location = new System.Drawing.Point(12, 200);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(945, 148);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "نتائج البحث";
            // 
            // patient_data
            // 
            this.patient_data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.patient_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patient_data.Location = new System.Drawing.Point(6, 19);
            this.patient_data.Name = "patient_data";
            this.patient_data.Size = new System.Drawing.Size(933, 123);
            this.patient_data.TabIndex = 0;
            // 
            // خروجToolStripMenuItem
            // 
            this.خروجToolStripMenuItem.Name = "خروجToolStripMenuItem";
            this.خروجToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.خروجToolStripMenuItem.Text = "خروج";
            this.خروجToolStripMenuItem.Click += new System.EventHandler(this.خروجToolStripMenuItem_Click);
            // 
            // frm_manages_files
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(963, 478);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_manages_files";
            this.Text = "ادارة الملفات";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.examination)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.patient_data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_activity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_employee_name;
        private System.Windows.Forms.TextBox txt_patiant_name;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.Button btn_name;
        private System.Windows.Forms.Button btn_date;
        private System.Windows.Forms.Button btn_emp;
        private System.Windows.Forms.Button btn_task;
        private System.Windows.Forms.DataGridView examination;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView patient_data;
        private System.Windows.Forms.ToolStripMenuItem ملفToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem إنشاءنسخةإحتياطيةToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem إستعادةنسخةإحتياطيةToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem خروجToolStripMenuItem;
    }
}

