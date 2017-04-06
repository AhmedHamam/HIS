namespace HIS
{
    partial class wm_operating_order
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.order_num = new System.Windows.Forms.TextBox();
            this.fromdate = new System.Windows.Forms.DateTimePicker();
            this.service = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.description = new System.Windows.Forms.LinkLabel();
            this.help = new System.Windows.Forms.LinkLabel();
            this.delete = new System.Windows.Forms.LinkLabel();
            this.add = new System.Windows.Forms.LinkLabel();
            this.exit = new System.Windows.Forms.LinkLabel();
            this.todate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numHoures = new System.Windows.Forms.TextBox();
            this.detergentsesQuantity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.demanderPlace = new System.Windows.Forms.TextBox();
            this.opOrderType = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.empId = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(369, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "اصدار امر شغل";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(900, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "رقم الطلب";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(242, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "كود الخدمة";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(257, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "من تاريخ";
            // 
            // order_num
            // 
            this.order_num.Location = new System.Drawing.Point(674, 92);
            this.order_num.Name = "order_num";
            this.order_num.ReadOnly = true;
            this.order_num.Size = new System.Drawing.Size(200, 20);
            this.order_num.TabIndex = 1;
            // 
            // fromdate
            // 
            this.fromdate.Location = new System.Drawing.Point(31, 187);
            this.fromdate.Name = "fromdate";
            this.fromdate.Size = new System.Drawing.Size(200, 20);
            this.fromdate.TabIndex = 3;
            // 
            // service
            // 
            this.service.Location = new System.Drawing.Point(31, 88);
            this.service.Name = "service";
            this.service.ReadOnly = true;
            this.service.Size = new System.Drawing.Size(144, 20);
            this.service.TabIndex = 2;
            this.service.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.service_KeyPress_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 234);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(945, 107);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(664, 13);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(87, 16);
            this.description.TabIndex = 11;
            this.description.TabStop = true;
            this.description.Text = "وصف الحقول";
            // 
            // help
            // 
            this.help.AutoSize = true;
            this.help.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.help.Location = new System.Drawing.Point(767, 13);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(42, 16);
            this.help.TabIndex = 12;
            this.help.TabStop = true;
            this.help.Text = "تعديل";
            this.help.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.help_LinkClicked);
            // 
            // delete
            // 
            this.delete.AutoSize = true;
            this.delete.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delete.Location = new System.Drawing.Point(825, 13);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(38, 16);
            this.delete.TabIndex = 7;
            this.delete.TabStop = true;
            this.delete.Text = "حذف";
            this.delete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.delete_LinkClicked);
            // 
            // add
            // 
            this.add.AutoSize = true;
            this.add.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add.Location = new System.Drawing.Point(869, 13);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(44, 16);
            this.add.TabIndex = 8;
            this.add.TabStop = true;
            this.add.Text = "اضافة";
            this.add.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.add_LinkClicked);
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit.Location = new System.Drawing.Point(919, 13);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(41, 16);
            this.exit.TabIndex = 9;
            this.exit.TabStop = true;
            this.exit.Text = "خروج";
            this.exit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.exit_LinkClicked);
            // 
            // todate
            // 
            this.todate.Location = new System.Drawing.Point(346, 191);
            this.todate.Name = "todate";
            this.todate.Size = new System.Drawing.Size(200, 20);
            this.todate.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(567, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "الى تاريخ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(881, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "المكان الطالب";
            // 
            // numHoures
            // 
            this.numHoures.Location = new System.Drawing.Point(346, 141);
            this.numHoures.Name = "numHoures";
            this.numHoures.Size = new System.Drawing.Size(200, 20);
            this.numHoures.TabIndex = 20;
            this.numHoures.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numHoures_KeyPress_1);
            // 
            // detergentsesQuantity
            // 
            this.detergentsesQuantity.Location = new System.Drawing.Point(346, 92);
            this.detergentsesQuantity.Name = "detergentsesQuantity";
            this.detergentsesQuantity.Size = new System.Drawing.Size(200, 20);
            this.detergentsesQuantity.TabIndex = 19;
            this.detergentsesQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.detergentsesQuantity_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(242, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "اسم الخدمة";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(567, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "عدد الساعات";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(562, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "كمية المسحوق";
            // 
            // demanderPlace
            // 
            this.demanderPlace.Location = new System.Drawing.Point(675, 142);
            this.demanderPlace.Name = "demanderPlace";
            this.demanderPlace.Size = new System.Drawing.Size(200, 20);
            this.demanderPlace.TabIndex = 24;
            this.demanderPlace.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.demanderPlace_KeyPress_1);
            // 
            // opOrderType
            // 
            this.opOrderType.Location = new System.Drawing.Point(31, 143);
            this.opOrderType.Name = "opOrderType";
            this.opOrderType.ReadOnly = true;
            this.opOrderType.Size = new System.Drawing.Size(200, 20);
            this.opOrderType.TabIndex = 23;
            this.opOrderType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.opOrderType_KeyPress_1);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(881, 197);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 16);
            this.label11.TabIndex = 30;
            this.label11.Text = "كود الموظف";
            // 
            // empId
            // 
            this.empId.Location = new System.Drawing.Point(674, 194);
            this.empId.Name = "empId";
            this.empId.ReadOnly = true;
            this.empId.Size = new System.Drawing.Size(149, 20);
            this.empId.TabIndex = 23;
            // 
            // button2
            // 
            this.button2.Image = global::HIS.Properties.Resources.search_scale_100_contrast_white;
            this.button2.Location = new System.Drawing.Point(828, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 23);
            this.button2.TabIndex = 31;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = global::HIS.Properties.Resources.search_scale_100_contrast_white;
            this.button1.Location = new System.Drawing.Point(181, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 23);
            this.button1.TabIndex = 31;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // wm_operating_order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 349);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.demanderPlace);
            this.Controls.Add(this.empId);
            this.Controls.Add(this.opOrderType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numHoures);
            this.Controls.Add(this.detergentsesQuantity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.todate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.description);
            this.Controls.Add(this.help);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.fromdate);
            this.Controls.Add(this.service);
            this.Controls.Add(this.order_num);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "wm_operating_order";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اصدار امر شغل";
            this.Load += new System.EventHandler(this.wm_operating_order_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox order_num;
        private System.Windows.Forms.DateTimePicker fromdate;
        private System.Windows.Forms.TextBox service;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.LinkLabel description;
        private System.Windows.Forms.LinkLabel help;
        private System.Windows.Forms.LinkLabel delete;
        private System.Windows.Forms.LinkLabel add;
        private System.Windows.Forms.LinkLabel exit;
        private System.Windows.Forms.DateTimePicker todate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox numHoures;
        private System.Windows.Forms.TextBox detergentsesQuantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox demanderPlace;
        private System.Windows.Forms.TextBox opOrderType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox empId;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

