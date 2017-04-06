namespace HIS
{
    partial class A_FRM_Add_Accommodation_Degree
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
            this.CB_Status = new System.Windows.Forms.ComboBox();
            this.C_default = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Txt_ename = new System.Windows.Forms.TextBox();
            this.Txt_aname = new System.Windows.Forms.TextBox();
            this.Txt_id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.C_Ok = new System.Windows.Forms.ToolStripButton();
            this.C_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.C_Exit = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CB_Col_Type = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CB_Acc_Type = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CB_AD_type = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_time = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Controles = new System.Windows.Forms.ToolStrip();
            this.groupBox1.SuspendLayout();
            this.Controles.SuspendLayout();
            this.SuspendLayout();
            // 
            // CB_Status
            // 
            this.CB_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Status.FormattingEnabled = true;
            this.CB_Status.Items.AddRange(new object[] {
            "غيرمتاحة ",
            "متاحة"});
            this.CB_Status.Location = new System.Drawing.Point(494, 192);
            this.CB_Status.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CB_Status.Name = "CB_Status";
            this.CB_Status.Size = new System.Drawing.Size(151, 24);
            this.CB_Status.Sorted = true;
            this.CB_Status.TabIndex = 36;
            this.CB_Status.SelectedIndexChanged += new System.EventHandler(this.CB_Status_SelectedIndexChanged);
            // 
            // C_default
            // 
            this.C_default.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.C_default.AutoSize = true;
            this.C_default.Location = new System.Drawing.Point(156, 196);
            this.C_default.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.C_default.Name = "C_default";
            this.C_default.Size = new System.Drawing.Size(79, 21);
            this.C_default.TabIndex = 34;
            this.C_default.Text = "أساسية ";
            this.C_default.UseVisualStyleBackColor = true;
            this.C_default.CheckedChanged += new System.EventHandler(this.C_default_CheckedChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(730, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "الحالة ";
            // 
            // Txt_ename
            // 
            this.Txt_ename.Location = new System.Drawing.Point(121, 145);
            this.Txt_ename.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Txt_ename.Name = "Txt_ename";
            this.Txt_ename.Size = new System.Drawing.Size(524, 24);
            this.Txt_ename.TabIndex = 13;
            this.Txt_ename.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_aname_KeyPress);
            // 
            // Txt_aname
            // 
            this.Txt_aname.Location = new System.Drawing.Point(121, 85);
            this.Txt_aname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Txt_aname.Name = "Txt_aname";
            this.Txt_aname.Size = new System.Drawing.Size(524, 24);
            this.Txt_aname.TabIndex = 11;
            this.Txt_aname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_aname_KeyPress);
            // 
            // Txt_id
            // 
            this.Txt_id.Location = new System.Drawing.Point(509, 36);
            this.Txt_id.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Txt_id.Name = "Txt_id";
            this.Txt_id.ReadOnly = true;
            this.Txt_id.Size = new System.Drawing.Size(136, 24);
            this.Txt_id.TabIndex = 16;
            this.Txt_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(677, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "الوصف اللاتينى ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(684, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "الوصف العربى ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(736, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "الكود ";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // C_Ok
            // 
            this.C_Ok.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.C_Ok.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.C_Ok.Name = "C_Ok";
            this.C_Ok.Size = new System.Drawing.Size(39, 23);
            this.C_Ok.Text = "موافق";
            this.C_Ok.Click += new System.EventHandler(this.C_Ok_Click);
            // 
            // C_Save
            // 
            this.C_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.C_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.C_Save.Name = "C_Save";
            this.C_Save.Size = new System.Drawing.Size(37, 23);
            this.C_Save.Text = "حفظ ";
            this.C_Save.Click += new System.EventHandler(this.C_Save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // C_Exit
            // 
            this.C_Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.C_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.C_Exit.Name = "C_Exit";
            this.C_Exit.Size = new System.Drawing.Size(42, 23);
            this.C_Exit.Text = "خروج";
            this.C_Exit.Click += new System.EventHandler(this.C_Exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.CB_Col_Type);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CB_Acc_Type);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.CB_AD_type);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_time);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.CB_Status);
            this.groupBox1.Controls.Add(this.C_default);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Txt_ename);
            this.groupBox1.Controls.Add(this.Txt_aname);
            this.groupBox1.Controls.Add(this.Txt_id);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 40);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(804, 475);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات درجة الإقامة ";
            // 
            // CB_Col_Type
            // 
            this.CB_Col_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Col_Type.FormattingEnabled = true;
            this.CB_Col_Type.Items.AddRange(new object[] {
            "رعاية ",
            "طوارئ ",
            "عناية ",
            "مشتركة",
            "ممتازة "});
            this.CB_Col_Type.Location = new System.Drawing.Point(147, 309);
            this.CB_Col_Type.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CB_Col_Type.Name = "CB_Col_Type";
            this.CB_Col_Type.Size = new System.Drawing.Size(151, 24);
            this.CB_Col_Type.Sorted = true;
            this.CB_Col_Type.TabIndex = 46;
            this.CB_Col_Type.SelectedIndexChanged += new System.EventHandler(this.C_Col_Type_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(341, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 45;
            this.label5.Text = "نوع تجميع الاقامة ";
            // 
            // CB_Acc_Type
            // 
            this.CB_Acc_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Acc_Type.FormattingEnabled = true;
            this.CB_Acc_Type.Items.AddRange(new object[] {
            "تقريبى ",
            "فعلى "});
            this.CB_Acc_Type.Location = new System.Drawing.Point(147, 247);
            this.CB_Acc_Type.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CB_Acc_Type.Name = "CB_Acc_Type";
            this.CB_Acc_Type.Size = new System.Drawing.Size(151, 24);
            this.CB_Acc_Type.Sorted = true;
            this.CB_Acc_Type.TabIndex = 44;
            this.CB_Acc_Type.SelectedIndexChanged += new System.EventHandler(this.C_Acc_Type_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 43;
            this.label4.Text = "نوع الحساب ";
            // 
            // CB_AD_type
            // 
            this.CB_AD_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_AD_type.FormattingEnabled = true;
            this.CB_AD_type.Items.AddRange(new object[] {
            "إقامة عادية ",
            "رعاية "});
            this.CB_AD_type.Location = new System.Drawing.Point(494, 309);
            this.CB_AD_type.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CB_AD_type.Name = "CB_AD_type";
            this.CB_AD_type.Size = new System.Drawing.Size(151, 24);
            this.CB_AD_type.Sorted = true;
            this.CB_AD_type.TabIndex = 42;
            this.CB_AD_type.SelectedIndexChanged += new System.EventHandler(this.C_AD_type_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(704, 312);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 17);
            this.label8.TabIndex = 41;
            this.label8.Text = "نوع الاقامة ";
            // 
            // txt_time
            // 
            this.txt_time.Location = new System.Drawing.Point(494, 247);
            this.txt_time.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_time.Name = "txt_time";
            this.txt_time.Size = new System.Drawing.Size(87, 24);
            this.txt_time.TabIndex = 37;
            this.txt_time.Text = "0";
            this.txt_time.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.txt_time.Leave += new System.EventHandler(this.txt_time_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(587, 250);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 17);
            this.label7.TabIndex = 38;
            this.label7.Text = "الحد الفاصل للحساب  بالساعة ";
            // 
            // Controles
            // 
            this.Controles.BackColor = System.Drawing.SystemColors.Control;
            this.Controles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Controles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.C_Exit,
            this.toolStripSeparator1,
            this.C_Save,
            this.C_Ok,
            this.toolStripSeparator2});
            this.Controles.Location = new System.Drawing.Point(0, 0);
            this.Controles.Name = "Controles";
            this.Controles.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Controles.Size = new System.Drawing.Size(804, 26);
            this.Controles.TabIndex = 37;
            this.Controles.Text = "Controles";
            // 
            // A_FRM_Add_Accommodation_Degree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 435);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Controles);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "A_FRM_Add_Accommodation_Degree";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "إضافة درجة إقامة ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Controles.ResumeLayout(false);
            this.Controles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox CB_Status;
        public System.Windows.Forms.CheckBox C_default;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox Txt_ename;
        public System.Windows.Forms.TextBox Txt_aname;
        public System.Windows.Forms.TextBox Txt_id;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton C_Ok;
        public System.Windows.Forms.ToolStripButton C_Save;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton C_Exit;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox txt_time;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.ToolStrip Controles;
        public System.Windows.Forms.ComboBox CB_Acc_Type;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox CB_AD_type;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox CB_Col_Type;
        public System.Windows.Forms.Label label5;
    }
}