namespace HIS
{
    partial class detergentForm
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
            this.description = new System.Windows.Forms.LinkLabel();
            this.help = new System.Windows.Forms.LinkLabel();
            this.delete = new System.Windows.Forms.LinkLabel();
            this.add = new System.Windows.Forms.LinkLabel();
            this.exit = new System.Windows.Forms.LinkLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.quantity = new System.Windows.Forms.TextBox();
            this.det_id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.detName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(106, 9);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(65, 13);
            this.description.TabIndex = 27;
            this.description.TabStop = true;
            this.description.Text = "وصف الحقول";
            // 
            // help
            // 
            this.help.AutoSize = true;
            this.help.Location = new System.Drawing.Point(193, 9);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(33, 13);
            this.help.TabIndex = 28;
            this.help.TabStop = true;
            this.help.Text = "تعديل";
            this.help.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.help_LinkClicked);
            // 
            // delete
            // 
            this.delete.AutoSize = true;
            this.delete.Location = new System.Drawing.Point(268, 9);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(30, 13);
            this.delete.TabIndex = 24;
            this.delete.TabStop = true;
            this.delete.Text = "حذف";
            this.delete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.delete_LinkClicked);
            // 
            // add
            // 
            this.add.AutoSize = true;
            this.add.Location = new System.Drawing.Point(324, 9);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(33, 13);
            this.add.TabIndex = 25;
            this.add.TabStop = true;
            this.add.Text = "اضافة";
            this.add.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.add_LinkClicked);
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Location = new System.Drawing.Point(365, 9);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(31, 13);
            this.exit.TabIndex = 26;
            this.exit.TabStop = true;
            this.exit.Text = "خروج";
            this.exit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.exit_LinkClicked);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 287);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(417, 107);
            this.dataGridView1.TabIndex = 23;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(39, 201);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(200, 20);
            this.quantity.TabIndex = 21;
            this.quantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.quantity_KeyPress);
            // 
            // det_id
            // 
            this.det_id.Enabled = false;
            this.det_id.Location = new System.Drawing.Point(39, 138);
            this.det_id.Name = "det_id";
            this.det_id.ReadOnly = true;
            this.det_id.Size = new System.Drawing.Size(200, 20);
            this.det_id.TabIndex = 20;
            this.det_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.det_id_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(324, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "كمية المسحوق";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(324, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "كود المسحوق";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 45);
            this.label1.TabIndex = 18;
            this.label1.Text = "المساحيق";
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(39, 242);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(200, 20);
            this.price.TabIndex = 30;
            this.price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.price_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "السعر";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(324, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "اسم المسحوق";
            // 
            // detName
            // 
            this.detName.Location = new System.Drawing.Point(39, 169);
            this.detName.Name = "detName";
            this.detName.Size = new System.Drawing.Size(200, 20);
            this.detName.TabIndex = 32;
            this.detName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.detName_KeyPress);
            // 
            // detergentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 400);
            this.Controls.Add(this.detName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.price);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.description);
            this.Controls.Add(this.help);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.quantity);
            this.Controls.Add(this.det_id);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "detergentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "المساحيق";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel description;
        private System.Windows.Forms.LinkLabel help;
        private System.Windows.Forms.LinkLabel delete;
        private System.Windows.Forms.LinkLabel add;
        private System.Windows.Forms.LinkLabel exit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox quantity;
        private System.Windows.Forms.TextBox det_id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox detName;
    }
}

