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

    }
}
