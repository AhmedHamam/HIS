namespace HIS
{
    partial class MedicalSheet
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
            this.SheetSetting = new System.Windows.Forms.Button();
            this.Print_Sheet = new System.Windows.Forms.Button();
            this.Design_Sheet = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SheetSetting
            // 
            this.SheetSetting.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SheetSetting.Location = new System.Drawing.Point(91, 350);
            this.SheetSetting.Name = "SheetSetting";
            this.SheetSetting.Size = new System.Drawing.Size(227, 48);
            this.SheetSetting.TabIndex = 51;
            this.SheetSetting.Text = "اعدادات الشيتات";
            this.SheetSetting.UseVisualStyleBackColor = true;
            this.SheetSetting.Visible = false;
            this.SheetSetting.Click += new System.EventHandler(this.SheetSetting_Click);
            // 
            // Print_Sheet
            // 
            this.Print_Sheet.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Print_Sheet.Location = new System.Drawing.Point(91, 246);
            this.Print_Sheet.Name = "Print_Sheet";
            this.Print_Sheet.Size = new System.Drawing.Size(227, 48);
            this.Print_Sheet.TabIndex = 49;
            this.Print_Sheet.Text = "طباعة نموذج الشيت الطبى";
            this.Print_Sheet.UseVisualStyleBackColor = true;
            this.Print_Sheet.Visible = false;
            this.Print_Sheet.Click += new System.EventHandler(this.Print_Sheet_Click);
            // 
            // Design_Sheet
            // 
            this.Design_Sheet.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Design_Sheet.Location = new System.Drawing.Point(87, 129);
            this.Design_Sheet.Name = "Design_Sheet";
            this.Design_Sheet.Size = new System.Drawing.Size(231, 42);
            this.Design_Sheet.TabIndex = 47;
            this.Design_Sheet.Text = "تصميم الشيتات التفاعلية";
            this.Design_Sheet.UseVisualStyleBackColor = true;
            this.Design_Sheet.Visible = false;
            this.Design_Sheet.Click += new System.EventHandler(this.Design_Sheet_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(454, 342);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(222, 56);
            this.button3.TabIndex = 46;
            this.button3.Text = "اعدادات";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(454, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 56);
            this.button1.TabIndex = 45;
            this.button1.Text = "برامج ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(454, 246);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(222, 56);
            this.button2.TabIndex = 52;
            this.button2.Text = "تقارير";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MedicalSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 512);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SheetSetting);
            this.Controls.Add(this.Print_Sheet);
            this.Controls.Add(this.Design_Sheet);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MedicalSheet";
            this.Text = "MedicalSheet";
            this.Load += new System.EventHandler(this.MedicalSheet_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button SheetSetting;
        private System.Windows.Forms.Button Print_Sheet;
        private System.Windows.Forms.Button Design_Sheet;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

    }
}



