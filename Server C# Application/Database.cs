using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SpaceStrategySystem
{
    class Database
    {
        private MySqlConnection m_connection;

        /*Default connection values*/
        private string m_dbAddress = "localhost";
        private string m_dbName = "";
        private string m_dbUsername = "";
        private string m_dbPassword = "";

        //TODO: Database table structure. Possibly passed through XML?

        public Database()
        {
            
        }

        public void SetDbAddress(string address)
        {
            this.m_dbAddress = address;
        }

        public void SetDbName(string name)
        {
            this.m_dbName = name;
        }

        public void SetDbUsername(string username)
        {
            this.m_dbUsername = username;
        }

        public void SetDbPassword(string password)
        {
            this.m_dbPassword = password;
        }

        public void DBConnectionTest()
        {
            /*TODO: If opening database connection fails, message needs to be sent back to OmegaGateSystem so lastUpdated timestamp is not updated.*/
            /*TODO: If opening database connection fails, prompt for new credentials if applicable (focus on credential fields).*/
            string connectionString;
            connectionString = "SERVER=" + this.m_dbAddress + ";" + "DATABASE=" +
            this.m_dbName + ";" + "UID=" + this.m_dbUsername + ";" + "PASSWORD=" + this.m_dbPassword + ";";

            //MySqlConnection connection = new MySqlConnection(connectionString);
            this.m_connection = new MySqlConnection(connectionString);

            if (this.OpenConnection())
            {
                /*TODO: This is invoked if contact can be made with the database (hostaddress is correct). 
                 * Protection needed for other empty database fields.*/

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
                        /*Hits here if server and database name are populated but credentials are not.*/
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1042:
                        MessageBox.Show("Unable to connect to any of the specified MySQL hosts");
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
    }
}
