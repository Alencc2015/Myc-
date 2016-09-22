namespace SimpleWare
{
    partial class frmRpttest
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SimpleWareDataSet = new SimpleWare.SimpleWareDataSet();
            this.SelPorceLainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SelPorceLainTableAdapter = new SimpleWare.SimpleWareDataSetTableAdapters.SelPorceLainTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SimpleWareDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelPorceLainBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "SelPain";
            reportDataSource1.Value = this.SelPorceLainBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SimpleWare.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(861, 463);
            this.reportViewer1.TabIndex = 0;
            // 
            // SimpleWareDataSet
            // 
            this.SimpleWareDataSet.DataSetName = "SimpleWareDataSet";
            this.SimpleWareDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // SelPorceLainBindingSource
            // 
            this.SelPorceLainBindingSource.DataMember = "SelPorceLain";
            this.SelPorceLainBindingSource.DataSource = this.SimpleWareDataSet;
            // 
            // SelPorceLainTableAdapter
            // 
            this.SelPorceLainTableAdapter.ClearBeforeFill = true;
            // 
            // frmRpttest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 463);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRpttest";
            this.Text = "frmRpttest";
            this.Load += new System.EventHandler(this.frmRpttest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SimpleWareDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelPorceLainBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SelPorceLainBindingSource;
        private SimpleWareDataSet SimpleWareDataSet;
        private SimpleWareDataSetTableAdapters.SelPorceLainTableAdapter SelPorceLainTableAdapter;
    }
}