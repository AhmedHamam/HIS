namespace HIS
{
    partial class A_FRM_Accommdation_Pricing
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_FRM_Accommdation_Pricing));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DGV1 = new System.Windows.Forms.DataGridView();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.Controles = new System.Windows.Forms.ToolStrip();
            this.C_Exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.C_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.C_Help = new System.Windows.Forms.ToolStripButton();
            this.txt_RP_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_RP_Search = new System.Windows.Forms.Button();
            this.txt_RP_id = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.Controles.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.DGV1);
            this.groupBox1.Controls.Add(this.DGV);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupBox1.Location = new System.Drawing.Point(0, 93);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(836, 341);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            // 
            // DGV1
            // 
            this.DGV1.AllowUserToAddRows = false;
            this.DGV1.AllowUserToDeleteRows = false;
            this.DGV1.AllowUserToResizeColumns = false;
            this.DGV1.AllowUserToResizeRows = false;
            this.DGV1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV1.ColumnHeadersHeight = 40;
            this.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV1.Dock = System.Windows.Forms.DockStyle.Right;
            this.DGV1.Location = new System.Drawing.Point(532, 24);
            this.DGV1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGV1.MultiSelect = false;
            this.DGV1.Name = "DGV1";
            this.DGV1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGV1.RowHeadersWidth = 20;
            this.DGV1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV1.Size = new System.Drawing.Size(301, 313);
            this.DGV1.TabIndex = 33;
            this.DGV1.SelectionChanged += new System.EventHandler(this.DGV1_SelectionChanged);
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeColumns = false;
            this.DGV.AllowUserToResizeRows = false;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV.ColumnHeadersHeight = 40;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.NullValue = "0";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.DefaultCellStyle = dataGridViewCellStyle1;
            this.DGV.Location = new System.Drawing.Point(-3, 24);
            this.DGV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGV.RowHeadersVisible = false;
            this.DGV.RowHeadersWidth = 10;
            this.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(540, 315);
            this.DGV.TabIndex = 32;
            this.DGV.SelectionChanged += new System.EventHandler(this.DGV_SelectionChanged);
            // 
            // Controles
            // 
            this.Controles.BackColor = System.Drawing.SystemColors.Control;
            this.Controles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.C_Exit,
            this.toolStripSeparator1,
            this.C_Save,
            this.toolStripSeparator2,
            this.C_Help});
            this.Controles.Location = new System.Drawing.Point(0, 0);
            this.Controles.Name = "Controles";
            this.Controles.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Controles.Size = new System.Drawing.Size(836, 25);
            this.Controles.TabIndex = 46;
            this.Controles.Text = "Controles";
            // 
            // C_Exit
            // 
            this.C_Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.C_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.C_Exit.Name = "C_Exit";
            this.C_Exit.Size = new System.Drawing.Size(36, 22);
            this.C_Exit.Text = "خروج";
            this.C_Exit.Click += new System.EventHandler(this.C_Exit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // C_Save
            // 
            this.C_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.C_Save.Image = ((System.Drawing.Image)(resources.GetObject("C_Save.Image")));
            this.C_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.C_Save.Name = "C_Save";
            this.C_Save.Size = new System.Drawing.Size(33, 22);
            this.C_Save.Text = "حفظ ";
            this.C_Save.Click += new System.EventHandler(this.C_Save_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // C_Help
            // 
            this.C_Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.C_Help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.C_Help.Name = "C_Help";
            this.C_Help.Size = new System.Drawing.Size(49, 22);
            this.C_Help.Text = "مساعدة ";
            // 
            // txt_RP_name
            // 
            this.txt_RP_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_RP_name.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_RP_name.Location = new System.Drawing.Point(90, 56);
            this.txt_RP_name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_RP_name.Name = "txt_RP_name";
            this.txt_RP_name.ReadOnly = true;
            this.txt_RP_name.Size = new System.Drawing.Size(355, 24);
            this.txt_RP_name.TabIndex = 50;
            this.txt_RP_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.label1.Location = new System.Drawing.Point(675, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 17);
            this.label1.TabIndex = 51;
            this.label1.Text = "لائحة الأسعار ";
            // 
            // btn_RP_Search
            // 
            this.btn_RP_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_RP_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RP_Search.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btn_RP_Search.Location = new System.Drawing.Point(563, 54);
            this.btn_RP_Search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_RP_Search.Name = "btn_RP_Search";
            this.btn_RP_Search.Size = new System.Drawing.Size(86, 26);
            this.btn_RP_Search.TabIndex = 48;
            this.btn_RP_Search.Text = "بحث ";
            this.btn_RP_Search.UseVisualStyleBackColor = true;
            this.btn_RP_Search.Click += new System.EventHandler(this.btn_RP_Search_Click);
            // 
            // txt_RP_id
            // 
            this.txt_RP_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_RP_id.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_RP_id.Location = new System.Drawing.Point(451, 56);
            this.txt_RP_id.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_RP_id.Name = "txt_RP_id";
            this.txt_RP_id.ReadOnly = true;
            this.txt_RP_id.Size = new System.Drawing.Size(93, 24);
            this.txt_RP_id.TabIndex = 49;
            this.txt_RP_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_RP_id.TextChanged += new System.EventHandler(this.txt_RP_id_TextChanged);
            // 
            // A_FRM_Accommdation_Pricing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 453);
            this.Controls.Add(this.txt_RP_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_RP_Search);
            this.Controls.Add(this.txt_RP_id);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Controles);
            this.Name = "A_FRM_Accommdation_Pricing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تسعير درجات الاقامة ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.A_FRM_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.Controles.ResumeLayout(false);
            this.Controles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView DGV;
        public System.Windows.Forms.ToolStrip Controles;
        public System.Windows.Forms.ToolStripButton C_Exit;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton C_Save;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton C_Help;
        public System.Windows.Forms.DataGridView DGV1;
        public System.Windows.Forms.TextBox txt_RP_name;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btn_RP_Search;
        public System.Windows.Forms.TextBox txt_RP_id;
    }
}