namespace HIS
{
    partial class تصميم_الشيتات
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
            this.HumanComponent = new System.Windows.Forms.Button();
            this.Measurement_Units = new System.Windows.Forms.Button();
            this.SearchEngine = new System.Windows.Forms.Button();
            this.Human_Photo = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Setting_Of_Fields = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HumanComponent
            // 
            this.HumanComponent.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HumanComponent.Location = new System.Drawing.Point(96, 130);
            this.HumanComponent.Name = "HumanComponent";
            this.HumanComponent.Size = new System.Drawing.Size(231, 48);
            this.HumanComponent.TabIndex = 43;
            this.HumanComponent.Text = "مكونات جسم الانسان";
            this.HumanComponent.UseVisualStyleBackColor = true;
            this.HumanComponent.Visible = false;
            this.HumanComponent.Click += new System.EventHandler(this.HumanComponent_Click);
            // 
            // Measurement_Units
            // 
            this.Measurement_Units.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Measurement_Units.Location = new System.Drawing.Point(100, 267);
            this.Measurement_Units.Name = "Measurement_Units";
            this.Measurement_Units.Size = new System.Drawing.Size(227, 48);
            this.Measurement_Units.TabIndex = 42;
            this.Measurement_Units.Text = "اعدادات وحدات القياس";
            this.Measurement_Units.UseVisualStyleBackColor = true;
            this.Measurement_Units.Visible = false;
            this.Measurement_Units.Click += new System.EventHandler(this.Measurement_Units_Click);
            // 
            // SearchEngine
            // 
            this.SearchEngine.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchEngine.Location = new System.Drawing.Point(94, 76);
            this.SearchEngine.Name = "SearchEngine";
            this.SearchEngine.Size = new System.Drawing.Size(233, 48);
            this.SearchEngine.TabIndex = 41;
            this.SearchEngine.Text = "محرك البحث عن الشيتات الطبية";
            this.SearchEngine.UseVisualStyleBackColor = true;
            this.SearchEngine.Visible = false;
            this.SearchEngine.Click += new System.EventHandler(this.SearchEngine_Click);
            // 
            // Human_Photo
            // 
            this.Human_Photo.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Human_Photo.Location = new System.Drawing.Point(96, 28);
            this.Human_Photo.Name = "Human_Photo";
            this.Human_Photo.Size = new System.Drawing.Size(231, 42);
            this.Human_Photo.TabIndex = 40;
            this.Human_Photo.Text = "صور مكونات جسم الانسان";
            this.Human_Photo.UseVisualStyleBackColor = true;
            this.Human_Photo.Visible = false;
            this.Human_Photo.Click += new System.EventHandler(this.Human_Photo_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(471, 288);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(222, 56);
            this.button3.TabIndex = 39;
            this.button3.Text = "اعدادات";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(471, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(222, 56);
            this.button1.TabIndex = 37;
            this.button1.Text = "برامج ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Setting_Of_Fields
            // 
            this.Setting_Of_Fields.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Setting_Of_Fields.Location = new System.Drawing.Point(100, 325);
            this.Setting_Of_Fields.Name = "Setting_Of_Fields";
            this.Setting_Of_Fields.Size = new System.Drawing.Size(227, 48);
            this.Setting_Of_Fields.TabIndex = 44;
            this.Setting_Of_Fields.Text = "اعدادت فئات تقارير الشيتات الطبية ";
            this.Setting_Of_Fields.UseVisualStyleBackColor = true;
            this.Setting_Of_Fields.Visible = false;
            this.Setting_Of_Fields.Click += new System.EventHandler(this.Setting_Of_Fields_Click);
            // 
            // تصميم_الشيتات
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 453);
            this.Controls.Add(this.Setting_Of_Fields);
            this.Controls.Add(this.HumanComponent);
            this.Controls.Add(this.Measurement_Units);
            this.Controls.Add(this.SearchEngine);
            this.Controls.Add(this.Human_Photo);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "تصميم_الشيتات";
            this.Text = "تصميم_الشيتات";
            this.Load += new System.EventHandler(this.تصميم_الشيتات_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button HumanComponent;
        private System.Windows.Forms.Button Measurement_Units;
        private System.Windows.Forms.Button SearchEngine;
        private System.Windows.Forms.Button Human_Photo;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Setting_Of_Fields;

    }
}



