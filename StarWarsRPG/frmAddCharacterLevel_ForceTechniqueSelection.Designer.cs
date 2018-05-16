namespace StarWarsRPG
{
    partial class frmAddCharacterLevel_ForceTechniqueSelection
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
            this.tvForceTechnique = new System.Windows.Forms.TreeView();
            this.btnSelectForceTechnique = new System.Windows.Forms.Button();
            this.txtForceTechniqueDescription = new System.Windows.Forms.TextBox();
            this.txtForceTechniqueName = new System.Windows.Forms.TextBox();
            this.lblForceTechniqueDescription = new System.Windows.Forms.Label();
            this.lblForceTechniqueName = new System.Windows.Forms.Label();
            this.gpForceTechnique = new System.Windows.Forms.GroupBox();
            this.gpForceTechnique.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvForceTechnique
            // 
            this.tvForceTechnique.Location = new System.Drawing.Point(8, 20);
            this.tvForceTechnique.Name = "tvForceTechnique";
            this.tvForceTechnique.Size = new System.Drawing.Size(208, 424);
            this.tvForceTechnique.TabIndex = 0;
            // 
            // btnSelectForceTechnique
            // 
            this.btnSelectForceTechnique.Location = new System.Drawing.Point(236, 80);
            this.btnSelectForceTechnique.Name = "btnSelectForceTechnique";
            this.btnSelectForceTechnique.Size = new System.Drawing.Size(80, 36);
            this.btnSelectForceTechnique.TabIndex = 11;
            this.btnSelectForceTechnique.Text = "Select Force Technique";
            this.btnSelectForceTechnique.UseVisualStyleBackColor = true;
            // 
            // txtForceTechniqueDescription
            // 
            this.txtForceTechniqueDescription.Location = new System.Drawing.Point(332, 36);
            this.txtForceTechniqueDescription.Multiline = true;
            this.txtForceTechniqueDescription.Name = "txtForceTechniqueDescription";
            this.txtForceTechniqueDescription.ReadOnly = true;
            this.txtForceTechniqueDescription.Size = new System.Drawing.Size(272, 412);
            this.txtForceTechniqueDescription.TabIndex = 10;
            // 
            // txtForceTechniqueName
            // 
            this.txtForceTechniqueName.Location = new System.Drawing.Point(332, 4);
            this.txtForceTechniqueName.Name = "txtForceTechniqueName";
            this.txtForceTechniqueName.ReadOnly = true;
            this.txtForceTechniqueName.Size = new System.Drawing.Size(272, 22);
            this.txtForceTechniqueName.TabIndex = 9;
            // 
            // lblForceTechniqueDescription
            // 
            this.lblForceTechniqueDescription.Location = new System.Drawing.Point(224, 32);
            this.lblForceTechniqueDescription.Name = "lblForceTechniqueDescription";
            this.lblForceTechniqueDescription.Size = new System.Drawing.Size(104, 28);
            this.lblForceTechniqueDescription.TabIndex = 8;
            this.lblForceTechniqueDescription.Text = "Force Secret Description:";
            this.lblForceTechniqueDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblForceTechniqueName
            // 
            this.lblForceTechniqueName.Location = new System.Drawing.Point(224, 4);
            this.lblForceTechniqueName.Name = "lblForceTechniqueName";
            this.lblForceTechniqueName.Size = new System.Drawing.Size(104, 20);
            this.lblForceTechniqueName.TabIndex = 7;
            this.lblForceTechniqueName.Text = "Force Technique Name:";
            this.lblForceTechniqueName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gpForceTechnique
            // 
            this.gpForceTechnique.Controls.Add(this.tvForceTechnique);
            this.gpForceTechnique.Location = new System.Drawing.Point(4, 4);
            this.gpForceTechnique.Name = "gpForceTechnique";
            this.gpForceTechnique.Size = new System.Drawing.Size(220, 448);
            this.gpForceTechnique.TabIndex = 6;
            this.gpForceTechnique.TabStop = false;
            this.gpForceTechnique.Text = "Select Force Technique";
            // 
            // frmAddCharacterLevel_ForceTechniqueSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 451);
            this.Controls.Add(this.btnSelectForceTechnique);
            this.Controls.Add(this.txtForceTechniqueDescription);
            this.Controls.Add(this.txtForceTechniqueName);
            this.Controls.Add(this.lblForceTechniqueDescription);
            this.Controls.Add(this.lblForceTechniqueName);
            this.Controls.Add(this.gpForceTechnique);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddCharacterLevel_ForceTechniqueSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Force Technique Selection";
            this.gpForceTechnique.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvForceTechnique;
        private System.Windows.Forms.Button btnSelectForceTechnique;
        private System.Windows.Forms.TextBox txtForceTechniqueDescription;
        private System.Windows.Forms.TextBox txtForceTechniqueName;
        private System.Windows.Forms.Label lblForceTechniqueDescription;
        private System.Windows.Forms.Label lblForceTechniqueName;
        private System.Windows.Forms.GroupBox gpForceTechnique;
    }
}