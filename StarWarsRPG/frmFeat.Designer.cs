namespace StarWarsRPG
{
    partial class frmFeat
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFeatID = new System.Windows.Forms.TextBox();
            this.lblFeatID = new System.Windows.Forms.Label();
            this.lblFeatDescription = new System.Windows.Forms.Label();
            this.txtFeatDescription = new System.Windows.Forms.TextBox();
            this.lblFeatName = new System.Windows.Forms.Label();
            this.txtFeatName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEdit.Location = new System.Drawing.Point(376, 72);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(64, 32);
            this.btnEdit.TabIndex = 31;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.Location = new System.Drawing.Point(376, 112);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 32);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "S&ave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnNew.Location = new System.Drawing.Point(376, 32);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(64, 32);
            this.btnNew.TabIndex = 29;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSearch.Location = new System.Drawing.Point(184, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 32);
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "&Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtFeatID
            // 
            this.txtFeatID.Location = new System.Drawing.Point(128, 8);
            this.txtFeatID.MaxLength = 100;
            this.txtFeatID.Name = "txtFeatID";
            this.txtFeatID.ReadOnly = true;
            this.txtFeatID.Size = new System.Drawing.Size(32, 20);
            this.txtFeatID.TabIndex = 27;
            // 
            // lblFeatID
            // 
            this.lblFeatID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFeatID.Location = new System.Drawing.Point(8, 8);
            this.lblFeatID.Name = "lblFeatID";
            this.lblFeatID.Size = new System.Drawing.Size(112, 24);
            this.lblFeatID.TabIndex = 26;
            this.lblFeatID.Text = "Feat ID:";
            this.lblFeatID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFeatDescription
            // 
            this.lblFeatDescription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFeatDescription.Location = new System.Drawing.Point(8, 80);
            this.lblFeatDescription.Name = "lblFeatDescription";
            this.lblFeatDescription.Size = new System.Drawing.Size(96, 24);
            this.lblFeatDescription.TabIndex = 19;
            this.lblFeatDescription.Text = "Description:";
            this.lblFeatDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFeatDescription
            // 
            this.txtFeatDescription.Location = new System.Drawing.Point(112, 72);
            this.txtFeatDescription.MaxLength = 1000;
            this.txtFeatDescription.Multiline = true;
            this.txtFeatDescription.Name = "txtFeatDescription";
            this.txtFeatDescription.Size = new System.Drawing.Size(256, 88);
            this.txtFeatDescription.TabIndex = 18;
            this.txtFeatDescription.TextChanged += new System.EventHandler(this.txtFeatDescription_TextChanged);
            // 
            // lblFeatName
            // 
            this.lblFeatName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFeatName.Location = new System.Drawing.Point(8, 48);
            this.lblFeatName.Name = "lblFeatName";
            this.lblFeatName.Size = new System.Drawing.Size(96, 24);
            this.lblFeatName.TabIndex = 17;
            this.lblFeatName.Text = "Feat Name:";
            this.lblFeatName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFeatName
            // 
            this.txtFeatName.Location = new System.Drawing.Point(112, 48);
            this.txtFeatName.MaxLength = 100;
            this.txtFeatName.Name = "txtFeatName";
            this.txtFeatName.Size = new System.Drawing.Size(152, 20);
            this.txtFeatName.TabIndex = 16;
            this.txtFeatName.TextChanged += new System.EventHandler(this.txtFeatName_TextChanged);
            // 
            // frmFeat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 168);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtFeatID);
            this.Controls.Add(this.lblFeatID);
            this.Controls.Add(this.lblFeatDescription);
            this.Controls.Add(this.txtFeatDescription);
            this.Controls.Add(this.lblFeatName);
            this.Controls.Add(this.txtFeatName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFeat";
            this.Text = "Feat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtFeatID;
        private System.Windows.Forms.Label lblFeatID;
        private System.Windows.Forms.Label lblFeatDescription;
        private System.Windows.Forms.TextBox txtFeatDescription;
        private System.Windows.Forms.Label lblFeatName;
        private System.Windows.Forms.TextBox txtFeatName;
    }
}