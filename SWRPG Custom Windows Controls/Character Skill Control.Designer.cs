namespace SWRPG_Custom_Windows_Controls
{
    partial class CharacterSkillControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtHalfLevel = new System.Windows.Forms.TextBox();
            this.lblSkillName = new System.Windows.Forms.Label();
            this.lblSkillTotal = new System.Windows.Forms.Label();
            this.lblEquals = new System.Windows.Forms.Label();
            this.lblPlus1 = new System.Windows.Forms.Label();
            this.txtAbilityMod = new System.Windows.Forms.TextBox();
            this.lblPlus2 = new System.Windows.Forms.Label();
            this.txtTrained = new System.Windows.Forms.TextBox();
            this.txtSkillFocus = new System.Windows.Forms.TextBox();
            this.lblPlus3 = new System.Windows.Forms.Label();
            this.lblPlus4 = new System.Windows.Forms.Label();
            this.txtMiscellaneous = new System.Windows.Forms.TextBox();
            this.txtSkillFeatTalentBonus = new System.Windows.Forms.TextBox();
            this.lblPlus5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtHalfLevel
            // 
            this.txtHalfLevel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHalfLevel.Location = new System.Drawing.Point(252, 0);
            this.txtHalfLevel.Name = "txtHalfLevel";
            this.txtHalfLevel.ReadOnly = true;
            this.txtHalfLevel.Size = new System.Drawing.Size(56, 23);
            this.txtHalfLevel.TabIndex = 2;
            this.txtHalfLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHalfLevel.TextChanged += new System.EventHandler(this.txtHalfLevel_TextChanged);
            // 
            // lblSkillName
            // 
            this.lblSkillName.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkillName.Location = new System.Drawing.Point(0, 0);
            this.lblSkillName.Name = "lblSkillName";
            this.lblSkillName.Size = new System.Drawing.Size(164, 20);
            this.lblSkillName.TabIndex = 3;
            // 
            // lblSkillTotal
            // 
            this.lblSkillTotal.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSkillTotal.Location = new System.Drawing.Point(172, 0);
            this.lblSkillTotal.Name = "lblSkillTotal";
            this.lblSkillTotal.Size = new System.Drawing.Size(52, 20);
            this.lblSkillTotal.TabIndex = 4;
            this.lblSkillTotal.Text = "Total";
            // 
            // lblEquals
            // 
            this.lblEquals.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquals.Location = new System.Drawing.Point(228, 0);
            this.lblEquals.Name = "lblEquals";
            this.lblEquals.Size = new System.Drawing.Size(17, 20);
            this.lblEquals.TabIndex = 5;
            this.lblEquals.Text = "=";
            // 
            // lblPlus1
            // 
            this.lblPlus1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlus1.Location = new System.Drawing.Point(312, 0);
            this.lblPlus1.Name = "lblPlus1";
            this.lblPlus1.Size = new System.Drawing.Size(16, 20);
            this.lblPlus1.TabIndex = 6;
            this.lblPlus1.Text = "+ ";
            // 
            // txtAbilityMod
            // 
            this.txtAbilityMod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbilityMod.Location = new System.Drawing.Point(332, 0);
            this.txtAbilityMod.Name = "txtAbilityMod";
            this.txtAbilityMod.ReadOnly = true;
            this.txtAbilityMod.Size = new System.Drawing.Size(56, 23);
            this.txtAbilityMod.TabIndex = 7;
            this.txtAbilityMod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAbilityMod.TextChanged += new System.EventHandler(this.txtAbilityMod_TextChanged);
            // 
            // lblPlus2
            // 
            this.lblPlus2.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlus2.Location = new System.Drawing.Point(392, 0);
            this.lblPlus2.Name = "lblPlus2";
            this.lblPlus2.Size = new System.Drawing.Size(16, 20);
            this.lblPlus2.TabIndex = 8;
            this.lblPlus2.Text = "+ ";
            // 
            // txtTrained
            // 
            this.txtTrained.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrained.Location = new System.Drawing.Point(412, 0);
            this.txtTrained.Name = "txtTrained";
            this.txtTrained.ReadOnly = true;
            this.txtTrained.Size = new System.Drawing.Size(56, 23);
            this.txtTrained.TabIndex = 9;
            this.txtTrained.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTrained.TextChanged += new System.EventHandler(this.txtTrained_TextChanged);
            // 
            // txtSkillFocus
            // 
            this.txtSkillFocus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSkillFocus.Location = new System.Drawing.Point(492, 0);
            this.txtSkillFocus.Name = "txtSkillFocus";
            this.txtSkillFocus.ReadOnly = true;
            this.txtSkillFocus.Size = new System.Drawing.Size(56, 23);
            this.txtSkillFocus.TabIndex = 11;
            this.txtSkillFocus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSkillFocus.TextChanged += new System.EventHandler(this.txtSkillFocus_TextChanged);
            // 
            // lblPlus3
            // 
            this.lblPlus3.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlus3.Location = new System.Drawing.Point(472, 0);
            this.lblPlus3.Name = "lblPlus3";
            this.lblPlus3.Size = new System.Drawing.Size(16, 20);
            this.lblPlus3.TabIndex = 10;
            this.lblPlus3.Text = "+ ";
            // 
            // lblPlus4
            // 
            this.lblPlus4.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlus4.Location = new System.Drawing.Point(552, 0);
            this.lblPlus4.Name = "lblPlus4";
            this.lblPlus4.Size = new System.Drawing.Size(16, 20);
            this.lblPlus4.TabIndex = 12;
            this.lblPlus4.Text = "+ ";
            // 
            // txtMiscellaneous
            // 
            this.txtMiscellaneous.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiscellaneous.Location = new System.Drawing.Point(652, 0);
            this.txtMiscellaneous.Name = "txtMiscellaneous";
            this.txtMiscellaneous.Size = new System.Drawing.Size(56, 23);
            this.txtMiscellaneous.TabIndex = 13;
            this.txtMiscellaneous.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMiscellaneous.TextChanged += new System.EventHandler(this.txtMiscellaneous_TextChanged);
            this.txtMiscellaneous.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMiscellaneous_KeyPress);
            // 
            // txtSkillFeatTalentBonus
            // 
            this.txtSkillFeatTalentBonus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSkillFeatTalentBonus.Location = new System.Drawing.Point(572, 0);
            this.txtSkillFeatTalentBonus.Name = "txtSkillFeatTalentBonus";
            this.txtSkillFeatTalentBonus.ReadOnly = true;
            this.txtSkillFeatTalentBonus.Size = new System.Drawing.Size(56, 23);
            this.txtSkillFeatTalentBonus.TabIndex = 15;
            this.txtSkillFeatTalentBonus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSkillFeatTalentBonus.TextChanged += new System.EventHandler(this.txtSkillFeatTalentBonus_TextChanged);
            // 
            // lblPlus5
            // 
            this.lblPlus5.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlus5.Location = new System.Drawing.Point(632, 0);
            this.lblPlus5.Name = "lblPlus5";
            this.lblPlus5.Size = new System.Drawing.Size(16, 20);
            this.lblPlus5.TabIndex = 14;
            this.lblPlus5.Text = "+ ";
            // 
            // CharacterSkillControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.txtSkillFeatTalentBonus);
            this.Controls.Add(this.lblPlus5);
            this.Controls.Add(this.txtMiscellaneous);
            this.Controls.Add(this.lblPlus4);
            this.Controls.Add(this.txtSkillFocus);
            this.Controls.Add(this.lblPlus3);
            this.Controls.Add(this.txtTrained);
            this.Controls.Add(this.lblPlus2);
            this.Controls.Add(this.txtAbilityMod);
            this.Controls.Add(this.lblPlus1);
            this.Controls.Add(this.lblEquals);
            this.Controls.Add(this.lblSkillTotal);
            this.Controls.Add(this.lblSkillName);
            this.Controls.Add(this.txtHalfLevel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CharacterSkillControl";
            this.Size = new System.Drawing.Size(711, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtHalfLevel;
        private System.Windows.Forms.Label lblSkillName;
        private System.Windows.Forms.Label lblSkillTotal;
        private System.Windows.Forms.Label lblEquals;
        private System.Windows.Forms.Label lblPlus1;
        private System.Windows.Forms.TextBox txtAbilityMod;
        private System.Windows.Forms.Label lblPlus2;
        private System.Windows.Forms.TextBox txtTrained;
        private System.Windows.Forms.TextBox txtSkillFocus;
        private System.Windows.Forms.Label lblPlus3;
        private System.Windows.Forms.Label lblPlus4;
        private System.Windows.Forms.TextBox txtMiscellaneous;
        private System.Windows.Forms.TextBox txtSkillFeatTalentBonus;
        private System.Windows.Forms.Label lblPlus5;
    }
}
