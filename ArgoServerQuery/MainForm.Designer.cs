﻿using System.Runtime.CompilerServices;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Terrorists", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Counter-Terrorists", System.Windows.Forms.HorizontalAlignment.Left);
            this.lvMainView = new ArgoServerQuery.MainForm.BufferedListView();
            this.colNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPing = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMap = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPlayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInfo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGetScoreToggle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuServer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyAddrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnSend = new System.Windows.Forms.Button();
            this.txtRconPW = new System.Windows.Forms.TextBox();
            this.rconGroupBox = new System.Windows.Forms.GroupBox();
            this.tsMenu = new ArgoServerQuery.TsMenu();
            this.lblRconSaved = new System.Windows.Forms.Label();
            this.chkRconShow = new System.Windows.Forms.CheckBox();
            this.btnRconSave = new System.Windows.Forms.Button();
            this.toolsGroupBox = new System.Windows.Forms.GroupBox();
            this.btnUpdatePlayers = new System.Windows.Forms.Button();
            this.btnRestartServer = new System.Windows.Forms.Button();
            this.btnSendStatus = new System.Windows.Forms.Button();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.contextMenuTxtOutput = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemCopyTxtOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.playersListView = new System.Windows.Forms.ListView();
            this.plvColKills = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.plvColPlayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.plvColDeaths = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuPlayers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyPlayerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPlayerIpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copySteamIDPlayerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewProfileBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPlayerListSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.banPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.banServersTSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kickPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblServerList = new System.Windows.Forms.Label();
            this.comboServerList = new System.Windows.Forms.ComboBox();
            this.btnNewServerList = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboRegion = new System.Windows.Forms.ComboBox();
            this.comboTS3 = new System.Windows.Forms.ComboBox();
            this.chkTS3 = new System.Windows.Forms.CheckBox();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverListLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServersAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServersAddAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainStrip = new System.Windows.Forms.MenuStrip();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRconAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsChat = new System.Windows.Forms.ToolStripMenuItem();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.lblErrors = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolBtnDeleteList = new System.Windows.Forms.ToolStripButton();
            this.toolBtnAddServer = new System.Windows.Forms.ToolStripButton();
            this.toolBtnRCONAll = new System.Windows.Forms.ToolStripButton();
            this.toolBtnScoreToggle = new System.Windows.Forms.ToolStripButton();
            this.comboCmd = new System.Windows.Forms.ComboBox();
            this.contextMenuCmd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyCmdMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteCmdMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorCmd = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllCmdMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorCmd2 = new System.Windows.Forms.ToolStripSeparator();
            this.commonCmdMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getpugscoreMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hostPlayersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hostWkshpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kickMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smAddBanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smBanIPMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smPluginsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smUnbanMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changelevelCmdMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.de_cacheMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.de_canalsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.de_cbbleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.de_dust2MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.de_infernoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.de_mirageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.de_nukeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.de_overpassMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.de_santoriniMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.de_seasonMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.de_trainMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparatorCmd3 = new System.Windows.Forms.ToolStripSeparator();
            this.clearCmdMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblRegion = new System.Windows.Forms.Label();
            this.lblTS3 = new System.Windows.Forms.Label();
            this.customTabControl = new System.Windows.Forms.CustomTabControl();
            this.tabConsole = new System.Windows.Forms.TabPage();
            this.tabChat = new System.Windows.Forms.TabPage();
            this.chkChatLog = new System.Windows.Forms.CheckBox();
            this.btnSendChat = new System.Windows.Forms.Button();
            this.txtSendChat = new System.Windows.Forms.TextBox();
            this.txtChat = new System.Windows.Forms.RichTextBox();
            this.optPanel = new System.Windows.Forms.Panel();
            this.lblOptions = new System.Windows.Forms.Label();
            this.contextMenuServer.SuspendLayout();
            this.rconGroupBox.SuspendLayout();
            this.contextMenuTxtOutput.SuspendLayout();
            this.contextMenuPlayers.SuspendLayout();
            this.mnuMainStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.contextMenuCmd.SuspendLayout();
            this.customTabControl.SuspendLayout();
            this.tabConsole.SuspendLayout();
            this.tabChat.SuspendLayout();
            this.optPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvMainView
            // 
            this.lvMainView.AllowColumnReorder = true;
            this.lvMainView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvMainView.BackColor = System.Drawing.Color.Silver;
            this.lvMainView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNum,
            this.colPing,
            this.colAddr,
            this.colName,
            this.colMap,
            this.colPlayers,
            this.colVersion,
            this.colScore,
            this.colInfo,
            this.colGetScoreToggle});
            this.lvMainView.ContextMenuStrip = this.contextMenuServer;
            this.lvMainView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMainView.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvMainView.FullRowSelect = true;
            this.lvMainView.HideSelection = false;
            this.lvMainView.Location = new System.Drawing.Point(12, 65);
            this.lvMainView.MultiSelect = false;
            this.lvMainView.Name = "lvMainView";
            this.lvMainView.Size = new System.Drawing.Size(1360, 314);
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
            this.colName.Width = 270;
            // 
            // colMap
            // 
            this.colMap.Text = "Map";
            this.colMap.Width = 270;
            // 
            // colPlayers
            // 
            this.colPlayers.Text = "Players";
            this.colPlayers.Width = 110;
            // 
            // colVersion
            // 
            this.colVersion.Text = "Version";
            this.colVersion.Width = 110;
            // 
            // colScore
            // 
            this.colScore.Text = "Score";
            this.colScore.Width = 120;
            // 
            // colInfo
            // 
            this.colInfo.Text = "Info";
            this.colInfo.Width = 205;
            // 
            // colGetScoreToggle
            // 
            this.colGetScoreToggle.Text = "";
            this.colGetScoreToggle.Width = 37;
            // 
            // contextMenuServer
            // 
            this.contextMenuServer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyAddrToolStripMenuItem,
            this.copyMapToolStripMenuItem,
            this.toolStripSeparator1,
            this.addInfoToolStripMenuItem,
            this.delServerToolStripMenuItem});
            this.contextMenuServer.Name = "contextMenuServer";
            this.contextMenuServer.Size = new System.Drawing.Size(165, 98);
            // 
            // copyAddrToolStripMenuItem
            // 
            this.copyAddrToolStripMenuItem.Name = "copyAddrToolStripMenuItem";
            this.copyAddrToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.copyAddrToolStripMenuItem.Text = "Copy Address";
            this.copyAddrToolStripMenuItem.Click += new System.EventHandler(this.copyAddrToolStripMenuItem_Click);
            // 
            // copyMapToolStripMenuItem
            // 
            this.copyMapToolStripMenuItem.Name = "copyMapToolStripMenuItem";
            this.copyMapToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.copyMapToolStripMenuItem.Text = "Copy Map Name";
            this.copyMapToolStripMenuItem.Click += new System.EventHandler(this.copyMapToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // addInfoToolStripMenuItem
            // 
            this.addInfoToolStripMenuItem.Name = "addInfoToolStripMenuItem";
            this.addInfoToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.addInfoToolStripMenuItem.Text = "Add Info";
            this.addInfoToolStripMenuItem.Click += new System.EventHandler(this.addInfoToolStripMenuItem_Click);
            // 
            // delServerToolStripMenuItem
            // 
            this.delServerToolStripMenuItem.Name = "delServerToolStripMenuItem";
            this.delServerToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.delServerToolStripMenuItem.Text = "Delete Server";
            this.delServerToolStripMenuItem.Click += new System.EventHandler(this.delServerToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "trophy.png");
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(765, 414);
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
            this.txtRconPW.Location = new System.Drawing.Point(6, 19);
            this.txtRconPW.Name = "txtRconPW";
            this.txtRconPW.Size = new System.Drawing.Size(237, 22);
            this.txtRconPW.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtRconPW, "Password for all servers in current list");
            this.txtRconPW.UseSystemPasswordChar = true;
            // 
            // rconGroupBox
            // 
            this.rconGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rconGroupBox.BackColor = System.Drawing.Color.DimGray;
            this.rconGroupBox.Controls.Add(this.lblRconSaved);
            this.rconGroupBox.Controls.Add(this.chkRconShow);
            this.rconGroupBox.Controls.Add(this.txtRconPW);
            this.rconGroupBox.Controls.Add(this.btnRconSave);
            this.rconGroupBox.Location = new System.Drawing.Point(903, 408);
            this.rconGroupBox.Name = "rconGroupBox";
            this.rconGroupBox.Size = new System.Drawing.Size(469, 51);
            this.rconGroupBox.TabIndex = 7;
            this.rconGroupBox.TabStop = false;
            this.rconGroupBox.Text = "Rcon Password";
            // 
            // tsMenu
            // 
            this.tsMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tsMenu.BackColor = System.Drawing.Color.Gray;
            this.tsMenu.Location = new System.Drawing.Point(1084, 65);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(300, 390);
            this.tsMenu.TabIndex = 20;
            this.tsMenu.Visible = false;
            // 
            // lblRconSaved
            // 
            this.lblRconSaved.AutoSize = true;
            this.lblRconSaved.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRconSaved.Location = new System.Drawing.Point(405, 23);
            this.lblRconSaved.Name = "lblRconSaved";
            this.lblRconSaved.Size = new System.Drawing.Size(50, 13);
            this.lblRconSaved.TabIndex = 11;
            this.lblRconSaved.Text = "✔ Saved";
            this.lblRconSaved.Visible = false;
            // 
            // chkRconShow
            // 
            this.chkRconShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkRconShow.AutoSize = true;
            this.chkRconShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRconShow.Location = new System.Drawing.Point(249, 23);
            this.chkRconShow.Name = "chkRconShow";
            this.chkRconShow.Size = new System.Drawing.Size(53, 17);
            this.chkRconShow.TabIndex = 10;
            this.chkRconShow.Text = "Show";
            this.chkRconShow.UseVisualStyleBackColor = true;
            this.chkRconShow.CheckedChanged += new System.EventHandler(this.chkRconShow_CheckedChanged);
            // 
            // btnRconSave
            // 
            this.btnRconSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRconSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRconSave.Location = new System.Drawing.Point(308, 16);
            this.btnRconSave.Name = "btnRconSave";
            this.btnRconSave.Size = new System.Drawing.Size(82, 26);
            this.btnRconSave.TabIndex = 9;
            this.btnRconSave.Text = "Save";
            this.btnRconSave.UseVisualStyleBackColor = true;
            this.btnRconSave.Click += new System.EventHandler(this.btnRconSave_Click);
            // 
            // toolsGroupBox
            // 
            this.toolsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toolsGroupBox.BackColor = System.Drawing.Color.DimGray;
            this.toolsGroupBox.Location = new System.Drawing.Point(775, 348);
            this.toolsGroupBox.Name = "toolsGroupBox";
            this.toolsGroupBox.Size = new System.Drawing.Size(469, 60);
            this.toolsGroupBox.TabIndex = 8;
            this.toolsGroupBox.TabStop = false;
            this.toolsGroupBox.Text = "Tools";
            // 
            // btnUpdatePlayers
            // 
            this.btnUpdatePlayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdatePlayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePlayers.Location = new System.Drawing.Point(235, 25);
            this.btnUpdatePlayers.Name = "btnUpdatePlayers";
            this.btnUpdatePlayers.Size = new System.Drawing.Size(100, 26);
            this.btnUpdatePlayers.TabIndex = 2;
            this.btnUpdatePlayers.Text = "Update Players";
            this.toolTip1.SetToolTip(this.btnUpdatePlayers, "Retrieve a list of players in selected server");
            this.btnUpdatePlayers.UseVisualStyleBackColor = true;
            this.btnUpdatePlayers.Click += new System.EventHandler(this.btnUpdatePlayers_Click);
            // 
            // btnRestartServer
            // 
            this.btnRestartServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestartServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestartServer.Location = new System.Drawing.Point(358, 25);
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
            this.btnSendStatus.Location = new System.Drawing.Point(124, 25);
            this.btnSendStatus.Name = "btnSendStatus";
            this.btnSendStatus.Size = new System.Drawing.Size(88, 26);
            this.btnSendStatus.TabIndex = 1;
            this.btnSendStatus.Text = "Send Status";
            this.toolTip1.SetToolTip(this.btnSendStatus, "Send the \'Status\' command to selected server");
            this.btnSendStatus.UseVisualStyleBackColor = true;
            this.btnSendStatus.Click += new System.EventHandler(this.btnSendStatus_Click);
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearOutput.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnClearOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearOutput.Location = new System.Drawing.Point(13, 25);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(88, 26);
            this.btnClearOutput.TabIndex = 0;
            this.btnClearOutput.Text = "Clear Output";
            this.toolTip1.SetToolTip(this.btnClearOutput, "Clear all console output");
            this.btnClearOutput.UseVisualStyleBackColor = true;
            this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.ContextMenuStrip = this.contextMenuTxtOutput;
            this.txtOutput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOutput.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(0, 0);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtOutput.Size = new System.Drawing.Size(865, 413);
            this.txtOutput.TabIndex = 10;
            this.txtOutput.Text = "";
            this.txtOutput.TextChanged += new System.EventHandler(this.txtOutput_TextChanged);
            // 
            // contextMenuTxtOutput
            // 
            this.contextMenuTxtOutput.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemCopyTxtOutput});
            this.contextMenuTxtOutput.Name = "contextMenuTxtOutput";
            this.contextMenuTxtOutput.Size = new System.Drawing.Size(103, 26);
            // 
            // menuItemCopyTxtOutput
            // 
            this.menuItemCopyTxtOutput.Name = "menuItemCopyTxtOutput";
            this.menuItemCopyTxtOutput.Size = new System.Drawing.Size(102, 22);
            this.menuItemCopyTxtOutput.Text = "Copy";
            this.menuItemCopyTxtOutput.Click += new System.EventHandler(this.menuItemCopyTxtOutput_Click);
            // 
            // playersListView
            // 
            this.playersListView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.playersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.plvColKills,
            this.plvColPlayers,
            this.plvColDeaths});
            this.playersListView.ContextMenuStrip = this.contextMenuPlayers;
            this.playersListView.FullRowSelect = true;
            listViewGroup1.Header = "Terrorists";
            listViewGroup1.Name = "groupT";
            listViewGroup2.Header = "Counter-Terrorists";
            listViewGroup2.Name = "groupCT";
            this.playersListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.playersListView.HideSelection = false;
            this.playersListView.Location = new System.Drawing.Point(1031, 570);
            this.playersListView.MultiSelect = false;
            this.playersListView.Name = "playersListView";
            this.playersListView.ShowItemToolTips = true;
            this.playersListView.Size = new System.Drawing.Size(341, 291);
            this.playersListView.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.playersListView.TabIndex = 11;
            this.playersListView.UseCompatibleStateImageBehavior = false;
            this.playersListView.View = System.Windows.Forms.View.Details;
            // 
            // plvColKills
            // 
            this.plvColKills.DisplayIndex = 1;
            this.plvColKills.Text = "Kills";
            // 
            // plvColPlayers
            // 
            this.plvColPlayers.DisplayIndex = 0;
            this.plvColPlayers.Text = "Players";
            this.plvColPlayers.Width = 160;
            // 
            // plvColDeaths
            // 
            this.plvColDeaths.Text = "Deaths";
            this.plvColDeaths.Width = 117;
            // 
            // contextMenuPlayers
            // 
            this.contextMenuPlayers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyPlayerMenuItem,
            this.copyPlayerIpMenuItem,
            this.copySteamIDPlayerMenuItem,
            this.viewProfileBrowser,
            this.mnuPlayerListSeparator,
            this.banPlayerToolStripMenuItem,
            this.banServersTSToolStripMenuItem,
            this.kickPlayerToolStripMenuItem});
            this.contextMenuPlayers.Name = "contextMenuPlayers";
            this.contextMenuPlayers.Size = new System.Drawing.Size(205, 164);
            // 
            // copyPlayerMenuItem
            // 
            this.copyPlayerMenuItem.Name = "copyPlayerMenuItem";
            this.copyPlayerMenuItem.Size = new System.Drawing.Size(204, 22);
            this.copyPlayerMenuItem.Text = "Copy Player Name";
            this.copyPlayerMenuItem.Click += new System.EventHandler(this.copyPlayerMenuItem_Click);
            // 
            // copyPlayerIpMenuItem
            // 
            this.copyPlayerIpMenuItem.Name = "copyPlayerIpMenuItem";
            this.copyPlayerIpMenuItem.Size = new System.Drawing.Size(204, 22);
            this.copyPlayerIpMenuItem.Text = "Copy Player IP";
            this.copyPlayerIpMenuItem.Click += new System.EventHandler(this.copyPlayerIpMenuItem_Click);
            // 
            // copySteamIDPlayerMenuItem
            // 
            this.copySteamIDPlayerMenuItem.Name = "copySteamIDPlayerMenuItem";
            this.copySteamIDPlayerMenuItem.Size = new System.Drawing.Size(204, 22);
            this.copySteamIDPlayerMenuItem.Text = "Copy SteamID";
            this.copySteamIDPlayerMenuItem.Click += new System.EventHandler(this.copySteamIDPlayerMenuItem_Click);
            // 
            // viewProfileBrowser
            // 
            this.viewProfileBrowser.Name = "viewProfileBrowser";
            this.viewProfileBrowser.Size = new System.Drawing.Size(204, 22);
            this.viewProfileBrowser.Text = "View Profile in Browser";
            this.viewProfileBrowser.Click += new System.EventHandler(this.viewProfileBrowser_Click);
            // 
            // mnuPlayerListSeparator
            // 
            this.mnuPlayerListSeparator.Name = "mnuPlayerListSeparator";
            this.mnuPlayerListSeparator.Size = new System.Drawing.Size(201, 6);
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
            this.lblServerList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerList.ForeColor = System.Drawing.SystemColors.Control;
            this.lblServerList.Location = new System.Drawing.Point(15, 35);
            this.lblServerList.Name = "lblServerList";
            this.lblServerList.Size = new System.Drawing.Size(68, 17);
            this.lblServerList.TabIndex = 12;
            this.lblServerList.Text = "Server List";
            // 
            // comboServerList
            // 
            this.comboServerList.BackColor = System.Drawing.SystemColors.Menu;
            this.comboServerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboServerList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboServerList.ForeColor = System.Drawing.SystemColors.WindowText;
            this.comboServerList.FormattingEnabled = true;
            this.comboServerList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboServerList.Location = new System.Drawing.Point(92, 34);
            this.comboServerList.MaxDropDownItems = 10;
            this.comboServerList.Name = "comboServerList";
            this.comboServerList.Size = new System.Drawing.Size(174, 21);
            this.comboServerList.TabIndex = 13;
            this.toolTip1.SetToolTip(this.comboServerList, "Select server list");
            this.comboServerList.SelectedIndexChanged += new System.EventHandler(this.comboServerList_SelectedIndexChanged);
            this.comboServerList.SelectionChangeCommitted += new System.EventHandler(this.comboServerList_SelectionChangeCommitted);
            // 
            // btnNewServerList
            // 
            this.btnNewServerList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewServerList.Location = new System.Drawing.Point(275, 33);
            this.btnNewServerList.Name = "btnNewServerList";
            this.btnNewServerList.Size = new System.Drawing.Size(80, 24);
            this.btnNewServerList.TabIndex = 14;
            this.btnNewServerList.Text = "Create New";
            this.toolTip1.SetToolTip(this.btnNewServerList, "New server list");
            this.btnNewServerList.UseVisualStyleBackColor = true;
            this.btnNewServerList.Click += new System.EventHandler(this.btnNewServerList_Click);
            // 
            // openFile
            // 
            this.openFile.DefaultExt = "sqlite";
            this.openFile.InitialDirectory = "D:\\Visual Studio Projects\\Argo Server Query\\Argo Server Query\\ArgoServerQuery\\Arg" +
    "oServerQuery\\bin\\Debug";
            this.openFile.Title = "Open Server List";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 750;
            // 
            // comboRegion
            // 
            this.comboRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboRegion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboRegion.FormattingEnabled = true;
            this.comboRegion.Items.AddRange(new object[] {
            "EU",
            "NA",
            "AU/NZ"});
            this.comboRegion.Location = new System.Drawing.Point(1008, 34);
            this.comboRegion.MaxDropDownItems = 5;
            this.comboRegion.Name = "comboRegion";
            this.comboRegion.Size = new System.Drawing.Size(73, 21);
            this.comboRegion.TabIndex = 23;
            this.toolTip1.SetToolTip(this.comboRegion, "Choose your region");
            this.comboRegion.SelectedIndexChanged += new System.EventHandler(this.comboRegion_SelectedIndexChanged);
            // 
            // comboTS3
            // 
            this.comboTS3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboTS3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTS3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboTS3.FormattingEnabled = true;
            this.comboTS3.Items.AddRange(new object[] {
            "Enable Modal Message",
            "Disable Modal Message",
            "Move Servers Channel To Top",
            "Mute RTP Channel",
            "Unmute RTP Channel"});
            this.comboTS3.Location = new System.Drawing.Point(1135, 34);
            this.comboTS3.Name = "comboTS3";
            this.comboTS3.Size = new System.Drawing.Size(175, 21);
            this.comboTS3.TabIndex = 26;
            this.toolTip1.SetToolTip(this.comboTS3, "TS3 Command List");
            this.comboTS3.SelectedIndexChanged += new System.EventHandler(this.comboTS3_SelectedIndexChanged);
            // 
            // chkTS3
            // 
            this.chkTS3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTS3.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkTS3.AutoSize = true;
            this.chkTS3.Image = global::ArgoServerQuery.Properties.Resources.TeamSpeak;
            this.chkTS3.Location = new System.Drawing.Point(1334, 26);
            this.chkTS3.Name = "chkTS3";
            this.chkTS3.Size = new System.Drawing.Size(38, 38);
            this.chkTS3.TabIndex = 18;
            this.toolTip1.SetToolTip(this.chkTS3, "Show TS3 config");
            this.chkTS3.UseVisualStyleBackColor = true;
            this.chkTS3.CheckedChanged += new System.EventHandler(this.chkTS3_CheckedChanged);
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.fileStripSeparator,
            this.exitToolStripMenuItem});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.newToolStripMenuItem.Text = "New Server List";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.btnNewServerList_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.openToolStripMenuItem.Text = "Open Server List";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // fileStripSeparator
            // 
            this.fileStripSeparator.Name = "fileStripSeparator";
            this.fileStripSeparator.Size = new System.Drawing.Size(156, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
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
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.serverListLocationToolStripMenuItem});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(44, 20);
            this.mnuView.Text = "&View";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // serverListLocationToolStripMenuItem
            // 
            this.serverListLocationToolStripMenuItem.Name = "serverListLocationToolStripMenuItem";
            this.serverListLocationToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.serverListLocationToolStripMenuItem.Text = "Server List Location";
            this.serverListLocationToolStripMenuItem.Click += new System.EventHandler(this.serverListLocationToolStripMenuItem_Click);
            // 
            // mnuServers
            // 
            this.mnuServers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuServersAdd,
            this.mnuServersAddAll});
            this.mnuServers.Name = "mnuServers";
            this.mnuServers.Size = new System.Drawing.Size(56, 20);
            this.mnuServers.Text = "&Servers";
            // 
            // mnuServersAdd
            // 
            this.mnuServersAdd.Name = "mnuServersAdd";
            this.mnuServersAdd.Size = new System.Drawing.Size(132, 22);
            this.mnuServersAdd.Text = "Add Server";
            this.mnuServersAdd.Click += new System.EventHandler(this.mnuServersAdd_Click);
            // 
            // mnuServersAddAll
            // 
            this.mnuServersAddAll.Name = "mnuServersAddAll";
            this.mnuServersAddAll.Size = new System.Drawing.Size(132, 22);
            this.mnuServersAddAll.Text = "Auto-Build";
            this.mnuServersAddAll.Click += new System.EventHandler(this.mnuServersAddAll_Click);
            // 
            // mnuMainStrip
            // 
            this.mnuMainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuView,
            this.mnuServers,
            this.mnuTools});
            this.mnuMainStrip.Location = new System.Drawing.Point(0, 0);
            this.mnuMainStrip.MinimumSize = new System.Drawing.Size(1384, 24);
            this.mnuMainStrip.Name = "mnuMainStrip";
            this.mnuMainStrip.Size = new System.Drawing.Size(1384, 24);
            this.mnuMainStrip.TabIndex = 0;
            this.mnuMainStrip.Text = "menuStrip1";
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRconAll,
            this.mnuToolsChat});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(47, 20);
            this.mnuTools.Text = "Tools";
            // 
            // mnuRconAll
            // 
            this.mnuRconAll.Name = "mnuRconAll";
            this.mnuRconAll.Size = new System.Drawing.Size(134, 22);
            this.mnuRconAll.Text = "RCON2All";
            this.mnuRconAll.Click += new System.EventHandler(this.toolBtnRCONAll_Click);
            // 
            // mnuToolsChat
            // 
            this.mnuToolsChat.Name = "mnuToolsChat";
            this.mnuToolsChat.Size = new System.Drawing.Size(134, 22);
            this.mnuToolsChat.Text = "Server Chat";
            this.mnuToolsChat.Click += new System.EventHandler(this.mnuToolsChat_Click);
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 155);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(150, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(150, 25);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightToolStripPanel.Location = new System.Drawing.Point(150, 25);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 130);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 25);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 130);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(150, 130);
            // 
            // lblErrors
            // 
            this.lblErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErrors.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrors.ForeColor = System.Drawing.Color.Red;
            this.lblErrors.Location = new System.Drawing.Point(9, 864);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(776, 23);
            this.lblErrors.TabIndex = 19;
            this.lblErrors.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 863);
            this.progressBar.MarqueeAnimationSpeed = 17;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(159, 16);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 21;
            this.progressBar.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnDeleteList,
            this.toolBtnAddServer,
            this.toolBtnRCONAll,
            this.toolBtnScoreToggle});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(365, 33);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(105, 25);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolBtnDeleteList
            // 
            this.toolBtnDeleteList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnDeleteList.Image = global::ArgoServerQuery.Properties.Resources.delete;
            this.toolBtnDeleteList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnDeleteList.Margin = new System.Windows.Forms.Padding(0, 1, 10, 2);
            this.toolBtnDeleteList.Name = "toolBtnDeleteList";
            this.toolBtnDeleteList.Size = new System.Drawing.Size(23, 22);
            this.toolBtnDeleteList.ToolTipText = "Delete current server list";
            this.toolBtnDeleteList.Click += new System.EventHandler(this.toolBtnDeleteList_Click);
            // 
            // toolBtnAddServer
            // 
            this.toolBtnAddServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnAddServer.Image = global::ArgoServerQuery.Properties.Resources.plus_circle;
            this.toolBtnAddServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnAddServer.Name = "toolBtnAddServer";
            this.toolBtnAddServer.Size = new System.Drawing.Size(23, 22);
            this.toolBtnAddServer.ToolTipText = "Add server";
            this.toolBtnAddServer.Click += new System.EventHandler(this.mnuServersAdd_Click);
            // 
            // toolBtnRCONAll
            // 
            this.toolBtnRCONAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnRCONAll.Image = global::ArgoServerQuery.Properties.Resources.server;
            this.toolBtnRCONAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnRCONAll.Name = "toolBtnRCONAll";
            this.toolBtnRCONAll.Size = new System.Drawing.Size(23, 22);
            this.toolBtnRCONAll.ToolTipText = "Send RCON command to all servers";
            this.toolBtnRCONAll.Click += new System.EventHandler(this.toolBtnRCONAll_Click);
            // 
            // toolBtnScoreToggle
            // 
            this.toolBtnScoreToggle.CheckOnClick = true;
            this.toolBtnScoreToggle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolBtnScoreToggle.Image = global::ArgoServerQuery.Properties.Resources.trophy;
            this.toolBtnScoreToggle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolBtnScoreToggle.Name = "toolBtnScoreToggle";
            this.toolBtnScoreToggle.Size = new System.Drawing.Size(23, 22);
            this.toolBtnScoreToggle.ToolTipText = "Toggle score updates on/off";
            this.toolBtnScoreToggle.Click += new System.EventHandler(this.toolBtnScoreToggle_Click);
            // 
            // comboCmd
            // 
            this.comboCmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboCmd.ContextMenuStrip = this.contextMenuCmd;
            this.comboCmd.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCmd.FormattingEnabled = true;
            this.comboCmd.Location = new System.Drawing.Point(0, 420);
            this.comboCmd.Name = "comboCmd";
            this.comboCmd.Size = new System.Drawing.Size(759, 23);
            this.comboCmd.TabIndex = 22;
            this.comboCmd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboCmd_KeyDown);
            // 
            // contextMenuCmd
            // 
            this.contextMenuCmd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCmdMenuItem,
            this.pasteCmdMenuItem,
            this.toolStripSeparatorCmd,
            this.selectAllCmdMenuItem,
            this.toolStripSeparatorCmd2,
            this.commonCmdMenuItem,
            this.changelevelCmdMenuItem,
            this.toolStripSeparatorCmd3,
            this.clearCmdMenuItem});
            this.contextMenuCmd.Name = "contextMenuCmd";
            this.contextMenuCmd.Size = new System.Drawing.Size(191, 154);
            // 
            // copyCmdMenuItem
            // 
            this.copyCmdMenuItem.Name = "copyCmdMenuItem";
            this.copyCmdMenuItem.Size = new System.Drawing.Size(190, 22);
            this.copyCmdMenuItem.Text = "Copy";
            this.copyCmdMenuItem.Click += new System.EventHandler(this.copyCmdMenuItem_Click);
            // 
            // pasteCmdMenuItem
            // 
            this.pasteCmdMenuItem.Name = "pasteCmdMenuItem";
            this.pasteCmdMenuItem.Size = new System.Drawing.Size(190, 22);
            this.pasteCmdMenuItem.Text = "Paste";
            this.pasteCmdMenuItem.Click += new System.EventHandler(this.pasteCmdMenuItem_Click);
            // 
            // toolStripSeparatorCmd
            // 
            this.toolStripSeparatorCmd.Name = "toolStripSeparatorCmd";
            this.toolStripSeparatorCmd.Size = new System.Drawing.Size(187, 6);
            // 
            // selectAllCmdMenuItem
            // 
            this.selectAllCmdMenuItem.Name = "selectAllCmdMenuItem";
            this.selectAllCmdMenuItem.Size = new System.Drawing.Size(190, 22);
            this.selectAllCmdMenuItem.Text = "Select All";
            this.selectAllCmdMenuItem.Click += new System.EventHandler(this.selectAllCmdMenuItem_Click);
            // 
            // toolStripSeparatorCmd2
            // 
            this.toolStripSeparatorCmd2.Name = "toolStripSeparatorCmd2";
            this.toolStripSeparatorCmd2.Size = new System.Drawing.Size(187, 6);
            // 
            // commonCmdMenuItem
            // 
            this.commonCmdMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getpugscoreMenuItem,
            this.hostPlayersMenuItem,
            this.hostWkshpMenuItem,
            this.kickMenuItem,
            this.smAddBanMenuItem,
            this.smBanIPMenuItem,
            this.smPluginsMenuItem,
            this.smUnbanMenuItem,
            this.statusMenuItem});
            this.commonCmdMenuItem.Name = "commonCmdMenuItem";
            this.commonCmdMenuItem.Size = new System.Drawing.Size(190, 22);
            this.commonCmdMenuItem.Text = "Common Commands";
            // 
            // getpugscoreMenuItem
            // 
            this.getpugscoreMenuItem.Name = "getpugscoreMenuItem";
            this.getpugscoreMenuItem.Size = new System.Drawing.Size(186, 22);
            this.getpugscoreMenuItem.Text = "getpugscore";
            this.getpugscoreMenuItem.Click += new System.EventHandler(this.commonCommands_Click);
            // 
            // hostPlayersMenuItem
            // 
            this.hostPlayersMenuItem.Name = "hostPlayersMenuItem";
            this.hostPlayersMenuItem.Size = new System.Drawing.Size(186, 22);
            this.hostPlayersMenuItem.Text = "host_players_show ";
            this.hostPlayersMenuItem.Click += new System.EventHandler(this.commonCommands_Click);
            // 
            // hostWkshpMenuItem
            // 
            this.hostWkshpMenuItem.Name = "hostWkshpMenuItem";
            this.hostWkshpMenuItem.Size = new System.Drawing.Size(186, 22);
            this.hostWkshpMenuItem.Text = "host_workshop_map ";
            this.hostWkshpMenuItem.Click += new System.EventHandler(this.commonCommands_Click);
            // 
            // kickMenuItem
            // 
            this.kickMenuItem.Name = "kickMenuItem";
            this.kickMenuItem.Size = new System.Drawing.Size(186, 22);
            this.kickMenuItem.Text = "kick";
            this.kickMenuItem.Click += new System.EventHandler(this.commonCommands_Click);
            // 
            // smAddBanMenuItem
            // 
            this.smAddBanMenuItem.Name = "smAddBanMenuItem";
            this.smAddBanMenuItem.Size = new System.Drawing.Size(186, 22);
            this.smAddBanMenuItem.Text = "sm_addban ";
            this.smAddBanMenuItem.Click += new System.EventHandler(this.commonCommands_Click);
            // 
            // smBanIPMenuItem
            // 
            this.smBanIPMenuItem.Name = "smBanIPMenuItem";
            this.smBanIPMenuItem.Size = new System.Drawing.Size(186, 22);
            this.smBanIPMenuItem.Text = "sm_banip ";
            this.smBanIPMenuItem.Click += new System.EventHandler(this.commonCommands_Click);
            // 
            // smPluginsMenuItem
            // 
            this.smPluginsMenuItem.Name = "smPluginsMenuItem";
            this.smPluginsMenuItem.Size = new System.Drawing.Size(186, 22);
            this.smPluginsMenuItem.Text = "sm plugins list";
            this.smPluginsMenuItem.Click += new System.EventHandler(this.commonCommands_Click);
            // 
            // smUnbanMenuItem
            // 
            this.smUnbanMenuItem.Name = "smUnbanMenuItem";
            this.smUnbanMenuItem.Size = new System.Drawing.Size(186, 22);
            this.smUnbanMenuItem.Text = "sm_unban ";
            this.smUnbanMenuItem.Click += new System.EventHandler(this.commonCommands_Click);
            // 
            // statusMenuItem
            // 
            this.statusMenuItem.Name = "statusMenuItem";
            this.statusMenuItem.Size = new System.Drawing.Size(186, 22);
            this.statusMenuItem.Text = "status";
            this.statusMenuItem.Click += new System.EventHandler(this.commonCommands_Click);
            // 
            // changelevelCmdMenuItem
            // 
            this.changelevelCmdMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.de_cacheMenuItem,
            this.de_canalsMenuItem,
            this.de_cbbleMenuItem,
            this.de_dust2MenuItem,
            this.de_infernoMenuItem,
            this.de_mirageMenuItem,
            this.de_nukeMenuItem,
            this.de_overpassMenuItem,
            this.de_santoriniMenuItem,
            this.de_seasonMenuItem,
            this.de_trainMenuItem});
            this.changelevelCmdMenuItem.Name = "changelevelCmdMenuItem";
            this.changelevelCmdMenuItem.Size = new System.Drawing.Size(190, 22);
            this.changelevelCmdMenuItem.Text = "changelevel";
            // 
            // de_cacheMenuItem
            // 
            this.de_cacheMenuItem.Name = "de_cacheMenuItem";
            this.de_cacheMenuItem.Size = new System.Drawing.Size(138, 22);
            this.de_cacheMenuItem.Text = "de_cache";
            this.de_cacheMenuItem.Click += new System.EventHandler(this.changelevel_Click);
            // 
            // de_canalsMenuItem
            // 
            this.de_canalsMenuItem.Name = "de_canalsMenuItem";
            this.de_canalsMenuItem.Size = new System.Drawing.Size(138, 22);
            this.de_canalsMenuItem.Text = "de_canals";
            this.de_canalsMenuItem.Click += new System.EventHandler(this.changelevel_Click);
            // 
            // de_cbbleMenuItem
            // 
            this.de_cbbleMenuItem.Name = "de_cbbleMenuItem";
            this.de_cbbleMenuItem.Size = new System.Drawing.Size(138, 22);
            this.de_cbbleMenuItem.Text = "de_cbble";
            this.de_cbbleMenuItem.Click += new System.EventHandler(this.changelevel_Click);
            // 
            // de_dust2MenuItem
            // 
            this.de_dust2MenuItem.Name = "de_dust2MenuItem";
            this.de_dust2MenuItem.Size = new System.Drawing.Size(138, 22);
            this.de_dust2MenuItem.Text = "de_dust2";
            this.de_dust2MenuItem.Click += new System.EventHandler(this.changelevel_Click);
            // 
            // de_infernoMenuItem
            // 
            this.de_infernoMenuItem.Name = "de_infernoMenuItem";
            this.de_infernoMenuItem.Size = new System.Drawing.Size(138, 22);
            this.de_infernoMenuItem.Text = "de_inferno";
            this.de_infernoMenuItem.Click += new System.EventHandler(this.changelevel_Click);
            // 
            // de_mirageMenuItem
            // 
            this.de_mirageMenuItem.Name = "de_mirageMenuItem";
            this.de_mirageMenuItem.Size = new System.Drawing.Size(138, 22);
            this.de_mirageMenuItem.Text = "de_mirage";
            this.de_mirageMenuItem.Click += new System.EventHandler(this.changelevel_Click);
            // 
            // de_nukeMenuItem
            // 
            this.de_nukeMenuItem.Name = "de_nukeMenuItem";
            this.de_nukeMenuItem.Size = new System.Drawing.Size(138, 22);
            this.de_nukeMenuItem.Text = "de_nuke";
            this.de_nukeMenuItem.Click += new System.EventHandler(this.changelevel_Click);
            // 
            // de_overpassMenuItem
            // 
            this.de_overpassMenuItem.Name = "de_overpassMenuItem";
            this.de_overpassMenuItem.Size = new System.Drawing.Size(138, 22);
            this.de_overpassMenuItem.Text = "de_overpass";
            this.de_overpassMenuItem.Click += new System.EventHandler(this.changelevel_Click);
            // 
            // de_santoriniMenuItem
            // 
            this.de_santoriniMenuItem.Name = "de_santoriniMenuItem";
            this.de_santoriniMenuItem.Size = new System.Drawing.Size(138, 22);
            this.de_santoriniMenuItem.Text = "de_santorini";
            this.de_santoriniMenuItem.Click += new System.EventHandler(this.changelevel_Click);
            // 
            // de_seasonMenuItem
            // 
            this.de_seasonMenuItem.Name = "de_seasonMenuItem";
            this.de_seasonMenuItem.Size = new System.Drawing.Size(138, 22);
            this.de_seasonMenuItem.Text = "de_season";
            this.de_seasonMenuItem.Click += new System.EventHandler(this.changelevel_Click);
            // 
            // de_trainMenuItem
            // 
            this.de_trainMenuItem.Name = "de_trainMenuItem";
            this.de_trainMenuItem.Size = new System.Drawing.Size(138, 22);
            this.de_trainMenuItem.Text = "de_train";
            this.de_trainMenuItem.Click += new System.EventHandler(this.changelevel_Click);
            // 
            // toolStripSeparatorCmd3
            // 
            this.toolStripSeparatorCmd3.Name = "toolStripSeparatorCmd3";
            this.toolStripSeparatorCmd3.Size = new System.Drawing.Size(187, 6);
            // 
            // clearCmdMenuItem
            // 
            this.clearCmdMenuItem.Name = "clearCmdMenuItem";
            this.clearCmdMenuItem.Size = new System.Drawing.Size(190, 22);
            this.clearCmdMenuItem.Text = "Clear CMD History";
            this.clearCmdMenuItem.Click += new System.EventHandler(this.clearCmdMenuItem_Click);
            // 
            // lblRegion
            // 
            this.lblRegion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRegion.AutoSize = true;
            this.lblRegion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegion.ForeColor = System.Drawing.SystemColors.Control;
            this.lblRegion.Location = new System.Drawing.Point(955, 35);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(49, 17);
            this.lblRegion.TabIndex = 24;
            this.lblRegion.Text = "Region";
            // 
            // lblTS3
            // 
            this.lblTS3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTS3.AutoSize = true;
            this.lblTS3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTS3.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTS3.Location = new System.Drawing.Point(1102, 35);
            this.lblTS3.Name = "lblTS3";
            this.lblTS3.Size = new System.Drawing.Size(29, 17);
            this.lblTS3.TabIndex = 25;
            this.lblTS3.Text = "TS3";
            // 
            // customTabControl
            // 
            this.customTabControl.Controls.Add(this.tabConsole);
            this.customTabControl.Controls.Add(this.tabChat);
            this.customTabControl.DisplayStyle = System.Windows.Forms.TabStyle.Rounded;
            // 
            // 
            // 
            this.customTabControl.DisplayStyleProvider.BorderColor = System.Drawing.Color.Transparent;
            this.customTabControl.DisplayStyleProvider.BorderColorHot = System.Drawing.Color.Transparent;
            this.customTabControl.DisplayStyleProvider.BorderColorSelected = System.Drawing.Color.Transparent;
            this.customTabControl.DisplayStyleProvider.CloserColor = System.Drawing.Color.DarkGray;
            this.customTabControl.DisplayStyleProvider.FocusTrack = false;
            this.customTabControl.DisplayStyleProvider.HotTrack = true;
            this.customTabControl.DisplayStyleProvider.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.customTabControl.DisplayStyleProvider.Opacity = 1F;
            this.customTabControl.DisplayStyleProvider.Overlap = 0;
            this.customTabControl.DisplayStyleProvider.Padding = new System.Drawing.Point(6, 3);
            this.customTabControl.DisplayStyleProvider.Radius = 10;
            this.customTabControl.DisplayStyleProvider.ShowTabCloser = false;
            this.customTabControl.DisplayStyleProvider.TextColor = System.Drawing.SystemColors.ControlText;
            this.customTabControl.DisplayStyleProvider.TextColorDisabled = System.Drawing.SystemColors.ControlDark;
            this.customTabControl.DisplayStyleProvider.TextColorSelected = System.Drawing.SystemColors.ControlText;
            this.customTabControl.HotTrack = true;
            this.customTabControl.Location = new System.Drawing.Point(12, 385);
            this.customTabControl.Name = "customTabControl";
            this.customTabControl.SelectedIndex = 0;
            this.customTabControl.Size = new System.Drawing.Size(873, 473);
            this.customTabControl.TabIndex = 27;
            // 
            // tabConsole
            // 
            this.tabConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabConsole.Controls.Add(this.txtOutput);
            this.tabConsole.Controls.Add(this.btnSend);
            this.tabConsole.Controls.Add(this.comboCmd);
            this.tabConsole.Controls.Add(this.toolsGroupBox);
            this.tabConsole.Location = new System.Drawing.Point(4, 23);
            this.tabConsole.Name = "tabConsole";
            this.tabConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsole.Size = new System.Drawing.Size(865, 446);
            this.tabConsole.TabIndex = 0;
            this.tabConsole.Text = "Console";
            // 
            // tabChat
            // 
            this.tabChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tabChat.Controls.Add(this.chkChatLog);
            this.tabChat.Controls.Add(this.btnSendChat);
            this.tabChat.Controls.Add(this.txtSendChat);
            this.tabChat.Controls.Add(this.txtChat);
            this.tabChat.Location = new System.Drawing.Point(4, 23);
            this.tabChat.Name = "tabChat";
            this.tabChat.Padding = new System.Windows.Forms.Padding(3);
            this.tabChat.Size = new System.Drawing.Size(865, 446);
            this.tabChat.TabIndex = 1;
            this.tabChat.Text = "Chat";
            // 
            // chkChatLog
            // 
            this.chkChatLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkChatLog.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkChatLog.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkChatLog.ForeColor = System.Drawing.Color.Green;
            this.chkChatLog.Location = new System.Drawing.Point(667, 414);
            this.chkChatLog.Name = "chkChatLog";
            this.chkChatLog.Size = new System.Drawing.Size(94, 32);
            this.chkChatLog.TabIndex = 3;
            this.chkChatLog.Text = "START";
            this.chkChatLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkChatLog.UseVisualStyleBackColor = true;
            this.chkChatLog.CheckedChanged += new System.EventHandler(this.chkChatLog_CheckedChanged);
            // 
            // btnSendChat
            // 
            this.btnSendChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendChat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendChat.Location = new System.Drawing.Point(765, 414);
            this.btnSendChat.Name = "btnSendChat";
            this.btnSendChat.Size = new System.Drawing.Size(94, 32);
            this.btnSendChat.TabIndex = 2;
            this.btnSendChat.Text = "SEND";
            this.btnSendChat.UseVisualStyleBackColor = true;
            // 
            // txtSendChat
            // 
            this.txtSendChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSendChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSendChat.Location = new System.Drawing.Point(0, 420);
            this.txtSendChat.Name = "txtSendChat";
            this.txtSendChat.Size = new System.Drawing.Size(661, 22);
            this.txtSendChat.TabIndex = 1;
            // 
            // txtChat
            // 
            this.txtChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtChat.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChat.Location = new System.Drawing.Point(0, 0);
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtChat.Size = new System.Drawing.Size(865, 413);
            this.txtChat.TabIndex = 0;
            this.txtChat.Text = "";
            this.txtChat.TextChanged += new System.EventHandler(this.txtChat_TextChanged);
            // 
            // optPanel
            // 
            this.optPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.optPanel.Controls.Add(this.lblOptions);
            this.optPanel.Controls.Add(this.btnClearOutput);
            this.optPanel.Controls.Add(this.btnRestartServer);
            this.optPanel.Controls.Add(this.btnSendStatus);
            this.optPanel.Controls.Add(this.btnUpdatePlayers);
            this.optPanel.Location = new System.Drawing.Point(903, 496);
            this.optPanel.Name = "optPanel";
            this.optPanel.Size = new System.Drawing.Size(469, 59);
            this.optPanel.TabIndex = 28;
            // 
            // lblOptions
            // 
            this.lblOptions.AutoSize = true;
            this.lblOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptions.ForeColor = System.Drawing.SystemColors.Control;
            this.lblOptions.Location = new System.Drawing.Point(10, 1);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new System.Drawing.Size(49, 15);
            this.lblOptions.TabIndex = 3;
            this.lblOptions.Text = "Options";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1384, 887);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.optPanel);
            this.Controls.Add(this.customTabControl);
            this.Controls.Add(this.comboTS3);
            this.Controls.Add(this.lblTS3);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.comboRegion);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lvMainView);
            this.Controls.Add(this.lblErrors);
            this.Controls.Add(this.chkTS3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnNewServerList);
            this.Controls.Add(this.comboServerList);
            this.Controls.Add(this.lblServerList);
            this.Controls.Add(this.playersListView);
            this.Controls.Add(this.rconGroupBox);
            this.Controls.Add(this.mnuMainStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMainStrip;
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.contextMenuServer.ResumeLayout(false);
            this.rconGroupBox.ResumeLayout(false);
            this.rconGroupBox.PerformLayout();
            this.contextMenuTxtOutput.ResumeLayout(false);
            this.contextMenuPlayers.ResumeLayout(false);
            this.mnuMainStrip.ResumeLayout(false);
            this.mnuMainStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuCmd.ResumeLayout(false);
            this.customTabControl.ResumeLayout(false);
            this.tabConsole.ResumeLayout(false);
            this.tabChat.ResumeLayout(false);
            this.tabChat.PerformLayout();
            this.optPanel.ResumeLayout(false);
            this.optPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.ColumnHeader colNum;
        private System.Windows.Forms.ColumnHeader colAddr;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colMap;
        private System.Windows.Forms.ColumnHeader colInfo;
        private System.Windows.Forms.ColumnHeader colPlayers;
        private System.Windows.Forms.ColumnHeader colVersion;
        private System.Windows.Forms.ColumnHeader colPing;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ContextMenuStrip contextMenuServer;
        private System.Windows.Forms.ColumnHeader colScore;
        private System.Windows.Forms.TextBox txtRconPW;
        private System.Windows.Forms.GroupBox rconGroupBox;
        private System.Windows.Forms.GroupBox toolsGroupBox;
        private System.Windows.Forms.Button btnClearOutput;
        private System.Windows.Forms.Button btnSendStatus;
        private System.Windows.Forms.Button btnRestartServer;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.ToolStripMenuItem addInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem delServerToolStripMenuItem;
        private System.Windows.Forms.ListView playersListView;
        private System.Windows.Forms.Button btnUpdatePlayers;
        private System.Windows.Forms.ColumnHeader plvColPlayers;
        private System.Windows.Forms.ColumnHeader plvColKills;
        private System.Windows.Forms.ColumnHeader plvColDeaths;
        private System.Windows.Forms.ContextMenuStrip contextMenuPlayers;
        private System.Windows.Forms.ToolStripMenuItem banPlayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem banServersTSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kickPlayerToolStripMenuItem;
        private System.Windows.Forms.Label lblServerList;
        private System.Windows.Forms.ComboBox comboServerList;
        private System.Windows.Forms.Button btnNewServerList;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuServers;
        private System.Windows.Forms.ToolStripMenuItem mnuServersAdd;
        private System.Windows.Forms.MenuStrip mnuMainStrip;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolBtnDeleteList;
        private System.Windows.Forms.ToolStripButton toolBtnRCONAll;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkTS3;
        private System.Windows.Forms.Button btnRconSave;
        private System.Windows.Forms.Label lblRconSaved;
        private System.Windows.Forms.CheckBox chkRconShow;
        private System.Windows.Forms.Label lblErrors;
        private TsMenu tsMenu;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ColumnHeader colGetScoreToggle;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripButton toolBtnAddServer;
        private System.Windows.Forms.ComboBox comboCmd;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ComboBox comboRegion;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Label lblTS3;
        private System.Windows.Forms.ComboBox comboTS3;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuToolsChat;
        private BufferedListView lvMainView;
        private System.Windows.Forms.ToolStripMenuItem mnuServersAddAll;
        private System.Windows.Forms.ToolStripMenuItem copyAddrToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyMapToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuCmd;
        private System.Windows.Forms.ToolStripMenuItem commonCmdMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getpugscoreMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hostPlayersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hostWkshpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kickMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smAddBanMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smBanIPMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smPluginsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smUnbanMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changelevelCmdMenuItem;
        private System.Windows.Forms.ToolStripMenuItem de_cacheMenuItem;
        private System.Windows.Forms.ToolStripMenuItem de_canalsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem de_cbbleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem de_dust2MenuItem;
        private System.Windows.Forms.ToolStripMenuItem de_infernoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem de_mirageMenuItem;
        private System.Windows.Forms.ToolStripMenuItem de_nukeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem de_overpassMenuItem;
        private System.Windows.Forms.ToolStripMenuItem de_santoriniMenuItem;
        private System.Windows.Forms.ToolStripMenuItem de_seasonMenuItem;
        private System.Windows.Forms.ToolStripMenuItem de_trainMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyCmdMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteCmdMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorCmd;
        private System.Windows.Forms.ToolStripMenuItem selectAllCmdMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorCmd2;
        private System.Windows.Forms.ToolStripMenuItem mnuRconAll;
        private System.Windows.Forms.ToolStripMenuItem copyPlayerMenuItem;
        private System.Windows.Forms.ToolStripSeparator mnuPlayerListSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparatorCmd3;
        private System.Windows.Forms.ToolStripMenuItem clearCmdMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySteamIDPlayerMenuItem;
        private System.Windows.Forms.ToolStripSeparator fileStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem serverListLocationToolStripMenuItem;
        public System.Windows.Forms.ToolStripButton toolBtnScoreToggle;
        private System.Windows.Forms.ToolStripMenuItem viewProfileBrowser;
        private System.Windows.Forms.ToolStripMenuItem copyPlayerIpMenuItem;
        private System.Windows.Forms.CustomTabControl customTabControl;
        private System.Windows.Forms.TabPage tabConsole;
        private System.Windows.Forms.TabPage tabChat;
        private System.Windows.Forms.ContextMenuStrip contextMenuTxtOutput;
        private System.Windows.Forms.ToolStripMenuItem menuItemCopyTxtOutput;
        private System.Windows.Forms.TextBox txtSendChat;
        private System.Windows.Forms.RichTextBox txtChat;
        private System.Windows.Forms.Button btnSendChat;
        private System.Windows.Forms.CheckBox chkChatLog;
        private System.Windows.Forms.Panel optPanel;
        private System.Windows.Forms.Label lblOptions;
    }
}

