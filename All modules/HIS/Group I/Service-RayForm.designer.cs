namespace HIS
{
    partial class Service_Ray
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbox_Ray_cato = new System.Windows.Forms.ListBox();
            this.txtServiceCode = new System.Windows.Forms.TextBox();
            this.lbl_service_code = new System.Windows.Forms.Label();
            this.txtpatient_code = new System.Windows.Forms.TextBox();
            this.lbl_patient_code = new System.Windows.Forms.Label();
            this.txtArabic_name = new System.Windows.Forms.TextBox();
            this.lbl_arabic_name = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_patient_info = new System.Windows.Forms.DataGridView();
            this.dgv_ray_service = new System.Windows.Forms.DataGridView();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcurrent = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btn_current = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gbService_info = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dgv_current_sevice = new System.Windows.Forms.DataGridView();
            this.gbPatient_info = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_patient_info)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ray_service)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.gbService_info.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_current_sevice)).BeginInit();
            this.gbPatient_info.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.linkLabel4);
            this.groupBox5.Controls.Add(this.linkLabel5);
            this.groupBox5.Controls.Add(this.linkLabel1);
            this.groupBox5.Location = new System.Drawing.Point(999, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(248, 26);
            this.groupBox5.TabIndex = 98;
            this.groupBox5.TabStop = false;
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.linkLabel4.Location = new System.Drawing.Point(137, 8);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(41, 19);
            this.linkLabel4.TabIndex = 96;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "اللغة";
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Font = new System.Drawing.Font("Tahoma", 12F);
            this.linkLabel5.Location = new System.Drawing.Point(66, 8);
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
            this.linkLabel1.Location = new System.Drawing.Point(184, 8);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(44, 19);
            this.linkLabel1.TabIndex = 95;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "خروج";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked_2);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(855, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 19);
            this.label5.TabIndex = 17;
            this.label5.Text = "التاريخ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(605, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 19);
            this.label4.TabIndex = 16;
            this.label4.Text = "النوع";
            // 
            // lbox_Ray_cato
            // 
            this.lbox_Ray_cato.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbox_Ray_cato.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbox_Ray_cato.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbox_Ray_cato.FormattingEnabled = true;
            this.lbox_Ray_cato.ItemHeight = 19;
            this.lbox_Ray_cato.Items.AddRange(new object[] {
            "أشعة مقطعية",
            "اشعة كاملة"});
            this.lbox_Ray_cato.Location = new System.Drawing.Point(6, 35);
            this.lbox_Ray_cato.Name = "lbox_Ray_cato";
            this.lbox_Ray_cato.Size = new System.Drawing.Size(180, 213);
            this.lbox_Ray_cato.TabIndex = 0;
            this.lbox_Ray_cato.SelectedValueChanged += new System.EventHandler(this.lbox_Ray_cato_SelectedValueChanged);
            // 
            // txtServiceCode
            // 
            this.txtServiceCode.Location = new System.Drawing.Point(435, 29);
            this.txtServiceCode.Name = "txtServiceCode";
            this.txtServiceCode.Size = new System.Drawing.Size(135, 27);
            this.txtServiceCode.TabIndex = 8;
            this.txtServiceCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtServiceCode_KeyPress);
            // 
            // lbl_service_code
            // 
            this.lbl_service_code.AutoSize = true;
            this.lbl_service_code.Location = new System.Drawing.Point(576, 29);
            this.lbl_service_code.Name = "lbl_service_code";
            this.lbl_service_code.Size = new System.Drawing.Size(87, 19);
            this.lbl_service_code.TabIndex = 5;
            this.lbl_service_code.Text = "كود الخدمة ";
            // 
            // txtpatient_code
            // 
            this.txtpatient_code.Location = new System.Drawing.Point(679, 26);
            this.txtpatient_code.Name = "txtpatient_code";
            this.txtpatient_code.Size = new System.Drawing.Size(135, 27);
            this.txtpatient_code.TabIndex = 9;
            this.txtpatient_code.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpatient_code_KeyPress);
            // 
            // lbl_patient_code
            // 
            this.lbl_patient_code.AutoSize = true;
            this.lbl_patient_code.Location = new System.Drawing.Point(820, 29);
            this.lbl_patient_code.Name = "lbl_patient_code";
            this.lbl_patient_code.Size = new System.Drawing.Size(85, 19);
            this.lbl_patient_code.TabIndex = 6;
            this.lbl_patient_code.Text = "كود المريض";
            // 
            // txtArabic_name
            // 
            this.txtArabic_name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtArabic_name.Location = new System.Drawing.Point(914, 26);
            this.txtArabic_name.Name = "txtArabic_name";
            this.txtArabic_name.Size = new System.Drawing.Size(135, 27);
            this.txtArabic_name.TabIndex = 10;
            this.txtArabic_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtArabic_name_KeyPress);
            // 
            // lbl_arabic_name
            // 
            this.lbl_arabic_name.AutoSize = true;
            this.lbl_arabic_name.Location = new System.Drawing.Point(1055, 23);
            this.lbl_arabic_name.Name = "lbl_arabic_name";
            this.lbl_arabic_name.Size = new System.Drawing.Size(99, 19);
            this.lbl_arabic_name.TabIndex = 7;
            this.lbl_arabic_name.Text = "الأسم العربي";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lbox_Ray_cato);
            this.groupBox2.Location = new System.Drawing.Point(1031, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 294);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // dgv_patient_info
            // 
            this.dgv_patient_info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_patient_info.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_patient_info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_patient_info.Location = new System.Drawing.Point(6, 26);
            this.dgv_patient_info.Name = "dgv_patient_info";
            this.dgv_patient_info.Size = new System.Drawing.Size(993, 145);
            this.dgv_patient_info.TabIndex = 12;
            this.dgv_patient_info.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_patient_info_MouseClick);
            // 
            // dgv_ray_service
            // 
            this.dgv_ray_service.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ray_service.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ray_service.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ray_service.Location = new System.Drawing.Point(6, 26);
            this.dgv_ray_service.Name = "dgv_ray_service";
            this.dgv_ray_service.Size = new System.Drawing.Size(993, 61);
            this.dgv_ray_service.TabIndex = 11;
            this.dgv_ray_service.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_ray_service_MouseClick);
            // 
            // cbGender
            // 
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.FormattingEnabled = true;
            this.cbGender.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbGender.Items.AddRange(new object[] {
            "ذكر ",
            "انثي"});
            this.cbGender.Location = new System.Drawing.Point(449, 71);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(121, 27);
            this.cbGender.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(676, 67);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(173, 27);
            this.dateTimePicker1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1237, 532);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "الشكل العام ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtcurrent);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.btn_current);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.numQuantity);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cbGender);
            this.groupBox3.Controls.Add(this.dateTimePicker1);
            this.groupBox3.Controls.Add(this.txtServiceCode);
            this.groupBox3.Controls.Add(this.lbl_service_code);
            this.groupBox3.Controls.Add(this.txtpatient_code);
            this.groupBox3.Controls.Add(this.lbl_patient_code);
            this.groupBox3.Controls.Add(this.txtArabic_name);
            this.groupBox3.Controls.Add(this.lbl_arabic_name);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1225, 520);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1095, 389);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 19);
            this.label7.TabIndex = 29;
            this.label7.Text = "إلغاء خدمة رقم";
            // 
            // txtcurrent
            // 
            this.txtcurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcurrent.Location = new System.Drawing.Point(1055, 426);
            this.txtcurrent.Name = "txtcurrent";
            this.txtcurrent.Size = new System.Drawing.Size(100, 27);
            this.txtcurrent.TabIndex = 28;
            this.txtcurrent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcurrent_KeyPress);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(1055, 469);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 34);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "إلغاء الخدمة";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btn_current
            // 
            this.btn_current.Location = new System.Drawing.Point(8, 74);
            this.btn_current.Name = "btn_current";
            this.btn_current.Size = new System.Drawing.Size(122, 32);
            this.btn_current.TabIndex = 22;
            this.btn_current.Text = "الخدمات الحالية ";
            this.btn_current.UseVisualStyleBackColor = true;
            this.btn_current.Click += new System.EventHandler(this.btn_current_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 19);
            this.label1.TabIndex = 21;
            this.label1.Text = "الكمية";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(218, 26);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(64, 27);
            this.numQuantity.TabIndex = 20;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(136, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 33);
            this.button1.TabIndex = 19;
            this.button1.Text = "طلب";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.gbService_info);
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Controls.Add(this.gbPatient_info);
            this.groupBox4.Location = new System.Drawing.Point(8, 112);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1017, 402);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            // 
            // gbService_info
            // 
            this.gbService_info.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbService_info.Controls.Add(this.dgv_ray_service);
            this.gbService_info.Location = new System.Drawing.Point(6, 209);
            this.gbService_info.Name = "gbService_info";
            this.gbService_info.Size = new System.Drawing.Size(1005, 98);
            this.gbService_info.TabIndex = 16;
            this.gbService_info.TabStop = false;
            this.gbService_info.Text = "تفاصيل الخدمة";
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.dgv_current_sevice);
            this.groupBox7.Location = new System.Drawing.Point(12, 302);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(993, 94);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "الأشعة المطلوبة ";
            // 
            // dgv_current_sevice
            // 
            this.dgv_current_sevice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_current_sevice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_current_sevice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_current_sevice.Location = new System.Drawing.Point(6, 26);
            this.dgv_current_sevice.Name = "dgv_current_sevice";
            this.dgv_current_sevice.Size = new System.Drawing.Size(981, 62);
            this.dgv_current_sevice.TabIndex = 13;
            this.dgv_current_sevice.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgv_current_sevice_MouseClick);
            // 
            // gbPatient_info
            // 
            this.gbPatient_info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPatient_info.Controls.Add(this.dgv_patient_info);
            this.gbPatient_info.Location = new System.Drawing.Point(6, 26);
            this.gbPatient_info.Name = "gbPatient_info";
            this.gbPatient_info.Size = new System.Drawing.Size(1005, 177);
            this.gbPatient_info.TabIndex = 14;
            this.gbPatient_info.TabStop = false;
            this.gbPatient_info.Text = "بيانات المريض";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.tabControl1.Location = new System.Drawing.Point(6, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1245, 564);
            this.tabControl1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(-12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1257, 602);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // Service_Ray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 626);
            this.Controls.Add(this.groupBox1);
            this.Name = "Service_Ray";
            this.Text = "خدمة طلب اشعة ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Service_Ray_FormClosed);
            this.Load += new System.EventHandler(this.Service_Ray_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Service_Ray_KeyPress);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_patient_info)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ray_service)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.gbService_info.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_current_sevice)).EndInit();
            this.gbPatient_info.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbox_Ray_cato;
        private System.Windows.Forms.TextBox txtServiceCode;
        private System.Windows.Forms.Label lbl_service_code;
        private System.Windows.Forms.TextBox txtpatient_code;
        private System.Windows.Forms.Label lbl_patient_code;
        private System.Windows.Forms.TextBox txtArabic_name;
        private System.Windows.Forms.Label lbl_arabic_name;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_patient_info;
        private System.Windows.Forms.DataGridView dgv_ray_service;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btn_current;
        private System.Windows.Forms.DataGridView dgv_current_sevice;
        private System.Windows.Forms.GroupBox gbPatient_info;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox gbService_info;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtcurrent;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip1;


    }
}