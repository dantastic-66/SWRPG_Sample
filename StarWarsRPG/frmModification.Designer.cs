namespace StarWarsRPG
{
    partial class frmModification
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
            this.grpModificationList = new System.Windows.Forms.GroupBox();
            this.btnRemoveAllMods = new System.Windows.Forms.Button();
            this.btnRemoveMod = new System.Windows.Forms.Button();
            this.btnAddMod = new System.Windows.Forms.Button();
            this.tvSelectedModifications = new System.Windows.Forms.TreeView();
            this.tvModificationList = new System.Windows.Forms.TreeView();
            this.grpModificationItem = new System.Windows.Forms.GroupBox();
            this.txtUsedUpgradePoints = new System.Windows.Forms.TextBox();
            this.lblUsedUpdgradePoints = new System.Windows.Forms.Label();
            this.grpModification = new System.Windows.Forms.GroupBox();
            this.txtUpgradeDescription = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.lblCost = new System.Windows.Forms.Label();
            this.txtUpgradePoints = new System.Windows.Forms.TextBox();
            this.lblUpgradePoints = new System.Windows.Forms.Label();
            this.lblModificationName = new System.Windows.Forms.Label();
            this.txtModificationType = new System.Windows.Forms.TextBox();
            this.txtModificationName = new System.Windows.Forms.TextBox();
            this.lblModificationType = new System.Windows.Forms.Label();
            this.txtUpgradePointsAvailable = new System.Windows.Forms.TextBox();
            this.lblUpgradePointsAvailable = new System.Windows.Forms.Label();
            this.txtItemModified = new System.Windows.Forms.TextBox();
            this.lblItemModified = new System.Windows.Forms.Label();
            this.btnSubmitMods = new System.Windows.Forms.Button();
            this.grpModificationList.SuspendLayout();
            this.grpModificationItem.SuspendLayout();
            this.grpModification.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpModificationList
            // 
            this.grpModificationList.Controls.Add(this.btnRemoveAllMods);
            this.grpModificationList.Controls.Add(this.btnRemoveMod);
            this.grpModificationList.Controls.Add(this.btnAddMod);
            this.grpModificationList.Controls.Add(this.tvSelectedModifications);
            this.grpModificationList.Controls.Add(this.tvModificationList);
            this.grpModificationList.Location = new System.Drawing.Point(4, 8);
            this.grpModificationList.Name = "grpModificationList";
            this.grpModificationList.Size = new System.Drawing.Size(472, 436);
            this.grpModificationList.TabIndex = 0;
            this.grpModificationList.TabStop = false;
            this.grpModificationList.Text = "Modifications";
            // 
            // btnRemoveAllMods
            // 
            this.btnRemoveAllMods.Enabled = false;
            this.btnRemoveAllMods.Location = new System.Drawing.Point(216, 212);
            this.btnRemoveAllMods.Name = "btnRemoveAllMods";
            this.btnRemoveAllMods.Size = new System.Drawing.Size(36, 24);
            this.btnRemoveAllMods.TabIndex = 8;
            this.btnRemoveAllMods.Text = "<<";
            this.btnRemoveAllMods.UseVisualStyleBackColor = true;
            this.btnRemoveAllMods.Click += new System.EventHandler(this.btnRemoveAllMod_Click);
            // 
            // btnRemoveMod
            // 
            this.btnRemoveMod.Enabled = false;
            this.btnRemoveMod.Location = new System.Drawing.Point(216, 184);
            this.btnRemoveMod.Name = "btnRemoveMod";
            this.btnRemoveMod.Size = new System.Drawing.Size(36, 24);
            this.btnRemoveMod.TabIndex = 7;
            this.btnRemoveMod.Text = "<";
            this.btnRemoveMod.UseVisualStyleBackColor = true;
            this.btnRemoveMod.Click += new System.EventHandler(this.btnRemoveMod_Click);
            // 
            // btnAddMod
            // 
            this.btnAddMod.Enabled = false;
            this.btnAddMod.Location = new System.Drawing.Point(216, 156);
            this.btnAddMod.Name = "btnAddMod";
            this.btnAddMod.Size = new System.Drawing.Size(36, 24);
            this.btnAddMod.TabIndex = 6;
            this.btnAddMod.Text = ">";
            this.btnAddMod.UseVisualStyleBackColor = true;
            this.btnAddMod.Click += new System.EventHandler(this.btnAddMod_Click);
            // 
            // tvSelectedModifications
            // 
            this.tvSelectedModifications.Location = new System.Drawing.Point(256, 76);
            this.tvSelectedModifications.Name = "tvSelectedModifications";
            this.tvSelectedModifications.Size = new System.Drawing.Size(210, 224);
            this.tvSelectedModifications.TabIndex = 5;
            this.tvSelectedModifications.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSelectedModifications_AfterSelect);
            // 
            // tvModificationList
            // 
            this.tvModificationList.Location = new System.Drawing.Point(4, 20);
            this.tvModificationList.Name = "tvModificationList";
            this.tvModificationList.Size = new System.Drawing.Size(210, 412);
            this.tvModificationList.TabIndex = 0;
            this.tvModificationList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvModificationList_AfterSelect);
            // 
            // grpModificationItem
            // 
            this.grpModificationItem.Controls.Add(this.txtUsedUpgradePoints);
            this.grpModificationItem.Controls.Add(this.lblUsedUpdgradePoints);
            this.grpModificationItem.Controls.Add(this.grpModification);
            this.grpModificationItem.Controls.Add(this.txtUpgradePointsAvailable);
            this.grpModificationItem.Controls.Add(this.lblUpgradePointsAvailable);
            this.grpModificationItem.Controls.Add(this.txtItemModified);
            this.grpModificationItem.Controls.Add(this.lblItemModified);
            this.grpModificationItem.Location = new System.Drawing.Point(480, 40);
            this.grpModificationItem.Name = "grpModificationItem";
            this.grpModificationItem.Size = new System.Drawing.Size(352, 380);
            this.grpModificationItem.TabIndex = 1;
            this.grpModificationItem.TabStop = false;
            this.grpModificationItem.Text = "Modification Item";
            // 
            // txtUsedUpgradePoints
            // 
            this.txtUsedUpgradePoints.Location = new System.Drawing.Point(308, 44);
            this.txtUsedUpgradePoints.Name = "txtUsedUpgradePoints";
            this.txtUsedUpgradePoints.ReadOnly = true;
            this.txtUsedUpgradePoints.Size = new System.Drawing.Size(32, 23);
            this.txtUsedUpgradePoints.TabIndex = 10;
            // 
            // lblUsedUpdgradePoints
            // 
            this.lblUsedUpdgradePoints.AutoSize = true;
            this.lblUsedUpdgradePoints.Location = new System.Drawing.Point(168, 48);
            this.lblUsedUpdgradePoints.Name = "lblUsedUpdgradePoints";
            this.lblUsedUpdgradePoints.Size = new System.Drawing.Size(127, 15);
            this.lblUsedUpdgradePoints.TabIndex = 9;
            this.lblUsedUpdgradePoints.Text = "Used Updgrade Points:";
            // 
            // grpModification
            // 
            this.grpModification.Controls.Add(this.txtUpgradeDescription);
            this.grpModification.Controls.Add(this.txtCost);
            this.grpModification.Controls.Add(this.lblCost);
            this.grpModification.Controls.Add(this.txtUpgradePoints);
            this.grpModification.Controls.Add(this.lblUpgradePoints);
            this.grpModification.Controls.Add(this.lblModificationName);
            this.grpModification.Controls.Add(this.txtModificationType);
            this.grpModification.Controls.Add(this.txtModificationName);
            this.grpModification.Controls.Add(this.lblModificationType);
            this.grpModification.Location = new System.Drawing.Point(4, 72);
            this.grpModification.Name = "grpModification";
            this.grpModification.Size = new System.Drawing.Size(340, 312);
            this.grpModification.TabIndex = 8;
            this.grpModification.TabStop = false;
            // 
            // txtUpgradeDescription
            // 
            this.txtUpgradeDescription.Location = new System.Drawing.Point(8, 96);
            this.txtUpgradeDescription.Multiline = true;
            this.txtUpgradeDescription.Name = "txtUpgradeDescription";
            this.txtUpgradeDescription.ReadOnly = true;
            this.txtUpgradeDescription.Size = new System.Drawing.Size(328, 204);
            this.txtUpgradeDescription.TabIndex = 12;
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(204, 68);
            this.txtCost.Name = "txtCost";
            this.txtCost.ReadOnly = true;
            this.txtCost.Size = new System.Drawing.Size(44, 23);
            this.txtCost.TabIndex = 11;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(156, 72);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(34, 15);
            this.lblCost.TabIndex = 10;
            this.lblCost.Text = "Cost:";
            // 
            // txtUpgradePoints
            // 
            this.txtUpgradePoints.Location = new System.Drawing.Point(104, 68);
            this.txtUpgradePoints.Name = "txtUpgradePoints";
            this.txtUpgradePoints.ReadOnly = true;
            this.txtUpgradePoints.Size = new System.Drawing.Size(44, 23);
            this.txtUpgradePoints.TabIndex = 9;
            // 
            // lblUpgradePoints
            // 
            this.lblUpgradePoints.AutoSize = true;
            this.lblUpgradePoints.Location = new System.Drawing.Point(8, 72);
            this.lblUpgradePoints.Name = "lblUpgradePoints";
            this.lblUpgradePoints.Size = new System.Drawing.Size(91, 15);
            this.lblUpgradePoints.TabIndex = 8;
            this.lblUpgradePoints.Text = "Upgrade Points:";
            // 
            // lblModificationName
            // 
            this.lblModificationName.AutoSize = true;
            this.lblModificationName.Location = new System.Drawing.Point(8, 24);
            this.lblModificationName.Name = "lblModificationName";
            this.lblModificationName.Size = new System.Drawing.Size(113, 15);
            this.lblModificationName.TabIndex = 4;
            this.lblModificationName.Text = "Modification Name:";
            // 
            // txtModificationType
            // 
            this.txtModificationType.Location = new System.Drawing.Point(124, 44);
            this.txtModificationType.Name = "txtModificationType";
            this.txtModificationType.ReadOnly = true;
            this.txtModificationType.Size = new System.Drawing.Size(140, 23);
            this.txtModificationType.TabIndex = 7;
            // 
            // txtModificationName
            // 
            this.txtModificationName.Location = new System.Drawing.Point(124, 20);
            this.txtModificationName.Name = "txtModificationName";
            this.txtModificationName.ReadOnly = true;
            this.txtModificationName.Size = new System.Drawing.Size(204, 23);
            this.txtModificationName.TabIndex = 5;
            // 
            // lblModificationType
            // 
            this.lblModificationType.AutoSize = true;
            this.lblModificationType.Location = new System.Drawing.Point(8, 48);
            this.lblModificationType.Name = "lblModificationType";
            this.lblModificationType.Size = new System.Drawing.Size(107, 15);
            this.lblModificationType.TabIndex = 6;
            this.lblModificationType.Text = "Modification Type:";
            // 
            // txtUpgradePointsAvailable
            // 
            this.txtUpgradePointsAvailable.Location = new System.Drawing.Point(128, 44);
            this.txtUpgradePointsAvailable.Name = "txtUpgradePointsAvailable";
            this.txtUpgradePointsAvailable.ReadOnly = true;
            this.txtUpgradePointsAvailable.Size = new System.Drawing.Size(32, 23);
            this.txtUpgradePointsAvailable.TabIndex = 3;
            // 
            // lblUpgradePointsAvailable
            // 
            this.lblUpgradePointsAvailable.AutoSize = true;
            this.lblUpgradePointsAvailable.Location = new System.Drawing.Point(8, 48);
            this.lblUpgradePointsAvailable.Name = "lblUpgradePointsAvailable";
            this.lblUpgradePointsAvailable.Size = new System.Drawing.Size(116, 15);
            this.lblUpgradePointsAvailable.TabIndex = 2;
            this.lblUpgradePointsAvailable.Text = "Upgrade Points Max:";
            // 
            // txtItemModified
            // 
            this.txtItemModified.Location = new System.Drawing.Point(132, 20);
            this.txtItemModified.Name = "txtItemModified";
            this.txtItemModified.ReadOnly = true;
            this.txtItemModified.Size = new System.Drawing.Size(196, 23);
            this.txtItemModified.TabIndex = 1;
            // 
            // lblItemModified
            // 
            this.lblItemModified.AutoSize = true;
            this.lblItemModified.Location = new System.Drawing.Point(8, 24);
            this.lblItemModified.Name = "lblItemModified";
            this.lblItemModified.Size = new System.Drawing.Size(118, 15);
            this.lblItemModified.TabIndex = 0;
            this.lblItemModified.Text = "Item To Be Modified:";
            // 
            // btnSubmitMods
            // 
            this.btnSubmitMods.Location = new System.Drawing.Point(480, 12);
            this.btnSubmitMods.Name = "btnSubmitMods";
            this.btnSubmitMods.Size = new System.Drawing.Size(348, 24);
            this.btnSubmitMods.TabIndex = 2;
            this.btnSubmitMods.Text = "Accept Selected Mods";
            this.btnSubmitMods.UseVisualStyleBackColor = true;
            this.btnSubmitMods.Click += new System.EventHandler(this.btnSubmitMods_Click);
            // 
            // frmModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 443);
            this.Controls.Add(this.btnSubmitMods);
            this.Controls.Add(this.grpModificationItem);
            this.Controls.Add(this.grpModificationList);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modification";
            this.grpModificationList.ResumeLayout(false);
            this.grpModificationItem.ResumeLayout(false);
            this.grpModificationItem.PerformLayout();
            this.grpModification.ResumeLayout(false);
            this.grpModification.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpModificationList;
        private System.Windows.Forms.TreeView tvModificationList;
        private System.Windows.Forms.GroupBox grpModificationItem;
        private System.Windows.Forms.GroupBox grpModification;
        private System.Windows.Forms.TextBox txtUpgradeDescription;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.TextBox txtUpgradePoints;
        private System.Windows.Forms.Label lblUpgradePoints;
        private System.Windows.Forms.Label lblModificationName;
        private System.Windows.Forms.TextBox txtModificationType;
        private System.Windows.Forms.TextBox txtModificationName;
        private System.Windows.Forms.Label lblModificationType;
        private System.Windows.Forms.TextBox txtUpgradePointsAvailable;
        private System.Windows.Forms.Label lblUpgradePointsAvailable;
        private System.Windows.Forms.TextBox txtItemModified;
        private System.Windows.Forms.Label lblItemModified;
        private System.Windows.Forms.Button btnRemoveAllMods;
        private System.Windows.Forms.Button btnRemoveMod;
        private System.Windows.Forms.Button btnAddMod;
        private System.Windows.Forms.TreeView tvSelectedModifications;
        private System.Windows.Forms.Button btnSubmitMods;
        private System.Windows.Forms.TextBox txtUsedUpgradePoints;
        private System.Windows.Forms.Label lblUsedUpdgradePoints;
    }
}