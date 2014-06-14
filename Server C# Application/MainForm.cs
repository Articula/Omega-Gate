﻿using System;
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
using System.IO;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

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
        public const string XML_TEMPLATE = "<Configuration><LastUpdate></LastUpdate><Frequency></Frequency><DatabaseAddress></DatabaseAddress><DatabaseUsername></DatabaseUsername><DatabasePassword></DatabasePassword></Configuration>";

        public const string QUARTER_HOUR = "15 Mins";
        public const string HALF_HOUR = "30 Mins";
        public const string HOURLY = "1 Hour";
        public const string FOUR_HOURS = "4 Hours";
        public const string DAILY = "1 Day";

        public const int ONE_MINUTE = 60000;
        
        /*Default settings in case of XML read errors
         *DateTime of now, Frequency of hourly*/
        private DateTime m_lastUpdate = DateTime.Now;
        private UpdateFrequency m_frequency = UpdateFrequency.Hourly;
        private DateTime m_nextUpdate;
        private System.Timers.Timer m_timer;
        private MySqlConnection m_connection;
        private Dictionary<UpdateFrequency, string> m_frequencyStrings = new Dictionary<UpdateFrequency,string>();
        private Dictionary<string, UpdateFrequency> m_frequencyEnums = new Dictionary<string,UpdateFrequency>();

        //TODO: Database credentials

        public MainForm()
        {
            InitializeComponent();
            this.PopulateFrequencyStrings();

            this.DBConnectionTest();

            //Extract XML values and update attributes
            this.ReadXML();
            this.SetFrequencyCombo();
            this.CalculateNextUpdate(); 

            //Create Timer, lasting 60 seconds
            this.m_timer = new System.Timers.Timer(ONE_MINUTE);
            this.m_timer.Elapsed += new ElapsedEventHandler(this.RunCheck);
            this.m_timer.Start();
        }

        private void DBConnectionTest()
        {
            string server = "localhost";
            string database = "connectiontest";
            string uid = "root";
            string password = "password";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            //MySqlConnection connection = new MySqlConnection(connectionString);
            this.m_connection = new MySqlConnection(connectionString);
            //connection.Close();

            if(this.OpenConnection())
            {
                //Select and grab current value
                string selectQuery = "SELECT * FROM testtable";
                List<int> list = new List<int>();
                MySqlCommand selectcmd = new MySqlCommand(selectQuery, this.m_connection);
                MySqlDataReader dataReader = selectcmd.ExecuteReader();
                while (dataReader.Read())
                {
                    list.Add(Convert.ToInt32(dataReader["testint"]));
                }
                dataReader.Close();

                //Update value
                string updateQuery = "UPDATE testtable SET testint=" + (list[0] + 1).ToString();
                MySqlCommand updatecmd = new MySqlCommand();
                updatecmd.CommandText = updateQuery;
                updatecmd.Connection = this.m_connection;
                updatecmd.ExecuteNonQuery();

                this.CloseConnection();
            }
        }

        private bool OpenConnection()
        {
            try
            {
                m_connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                m_connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
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
            if (File.Exists((CONFIG_FILE)))
            {
                //Read in XML fields
                XmlTextReader reader = new XmlTextReader(CONFIG_FILE);
                string currentRead;
                DateTime dateValue;
                int frequencyValue;

                reader.ReadToFollowing(XMLFields.LastUpdate.ToString());
                reader.MoveToFirstAttribute();
                currentRead = reader.ReadElementContentAsString();
                if (DateTime.TryParse(currentRead, out dateValue))
                {
                    this.m_lastUpdate = dateValue;
                }

                reader.ReadToFollowing(XMLFields.Frequency.ToString());
                reader.MoveToFirstAttribute();
                currentRead = reader.ReadElementContentAsString();
                if (int.TryParse(currentRead, out frequencyValue))
                {
                    this.m_frequency = (UpdateFrequency)frequencyValue;
                }

                reader.Close();
            }
            else
            {
                //Config file does not exist! Default values will be used and blank config file created.
                XmlDocument file = new XmlDocument();
                file.LoadXml(XML_TEMPLATE);
                XmlTextWriter writer = new XmlTextWriter(CONFIG_FILE, null);
                writer.Formatting = Formatting.Indented;
                file.Save(writer);
            }
        }

        private void SetFrequencyCombo()
        {
            this.cmbTickFrequency.Text = this.m_frequencyStrings[this.m_frequency];
        }

        private void UpdateFrequencyXML()
        {
            /*TODO: Put in another check for XML file (/generate if not) here*/
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

        private void RunCheck(object source, ElapsedEventArgs e)
        {
            this.BeginInvoke(new MethodInvoker(delegate { RunCheck(); }));
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
            this.m_timer.Stop();

            /* TODO: Expand on the below? Due to the minute wait of the timer the below will gradually make the tick time slide*/
            this.m_lastUpdate = DateTime.Now;
            this.CalculateNextUpdate();

            /* TODO: 
             * Connect to database
             * Action long list of database updates
             * Close connection to database*/         

            /*TODO: Put in another check for XML file (/generate if not) here*/
            //Update last update in XML
            XmlDocument file = new XmlDocument();
            file.Load(CONFIG_FILE);
            XmlNode node = file.SelectSingleNode(XMLFields.Configuration + "/" + XMLFields.LastUpdate);
            node.InnerText = this.m_lastUpdate.ToString();
            file.Save(CONFIG_FILE);

            this.m_timer.Start();
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
