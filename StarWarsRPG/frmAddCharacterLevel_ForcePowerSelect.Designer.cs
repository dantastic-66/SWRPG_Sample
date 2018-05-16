namespace StarWarsRPG
{
    partial class frmAddCharacterLevel_ForcePowerSelect
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
            this.gpForcePowers = new System.Windows.Forms.GroupBox();
            this.lblForcePowerCount = new System.Windows.Forms.Label();
            this.btnRemoveAllFP = new System.Windows.Forms.Button();
            this.btnRemoveFP = new System.Windows.Forms.Button();
            this.btnAddFP = new System.Windows.Forms.Button();
            this.tvSelectedForcePowers = new System.Windows.Forms.TreeView();
            this.tvForcePowerList = new System.Windows.Forms.TreeView();
            this.lbForcePowerSpecial = new System.Windows.Forms.Label();
            this.txtForcePowerSpecial = new System.Windows.Forms.TextBox();
            this.lblForcePowerDescription = new System.Windows.Forms.Label();
            this.txtForcePowerDescription = new System.Windows.Forms.TextBox();
            this.lblForcePowerName = new System.Windows.Forms.Label();
            this.txtForcePowerName = new System.Windows.Forms.TextBox();
            this.lblTurnSegment = new System.Windows.Forms.Label();
            this.txtTurnSegment = new System.Windows.Forms.TextBox();
            this.lblForcePowerDescriptor = new System.Windows.Forms.Label();
            this.tvForcePowerDescriptor = new System.Windows.Forms.TreeView();
            this.lblForcePowerTarget = new System.Windows.Forms.Label();
            this.txtForcePowerTarget = new System.Windows.Forms.TextBox();
            this.btnSelectForcePower = new System.Windows.Forms.Button();
            this.txtCurrentCharacterForcePowers = new System.Windows.Forms.TextBox();
            this.lblCurrentForcePowers = new System.Windows.Forms.Label();
            this.gpForcePowers.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpForcePowers
            // 
            this.gpForcePowers.Controls.Add(this.txtCurrentCharacterForcePowers);
            this.gpForcePowers.Controls.Add(this.lblCurrentForcePowers);
            this.gpForcePowers.Controls.Add(this.lblForcePowerCount);
            this.gpForcePowers.Controls.Add(this.btnRemoveAllFP);
            this.gpForcePowers.Controls.Add(this.btnRemoveFP);
            this.gpForcePowers.Controls.Add(this.btnAddFP);
            this.gpForcePowers.Controls.Add(this.tvSelectedForcePowers);
            this.gpForcePowers.Controls.Add(this.tvForcePowerList);
            this.gpForcePowers.Location = new System.Drawing.Point(12, 8);
            this.gpForcePowers.Name = "gpForcePowers";
            this.gpForcePowers.Size = new System.Drawing.Size(368, 520);
            this.gpForcePowers.TabIndex = 1;
            this.gpForcePowers.TabStop = false;
            this.gpForcePowers.Text = "Select Force Power";
            // 
            // lblForcePowerCount
            // 
            this.lblForcePowerCount.Location = new System.Drawing.Point(244, 32);
            this.lblForcePowerCount.Name = "lblForcePowerCount";
            this.lblForcePowerCount.Size = new System.Drawing.Size(100, 28);
            this.lblForcePowerCount.TabIndex = 5;
            this.lblForcePowerCount.Text = "Available Force Powers:";
            this.lblForcePowerCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRemoveAllFP
            // 
            this.btnRemoveAllFP.Enabled = false;
            this.btnRemoveAllFP.Location = new System.Drawing.Point(196, 176);
            this.btnRemoveAllFP.Name = "btnRemoveAllFP";
            this.btnRemoveAllFP.Size = new System.Drawing.Size(36, 24);
            this.btnRemoveAllFP.TabIndex = 4;
            this.btnRemoveAllFP.Text = "<<";
            this.btnRemoveAllFP.UseVisualStyleBackColor = true;
            this.btnRemoveAllFP.Click += new System.EventHandler(this.btnRemoveAllFP_Click);
            // 
            // btnRemoveFP
            // 
            this.btnRemoveFP.Enabled = false;
            this.btnRemoveFP.Location = new System.Drawing.Point(196, 148);
            this.btnRemoveFP.Name = "btnRemoveFP";
            this.btnRemoveFP.Size = new System.Drawing.Size(36, 24);
            this.btnRemoveFP.TabIndex = 3;
            this.btnRemoveFP.Text = "<";
            this.btnRemoveFP.UseVisualStyleBackColor = true;
            this.btnRemoveFP.Click += new System.EventHandler(this.btnRemoveFP_Click);
            // 
            // btnAddFP
            // 
            this.btnAddFP.Enabled = false;
            this.btnAddFP.Location = new System.Drawing.Point(196, 120);
            this.btnAddFP.Name = "btnAddFP";
            this.btnAddFP.Size = new System.Drawing.Size(36, 24);
            this.btnAddFP.TabIndex = 2;
            this.btnAddFP.Text = ">";
            this.btnAddFP.UseVisualStyleBackColor = true;
            this.btnAddFP.Click += new System.EventHandler(this.btnAddFP_Click);
            // 
            // tvSelectedForcePowers
            // 
            this.tvSelectedForcePowers.Location = new System.Drawing.Point(240, 64);
            this.tvSelectedForcePowers.Name = "tvSelectedForcePowers";
            this.tvSelectedForcePowers.Size = new System.Drawing.Size(112, 224);
            this.tvSelectedForcePowers.TabIndex = 1;
            this.tvSelectedForcePowers.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSelectedForcePowers_AfterSelect);
            // 
            // tvForcePowerList
            // 
            this.tvForcePowerList.Location = new System.Drawing.Point(8, 24);
            this.tvForcePowerList.Name = "tvForcePowerList";
            this.tvForcePowerList.Size = new System.Drawing.Size(180, 492);
            this.tvForcePowerList.TabIndex = 0;
            this.tvForcePowerList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvForcePowerList_AfterSelect);
            // 
            // lbForcePowerSpecial
            // 
            this.lbForcePowerSpecial.Location = new System.Drawing.Point(392, 264);
            this.lbForcePowerSpecial.Name = "lbForcePowerSpecial";
            this.lbForcePowerSpecial.Size = new System.Drawing.Size(72, 32);
            this.lbForcePowerSpecial.TabIndex = 14;
            this.lbForcePowerSpecial.Text = "Force Power Special:";
            this.lbForcePowerSpecial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtForcePowerSpecial
            // 
            this.txtForcePowerSpecial.Location = new System.Drawing.Point(464, 264);
            this.txtForcePowerSpecial.Multiline = true;
            this.txtForcePowerSpecial.Name = "txtForcePowerSpecial";
            this.txtForcePowerSpecial.ReadOnly = true;
            this.txtForcePowerSpecial.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtForcePowerSpecial.Size = new System.Drawing.Size(372, 152);
            this.txtForcePowerSpecial.TabIndex = 13;
            // 
            // lblForcePowerDescription
            // 
            this.lblForcePowerDescription.Location = new System.Drawing.Point(392, 56);
            this.lblForcePowerDescription.Name = "lblForcePowerDescription";
            this.lblForcePowerDescription.Size = new System.Drawing.Size(72, 36);
            this.lblForcePowerDescription.TabIndex = 12;
            this.lblForcePowerDescription.Text = "Force Power Description:";
            this.lblForcePowerDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtForcePowerDescription
            // 
            this.txtForcePowerDescription.Location = new System.Drawing.Point(464, 52);
            this.txtForcePowerDescription.Multiline = true;
            this.txtForcePowerDescription.Name = "txtForcePowerDescription";
            this.txtForcePowerDescription.ReadOnly = true;
            this.txtForcePowerDescription.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtForcePowerDescription.Size = new System.Drawing.Size(372, 208);
            this.txtForcePowerDescription.TabIndex = 11;
            // 
            // lblForcePowerName
            // 
            this.lblForcePowerName.Location = new System.Drawing.Point(392, 8);
            this.lblForcePowerName.Name = "lblForcePowerName";
            this.lblForcePowerName.Size = new System.Drawing.Size(72, 28);
            this.lblForcePowerName.TabIndex = 10;
            this.lblForcePowerName.Text = "Force Power Name:";
            this.lblForcePowerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtForcePowerName
            // 
            this.txtForcePowerName.Location = new System.Drawing.Point(464, 8);
            this.txtForcePowerName.Name = "txtForcePowerName";
            this.txtForcePowerName.ReadOnly = true;
            this.txtForcePowerName.Size = new System.Drawing.Size(288, 22);
            this.txtForcePowerName.TabIndex = 9;
            // 
            // lblTurnSegment
            // 
            this.lblTurnSegment.Location = new System.Drawing.Point(388, 444);
            this.lblTurnSegment.Name = "lblTurnSegment";
            this.lblTurnSegment.Size = new System.Drawing.Size(72, 28);
            this.lblTurnSegment.TabIndex = 16;
            this.lblTurnSegment.Text = "Turn Segment:";
            this.lblTurnSegment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTurnSegment
            // 
            this.txtTurnSegment.Location = new System.Drawing.Point(464, 444);
            this.txtTurnSegment.Name = "txtTurnSegment";
            this.txtTurnSegment.ReadOnly = true;
            this.txtTurnSegment.Size = new System.Drawing.Size(372, 22);
            this.txtTurnSegment.TabIndex = 15;
            // 
            // lblForcePowerDescriptor
            // 
            this.lblForcePowerDescriptor.Location = new System.Drawing.Point(392, 476);
            this.lblForcePowerDescriptor.Name = "lblForcePowerDescriptor";
            this.lblForcePowerDescriptor.Size = new System.Drawing.Size(72, 28);
            this.lblForcePowerDescriptor.TabIndex = 17;
            this.lblForcePowerDescriptor.Text = "Force Power Descriptors:";
            this.lblForcePowerDescriptor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tvForcePowerDescriptor
            // 
            this.tvForcePowerDescriptor.Location = new System.Drawing.Point(464, 476);
            this.tvForcePowerDescriptor.Name = "tvForcePowerDescriptor";
            this.tvForcePowerDescriptor.Size = new System.Drawing.Size(176, 52);
            this.tvForcePowerDescriptor.TabIndex = 18;
            // 
            // lblForcePowerTarget
            // 
            this.lblForcePowerTarget.Location = new System.Drawing.Point(388, 416);
            this.lblForcePowerTarget.Name = "lblForcePowerTarget";
            this.lblForcePowerTarget.Size = new System.Drawing.Size(72, 28);
            this.lblForcePowerTarget.TabIndex = 20;
            this.lblForcePowerTarget.Text = "Force Power Target";
            this.lblForcePowerTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtForcePowerTarget
            // 
            this.txtForcePowerTarget.Location = new System.Drawing.Point(464, 416);
            this.txtForcePowerTarget.Name = "txtForcePowerTarget";
            this.txtForcePowerTarget.ReadOnly = true;
            this.txtForcePowerTarget.Size = new System.Drawing.Size(372, 22);
            this.txtForcePowerTarget.TabIndex = 19;
            // 
            // btnSelectForcePower
            // 
            this.btnSelectForcePower.Enabled = false;
            this.btnSelectForcePower.Location = new System.Drawing.Point(756, 8);
            this.btnSelectForcePower.Name = "btnSelectForcePower";
            this.btnSelectForcePower.Size = new System.Drawing.Size(100, 36);
            this.btnSelectForcePower.TabIndex = 21;
            this.btnSelectForcePower.Text = "Accept Selected Force Power(s)";
            this.btnSelectForcePower.UseVisualStyleBackColor = true;
            this.btnSelectForcePower.Click += new System.EventHandler(this.btnSelectForcePower_Click);
            // 
            // txtCurrentCharacterForcePowers
            // 
            this.txtCurrentCharacterForcePowers.Location = new System.Drawing.Point(192, 348);
            this.txtCurrentCharacterForcePowers.Multiline = true;
            this.txtCurrentCharacterForcePowers.Name = "txtCurrentCharacterForcePowers";
            this.txtCurrentCharacterForcePowers.ReadOnly = true;
            this.txtCurrentCharacterForcePowers.Size = new System.Drawing.Size(172, 164);
            this.txtCurrentCharacterForcePowers.TabIndex = 25;
            // 
            // lblCurrentForcePowers
            // 
            this.lblCurrentForcePowers.AutoSize = true;
            this.lblCurrentForcePowers.Location = new System.Drawing.Point(192, 328);
            this.lblCurrentForcePowers.Name = "lblCurrentForcePowers";
            this.lblCurrentForcePowers.Size = new System.Drawing.Size(172, 13);
            this.lblCurrentForcePowers.TabIndex = 24;
            this.lblCurrentForcePowers.Text = "Current Character Force Powers:";
            // 
            // frmAddCharacterLevel_ForcePowerSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(878, 532);
            this.Controls.Add(this.btnSelectForcePower);
            this.Controls.Add(this.lblForcePowerTarget);
            this.Controls.Add(this.txtForcePowerTarget);
            this.Controls.Add(this.tvForcePowerDescriptor);
            this.Controls.Add(this.lblForcePowerDescriptor);
            this.Controls.Add(this.lblTurnSegment);
            this.Controls.Add(this.txtTurnSegment);
            this.Controls.Add(this.lbForcePowerSpecial);
            this.Controls.Add(this.gpForcePowers);
            this.Controls.Add(this.txtForcePowerSpecial);
            this.Controls.Add(this.lblForcePowerName);
            this.Controls.Add(this.lblForcePowerDescription);
            this.Controls.Add(this.txtForcePowerName);
            this.Controls.Add(this.txtForcePowerDescription);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddCharacterLevel_ForcePowerSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Force Power";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddCharacterLevel_ForcePowerSelect_FormClosed);
            this.gpForcePowers.ResumeLayout(false);
            this.gpForcePowers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpForcePowers;
        private System.Windows.Forms.TreeView tvForcePowerList;
        private System.Windows.Forms.Label lbForcePowerSpecial;
        private System.Windows.Forms.TextBox txtForcePowerSpecial;
        private System.Windows.Forms.Label lblForcePowerDescription;
        private System.Windows.Forms.TextBox txtForcePowerDescription;
        private System.Windows.Forms.Label lblForcePowerName;
        private System.Windows.Forms.TextBox txtForcePowerName;
        private System.Windows.Forms.Label lblTurnSegment;
        private System.Windows.Forms.TextBox txtTurnSegment;
        private System.Windows.Forms.Label lblForcePowerDescriptor;
        private System.Windows.Forms.TreeView tvForcePowerDescriptor;
        private System.Windows.Forms.Label lblForcePowerTarget;
        private System.Windows.Forms.TextBox txtForcePowerTarget;
        private System.Windows.Forms.Button btnSelectForcePower;
        private System.Windows.Forms.Label lblForcePowerCount;
        private System.Windows.Forms.Button btnRemoveAllFP;
        private System.Windows.Forms.Button btnRemoveFP;
        private System.Windows.Forms.Button btnAddFP;
        private System.Windows.Forms.TreeView tvSelectedForcePowers;
        private System.Windows.Forms.TextBox txtCurrentCharacterForcePowers;
        private System.Windows.Forms.Label lblCurrentForcePowers;
    }
}