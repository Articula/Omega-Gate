using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceStrategySystem
{
    public delegate void PassFrequencyUpdateHandler(string frequency);

    public partial class MainForm : Form
    {
        public event PassFrequencyUpdateHandler PassFrequencyUpdate;

        protected virtual void OnPassFrequencyUpdate(string frequency) { PassFrequencyUpdate(frequency); }


        public MainForm()
        {
            InitializeComponent();
        }

        public void SetFrequencyCombo(string value)
        {
            this.cmbTickFrequency.Text = value;
        }

        public void SetDbAddress(string address)
        {
            //TODO: Remove case sensitivity from localhost check.
            if(address == "127.0.0.1" || address == "localhost")
            {
                this.chkLocalHost.Checked = true;
            }
            else
            {
                this.txtAddress.Text = address;
            }  
        }

        public void SetDbName(string name)
        {
            this.txtDbName.Text = name;
        }

        public void SetDbUsername(string username)
        {
            this.txtUsername.Text = username;
        }

        public void SetDbPassword(string password)
        {
            this.txtPassword.Text = password;
        }

        private void cmbTickFrequency_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox) sender;
            this.OnPassFrequencyUpdate(senderComboBox.SelectedItem.ToString());
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*TODO: Insert check to make sure tick is currently not being processed. If it is, application only terminated when processing is complete. */
            Application.Exit();
        }

        private void chkLocalHost_CheckedChanged(object sender, EventArgs e)
        {
            if(this.chkLocalHost.Checked)
            {
                this.txtAddress.Text = "";
                this.txtAddress.Enabled = false;
            }
            else
            {
                this.txtAddress.Enabled = true;
            }
        }

    }
}
