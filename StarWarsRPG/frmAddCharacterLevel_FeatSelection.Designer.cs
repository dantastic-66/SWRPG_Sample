namespace StarWarsRPG
{
    partial class frmAddCharacterLevel_FeatSelection
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
            this.gpFeats = new System.Windows.Forms.GroupBox();
            this.tvFeatList = new System.Windows.Forms.TreeView();
            this.ckbRageRequired = new System.Windows.Forms.CheckBox();
            this.ckbShapeShiftRequired = new System.Windows.Forms.CheckBox();
            this.txtFeatName = new System.Windows.Forms.TextBox();
            this.lblFeatName = new System.Windows.Forms.Label();
            this.lblFeatDescription = new System.Windows.Forms.Label();
            this.txtFeatDescription = new System.Windows.Forms.TextBox();
            this.lblFeatSpecial = new System.Windows.Forms.Label();
            this.txtFeatSpecial = new System.Windows.Forms.TextBox();
            this.ckMultipleAllowed = new System.Windows.Forms.CheckBox();
            this.ckbRemoveBonusFeats = new System.Windows.Forms.CheckBox();
            this.btnSelectFeat = new System.Windows.Forms.Button();
            this.gpFeats.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpFeats
            // 
            this.gpFeats.Controls.Add(this.tvFeatList);
            this.gpFeats.Location = new System.Drawing.Point(4, 8);
            this.gpFeats.Name = "gpFeats";
            this.gpFeats.Size = new System.Drawing.Size(280, 464);
            this.gpFeats.TabIndex = 0;
            this.gpFeats.TabStop = false;
            this.gpFeats.Text = "Select Level Feat";
            // 
            // tvFeatList
            // 
            this.tvFeatList.Location = new System.Drawing.Point(8, 24);
            this.tvFeatList.Name = "tvFeatList";
            this.tvFeatList.Size = new System.Drawing.Size(268, 436);
            this.tvFeatList.TabIndex = 0;
            this.tvFeatList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFeatList_AfterSelect);
            // 
            // ckbRageRequired
            // 
            this.ckbRageRequired.AutoSize = true;
            this.ckbRageRequired.Enabled = false;
            this.ckbRageRequired.Location = new System.Drawing.Point(312, 16);
            this.ckbRageRequired.Name = "ckbRageRequired";
            this.ckbRageRequired.Size = new System.Drawing.Size(102, 17);
            this.ckbRageRequired.TabIndex = 1;
            this.ckbRageRequired.Text = "Rage Required";
            this.ckbRageRequired.UseVisualStyleBackColor = true;
            // 
            // ckbShapeShiftRequired
            // 
            this.ckbShapeShiftRequired.AutoSize = true;
            this.ckbShapeShiftRequired.Enabled = false;
            this.ckbShapeShiftRequired.Location = new System.Drawing.Point(312, 36);
            this.ckbShapeShiftRequired.Name = "ckbShapeShiftRequired";
            this.ckbShapeShiftRequired.Size = new System.Drawing.Size(135, 17);
            this.ckbShapeShiftRequired.TabIndex = 2;
            this.ckbShapeShiftRequired.Text = "Shape Shift Required";
            this.ckbShapeShiftRequired.UseVisualStyleBackColor = true;
            // 
            // txtFeatName
            // 
            this.txtFeatName.Location = new System.Drawing.Point(376, 80);
            this.txtFeatName.Name = "txtFeatName";
            this.txtFeatName.ReadOnly = true;
            this.txtFeatName.Size = new System.Drawing.Size(288, 22);
            this.txtFeatName.TabIndex = 3;
            // 
            // lblFeatName
            // 
            this.lblFeatName.Location = new System.Drawing.Point(304, 80);
            this.lblFeatName.Name = "lblFeatName";
            this.lblFeatName.Size = new System.Drawing.Size(72, 22);
            this.lblFeatName.TabIndex = 4;
            this.lblFeatName.Text = "Feat Name:";
            this.lblFeatName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFeatDescription
            // 
            this.lblFeatDescription.Location = new System.Drawing.Point(280, 108);
            this.lblFeatDescription.Name = "lblFeatDescription";
            this.lblFeatDescription.Size = new System.Drawing.Size(96, 24);
            this.lblFeatDescription.TabIndex = 6;
            this.lblFeatDescription.Text = "Feat Description:";
            this.lblFeatDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFeatDescription
            // 
            this.txtFeatDescription.Location = new System.Drawing.Point(376, 104);
            this.txtFeatDescription.Multiline = true;
            this.txtFeatDescription.Name = "txtFeatDescription";
            this.txtFeatDescription.ReadOnly = true;
            this.txtFeatDescription.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtFeatDescription.Size = new System.Drawing.Size(288, 208);
            this.txtFeatDescription.TabIndex = 5;
            // 
            // lblFeatSpecial
            // 
            this.lblFeatSpecial.Location = new System.Drawing.Point(284, 316);
            this.lblFeatSpecial.Name = "lblFeatSpecial";
            this.lblFeatSpecial.Size = new System.Drawing.Size(92, 20);
            this.lblFeatSpecial.TabIndex = 8;
            this.lblFeatSpecial.Text = "Feat Special:";
            this.lblFeatSpecial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFeatSpecial
            // 
            this.txtFeatSpecial.Location = new System.Drawing.Point(376, 316);
            this.txtFeatSpecial.Multiline = true;
            this.txtFeatSpecial.Name = "txtFeatSpecial";
            this.txtFeatSpecial.ReadOnly = true;
            this.txtFeatSpecial.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtFeatSpecial.Size = new System.Drawing.Size(288, 152);
            this.txtFeatSpecial.TabIndex = 7;
            // 
            // ckMultipleAllowed
            // 
            this.ckMultipleAllowed.AutoSize = true;
            this.ckMultipleAllowed.Enabled = false;
            this.ckMultipleAllowed.Location = new System.Drawing.Point(312, 56);
            this.ckMultipleAllowed.Name = "ckMultipleAllowed";
            this.ckMultipleAllowed.Size = new System.Drawing.Size(203, 17);
            this.ckMultipleAllowed.TabIndex = 10;
            this.ckMultipleAllowed.Text = "Multiple Selection of Feat Allowed";
            this.ckMultipleAllowed.UseVisualStyleBackColor = true;
            // 
            // ckbRemoveBonusFeats
            // 
            this.ckbRemoveBonusFeats.AutoSize = true;
            this.ckbRemoveBonusFeats.Location = new System.Drawing.Point(528, 8);
            this.ckbRemoveBonusFeats.Name = "ckbRemoveBonusFeats";
            this.ckbRemoveBonusFeats.Size = new System.Drawing.Size(132, 17);
            this.ckbRemoveBonusFeats.TabIndex = 11;
            this.ckbRemoveBonusFeats.Text = "Remove Bonus Feats";
            this.ckbRemoveBonusFeats.UseVisualStyleBackColor = true;
            this.ckbRemoveBonusFeats.CheckedChanged += new System.EventHandler(this.ckbRemoveBonusFeats_CheckedChanged);
            // 
            // btnSelectFeat
            // 
            this.btnSelectFeat.Enabled = false;
            this.btnSelectFeat.Location = new System.Drawing.Point(536, 40);
            this.btnSelectFeat.Name = "btnSelectFeat";
            this.btnSelectFeat.Size = new System.Drawing.Size(108, 32);
            this.btnSelectFeat.TabIndex = 12;
            this.btnSelectFeat.Text = "Select &Feat";
            this.btnSelectFeat.UseVisualStyleBackColor = true;
            this.btnSelectFeat.Click += new System.EventHandler(this.btnSelectFeat_Click);
            // 
            // frmAddCharacterLevel_FeatSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 471);
            this.Controls.Add(this.btnSelectFeat);
            this.Controls.Add(this.ckbRemoveBonusFeats);
            this.Controls.Add(this.ckMultipleAllowed);
            this.Controls.Add(this.lblFeatSpecial);
            this.Controls.Add(this.txtFeatSpecial);
            this.Controls.Add(this.lblFeatDescription);
            this.Controls.Add(this.txtFeatDescription);
            this.Controls.Add(this.lblFeatName);
            this.Controls.Add(this.txtFeatName);
            this.Controls.Add(this.ckbShapeShiftRequired);
            this.Controls.Add(this.ckbRageRequired);
            this.Controls.Add(this.gpFeats);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.Name = "frmAddCharacterLevel_FeatSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Character Feat:";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddCharacterLevel_FeatSelection_FormClosed);
            this.gpFeats.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpFeats;
        private System.Windows.Forms.CheckBox ckbRageRequired;
        private System.Windows.Forms.CheckBox ckbShapeShiftRequired;
        private System.Windows.Forms.TextBox txtFeatName;
        private System.Windows.Forms.Label lblFeatName;
        private System.Windows.Forms.Label lblFeatDescription;
        private System.Windows.Forms.TextBox txtFeatDescription;
        private System.Windows.Forms.Label lblFeatSpecial;
        private System.Windows.Forms.TextBox txtFeatSpecial;
        private System.Windows.Forms.CheckBox ckMultipleAllowed;
        private System.Windows.Forms.TreeView tvFeatList;
        private System.Windows.Forms.CheckBox ckbRemoveBonusFeats;
        private System.Windows.Forms.Button btnSelectFeat;
    }
}