namespace HIS
{
    partial class A_FRM_Contracting_Entities
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
            this.Controles = new System.Windows.Forms.ToolStrip();
            this.C_Exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.C_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.C_Delete = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.Controles.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // Controles
            // 
            this.Controles.BackColor = System.Drawing.SystemColors.Control;
            this.Controles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.C_Exit,
            this.toolStripSeparator1,
            this.C_Add,
            this.toolStripSeparator2,
            this.C_Delete});
            this.Controles.Location = new System.Drawing.Point(0, 0);
            this.Controles.Name = "Controles";
            this.Controles.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Controles.Size = new System.Drawing.Size(833, 25);
            this.Controles.TabIndex = 34;
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
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.DGV);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(833, 323);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "جهات التعاقد ";
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV.ColumnHeadersHeight = 40;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGV.Location = new System.Drawing.Point(3, 26);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGV.RowHeadersWidth = 20;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(824, 291);
            this.DGV.TabIndex = 32;
            // 
            // A_FRM_Contracting_Entities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 348);
            this.Controls.Add(this.Controles);
            this.Controls.Add(this.groupBox1);
            this.Name = "A_FRM_Contracting_Entities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جهات التعاقد ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.A_FRM_Contracting_Entities_Load);
            this.Controles.ResumeLayout(false);
            this.Controles.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ToolStrip Controles;
        public System.Windows.Forms.ToolStripButton C_Exit;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton C_Add;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton C_Delete;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView DGV;
    }
}