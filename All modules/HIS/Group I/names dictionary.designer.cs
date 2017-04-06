namespace HIS
{
    partial class names_dictionary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(names_dictionary));
            this.gb3 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.cb_gendar = new System.Windows.Forms.ComboBox();
            this.btndelete = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_ardes = new System.Windows.Forms.TextBox();
            this.txt_endes = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.gb3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.gb1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb3
            // 
            this.gb3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb3.BackColor = System.Drawing.SystemColors.Control;
            this.gb3.Controls.Add(this.dataGridView2);
            this.gb3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gb3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gb3.Location = new System.Drawing.Point(12, 241);
            this.gb3.Name = "gb3";
            this.gb3.Size = new System.Drawing.Size(990, 286);
            this.gb3.TabIndex = 126;
            this.gb3.TabStop = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 19);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(974, 261);
            this.dataGridView2.TabIndex = 120;
            this.dataGridView2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView2_MouseClick);
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.SystemColors.Control;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_add.Location = new System.Drawing.Point(153, 128);
            this.btn_add.Name = "btn_add";
            this.btn_add.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_add.Size = new System.Drawing.Size(93, 34);
            this.btn_add.TabIndex = 125;
            this.btn_add.Text = "اضافة";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.SystemColors.Control;
            this.btn_search.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_search.Location = new System.Drawing.Point(292, 128);
            this.btn_search.Name = "btn_search";
            this.btn_search.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_search.Size = new System.Drawing.Size(93, 34);
            this.btn_search.TabIndex = 124;
            this.btn_search.Text = "بحــث";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // gb1
            // 
            this.gb1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gb1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.gb1.Controls.Add(this.cb_gendar);
            this.gb1.Controls.Add(this.btndelete);
            this.gb1.Controls.Add(this.btn_add);
            this.gb1.Controls.Add(this.btn_search);
            this.gb1.Controls.Add(this.label4);
            this.gb1.Controls.Add(this.label3);
            this.gb1.Controls.Add(this.label2);
            this.gb1.Controls.Add(this.label5);
            this.gb1.Controls.Add(this.txt_ardes);
            this.gb1.Controls.Add(this.txt_endes);
            this.gb1.Controls.Add(this.txt_name);
            this.gb1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gb1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb1.Location = new System.Drawing.Point(161, 61);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(841, 174);
            this.gb1.TabIndex = 123;
            this.gb1.TabStop = false;
            // 
            // cb_gendar
            // 
            this.cb_gendar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_gendar.FormattingEnabled = true;
            this.cb_gendar.Items.AddRange(new object[] {
            "انثى ",
            "ذكر",
            "       "});
            this.cb_gendar.Location = new System.Drawing.Point(495, 133);
            this.cb_gendar.Name = "cb_gendar";
            this.cb_gendar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cb_gendar.Size = new System.Drawing.Size(220, 27);
            this.cb_gendar.TabIndex = 126;
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.SystemColors.Control;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btndelete.Location = new System.Drawing.Point(18, 128);
            this.btndelete.Name = "btndelete";
            this.btndelete.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btndelete.Size = new System.Drawing.Size(93, 34);
            this.btndelete.TabIndex = 125;
            this.btndelete.Text = "حذف";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 83);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(132, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "الوصـف بالانجليـزى";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(721, 85);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(114, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "الوصـف بالعربـى";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(732, 28);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(103, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "للبحث بالاسم";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(786, 136);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(41, 19);
            this.label5.TabIndex = 5;
            this.label5.Text = "النوع";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_ardes
            // 
            this.txt_ardes.Location = new System.Drawing.Point(495, 83);
            this.txt_ardes.Name = "txt_ardes";
            this.txt_ardes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_ardes.Size = new System.Drawing.Size(220, 27);
            this.txt_ardes.TabIndex = 4;
            this.txt_ardes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_ardes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_ardes_KeyPress);
            // 
            // txt_endes
            // 
            this.txt_endes.Location = new System.Drawing.Point(18, 83);
            this.txt_endes.Name = "txt_endes";
            this.txt_endes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_endes.Size = new System.Drawing.Size(333, 27);
            this.txt_endes.TabIndex = 3;
            this.txt_endes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_endes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_endes_KeyPress);
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(18, 25);
            this.txt_name.Name = "txt_name";
            this.txt_name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_name.Size = new System.Drawing.Size(697, 27);
            this.txt_name.TabIndex = 1;
            this.txt_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_name_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btn_exit);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(904, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(98, 46);
            this.panel1.TabIndex = 127;
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(5, 3);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(89, 40);
            this.btn_exit.TabIndex = 97;
            this.btn_exit.Text = "خروج";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // names_dictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1014, 539);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gb3);
            this.Controls.Add(this.gb1);
            this.Name = "names_dictionary";
            this.Text = "اعدادات قاموس الاسماء";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.names_dictionary_Load);
            this.gb3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.GroupBox gb1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ardes;
        private System.Windows.Forms.TextBox txt_endes;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.ComboBox cb_gendar;
        private System.Windows.Forms.Label label5;
    }
}