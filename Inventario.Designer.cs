namespace ControLSInsumos
{
    partial class Inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventario));
            this.insumosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dBInsumosDataSet1 = new ControLSInsumos.DBInsumosDataSet1();
            this.despachosProcBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.despachosProceDataSet2 = new ControLSInsumos.despachosProceDataSet2();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.insumosTableAdapter = new ControLSInsumos.DBInsumosDataSet1TableAdapters.insumosTableAdapter();
            this.despachosProcTableAdapter = new ControLSInsumos.despachosProceDataSet2TableAdapters.despachosProcTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.insumosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBInsumosDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.despachosProcBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.despachosProceDataSet2)).BeginInit();
            this.SuspendLayout();
            // 
            // insumosBindingSource
            // 
            this.insumosBindingSource.DataMember = "insumos";
            this.insumosBindingSource.DataSource = this.dBInsumosDataSet1;
            // 
            // dBInsumosDataSet1
            // 
            this.dBInsumosDataSet1.DataSetName = "DBInsumosDataSet1";
            this.dBInsumosDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // despachosProcBindingSource
            // 
            this.despachosProcBindingSource.DataMember = "despachosProc";
            this.despachosProcBindingSource.DataSource = this.despachosProceDataSet2;
            // 
            // despachosProceDataSet2
            // 
            this.despachosProceDataSet2.DataSetName = "despachosProceDataSet2";
            this.despachosProceDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.insumosBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.despachosProcBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ControLSInsumos.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // insumosTableAdapter
            // 
            this.insumosTableAdapter.ClearBeforeFill = true;
            // 
            // despachosProcTableAdapter
            // 
            this.despachosProcTableAdapter.ClearBeforeFill = true;
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Inventario";
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.Inventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.insumosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dBInsumosDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.despachosProcBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.despachosProceDataSet2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DBInsumosDataSet1 dBInsumosDataSet1;
        private System.Windows.Forms.BindingSource insumosBindingSource;
        private DBInsumosDataSet1TableAdapters.insumosTableAdapter insumosTableAdapter;
        private despachosProceDataSet2 despachosProceDataSet2;
        private System.Windows.Forms.BindingSource despachosProcBindingSource;
        private despachosProceDataSet2TableAdapters.despachosProcTableAdapter despachosProcTableAdapter;
    }
}