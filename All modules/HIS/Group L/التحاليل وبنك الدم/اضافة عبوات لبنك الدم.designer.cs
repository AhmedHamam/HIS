namespace HIS
{
    partial class اضافة_عبوات_لبنك_الدم
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
            this.dtExDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbRH = new System.Windows.Forms.ComboBox();
            this.cbBloodFaction = new System.Windows.Forms.ComboBox();
            this.cbBloodType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtQuntity = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtExDate
            // 
            this.dtExDate.Location = new System.Drawing.Point(38, 265);
            this.dtExDate.Name = "dtExDate";
            this.dtExDate.Size = new System.Drawing.Size(200, 20);
            this.dtExDate.TabIndex = 96;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 95;
            this.label4.Text = "تاريخ الصلاحية";
            // 
            // cbRH
            // 
            this.cbRH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRH.FormattingEnabled = true;
            this.cbRH.Items.AddRange(new object[] {
            "+",
            "-"});
            this.cbRH.Location = new System.Drawing.Point(40, 213);
            this.cbRH.Name = "cbRH";
            this.cbRH.Size = new System.Drawing.Size(200, 21);
            this.cbRH.TabIndex = 94;
            // 
            // cbBloodFaction
            // 
            this.cbBloodFaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBloodFaction.FormattingEnabled = true;
            this.cbBloodFaction.Items.AddRange(new object[] {
            "A",
            "B",
            "O",
            "AB"});
            this.cbBloodFaction.Location = new System.Drawing.Point(40, 163);
            this.cbBloodFaction.Name = "cbBloodFaction";
            this.cbBloodFaction.Size = new System.Drawing.Size(200, 21);
            this.cbBloodFaction.TabIndex = 93;
            // 
            // cbBloodType
            // 
            this.cbBloodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBloodType.FormattingEnabled = true;
            this.cbBloodType.Items.AddRange(new object[] {
            "دم كامل",
            "بلازما"});
            this.cbBloodType.Location = new System.Drawing.Point(40, 111);
            this.cbBloodType.Name = "cbBloodType";
            this.cbBloodType.Size = new System.Drawing.Size(200, 21);
            this.cbBloodType.TabIndex = 92;
            this.cbBloodType.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(320, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 91;
            this.label7.Text = "RH";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(304, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 90;
            this.label8.Text = "الفصيله";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(313, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 89;
            this.label9.Text = "النوع";
            // 
            // txtQuntity
            // 
            this.txtQuntity.Location = new System.Drawing.Point(38, 63);
            this.txtQuntity.Name = "txtQuntity";
            this.txtQuntity.Size = new System.Drawing.Size(200, 20);
            this.txtQuntity.TabIndex = 86;
            this.txtQuntity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuntity_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(309, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 85;
            this.label11.Text = "الكمية";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(375, 25);
            this.toolStrip1.TabIndex = 97;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(34, 22);
            this.toolStripLabel1.Text = "أضافة";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel2.Text = "خروج";
            this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // اضافة_عبوات_لبنك_الدم
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 336);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dtExDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbRH);
            this.Controls.Add(this.cbBloodFaction);
            this.Controls.Add(this.cbBloodType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtQuntity);
            this.Controls.Add(this.label11);
            this.Name = "اضافة_عبوات_لبنك_الدم";
            this.Text = "اضافة_عبوات_لبنك_الدم";
            this.Load += new System.EventHandler(this.اضافة_عبوات_لبنك_الدم_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtExDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbRH;
        private System.Windows.Forms.ComboBox cbBloodFaction;
        private System.Windows.Forms.ComboBox cbBloodType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtQuntity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
    }
}