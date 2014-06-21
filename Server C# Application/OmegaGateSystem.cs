using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace SpaceStrategySystem
{
    public enum UpdateFrequency
    {
        QuarterHour = 1,
        HalfHour = 2,
        Hourly = 3,
        FourHours = 4,
        Daily = 5
    };

    class OmegaGateSystem
    {
        public const string QUARTER_HOUR = "15 Mins";
        public const string HALF_HOUR = "30 Mins";
        public const string HOURLY = "1 Hour";
        public const string FOUR_HOURS = "4 Hours";
        public const string DAILY = "1 Day";
        public const int ONE_MINUTE = 60000;

        private XmlInterface m_xmlInterface = new XmlInterface();
        private Database m_database = new Database();
        private MainForm m_mainForm = new MainForm();

        /*Default settings in case of XML read errors
         *DateTime of now, Frequency of hourly*/
        private DateTime m_lastUpdate = DateTime.Now;
        private UpdateFrequency m_frequency = UpdateFrequency.Hourly;
        private DateTime m_nextUpdate;
        private System.Timers.Timer m_timer;
        private Dictionary<UpdateFrequency, string> m_frequencyStrings = new Dictionary<UpdateFrequency, string>();
        private Dictionary<string, UpdateFrequency> m_frequencyEnums = new Dictionary<string, UpdateFrequency>();

        public OmegaGateSystem()
        {
            this.AddHandlerEvents();
            this.PopulateFrequencyStrings();
            this.m_xmlInterface.ReadXML();
            this.CalculateNextUpdate();

            //Temporary test
            this.m_database.DBConnectionTest();

            //Create Timer, lasting 60 seconds
            this.m_timer = new System.Timers.Timer(ONE_MINUTE);
            this.m_timer.AutoReset = false;
            this.m_timer.Elapsed += new ElapsedEventHandler(this.RunCheck);
            this.m_timer.Enabled = true;

            this.m_mainForm.Show();
        }

        private void AddHandlerEvents()
        {
            this.m_xmlInterface.PassLastUpdate += new PassLastUpdateHandler(this.UpdateLastUpdateTime);
            this.m_xmlInterface.PassFrequency += new PassFrequencyHandler(this.UpdateTickFrequency);
            this.m_xmlInterface.PassDbAddress += new PassDbAddressHandler(this.PassDbAddress);
            this.m_xmlInterface.PassDbName += new PassDbNameHandler(this.PassDbName);
            this.m_xmlInterface.PassDbUsername += new PassDbUsernameHandler(this.PassDbUsername);
            this.m_xmlInterface.PassDbPassword += new PassDbPasswordHandler(this.PassDbPassword);
            this.m_mainForm.PassFrequencyUpdate += new PassFrequencyUpdateHandler(this.UpdateTickFrequency);
            this.m_mainForm.UpdateDbName += new UpdateDbNameHandler(this.UpdateDbName);
            this.m_mainForm.UpdateUsername += new UpdateDbUsernameHandler(this.UpdateDbUsername);
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

        private void UpdateLastUpdateTime(DateTime dateValue)
        {
            this.m_lastUpdate = dateValue;
        }

        private void UpdateTickFrequency(UpdateFrequency frequency)
        {
            this.m_frequency = frequency;
            this.m_mainForm.SetFrequencyCombo(this.m_frequencyStrings[this.m_frequency]);
        }

        private void UpdateTickFrequency(string frequency)
        {
            this.m_frequency = this.m_frequencyEnums[frequency];
            this.m_xmlInterface.CommitFrequencyUpdate(Convert.ToInt32(this.m_frequency));
        }

        private void PassDbAddress(string dbAddress)
        {
            this.m_database.SetDbAddress(dbAddress);
            this.m_mainForm.SetDbAddress(dbAddress);
        }

        private void PassDbName(string dbName)
        {
            this.m_database.SetDbName(dbName);
            this.m_mainForm.SetDbName(dbName);
        }

        private void UpdateDbName(string dbName)
        {
            this.m_database.SetDbName(dbName);
            this.m_xmlInterface.CommitDbNameUpdate(dbName);
        }

        private void PassDbUsername(string dbUsername)
        {
            this.m_database.SetDbUsername(dbUsername);
            this.m_mainForm.SetDbUsername(dbUsername);
        }

        private void UpdateDbUsername(string username)
        {
            this.m_database.SetDbUsername(username);
            this.m_xmlInterface.CommitDbUsernameUpdate(username);
        }

        private void PassDbPassword(string dbPassword)
        {
            this.m_database.SetDbPassword(dbPassword);
            this.m_mainForm.SetDbPassword(dbPassword);
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

        private void RunCheck(object source, ElapsedEventArgs e)
        {
            if (this.m_nextUpdate < DateTime.Now)
            {
                this.UpdateSystem();
            }
            this.m_timer.Enabled = true;
        }

        private void UpdateSystem()
        {
            /* TODO: Expand on the below? Due to the minute wait of the timer the below will gradually make the tick time slide*/
            this.m_lastUpdate = DateTime.Now;
            this.CalculateNextUpdate();

            /* TODO: 
             * Connect to database
             * Action long list of database updates
             * Close connection to database*/

            this.m_xmlInterface.CommitLastUpdate(this.m_lastUpdate);
        }
    }
}
