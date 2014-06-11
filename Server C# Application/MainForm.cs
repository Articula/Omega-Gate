using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Timers;

namespace SpaceStrategySystem
{
    public enum XMLFields
    {
        Configuration,
        LastUpdate,
        Frequency,
        DatabaseAddress,
        DatabaseUsername,
        DatabasePassword
    };
    
    public enum UpdateFrequency
    {
        QuarterHour = 1,
        HalfHour = 2,
        Hourly = 3,
        FourHours = 4,
        Daily = 5
    };

    public partial class MainForm : Form
    {
        public const string CONFIG_FILE = "config.xml";

        public const string QUARTER_HOUR = "15 Mins";
        public const string HALF_HOUR = "30 Mins";
        public const string HOURLY = "1 Hour";
        public const string FOUR_HOURS = "4 Hours";
        public const string DAILY = "1 Day";
        
        //Default settings in case of XML read errors
        //DateTime of now, Frequency of hourly
        private DateTime m_lastUpdate = DateTime.Now;
        private UpdateFrequency m_frequency = UpdateFrequency.Hourly;
        private DateTime m_nextUpdate;
        private Dictionary<UpdateFrequency, string> m_frequencyStrings = new Dictionary<UpdateFrequency,string>();
        private Dictionary<string, UpdateFrequency> m_frequencyEnums = new Dictionary<string,UpdateFrequency>();

        //TODO: Database credentials

        public MainForm()
        {
            InitializeComponent();
            PopulateFrequencyStrings();

            //Extract XML values and update attributes
            ReadXML();
            this.SetFrequencyCombo();
            this.CalculateNextUpdate(); 

            //TODO: Create Timer, lasting 60 seconds
            //at timeout

            //this.m_nextUpdate = (DateTime.Now - new TimeSpan(0, 15, 0)); //Testing UpdateSystem()
            RunCheck();
            //Recreate timer (Timer needs to pause while tick processing is occurring)
        }

        private void PopulateFrequencyStrings()
        {
            this.m_frequencyStrings.Add(UpdateFrequency.QuarterHour, QUARTER_HOUR);
            this.m_frequencyStrings.Add(UpdateFrequency.HalfHour, HALF_HOUR);
            this.m_frequencyStrings.Add(UpdateFrequency.Hourly, HOURLY);
            this.m_frequencyStrings.Add(UpdateFrequency.FourHours, FOUR_HOURS);
            this.m_frequencyStrings.Add(UpdateFrequency.Daily, DAILY);

            this.m_frequencyEnums.Add(QUARTER_HOUR, UpdateFrequency.QuarterHour);
            this.m_frequencyEnums.Add(HALF_HOUR, UpdateFrequency.HalfHour);
            this.m_frequencyEnums.Add(HOURLY, UpdateFrequency.Hourly);
            this.m_frequencyEnums.Add(FOUR_HOURS, UpdateFrequency.FourHours);
            this.m_frequencyEnums.Add(DAILY, UpdateFrequency.Daily);
        }

        private void ReadXML()
        {
            /* TODO: First check file exists. If not create a new one.*/

            //Read in XML fields
            XmlTextReader reader = new XmlTextReader(CONFIG_FILE);
            string currentRead;

            reader.ReadToFollowing(XMLFields.LastUpdate.ToString());
            reader.MoveToFirstAttribute();
            currentRead = reader.ReadElementContentAsString();
            if (currentRead != "")
            {
                this.m_lastUpdate = Convert.ToDateTime(currentRead);
            }

            reader.ReadToFollowing(XMLFields.Frequency.ToString());
            reader.MoveToFirstAttribute();
            currentRead = reader.ReadElementContentAsString();
            if (currentRead != "")
            {
                this.m_frequency = (UpdateFrequency)Convert.ToInt32(currentRead);
            }

            reader.Close();
        }

        private void SetFrequencyCombo()
        {
            this.cmbTickFrequency.Text = this.m_frequencyStrings[this.m_frequency];
        }

        private void UpdateFrequencyXML()
        {
            XmlDocument file = new XmlDocument();
            file.Load(CONFIG_FILE);
            XmlNode node = file.SelectSingleNode(XMLFields.Configuration + "/" + XMLFields.Frequency);
            node.InnerText = Convert.ToInt32(this.m_frequency).ToString();
            file.Save(CONFIG_FILE);
        }

        private void CalculateNextUpdate()
        {
            switch (this.m_frequency)
            {
                case UpdateFrequency.QuarterHour:
                    this.m_nextUpdate = this.m_lastUpdate + new TimeSpan(0, 15, 0);
                    break;
                case UpdateFrequency.HalfHour:
                    this.m_nextUpdate = this.m_lastUpdate + new TimeSpan(0, 30, 0);
                    break;
                case UpdateFrequency.Hourly:
                default:
                    this.m_nextUpdate = this.m_lastUpdate + new TimeSpan(1, 0, 0);
                    break;
                case UpdateFrequency.FourHours:
                    this.m_nextUpdate = this.m_lastUpdate + new TimeSpan(4, 0, 0);
                    break;
                case UpdateFrequency.Daily:
                    this.m_nextUpdate = this.m_lastUpdate + new TimeSpan(1, 0, 0, 0);
                    break;
            }
        }

        private void RunCheck()
        {
            if(this.m_nextUpdate < DateTime.Now)
            {
                this.UpdateSystem();
            }
        }

        private void UpdateSystem()
        {
            /* TODO: 
             * Connect to database
             * Action long list of database updates
             * Close connection to database
             */

            this.m_lastUpdate = DateTime.Now;
            this.CalculateNextUpdate();

            //Update last update in XML
            XmlDocument file = new XmlDocument();
            file.Load(CONFIG_FILE);
            XmlNode node = file.SelectSingleNode(XMLFields.Configuration + "/" + XMLFields.LastUpdate);
            node.InnerText = this.m_lastUpdate.ToString();
            file.Save(CONFIG_FILE);
        }

        private void cmbTickFrequency_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox senderComboBox = (ComboBox) sender;

            this.m_frequency = this.m_frequencyEnums[senderComboBox.SelectedItem.ToString()];
            this.SetFrequencyCombo();
            this.UpdateFrequencyXML();
        }
    }
}
