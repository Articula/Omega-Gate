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

        /*Default connection values*/
        private string m_previousDbAddress = "localhost";
        private string m_previousDbName = "";
        private string m_previousDbUsername = "";
        private string m_previousDbPassword = "";


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
            this.m_previousDbAddress = address;
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
            this.m_previousDbName = name;
            this.txtDbName.Text = name; 
        }

        public void SetDbUsername(string username)
        {
            this.m_previousDbUsername = username;
            this.txtUsername.Text = username;
        }

        public void SetDbPassword(string password)
        {
            this.m_previousDbPassword = password;
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.btnEdit.Visible = false;
            this.btnOk.Visible = true;
            this.btnCancel.Visible = true;

            this.chkLocalHost.Enabled = true;
            if(!this.chkLocalHost.Checked)
            {
                this.txtAddress.Enabled = true;
            }
            this.txtUsername.Enabled = true;
            this.txtPassword.Enabled = true;
            this.txtDbName.Enabled = true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            /*TODO: Data validation check on server address if applicable
            * Check entered data against what is currently stored as the current entries
            * Update MainForm variables accordingly
            * Send changed fields up to OmegaSystem for processing*/

            //IsTextAValidIPAddress();

            this.DisableDatabaseFields();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.m_previousDbAddress == "127.0.0.1" || this.m_previousDbAddress == "localhost")
            {
                this.chkLocalHost.Checked = true;
            }
            else
            {
                this.txtAddress.Text = this.m_previousDbAddress;
            }

            this.txtDbName.Text = this.m_previousDbName;
            this.txtUsername.Text = this.m_previousDbUsername;
            this.txtPassword.Text = this.m_previousDbPassword;

            this.DisableDatabaseFields();
        }

        private void DisableDatabaseFields()
        {
            this.chkLocalHost.Enabled = false;
            this.txtAddress.Enabled = false;
            this.txtUsername.Enabled = false;
            this.txtPassword.Enabled = false;
            this.txtDbName.Enabled = false;

            this.btnOk.Visible = false;
            this.btnCancel.Visible = false;
            this.btnEdit.Visible = true;
        }

        private bool IsTextAValidIPAddress(string text)
        {
            bool result = true;
            if (text != "")
            {
                string[] values = text.Split(new[] { "." }, StringSplitOptions.None);
                result &= values.Length == 4; // String has to contain 4 octets
                Byte byteValue;
                if (result)
                    for (int i = 0; i < 4; i++)
                        result &= byte.TryParse(values[i], out byteValue); //Each octet must be a byte (0-255)
            }
            return result;
        }
    }
}
