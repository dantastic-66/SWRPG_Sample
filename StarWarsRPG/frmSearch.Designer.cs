namespace StarWarsRPG
{
    partial class frmSearch
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lvSearchResults = new System.Windows.Forms.ListView();
            this.lblNoResults = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(18, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(268, 27);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(316, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 30);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lvSearchResults
            // 
            this.lvSearchResults.FullRowSelect = true;
            this.lvSearchResults.Location = new System.Drawing.Point(22, 64);
            this.lvSearchResults.MultiSelect = false;
            this.lvSearchResults.Name = "lvSearchResults";
            this.lvSearchResults.Size = new System.Drawing.Size(440, 165);
            this.lvSearchResults.TabIndex = 2;
            this.lvSearchResults.UseCompatibleStateImageBehavior = false;
            this.lvSearchResults.View = System.Windows.Forms.View.Details;
            this.lvSearchResults.Visible = false;
            this.lvSearchResults.SelectedIndexChanged += new System.EventHandler(this.lvSearchResults_SelectedIndexChanged);
            // 
            // lblNoResults
            // 
            this.lblNoResults.Location = new System.Drawing.Point(19, 64);
            this.lblNoResults.Name = "lblNoResults";
            this.lblNoResults.Size = new System.Drawing.Size(442, 25);
            this.lblNoResults.TabIndex = 3;
            this.lblNoResults.Text = "No Results found for:";
            this.lblNoResults.Visible = false;
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(501, 241);
            this.Controls.Add(this.lvSearchResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblNoResults);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 11.25F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search Game By Name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lvSearchResults;
        private System.Windows.Forms.Label lblNoResults;
    }
}