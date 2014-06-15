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

        public Database()
        {
            this.DBConnectionTest();
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

            if (this.OpenConnection())
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
    }
}
