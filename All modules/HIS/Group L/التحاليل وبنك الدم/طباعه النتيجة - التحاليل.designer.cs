namespace HIS
{
    partial class طباعه_النتيجة___التحاليل
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
            this.print_resultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labAnalysis = new HIS.labAnalysis();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.print_resultBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labAnalysis)).BeginInit();
            this.SuspendLayout();
            // 
            // print_resultBindingSource
            // 
            this.print_resultBindingSource.DataMember = "print_result";
            this.print_resultBindingSource.DataSource = this.labAnalysis;
            // 
            // labAnalysis
            // 
            this.labAnalysis.DataSetName = "labAnalysis";
            this.labAnalysis.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.print_resultBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "HIS.طباعه النتيجة - التحاليل.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(668, 374);
            this.reportViewer1.TabIndex = 0;
            // 
            // طباعه_النتيجة___التحاليل
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 374);
            this.Controls.Add(this.reportViewer1);
            this.Name = "طباعه_النتيجة___التحاليل";
            this.Text = "طباعه_النتيجة___التحاليل";
            this.Load += new System.EventHandler(this.طباعه_النتيجة___التحاليل_Load);
            ((System.ComponentModel.ISupportInitialize)(this.print_resultBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labAnalysis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource print_resultBindingSource;
        private labAnalysis labAnalysis;
    }
}