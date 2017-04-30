using System;
using System.Collections.Generic;
//---------------------------------------------------------------------------------//
//------------- System.Data.SQLite is an ADO.NET provider for SQLite. -------------//
// Find it at: https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki -//
//---------------------------------------------------------------------------------//
using System.Data.SQLite;                                                          //
using System.Data.SqlClient;                                                       //
//---------------------------------------------------------------------------------//

namespace ArgoServerQuery
{
    class SQLite
    {
        static SQLiteConnection m_dbConnection;
        static string sqlInit = "CREATE TABLE SERVERLIST (Address VARCHAR(21), Info VARCHAR(255))";

        
        public static void createDB(string name)
        {
            // Make sure we aren't already connected to a server list. If we are,
            // close it before creating a new sqlite db
            m_dbConnection?.Close();

            // Create a new connection object and set the Data Source to our global
            // DataDirectory (in MainForm.cs) where all server lists are stored
            m_dbConnection = new SQLiteConnection($"Data Source=|DataDirectory|{name}.sqlite;Version=3;");

            m_dbConnection.Open();

            // Create the table for the new server list
            SQLiteCommand cmd = new SQLiteCommand(sqlInit, m_dbConnection);
            cmd.ExecuteNonQuery();
        }

        public static Dictionary<string, string> loadDB(string file)
        {
            m_dbConnection?.Close();

            m_dbConnection = new SQLiteConnection($"Data Source=|DataDirectory|{file};Version=3;");
            m_dbConnection.Open();

            Dictionary<string, string> ip_info = new Dictionary<string, string>();
            string numString = "SELECT * FROM SERVERLIST";
            SQLiteCommand numCmd = new SQLiteCommand(numString, m_dbConnection);
            SQLiteDataReader reader = numCmd.ExecuteReader();

            while (reader.Read())
            {
                ip_info.Add(Convert.ToString(reader["Address"]), Convert.ToString(reader["Info"]));
            }
            return ip_info;
        }

        public static void connectDB(string name)
        {
            m_dbConnection = new SQLiteConnection($"Data Source=|DataDirectory|{name}.sqlite;Version=3;");
            m_dbConnection.Open();
        }

        public static void addAddress(string addr)
        {
            string sql = $"INSERT INTO SERVERLIST (Address) VALUES ('{addr}')";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        // Used by the Background Worker to update each server in the server list 
        public static List<string> bgUpdates()
        {
            List<string> bgWorkerSnack = new List<string>();

            if (m_dbConnection != null && m_dbConnection.State == System.Data.ConnectionState.Open)
            {
                // Select the Address column from the table 
                string select = "SELECT Address FROM SERVERLIST";
                SQLiteCommand selectCmd = new SQLiteCommand(select, m_dbConnection);
                SQLiteDataReader reader = selectCmd.ExecuteReader();

                // Read down each address and store them in the bgWorkerSnack List
                while (reader.Read())
                {
                    bgWorkerSnack.Add(Convert.ToString(reader["Address"]));
                }
                return bgWorkerSnack;
            }
            else
            {
                return bgWorkerSnack;
            }
        }

        // Adds a custom name to organize servers. Displayed in the info column of server list
        public static void addInfo(string ip, string info)
        {
            if (m_dbConnection != null && m_dbConnection.State == System.Data.ConnectionState.Open)
            {
                SQLiteCommand cmdInfo = new SQLiteCommand(m_dbConnection)
                {
                    CommandText = "UPDATE SERVERLIST SET Info = @info WHERE Address = @ip"
                };
                cmdInfo.Parameters.AddWithValue("info", info);
                cmdInfo.Parameters.AddWithValue("ip", ip);
                cmdInfo.ExecuteNonQuery();
            }
        }

        public static void deleteRecord(string ip)
        {
            if (m_dbConnection != null && m_dbConnection.State == System.Data.ConnectionState.Open)
            {
                SQLiteCommand cmdDelete = new SQLiteCommand(m_dbConnection)
                {
                    CommandText = "DELETE FROM SERVERLIST WHERE Address = @ip"
                };
                cmdDelete.Parameters.AddWithValue("ip", ip);
                cmdDelete.ExecuteNonQuery();
            }
        }

        public static void closeConnection()
        {
            m_dbConnection?.Close();
        }
    }
}
