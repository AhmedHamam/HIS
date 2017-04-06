namespace HIS
{
    partial class البنود
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIemname = new System.Windows.Forms.TextBox();
            this.txtCreditvalue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.add = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemid = new System.Windows.Forms.TextBox();
            this.clear = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.update = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(776, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "اسم البند";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(745, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "قيمة الاعتماد";
            // 
            // txtIemname
            // 
            this.txtIemname.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtIemname.Location = new System.Drawing.Point(582, 130);
            this.txtIemname.Name = "txtIemname";
            this.txtIemname.Size = new System.Drawing.Size(143, 21);
            this.txtIemname.TabIndex = 4;
            this.txtIemname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIemname_KeyPress);
            // 
            // txtCreditvalue
            // 
            this.txtCreditvalue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCreditvalue.Location = new System.Drawing.Point(582, 174);
            this.txtCreditvalue.Name = "txtCreditvalue";
            this.txtCreditvalue.Size = new System.Drawing.Size(143, 21);
            this.txtCreditvalue.TabIndex = 5;
            this.txtCreditvalue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCreditvalue_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(771, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "اسم الباب";
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(93, 126);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(96, 38);
            this.add.TabIndex = 10;
            this.add.Text = "اضافة";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label7.Location = new System.Drawing.Point(256, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 44);
            this.label7.TabIndex = 13;
            this.label7.Text = "البنود";
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(93, 371);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(96, 38);
            this.delete.TabIndex = 14;
            this.delete.Text = "حذف";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(93, 314);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(96, 38);
            this.search.TabIndex = 15;
            this.search.Text = "بحث";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(256, 333);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(615, 185);
            this.dataGridView1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(788, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "رقم البند";
            // 
            // txtItemid
            // 
            this.txtItemid.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtItemid.Location = new System.Drawing.Point(581, 79);
            this.txtItemid.Name = "txtItemid";
            this.txtItemid.Size = new System.Drawing.Size(143, 21);
            this.txtItemid.TabIndex = 18;
            this.txtItemid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemid_KeyPress);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(93, 187);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(96, 38);
            this.clear.TabIndex = 21;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(581, 225);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(144, 31);
            this.comboBox1.TabIndex = 23;
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(93, 250);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(96, 38);
            this.update.TabIndex = 24;
            this.update.Text = "تعديل";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // البنود
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(924, 525);
            this.Controls.Add(this.update);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.txtItemid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCreditvalue);
            this.Controls.Add(this.txtIemname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.add);
            this.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "البنود";
            this.ShowIcon = false;
            this.Text = "البنود";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIemname;
        private System.Windows.Forms.TextBox txtCreditvalue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItemid;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button update;
    }
}