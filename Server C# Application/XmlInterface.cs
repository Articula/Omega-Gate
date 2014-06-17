using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace SpaceStrategySystem
{
    public enum XMLFields
    {
        Configuration,
        LastUpdate,
        Frequency,
        DatabaseAddress,
        DatabaseName,
        DatabaseUsername,
        DatabasePassword
    };

    public delegate void PassLastUpdateHandler(DateTime dateValue);
    public delegate void PassFrequencyHandler(UpdateFrequency frequency);
    public delegate void PassDbAddressHandler(string dbAddress);
    public delegate void PassDbNameHandler(string dbName);
    public delegate void PassDbUsernameHandler(string dbUsername);
    public delegate void PassDbPasswordHandler(string dbPassword);

    class XmlInterface
    {
        public const string CONFIG_FILE = "config.xml";
        public const string XML_TEMPLATE = "<Configuration><LastUpdate></LastUpdate><Frequency></Frequency><DatabaseAddress></DatabaseAddress><DatabaseName></DatabaseName><DatabaseUsername></DatabaseUsername><DatabasePassword></DatabasePassword></Configuration>";

        public event PassLastUpdateHandler PassLastUpdate;
        public event PassFrequencyHandler PassFrequency;
        public event PassDbAddressHandler PassDbAddress;
        public event PassDbNameHandler PassDbName;
        public event PassDbUsernameHandler PassDbUsername;
        public event PassDbPasswordHandler PassDbPassword;

        protected virtual void OnPassLastUpdate(DateTime dateValue) { PassLastUpdate(dateValue); }
        protected virtual void OnPassFrequency(UpdateFrequency frequency) { PassFrequency(frequency); }
        protected virtual void OnPassDbAddress(string dbAddress) { PassDbAddress(dbAddress); }
        protected virtual void OnPassDbName(string dbName) { PassDbName(dbName); }
        protected virtual void OnPassDbUsername(string dbUsername) { PassDbUsername(dbUsername); }
        protected virtual void OnPassDbPassword(string dbPassword) { PassDbPassword(dbPassword); }


        public void ReadXML()
        {
            if (File.Exists((CONFIG_FILE)))
            {
                //Read in XML fields
                XmlTextReader reader = new XmlTextReader(CONFIG_FILE);
                string currentRead;
                DateTime dateValue;
                int frequencyValue;

                /*Read LastUpdate*/
                reader.ReadToFollowing(XMLFields.LastUpdate.ToString());
                reader.MoveToFirstAttribute();
                currentRead = reader.ReadElementContentAsString();
                if (DateTime.TryParse(currentRead, out dateValue))
                {
                    this.PassLastUpdate(dateValue);
                }
                
                /*Read Frequency*/
                reader.ReadToFollowing(XMLFields.Frequency.ToString());
                reader.MoveToFirstAttribute();
                currentRead = reader.ReadElementContentAsString();
                if (int.TryParse(currentRead, out frequencyValue))
                {
                    this.PassFrequency((UpdateFrequency)frequencyValue);
                }

                /*Read DatabaseAddress*/
                reader.ReadToFollowing(XMLFields.DatabaseAddress.ToString());
                reader.MoveToFirstAttribute();
                currentRead = reader.ReadElementContentAsString();
                this.PassDbAddress(currentRead);

                /*Read DatabaseName*/
                reader.ReadToFollowing(XMLFields.DatabaseName.ToString());
                reader.MoveToFirstAttribute();
                currentRead = reader.ReadElementContentAsString();
                this.PassDbName(currentRead);

                /*Read DatabaseUsername*/
                reader.ReadToFollowing(XMLFields.DatabaseUsername.ToString());
                reader.MoveToFirstAttribute();
                currentRead = reader.ReadElementContentAsString();
                this.PassDbUsername(currentRead);

                /*Read DatabasePassword*/
                reader.ReadToFollowing(XMLFields.DatabasePassword.ToString());
                reader.MoveToFirstAttribute();
                currentRead = reader.ReadElementContentAsString();
                this.PassDbPassword(currentRead);

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

        /*TODO: Combine XML commits into one function?*/
        public void CommitLastUpdate(DateTime dateValue)
        {
            /*TODO: Put in another check for XML file (/generate if not) here*/
            //Update last update in XML
            XmlDocument file = new XmlDocument();
            file.Load(CONFIG_FILE);
            XmlNode node = file.SelectSingleNode(XMLFields.Configuration + "/" + XMLFields.LastUpdate);
            node.InnerText = dateValue.ToString();
            file.Save(CONFIG_FILE);
        }

        public void CommitFrequencyUpdate(int frequency)
        {
            /*TODO: Put in another check for XML file (/generate if not) here*/
            XmlDocument file = new XmlDocument();
            file.Load(CONFIG_FILE);
            XmlNode node = file.SelectSingleNode(XMLFields.Configuration + "/" + XMLFields.Frequency);
            node.InnerText = frequency.ToString();
            file.Save(CONFIG_FILE);
        }
    }
}
