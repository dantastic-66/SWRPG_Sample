namespace StarWarsRPG
{
    partial class frmCharCreate1GenerateScores
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.formToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableRerollOfOne1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manuallyEnterScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGenerateValue4 = new System.Windows.Forms.Button();
            this.btnGenerateValue3 = new System.Windows.Forms.Button();
            this.btnGenerateValue2 = new System.Windows.Forms.Button();
            this.btnGenerateValue1 = new System.Windows.Forms.Button();
            this.btnSaveNReset = new System.Windows.Forms.Button();
            this.txtAbility6 = new System.Windows.Forms.TextBox();
            this.txtAbility5 = new System.Windows.Forms.TextBox();
            this.txtAbility4 = new System.Windows.Forms.TextBox();
            this.txtAbility3 = new System.Windows.Forms.TextBox();
            this.txtAbility2 = new System.Windows.Forms.TextBox();
            this.txtAbility1 = new System.Windows.Forms.TextBox();
            this.btnReroll4 = new System.Windows.Forms.Button();
            this.btnReroll3 = new System.Windows.Forms.Button();
            this.btnReroll2 = new System.Windows.Forms.Button();
            this.btnReroll1 = new System.Windows.Forms.Button();
            this.txtTotalValue = new System.Windows.Forms.TextBox();
            this.btnGenerateValues = new System.Windows.Forms.Button();
            this.txtValue4 = new System.Windows.Forms.TextBox();
            this.txtValue3 = new System.Windows.Forms.TextBox();
            this.txtValue2 = new System.Windows.Forms.TextBox();
            this.txtValue1 = new System.Windows.Forms.TextBox();
            this.lblValue1 = new System.Windows.Forms.Label();
            this.lblValue2 = new System.Windows.Forms.Label();
            this.lblValue3 = new System.Windows.Forms.Label();
            this.lblValue4 = new System.Windows.Forms.Label();
            this.tmrDieDelay = new System.Windows.Forms.Timer(this.components);
            this.btnAssignAbilities = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(759, 24);
            this.menuStrip1.TabIndex = 54;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // formToolStripMenuItem
            // 
            this.formToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableRerollOfOne1ToolStripMenuItem,
            this.resetCharacterToolStripMenuItem,
            this.manuallyEnterScoreToolStripMenuItem});
            this.formToolStripMenuItem.Name = "formToolStripMenuItem";
            this.formToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.formToolStripMenuItem.Text = "&Character Options";
            // 
            // enableRerollOfOne1ToolStripMenuItem
            // 
            this.enableRerollOfOne1ToolStripMenuItem.Name = "enableRerollOfOne1ToolStripMenuItem";
            this.enableRerollOfOne1ToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.enableRerollOfOne1ToolStripMenuItem.Text = "&Enable Reroll of one 1";
            this.enableRerollOfOne1ToolStripMenuItem.Click += new System.EventHandler(this.enableRerollOfOne1ToolStripMenuItem_Click);
            // 
            // resetCharacterToolStripMenuItem
            // 
            this.resetCharacterToolStripMenuItem.Name = "resetCharacterToolStripMenuItem";
            this.resetCharacterToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.resetCharacterToolStripMenuItem.Text = "&Reset Character";
            this.resetCharacterToolStripMenuItem.Click += new System.EventHandler(this.resetCharacterToolStripMenuItem_Click);
            // 
            // manuallyEnterScoreToolStripMenuItem
            // 
            this.manuallyEnterScoreToolStripMenuItem.Name = "manuallyEnterScoreToolStripMenuItem";
            this.manuallyEnterScoreToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.manuallyEnterScoreToolStripMenuItem.Text = "&Manually Enter Score";
            this.manuallyEnterScoreToolStripMenuItem.Click += new System.EventHandler(this.manuallyEnterScoreToolStripMenuItem_Click);
            // 
            // btnGenerateValue4
            // 
            this.btnGenerateValue4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateValue4.Location = new System.Drawing.Point(24, 136);
            this.btnGenerateValue4.Name = "btnGenerateValue4";
            this.btnGenerateValue4.Size = new System.Drawing.Size(64, 25);
            this.btnGenerateValue4.TabIndex = 79;
            this.btnGenerateValue4.Text = "Roll 4";
            this.btnGenerateValue4.UseVisualStyleBackColor = true;
            this.btnGenerateValue4.Visible = false;
            // 
            // btnGenerateValue3
            // 
            this.btnGenerateValue3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateValue3.Location = new System.Drawing.Point(24, 104);
            this.btnGenerateValue3.Name = "btnGenerateValue3";
            this.btnGenerateValue3.Size = new System.Drawing.Size(64, 25);
            this.btnGenerateValue3.TabIndex = 78;
            this.btnGenerateValue3.Text = "Roll 3";
            this.btnGenerateValue3.UseVisualStyleBackColor = true;
            this.btnGenerateValue3.Visible = false;
            // 
            // btnGenerateValue2
            // 
            this.btnGenerateValue2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateValue2.Location = new System.Drawing.Point(24, 72);
            this.btnGenerateValue2.Name = "btnGenerateValue2";
            this.btnGenerateValue2.Size = new System.Drawing.Size(64, 25);
            this.btnGenerateValue2.TabIndex = 77;
            this.btnGenerateValue2.Text = "Roll 2";
            this.btnGenerateValue2.UseVisualStyleBackColor = true;
            this.btnGenerateValue2.Visible = false;
            // 
            // btnGenerateValue1
            // 
            this.btnGenerateValue1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateValue1.Location = new System.Drawing.Point(24, 40);
            this.btnGenerateValue1.Name = "btnGenerateValue1";
            this.btnGenerateValue1.Size = new System.Drawing.Size(64, 25);
            this.btnGenerateValue1.TabIndex = 76;
            this.btnGenerateValue1.Text = "Roll 1";
            this.btnGenerateValue1.UseVisualStyleBackColor = true;
            this.btnGenerateValue1.Visible = false;
            // 
            // btnSaveNReset
            // 
            this.btnSaveNReset.Enabled = false;
            this.btnSaveNReset.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNReset.Location = new System.Drawing.Point(336, 40);
            this.btnSaveNReset.Name = "btnSaveNReset";
            this.btnSaveNReset.Size = new System.Drawing.Size(72, 48);
            this.btnSaveNReset.TabIndex = 75;
            this.btnSaveNReset.Text = "Save Score";
            this.btnSaveNReset.UseVisualStyleBackColor = true;
            this.btnSaveNReset.Click += new System.EventHandler(this.btnSaveNReset_Click);
            // 
            // txtAbility6
            // 
            this.txtAbility6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAbility6.Location = new System.Drawing.Point(416, 190);
            this.txtAbility6.Name = "txtAbility6";
            this.txtAbility6.ReadOnly = true;
            this.txtAbility6.Size = new System.Drawing.Size(40, 25);
            this.txtAbility6.TabIndex = 74;
            this.txtAbility6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAbility6_KeyPress);
            // 
            // txtAbility5
            // 
            this.txtAbility5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAbility5.Location = new System.Drawing.Point(416, 160);
            this.txtAbility5.Name = "txtAbility5";
            this.txtAbility5.ReadOnly = true;
            this.txtAbility5.Size = new System.Drawing.Size(40, 25);
            this.txtAbility5.TabIndex = 73;
            this.txtAbility5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAbility5_KeyPress);
            // 
            // txtAbility4
            // 
            this.txtAbility4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAbility4.Location = new System.Drawing.Point(416, 130);
            this.txtAbility4.Name = "txtAbility4";
            this.txtAbility4.ReadOnly = true;
            this.txtAbility4.Size = new System.Drawing.Size(40, 25);
            this.txtAbility4.TabIndex = 72;
            this.txtAbility4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAbility4_KeyPress);
            // 
            // txtAbility3
            // 
            this.txtAbility3.BackColor = System.Drawing.SystemColors.Control;
            this.txtAbility3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAbility3.Location = new System.Drawing.Point(416, 100);
            this.txtAbility3.Name = "txtAbility3";
            this.txtAbility3.ReadOnly = true;
            this.txtAbility3.Size = new System.Drawing.Size(40, 25);
            this.txtAbility3.TabIndex = 71;
            this.txtAbility3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAbility3_KeyPress);
            // 
            // txtAbility2
            // 
            this.txtAbility2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAbility2.Location = new System.Drawing.Point(416, 70);
            this.txtAbility2.Name = "txtAbility2";
            this.txtAbility2.ReadOnly = true;
            this.txtAbility2.Size = new System.Drawing.Size(40, 25);
            this.txtAbility2.TabIndex = 70;
            this.txtAbility2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAbility2_KeyPress);
            // 
            // txtAbility1
            // 
            this.txtAbility1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAbility1.Location = new System.Drawing.Point(416, 40);
            this.txtAbility1.Name = "txtAbility1";
            this.txtAbility1.ReadOnly = true;
            this.txtAbility1.Size = new System.Drawing.Size(40, 25);
            this.txtAbility1.TabIndex = 69;
            this.txtAbility1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAbility1_KeyPress);
            // 
            // btnReroll4
            // 
            this.btnReroll4.Enabled = false;
            this.btnReroll4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReroll4.Location = new System.Drawing.Point(264, 142);
            this.btnReroll4.Name = "btnReroll4";
            this.btnReroll4.Size = new System.Drawing.Size(64, 25);
            this.btnReroll4.TabIndex = 68;
            this.btnReroll4.Text = "Reroll";
            this.btnReroll4.UseVisualStyleBackColor = true;
            this.btnReroll4.Click += new System.EventHandler(this.btnReroll4_Click);
            // 
            // btnReroll3
            // 
            this.btnReroll3.Enabled = false;
            this.btnReroll3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReroll3.Location = new System.Drawing.Point(264, 108);
            this.btnReroll3.Name = "btnReroll3";
            this.btnReroll3.Size = new System.Drawing.Size(64, 25);
            this.btnReroll3.TabIndex = 67;
            this.btnReroll3.Text = "Reroll";
            this.btnReroll3.UseVisualStyleBackColor = true;
            this.btnReroll3.Click += new System.EventHandler(this.btnReroll3_Click);
            // 
            // btnReroll2
            // 
            this.btnReroll2.Enabled = false;
            this.btnReroll2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReroll2.Location = new System.Drawing.Point(264, 74);
            this.btnReroll2.Name = "btnReroll2";
            this.btnReroll2.Size = new System.Drawing.Size(64, 25);
            this.btnReroll2.TabIndex = 66;
            this.btnReroll2.Text = "Reroll";
            this.btnReroll2.UseVisualStyleBackColor = true;
            this.btnReroll2.Click += new System.EventHandler(this.btnReroll2_Click);
            // 
            // btnReroll1
            // 
            this.btnReroll1.Enabled = false;
            this.btnReroll1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReroll1.Location = new System.Drawing.Point(264, 40);
            this.btnReroll1.Name = "btnReroll1";
            this.btnReroll1.Size = new System.Drawing.Size(64, 25);
            this.btnReroll1.TabIndex = 65;
            this.btnReroll1.Text = "Reroll";
            this.btnReroll1.UseVisualStyleBackColor = true;
            this.btnReroll1.Click += new System.EventHandler(this.btnReroll1_Click);
            // 
            // txtTotalValue
            // 
            this.txtTotalValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalValue.Location = new System.Drawing.Point(184, 184);
            this.txtTotalValue.Name = "txtTotalValue";
            this.txtTotalValue.ReadOnly = true;
            this.txtTotalValue.Size = new System.Drawing.Size(64, 25);
            this.txtTotalValue.TabIndex = 64;
            // 
            // btnGenerateValues
            // 
            this.btnGenerateValues.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateValues.Location = new System.Drawing.Point(24, 168);
            this.btnGenerateValues.Name = "btnGenerateValues";
            this.btnGenerateValues.Size = new System.Drawing.Size(64, 48);
            this.btnGenerateValues.TabIndex = 63;
            this.btnGenerateValues.Text = "Roll All Die";
            this.btnGenerateValues.UseVisualStyleBackColor = true;
            this.btnGenerateValues.Click += new System.EventHandler(this.btnGenerateValues_Click);
            // 
            // txtValue4
            // 
            this.txtValue4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue4.Location = new System.Drawing.Point(184, 142);
            this.txtValue4.Name = "txtValue4";
            this.txtValue4.ReadOnly = true;
            this.txtValue4.Size = new System.Drawing.Size(64, 25);
            this.txtValue4.TabIndex = 62;
            // 
            // txtValue3
            // 
            this.txtValue3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue3.Location = new System.Drawing.Point(184, 108);
            this.txtValue3.Name = "txtValue3";
            this.txtValue3.ReadOnly = true;
            this.txtValue3.Size = new System.Drawing.Size(64, 25);
            this.txtValue3.TabIndex = 61;
            // 
            // txtValue2
            // 
            this.txtValue2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue2.Location = new System.Drawing.Point(184, 74);
            this.txtValue2.Name = "txtValue2";
            this.txtValue2.ReadOnly = true;
            this.txtValue2.Size = new System.Drawing.Size(64, 25);
            this.txtValue2.TabIndex = 60;
            // 
            // txtValue1
            // 
            this.txtValue1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue1.Location = new System.Drawing.Point(184, 40);
            this.txtValue1.Name = "txtValue1";
            this.txtValue1.ReadOnly = true;
            this.txtValue1.Size = new System.Drawing.Size(64, 25);
            this.txtValue1.TabIndex = 59;
            // 
            // lblValue1
            // 
            this.lblValue1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue1.Location = new System.Drawing.Point(112, 40);
            this.lblValue1.Name = "lblValue1";
            this.lblValue1.Size = new System.Drawing.Size(64, 24);
            this.lblValue1.TabIndex = 58;
            this.lblValue1.Text = "Value 1:";
            // 
            // lblValue2
            // 
            this.lblValue2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue2.Location = new System.Drawing.Point(112, 74);
            this.lblValue2.Name = "lblValue2";
            this.lblValue2.Size = new System.Drawing.Size(64, 24);
            this.lblValue2.TabIndex = 57;
            this.lblValue2.Text = "Value 2:";
            // 
            // lblValue3
            // 
            this.lblValue3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue3.Location = new System.Drawing.Point(112, 108);
            this.lblValue3.Name = "lblValue3";
            this.lblValue3.Size = new System.Drawing.Size(64, 24);
            this.lblValue3.TabIndex = 56;
            this.lblValue3.Text = "Value 3:";
            // 
            // lblValue4
            // 
            this.lblValue4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue4.Location = new System.Drawing.Point(112, 142);
            this.lblValue4.Name = "lblValue4";
            this.lblValue4.Size = new System.Drawing.Size(64, 24);
            this.lblValue4.TabIndex = 55;
            this.lblValue4.Text = "Value 4:";
            // 
            // tmrDieDelay
            // 
            this.tmrDieDelay.Tick += new System.EventHandler(this.tmrDieDelay_Tick);
            // 
            // btnAssignAbilities
            // 
            this.btnAssignAbilities.Enabled = false;
            this.btnAssignAbilities.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignAbilities.Location = new System.Drawing.Point(336, 168);
            this.btnAssignAbilities.Name = "btnAssignAbilities";
            this.btnAssignAbilities.Size = new System.Drawing.Size(72, 48);
            this.btnAssignAbilities.TabIndex = 80;
            this.btnAssignAbilities.Text = "Assign Abilities";
            this.btnAssignAbilities.UseVisualStyleBackColor = true;
            this.btnAssignAbilities.Click += new System.EventHandler(this.btnAssignAbilities_Click);
            // 
            // frmCharCreate1GenerateScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 244);
            this.Controls.Add(this.btnAssignAbilities);
            this.Controls.Add(this.btnGenerateValue4);
            this.Controls.Add(this.btnGenerateValue3);
            this.Controls.Add(this.btnGenerateValue2);
            this.Controls.Add(this.btnGenerateValue1);
            this.Controls.Add(this.btnSaveNReset);
            this.Controls.Add(this.txtAbility6);
            this.Controls.Add(this.txtAbility5);
            this.Controls.Add(this.txtAbility4);
            this.Controls.Add(this.txtAbility3);
            this.Controls.Add(this.txtAbility2);
            this.Controls.Add(this.txtAbility1);
            this.Controls.Add(this.btnReroll4);
            this.Controls.Add(this.btnReroll3);
            this.Controls.Add(this.btnReroll2);
            this.Controls.Add(this.btnReroll1);
            this.Controls.Add(this.txtTotalValue);
            this.Controls.Add(this.btnGenerateValues);
            this.Controls.Add(this.txtValue4);
            this.Controls.Add(this.txtValue3);
            this.Controls.Add(this.txtValue2);
            this.Controls.Add(this.txtValue1);
            this.Controls.Add(this.lblValue1);
            this.Controls.Add(this.lblValue2);
            this.Controls.Add(this.lblValue3);
            this.Controls.Add(this.lblValue4);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.Name = "frmCharCreate1GenerateScores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Step 1.  Generate Scores";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem formToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableRerollOfOne1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetCharacterToolStripMenuItem;
        private System.Windows.Forms.Button btnGenerateValue4;
        private System.Windows.Forms.Button btnGenerateValue3;
        private System.Windows.Forms.Button btnGenerateValue2;
        private System.Windows.Forms.Button btnGenerateValue1;
        private System.Windows.Forms.Button btnSaveNReset;
        private System.Windows.Forms.TextBox txtAbility6;
        private System.Windows.Forms.TextBox txtAbility5;
        private System.Windows.Forms.TextBox txtAbility4;
        private System.Windows.Forms.TextBox txtAbility3;
        private System.Windows.Forms.TextBox txtAbility2;
        private System.Windows.Forms.TextBox txtAbility1;
        private System.Windows.Forms.Button btnReroll4;
        private System.Windows.Forms.Button btnReroll3;
        private System.Windows.Forms.Button btnReroll2;
        private System.Windows.Forms.Button btnReroll1;
        private System.Windows.Forms.TextBox txtTotalValue;
        private System.Windows.Forms.Button btnGenerateValues;
        private System.Windows.Forms.TextBox txtValue4;
        private System.Windows.Forms.TextBox txtValue3;
        private System.Windows.Forms.TextBox txtValue2;
        private System.Windows.Forms.TextBox txtValue1;
        private System.Windows.Forms.Label lblValue1;
        private System.Windows.Forms.Label lblValue2;
        private System.Windows.Forms.Label lblValue3;
        private System.Windows.Forms.Label lblValue4;
        private System.Windows.Forms.Timer tmrDieDelay;
        private System.Windows.Forms.ToolStripMenuItem manuallyEnterScoreToolStripMenuItem;
        private System.Windows.Forms.Button btnAssignAbilities;
    }
}