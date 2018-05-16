namespace StarWarsRPG
{
    partial class frmAbilityDisplay
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtSortOrder = new System.Windows.Forms.TextBox();
            this.lblSortOrder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(16, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(56, 24);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Info;
            this.txtName.Location = new System.Drawing.Point(104, 24);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(160, 25);
            this.txtName.TabIndex = 1;
            // 
            // txtSortOrder
            // 
            this.txtSortOrder.BackColor = System.Drawing.SystemColors.Info;
            this.txtSortOrder.Location = new System.Drawing.Point(104, 56);
            this.txtSortOrder.Name = "txtSortOrder";
            this.txtSortOrder.ReadOnly = true;
            this.txtSortOrder.Size = new System.Drawing.Size(160, 25);
            this.txtSortOrder.TabIndex = 5;
            // 
            // lblSortOrder
            // 
            this.lblSortOrder.Location = new System.Drawing.Point(16, 56);
            this.lblSortOrder.Name = "lblSortOrder";
            this.lblSortOrder.Size = new System.Drawing.Size(56, 24);
            this.lblSortOrder.TabIndex = 4;
            this.lblSortOrder.Text = "Sort Order:";
            // 
            // frmAbilityDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 92);
            this.Controls.Add(this.txtSortOrder);
            this.Controls.Add(this.lblSortOrder);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbilityDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ability";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtSortOrder;
        private System.Windows.Forms.Label lblSortOrder;
    }
}