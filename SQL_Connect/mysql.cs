using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

// ===============================================================
// This class is designed to facilitate access to MySQL.
//  * Last Update : 2021-03-11
// ===============================================================

namespace SQL_Connect
{
    class mysql
    {
        // DB Connection Information
        private String Server_IP = "localhost"; // Server IP address
        private String Server_Port = "3306"; // Server DB port
        private String DB_Name = "test_db"; // Database name
        private String DB_User = "root"; // Database user
        private String DB_Password = "1234abcd"; // Database password

        MySqlConnection connection;

        // MySQL DB Generators
        public mysql()
        {
            return;
        }

        public Boolean DBConnection()
        {
            string DB_Server_Connect = "Server=" + Server_IP + "; Port=" + Server_Port + "; Database=" + DB_Name + "; Uid=" + DB_User + "; Pwd=" + DB_Password;
            try
            {
                connection = new MySqlConnection(DB_Server_Connect);
                connection.Open();

                Boolean tmp = connection.Ping(); // Check Connection

                if (tmp) // If Connection to DB, return true
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public Boolean Sql(string SQL)
        {
            Boolean connection_result = DBConnection();

            if (!connection_result) // If connection error
            {
                return false;
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                cmd.ExecuteNonQuery(); // Run SQL
                connection.Close();
                return true;
            }
            catch (Exception ex) // If SQL process failed
            {
                connection.Close();
                return false;
            }
        }

        // Select SQL (Single value)
        public string Select_Sql(string SQL)
        {
            Boolean connection_result = DBConnection();
            string result = "";

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                MySqlDataReader table = cmd.ExecuteReader();

                while (table.Read())
                {
                    result = Convert.ToString(table[0]);
                }
                return result;
            }
            catch (Exception ex) // If SQL process failed
            {
                connection.Close();
            }
            return "0";
        }

        // Select SQL (Multi Values)
        public string[] Select_Sql(string SQL, string[] parameter)
        {
            Boolean connection_result = DBConnection();
            string[] result = new string[parameter.Length];

            try
            {
                MySqlCommand cmd = new MySqlCommand(SQL, connection);
                MySqlDataReader table = cmd.ExecuteReader();
                //table_count = table.Cast<Object>().Count();
                //result = new string[parameter.Length, table_count];

                while (table.Read())
                {
                    for (int i = 0; i < parameter.Length; i++)
                        result[i] = Convert.ToString(table[parameter[i]]);
                }
                return result;
            }
            catch (Exception ex) // If SQL process failed
            {
                connection.Close();
            }

            return result;
        }

        // 상황에 따라 SQL 호출
        internal String Get_IP()
        {
            return Server_IP;
        }

        internal String Get_Port()
        {
            return Server_Port;
        }

        internal String Get_Name()
        {
            return DB_Name;
        }

        internal String Get_User()
        {
            return DB_User;
        }

        internal String Get_Password()
        {
            return DB_Password;
        }
    }
}
