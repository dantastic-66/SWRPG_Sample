namespace StarWarsRPG
{
    partial class frmAddCharacterLevel_ForceSecretSelection
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
            this.gpForceSecret = new System.Windows.Forms.GroupBox();
            this.tvForceSecret = new System.Windows.Forms.TreeView();
            this.lblForceSecretName = new System.Windows.Forms.Label();
            this.lblForceSecretDescription = new System.Windows.Forms.Label();
            this.txtForceSecretName = new System.Windows.Forms.TextBox();
            this.txtForceSecretDescription = new System.Windows.Forms.TextBox();
            this.btnSelectForceSecret = new System.Windows.Forms.Button();
            this.gpForceSecret.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpForceSecret
            // 
            this.gpForceSecret.Controls.Add(this.tvForceSecret);
            this.gpForceSecret.Location = new System.Drawing.Point(4, 8);
            this.gpForceSecret.Name = "gpForceSecret";
            this.gpForceSecret.Size = new System.Drawing.Size(220, 448);
            this.gpForceSecret.TabIndex = 0;
            this.gpForceSecret.TabStop = false;
            this.gpForceSecret.Text = "Select Force Secret";
            // 
            // tvForceSecret
            // 
            this.tvForceSecret.Location = new System.Drawing.Point(8, 20);
            this.tvForceSecret.Name = "tvForceSecret";
            this.tvForceSecret.Size = new System.Drawing.Size(208, 424);
            this.tvForceSecret.TabIndex = 0;
            this.tvForceSecret.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvForceSecret_AfterSelect);
            // 
            // lblForceSecretName
            // 
            this.lblForceSecretName.Location = new System.Drawing.Point(224, 8);
            this.lblForceSecretName.Name = "lblForceSecretName";
            this.lblForceSecretName.Size = new System.Drawing.Size(104, 20);
            this.lblForceSecretName.TabIndex = 1;
            this.lblForceSecretName.Text = "Force Secret Name:";
            this.lblForceSecretName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblForceSecretDescription
            // 
            this.lblForceSecretDescription.Location = new System.Drawing.Point(224, 36);
            this.lblForceSecretDescription.Name = "lblForceSecretDescription";
            this.lblForceSecretDescription.Size = new System.Drawing.Size(104, 28);
            this.lblForceSecretDescription.TabIndex = 2;
            this.lblForceSecretDescription.Text = "Force Secret Description:";
            this.lblForceSecretDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtForceSecretName
            // 
            this.txtForceSecretName.Location = new System.Drawing.Point(332, 8);
            this.txtForceSecretName.Name = "txtForceSecretName";
            this.txtForceSecretName.ReadOnly = true;
            this.txtForceSecretName.Size = new System.Drawing.Size(272, 22);
            this.txtForceSecretName.TabIndex = 3;
            // 
            // txtForceSecretDescription
            // 
            this.txtForceSecretDescription.Location = new System.Drawing.Point(332, 40);
            this.txtForceSecretDescription.Multiline = true;
            this.txtForceSecretDescription.Name = "txtForceSecretDescription";
            this.txtForceSecretDescription.ReadOnly = true;
            this.txtForceSecretDescription.Size = new System.Drawing.Size(272, 412);
            this.txtForceSecretDescription.TabIndex = 4;
            // 
            // btnSelectForceSecret
            // 
            this.btnSelectForceSecret.Location = new System.Drawing.Point(236, 84);
            this.btnSelectForceSecret.Name = "btnSelectForceSecret";
            this.btnSelectForceSecret.Size = new System.Drawing.Size(80, 36);
            this.btnSelectForceSecret.TabIndex = 5;
            this.btnSelectForceSecret.Text = "Select Force Secret";
            this.btnSelectForceSecret.UseVisualStyleBackColor = true;
            this.btnSelectForceSecret.Click += new System.EventHandler(this.btnSelectForceSecret_Click);
            // 
            // frmAddCharacterLevel_ForceSecretSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 457);
            this.Controls.Add(this.btnSelectForceSecret);
            this.Controls.Add(this.txtForceSecretDescription);
            this.Controls.Add(this.txtForceSecretName);
            this.Controls.Add(this.lblForceSecretDescription);
            this.Controls.Add(this.lblForceSecretName);
            this.Controls.Add(this.gpForceSecret);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddCharacterLevel_ForceSecretSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Force Secret";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddCharacterLevel_ForceSecretSelection_FormClosed);
            this.gpForceSecret.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpForceSecret;
        private System.Windows.Forms.TreeView tvForceSecret;
        private System.Windows.Forms.Label lblForceSecretName;
        private System.Windows.Forms.Label lblForceSecretDescription;
        private System.Windows.Forms.TextBox txtForceSecretName;
        private System.Windows.Forms.TextBox txtForceSecretDescription;
        private System.Windows.Forms.Button btnSelectForceSecret;
    }
}