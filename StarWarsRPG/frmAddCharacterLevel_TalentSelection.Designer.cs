namespace StarWarsRPG
{
    partial class frmAddCharacterLevel_TalentSelection
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
            this.tvTalentTreeTalents = new System.Windows.Forms.TreeView();
            this.gbTalentTree = new System.Windows.Forms.GroupBox();
            this.ckbForceTalentTree = new System.Windows.Forms.CheckBox();
            this.gbTalent = new System.Windows.Forms.GroupBox();
            this.gpTalentPrereqs = new System.Windows.Forms.GroupBox();
            this.lblSkillReq = new System.Windows.Forms.Label();
            this.lstSkillsReq = new System.Windows.Forms.ListBox();
            this.txtBaseAttackReq = new System.Windows.Forms.TextBox();
            this.lblBaseAttackPrereq = new System.Windows.Forms.Label();
            this.lblForcePowerReq = new System.Windows.Forms.Label();
            this.lstForcePowerReq = new System.Windows.Forms.ListBox();
            this.lblAbilitiesReq = new System.Windows.Forms.Label();
            this.lstAbilitiesReq = new System.Windows.Forms.ListBox();
            this.lblTalentRequired = new System.Windows.Forms.Label();
            this.lstTalentsReq = new System.Windows.Forms.ListBox();
            this.lblFeatPrereq = new System.Windows.Forms.Label();
            this.lstFeatsReq = new System.Windows.Forms.ListBox();
            this.txtTalentSpecial = new System.Windows.Forms.TextBox();
            this.lblTurnSegment = new System.Windows.Forms.Label();
            this.txtTalentDescription = new System.Windows.Forms.TextBox();
            this.lblTalentName = new System.Windows.Forms.Label();
            this.btnSelectTalent = new System.Windows.Forms.Button();
            this.gbTalentTree.SuspendLayout();
            this.gbTalent.SuspendLayout();
            this.gpTalentPrereqs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvTalentTreeTalents
            // 
            this.tvTalentTreeTalents.Location = new System.Drawing.Point(4, 12);
            this.tvTalentTreeTalents.Name = "tvTalentTreeTalents";
            this.tvTalentTreeTalents.Size = new System.Drawing.Size(284, 560);
            this.tvTalentTreeTalents.TabIndex = 0;
            this.tvTalentTreeTalents.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTalentTreeTalents_AfterSelect);
            // 
            // gbTalentTree
            // 
            this.gbTalentTree.Controls.Add(this.ckbForceTalentTree);
            this.gbTalentTree.Location = new System.Drawing.Point(292, 16);
            this.gbTalentTree.Name = "gbTalentTree";
            this.gbTalentTree.Size = new System.Drawing.Size(352, 52);
            this.gbTalentTree.TabIndex = 1;
            this.gbTalentTree.TabStop = false;
            this.gbTalentTree.Text = "Talent Tree";
            // 
            // ckbForceTalentTree
            // 
            this.ckbForceTalentTree.AutoSize = true;
            this.ckbForceTalentTree.Enabled = false;
            this.ckbForceTalentTree.Location = new System.Drawing.Point(12, 20);
            this.ckbForceTalentTree.Name = "ckbForceTalentTree";
            this.ckbForceTalentTree.Size = new System.Drawing.Size(112, 17);
            this.ckbForceTalentTree.TabIndex = 0;
            this.ckbForceTalentTree.Text = "Force Talent Tree";
            this.ckbForceTalentTree.UseVisualStyleBackColor = true;
            // 
            // gbTalent
            // 
            this.gbTalent.Controls.Add(this.gpTalentPrereqs);
            this.gbTalent.Controls.Add(this.txtTalentSpecial);
            this.gbTalent.Controls.Add(this.lblTurnSegment);
            this.gbTalent.Controls.Add(this.txtTalentDescription);
            this.gbTalent.Controls.Add(this.lblTalentName);
            this.gbTalent.Location = new System.Drawing.Point(292, 68);
            this.gbTalent.Name = "gbTalent";
            this.gbTalent.Size = new System.Drawing.Size(508, 504);
            this.gbTalent.TabIndex = 2;
            this.gbTalent.TabStop = false;
            this.gbTalent.Text = "Talent";
            // 
            // gpTalentPrereqs
            // 
            this.gpTalentPrereqs.Controls.Add(this.lblSkillReq);
            this.gpTalentPrereqs.Controls.Add(this.lstSkillsReq);
            this.gpTalentPrereqs.Controls.Add(this.txtBaseAttackReq);
            this.gpTalentPrereqs.Controls.Add(this.lblBaseAttackPrereq);
            this.gpTalentPrereqs.Controls.Add(this.lblForcePowerReq);
            this.gpTalentPrereqs.Controls.Add(this.lstForcePowerReq);
            this.gpTalentPrereqs.Controls.Add(this.lblAbilitiesReq);
            this.gpTalentPrereqs.Controls.Add(this.lstAbilitiesReq);
            this.gpTalentPrereqs.Controls.Add(this.lblTalentRequired);
            this.gpTalentPrereqs.Controls.Add(this.lstTalentsReq);
            this.gpTalentPrereqs.Controls.Add(this.lblFeatPrereq);
            this.gpTalentPrereqs.Controls.Add(this.lstFeatsReq);
            this.gpTalentPrereqs.Location = new System.Drawing.Point(328, 24);
            this.gpTalentPrereqs.Name = "gpTalentPrereqs";
            this.gpTalentPrereqs.Size = new System.Drawing.Size(180, 480);
            this.gpTalentPrereqs.TabIndex = 5;
            this.gpTalentPrereqs.TabStop = false;
            this.gpTalentPrereqs.Text = "Talent Prerequisities";
            // 
            // lblSkillReq
            // 
            this.lblSkillReq.Location = new System.Drawing.Point(8, 192);
            this.lblSkillReq.Name = "lblSkillReq";
            this.lblSkillReq.Size = new System.Drawing.Size(84, 16);
            this.lblSkillReq.TabIndex = 15;
            this.lblSkillReq.Text = "Skills Required";
            // 
            // lstSkillsReq
            // 
            this.lstSkillsReq.FormattingEnabled = true;
            this.lstSkillsReq.Location = new System.Drawing.Point(4, 208);
            this.lstSkillsReq.Name = "lstSkillsReq";
            this.lstSkillsReq.Size = new System.Drawing.Size(172, 56);
            this.lstSkillsReq.TabIndex = 14;
            // 
            // txtBaseAttackReq
            // 
            this.txtBaseAttackReq.Location = new System.Drawing.Point(8, 448);
            this.txtBaseAttackReq.Name = "txtBaseAttackReq";
            this.txtBaseAttackReq.ReadOnly = true;
            this.txtBaseAttackReq.Size = new System.Drawing.Size(168, 22);
            this.txtBaseAttackReq.TabIndex = 13;
            // 
            // lblBaseAttackPrereq
            // 
            this.lblBaseAttackPrereq.Location = new System.Drawing.Point(8, 428);
            this.lblBaseAttackPrereq.Name = "lblBaseAttackPrereq";
            this.lblBaseAttackPrereq.Size = new System.Drawing.Size(136, 16);
            this.lblBaseAttackPrereq.TabIndex = 12;
            this.lblBaseAttackPrereq.Text = "Base Attack Requirement";
            // 
            // lblForcePowerReq
            // 
            this.lblForcePowerReq.Location = new System.Drawing.Point(8, 352);
            this.lblForcePowerReq.Name = "lblForcePowerReq";
            this.lblForcePowerReq.Size = new System.Drawing.Size(136, 16);
            this.lblForcePowerReq.TabIndex = 10;
            this.lblForcePowerReq.Text = "Force Powers Required";
            // 
            // lstForcePowerReq
            // 
            this.lstForcePowerReq.FormattingEnabled = true;
            this.lstForcePowerReq.Location = new System.Drawing.Point(4, 368);
            this.lstForcePowerReq.Name = "lstForcePowerReq";
            this.lstForcePowerReq.Size = new System.Drawing.Size(172, 56);
            this.lstForcePowerReq.TabIndex = 9;
            // 
            // lblAbilitiesReq
            // 
            this.lblAbilitiesReq.Location = new System.Drawing.Point(8, 272);
            this.lblAbilitiesReq.Name = "lblAbilitiesReq";
            this.lblAbilitiesReq.Size = new System.Drawing.Size(100, 16);
            this.lblAbilitiesReq.TabIndex = 8;
            this.lblAbilitiesReq.Text = "Abilities Required";
            // 
            // lstAbilitiesReq
            // 
            this.lstAbilitiesReq.FormattingEnabled = true;
            this.lstAbilitiesReq.Location = new System.Drawing.Point(4, 288);
            this.lstAbilitiesReq.Name = "lstAbilitiesReq";
            this.lstAbilitiesReq.Size = new System.Drawing.Size(172, 56);
            this.lstAbilitiesReq.TabIndex = 7;
            // 
            // lblTalentRequired
            // 
            this.lblTalentRequired.Location = new System.Drawing.Point(8, 20);
            this.lblTalentRequired.Name = "lblTalentRequired";
            this.lblTalentRequired.Size = new System.Drawing.Size(92, 16);
            this.lblTalentRequired.TabIndex = 6;
            this.lblTalentRequired.Text = "Talent Required";
            // 
            // lstTalentsReq
            // 
            this.lstTalentsReq.FormattingEnabled = true;
            this.lstTalentsReq.Location = new System.Drawing.Point(4, 36);
            this.lstTalentsReq.Name = "lstTalentsReq";
            this.lstTalentsReq.Size = new System.Drawing.Size(172, 69);
            this.lstTalentsReq.TabIndex = 5;
            // 
            // lblFeatPrereq
            // 
            this.lblFeatPrereq.Location = new System.Drawing.Point(4, 116);
            this.lblFeatPrereq.Name = "lblFeatPrereq";
            this.lblFeatPrereq.Size = new System.Drawing.Size(84, 16);
            this.lblFeatPrereq.TabIndex = 4;
            this.lblFeatPrereq.Text = "Feats Required";
            // 
            // lstFeatsReq
            // 
            this.lstFeatsReq.FormattingEnabled = true;
            this.lstFeatsReq.Location = new System.Drawing.Point(0, 132);
            this.lstFeatsReq.Name = "lstFeatsReq";
            this.lstFeatsReq.Size = new System.Drawing.Size(172, 56);
            this.lstFeatsReq.TabIndex = 0;
            // 
            // txtTalentSpecial
            // 
            this.txtTalentSpecial.Location = new System.Drawing.Point(8, 336);
            this.txtTalentSpecial.Multiline = true;
            this.txtTalentSpecial.Name = "txtTalentSpecial";
            this.txtTalentSpecial.ReadOnly = true;
            this.txtTalentSpecial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTalentSpecial.Size = new System.Drawing.Size(316, 160);
            this.txtTalentSpecial.TabIndex = 4;
            this.txtTalentSpecial.Text = "txtTalentSpecial";
            // 
            // lblTurnSegment
            // 
            this.lblTurnSegment.Location = new System.Drawing.Point(8, 44);
            this.lblTurnSegment.Name = "lblTurnSegment";
            this.lblTurnSegment.Size = new System.Drawing.Size(264, 20);
            this.lblTurnSegment.TabIndex = 3;
            this.lblTurnSegment.Text = "lblTurnSegment";
            // 
            // txtTalentDescription
            // 
            this.txtTalentDescription.Location = new System.Drawing.Point(8, 68);
            this.txtTalentDescription.Multiline = true;
            this.txtTalentDescription.Name = "txtTalentDescription";
            this.txtTalentDescription.ReadOnly = true;
            this.txtTalentDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTalentDescription.Size = new System.Drawing.Size(316, 268);
            this.txtTalentDescription.TabIndex = 2;
            this.txtTalentDescription.Text = "txtTalentDescription";
            // 
            // lblTalentName
            // 
            this.lblTalentName.Location = new System.Drawing.Point(8, 20);
            this.lblTalentName.Name = "lblTalentName";
            this.lblTalentName.Size = new System.Drawing.Size(312, 20);
            this.lblTalentName.TabIndex = 0;
            this.lblTalentName.Text = "lblTalentName";
            // 
            // btnSelectTalent
            // 
            this.btnSelectTalent.Enabled = false;
            this.btnSelectTalent.Location = new System.Drawing.Point(684, 24);
            this.btnSelectTalent.Name = "btnSelectTalent";
            this.btnSelectTalent.Size = new System.Drawing.Size(88, 36);
            this.btnSelectTalent.TabIndex = 3;
            this.btnSelectTalent.Text = "Select Talent";
            this.btnSelectTalent.UseVisualStyleBackColor = true;
            this.btnSelectTalent.Click += new System.EventHandler(this.btnSelectTalent_Click);
            // 
            // frmAddCharacterLevel_TalentSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 576);
            this.Controls.Add(this.btnSelectTalent);
            this.Controls.Add(this.gbTalent);
            this.Controls.Add(this.gbTalentTree);
            this.Controls.Add(this.tvTalentTreeTalents);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddCharacterLevel_TalentSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Character Talent:";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddCharacterLevel_TalentSelection_FormClosed);
            this.gbTalentTree.ResumeLayout(false);
            this.gbTalentTree.PerformLayout();
            this.gbTalent.ResumeLayout(false);
            this.gbTalent.PerformLayout();
            this.gpTalentPrereqs.ResumeLayout(false);
            this.gpTalentPrereqs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvTalentTreeTalents;
        private System.Windows.Forms.GroupBox gbTalentTree;
        private System.Windows.Forms.CheckBox ckbForceTalentTree;
        private System.Windows.Forms.GroupBox gbTalent;
        private System.Windows.Forms.Label lblTurnSegment;
        private System.Windows.Forms.TextBox txtTalentDescription;
        private System.Windows.Forms.Label lblTalentName;
        private System.Windows.Forms.Button btnSelectTalent;
        private System.Windows.Forms.TextBox txtTalentSpecial;
        private System.Windows.Forms.GroupBox gpTalentPrereqs;
        private System.Windows.Forms.ListBox lstFeatsReq;
        private System.Windows.Forms.Label lblTalentRequired;
        private System.Windows.Forms.ListBox lstTalentsReq;
        private System.Windows.Forms.Label lblFeatPrereq;
        private System.Windows.Forms.TextBox txtBaseAttackReq;
        private System.Windows.Forms.Label lblBaseAttackPrereq;
        private System.Windows.Forms.Label lblForcePowerReq;
        private System.Windows.Forms.ListBox lstForcePowerReq;
        private System.Windows.Forms.Label lblAbilitiesReq;
        private System.Windows.Forms.ListBox lstAbilitiesReq;
        private System.Windows.Forms.Label lblSkillReq;
        private System.Windows.Forms.ListBox lstSkillsReq;
    }
}