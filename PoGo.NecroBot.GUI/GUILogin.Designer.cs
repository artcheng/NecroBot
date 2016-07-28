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
            this.label2 = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioGoogle = new System.Windows.Forms.RadioButton();
            this.radioPtc = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            this.cmdLoadProfile.Location = new System.Drawing.Point(325, 10);
            this.cmdLoadProfile.Name = "cmdLoadProfile";
            this.cmdLoadProfile.Size = new System.Drawing.Size(75, 23);
            this.cmdLoadProfile.TabIndex = 2;
            this.cmdLoadProfile.Text = "Load Profile";
            this.cmdLoadProfile.UseVisualStyleBackColor = true;
            this.cmdLoadProfile.Click += new System.EventHandler(this.cmdLoadProfile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(67, 47);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(220, 20);
            this.textUsername.TabIndex = 4;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(67, 73);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(220, 20);
            this.textPassword.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.radioPtc);
            this.groupBox1.Controls.Add(this.radioGoogle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textPassword);
            this.groupBox1.Controls.Add(this.textUsername);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(16, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 100);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New profile";
            // 
            // radioGoogle
            // 
            this.radioGoogle.AutoSize = true;
            this.radioGoogle.Checked = true;
            this.radioGoogle.Location = new System.Drawing.Point(9, 20);
            this.radioGoogle.Name = "radioGoogle";
            this.radioGoogle.Size = new System.Drawing.Size(59, 17);
            this.radioGoogle.TabIndex = 7;
            this.radioGoogle.TabStop = true;
            this.radioGoogle.Text = "Google";
            this.radioGoogle.UseVisualStyleBackColor = true;
            // 
            // radioPtc
            // 
            this.radioPtc.AutoSize = true;
            this.radioPtc.Location = new System.Drawing.Point(100, 20);
            this.radioPtc.Name = "radioPtc";
            this.radioPtc.Size = new System.Drawing.Size(46, 17);
            this.radioPtc.TabIndex = 8;
            this.radioPtc.Text = "PTC";
            this.radioPtc.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(296, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "New Profile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GUILogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 147);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdLoadProfile);
            this.Controls.Add(this.cboProfiles);
            this.Controls.Add(this.label1);
            this.Name = "GUILogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profile Loader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GUILogin_FormClosing);
            this.Load += new System.EventHandler(this.GUILogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboProfiles;
        private System.Windows.Forms.Button cmdLoadProfile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioPtc;
        private System.Windows.Forms.RadioButton radioGoogle;
    }
}