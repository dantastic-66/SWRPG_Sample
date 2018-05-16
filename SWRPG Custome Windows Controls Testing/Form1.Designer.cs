namespace SWRPG_Custome_Windows_Controls_Testing
{
    partial class Form1
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
            this.cwc2 = new SWRPG_Custom_Windows_Controls.Character_Weapon_Control();
            this.cwc1 = new SWRPG_Custom_Windows_Controls.Character_Weapon_Control();
            this.SuspendLayout();
            // 
            // cwc2
            // 
            this.cwc2.AutoSize = true;
            this.cwc2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cwc2.Location = new System.Drawing.Point(32, 172);
            this.cwc2.Name = "cwc2";
            this.cwc2.Size = new System.Drawing.Size(681, 136);
            this.cwc2.TabIndex = 3;
            // 
            // cwc1
            // 
            this.cwc1.AutoSize = true;
            this.cwc1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cwc1.Location = new System.Drawing.Point(36, 20);
            this.cwc1.Name = "cwc1";
            this.cwc1.Size = new System.Drawing.Size(681, 136);
            this.cwc1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 526);
            this.Controls.Add(this.cwc2);
            this.Controls.Add(this.cwc1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SWRPG_Custom_Windows_Controls.Character_Weapon_Control cwc1;
        private SWRPG_Custom_Windows_Controls.Character_Weapon_Control cwc2;


    }
}

