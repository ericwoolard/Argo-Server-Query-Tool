namespace ArgoServerQuery
{
    partial class MainForm
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Counter-Terrorists", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Terrorists", System.Windows.Forms.HorizontalAlignment.Left);
            this.mnuMainStrip = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServersAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.lvMainView = new System.Windows.Forms.ListView();
            this.colNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPlayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuServer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCmd = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtRconPW = new System.Windows.Forms.TextBox();
            this.rconGroupBox = new System.Windows.Forms.GroupBox();
            this.optGroupBox = new System.Windows.Forms.GroupBox();
            this.btnUpdatePlayers = new System.Windows.Forms.Button();
            this.btnRestartServer = new System.Windows.Forms.Button();
            this.btnSendStatus = new System.Windows.Forms.Button();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.playersListView = new System.Windows.Forms.ListView();
            this.plvColPlayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.plvColScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.plvColTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuPlayers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.banPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.banServersTSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kickPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblServerList = new System.Windows.Forms.Label();
            this.comboServerList = new System.Windows.Forms.ComboBox();
            this.mnuMainStrip.SuspendLayout();
            this.contextMenuServer.SuspendLayout();
            this.rconGroupBox.SuspendLayout();
            this.optGroupBox.SuspendLayout();
            this.contextMenuPlayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMainStrip
            // 
            this.mnuMainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuView,
            this.mnuServers});
            this.mnuMainStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuMainStrip.MinimumSize = new System.Drawing.Size(1384, 24);
            this.mnuMainStrip.Name = "mnuMainStrip";
            this.mnuMainStrip.Size = new System.Drawing.Size(1384, 24);
            this.mnuMainStrip.TabIndex = 0;
            this.mnuMainStrip.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "&Edit";
            // 
            // mnuView
            // 
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(44, 20);
            this.mnuView.Text = "&View";
            // 
            // mnuServers
            // 
            this.mnuServers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuServersAdd});
            this.mnuServers.Name = "mnuServers";
            this.mnuServers.Size = new System.Drawing.Size(56, 20);
            this.mnuServers.Text = "&Servers";
            // 
            // mnuServersAdd
            // 
            this.mnuServersAdd.Name = "mnuServersAdd";
            this.mnuServersAdd.Size = new System.Drawing.Size(152, 22);
            this.mnuServersAdd.Text = "Add Server";
            this.mnuServersAdd.Click += new System.EventHandler(this.mnuServersAdd_Click);
            // 
            // lvMainView
            // 
            this.lvMainView.AllowColumnReorder = true;
            this.lvMainView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMainView.BackColor = System.Drawing.SystemColors.Window;
            this.lvMainView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNum,
            this.colPing,
            this.colAddr,
            this.colName,
            this.colMap,
            this.colPlayers,
            this.colVersion,
            this.colScore,
            this.colInfo});
            this.lvMainView.ContextMenuStrip = this.contextMenuServer;
            this.lvMainView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMainView.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvMainView.FullRowSelect = true;
            this.lvMainView.HideSelection = false;
            this.lvMainView.Location = new System.Drawing.Point(12, 65);
            this.lvMainView.MultiSelect = false;
            this.lvMainView.Name = "lvMainView";
            this.lvMainView.Size = new System.Drawing.Size(1360, 367);
            this.lvMainView.TabIndex = 1;
            this.lvMainView.UseCompatibleStateImageBehavior = false;
            this.lvMainView.View = System.Windows.Forms.View.Details;
            this.lvMainView.SelectedIndexChanged += new System.EventHandler(this.lvMainView_SelectedIndexChanged);
            // 
            // colNum
            // 
            this.colNum.Text = "#";
            this.colNum.Width = 34;
            // 
            // colPing
            // 
            this.colPing.Text = "Ping";
            this.colPing.Width = 50;
            // 
            // colAddr
            // 
            this.colAddr.Text = "Address";
            this.colAddr.Width = 150;
            // 
            // colName
            // 
            this.colName.Text = "Server Name";
            this.colName.Width = 280;
            // 
            // colMap
            // 
            this.colMap.Text = "Map";
            this.colMap.Width = 280;
            // 
            // colPlayers
            // 
            this.colPlayers.Text = "Players";
            this.colPlayers.Width = 115;
            // 
            // colVersion
            // 
            this.colVersion.Text = "Version";
            this.colVersion.Width = 115;
            // 
            // colScore
            // 
            this.colScore.Text = "Score";
            this.colScore.Width = 120;
            // 
            // colInfo
            // 
            this.colInfo.Text = "Info";
            this.colInfo.Width = 210;
            // 
            // contextMenuServer
            // 
            this.contextMenuServer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addInfoToolStripMenuItem,
            this.delServerToolStripMenuItem,
            this.scoreToolStripMenuItem,
            this.toolStripSeparator1,
            this.propertiesToolStripMenuItem});
            this.contextMenuServer.Name = "contextMenuServer";
            this.contextMenuServer.Size = new System.Drawing.Size(145, 98);
            // 
            // addInfoToolStripMenuItem
            // 
            this.addInfoToolStripMenuItem.Name = "addInfoToolStripMenuItem";
            this.addInfoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.addInfoToolStripMenuItem.Text = "Add Info";
            this.addInfoToolStripMenuItem.Click += new System.EventHandler(this.addInfoToolStripMenuItem_Click);
            // 
            // delServerToolStripMenuItem
            // 
            this.delServerToolStripMenuItem.Name = "delServerToolStripMenuItem";
            this.delServerToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.delServerToolStripMenuItem.Text = "Delete Server";
            this.delServerToolStripMenuItem.Click += new System.EventHandler(this.delServerToolStripMenuItem_Click);
            // 
            // scoreToolStripMenuItem
            // 
            this.scoreToolStripMenuItem.Name = "scoreToolStripMenuItem";
            this.scoreToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.scoreToolStripMenuItem.Text = "Update Score";
            this.scoreToolStripMenuItem.Click += new System.EventHandler(this.scoreToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            // 
            // txtCmd
            // 
            this.txtCmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmd.Location = new System.Drawing.Point(12, 809);
            this.txtCmd.Name = "txtCmd";
            this.txtCmd.Size = new System.Drawing.Size(773, 22);
            this.txtCmd.TabIndex = 3;
            this.txtCmd.WordWrap = false;
            this.txtCmd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCmd_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(791, 803);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(94, 32);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtRconPW
            // 
            this.txtRconPW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRconPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRconPW.Location = new System.Drawing.Point(27, 19);
            this.txtRconPW.Name = "txtRconPW";
            this.txtRconPW.Size = new System.Drawing.Size(226, 22);
            this.txtRconPW.TabIndex = 6;
            this.txtRconPW.UseSystemPasswordChar = true;
            // 
            // rconGroupBox
            // 
            this.rconGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rconGroupBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.rconGroupBox.Controls.Add(this.txtRconPW);
            this.rconGroupBox.Location = new System.Drawing.Point(903, 438);
            this.rconGroupBox.Name = "rconGroupBox";
            this.rconGroupBox.Size = new System.Drawing.Size(469, 51);
            this.rconGroupBox.TabIndex = 7;
            this.rconGroupBox.TabStop = false;
            this.rconGroupBox.Text = "Rcon Password";
            // 
            // optGroupBox
            // 
            this.optGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.optGroupBox.Controls.Add(this.btnUpdatePlayers);
            this.optGroupBox.Controls.Add(this.btnRestartServer);
            this.optGroupBox.Controls.Add(this.btnSendStatus);
            this.optGroupBox.Controls.Add(this.btnClearOutput);
            this.optGroupBox.Location = new System.Drawing.Point(903, 495);
            this.optGroupBox.Name = "optGroupBox";
            this.optGroupBox.Size = new System.Drawing.Size(469, 89);
            this.optGroupBox.TabIndex = 8;
            this.optGroupBox.TabStop = false;
            this.optGroupBox.Text = "Options";
            // 
            // btnUpdatePlayers
            // 
            this.btnUpdatePlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdatePlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePlayers.Location = new System.Drawing.Point(238, 20);
            this.btnUpdatePlayers.Name = "btnUpdatePlayers";
            this.btnUpdatePlayers.Size = new System.Drawing.Size(100, 26);
            this.btnUpdatePlayers.TabIndex = 2;
            this.btnUpdatePlayers.Text = "Update Players";
            this.btnUpdatePlayers.UseVisualStyleBackColor = true;
            this.btnUpdatePlayers.Click += new System.EventHandler(this.btnUpdatePlayers_Click);
            // 
            // btnRestartServer
            // 
            this.btnRestartServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestartServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestartServer.Location = new System.Drawing.Point(366, 20);
            this.btnRestartServer.Name = "btnRestartServer";
            this.btnRestartServer.Size = new System.Drawing.Size(97, 26);
            this.btnRestartServer.TabIndex = 0;
            this.btnRestartServer.Text = "Restart Server";
            this.btnRestartServer.UseVisualStyleBackColor = true;
            this.btnRestartServer.Click += new System.EventHandler(this.btnRestartServer_Click);
            // 
            // btnSendStatus
            // 
            this.btnSendStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendStatus.Location = new System.Drawing.Point(122, 20);
            this.btnSendStatus.Name = "btnSendStatus";
            this.btnSendStatus.Size = new System.Drawing.Size(88, 26);
            this.btnSendStatus.TabIndex = 1;
            this.btnSendStatus.Text = "Send Status";
            this.btnSendStatus.UseVisualStyleBackColor = true;
            this.btnSendStatus.Click += new System.EventHandler(this.btnSendStatus_Click);
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearOutput.Location = new System.Drawing.Point(6, 19);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(88, 26);
            this.btnClearOutput.TabIndex = 0;
            this.btnClearOutput.Text = "Clear Output";
            this.btnClearOutput.UseVisualStyleBackColor = true;
            this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(12, 438);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtOutput.Size = new System.Drawing.Size(873, 358);
            this.txtOutput.TabIndex = 10;
            this.txtOutput.Text = "";
            this.txtOutput.TextChanged += new System.EventHandler(this.txtOutput_TextChanged);
            // 
            // playersListView
            // 
            this.playersListView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.playersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.plvColPlayers,
            this.plvColScore,
            this.plvColTime});
            this.playersListView.ContextMenuStrip = this.contextMenuPlayers;
            this.playersListView.FullRowSelect = true;
            listViewGroup1.Header = "Counter-Terrorists";
            listViewGroup1.Name = "groupCT";
            listViewGroup2.Header = "Terrorists";
            listViewGroup2.Name = "groupT";
            this.playersListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.playersListView.HideSelection = false;
            this.playersListView.Location = new System.Drawing.Point(1031, 590);
            this.playersListView.MultiSelect = false;
            this.playersListView.Name = "playersListView";
            this.playersListView.ShowItemToolTips = true;
            this.playersListView.Size = new System.Drawing.Size(341, 245);
            this.playersListView.TabIndex = 11;
            this.playersListView.UseCompatibleStateImageBehavior = false;
            this.playersListView.View = System.Windows.Forms.View.Details;
            // 
            // plvColPlayers
            // 
            this.plvColPlayers.Text = "Players";
            this.plvColPlayers.Width = 160;
            // 
            // plvColScore
            // 
            this.plvColScore.Text = "Score";
            // 
            // plvColTime
            // 
            this.plvColTime.Text = "Time";
            this.plvColTime.Width = 115;
            // 
            // contextMenuPlayers
            // 
            this.contextMenuPlayers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.banPlayerToolStripMenuItem,
            this.banServersTSToolStripMenuItem,
            this.kickPlayerToolStripMenuItem});
            this.contextMenuPlayers.Name = "contextMenuPlayers";
            this.contextMenuPlayers.Size = new System.Drawing.Size(205, 70);
            // 
            // banPlayerToolStripMenuItem
            // 
            this.banPlayerToolStripMenuItem.Name = "banPlayerToolStripMenuItem";
            this.banPlayerToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.banPlayerToolStripMenuItem.Text = "Ban From All Servers";
            this.banPlayerToolStripMenuItem.Click += new System.EventHandler(this.banPlayerToolStripMenuItem_Click);
            // 
            // banServersTSToolStripMenuItem
            // 
            this.banServersTSToolStripMenuItem.Name = "banServersTSToolStripMenuItem";
            this.banServersTSToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.banServersTSToolStripMenuItem.Text = "Ban From Servers and TS";
            this.banServersTSToolStripMenuItem.Click += new System.EventHandler(this.banServersTSToolStripMenuItem_Click);
            // 
            // kickPlayerToolStripMenuItem
            // 
            this.kickPlayerToolStripMenuItem.Name = "kickPlayerToolStripMenuItem";
            this.kickPlayerToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.kickPlayerToolStripMenuItem.Text = "Kick From Server";
            this.kickPlayerToolStripMenuItem.Click += new System.EventHandler(this.kickPlayerToolStripMenuItem_Click);
            // 
            // lblServerList
            // 
            this.lblServerList.AutoSize = true;
            this.lblServerList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerList.Location = new System.Drawing.Point(12, 33);
            this.lblServerList.Name = "lblServerList";
            this.lblServerList.Size = new System.Drawing.Size(74, 16);
            this.lblServerList.TabIndex = 12;
            this.lblServerList.Text = "Server List:";
            // 
            // comboServerList
            // 
            this.comboServerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboServerList.FormattingEnabled = true;
            this.comboServerList.Location = new System.Drawing.Point(92, 32);
            this.comboServerList.Name = "comboServerList";
            this.comboServerList.Size = new System.Drawing.Size(174, 21);
            this.comboServerList.TabIndex = 13;
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1384, 861);
            this.Controls.Add(this.comboServerList);
            this.Controls.Add(this.lblServerList);
            this.Controls.Add(this.playersListView);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.optGroupBox);
            this.Controls.Add(this.rconGroupBox);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtCmd);
            this.Controls.Add(this.lvMainView);
            this.Controls.Add(this.mnuMainStrip);
            this.MainMenuStrip = this.mnuMainStrip;
            this.MinimumSize = new System.Drawing.Size(1400, 900);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Argo CS:GO Server Query Tool";
            this.mnuMainStrip.ResumeLayout(false);
            this.mnuMainStrip.PerformLayout();
            this.contextMenuServer.ResumeLayout(false);
            this.rconGroupBox.ResumeLayout(false);
            this.rconGroupBox.PerformLayout();
            this.optGroupBox.ResumeLayout(false);
            this.contextMenuPlayers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.MenuStrip mnuMainStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuServers;
        private System.Windows.Forms.ToolStripMenuItem mnuServersAdd;
        private System.Windows.Forms.ListView lvMainView;
        private System.Windows.Forms.ColumnHeader colNum;
        private System.Windows.Forms.ColumnHeader colAddr;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colMap;
        private System.Windows.Forms.ColumnHeader colInfo;
        private System.Windows.Forms.ColumnHeader colPlayers;
        private System.Windows.Forms.ColumnHeader colVersion;
        private System.Windows.Forms.ColumnHeader colPing;
        private System.Windows.Forms.TextBox txtCmd;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ContextMenuStrip contextMenuServer;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader colScore;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox txtRconPW;
        private System.Windows.Forms.GroupBox rconGroupBox;
        private System.Windows.Forms.GroupBox optGroupBox;
        private System.Windows.Forms.Button btnClearOutput;
        private System.Windows.Forms.Button btnSendStatus;
        private System.Windows.Forms.Button btnRestartServer;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.ToolStripMenuItem addInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem delServerToolStripMenuItem;
        private System.Windows.Forms.ListView playersListView;
        private System.Windows.Forms.Button btnUpdatePlayers;
        private System.Windows.Forms.ColumnHeader plvColPlayers;
        private System.Windows.Forms.ColumnHeader plvColScore;
        private System.Windows.Forms.ColumnHeader plvColTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuPlayers;
        private System.Windows.Forms.ToolStripMenuItem banPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem banServersTSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kickPlayerToolStripMenuItem;
        private System.Windows.Forms.Label lblServerList;
        private System.Windows.Forms.ComboBox comboServerList;
    }
}

