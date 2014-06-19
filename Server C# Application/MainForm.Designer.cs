namespace SpaceStrategySystem
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
            this.lblTick = new System.Windows.Forms.Label();
            this.cmbTickFrequency = new System.Windows.Forms.ComboBox();
            this.chkLocalHost = new System.Windows.Forms.CheckBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtDbName = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblDbName = new System.Windows.Forms.Label();
            this.lblDbUsername = new System.Windows.Forms.Label();
            this.lblDbPassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTick
            // 
            this.lblTick.AutoSize = true;
            this.lblTick.Location = new System.Drawing.Point(12, 21);
            this.lblTick.Name = "lblTick";
            this.lblTick.Size = new System.Drawing.Size(84, 13);
            this.lblTick.TabIndex = 0;
            this.lblTick.Text = "Tick Frequency:";
            // 
            // cmbTickFrequency
            // 
            this.cmbTickFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTickFrequency.FormattingEnabled = true;
            this.cmbTickFrequency.Items.AddRange(new object[] {
            "15 Mins",
            "30 Mins",
            "1 Hour",
            "4 Hours",
            "1 Day"});
            this.cmbTickFrequency.Location = new System.Drawing.Point(15, 37);
            this.cmbTickFrequency.Name = "cmbTickFrequency";
            this.cmbTickFrequency.Size = new System.Drawing.Size(121, 21);
            this.cmbTickFrequency.TabIndex = 1;
            this.cmbTickFrequency.SelectionChangeCommitted += new System.EventHandler(this.cmbTickFrequency_SelectionChangeCommitted);
            // 
            // chkLocalHost
            // 
            this.chkLocalHost.AutoSize = true;
            this.chkLocalHost.Location = new System.Drawing.Point(114, 96);
            this.chkLocalHost.Name = "chkLocalHost";
            this.chkLocalHost.Size = new System.Drawing.Size(72, 17);
            this.chkLocalHost.TabIndex = 2;
            this.chkLocalHost.Text = "Localhost";
            this.chkLocalHost.UseVisualStyleBackColor = true;
            this.chkLocalHost.CheckedChanged += new System.EventHandler(this.chkLocalHost_CheckedChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(207, 93);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(161, 20);
            this.txtAddress.TabIndex = 3;
            // 
            // txtDbName
            // 
            this.txtDbName.Location = new System.Drawing.Point(114, 177);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(100, 20);
            this.txtDbName.TabIndex = 4;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(114, 121);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(114, 148);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(6, 96);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(82, 13);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = "Server Address:";
            // 
            // lblDbName
            // 
            this.lblDbName.AutoSize = true;
            this.lblDbName.Location = new System.Drawing.Point(6, 177);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(87, 13);
            this.lblDbName.TabIndex = 8;
            this.lblDbName.Text = "Database Name:";
            // 
            // lblDbUsername
            // 
            this.lblDbUsername.AutoSize = true;
            this.lblDbUsername.Location = new System.Drawing.Point(6, 123);
            this.lblDbUsername.Name = "lblDbUsername";
            this.lblDbUsername.Size = new System.Drawing.Size(107, 13);
            this.lblDbUsername.TabIndex = 9;
            this.lblDbUsername.Text = "Database Username:";
            // 
            // lblDbPassword
            // 
            this.lblDbPassword.AutoSize = true;
            this.lblDbPassword.Location = new System.Drawing.Point(6, 150);
            this.lblDbPassword.Name = "lblDbPassword";
            this.lblDbPassword.Size = new System.Drawing.Size(105, 13);
            this.lblDbPassword.TabIndex = 10;
            this.lblDbPassword.Text = "Database Password:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 234);
            this.Controls.Add(this.lblDbPassword);
            this.Controls.Add(this.lblDbUsername);
            this.Controls.Add(this.lblDbName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtDbName);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.chkLocalHost);
            this.Controls.Add(this.cmbTickFrequency);
            this.Controls.Add(this.lblTick);
            this.Name = "MainForm";
            this.Text = "Space Strategy System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTick;
        private System.Windows.Forms.ComboBox cmbTickFrequency;
        private System.Windows.Forms.CheckBox chkLocalHost;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtDbName;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblDbName;
        private System.Windows.Forms.Label lblDbUsername;
        private System.Windows.Forms.Label lblDbPassword;
    }
}

