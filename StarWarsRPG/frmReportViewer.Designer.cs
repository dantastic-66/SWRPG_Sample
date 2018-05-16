namespace StarWarsRPG
{
    partial class frmReportViewer
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
            this.rptvReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rvReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptvReportViewer
            // 
            this.rptvReportViewer.Location = new System.Drawing.Point(0, 0);
            this.rptvReportViewer.Name = "rptvReportViewer";
            this.rptvReportViewer.Size = new System.Drawing.Size(396, 246);
            this.rptvReportViewer.TabIndex = 0;
            // 
            // rvReportViewer
            // 
            this.rvReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvReportViewer.Location = new System.Drawing.Point(0, 0);
            this.rvReportViewer.Name = "rvReportViewer";
            this.rvReportViewer.ShowBackButton = false;
            this.rvReportViewer.ShowContextMenu = false;
            this.rvReportViewer.ShowParameterPrompts = false;
            this.rvReportViewer.ShowProgress = false;
            this.rvReportViewer.Size = new System.Drawing.Size(989, 745);
            this.rvReportViewer.TabIndex = 0;
            // 
            // frmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 745);
            this.Controls.Add(this.rvReportViewer);
            this.Name = "frmReportViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.frmReportViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptvReportViewer;
        private Microsoft.Reporting.WinForms.ReportViewer rvReportViewer;

    }
}