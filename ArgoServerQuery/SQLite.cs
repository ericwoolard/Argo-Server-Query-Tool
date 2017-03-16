using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace ArgoServerQuery
{
    class SQLite
    {
        static SQLiteConnection m_dbConnection;
        static string sqlInit = "CREATE TABLE SERVERLIST (Address VARCHAR(21), Info VARCHAR(255))";

        
        public static void createDB(string name)
        {
            m_dbConnection?.Close();

            SQLiteConnection.CreateFile($"{name}.sqlite");

            //connectDB()
            m_dbConnection = new SQLiteConnection($"Data Source={name}.sqlite;Version=3;");

            // ***REMEMBER TO CALL .Close() WHEN NEEDED***
            m_dbConnection.Open();

            //createTable()
            SQLiteCommand cmd = new SQLiteCommand(sqlInit, m_dbConnection);
            cmd.ExecuteNonQuery();

        }

        public static List<string> loadDB(string file)
        {
            m_dbConnection?.Close();

            m_dbConnection = new SQLiteConnection($"Data Source={file};Version=3;");
            m_dbConnection.Open();

            List<string> numServers = new List<string>();
            string numString = "SELECT Address FROM SERVERLIST";
            SQLiteCommand numCmd = new SQLiteCommand(numString, m_dbConnection);
            SQLiteDataReader reader = numCmd.ExecuteReader();

            while (reader.Read())
            {
                numServers.Add(Convert.ToString(reader["Address"]));
            }
            return numServers;
        }

        public static void connectDB(string name)
        {
            m_dbConnection = new SQLiteConnection($"Data Source={name}.sqlite;Version=3;");
            m_dbConnection.Open();
        }

        public static void createTable()
        {

        }

        public static void addAddress(string addr)
        {
            string sql = $"INSERT INTO SERVERLIST (Address) VALUES ('{addr}')";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
        }

        public static List<string> bgUpdates()
        {
            List<string> bgWorkerSnack = new List<string>();

            if (m_dbConnection != null && m_dbConnection.State == System.Data.ConnectionState.Open)
            {
                string select = "SELECT Address FROM SERVERLIST";
                SQLiteCommand selectCmd = new SQLiteCommand(select, m_dbConnection);
                SQLiteDataReader reader = selectCmd.ExecuteReader();

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
