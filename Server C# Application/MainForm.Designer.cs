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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 234);
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
    }
}

