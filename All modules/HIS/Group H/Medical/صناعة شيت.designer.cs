namespace HIS
{
    partial class صناعة_شيت
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
            this.خروجToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.اضافةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.medicalSheetNewHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.pHISDataSet2 = new HIS.PHISDataSet2();
            this.مسحToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.صفحةجديدةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.صفحةجديدةToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.طباعةToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.medicalSheetNewPageBindingSource = new System.Windows.Forms.BindingSource(this.components);
           // this.pHISDataSet1 = new HIS.PHISDataSet1();
            //this.medicalSheet_NewPageTableAdapter = new HIS.PHISDataSet1TableAdapters.MedicalSheet_NewPageTableAdapter();
            //this.medicalSheet_NewHeaderTableAdapter = new HIS.PHISDataSet2TableAdapters.MedicalSheet_NewHeaderTableAdapter();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.medicalSheetNewHeaderBindingSource)).BeginInit();
           // ((System.ComponentModel.ISupportInitialize)(this.pHISDataSet2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medicalSheetNewPageBindingSource)).BeginInit();
            //((System.ComponentModel.ISupportInitialize)(this.pHISDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // خروجToolStripMenuItem
            // 
            this.خروجToolStripMenuItem.Name = "خروجToolStripMenuItem";
            this.خروجToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.خروجToolStripMenuItem.Text = "خروج";
            this.خروجToolStripMenuItem.Click += new System.EventHandler(this.خروجToolStripMenuItem_Click);
            // 
            // اضافةToolStripMenuItem
            // 
            this.اضافةToolStripMenuItem.Name = "اضافةToolStripMenuItem";
            this.اضافةToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.اضافةToolStripMenuItem.Text = "اضافة";
            this.اضافةToolStripMenuItem.Click += new System.EventHandler(this.اضافةToolStripMenuItem_Click_1);
            // 
            // listBox2
            // 
            this.listBox2.DataSource = this.medicalSheetNewHeaderBindingSource;
            this.listBox2.DisplayMember = "Arabic_Header_Name";
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(665, 196);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(129, 108);
            this.listBox2.TabIndex = 15;
            this.listBox2.ValueMember = "Page_Id";
            // 
            // medicalSheetNewHeaderBindingSource
            // 
            this.medicalSheetNewHeaderBindingSource.DataMember = "MedicalSheet_NewHeader";
           // this.medicalSheetNewHeaderBindingSource.DataSource = this.pHISDataSet2;
            // 
            // pHISDataSet2
            // 
           // this.pHISDataSet2.DataSetName = "PHISDataSet2";
            //this.pHISDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // مسحToolStripMenuItem
            // 
            this.مسحToolStripMenuItem.Name = "مسحToolStripMenuItem";
            this.مسحToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.مسحToolStripMenuItem.Text = "حذف";
            this.مسحToolStripMenuItem.Click += new System.EventHandler(this.مسحToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.صفحةجديدةToolStripMenuItem,
            this.صفحةجديدةToolStripMenuItem1,
            this.طباعةToolStripMenuItem,
            this.مسحToolStripMenuItem,
            this.اضافةToolStripMenuItem,
            this.خروجToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(469, 9);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(349, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // صفحةجديدةToolStripMenuItem
            // 
            this.صفحةجديدةToolStripMenuItem.Name = "صفحةجديدةToolStripMenuItem";
            this.صفحةجديدةToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.صفحةجديدةToolStripMenuItem.Text = "عنوان جديد";
            this.صفحةجديدةToolStripMenuItem.Click += new System.EventHandler(this.صفحةجديدةToolStripMenuItem_Click);
            // 
            // صفحةجديدةToolStripMenuItem1
            // 
            this.صفحةجديدةToolStripMenuItem1.Name = "صفحةجديدةToolStripMenuItem1";
            this.صفحةجديدةToolStripMenuItem1.Size = new System.Drawing.Size(82, 20);
            this.صفحةجديدةToolStripMenuItem1.Text = "صفحة جديدة";
            this.صفحةجديدةToolStripMenuItem1.Click += new System.EventHandler(this.صفحةجديدةToolStripMenuItem1_Click_1);
            // 
            // طباعةToolStripMenuItem
            // 
            this.طباعةToolStripMenuItem.Name = "طباعةToolStripMenuItem";
            this.طباعةToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.طباعةToolStripMenuItem.Text = "طباعة";
            this.طباعةToolStripMenuItem.Click += new System.EventHandler(this.طباعةToolStripMenuItem_Click_1);
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.medicalSheetNewPageBindingSource;
            this.listBox1.DisplayMember = "Arabic_Page_name";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(665, 63);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(129, 108);
            this.listBox1.TabIndex = 21;
            this.listBox1.ValueMember = "Sheet_Id";
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged_1);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick_1);
            // 
            // medicalSheetNewPageBindingSource
            // 
            this.medicalSheetNewPageBindingSource.DataMember = "MedicalSheet_NewPage";
            //this.medicalSheetNewPageBindingSource.DataSource = this.pHISDataSet1;
            // 
            // pHISDataSet1
            // 
           // this.pHISDataSet1.DataSetName = "PHISDataSet1";
            //this.pHISDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // medicalSheet_NewPageTableAdapter
            // 
          //  this.medicalSheet_NewPageTableAdapter.ClearBeforeFill = true;
            // 
            // medicalSheet_NewHeaderTableAdapter
            // 
          //  this.medicalSheet_NewHeaderTableAdapter.ClearBeforeFill = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(12, 19);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(138, 24);
            this.linkLabel1.TabIndex = 22;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Doctor Desktop";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 63);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(139, 296);
            this.flowLayoutPanel1.TabIndex = 23;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(177, 63);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(170, 296);
            this.flowLayoutPanel2.TabIndex = 24;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Location = new System.Drawing.Point(391, 63);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(139, 296);
            this.flowLayoutPanel3.TabIndex = 24;
            // 
            // صناعة_شيت
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 400);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "صناعة_شيت";
            this.Text = "صناعة_شيت";
            this.Load += new System.EventHandler(this.صناعة_شيت_Load);
            this.MouseHover += new System.EventHandler(this.صناعة_شيت_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.medicalSheetNewHeaderBindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.pHISDataSet2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.medicalSheetNewPageBindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.pHISDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem خروجToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem اضافةToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ToolStripMenuItem مسحToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem صفحةجديدةToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem صفحةجديدةToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem طباعةToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        //private HIS.PHISDataSet1 pHISDataSet1;
        private System.Windows.Forms.BindingSource medicalSheetNewPageBindingSource;
       // private HIS.PHISDataSet1TableAdapters.MedicalSheet_NewPageTableAdapter medicalSheet_NewPageTableAdapter;
        //private HIS.PHISDataSet2 pHISDataSet2;
        private System.Windows.Forms.BindingSource medicalSheetNewHeaderBindingSource;
       // private HIS.PHISDataSet2TableAdapters.MedicalSheet_NewHeaderTableAdapter medicalSheet_NewHeaderTableAdapter;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
    }
}