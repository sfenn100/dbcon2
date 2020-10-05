using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data.Common;
using System.Data;


namespace dbcon2
{
    public class MySQLCon : DbConection
    {
        //
        // Based on example from
        // http://www.codeproject.com/Articles/43438/Connect-C-to-MySQL
        //
        Dictionary<string, string> m_properties;
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public MySQLCon(Dictionary<string, string> properties)
        {
            m_properties = properties;
            initialize();            
        }       

        //Initialize values
        private void initialize()
        {
            server = m_properties["Server"];
            database = m_properties["Database"];
            uid = m_properties["User"];
            password = m_properties["Password"];

            setConection();
        }

        private void setConection()
        {
            string connectionString;
            connectionString = "server=" + server + ";" + "database=" +
            database + ";" + "uid=" + uid + ";" + "password=" + password + ";";
            //connectionString = "server=127.0.0.1;database=crashcourse;uid=testuser;password=password;";
            //connectionString = "server=127.0.0.1;database=crashcourse;uid=root;";
            connection = new MySqlConnection(connectionString);
        }        
        
        //open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();                
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
                        MessageBox.Show("Cannot connect to server.  Contact administrator\n" + ex.Message);
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again\n" + ex.Message);
                        break;
                    default:
                        MessageBox.Show("Unable to connect to database exception:\n" + ex.Message);
                        break;
                }
                return false;
            }
            return true;

        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        /*
        //Insert statement
        public void Insert()
        {
        }

        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }
         
        */
        

        //Select statement
        public DbDataReader Select(String query)
        {
            DbDataReader dr = null;

            if (null != connection)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                //MySqlDataReader dataReader = cmd.ExecuteReader();
                dr = cmd.ExecuteReader();                                                    
            }
            return dr;
        }
        /*
        //Count statement
        public int Count()
        {
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }
        */
        
        public DataSet getDataSet(string sqlStatement)
        {
            DataSet dataSet;

            // create the object dataAdapter to manipulate a table from the database StudentDissertations specified by connectionToDB
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlStatement, connection);
            // create the dataset
            dataSet = new System.Data.DataSet();
            dataAdapter.Fill(dataSet);
            //return the dataSet
            return dataSet;
        }
    }
}
