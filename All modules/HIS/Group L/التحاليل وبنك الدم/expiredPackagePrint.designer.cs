namespace HIS
{
    partial class expiredPackagePrint
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.bloodPackageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bloodBank = new HIS.bloodBank();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bloodPackageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bloodBank)).BeginInit();
            this.SuspendLayout();
            // 
            // bloodPackageBindingSource
            // 
            this.bloodPackageBindingSource.DataMember = "bloodPackage";
            this.bloodPackageBindingSource.DataSource = this.bloodBank;
            // 
            // bloodBank
            // 
            this.bloodBank.DataSetName = "bloodBank";
            this.bloodBank.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.bloodPackageBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "HIS.العبوات المنتهية الصلاحية - بنك الدم.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(726, 464);
            this.reportViewer1.TabIndex = 0;
            // 
            // expiredPackagePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 464);
            this.Controls.Add(this.reportViewer1);
            this.Name = "expiredPackagePrint";
            this.Text = "expiredPackagePrint";
            this.Load += new System.EventHandler(this.expiredPackagePrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bloodPackageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bloodBank)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource bloodPackageBindingSource;
        private bloodBank bloodBank;
    }
}