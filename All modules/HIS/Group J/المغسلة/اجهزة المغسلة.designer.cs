namespace HIS
{
    partial class WM_device
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
            this.conditions = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.colores = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.kind = new System.Windows.Forms.TextBox();
            this.temp = new System.Windows.Forms.TextBox();
            this.description = new System.Windows.Forms.LinkLabel();
            this.help = new System.Windows.Forms.LinkLabel();
            this.delete = new System.Windows.Forms.LinkLabel();
            this.add = new System.Windows.Forms.LinkLabel();
            this.exit = new System.Windows.Forms.LinkLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.devName = new System.Windows.Forms.TextBox();
            this.dev_id = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.descriptions = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // conditions
            // 
            this.conditions.Location = new System.Drawing.Point(158, 264);
            this.conditions.Name = "conditions";
            this.conditions.Size = new System.Drawing.Size(200, 20);
            this.conditions.TabIndex = 55;
            this.conditions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.conditions_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(377, 264);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 54;
            this.label7.Text = "الحالة";
            // 
            // colores
            // 
            this.colores.Location = new System.Drawing.Point(535, 264);
            this.colores.Name = "colores";
            this.colores.Size = new System.Drawing.Size(200, 20);
            this.colores.TabIndex = 53;
            this.colores.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.colores_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(773, 267);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "اللون";
            // 
            // kind
            // 
            this.kind.Location = new System.Drawing.Point(158, 212);
            this.kind.Name = "kind";
            this.kind.Size = new System.Drawing.Size(200, 20);
            this.kind.TabIndex = 51;
            this.kind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kind_KeyPress);
            // 
            // temp
            // 
            this.temp.Font = new System.Drawing.Font("Tahoma", 8F);
            this.temp.Location = new System.Drawing.Point(535, 212);
            this.temp.Name = "temp";
            this.temp.Size = new System.Drawing.Size(200, 20);
            this.temp.TabIndex = 50;
            this.temp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.temp_KeyPress);
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(532, 8);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(65, 13);
            this.description.TabIndex = 48;
            this.description.TabStop = true;
            this.description.Text = "وصف الحقول";
            // 
            // help
            // 
            this.help.AutoSize = true;
            this.help.Location = new System.Drawing.Point(624, 9);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(33, 13);
            this.help.TabIndex = 49;
            this.help.TabStop = true;
            this.help.Text = "تعديل";
            this.help.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.help_LinkClicked);
            // 
            // delete
            // 
            this.delete.AutoSize = true;
            this.delete.Location = new System.Drawing.Point(706, 8);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(30, 13);
            this.delete.TabIndex = 45;
            this.delete.TabStop = true;
            this.delete.Text = "حذف";
            this.delete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.delete_LinkClicked);
            // 
            // add
            // 
            this.add.AutoSize = true;
            this.add.Location = new System.Drawing.Point(767, 8);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(33, 13);
            this.add.TabIndex = 46;
            this.add.TabStop = true;
            this.add.Text = "اضافة";
            this.add.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.add_LinkClicked);
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Location = new System.Drawing.Point(827, 8);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(31, 13);
            this.exit.TabIndex = 47;
            this.exit.TabStop = true;
            this.exit.Text = "خروج";
            this.exit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.exit_LinkClicked);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(78, 344);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(780, 150);
            this.dataGridView1.TabIndex = 44;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // devName
            // 
            this.devName.Location = new System.Drawing.Point(158, 146);
            this.devName.Name = "devName";
            this.devName.Size = new System.Drawing.Size(200, 20);
            this.devName.TabIndex = 43;
            this.devName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.devName_KeyPress);
            // 
            // dev_id
            // 
            this.dev_id.Enabled = false;
            this.dev_id.Location = new System.Drawing.Point(535, 146);
            this.dev_id.Name = "dev_id";
            this.dev_id.ReadOnly = true;
            this.dev_id.Size = new System.Drawing.Size(200, 20);
            this.dev_id.TabIndex = 42;
            this.dev_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dev_id_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(785, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "درجة حرارة قصوى";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(367, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "النوع";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(367, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "اسم الجهاز";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(785, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "رقم الجهاز";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(343, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 45);
            this.label1.TabIndex = 40;
            this.label1.Text = "أجهزة المغسلة";
            // 
            // descriptions
            // 
            this.descriptions.Location = new System.Drawing.Point(158, 318);
            this.descriptions.Name = "descriptions";
            this.descriptions.Size = new System.Drawing.Size(577, 20);
            this.descriptions.TabIndex = 57;
            this.descriptions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.descriptions_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(773, 321);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 56;
            this.label8.Text = "الوصف";
            // 
            // WM_device
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 506);
            this.Controls.Add(this.descriptions);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.conditions);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.colores);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.kind);
            this.Controls.Add(this.temp);
            this.Controls.Add(this.description);
            this.Controls.Add(this.help);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.devName);
            this.Controls.Add(this.dev_id);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "WM_device";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "أجهزة المغسلة";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox conditions;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox colores;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox kind;
        private System.Windows.Forms.TextBox temp;
        private System.Windows.Forms.LinkLabel description;
        private System.Windows.Forms.LinkLabel help;
        private System.Windows.Forms.LinkLabel delete;
        private System.Windows.Forms.LinkLabel add;
        private System.Windows.Forms.LinkLabel exit;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox devName;
        private System.Windows.Forms.TextBox dev_id;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox descriptions;
        private System.Windows.Forms.Label label8;
    }
}

