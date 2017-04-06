namespace HIS
{
    partial class GroupA_PatientBill_bill_report
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Visit_BillBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Patient_Bill_DataSet1 = new HIS.Patient_Bill_DataSet1();
            this.serviceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.residenceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.medicineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.Visit_BillBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Patient_Bill_DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.residenceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicineBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Visit_BillBindingSource
            // 
            this.Visit_BillBindingSource.DataMember = "Visit_Bill";
            this.Visit_BillBindingSource.DataSource = this.Patient_Bill_DataSet1;
            // 
            // Patient_Bill_DataSet1
            // 
            this.Patient_Bill_DataSet1.DataSetName = "Patient_Bill_DataSet1";
            this.Patient_Bill_DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // serviceBindingSource
            // 
            this.serviceBindingSource.DataMember = "service";
            this.serviceBindingSource.DataSource = this.Patient_Bill_DataSet1;
            // 
            // residenceBindingSource
            // 
            this.residenceBindingSource.DataMember = "residence";
            this.residenceBindingSource.DataSource = this.Patient_Bill_DataSet1;
            // 
            // medicineBindingSource
            // 
            this.medicineBindingSource.DataMember = "medicine";
            this.medicineBindingSource.DataSource = this.Patient_Bill_DataSet1;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Visit_BillBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.serviceBindingSource;
            reportDataSource3.Name = "DataSet3";
            reportDataSource3.Value = this.residenceBindingSource;
            reportDataSource4.Name = "DataSet4";
            reportDataSource4.Value = this.medicineBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "HIS.Report_Patient_bill_Show_AND_Print.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(746, 406);
            this.reportViewer1.TabIndex = 0;
            // 
            // GroupA_PatientBill_bill_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 406);
            this.Controls.Add(this.reportViewer1);
            this.Name = "GroupA_PatientBill_bill_report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كشف حساب زيارة";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GroupA_PatientBill_bill_report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Visit_BillBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Patient_Bill_DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.residenceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medicineBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Visit_BillBindingSource;
        private Patient_Bill_DataSet1 Patient_Bill_DataSet1;
        private System.Windows.Forms.BindingSource serviceBindingSource;
        private System.Windows.Forms.BindingSource residenceBindingSource;
        private System.Windows.Forms.BindingSource medicineBindingSource;
    }
}