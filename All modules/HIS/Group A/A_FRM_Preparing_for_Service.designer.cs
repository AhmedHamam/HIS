namespace HIS
{
    partial class A_FRM_Preparing_for_Service
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(A_FRM_Preparing_for_Service));
            this.DGV = new System.Windows.Forms.DataGridView();
            this.Controles = new System.Windows.Forms.ToolStrip();
            this.C_Exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.C_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.C_Ok = new System.Windows.Forms.ToolStripButton();
            this.C_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.C_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.C_Help = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.Controles.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.DGV.Location = new System.Drawing.Point(0, 24);
            this.DGV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGV.RowHeadersWidth = 20;
            this.DGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(609, 401);
            this.DGV.TabIndex = 32;
            this.DGV.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGV_EditingControlShowing);
            // 
            // Controles
            // 
            this.Controles.BackColor = System.Drawing.SystemColors.Control;
            this.Controles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.C_Exit,
            this.toolStripSeparator1,
            this.C_Add,
            this.toolStripSeparator4,
            this.C_Ok,
            this.C_Save,
            this.toolStripSeparator2,
            this.C_Delete,
            this.toolStripSeparator3,
            this.C_Help});
            this.Controles.Location = new System.Drawing.Point(0, 0);
            this.Controles.Name = "Controles";
            this.Controles.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Controles.Size = new System.Drawing.Size(668, 25);
            this.Controles.TabIndex = 40;
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
            // C_Add
            // 
            this.C_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.C_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.C_Add.Name = "C_Add";
            this.C_Add.Size = new System.Drawing.Size(41, 22);
            this.C_Add.Text = "إضافة ";
            this.C_Add.Click += new System.EventHandler(this.C_Add_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // C_Ok
            // 
            this.C_Ok.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.C_Ok.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.C_Ok.Name = "C_Ok";
            this.C_Ok.Size = new System.Drawing.Size(35, 22);
            this.C_Ok.Text = "موافق";
            this.C_Ok.ToolTipText = "موافق";
            this.C_Ok.Click += new System.EventHandler(this.C_Ok_Click);
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
            // C_Delete
            // 
            this.C_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.C_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.C_Delete.Name = "C_Delete";
            this.C_Delete.Size = new System.Drawing.Size(35, 22);
            this.C_Delete.Text = "حذف ";
            this.C_Delete.Click += new System.EventHandler(this.C_Delete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // C_Help
            // 
            this.C_Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.C_Help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.C_Help.Name = "C_Help";
            this.C_Help.Size = new System.Drawing.Size(49, 22);
            this.C_Help.Text = "مساعدة ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.DGV);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.groupBox1.Location = new System.Drawing.Point(27, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(609, 425);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // A_FRM_Preparing_for_Service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 465);
            this.Controls.Add(this.Controles);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "A_FRM_Preparing_for_Service";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الاعداد للخدمات ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.A_FRM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.Controles.ResumeLayout(false);
            this.Controles.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView DGV;
        public System.Windows.Forms.ToolStrip Controles;
        public System.Windows.Forms.ToolStripButton C_Exit;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton C_Add;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        public System.Windows.Forms.ToolStripButton C_Ok;
        public System.Windows.Forms.ToolStripButton C_Save;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton C_Delete;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripButton C_Help;
        public System.Windows.Forms.GroupBox groupBox1;
    }
}