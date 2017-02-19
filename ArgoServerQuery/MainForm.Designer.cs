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
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtCmd = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.objListView = new BrightIdeasSoftware.ObjectListView();
            this.olvColNum = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColPing = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColAddr = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColMap = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColPlayers = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColVersion = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColScore = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColInfo = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.txtRconPW = new System.Windows.Forms.TextBox();
            this.rconGroupBox = new System.Windows.Forms.GroupBox();
            this.optGroupBox = new System.Windows.Forms.GroupBox();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.btnSendStatus = new System.Windows.Forms.Button();
            this.mnuMainStrip.SuspendLayout();
            this.contextMenuServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objListView)).BeginInit();
            this.rconGroupBox.SuspendLayout();
            this.optGroupBox.SuspendLayout();
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
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            this.mnuServersAdd.Size = new System.Drawing.Size(131, 22);
            this.mnuServersAdd.Text = "Add Server";
            this.mnuServersAdd.Click += new System.EventHandler(this.mnuServersAdd_Click);
            // 
            // lvMainView
            // 
            this.lvMainView.AllowColumnReorder = true;
            this.lvMainView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.lvMainView.FullRowSelect = true;
            this.lvMainView.HideSelection = false;
            this.lvMainView.Location = new System.Drawing.Point(12, 37);
            this.lvMainView.MultiSelect = false;
            this.lvMainView.Name = "lvMainView";
            this.lvMainView.Size = new System.Drawing.Size(1360, 375);
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
            this.propertiesToolStripMenuItem});
            this.contextMenuServer.Name = "contextMenuServer";
            this.contextMenuServer.Size = new System.Drawing.Size(128, 26);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(12, 418);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(873, 359);
            this.txtOutput.TabIndex = 2;
            // 
            // txtCmd
            // 
            this.txtCmd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmd.Location = new System.Drawing.Point(12, 789);
            this.txtCmd.Name = "txtCmd";
            this.txtCmd.Size = new System.Drawing.Size(773, 22);
            this.txtCmd.TabIndex = 3;
            this.txtCmd.WordWrap = false;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(791, 783);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(94, 32);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // objListView
            // 
            this.objListView.AllColumns.Add(this.olvColNum);
            this.objListView.AllColumns.Add(this.olvColStatus);
            this.objListView.AllColumns.Add(this.olvColPing);
            this.objListView.AllColumns.Add(this.olvColAddr);
            this.objListView.AllColumns.Add(this.olvColName);
            this.objListView.AllColumns.Add(this.olvColMap);
            this.objListView.AllColumns.Add(this.olvColPlayers);
            this.objListView.AllColumns.Add(this.olvColVersion);
            this.objListView.AllColumns.Add(this.olvColScore);
            this.objListView.AllColumns.Add(this.olvColInfo);
            this.objListView.CellEditUseWholeCell = false;
            this.objListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColNum,
            this.olvColStatus,
            this.olvColPing,
            this.olvColAddr,
            this.olvColName,
            this.olvColMap,
            this.olvColPlayers,
            this.olvColVersion,
            this.olvColScore,
            this.olvColInfo});
            this.objListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.objListView.Enabled = false;
            this.objListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.objListView.FullRowSelect = true;
            this.objListView.HasCollapsibleGroups = false;
            this.objListView.Location = new System.Drawing.Point(12, 253);
            this.objListView.Name = "objListView";
            this.objListView.ShowGroups = false;
            this.objListView.Size = new System.Drawing.Size(1360, 159);
            this.objListView.TabIndex = 5;
            this.objListView.UseCompatibleStateImageBehavior = false;
            this.objListView.View = System.Windows.Forms.View.Details;
            this.objListView.Visible = false;
            // 
            // olvColNum
            // 
            this.olvColNum.Text = "#";
            this.olvColNum.Width = 28;
            // 
            // olvColStatus
            // 
            this.olvColStatus.Text = "Status";
            this.olvColStatus.Width = 48;
            // 
            // olvColPing
            // 
            this.olvColPing.Text = "Ping";
            this.olvColPing.Width = 50;
            // 
            // olvColAddr
            // 
            this.olvColAddr.Text = "Address";
            this.olvColAddr.Width = 160;
            // 
            // olvColName
            // 
            this.olvColName.Text = "Server Name";
            this.olvColName.Width = 280;
            // 
            // olvColMap
            // 
            this.olvColMap.Text = "Map";
            this.olvColMap.Width = 280;
            // 
            // olvColPlayers
            // 
            this.olvColPlayers.Text = "Players";
            this.olvColPlayers.Width = 100;
            // 
            // olvColVersion
            // 
            this.olvColVersion.Text = "Version";
            this.olvColVersion.Width = 100;
            // 
            // olvColScore
            // 
            this.olvColScore.Text = "Score";
            this.olvColScore.Width = 110;
            // 
            // olvColInfo
            // 
            this.olvColInfo.Text = "Info";
            this.olvColInfo.Width = 200;
            // 
            // txtRconPW
            // 
            this.txtRconPW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRconPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRconPW.Location = new System.Drawing.Point(6, 30);
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
            this.rconGroupBox.Location = new System.Drawing.Point(903, 418);
            this.rconGroupBox.Name = "rconGroupBox";
            this.rconGroupBox.Size = new System.Drawing.Size(448, 97);
            this.rconGroupBox.TabIndex = 7;
            this.rconGroupBox.TabStop = false;
            this.rconGroupBox.Text = "Rcon Password";
            // 
            // optGroupBox
            // 
            this.optGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.optGroupBox.Controls.Add(this.btnSendStatus);
            this.optGroupBox.Controls.Add(this.btnClearOutput);
            this.optGroupBox.Location = new System.Drawing.Point(903, 521);
            this.optGroupBox.Name = "optGroupBox";
            this.optGroupBox.Size = new System.Drawing.Size(448, 100);
            this.optGroupBox.TabIndex = 8;
            this.optGroupBox.TabStop = false;
            this.optGroupBox.Text = "Options";
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearOutput.Location = new System.Drawing.Point(28, 19);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(88, 26);
            this.btnClearOutput.TabIndex = 0;
            this.btnClearOutput.Text = "Clear Output";
            this.btnClearOutput.UseVisualStyleBackColor = true;
            this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
            // 
            // btnSendStatus
            // 
            this.btnSendStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendStatus.Location = new System.Drawing.Point(28, 60);
            this.btnSendStatus.Name = "btnSendStatus";
            this.btnSendStatus.Size = new System.Drawing.Size(88, 26);
            this.btnSendStatus.TabIndex = 1;
            this.btnSendStatus.Text = "Send Status";
            this.btnSendStatus.UseVisualStyleBackColor = true;
            this.btnSendStatus.Click += new System.EventHandler(this.btnSendStatus_Click);
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1384, 861);
            this.Controls.Add(this.optGroupBox);
            this.Controls.Add(this.rconGroupBox);
            this.Controls.Add(this.objListView);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtCmd);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.lvMainView);
            this.Controls.Add(this.mnuMainStrip);
            this.MainMenuStrip = this.mnuMainStrip;
            this.MinimumSize = new System.Drawing.Size(1400, 900);
            this.Name = "MainForm";
            this.Text = "Argo CS:GO Server Query Tool";
            this.mnuMainStrip.ResumeLayout(false);
            this.mnuMainStrip.PerformLayout();
            this.contextMenuServer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objListView)).EndInit();
            this.rconGroupBox.ResumeLayout(false);
            this.rconGroupBox.PerformLayout();
            this.optGroupBox.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtCmd;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ContextMenuStrip contextMenuServer;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader colScore;
        private BrightIdeasSoftware.ObjectListView objListView;
        private BrightIdeasSoftware.OLVColumn olvColStatus;
        private BrightIdeasSoftware.OLVColumn olvColNum;
        private BrightIdeasSoftware.OLVColumn olvColPing;
        private BrightIdeasSoftware.OLVColumn olvColAddr;
        private BrightIdeasSoftware.OLVColumn olvColName;
        private BrightIdeasSoftware.OLVColumn olvColMap;
        private BrightIdeasSoftware.OLVColumn olvColPlayers;
        private BrightIdeasSoftware.OLVColumn olvColVersion;
        private BrightIdeasSoftware.OLVColumn olvColScore;
        private BrightIdeasSoftware.OLVColumn olvColInfo;
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
    }
}

