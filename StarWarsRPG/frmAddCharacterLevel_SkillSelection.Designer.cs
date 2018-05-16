namespace StarWarsRPG
{
    partial class frmAddCharacterLevel_SkillSelection
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
            this.gpSkills = new System.Windows.Forms.GroupBox();
            this.txtCurrentCharacterSkills = new System.Windows.Forms.TextBox();
            this.lblCurrentSkills = new System.Windows.Forms.Label();
            this.lblSkillCount = new System.Windows.Forms.Label();
            this.btnRemoveAllSkill = new System.Windows.Forms.Button();
            this.btnRemoveSkill = new System.Windows.Forms.Button();
            this.btnAddSkill = new System.Windows.Forms.Button();
            this.tvSelectedSkills = new System.Windows.Forms.TreeView();
            this.tvSkillList = new System.Windows.Forms.TreeView();
            this.gbSkillInfo = new System.Windows.Forms.GroupBox();
            this.ckbTrained = new System.Windows.Forms.CheckBox();
            this.txtAbilityName = new System.Windows.Forms.TextBox();
            this.lblAbilityName = new System.Windows.Forms.Label();
            this.txtSkillDescription = new System.Windows.Forms.TextBox();
            this.lblSkillDescription = new System.Windows.Forms.Label();
            this.txtSkillName = new System.Windows.Forms.TextBox();
            this.lblSkillName = new System.Windows.Forms.Label();
            this.btnSelectSkills = new System.Windows.Forms.Button();
            this.gpSkills.SuspendLayout();
            this.gbSkillInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpSkills
            // 
            this.gpSkills.Controls.Add(this.txtCurrentCharacterSkills);
            this.gpSkills.Controls.Add(this.lblCurrentSkills);
            this.gpSkills.Controls.Add(this.lblSkillCount);
            this.gpSkills.Controls.Add(this.btnRemoveAllSkill);
            this.gpSkills.Controls.Add(this.btnRemoveSkill);
            this.gpSkills.Controls.Add(this.btnAddSkill);
            this.gpSkills.Controls.Add(this.tvSelectedSkills);
            this.gpSkills.Controls.Add(this.tvSkillList);
            this.gpSkills.Location = new System.Drawing.Point(4, 8);
            this.gpSkills.Name = "gpSkills";
            this.gpSkills.Size = new System.Drawing.Size(428, 464);
            this.gpSkills.TabIndex = 1;
            this.gpSkills.TabStop = false;
            this.gpSkills.Text = "Select Skill";
            // 
            // txtCurrentCharacterSkills
            // 
            this.txtCurrentCharacterSkills.Location = new System.Drawing.Point(216, 312);
            this.txtCurrentCharacterSkills.Multiline = true;
            this.txtCurrentCharacterSkills.Name = "txtCurrentCharacterSkills";
            this.txtCurrentCharacterSkills.ReadOnly = true;
            this.txtCurrentCharacterSkills.Size = new System.Drawing.Size(208, 144);
            this.txtCurrentCharacterSkills.TabIndex = 27;
            // 
            // lblCurrentSkills
            // 
            this.lblCurrentSkills.AutoSize = true;
            this.lblCurrentSkills.Location = new System.Drawing.Point(216, 292);
            this.lblCurrentSkills.Name = "lblCurrentSkills";
            this.lblCurrentSkills.Size = new System.Drawing.Size(130, 13);
            this.lblCurrentSkills.TabIndex = 26;
            this.lblCurrentSkills.Text = "Current Character Skills:";
            // 
            // lblSkillCount
            // 
            this.lblSkillCount.Location = new System.Drawing.Point(276, 28);
            this.lblSkillCount.Name = "lblSkillCount";
            this.lblSkillCount.Size = new System.Drawing.Size(100, 28);
            this.lblSkillCount.TabIndex = 10;
            this.lblSkillCount.Text = "Available Skills:";
            this.lblSkillCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRemoveAllSkill
            // 
            this.btnRemoveAllSkill.Enabled = false;
            this.btnRemoveAllSkill.Location = new System.Drawing.Point(216, 172);
            this.btnRemoveAllSkill.Name = "btnRemoveAllSkill";
            this.btnRemoveAllSkill.Size = new System.Drawing.Size(36, 24);
            this.btnRemoveAllSkill.TabIndex = 9;
            this.btnRemoveAllSkill.Text = "<<";
            this.btnRemoveAllSkill.UseVisualStyleBackColor = true;
            this.btnRemoveAllSkill.Click += new System.EventHandler(this.btnRemoveAllSkill_Click);
            // 
            // btnRemoveSkill
            // 
            this.btnRemoveSkill.Enabled = false;
            this.btnRemoveSkill.Location = new System.Drawing.Point(216, 144);
            this.btnRemoveSkill.Name = "btnRemoveSkill";
            this.btnRemoveSkill.Size = new System.Drawing.Size(36, 24);
            this.btnRemoveSkill.TabIndex = 8;
            this.btnRemoveSkill.Text = "<";
            this.btnRemoveSkill.UseVisualStyleBackColor = true;
            this.btnRemoveSkill.Click += new System.EventHandler(this.btnRemoveSkill_Click);
            // 
            // btnAddSkill
            // 
            this.btnAddSkill.Enabled = false;
            this.btnAddSkill.Location = new System.Drawing.Point(216, 116);
            this.btnAddSkill.Name = "btnAddSkill";
            this.btnAddSkill.Size = new System.Drawing.Size(36, 24);
            this.btnAddSkill.TabIndex = 7;
            this.btnAddSkill.Text = ">";
            this.btnAddSkill.UseVisualStyleBackColor = true;
            this.btnAddSkill.Click += new System.EventHandler(this.btnAddSkill_Click);
            // 
            // tvSelectedSkills
            // 
            this.tvSelectedSkills.Location = new System.Drawing.Point(256, 60);
            this.tvSelectedSkills.Name = "tvSelectedSkills";
            this.tvSelectedSkills.Size = new System.Drawing.Size(168, 224);
            this.tvSelectedSkills.TabIndex = 6;
            this.tvSelectedSkills.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSelectedSkills_AfterSelect);
            // 
            // tvSkillList
            // 
            this.tvSkillList.Location = new System.Drawing.Point(8, 24);
            this.tvSkillList.Name = "tvSkillList";
            this.tvSkillList.Size = new System.Drawing.Size(204, 436);
            this.tvSkillList.TabIndex = 0;
            this.tvSkillList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSkillList_AfterSelect);
            // 
            // gbSkillInfo
            // 
            this.gbSkillInfo.Controls.Add(this.ckbTrained);
            this.gbSkillInfo.Controls.Add(this.txtAbilityName);
            this.gbSkillInfo.Controls.Add(this.lblAbilityName);
            this.gbSkillInfo.Controls.Add(this.txtSkillDescription);
            this.gbSkillInfo.Controls.Add(this.lblSkillDescription);
            this.gbSkillInfo.Controls.Add(this.txtSkillName);
            this.gbSkillInfo.Controls.Add(this.lblSkillName);
            this.gbSkillInfo.Location = new System.Drawing.Point(448, 44);
            this.gbSkillInfo.Name = "gbSkillInfo";
            this.gbSkillInfo.Size = new System.Drawing.Size(268, 428);
            this.gbSkillInfo.TabIndex = 1;
            this.gbSkillInfo.TabStop = false;
            this.gbSkillInfo.Text = "Skill Info";
            // 
            // ckbTrained
            // 
            this.ckbTrained.AutoSize = true;
            this.ckbTrained.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbTrained.Enabled = false;
            this.ckbTrained.Location = new System.Drawing.Point(16, 404);
            this.ckbTrained.Name = "ckbTrained";
            this.ckbTrained.Size = new System.Drawing.Size(67, 17);
            this.ckbTrained.TabIndex = 6;
            this.ckbTrained.Text = "Trained:";
            this.ckbTrained.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbTrained.UseVisualStyleBackColor = true;
            // 
            // txtAbilityName
            // 
            this.txtAbilityName.Location = new System.Drawing.Point(88, 368);
            this.txtAbilityName.Name = "txtAbilityName";
            this.txtAbilityName.ReadOnly = true;
            this.txtAbilityName.Size = new System.Drawing.Size(180, 22);
            this.txtAbilityName.TabIndex = 5;
            // 
            // lblAbilityName
            // 
            this.lblAbilityName.Location = new System.Drawing.Point(8, 368);
            this.lblAbilityName.Name = "lblAbilityName";
            this.lblAbilityName.Size = new System.Drawing.Size(72, 28);
            this.lblAbilityName.TabIndex = 4;
            this.lblAbilityName.Text = "Ability Name:";
            this.lblAbilityName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSkillDescription
            // 
            this.txtSkillDescription.Location = new System.Drawing.Point(8, 76);
            this.txtSkillDescription.Multiline = true;
            this.txtSkillDescription.Name = "txtSkillDescription";
            this.txtSkillDescription.ReadOnly = true;
            this.txtSkillDescription.Size = new System.Drawing.Size(256, 288);
            this.txtSkillDescription.TabIndex = 3;
            // 
            // lblSkillDescription
            // 
            this.lblSkillDescription.Location = new System.Drawing.Point(8, 52);
            this.lblSkillDescription.Name = "lblSkillDescription";
            this.lblSkillDescription.Size = new System.Drawing.Size(260, 20);
            this.lblSkillDescription.TabIndex = 2;
            this.lblSkillDescription.Text = "Skill Description:";
            this.lblSkillDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSkillName
            // 
            this.txtSkillName.Location = new System.Drawing.Point(88, 24);
            this.txtSkillName.Name = "txtSkillName";
            this.txtSkillName.ReadOnly = true;
            this.txtSkillName.Size = new System.Drawing.Size(180, 22);
            this.txtSkillName.TabIndex = 1;
            // 
            // lblSkillName
            // 
            this.lblSkillName.Location = new System.Drawing.Point(8, 24);
            this.lblSkillName.Name = "lblSkillName";
            this.lblSkillName.Size = new System.Drawing.Size(72, 20);
            this.lblSkillName.TabIndex = 0;
            this.lblSkillName.Text = "Skill Name:";
            this.lblSkillName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSelectSkills
            // 
            this.btnSelectSkills.Enabled = false;
            this.btnSelectSkills.Location = new System.Drawing.Point(484, 12);
            this.btnSelectSkills.Name = "btnSelectSkills";
            this.btnSelectSkills.Size = new System.Drawing.Size(176, 28);
            this.btnSelectSkills.TabIndex = 2;
            this.btnSelectSkills.Text = "Accept Selected Skill(s)";
            this.btnSelectSkills.UseVisualStyleBackColor = true;
            this.btnSelectSkills.Click += new System.EventHandler(this.btnSelectSkills_Click);
            // 
            // frmAddCharacterLevel_SkillSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 473);
            this.Controls.Add(this.btnSelectSkills);
            this.Controls.Add(this.gbSkillInfo);
            this.Controls.Add(this.gpSkills);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddCharacterLevel_SkillSelection";
            this.Text = "Select Character Skill(s)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddCharacterLevel_SkillSelection_FormClosed);
            this.gpSkills.ResumeLayout(false);
            this.gpSkills.PerformLayout();
            this.gbSkillInfo.ResumeLayout(false);
            this.gbSkillInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpSkills;
        private System.Windows.Forms.TreeView tvSkillList;
        private System.Windows.Forms.GroupBox gbSkillInfo;
        private System.Windows.Forms.CheckBox ckbTrained;
        private System.Windows.Forms.TextBox txtAbilityName;
        private System.Windows.Forms.Label lblAbilityName;
        private System.Windows.Forms.TextBox txtSkillDescription;
        private System.Windows.Forms.Label lblSkillDescription;
        private System.Windows.Forms.TextBox txtSkillName;
        private System.Windows.Forms.Label lblSkillName;
        private System.Windows.Forms.Label lblSkillCount;
        private System.Windows.Forms.Button btnRemoveAllSkill;
        private System.Windows.Forms.Button btnRemoveSkill;
        private System.Windows.Forms.Button btnAddSkill;
        private System.Windows.Forms.TreeView tvSelectedSkills;
        private System.Windows.Forms.Button btnSelectSkills;
        private System.Windows.Forms.TextBox txtCurrentCharacterSkills;
        private System.Windows.Forms.Label lblCurrentSkills;
    }
}