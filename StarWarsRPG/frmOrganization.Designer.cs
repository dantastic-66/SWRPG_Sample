namespace StarWarsRPG
{
    partial class frmOrganization
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
            this.cmbOrganization = new System.Windows.Forms.ComboBox();
            this.lblOrganization = new System.Windows.Forms.Label();
            this.lblOrganizationDescription = new System.Windows.Forms.Label();
            this.txtOrganizationDescription = new System.Windows.Forms.TextBox();
            this.txtOrganizationAllies = new System.Windows.Forms.TextBox();
            this.lblOrganizationAllies = new System.Windows.Forms.Label();
            this.txtOrganizationEnemies = new System.Windows.Forms.TextBox();
            this.lblOrganizationEnemies = new System.Windows.Forms.Label();
            this.btnSetOrganizations = new System.Windows.Forms.Button();
            this.lblOrganizationScale = new System.Windows.Forms.Label();
            this.txtOrganizationScale = new System.Windows.Forms.TextBox();
            this.txtOrganizationType = new System.Windows.Forms.TextBox();
            this.lblOrganizationType = new System.Windows.Forms.Label();
            this.txtForceTradition = new System.Windows.Forms.TextBox();
            this.lblForceTradition = new System.Windows.Forms.Label();
            this.gpOrganizationSelection = new System.Windows.Forms.GroupBox();
            this.tvCharacterOrgs = new System.Windows.Forms.TreeView();
            this.lblCurrentOrgs = new System.Windows.Forms.Label();
            this.lblMaxOrgs = new System.Windows.Forms.Label();
            this.btnRemoveAllFP = new System.Windows.Forms.Button();
            this.btnRemoveFP = new System.Windows.Forms.Button();
            this.btnAddFP = new System.Windows.Forms.Button();
            this.tvSelectedOrganizations = new System.Windows.Forms.TreeView();
            this.tvOrganizationList = new System.Windows.Forms.TreeView();
            this.gpOrganizationInfo = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gpOrganizationSelection.SuspendLayout();
            this.gpOrganizationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbOrganization
            // 
            this.cmbOrganization.FormattingEnabled = true;
            this.cmbOrganization.Location = new System.Drawing.Point(88, 452);
            this.cmbOrganization.Name = "cmbOrganization";
            this.cmbOrganization.Size = new System.Drawing.Size(40, 21);
            this.cmbOrganization.TabIndex = 0;
            this.cmbOrganization.Visible = false;
            this.cmbOrganization.SelectedIndexChanged += new System.EventHandler(this.cmbOrganization_SelectedIndexChanged);
            // 
            // lblOrganization
            // 
            this.lblOrganization.AutoSize = true;
            this.lblOrganization.Location = new System.Drawing.Point(16, 456);
            this.lblOrganization.Name = "lblOrganization";
            this.lblOrganization.Size = new System.Drawing.Size(78, 13);
            this.lblOrganization.TabIndex = 1;
            this.lblOrganization.Text = "Organization:";
            this.lblOrganization.Visible = false;
            // 
            // lblOrganizationDescription
            // 
            this.lblOrganizationDescription.AutoSize = true;
            this.lblOrganizationDescription.Location = new System.Drawing.Point(16, 36);
            this.lblOrganizationDescription.Name = "lblOrganizationDescription";
            this.lblOrganizationDescription.Size = new System.Drawing.Size(140, 13);
            this.lblOrganizationDescription.TabIndex = 2;
            this.lblOrganizationDescription.Text = "Organization Description:";
            // 
            // txtOrganizationDescription
            // 
            this.txtOrganizationDescription.Location = new System.Drawing.Point(156, 32);
            this.txtOrganizationDescription.Multiline = true;
            this.txtOrganizationDescription.Name = "txtOrganizationDescription";
            this.txtOrganizationDescription.ReadOnly = true;
            this.txtOrganizationDescription.Size = new System.Drawing.Size(336, 100);
            this.txtOrganizationDescription.TabIndex = 3;
            // 
            // txtOrganizationAllies
            // 
            this.txtOrganizationAllies.Location = new System.Drawing.Point(157, 143);
            this.txtOrganizationAllies.Multiline = true;
            this.txtOrganizationAllies.Name = "txtOrganizationAllies";
            this.txtOrganizationAllies.ReadOnly = true;
            this.txtOrganizationAllies.Size = new System.Drawing.Size(336, 100);
            this.txtOrganizationAllies.TabIndex = 5;
            // 
            // lblOrganizationAllies
            // 
            this.lblOrganizationAllies.AutoSize = true;
            this.lblOrganizationAllies.Location = new System.Drawing.Point(17, 147);
            this.lblOrganizationAllies.Name = "lblOrganizationAllies";
            this.lblOrganizationAllies.Size = new System.Drawing.Size(108, 13);
            this.lblOrganizationAllies.TabIndex = 4;
            this.lblOrganizationAllies.Text = "Organization Allies:";
            // 
            // txtOrganizationEnemies
            // 
            this.txtOrganizationEnemies.Location = new System.Drawing.Point(156, 248);
            this.txtOrganizationEnemies.Multiline = true;
            this.txtOrganizationEnemies.Name = "txtOrganizationEnemies";
            this.txtOrganizationEnemies.ReadOnly = true;
            this.txtOrganizationEnemies.Size = new System.Drawing.Size(336, 100);
            this.txtOrganizationEnemies.TabIndex = 7;
            // 
            // lblOrganizationEnemies
            // 
            this.lblOrganizationEnemies.AutoSize = true;
            this.lblOrganizationEnemies.Location = new System.Drawing.Point(16, 252);
            this.lblOrganizationEnemies.Name = "lblOrganizationEnemies";
            this.lblOrganizationEnemies.Size = new System.Drawing.Size(123, 13);
            this.lblOrganizationEnemies.TabIndex = 6;
            this.lblOrganizationEnemies.Text = "Organization Enemies:";
            // 
            // btnSetOrganizations
            // 
            this.btnSetOrganizations.Enabled = false;
            this.btnSetOrganizations.Location = new System.Drawing.Point(536, 488);
            this.btnSetOrganizations.Name = "btnSetOrganizations";
            this.btnSetOrganizations.Size = new System.Drawing.Size(160, 28);
            this.btnSetOrganizations.TabIndex = 8;
            this.btnSetOrganizations.Text = "Select Organization(s)";
            this.btnSetOrganizations.UseVisualStyleBackColor = true;
            this.btnSetOrganizations.Click += new System.EventHandler(this.btnSetOrganizations_Click);
            // 
            // lblOrganizationScale
            // 
            this.lblOrganizationScale.Location = new System.Drawing.Point(12, 360);
            this.lblOrganizationScale.Name = "lblOrganizationScale";
            this.lblOrganizationScale.Size = new System.Drawing.Size(112, 20);
            this.lblOrganizationScale.TabIndex = 10;
            this.lblOrganizationScale.Text = "Organization Scale:";
            // 
            // txtOrganizationScale
            // 
            this.txtOrganizationScale.Location = new System.Drawing.Point(128, 360);
            this.txtOrganizationScale.Name = "txtOrganizationScale";
            this.txtOrganizationScale.ReadOnly = true;
            this.txtOrganizationScale.Size = new System.Drawing.Size(268, 22);
            this.txtOrganizationScale.TabIndex = 11;
            // 
            // txtOrganizationType
            // 
            this.txtOrganizationType.Location = new System.Drawing.Point(128, 388);
            this.txtOrganizationType.Name = "txtOrganizationType";
            this.txtOrganizationType.ReadOnly = true;
            this.txtOrganizationType.Size = new System.Drawing.Size(268, 22);
            this.txtOrganizationType.TabIndex = 13;
            // 
            // lblOrganizationType
            // 
            this.lblOrganizationType.Location = new System.Drawing.Point(12, 388);
            this.lblOrganizationType.Name = "lblOrganizationType";
            this.lblOrganizationType.Size = new System.Drawing.Size(112, 20);
            this.lblOrganizationType.TabIndex = 12;
            this.lblOrganizationType.Text = "Organization Type:";
            // 
            // txtForceTradition
            // 
            this.txtForceTradition.Location = new System.Drawing.Point(128, 416);
            this.txtForceTradition.Name = "txtForceTradition";
            this.txtForceTradition.ReadOnly = true;
            this.txtForceTradition.Size = new System.Drawing.Size(268, 22);
            this.txtForceTradition.TabIndex = 15;
            // 
            // lblForceTradition
            // 
            this.lblForceTradition.Location = new System.Drawing.Point(12, 416);
            this.lblForceTradition.Name = "lblForceTradition";
            this.lblForceTradition.Size = new System.Drawing.Size(112, 20);
            this.lblForceTradition.TabIndex = 14;
            this.lblForceTradition.Text = "Force Tradition:";
            // 
            // gpOrganizationSelection
            // 
            this.gpOrganizationSelection.Controls.Add(this.tvCharacterOrgs);
            this.gpOrganizationSelection.Controls.Add(this.lblCurrentOrgs);
            this.gpOrganizationSelection.Controls.Add(this.lblMaxOrgs);
            this.gpOrganizationSelection.Controls.Add(this.btnRemoveAllFP);
            this.gpOrganizationSelection.Controls.Add(this.btnRemoveFP);
            this.gpOrganizationSelection.Controls.Add(this.btnAddFP);
            this.gpOrganizationSelection.Controls.Add(this.tvSelectedOrganizations);
            this.gpOrganizationSelection.Controls.Add(this.tvOrganizationList);
            this.gpOrganizationSelection.Location = new System.Drawing.Point(4, 4);
            this.gpOrganizationSelection.Name = "gpOrganizationSelection";
            this.gpOrganizationSelection.Size = new System.Drawing.Size(468, 520);
            this.gpOrganizationSelection.TabIndex = 16;
            this.gpOrganizationSelection.TabStop = false;
            this.gpOrganizationSelection.Text = "Select Organizations";
            // 
            // tvCharacterOrgs
            // 
            this.tvCharacterOrgs.Location = new System.Drawing.Point(264, 376);
            this.tvCharacterOrgs.Name = "tvCharacterOrgs";
            this.tvCharacterOrgs.Size = new System.Drawing.Size(196, 96);
            this.tvCharacterOrgs.TabIndex = 7;
            // 
            // lblCurrentOrgs
            // 
            this.lblCurrentOrgs.Location = new System.Drawing.Point(264, 352);
            this.lblCurrentOrgs.Name = "lblCurrentOrgs";
            this.lblCurrentOrgs.Size = new System.Drawing.Size(196, 20);
            this.lblCurrentOrgs.TabIndex = 6;
            this.lblCurrentOrgs.Text = "Characters Current Organizations:";
            this.lblCurrentOrgs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxOrgs
            // 
            this.lblMaxOrgs.Location = new System.Drawing.Point(264, 52);
            this.lblMaxOrgs.Name = "lblMaxOrgs";
            this.lblMaxOrgs.Size = new System.Drawing.Size(196, 56);
            this.lblMaxOrgs.TabIndex = 5;
            this.lblMaxOrgs.Text = "Maximum Number of Organizations allowed:";
            this.lblMaxOrgs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRemoveAllFP
            // 
            this.btnRemoveAllFP.Enabled = false;
            this.btnRemoveAllFP.Location = new System.Drawing.Point(216, 228);
            this.btnRemoveAllFP.Name = "btnRemoveAllFP";
            this.btnRemoveAllFP.Size = new System.Drawing.Size(36, 24);
            this.btnRemoveAllFP.TabIndex = 4;
            this.btnRemoveAllFP.Text = "<<";
            this.btnRemoveAllFP.UseVisualStyleBackColor = true;
            this.btnRemoveAllFP.Click += new System.EventHandler(this.btnRemoveAllOrg_Click);
            // 
            // btnRemoveFP
            // 
            this.btnRemoveFP.Enabled = false;
            this.btnRemoveFP.Location = new System.Drawing.Point(216, 200);
            this.btnRemoveFP.Name = "btnRemoveFP";
            this.btnRemoveFP.Size = new System.Drawing.Size(36, 24);
            this.btnRemoveFP.TabIndex = 3;
            this.btnRemoveFP.Text = "<";
            this.btnRemoveFP.UseVisualStyleBackColor = true;
            this.btnRemoveFP.Click += new System.EventHandler(this.btnRemoveOrg_Click);
            // 
            // btnAddFP
            // 
            this.btnAddFP.Enabled = false;
            this.btnAddFP.Location = new System.Drawing.Point(216, 172);
            this.btnAddFP.Name = "btnAddFP";
            this.btnAddFP.Size = new System.Drawing.Size(36, 24);
            this.btnAddFP.TabIndex = 2;
            this.btnAddFP.Text = ">";
            this.btnAddFP.UseVisualStyleBackColor = true;
            this.btnAddFP.Click += new System.EventHandler(this.btnAddOrg_Click);
            // 
            // tvSelectedOrganizations
            // 
            this.tvSelectedOrganizations.Location = new System.Drawing.Point(264, 116);
            this.tvSelectedOrganizations.Name = "tvSelectedOrganizations";
            this.tvSelectedOrganizations.Size = new System.Drawing.Size(196, 224);
            this.tvSelectedOrganizations.TabIndex = 1;
            this.tvSelectedOrganizations.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSelectedOrganizations_AfterSelect);
            // 
            // tvOrganizationList
            // 
            this.tvOrganizationList.Location = new System.Drawing.Point(8, 24);
            this.tvOrganizationList.Name = "tvOrganizationList";
            this.tvOrganizationList.Size = new System.Drawing.Size(196, 492);
            this.tvOrganizationList.TabIndex = 0;
            this.tvOrganizationList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOrganizationList_AfterSelect);
            // 
            // gpOrganizationInfo
            // 
            this.gpOrganizationInfo.Controls.Add(this.txtOrganizationDescription);
            this.gpOrganizationInfo.Controls.Add(this.lblOrganizationDescription);
            this.gpOrganizationInfo.Controls.Add(this.txtForceTradition);
            this.gpOrganizationInfo.Controls.Add(this.lblOrganization);
            this.gpOrganizationInfo.Controls.Add(this.lblOrganizationAllies);
            this.gpOrganizationInfo.Controls.Add(this.cmbOrganization);
            this.gpOrganizationInfo.Controls.Add(this.lblForceTradition);
            this.gpOrganizationInfo.Controls.Add(this.txtOrganizationAllies);
            this.gpOrganizationInfo.Controls.Add(this.txtOrganizationType);
            this.gpOrganizationInfo.Controls.Add(this.lblOrganizationEnemies);
            this.gpOrganizationInfo.Controls.Add(this.lblOrganizationType);
            this.gpOrganizationInfo.Controls.Add(this.txtOrganizationEnemies);
            this.gpOrganizationInfo.Controls.Add(this.txtOrganizationScale);
            this.gpOrganizationInfo.Controls.Add(this.lblOrganizationScale);
            this.gpOrganizationInfo.Location = new System.Drawing.Point(480, 4);
            this.gpOrganizationInfo.Name = "gpOrganizationInfo";
            this.gpOrganizationInfo.Size = new System.Drawing.Size(500, 464);
            this.gpOrganizationInfo.TabIndex = 17;
            this.gpOrganizationInfo.TabStop = false;
            this.gpOrganizationInfo.Text = "Organization Information";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(700, 488);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 28);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmOrganization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 529);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gpOrganizationInfo);
            this.Controls.Add(this.gpOrganizationSelection);
            this.Controls.Add(this.btnSetOrganizations);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOrganization";
            this.Text = "Organization";
            this.gpOrganizationSelection.ResumeLayout(false);
            this.gpOrganizationInfo.ResumeLayout(false);
            this.gpOrganizationInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbOrganization;
        private System.Windows.Forms.Label lblOrganization;
        private System.Windows.Forms.Label lblOrganizationDescription;
        private System.Windows.Forms.TextBox txtOrganizationDescription;
        private System.Windows.Forms.TextBox txtOrganizationAllies;
        private System.Windows.Forms.Label lblOrganizationAllies;
        private System.Windows.Forms.TextBox txtOrganizationEnemies;
        private System.Windows.Forms.Label lblOrganizationEnemies;
        private System.Windows.Forms.Button btnSetOrganizations;
        private System.Windows.Forms.Label lblOrganizationScale;
        private System.Windows.Forms.TextBox txtOrganizationScale;
        private System.Windows.Forms.TextBox txtOrganizationType;
        private System.Windows.Forms.Label lblOrganizationType;
        private System.Windows.Forms.TextBox txtForceTradition;
        private System.Windows.Forms.Label lblForceTradition;
        private System.Windows.Forms.GroupBox gpOrganizationSelection;
        private System.Windows.Forms.Button btnRemoveAllFP;
        private System.Windows.Forms.Button btnRemoveFP;
        private System.Windows.Forms.Button btnAddFP;
        private System.Windows.Forms.TreeView tvSelectedOrganizations;
        private System.Windows.Forms.TreeView tvOrganizationList;
        private System.Windows.Forms.GroupBox gpOrganizationInfo;
        private System.Windows.Forms.Label lblMaxOrgs;
        private System.Windows.Forms.Label lblCurrentOrgs;
        private System.Windows.Forms.TreeView tvCharacterOrgs;
        private System.Windows.Forms.Button btnCancel;
    }
}