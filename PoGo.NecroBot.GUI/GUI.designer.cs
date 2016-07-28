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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridConsole = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpPlayer = new System.Windows.Forms.GroupBox();
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
            this.tabControlMapSettings = new System.Windows.Forms.TabControl();
            this.tabMap = new System.Windows.Forms.TabPage();
            this.tabConsole = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.grpMyPokemons = new System.Windows.Forms.GroupBox();
            this.dataMyPokemons = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Move1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Move2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConsole)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpPlayer.SuspendLayout();
            this.tabControlInventory.SuspendLayout();
            this.tabItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataMyItems)).BeginInit();
            this.tabCandies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataMyCandies)).BeginInit();
            this.tabControlMapSettings.SuspendLayout();
            this.tabConsole.SuspendLayout();
            this.grpMyPokemons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataMyPokemons)).BeginInit();
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridConsole.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridConsole.GridColor = System.Drawing.Color.Black;
            this.dataGridConsole.Location = new System.Drawing.Point(3, 3);
            this.dataGridConsole.Name = "dataGridConsole";
            this.dataGridConsole.ReadOnly = true;
            this.dataGridConsole.RowHeadersVisible = false;
            this.dataGridConsole.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Black;
            this.dataGridConsole.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridConsole.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.dataGridConsole.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridConsole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridConsole.Size = new System.Drawing.Size(688, 491);
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
            this.tableLayoutPanel1.Controls.Add(this.grpPlayer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tabControlInventory, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControlMapSettings, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpMyPokemons, 0, 2);
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
            // tabControlMapSettings
            // 
            this.tabControlMapSettings.Controls.Add(this.tabConsole);
            this.tabControlMapSettings.Controls.Add(this.tabMap);
            this.tabControlMapSettings.Controls.Add(this.tabSettings);
            this.tabControlMapSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMapSettings.Location = new System.Drawing.Point(303, 3);
            this.tabControlMapSettings.Name = "tabControlMapSettings";
            this.tableLayoutPanel1.SetRowSpan(this.tabControlMapSettings, 2);
            this.tabControlMapSettings.SelectedIndex = 0;
            this.tabControlMapSettings.Size = new System.Drawing.Size(702, 523);
            this.tabControlMapSettings.TabIndex = 1;
            // 
            // tabMap
            // 
            this.tabMap.Location = new System.Drawing.Point(4, 22);
            this.tabMap.Name = "tabMap";
            this.tabMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabMap.Size = new System.Drawing.Size(694, 497);
            this.tabMap.TabIndex = 0;
            this.tabMap.Text = "Live Map";
            this.tabMap.UseVisualStyleBackColor = true;
            // 
            // tabConsole
            // 
            this.tabConsole.Controls.Add(this.dataGridConsole);
            this.tabConsole.Location = new System.Drawing.Point(4, 22);
            this.tabConsole.Name = "tabConsole";
            this.tabConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsole.Size = new System.Drawing.Size(694, 497);
            this.tabConsole.TabIndex = 2;
            this.tabConsole.Text = "Console";
            this.tabConsole.UseVisualStyleBackColor = true;
            // 
            // tabSettings
            // 
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(694, 497);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // grpMyPokemons
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grpMyPokemons, 2);
            this.grpMyPokemons.Controls.Add(this.dataMyPokemons);
            this.grpMyPokemons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMyPokemons.Location = new System.Drawing.Point(3, 532);
            this.grpMyPokemons.Name = "grpMyPokemons";
            this.grpMyPokemons.Size = new System.Drawing.Size(1002, 194);
            this.grpMyPokemons.TabIndex = 4;
            this.grpMyPokemons.TabStop = false;
            this.grpMyPokemons.Text = "Pokemons (0/250)";
            // 
            // dataMyPokemons
            // 
            this.dataMyPokemons.AllowUserToAddRows = false;
            this.dataMyPokemons.AllowUserToDeleteRows = false;
            this.dataMyPokemons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataMyPokemons.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.Move1,
            this.Move2});
            this.dataMyPokemons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataMyPokemons.Location = new System.Drawing.Point(3, 16);
            this.dataMyPokemons.Name = "dataMyPokemons";
            this.dataMyPokemons.RowHeadersWidth = 10;
            this.dataMyPokemons.RowTemplate.Height = 40;
            this.dataMyPokemons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataMyPokemons.Size = new System.Drawing.Size(996, 175);
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
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "CP";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 75;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Max CP";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Perfect % (IV)";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Level";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // Move1
            // 
            this.Move1.HeaderText = "Move1";
            this.Move1.Name = "Move1";
            // 
            // Move2
            // 
            this.Move2.HeaderText = "Move2";
            this.Move2.Name = "Move2";
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
            this.tabControlMapSettings.ResumeLayout(false);
            this.tabConsole.ResumeLayout(false);
            this.grpMyPokemons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataMyPokemons)).EndInit();
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
        private System.Windows.Forms.TabControl tabControlMapSettings;
        private System.Windows.Forms.TabPage tabMap;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabConsole;
        private System.Windows.Forms.DataGridView dataMyItems;
        private System.Windows.Forms.DataGridView dataMyCandies;
        private System.Windows.Forms.GroupBox grpMyPokemons;
        private System.Windows.Forms.DataGridView dataMyPokemons;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewImageColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Move1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Move2;
    }
}

