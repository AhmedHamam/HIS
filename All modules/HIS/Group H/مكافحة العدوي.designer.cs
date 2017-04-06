namespace HIS
{
    partial class مكافحة_العدوي
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
            this.add_vaccination = new System.Windows.Forms.Button();
            this.reportvaccination = new System.Windows.Forms.Button();
            this.Emp_Infection = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.report_patient_onPeriod = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // add_vaccination
            // 
            this.add_vaccination.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.add_vaccination.Location = new System.Drawing.Point(37, 308);
            this.add_vaccination.Name = "add_vaccination";
            this.add_vaccination.Size = new System.Drawing.Size(227, 48);
            this.add_vaccination.TabIndex = 33;
            this.add_vaccination.Text = "اضافة تطعيم جديد";
            this.add_vaccination.UseVisualStyleBackColor = true;
            this.add_vaccination.Visible = false;
            this.add_vaccination.Click += new System.EventHandler(this.add_vaccination_Click);
            // 
            // reportvaccination
            // 
            this.reportvaccination.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportvaccination.Location = new System.Drawing.Point(14, 161);
            this.reportvaccination.Name = "reportvaccination";
            this.reportvaccination.Size = new System.Drawing.Size(376, 48);
            this.reportvaccination.TabIndex = 32;
            this.reportvaccination.Text = "تقرير عن التطعيمات التى حصل عليها المريض خلال فترة معينة";
            this.reportvaccination.UseVisualStyleBackColor = true;
            this.reportvaccination.Visible = false;
            this.reportvaccination.Click += new System.EventHandler(this.reportvaccination_Click);
            // 
            // Emp_Infection
            // 
            this.Emp_Infection.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Emp_Infection.Location = new System.Drawing.Point(33, 34);
            this.Emp_Infection.Name = "Emp_Infection";
            this.Emp_Infection.Size = new System.Drawing.Size(231, 42);
            this.Emp_Infection.TabIndex = 31;
            this.Emp_Infection.Text = "اضافة مكافحة عدوي للموظفين";
            this.Emp_Infection.UseVisualStyleBackColor = true;
            this.Emp_Infection.Visible = false;
            this.Emp_Infection.Click += new System.EventHandler(this.Emp_Infection_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(453, 304);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(222, 56);
            this.button3.TabIndex = 29;
            this.button3.Text = "اعدادات";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(453, 180);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(222, 56);
            this.button2.TabIndex = 28;
            this.button2.Text = "تقارير ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(453, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 56);
            this.button1.TabIndex = 27;
            this.button1.Text = "برامج ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // report_patient_onPeriod
            // 
            this.report_patient_onPeriod.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.report_patient_onPeriod.Location = new System.Drawing.Point(16, 215);
            this.report_patient_onPeriod.Name = "report_patient_onPeriod";
            this.report_patient_onPeriod.Size = new System.Drawing.Size(374, 48);
            this.report_patient_onPeriod.TabIndex = 36;
            this.report_patient_onPeriod.Text = "تقرير للمرضى المصابين بالعدوي عند فترة معينة";
            this.report_patient_onPeriod.UseVisualStyleBackColor = true;
            this.report_patient_onPeriod.Visible = false;
            this.report_patient_onPeriod.Click += new System.EventHandler(this.report_patient_onPeriod_Click);
            // 
            // مكافحة_العدوي
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 453);
            this.Controls.Add(this.report_patient_onPeriod);
            this.Controls.Add(this.add_vaccination);
            this.Controls.Add(this.reportvaccination);
            this.Controls.Add(this.Emp_Infection);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "مكافحة_العدوي";
            this.Text = "مكافحة_العدوي";
            this.Load += new System.EventHandler(this.مكافحة_العدوي_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button add_vaccination;
        private System.Windows.Forms.Button reportvaccination;
        private System.Windows.Forms.Button Emp_Infection;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button report_patient_onPeriod;

    }
}



