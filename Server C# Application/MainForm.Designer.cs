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
            this.grpDatabase = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTick
            // 
            this.lblTick.AutoSize = true;
            this.lblTick.Location = new System.Drawing.Point(12, 16);
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
            this.cmbTickFrequency.Location = new System.Drawing.Point(15, 32);
            this.cmbTickFrequency.Name = "cmbTickFrequency";
            this.cmbTickFrequency.Size = new System.Drawing.Size(121, 21);
            this.cmbTickFrequency.TabIndex = 1;
            this.cmbTickFrequency.SelectionChangeCommitted += new System.EventHandler(this.cmbTickFrequency_SelectionChangeCommitted);
            // 
            // chkLocalHost
            // 
            this.chkLocalHost.AutoSize = true;
            this.chkLocalHost.Enabled = false;
            this.chkLocalHost.Location = new System.Drawing.Point(114, 26);
            this.chkLocalHost.Name = "chkLocalHost";
            this.chkLocalHost.Size = new System.Drawing.Size(72, 17);
            this.chkLocalHost.TabIndex = 2;
            this.chkLocalHost.Text = "Localhost";
            this.chkLocalHost.UseVisualStyleBackColor = true;
            this.chkLocalHost.CheckedChanged += new System.EventHandler(this.chkLocalHost_CheckedChanged);
            // 
            // txtAddress
            // 
            this.txtAddress.Enabled = false;
            this.txtAddress.Location = new System.Drawing.Point(207, 23);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(161, 20);
            this.txtAddress.TabIndex = 3;
            // 
            // txtDbName
            // 
            this.txtDbName.Enabled = false;
            this.txtDbName.Location = new System.Drawing.Point(114, 107);
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Size = new System.Drawing.Size(100, 20);
            this.txtDbName.TabIndex = 6;
            // 
            // txtUsername
            // 
            this.txtUsername.Enabled = false;
            this.txtUsername.Location = new System.Drawing.Point(114, 51);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(114, 78);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(6, 26);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(82, 13);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = "Server Address:";
            // 
            // lblDbName
            // 
            this.lblDbName.AutoSize = true;
            this.lblDbName.Location = new System.Drawing.Point(6, 107);
            this.lblDbName.Name = "lblDbName";
            this.lblDbName.Size = new System.Drawing.Size(87, 13);
            this.lblDbName.TabIndex = 8;
            this.lblDbName.Text = "Database Name:";
            // 
            // lblDbUsername
            // 
            this.lblDbUsername.AutoSize = true;
            this.lblDbUsername.Location = new System.Drawing.Point(6, 53);
            this.lblDbUsername.Name = "lblDbUsername";
            this.lblDbUsername.Size = new System.Drawing.Size(107, 13);
            this.lblDbUsername.TabIndex = 9;
            this.lblDbUsername.Text = "Database Username:";
            // 
            // lblDbPassword
            // 
            this.lblDbPassword.AutoSize = true;
            this.lblDbPassword.Location = new System.Drawing.Point(6, 80);
            this.lblDbPassword.Name = "lblDbPassword";
            this.lblDbPassword.Size = new System.Drawing.Size(105, 13);
            this.lblDbPassword.TabIndex = 10;
            this.lblDbPassword.Text = "Database Password:";
            // 
            // grpDatabase
            // 
            this.grpDatabase.Controls.Add(this.btnCancel);
            this.grpDatabase.Controls.Add(this.btnOk);
            this.grpDatabase.Controls.Add(this.btnEdit);
            this.grpDatabase.Controls.Add(this.txtUsername);
            this.grpDatabase.Controls.Add(this.lblDbPassword);
            this.grpDatabase.Controls.Add(this.chkLocalHost);
            this.grpDatabase.Controls.Add(this.lblDbUsername);
            this.grpDatabase.Controls.Add(this.txtAddress);
            this.grpDatabase.Controls.Add(this.lblDbName);
            this.grpDatabase.Controls.Add(this.txtDbName);
            this.grpDatabase.Controls.Add(this.lblAddress);
            this.grpDatabase.Controls.Add(this.txtPassword);
            this.grpDatabase.Location = new System.Drawing.Point(8, 68);
            this.grpDatabase.Name = "grpDatabase";
            this.grpDatabase.Size = new System.Drawing.Size(379, 170);
            this.grpDatabase.TabIndex = 11;
            this.grpDatabase.TabStop = false;
            this.grpDatabase.Text = "Database Details";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(145, 140);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(53, 140);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(238, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 245);
            this.Controls.Add(this.grpDatabase);
            this.Controls.Add(this.cmbTickFrequency);
            this.Controls.Add(this.lblTick);
            this.Name = "MainForm";
            this.Text = "Space Strategy System";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.grpDatabase.ResumeLayout(false);
            this.grpDatabase.PerformLayout();
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
        private System.Windows.Forms.GroupBox grpDatabase;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnEdit;
    }
}

