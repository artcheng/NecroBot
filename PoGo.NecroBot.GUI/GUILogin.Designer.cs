namespace PoGo.NecroBot.GUI
{
    partial class GUILogin
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboProfiles = new System.Windows.Forms.ComboBox();
            this.cmdLoadProfile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profile";
            // 
            // cboProfiles
            // 
            this.cboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProfiles.FormattingEnabled = true;
            this.cboProfiles.Location = new System.Drawing.Point(55, 10);
            this.cboProfiles.Name = "cboProfiles";
            this.cboProfiles.Size = new System.Drawing.Size(264, 21);
            this.cboProfiles.TabIndex = 1;
            this.cboProfiles.SelectedIndexChanged += new System.EventHandler(this.cboProfiles_SelectedIndexChanged);
            // 
            // cmdLoadProfile
            // 
            this.cmdLoadProfile.Location = new System.Drawing.Point(244, 37);
            this.cmdLoadProfile.Name = "cmdLoadProfile";
            this.cmdLoadProfile.Size = new System.Drawing.Size(75, 23);
            this.cmdLoadProfile.TabIndex = 2;
            this.cmdLoadProfile.Text = "Load Profile";
            this.cmdLoadProfile.UseVisualStyleBackColor = true;
            this.cmdLoadProfile.Click += new System.EventHandler(this.cmdLoadProfile_Click);
            // 
            // GUILogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 74);
            this.Controls.Add(this.cmdLoadProfile);
            this.Controls.Add(this.cboProfiles);
            this.Controls.Add(this.label1);
            this.Name = "GUILogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profile Loader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GUILogin_FormClosing);
            this.Load += new System.EventHandler(this.GUILogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboProfiles;
        private System.Windows.Forms.Button cmdLoadProfile;
    }
}