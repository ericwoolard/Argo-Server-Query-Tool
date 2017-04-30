namespace ArgoServerQuery
{
    sealed partial class TsMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picTS = new System.Windows.Forms.PictureBox();
            this.lblTsConfig = new System.Windows.Forms.Label();
            this.lblTsAddress = new System.Windows.Forms.Label();
            this.txtTsAddress = new System.Windows.Forms.TextBox();
            this.lblServerQuery = new System.Windows.Forms.Label();
            this.lblSQUser = new System.Windows.Forms.Label();
            this.txtSQUser = new System.Windows.Forms.TextBox();
            this.lblSQPassword = new System.Windows.Forms.Label();
            this.txtSQPassword = new System.Windows.Forms.TextBox();
            this.lblSQPort = new System.Windows.Forms.Label();
            this.txtSQPort = new System.Windows.Forms.TextBox();
            this.lblDefaultPort = new System.Windows.Forms.Label();
            this.btnTsSave = new System.Windows.Forms.Button();
            this.lblTsSaved = new System.Windows.Forms.Label();
            this.tsToolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picTS)).BeginInit();
            this.SuspendLayout();
            // 
            // picTS
            // 
            this.picTS.Image = global::ArgoServerQuery.Properties.Resources.teamspeak3logo;
            this.picTS.InitialImage = global::ArgoServerQuery.Properties.Resources.teamspeak3logo;
            this.picTS.Location = new System.Drawing.Point(3, 13);
            this.picTS.Name = "picTS";
            this.picTS.Size = new System.Drawing.Size(294, 61);
            this.picTS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTS.TabIndex = 0;
            this.picTS.TabStop = false;
            // 
            // lblTsConfig
            // 
            this.lblTsConfig.AutoSize = true;
            this.lblTsConfig.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTsConfig.Location = new System.Drawing.Point(42, 90);
            this.lblTsConfig.Name = "lblTsConfig";
            this.lblTsConfig.Size = new System.Drawing.Size(217, 21);
            this.lblTsConfig.TabIndex = 1;
            this.lblTsConfig.Text = "TeamSpeak3 Configuration";
            // 
            // lblTsAddress
            // 
            this.lblTsAddress.AutoSize = true;
            this.lblTsAddress.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTsAddress.Location = new System.Drawing.Point(3, 138);
            this.lblTsAddress.Name = "lblTsAddress";
            this.lblTsAddress.Size = new System.Drawing.Size(103, 17);
            this.lblTsAddress.TabIndex = 2;
            this.lblTsAddress.Text = "Server Address:";
            // 
            // txtTsAddress
            // 
            this.txtTsAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTsAddress.Location = new System.Drawing.Point(112, 136);
            this.txtTsAddress.Name = "txtTsAddress";
            this.txtTsAddress.Size = new System.Drawing.Size(185, 22);
            this.txtTsAddress.TabIndex = 3;
            this.tsToolTip.SetToolTip(this.txtTsAddress, "IP or hostname of TS3 server");
            // 
            // lblServerQuery
            // 
            this.lblServerQuery.AutoSize = true;
            this.lblServerQuery.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerQuery.Location = new System.Drawing.Point(91, 176);
            this.lblServerQuery.Name = "lblServerQuery";
            this.lblServerQuery.Size = new System.Drawing.Size(118, 17);
            this.lblServerQuery.TabIndex = 4;
            this.lblServerQuery.Text = "Server Query Info";
            // 
            // lblSQUser
            // 
            this.lblSQUser.AutoSize = true;
            this.lblSQUser.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSQUser.Location = new System.Drawing.Point(29, 218);
            this.lblSQUser.Name = "lblSQUser";
            this.lblSQUser.Size = new System.Drawing.Size(101, 13);
            this.lblSQUser.TabIndex = 5;
            this.lblSQUser.Text = "Server Query User:";
            // 
            // txtSQUser
            // 
            this.txtSQUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSQUser.Location = new System.Drawing.Point(161, 213);
            this.txtSQUser.Name = "txtSQUser";
            this.txtSQUser.Size = new System.Drawing.Size(111, 22);
            this.txtSQUser.TabIndex = 6;
            this.tsToolTip.SetToolTip(this.txtSQUser, "Your server query user");
            // 
            // lblSQPassword
            // 
            this.lblSQPassword.AutoSize = true;
            this.lblSQPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSQPassword.Location = new System.Drawing.Point(29, 265);
            this.lblSQPassword.Name = "lblSQPassword";
            this.lblSQPassword.Size = new System.Drawing.Size(126, 13);
            this.lblSQPassword.TabIndex = 7;
            this.lblSQPassword.Text = "Server Query Password:";
            // 
            // txtSQPassword
            // 
            this.txtSQPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSQPassword.Location = new System.Drawing.Point(161, 260);
            this.txtSQPassword.Name = "txtSQPassword";
            this.txtSQPassword.Size = new System.Drawing.Size(111, 22);
            this.txtSQPassword.TabIndex = 8;
            this.txtSQPassword.UseSystemPasswordChar = true;
            // 
            // lblSQPort
            // 
            this.lblSQPort.AutoSize = true;
            this.lblSQPort.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSQPort.Location = new System.Drawing.Point(29, 312);
            this.lblSQPort.Name = "lblSQPort";
            this.lblSQPort.Size = new System.Drawing.Size(99, 13);
            this.lblSQPort.TabIndex = 9;
            this.lblSQPort.Text = "Server Query Port:";
            // 
            // txtSQPort
            // 
            this.txtSQPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSQPort.Location = new System.Drawing.Point(161, 307);
            this.txtSQPort.Name = "txtSQPort";
            this.txtSQPort.Size = new System.Drawing.Size(111, 22);
            this.txtSQPort.TabIndex = 10;
            this.tsToolTip.SetToolTip(this.txtSQPort, "Server query port");
            // 
            // lblDefaultPort
            // 
            this.lblDefaultPort.AutoSize = true;
            this.lblDefaultPort.Font = new System.Drawing.Font("Segoe UI", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefaultPort.Location = new System.Drawing.Point(157, 332);
            this.lblDefaultPort.Name = "lblDefaultPort";
            this.lblDefaultPort.Size = new System.Drawing.Size(123, 13);
            this.lblDefaultPort.TabIndex = 11;
            this.lblDefaultPort.Text = "Do not use port 10011!";
            // 
            // btnTsSave
            // 
            this.btnTsSave.Location = new System.Drawing.Point(32, 353);
            this.btnTsSave.Name = "btnTsSave";
            this.btnTsSave.Size = new System.Drawing.Size(75, 23);
            this.btnTsSave.TabIndex = 12;
            this.btnTsSave.Text = "Save Config";
            this.tsToolTip.SetToolTip(this.btnTsSave, "Save TS3 config");
            this.btnTsSave.UseVisualStyleBackColor = true;
            this.btnTsSave.Click += new System.EventHandler(this.btnTsSave_Click);
            // 
            // lblTsSaved
            // 
            this.lblTsSaved.AutoSize = true;
            this.lblTsSaved.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTsSaved.Location = new System.Drawing.Point(115, 358);
            this.lblTsSaved.Name = "lblTsSaved";
            this.lblTsSaved.Size = new System.Drawing.Size(80, 13);
            this.lblTsSaved.TabIndex = 13;
            this.lblTsSaved.Text = "✔ Config Saved";
            this.lblTsSaved.Visible = false;
            // 
            // tsToolTip
            // 
            this.tsToolTip.AutomaticDelay = 750;
            // 
            // TsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.lblTsSaved);
            this.Controls.Add(this.btnTsSave);
            this.Controls.Add(this.lblDefaultPort);
            this.Controls.Add(this.txtSQPort);
            this.Controls.Add(this.lblSQPort);
            this.Controls.Add(this.txtSQPassword);
            this.Controls.Add(this.lblSQPassword);
            this.Controls.Add(this.txtSQUser);
            this.Controls.Add(this.lblSQUser);
            this.Controls.Add(this.lblServerQuery);
            this.Controls.Add(this.txtTsAddress);
            this.Controls.Add(this.lblTsAddress);
            this.Controls.Add(this.lblTsConfig);
            this.Controls.Add(this.picTS);
            this.Name = "TsMenu";
            this.Size = new System.Drawing.Size(300, 385);
            ((System.ComponentModel.ISupportInitialize)(this.picTS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picTS;
        private System.Windows.Forms.Label lblTsConfig;
        private System.Windows.Forms.Label lblTsAddress;
        private System.Windows.Forms.TextBox txtTsAddress;
        private System.Windows.Forms.Label lblServerQuery;
        private System.Windows.Forms.Label lblSQUser;
        private System.Windows.Forms.TextBox txtSQUser;
        private System.Windows.Forms.Label lblSQPassword;
        private System.Windows.Forms.TextBox txtSQPassword;
        private System.Windows.Forms.Label lblSQPort;
        private System.Windows.Forms.TextBox txtSQPort;
        private System.Windows.Forms.Label lblDefaultPort;
        private System.Windows.Forms.Button btnTsSave;
        private System.Windows.Forms.Label lblTsSaved;
        private System.Windows.Forms.ToolTip tsToolTip;
    }
}
