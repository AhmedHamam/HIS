namespace HIS
{
    partial class Request_a_mealForm
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
            this.components = new System.ComponentModel.Container();
            this.rbPatient = new System.Windows.Forms.RadioButton();
            this.cbStation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMealType = new System.Windows.Forms.ComboBox();
            this.rbFollower = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateExchange = new System.Windows.Forms.DateTimePicker();
            this.btnMealExchange = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_partner_number = new System.Windows.Forms.ComboBox();
            this.cb_account_number = new System.Windows.Forms.ComboBox();
            this.txtMealID = new System.Windows.Forms.TextBox();
            this.lblFollower = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_partner = new System.Windows.Forms.DataGridView();
            this.dgv_patient = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtmealCancelCode = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_partner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_patient)).BeginInit();
            this.SuspendLayout();
            // 
            // rbPatient
            // 
            this.rbPatient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbPatient.AutoSize = true;
            this.rbPatient.Location = new System.Drawing.Point(1020, 31);
            this.rbPatient.Name = "rbPatient";
            this.rbPatient.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbPatient.Size = new System.Drawing.Size(115, 23);
            this.rbPatient.TabIndex = 0;
            this.rbPatient.Text = "طلب للمريض";
            this.rbPatient.UseVisualStyleBackColor = true;
            this.rbPatient.CheckedChanged += new System.EventHandler(this.rbPatient_CheckedChanged);
            // 
            // cbStation
            // 
            this.cbStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStation.FormattingEnabled = true;
            this.cbStation.Items.AddRange(new object[] {
            "الدور الأول ",
            "الدول الثاني ",
            "الدور الثالث ",
            "الدور الرابع ",
            "الدور الخامس",
            "الدور السادس "});
            this.cbStation.Location = new System.Drawing.Point(306, 30);
            this.cbStation.Name = "cbStation";
            this.cbStation.Size = new System.Drawing.Size(161, 27);
            this.cbStation.TabIndex = 1;
            this.cbStation.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(473, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "وحدة التمريض";
            // 
            // cbMealType
            // 
            this.cbMealType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMealType.FormattingEnabled = true;
            this.cbMealType.Items.AddRange(new object[] {
            "الافطار",
            "الغداء ",
            "العشاء "});
            this.cbMealType.Location = new System.Drawing.Point(38, 92);
            this.cbMealType.Name = "cbMealType";
            this.cbMealType.Size = new System.Drawing.Size(161, 27);
            this.cbMealType.TabIndex = 1;
            this.cbMealType.SelectionChangeCommitted += new System.EventHandler(this.cbMealType_SelectionChangeCommitted);
            // 
            // rbFollower
            // 
            this.rbFollower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbFollower.AutoSize = true;
            this.rbFollower.Location = new System.Drawing.Point(1018, 75);
            this.rbFollower.Name = "rbFollower";
            this.rbFollower.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbFollower.Size = new System.Drawing.Size(117, 23);
            this.rbFollower.TabIndex = 0;
            this.rbFollower.Text = "طلب للمرافق";
            this.rbFollower.UseVisualStyleBackColor = true;
            this.rbFollower.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "الوجبة ";
            this.label3.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(492, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "وقت الصرف";
            this.label4.Click += new System.EventHandler(this.label2_Click);
            // 
            // dateExchange
            // 
            this.dateExchange.Location = new System.Drawing.Point(306, 84);
            this.dateExchange.Name = "dateExchange";
            this.dateExchange.Size = new System.Drawing.Size(161, 27);
            this.dateExchange.TabIndex = 4;
            // 
            // btnMealExchange
            // 
            this.btnMealExchange.Location = new System.Drawing.Point(267, 50);
            this.btnMealExchange.Name = "btnMealExchange";
            this.btnMealExchange.Size = new System.Drawing.Size(100, 40);
            this.btnMealExchange.TabIndex = 5;
            this.btnMealExchange.Text = "طلب وجبة";
            this.btnMealExchange.UseVisualStyleBackColor = true;
            this.btnMealExchange.Click += new System.EventHandler(this.btnMealExchange_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cb_partner_number);
            this.groupBox1.Controls.Add(this.cb_account_number);
            this.groupBox1.Controls.Add(this.txtMealID);
            this.groupBox1.Controls.Add(this.lblFollower);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.rbFollower);
            this.groupBox1.Controls.Add(this.rbPatient);
            this.groupBox1.Controls.Add(this.dateExchange);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbStation);
            this.groupBox1.Controls.Add(this.cbMealType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1141, 154);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // cb_partner_number
            // 
            this.cb_partner_number.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_partner_number.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_partner_number.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_partner_number.FormattingEnabled = true;
            this.cb_partner_number.Items.AddRange(new object[] {
            "1",
            "11",
            "111",
            "212",
            "12213",
            "422"});
            this.cb_partner_number.Location = new System.Drawing.Point(746, 76);
            this.cb_partner_number.Name = "cb_partner_number";
            this.cb_partner_number.Size = new System.Drawing.Size(139, 27);
            this.cb_partner_number.TabIndex = 9;
            this.cb_partner_number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_partner_number_KeyPress);
            // 
            // cb_account_number
            // 
            this.cb_account_number.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_account_number.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_account_number.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_account_number.FormattingEnabled = true;
            this.cb_account_number.Items.AddRange(new object[] {
            "1",
            "11",
            "111",
            "212",
            "12213",
            "422"});
            this.cb_account_number.Location = new System.Drawing.Point(746, 30);
            this.cb_account_number.Name = "cb_account_number";
            this.cb_account_number.Size = new System.Drawing.Size(139, 27);
            this.cb_account_number.TabIndex = 9;
            this.cb_account_number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_account_number_KeyPress);
            // 
            // txtMealID
            // 
            this.txtMealID.Location = new System.Drawing.Point(38, 31);
            this.txtMealID.Name = "txtMealID";
            this.txtMealID.ReadOnly = true;
            this.txtMealID.Size = new System.Drawing.Size(161, 27);
            this.txtMealID.TabIndex = 7;
            // 
            // lblFollower
            // 
            this.lblFollower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFollower.AutoSize = true;
            this.lblFollower.Location = new System.Drawing.Point(897, 75);
            this.lblFollower.Name = "lblFollower";
            this.lblFollower.Size = new System.Drawing.Size(89, 19);
            this.lblFollower.TabIndex = 6;
            this.lblFollower.Text = "رقم المرافق";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(217, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "كود الوجبة ";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(903, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "كود المريض";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.btnMealExchange);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupBox2.Location = new System.Drawing.Point(12, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1141, 109);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(97, 50);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(129, 40);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "استعلام وجبة";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.linkLabel4);
            this.groupBox5.Controls.Add(this.linkLabel5);
            this.groupBox5.Controls.Add(this.linkLabel1);
            this.groupBox5.Location = new System.Drawing.Point(905, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(248, 33);
            this.groupBox5.TabIndex = 99;
            this.groupBox5.TabStop = false;
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.linkLabel4.Location = new System.Drawing.Point(125, 9);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(41, 19);
            this.linkLabel4.TabIndex = 96;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "اللغة";
            this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Font = new System.Drawing.Font("Tahoma", 12F);
            this.linkLabel5.Location = new System.Drawing.Point(56, 9);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(65, 19);
            this.linkLabel5.TabIndex = 97;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "مساعدة";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.linkLabel1.Location = new System.Drawing.Point(172, 9);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(44, 19);
            this.linkLabel1.TabIndex = 95;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "خروج";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgv_partner);
            this.groupBox3.Controls.Add(this.dgv_patient);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupBox3.Location = new System.Drawing.Point(12, 307);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1141, 271);
            this.groupBox3.TabIndex = 100;
            this.groupBox3.TabStop = false;
            // 
            // dgv_partner
            // 
            this.dgv_partner.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_partner.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_partner.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_partner.Location = new System.Drawing.Point(29, 26);
            this.dgv_partner.Name = "dgv_partner";
            this.dgv_partner.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv_partner.Size = new System.Drawing.Size(1093, 218);
            this.dgv_partner.TabIndex = 1;
            this.dgv_partner.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dtaGfollower_MouseClick);
            // 
            // dgv_patient
            // 
            this.dgv_patient.AllowUserToAddRows = false;
            this.dgv_patient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_patient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_patient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_patient.Location = new System.Drawing.Point(16, 13);
            this.dgv_patient.Name = "dgv_patient";
            this.dgv_patient.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv_patient.Size = new System.Drawing.Size(1119, 241);
            this.dgv_patient.TabIndex = 0;
            this.dgv_patient.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dtaGpatient_MouseClick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.button1.Location = new System.Drawing.Point(28, 596);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 27);
            this.button1.TabIndex = 101;
            this.button1.Text = "إلغاء الوجبة المحددة";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label6.Location = new System.Drawing.Point(301, 596);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 19);
            this.label6.TabIndex = 102;
            this.label6.Text = "كود الوجبة";
            // 
            // txtmealCancelCode
            // 
            this.txtmealCancelCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtmealCancelCode.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtmealCancelCode.Location = new System.Drawing.Point(177, 596);
            this.txtmealCancelCode.Name = "txtmealCancelCode";
            this.txtmealCancelCode.Size = new System.Drawing.Size(100, 27);
            this.txtmealCancelCode.TabIndex = 103;
            this.txtmealCancelCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmealCancelCode_KeyPress);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "adsasdasddsa";
            // 
            // Request_a_mealForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 643);
            this.Controls.Add(this.txtmealCancelCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Request_a_mealForm";
            this.Text = "طلب وجبة";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Request_a_mealForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_partner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_patient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbPatient;
        private System.Windows.Forms.ComboBox cbStation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMealType;
        private System.Windows.Forms.RadioButton rbFollower;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateExchange;
        private System.Windows.Forms.Button btnMealExchange;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_patient;
        private System.Windows.Forms.TextBox txtMealID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_partner;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblFollower;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtmealCancelCode;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cb_account_number;
        private System.Windows.Forms.ComboBox cb_partner_number;
    }
}