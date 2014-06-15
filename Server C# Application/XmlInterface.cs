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
        DatabaseUsername,
        DatabasePassword
    };

    public delegate void PassLastUpdateHandler(DateTime dateValue);
    public delegate void PassFrequencyHandler(UpdateFrequency frequency);

    class XmlInterface
    {
        public const string CONFIG_FILE = "config.xml";
        public const string XML_TEMPLATE = "<Configuration><LastUpdate></LastUpdate><Frequency></Frequency><DatabaseAddress></DatabaseAddress><DatabaseUsername></DatabaseUsername><DatabasePassword></DatabasePassword></Configuration>";

        public event PassLastUpdateHandler PassLastUpdate;
        public event PassFrequencyHandler PassFrequency;

        protected virtual void OnPassLastUpdate(DateTime dateValue) { PassLastUpdate(dateValue); }
        protected virtual void OnPassFrequency(UpdateFrequency frequency) { PassFrequency(frequency); }


        public void ReadXML()
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
                    this.PassLastUpdate(dateValue);
                }

                reader.ReadToFollowing(XMLFields.Frequency.ToString());
                reader.MoveToFirstAttribute();
                currentRead = reader.ReadElementContentAsString();
                if (int.TryParse(currentRead, out frequencyValue))
                {
                    this.PassFrequency((UpdateFrequency)frequencyValue);
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
