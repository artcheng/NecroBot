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
            this.comboProfiles = new System.Windows.Forms.ComboBox();
            this.cmdLoadProfile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdNewProfile = new System.Windows.Forms.Button();
            this.radioPtc = new System.Windows.Forms.RadioButton();
            this.radioGoogle = new System.Windows.Forms.RadioButton();
            this.tabProfiles = new System.Windows.Forms.TabControl();
            this.tabLoad = new System.Windows.Forms.TabPage();
            this.comboGPXFiles = new System.Windows.Forms.ComboBox();
            this.checkGPX = new System.Windows.Forms.CheckBox();
            this.tabPageCreate = new System.Windows.Forms.TabPage();
            this.checkUseLastCoords = new System.Windows.Forms.CheckBox();
            this.checkLiveMap = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboCopyConfig = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.tabProfiles.SuspendLayout();
            this.tabLoad.SuspendLayout();
            this.tabPageCreate.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profile";
            // 
            // comboProfiles
            // 
            this.comboProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProfiles.FormattingEnabled = true;
            this.comboProfiles.Location = new System.Drawing.Point(52, 6);
            this.comboProfiles.Name = "comboProfiles";
            this.comboProfiles.Size = new System.Drawing.Size(324, 21);
            this.comboProfiles.TabIndex = 1;
            this.comboProfiles.SelectedIndexChanged += new System.EventHandler(this.comboProfiles_SelectedIndexChanged);
            // 
            // cmdLoadProfile
            // 
            this.cmdLoadProfile.Location = new System.Drawing.Point(303, 108);
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
            this.textPassword.PasswordChar = '*';
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
            this.groupBox1.Controls.Add(this.comboCopyConfig);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmdNewProfile);
            this.groupBox1.Controls.Add(this.radioPtc);
            this.groupBox1.Controls.Add(this.radioGoogle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textPassword);
            this.groupBox1.Controls.Add(this.textUsername);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 129);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "New profile";
            // 
            // cmdNewProfile
            // 
            this.cmdNewProfile.Location = new System.Drawing.Point(297, 99);
            this.cmdNewProfile.Name = "cmdNewProfile";
            this.cmdNewProfile.Size = new System.Drawing.Size(75, 23);
            this.cmdNewProfile.TabIndex = 9;
            this.cmdNewProfile.Text = "New Profile";
            this.cmdNewProfile.UseVisualStyleBackColor = true;
            this.cmdNewProfile.Click += new System.EventHandler(this.button1_Click);
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
            // tabProfiles
            // 
            this.tabProfiles.Controls.Add(this.tabLoad);
            this.tabProfiles.Controls.Add(this.tabPageCreate);
            this.tabProfiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabProfiles.Location = new System.Drawing.Point(0, 0);
            this.tabProfiles.Name = "tabProfiles";
            this.tabProfiles.SelectedIndex = 0;
            this.tabProfiles.Size = new System.Drawing.Size(392, 161);
            this.tabProfiles.TabIndex = 8;
            // 
            // tabLoad
            // 
            this.tabLoad.Controls.Add(this.checkLiveMap);
            this.tabLoad.Controls.Add(this.checkUseLastCoords);
            this.tabLoad.Controls.Add(this.comboGPXFiles);
            this.tabLoad.Controls.Add(this.checkGPX);
            this.tabLoad.Controls.Add(this.comboProfiles);
            this.tabLoad.Controls.Add(this.cmdLoadProfile);
            this.tabLoad.Controls.Add(this.label1);
            this.tabLoad.Location = new System.Drawing.Point(4, 22);
            this.tabLoad.Name = "tabLoad";
            this.tabLoad.Padding = new System.Windows.Forms.Padding(3);
            this.tabLoad.Size = new System.Drawing.Size(384, 135);
            this.tabLoad.TabIndex = 0;
            this.tabLoad.Text = "Load profile";
            this.tabLoad.UseVisualStyleBackColor = true;
            // 
            // comboGPXFiles
            // 
            this.comboGPXFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGPXFiles.Enabled = false;
            this.comboGPXFiles.FormattingEnabled = true;
            this.comboGPXFiles.Location = new System.Drawing.Point(105, 33);
            this.comboGPXFiles.Name = "comboGPXFiles";
            this.comboGPXFiles.Size = new System.Drawing.Size(271, 21);
            this.comboGPXFiles.TabIndex = 4;
            // 
            // checkGPX
            // 
            this.checkGPX.AutoSize = true;
            this.checkGPX.Location = new System.Drawing.Point(13, 35);
            this.checkGPX.Name = "checkGPX";
            this.checkGPX.Size = new System.Drawing.Size(86, 17);
            this.checkGPX.TabIndex = 3;
            this.checkGPX.Text = "Use GPX file";
            this.checkGPX.UseVisualStyleBackColor = true;
            this.checkGPX.CheckedChanged += new System.EventHandler(this.checkGPX_CheckedChanged);
            // 
            // tabPageCreate
            // 
            this.tabPageCreate.Controls.Add(this.groupBox1);
            this.tabPageCreate.Location = new System.Drawing.Point(4, 22);
            this.tabPageCreate.Name = "tabPageCreate";
            this.tabPageCreate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCreate.Size = new System.Drawing.Size(384, 135);
            this.tabPageCreate.TabIndex = 1;
            this.tabPageCreate.Text = "Create new profile";
            this.tabPageCreate.UseVisualStyleBackColor = true;
            // 
            // checkUseLastCoords
            // 
            this.checkUseLastCoords.AutoSize = true;
            this.checkUseLastCoords.Location = new System.Drawing.Point(13, 58);
            this.checkUseLastCoords.Name = "checkUseLastCoords";
            this.checkUseLastCoords.Size = new System.Drawing.Size(99, 17);
            this.checkUseLastCoords.TabIndex = 5;
            this.checkUseLastCoords.Text = "Use last coords";
            this.checkUseLastCoords.UseVisualStyleBackColor = true;
            this.checkUseLastCoords.Visible = false;
            this.checkUseLastCoords.CheckedChanged += new System.EventHandler(this.checkUseLastCoords_CheckedChanged);
            // 
            // checkLiveMap
            // 
            this.checkLiveMap.AutoSize = true;
            this.checkLiveMap.Location = new System.Drawing.Point(13, 81);
            this.checkLiveMap.Name = "checkLiveMap";
            this.checkLiveMap.Size = new System.Drawing.Size(84, 17);
            this.checkLiveMap.TabIndex = 6;
            this.checkLiveMap.Text = "Use livemap";
            this.checkLiveMap.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Copy config.json from";
            // 
            // comboCopyConfig
            // 
            this.comboCopyConfig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCopyConfig.FormattingEnabled = true;
            this.comboCopyConfig.Location = new System.Drawing.Point(123, 99);
            this.comboCopyConfig.Name = "comboCopyConfig";
            this.comboCopyConfig.Size = new System.Drawing.Size(164, 21);
            this.comboCopyConfig.TabIndex = 11;
            // 
            // GUILogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 161);
            this.Controls.Add(this.tabProfiles);
            this.Name = "GUILogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profile Loader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GUILogin_FormClosing);
            this.Load += new System.EventHandler(this.GUILogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabProfiles.ResumeLayout(false);
            this.tabLoad.ResumeLayout(false);
            this.tabLoad.PerformLayout();
            this.tabPageCreate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboProfiles;
        private System.Windows.Forms.Button cmdLoadProfile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdNewProfile;
        private System.Windows.Forms.RadioButton radioPtc;
        private System.Windows.Forms.RadioButton radioGoogle;
        private System.Windows.Forms.TabControl tabProfiles;
        private System.Windows.Forms.TabPage tabLoad;
        private System.Windows.Forms.TabPage tabPageCreate;
        private System.Windows.Forms.ComboBox comboGPXFiles;
        private System.Windows.Forms.CheckBox checkGPX;
        private System.Windows.Forms.CheckBox checkLiveMap;
        private System.Windows.Forms.CheckBox checkUseLastCoords;
        private System.Windows.Forms.ComboBox comboCopyConfig;
        private System.Windows.Forms.Label label4;
    }
}