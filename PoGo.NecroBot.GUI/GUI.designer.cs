using PoGo.NecroBot.GUI.UserControls;

namespace PoGo.NecroBot.GUI
{
    partial class GUI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridConsole = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpPlayer = new System.Windows.Forms.GroupBox();
            this.cmdStart = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textPlayerPokecoins = new System.Windows.Forms.TextBox();
            this.labelPlayerPokeHr = new System.Windows.Forms.Label();
            this.labelPlayerExpHr = new System.Windows.Forms.Label();
            this.labelPlayerExpOverLevelExp = new System.Windows.Forms.Label();
            this.progressPlayerExpBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.textPlayerStardust = new System.Windows.Forms.TextBox();
            this.textPlayerLevel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textPlayerName = new System.Windows.Forms.TextBox();
            this.tabControlInventory = new System.Windows.Forms.TabControl();
            this.tabItems = new System.Windows.Forms.TabPage();
            this.dataMyItems = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCandies = new System.Windows.Forms.TabPage();
            this.dataMyCandies = new System.Windows.Forms.DataGridView();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabMyPokemons = new System.Windows.Forms.TabPage();
            this.cmdEvolveSelected = new System.Windows.Forms.Button();
            this.cmdTransferSelected = new System.Windows.Forms.Button();
            this.dataMyPokemons = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Move1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Move2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMap = new System.Windows.Forms.TabPage();
            this.checkShowPath = new System.Windows.Forms.CheckBox();
            this.checkShowPokegyms = new System.Windows.Forms.CheckBox();
            this.checkShowPokestops = new System.Windows.Forms.CheckBox();
            this.checkShowPokemons = new System.Windows.Forms.CheckBox();
            this.textCurrentLatLng = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.tabManualSniping = new System.Windows.Forms.TabPage();
            this.radioSnipeGetAll = new System.Windows.Forms.RadioButton();
            this.radioSnipeUseSettings = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmdSnipeList = new System.Windows.Forms.Button();
            this.textPokemonSnipeList = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.cmdSaveSettings = new System.Windows.Forms.Button();
            this.tabControlSettings = new System.Windows.Forms.TabControl();
            this.tabPageSettingsGlobal = new System.Windows.Forms.TabPage();
            this.globalSettingsControl = new PoGo.NecroBot.GUI.UserControls.GlobalSettingsControl();
            this.tabPageSettingsSniping = new System.Windows.Forms.TabPage();
            this.snipingSettingsControl = new PoGo.NecroBot.GUI.UserControls.SnipingSettingsControl();
            this.tabPageSettingsPokemons = new System.Windows.Forms.TabPage();
            this.settingsUsePokemonToNotCatchFilter = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.settingsRenameAboveIv = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.settingsKeepMinCp = new System.Windows.Forms.TextBox();
            this.settingsKeepMinDuplicatePokemon = new System.Windows.Forms.TextBox();
            this.settingsKeepMinIvPercentage = new System.Windows.Forms.TextBox();
            this.settingsTransferDuplicatePokemon = new System.Windows.Forms.CheckBox();
            this.settingsPrioritizeIvOverCp = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.settingsKeepPokemonsThatCanEvolve = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.settingsEvolveAllPokemonWithEnoughCandy = new System.Windows.Forms.CheckBox();
            this.settingsEvolveAboveIvValue = new System.Windows.Forms.TextBox();
            this.settingsEvolveAllPokemonAboveIv = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.dataPokemonSettings = new System.Windows.Forms.DataGridView();
            this.tabPageSettingsItems = new System.Windows.Forms.TabPage();
            this.dataItemSettings = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTransferSelected = new System.Windows.Forms.ToolTip(this.components);
            this.toolEvolveSelected = new System.Windows.Forms.ToolTip(this.components);
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column20 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConsole)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpPlayer.SuspendLayout();
            this.tabControlInventory.SuspendLayout();
            this.tabItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataMyItems)).BeginInit();
            this.tabCandies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataMyCandies)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabMyPokemons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataMyPokemons)).BeginInit();
            this.tabMap.SuspendLayout();
            this.tabManualSniping.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.tabControlSettings.SuspendLayout();
            this.tabPageSettingsGlobal.SuspendLayout();
            this.tabPageSettingsSniping.SuspendLayout();
            this.tabPageSettingsPokemons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPokemonSettings)).BeginInit();
            this.tabPageSettingsItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataItemSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridConsole
            // 
            this.dataGridConsole.AllowUserToAddRows = false;
            this.dataGridConsole.AllowUserToDeleteRows = false;
            this.dataGridConsole.AllowUserToResizeColumns = false;
            this.dataGridConsole.AllowUserToResizeRows = false;
            this.dataGridConsole.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridConsole, 2);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridConsole.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridConsole.GridColor = System.Drawing.Color.Black;
            this.dataGridConsole.Location = new System.Drawing.Point(3, 532);
            this.dataGridConsole.Name = "dataGridConsole";
            this.dataGridConsole.ReadOnly = true;
            this.dataGridConsole.RowHeadersVisible = false;
            this.dataGridConsole.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Black;
            this.dataGridConsole.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridConsole.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.dataGridConsole.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridConsole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridConsole.Size = new System.Drawing.Size(1002, 194);
            this.dataGridConsole.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "DateTime";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "LogLevel";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 75;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Message";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 1000;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridConsole, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grpPlayer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControlInventory, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControlMain, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 729);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // grpPlayer
            // 
            this.grpPlayer.Controls.Add(this.cmdStart);
            this.grpPlayer.Controls.Add(this.label4);
            this.grpPlayer.Controls.Add(this.textPlayerPokecoins);
            this.grpPlayer.Controls.Add(this.labelPlayerPokeHr);
            this.grpPlayer.Controls.Add(this.labelPlayerExpHr);
            this.grpPlayer.Controls.Add(this.labelPlayerExpOverLevelExp);
            this.grpPlayer.Controls.Add(this.progressPlayerExpBar);
            this.grpPlayer.Controls.Add(this.label3);
            this.grpPlayer.Controls.Add(this.textPlayerStardust);
            this.grpPlayer.Controls.Add(this.textPlayerLevel);
            this.grpPlayer.Controls.Add(this.label2);
            this.grpPlayer.Controls.Add(this.label1);
            this.grpPlayer.Controls.Add(this.textPlayerName);
            this.grpPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPlayer.Location = new System.Drawing.Point(3, 3);
            this.grpPlayer.Name = "grpPlayer";
            this.grpPlayer.Size = new System.Drawing.Size(294, 194);
            this.grpPlayer.TabIndex = 1;
            this.grpPlayer.TabStop = false;
            this.grpPlayer.Text = "Player";
            // 
            // cmdStart
            // 
            this.cmdStart.Image = global::PoGo.NecroBot.GUI.PoGoImages.play;
            this.cmdStart.Location = new System.Drawing.Point(215, 19);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(72, 57);
            this.cmdStart.TabIndex = 1;
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Pokecoins";
            // 
            // textPlayerPokecoins
            // 
            this.textPlayerPokecoins.Location = new System.Drawing.Point(69, 97);
            this.textPlayerPokecoins.Name = "textPlayerPokecoins";
            this.textPlayerPokecoins.ReadOnly = true;
            this.textPlayerPokecoins.Size = new System.Drawing.Size(140, 20);
            this.textPlayerPokecoins.TabIndex = 26;
            // 
            // labelPlayerPokeHr
            // 
            this.labelPlayerPokeHr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayerPokeHr.Location = new System.Drawing.Point(160, 169);
            this.labelPlayerPokeHr.Name = "labelPlayerPokeHr";
            this.labelPlayerPokeHr.Size = new System.Drawing.Size(127, 23);
            this.labelPlayerPokeHr.TabIndex = 24;
            this.labelPlayerPokeHr.Text = "POKEMON/HR";
            this.labelPlayerPokeHr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPlayerExpHr
            // 
            this.labelPlayerExpHr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayerExpHr.Location = new System.Drawing.Point(0, 169);
            this.labelPlayerExpHr.Name = "labelPlayerExpHr";
            this.labelPlayerExpHr.Size = new System.Drawing.Size(154, 23);
            this.labelPlayerExpHr.TabIndex = 23;
            this.labelPlayerExpHr.Text = "EXP/HR";
            this.labelPlayerExpHr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPlayerExpOverLevelExp
            // 
            this.labelPlayerExpOverLevelExp.Location = new System.Drawing.Point(0, 149);
            this.labelPlayerExpOverLevelExp.Name = "labelPlayerExpOverLevelExp";
            this.labelPlayerExpOverLevelExp.Size = new System.Drawing.Size(287, 19);
            this.labelPlayerExpOverLevelExp.TabIndex = 22;
            this.labelPlayerExpOverLevelExp.Text = "EXP/LEVELEXP";
            this.labelPlayerExpOverLevelExp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressPlayerExpBar
            // 
            this.progressPlayerExpBar.Location = new System.Drawing.Point(0, 123);
            this.progressPlayerExpBar.Name = "progressPlayerExpBar";
            this.progressPlayerExpBar.Size = new System.Drawing.Size(287, 23);
            this.progressPlayerExpBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressPlayerExpBar.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stardust";
            // 
            // textPlayerStardust
            // 
            this.textPlayerStardust.Location = new System.Drawing.Point(69, 71);
            this.textPlayerStardust.Name = "textPlayerStardust";
            this.textPlayerStardust.ReadOnly = true;
            this.textPlayerStardust.Size = new System.Drawing.Size(140, 20);
            this.textPlayerStardust.TabIndex = 5;
            // 
            // textPlayerLevel
            // 
            this.textPlayerLevel.Location = new System.Drawing.Point(69, 45);
            this.textPlayerLevel.Name = "textPlayerLevel";
            this.textPlayerLevel.ReadOnly = true;
            this.textPlayerLevel.Size = new System.Drawing.Size(39, 20);
            this.textPlayerLevel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Level";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // textPlayerName
            // 
            this.textPlayerName.Location = new System.Drawing.Point(69, 19);
            this.textPlayerName.Name = "textPlayerName";
            this.textPlayerName.ReadOnly = true;
            this.textPlayerName.Size = new System.Drawing.Size(140, 20);
            this.textPlayerName.TabIndex = 2;
            // 
            // tabControlInventory
            // 
            this.tabControlInventory.Controls.Add(this.tabItems);
            this.tabControlInventory.Controls.Add(this.tabCandies);
            this.tabControlInventory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlInventory.Location = new System.Drawing.Point(3, 203);
            this.tabControlInventory.Name = "tabControlInventory";
            this.tabControlInventory.SelectedIndex = 0;
            this.tabControlInventory.Size = new System.Drawing.Size(294, 323);
            this.tabControlInventory.TabIndex = 2;
            // 
            // tabItems
            // 
            this.tabItems.Controls.Add(this.dataMyItems);
            this.tabItems.Location = new System.Drawing.Point(4, 22);
            this.tabItems.Name = "tabItems";
            this.tabItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabItems.Size = new System.Drawing.Size(286, 297);
            this.tabItems.TabIndex = 0;
            this.tabItems.Text = "Items (0/350)";
            this.tabItems.UseVisualStyleBackColor = true;
            // 
            // dataMyItems
            // 
            this.dataMyItems.AllowUserToAddRows = false;
            this.dataMyItems.AllowUserToDeleteRows = false;
            this.dataMyItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMyItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataMyItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataMyItems.Location = new System.Drawing.Point(3, 3);
            this.dataMyItems.Name = "dataMyItems";
            this.dataMyItems.ReadOnly = true;
            this.dataMyItems.RowHeadersWidth = 10;
            this.dataMyItems.RowTemplate.Height = 40;
            this.dataMyItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataMyItems.Size = new System.Drawing.Size(280, 291);
            this.dataMyItems.TabIndex = 10;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "ID";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 30;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Item";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 150;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Count";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column6.Width = 75;
            // 
            // tabCandies
            // 
            this.tabCandies.Controls.Add(this.dataMyCandies);
            this.tabCandies.Location = new System.Drawing.Point(4, 22);
            this.tabCandies.Name = "tabCandies";
            this.tabCandies.Padding = new System.Windows.Forms.Padding(3);
            this.tabCandies.Size = new System.Drawing.Size(286, 297);
            this.tabCandies.TabIndex = 1;
            this.tabCandies.Text = "Candies";
            this.tabCandies.UseVisualStyleBackColor = true;
            // 
            // dataMyCandies
            // 
            this.dataMyCandies.AllowUserToAddRows = false;
            this.dataMyCandies.AllowUserToDeleteRows = false;
            this.dataMyCandies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMyCandies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column15,
            this.Column13,
            this.Column14});
            this.dataMyCandies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataMyCandies.Location = new System.Drawing.Point(3, 3);
            this.dataMyCandies.Name = "dataMyCandies";
            this.dataMyCandies.ReadOnly = true;
            this.dataMyCandies.RowHeadersWidth = 10;
            this.dataMyCandies.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataMyCandies.Size = new System.Drawing.Size(280, 291);
            this.dataMyCandies.TabIndex = 1;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "ID";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Visible = false;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Family";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "Count";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabMyPokemons);
            this.tabControlMain.Controls.Add(this.tabMap);
            this.tabControlMain.Controls.Add(this.tabManualSniping);
            this.tabControlMain.Controls.Add(this.tabSettings);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(303, 3);
            this.tabControlMain.Name = "tabControlMain";
            this.tableLayoutPanel1.SetRowSpan(this.tabControlMain, 2);
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(702, 523);
            this.tabControlMain.TabIndex = 1;
            // 
            // tabMyPokemons
            // 
            this.tabMyPokemons.Controls.Add(this.cmdEvolveSelected);
            this.tabMyPokemons.Controls.Add(this.cmdTransferSelected);
            this.tabMyPokemons.Controls.Add(this.dataMyPokemons);
            this.tabMyPokemons.Location = new System.Drawing.Point(4, 22);
            this.tabMyPokemons.Name = "tabMyPokemons";
            this.tabMyPokemons.Padding = new System.Windows.Forms.Padding(3);
            this.tabMyPokemons.Size = new System.Drawing.Size(694, 497);
            this.tabMyPokemons.TabIndex = 3;
            this.tabMyPokemons.Text = "Pokemons (0/250)";
            this.tabMyPokemons.UseVisualStyleBackColor = true;
            // 
            // cmdEvolveSelected
            // 
            this.cmdEvolveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEvolveSelected.Image = global::PoGo.NecroBot.GUI.PoGoImages.evolve;
            this.cmdEvolveSelected.Location = new System.Drawing.Point(648, 457);
            this.cmdEvolveSelected.Name = "cmdEvolveSelected";
            this.cmdEvolveSelected.Size = new System.Drawing.Size(40, 34);
            this.cmdEvolveSelected.TabIndex = 13;
            this.toolEvolveSelected.SetToolTip(this.cmdEvolveSelected, "Evolve selected pokemons");
            this.cmdEvolveSelected.UseVisualStyleBackColor = true;
            this.cmdEvolveSelected.Click += new System.EventHandler(this.cmdEvolveSelected_Click);
            // 
            // cmdTransferSelected
            // 
            this.cmdTransferSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdTransferSelected.Image = global::PoGo.NecroBot.GUI.PoGoImages.transfer;
            this.cmdTransferSelected.Location = new System.Drawing.Point(602, 457);
            this.cmdTransferSelected.Name = "cmdTransferSelected";
            this.cmdTransferSelected.Size = new System.Drawing.Size(40, 34);
            this.cmdTransferSelected.TabIndex = 12;
            this.toolTransferSelected.SetToolTip(this.cmdTransferSelected, "Transfer selected pokemons");
            this.cmdTransferSelected.UseVisualStyleBackColor = true;
            this.cmdTransferSelected.Click += new System.EventHandler(this.cmdTransferSelected_Click);
            // 
            // dataMyPokemons
            // 
            this.dataMyPokemons.AllowUserToAddRows = false;
            this.dataMyPokemons.AllowUserToDeleteRows = false;
            this.dataMyPokemons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataMyPokemons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMyPokemons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn1,
            this.Column10,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.Move1,
            this.Move2,
            this.Column9});
            this.dataMyPokemons.Location = new System.Drawing.Point(3, 3);
            this.dataMyPokemons.Name = "dataMyPokemons";
            this.dataMyPokemons.RowHeadersWidth = 10;
            this.dataMyPokemons.RowTemplate.Height = 40;
            this.dataMyPokemons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataMyPokemons.Size = new System.Drawing.Size(688, 451);
            this.dataMyPokemons.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Pokemon";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "ID";
            this.Column10.Name = "Column10";
            this.Column10.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "CP";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Max CP";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "IV";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Level";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 50;
            // 
            // Move1
            // 
            this.Move1.HeaderText = "Move1";
            this.Move1.Name = "Move1";
            this.Move1.ReadOnly = true;
            this.Move1.Width = 65;
            // 
            // Move2
            // 
            this.Move2.HeaderText = "Move2";
            this.Move2.Name = "Move2";
            this.Move2.ReadOnly = true;
            this.Move2.Width = 65;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Power";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // tabMap
            // 
            this.tabMap.Controls.Add(this.checkShowPath);
            this.tabMap.Controls.Add(this.checkShowPokegyms);
            this.tabMap.Controls.Add(this.checkShowPokestops);
            this.tabMap.Controls.Add(this.checkShowPokemons);
            this.tabMap.Controls.Add(this.textCurrentLatLng);
            this.tabMap.Controls.Add(this.label5);
            this.tabMap.Controls.Add(this.gMap);
            this.tabMap.Location = new System.Drawing.Point(4, 22);
            this.tabMap.Name = "tabMap";
            this.tabMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabMap.Size = new System.Drawing.Size(694, 497);
            this.tabMap.TabIndex = 0;
            this.tabMap.Text = "Live Map";
            this.tabMap.UseVisualStyleBackColor = true;
            // 
            // checkShowPath
            // 
            this.checkShowPath.AutoSize = true;
            this.checkShowPath.Checked = true;
            this.checkShowPath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowPath.Location = new System.Drawing.Point(344, 31);
            this.checkShowPath.Name = "checkShowPath";
            this.checkShowPath.Size = new System.Drawing.Size(108, 17);
            this.checkShowPath.TabIndex = 28;
            this.checkShowPath.Text = "Show Path taken";
            this.checkShowPath.UseVisualStyleBackColor = true;
            this.checkShowPath.CheckedChanged += new System.EventHandler(this.checkShowPath_CheckedChanged);
            // 
            // checkShowPokegyms
            // 
            this.checkShowPokegyms.AutoSize = true;
            this.checkShowPokegyms.Checked = true;
            this.checkShowPokegyms.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowPokegyms.Location = new System.Drawing.Point(232, 31);
            this.checkShowPokegyms.Name = "checkShowPokegyms";
            this.checkShowPokegyms.Size = new System.Drawing.Size(105, 17);
            this.checkShowPokegyms.TabIndex = 27;
            this.checkShowPokegyms.Text = "Show Pokegyms";
            this.checkShowPokegyms.UseVisualStyleBackColor = true;
            this.checkShowPokegyms.CheckedChanged += new System.EventHandler(this.checkShowPokegyms_CheckedChanged);
            // 
            // checkShowPokestops
            // 
            this.checkShowPokestops.AutoSize = true;
            this.checkShowPokestops.Checked = true;
            this.checkShowPokestops.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowPokestops.Location = new System.Drawing.Point(120, 31);
            this.checkShowPokestops.Name = "checkShowPokestops";
            this.checkShowPokestops.Size = new System.Drawing.Size(106, 17);
            this.checkShowPokestops.TabIndex = 26;
            this.checkShowPokestops.Text = "Show Pokestops";
            this.checkShowPokestops.UseVisualStyleBackColor = true;
            this.checkShowPokestops.CheckedChanged += new System.EventHandler(this.checkShowPokestops_CheckedChanged);
            // 
            // checkShowPokemons
            // 
            this.checkShowPokemons.AutoSize = true;
            this.checkShowPokemons.Checked = true;
            this.checkShowPokemons.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkShowPokemons.Location = new System.Drawing.Point(8, 31);
            this.checkShowPokemons.Name = "checkShowPokemons";
            this.checkShowPokemons.Size = new System.Drawing.Size(106, 17);
            this.checkShowPokemons.TabIndex = 25;
            this.checkShowPokemons.Text = "Show Pokémons";
            this.checkShowPokemons.UseVisualStyleBackColor = true;
            this.checkShowPokemons.CheckedChanged += new System.EventHandler(this.checkShowPokemons_CheckedChanged);
            // 
            // textCurrentLatLng
            // 
            this.textCurrentLatLng.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCurrentLatLng.Location = new System.Drawing.Point(85, 6);
            this.textCurrentLatLng.Name = "textCurrentLatLng";
            this.textCurrentLatLng.ReadOnly = true;
            this.textCurrentLatLng.Size = new System.Drawing.Size(467, 20);
            this.textCurrentLatLng.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Current lat/lng";
            // 
            // gMap
            // 
            this.gMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = true;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemmory = 5;
            this.gMap.Location = new System.Drawing.Point(6, 54);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 18;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = true;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(685, 437);
            this.gMap.TabIndex = 0;
            this.gMap.Zoom = 0D;
            // 
            // tabManualSniping
            // 
            this.tabManualSniping.Controls.Add(this.radioSnipeGetAll);
            this.tabManualSniping.Controls.Add(this.radioSnipeUseSettings);
            this.tabManualSniping.Controls.Add(this.label14);
            this.tabManualSniping.Controls.Add(this.label10);
            this.tabManualSniping.Controls.Add(this.cmdSnipeList);
            this.tabManualSniping.Controls.Add(this.textPokemonSnipeList);
            this.tabManualSniping.Controls.Add(this.label8);
            this.tabManualSniping.Location = new System.Drawing.Point(4, 22);
            this.tabManualSniping.Name = "tabManualSniping";
            this.tabManualSniping.Padding = new System.Windows.Forms.Padding(3);
            this.tabManualSniping.Size = new System.Drawing.Size(694, 497);
            this.tabManualSniping.TabIndex = 4;
            this.tabManualSniping.Text = "Pokemon Sniper";
            this.tabManualSniping.UseVisualStyleBackColor = true;
            // 
            // radioSnipeGetAll
            // 
            this.radioSnipeGetAll.AutoSize = true;
            this.radioSnipeGetAll.Location = new System.Drawing.Point(300, 78);
            this.radioSnipeGetAll.Name = "radioSnipeGetAll";
            this.radioSnipeGetAll.Size = new System.Drawing.Size(145, 17);
            this.radioSnipeGetAll.TabIndex = 8;
            this.radioSnipeGetAll.Text = "Get all pokemons from list";
            this.radioSnipeGetAll.UseVisualStyleBackColor = true;
            // 
            // radioSnipeUseSettings
            // 
            this.radioSnipeUseSettings.AutoSize = true;
            this.radioSnipeUseSettings.Checked = true;
            this.radioSnipeUseSettings.Location = new System.Drawing.Point(300, 58);
            this.radioSnipeUseSettings.Name = "radioSnipeUseSettings";
            this.radioSnipeUseSettings.Size = new System.Drawing.Size(342, 17);
            this.radioSnipeUseSettings.TabIndex = 7;
            this.radioSnipeUseSettings.TabStop = true;
            this.radioSnipeUseSettings.Text = "Use Pokemons in Sniping list from settings + KeepMinIVPercentage";
            this.radioSnipeUseSettings.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 41);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(317, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Example: 51.502251182719,-0.12680284541418 Porygon 78% IV";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(642, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Example: [248 seconds remaining] 78% IV - Porygon at 51.502251182719,-0.126802845" +
    "41418 [ Moveset: QuickAttackFast/Psybeam ]";
            // 
            // cmdSnipeList
            // 
            this.cmdSnipeList.Location = new System.Drawing.Point(9, 72);
            this.cmdSnipeList.Name = "cmdSnipeList";
            this.cmdSnipeList.Size = new System.Drawing.Size(246, 23);
            this.cmdSnipeList.TabIndex = 2;
            this.cmdSnipeList.Text = "Snipe List!";
            this.cmdSnipeList.UseVisualStyleBackColor = true;
            this.cmdSnipeList.Click += new System.EventHandler(this.cmdSnipeList_Click);
            // 
            // textPokemonSnipeList
            // 
            this.textPokemonSnipeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPokemonSnipeList.Location = new System.Drawing.Point(9, 101);
            this.textPokemonSnipeList.Multiline = true;
            this.textPokemonSnipeList.Name = "textPokemonSnipeList";
            this.textPokemonSnipeList.Size = new System.Drawing.Size(679, 390);
            this.textPokemonSnipeList.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(333, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Add sniping location and pokemon in the following format (1 per line): ";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.cmdSaveSettings);
            this.tabSettings.Controls.Add(this.tabControlSettings);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(694, 497);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Profile settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // cmdSaveSettings
            // 
            this.cmdSaveSettings.Location = new System.Drawing.Point(7, 6);
            this.cmdSaveSettings.Name = "cmdSaveSettings";
            this.cmdSaveSettings.Size = new System.Drawing.Size(100, 23);
            this.cmdSaveSettings.TabIndex = 37;
            this.cmdSaveSettings.Text = "Save Settings";
            this.cmdSaveSettings.UseVisualStyleBackColor = true;
            this.cmdSaveSettings.Click += new System.EventHandler(this.cmdSaveSettings_Click);
            // 
            // tabControlSettings
            // 
            this.tabControlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSettings.Controls.Add(this.tabPageSettingsGlobal);
            this.tabControlSettings.Controls.Add(this.tabPageSettingsSniping);
            this.tabControlSettings.Controls.Add(this.tabPageSettingsPokemons);
            this.tabControlSettings.Controls.Add(this.tabPageSettingsItems);
            this.tabControlSettings.Location = new System.Drawing.Point(3, 39);
            this.tabControlSettings.Name = "tabControlSettings";
            this.tabControlSettings.SelectedIndex = 0;
            this.tabControlSettings.Size = new System.Drawing.Size(688, 455);
            this.tabControlSettings.TabIndex = 13;
            // 
            // tabPageSettingsGlobal
            // 
            this.tabPageSettingsGlobal.Controls.Add(this.globalSettingsControl);
            this.tabPageSettingsGlobal.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettingsGlobal.Name = "tabPageSettingsGlobal";
            this.tabPageSettingsGlobal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettingsGlobal.Size = new System.Drawing.Size(680, 429);
            this.tabPageSettingsGlobal.TabIndex = 0;
            this.tabPageSettingsGlobal.Text = "Global";
            this.tabPageSettingsGlobal.UseVisualStyleBackColor = true;
            // 
            // globalSettingsControl
            // 
            this.globalSettingsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.globalSettingsControl.AutoScroll = true;
            this.globalSettingsControl.Location = new System.Drawing.Point(3, -26);
            this.globalSettingsControl.Name = "globalSettingsControl";
            this.globalSettingsControl.Size = new System.Drawing.Size(674, 452);
            this.globalSettingsControl.TabIndex = 36;
            // 
            // tabPageSettingsSniping
            // 
            this.tabPageSettingsSniping.Controls.Add(this.snipingSettingsControl);
            this.tabPageSettingsSniping.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettingsSniping.Name = "tabPageSettingsSniping";
            this.tabPageSettingsSniping.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettingsSniping.Size = new System.Drawing.Size(680, 429);
            this.tabPageSettingsSniping.TabIndex = 3;
            this.tabPageSettingsSniping.Text = "Sniping";
            this.tabPageSettingsSniping.UseVisualStyleBackColor = true;
            // 
            // snipingSettingsControl
            // 
            this.snipingSettingsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.snipingSettingsControl.Location = new System.Drawing.Point(3, 3);
            this.snipingSettingsControl.Name = "snipingSettingsControl";
            this.snipingSettingsControl.Size = new System.Drawing.Size(674, 423);
            this.snipingSettingsControl.TabIndex = 0;
            // 
            // tabPageSettingsPokemons
            // 
            this.tabPageSettingsPokemons.Controls.Add(this.settingsUsePokemonToNotCatchFilter);
            this.tabPageSettingsPokemons.Controls.Add(this.label25);
            this.tabPageSettingsPokemons.Controls.Add(this.settingsRenameAboveIv);
            this.tabPageSettingsPokemons.Controls.Add(this.label7);
            this.tabPageSettingsPokemons.Controls.Add(this.settingsKeepMinCp);
            this.tabPageSettingsPokemons.Controls.Add(this.settingsKeepMinDuplicatePokemon);
            this.tabPageSettingsPokemons.Controls.Add(this.settingsKeepMinIvPercentage);
            this.tabPageSettingsPokemons.Controls.Add(this.settingsTransferDuplicatePokemon);
            this.tabPageSettingsPokemons.Controls.Add(this.settingsPrioritizeIvOverCp);
            this.tabPageSettingsPokemons.Controls.Add(this.label6);
            this.tabPageSettingsPokemons.Controls.Add(this.settingsKeepPokemonsThatCanEvolve);
            this.tabPageSettingsPokemons.Controls.Add(this.label21);
            this.tabPageSettingsPokemons.Controls.Add(this.label20);
            this.tabPageSettingsPokemons.Controls.Add(this.label19);
            this.tabPageSettingsPokemons.Controls.Add(this.label18);
            this.tabPageSettingsPokemons.Controls.Add(this.label17);
            this.tabPageSettingsPokemons.Controls.Add(this.settingsEvolveAllPokemonWithEnoughCandy);
            this.tabPageSettingsPokemons.Controls.Add(this.settingsEvolveAboveIvValue);
            this.tabPageSettingsPokemons.Controls.Add(this.settingsEvolveAllPokemonAboveIv);
            this.tabPageSettingsPokemons.Controls.Add(this.label11);
            this.tabPageSettingsPokemons.Controls.Add(this.label12);
            this.tabPageSettingsPokemons.Controls.Add(this.label13);
            this.tabPageSettingsPokemons.Controls.Add(this.dataPokemonSettings);
            this.tabPageSettingsPokemons.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettingsPokemons.Name = "tabPageSettingsPokemons";
            this.tabPageSettingsPokemons.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettingsPokemons.Size = new System.Drawing.Size(680, 429);
            this.tabPageSettingsPokemons.TabIndex = 1;
            this.tabPageSettingsPokemons.Text = "Pokemons";
            this.tabPageSettingsPokemons.UseVisualStyleBackColor = true;
            // 
            // settingsUsePokemonToNotCatchFilter
            // 
            this.settingsUsePokemonToNotCatchFilter.AutoSize = true;
            this.settingsUsePokemonToNotCatchFilter.Location = new System.Drawing.Point(213, 99);
            this.settingsUsePokemonToNotCatchFilter.Name = "settingsUsePokemonToNotCatchFilter";
            this.settingsUsePokemonToNotCatchFilter.Size = new System.Drawing.Size(29, 17);
            this.settingsUsePokemonToNotCatchFilter.TabIndex = 136;
            this.settingsUsePokemonToNotCatchFilter.Text = " ";
            this.settingsUsePokemonToNotCatchFilter.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 100);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(151, 13);
            this.label25.TabIndex = 135;
            this.label25.Text = "UsePokemonToNotCatchFilter";
            // 
            // settingsRenameAboveIv
            // 
            this.settingsRenameAboveIv.AutoSize = true;
            this.settingsRenameAboveIv.Location = new System.Drawing.Point(213, 76);
            this.settingsRenameAboveIv.Name = "settingsRenameAboveIv";
            this.settingsRenameAboveIv.Size = new System.Drawing.Size(29, 17);
            this.settingsRenameAboveIv.TabIndex = 134;
            this.settingsRenameAboveIv.Text = " ";
            this.settingsRenameAboveIv.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 133;
            this.label7.Text = "RenameAboveIv";
            // 
            // settingsKeepMinCp
            // 
            this.settingsKeepMinCp.Location = new System.Drawing.Point(513, 6);
            this.settingsKeepMinCp.Name = "settingsKeepMinCp";
            this.settingsKeepMinCp.Size = new System.Drawing.Size(91, 20);
            this.settingsKeepMinCp.TabIndex = 132;
            // 
            // settingsKeepMinDuplicatePokemon
            // 
            this.settingsKeepMinDuplicatePokemon.Location = new System.Drawing.Point(513, 32);
            this.settingsKeepMinDuplicatePokemon.Name = "settingsKeepMinDuplicatePokemon";
            this.settingsKeepMinDuplicatePokemon.Size = new System.Drawing.Size(91, 20);
            this.settingsKeepMinDuplicatePokemon.TabIndex = 131;
            // 
            // settingsKeepMinIvPercentage
            // 
            this.settingsKeepMinIvPercentage.Location = new System.Drawing.Point(513, 58);
            this.settingsKeepMinIvPercentage.Name = "settingsKeepMinIvPercentage";
            this.settingsKeepMinIvPercentage.Size = new System.Drawing.Size(91, 20);
            this.settingsKeepMinIvPercentage.TabIndex = 130;
            // 
            // settingsTransferDuplicatePokemon
            // 
            this.settingsTransferDuplicatePokemon.AutoSize = true;
            this.settingsTransferDuplicatePokemon.Location = new System.Drawing.Point(513, 128);
            this.settingsTransferDuplicatePokemon.Name = "settingsTransferDuplicatePokemon";
            this.settingsTransferDuplicatePokemon.Size = new System.Drawing.Size(29, 17);
            this.settingsTransferDuplicatePokemon.TabIndex = 129;
            this.settingsTransferDuplicatePokemon.Text = " ";
            this.settingsTransferDuplicatePokemon.UseVisualStyleBackColor = true;
            // 
            // settingsPrioritizeIvOverCp
            // 
            this.settingsPrioritizeIvOverCp.AutoSize = true;
            this.settingsPrioritizeIvOverCp.Location = new System.Drawing.Point(513, 107);
            this.settingsPrioritizeIvOverCp.Name = "settingsPrioritizeIvOverCp";
            this.settingsPrioritizeIvOverCp.Size = new System.Drawing.Size(29, 17);
            this.settingsPrioritizeIvOverCp.TabIndex = 128;
            this.settingsPrioritizeIvOverCp.Text = " ";
            this.settingsPrioritizeIvOverCp.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(306, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 13);
            this.label6.TabIndex = 127;
            this.label6.Text = "TransferDuplicatePokemon";
            // 
            // settingsKeepPokemonsThatCanEvolve
            // 
            this.settingsKeepPokemonsThatCanEvolve.AutoSize = true;
            this.settingsKeepPokemonsThatCanEvolve.Location = new System.Drawing.Point(513, 84);
            this.settingsKeepPokemonsThatCanEvolve.Name = "settingsKeepPokemonsThatCanEvolve";
            this.settingsKeepPokemonsThatCanEvolve.Size = new System.Drawing.Size(29, 17);
            this.settingsKeepPokemonsThatCanEvolve.TabIndex = 126;
            this.settingsKeepPokemonsThatCanEvolve.Text = " ";
            this.settingsKeepPokemonsThatCanEvolve.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(306, 108);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(91, 13);
            this.label21.TabIndex = 125;
            this.label21.Text = "PrioritizeIvOverCp";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(306, 85);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(151, 13);
            this.label20.TabIndex = 124;
            this.label20.Text = "KeepPokemonThatCanEvolve";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(306, 61);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(113, 13);
            this.label19.TabIndex = 123;
            this.label19.Text = "KeepMinIvPercentage";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(306, 35);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(139, 13);
            this.label18.TabIndex = 122;
            this.label18.Text = "KeepMinDuplicatePokemon";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(306, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 121;
            this.label17.Text = "KeepMinCp";
            // 
            // settingsEvolveAllPokemonWithEnoughCandy
            // 
            this.settingsEvolveAllPokemonWithEnoughCandy.AutoSize = true;
            this.settingsEvolveAllPokemonWithEnoughCandy.Location = new System.Drawing.Point(213, 55);
            this.settingsEvolveAllPokemonWithEnoughCandy.Name = "settingsEvolveAllPokemonWithEnoughCandy";
            this.settingsEvolveAllPokemonWithEnoughCandy.Size = new System.Drawing.Size(29, 17);
            this.settingsEvolveAllPokemonWithEnoughCandy.TabIndex = 120;
            this.settingsEvolveAllPokemonWithEnoughCandy.Text = " ";
            this.settingsEvolveAllPokemonWithEnoughCandy.UseVisualStyleBackColor = true;
            // 
            // settingsEvolveAboveIvValue
            // 
            this.settingsEvolveAboveIvValue.Location = new System.Drawing.Point(213, 6);
            this.settingsEvolveAboveIvValue.Name = "settingsEvolveAboveIvValue";
            this.settingsEvolveAboveIvValue.Size = new System.Drawing.Size(67, 20);
            this.settingsEvolveAboveIvValue.TabIndex = 119;
            // 
            // settingsEvolveAllPokemonAboveIv
            // 
            this.settingsEvolveAllPokemonAboveIv.AutoSize = true;
            this.settingsEvolveAllPokemonAboveIv.Location = new System.Drawing.Point(213, 32);
            this.settingsEvolveAllPokemonAboveIv.Name = "settingsEvolveAllPokemonAboveIv";
            this.settingsEvolveAllPokemonAboveIv.Size = new System.Drawing.Size(29, 17);
            this.settingsEvolveAllPokemonAboveIv.TabIndex = 118;
            this.settingsEvolveAllPokemonAboveIv.Text = " ";
            this.settingsEvolveAllPokemonAboveIv.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(185, 13);
            this.label11.TabIndex = 117;
            this.label11.Text = "EvolveAllPokemonWithEnoughCandy";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(136, 13);
            this.label12.TabIndex = 116;
            this.label12.Text = "EvolveAllPokemonAboveIv";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 13);
            this.label13.TabIndex = 115;
            this.label13.Text = "EvolveAboveIvValue";
            // 
            // dataPokemonSettings
            // 
            this.dataPokemonSettings.AllowUserToAddRows = false;
            this.dataPokemonSettings.AllowUserToDeleteRows = false;
            this.dataPokemonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataPokemonSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataPokemonSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewImageColumn3,
            this.dataGridViewTextBoxColumn11,
            this.Column17,
            this.Column18,
            this.Column19,
            this.Column11,
            this.Column12,
            this.Column16,
            this.Column20});
            this.dataPokemonSettings.Location = new System.Drawing.Point(6, 151);
            this.dataPokemonSettings.Name = "dataPokemonSettings";
            this.dataPokemonSettings.RowHeadersWidth = 10;
            this.dataPokemonSettings.RowTemplate.Height = 40;
            this.dataPokemonSettings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataPokemonSettings.Size = new System.Drawing.Size(668, 272);
            this.dataPokemonSettings.TabIndex = 14;
            // 
            // tabPageSettingsItems
            // 
            this.tabPageSettingsItems.Controls.Add(this.dataItemSettings);
            this.tabPageSettingsItems.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettingsItems.Name = "tabPageSettingsItems";
            this.tabPageSettingsItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettingsItems.Size = new System.Drawing.Size(680, 429);
            this.tabPageSettingsItems.TabIndex = 2;
            this.tabPageSettingsItems.Text = "Items";
            this.tabPageSettingsItems.UseVisualStyleBackColor = true;
            // 
            // dataItemSettings
            // 
            this.dataItemSettings.AllowUserToAddRows = false;
            this.dataItemSettings.AllowUserToDeleteRows = false;
            this.dataItemSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataItemSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewImageColumn2,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.dataItemSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataItemSettings.Location = new System.Drawing.Point(3, 3);
            this.dataItemSettings.Name = "dataItemSettings";
            this.dataItemSettings.RowHeadersWidth = 10;
            this.dataItemSettings.RowTemplate.Height = 40;
            this.dataItemSettings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataItemSettings.Size = new System.Drawing.Size(674, 423);
            this.dataItemSettings.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "ID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Width = 30;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Item";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 150;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Keep Max";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn9.Width = 75;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "ID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "";
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            this.dataGridViewImageColumn3.Width = 30;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "Pokemon";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 90;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "KeepMinCP";
            this.Column17.Name = "Column17";
            this.Column17.Width = 75;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "KeepMinIV";
            this.Column18.Name = "Column18";
            this.Column18.Width = 75;
            // 
            // Column19
            // 
            this.Column19.HeaderText = "KeepMinDuplicate";
            this.Column19.Name = "Column19";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "NotToTransfer";
            this.Column11.Name = "Column11";
            // 
            // Column12
            // 
            this.Column12.HeaderText = "ToEvolve";
            this.Column12.Name = "Column12";
            this.Column12.Width = 60;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "ToIgnore";
            this.Column16.Name = "Column16";
            this.Column16.Width = 60;
            // 
            // Column20
            // 
            this.Column20.HeaderText = "ToSnipe";
            this.Column20.Name = "Column20";
            this.Column20.Width = 60;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NecroBot GUI";
            this.Load += new System.EventHandler(this.GUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConsole)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpPlayer.ResumeLayout(false);
            this.grpPlayer.PerformLayout();
            this.tabControlInventory.ResumeLayout(false);
            this.tabItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataMyItems)).EndInit();
            this.tabCandies.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataMyCandies)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabMyPokemons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataMyPokemons)).EndInit();
            this.tabMap.ResumeLayout(false);
            this.tabMap.PerformLayout();
            this.tabManualSniping.ResumeLayout(false);
            this.tabManualSniping.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabControlSettings.ResumeLayout(false);
            this.tabPageSettingsGlobal.ResumeLayout(false);
            this.tabPageSettingsSniping.ResumeLayout(false);
            this.tabPageSettingsPokemons.ResumeLayout(false);
            this.tabPageSettingsPokemons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataPokemonSettings)).EndInit();
            this.tabPageSettingsItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataItemSettings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridConsole;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grpPlayer;
        private System.Windows.Forms.TextBox textPlayerLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPlayerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textPlayerStardust;
        private System.Windows.Forms.Label labelPlayerPokeHr;
        private System.Windows.Forms.Label labelPlayerExpHr;
        private System.Windows.Forms.Label labelPlayerExpOverLevelExp;
        private System.Windows.Forms.ProgressBar progressPlayerExpBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textPlayerPokecoins;
        private System.Windows.Forms.TabControl tabControlInventory;
        private System.Windows.Forms.TabPage tabItems;
        private System.Windows.Forms.TabPage tabCandies;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabMap;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.DataGridView dataMyItems;
        private System.Windows.Forms.DataGridView dataMyCandies;
        private System.Windows.Forms.DataGridView dataMyPokemons;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.CheckBox checkShowPath;
        private System.Windows.Forms.CheckBox checkShowPokegyms;
        private System.Windows.Forms.CheckBox checkShowPokestops;
        private System.Windows.Forms.CheckBox checkShowPokemons;
        private System.Windows.Forms.TextBox textCurrentLatLng;
        private System.Windows.Forms.Label label5;
        private GMap.NET.WindowsForms.GMapControl gMap;
        private System.Windows.Forms.DataGridView dataItemSettings;
        private System.Windows.Forms.TabControl tabControlSettings;
        private System.Windows.Forms.TabPage tabPageSettingsGlobal;
        private System.Windows.Forms.TabPage tabPageSettingsPokemons;
        private System.Windows.Forms.TabPage tabPageSettingsItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewImageColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private GlobalSettingsControl globalSettingsControl;
        private System.Windows.Forms.Button cmdSaveSettings;
        private System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.TabPage tabMyPokemons;
        private System.Windows.Forms.TabPage tabPageSettingsSniping;
        private UserControls.SnipingSettingsControl snipingSettingsControl;
        private System.Windows.Forms.DataGridView dataPokemonSettings;
        private System.Windows.Forms.CheckBox settingsEvolveAllPokemonWithEnoughCandy;
        private System.Windows.Forms.TextBox settingsEvolveAboveIvValue;
        private System.Windows.Forms.CheckBox settingsEvolveAllPokemonAboveIv;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox settingsKeepMinCp;
        private System.Windows.Forms.TextBox settingsKeepMinDuplicatePokemon;
        private System.Windows.Forms.TextBox settingsKeepMinIvPercentage;
        private System.Windows.Forms.CheckBox settingsTransferDuplicatePokemon;
        private System.Windows.Forms.CheckBox settingsPrioritizeIvOverCp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox settingsKeepPokemonsThatCanEvolve;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.CheckBox settingsRenameAboveIv;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox settingsUsePokemonToNotCatchFilter;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TabPage tabManualSniping;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmdSnipeList;
        private System.Windows.Forms.TextBox textPokemonSnipeList;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton radioSnipeGetAll;
        private System.Windows.Forms.RadioButton radioSnipeUseSettings;
        private System.Windows.Forms.Button cmdEvolveSelected;
        private System.Windows.Forms.Button cmdTransferSelected;
        private System.Windows.Forms.ToolTip toolEvolveSelected;
        private System.Windows.Forms.ToolTip toolTransferSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Move1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Move2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column11;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column12;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column16;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column20;
    }
}

