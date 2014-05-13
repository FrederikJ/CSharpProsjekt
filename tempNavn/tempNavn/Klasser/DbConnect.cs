using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace tempNavn.Klasser
{
    class DbConnect
    {
        private static MySqlConnection connection;
        private static MySqlDataAdapter adapter;
        private static DataTable dataTable;
        private static string server;
        private static string database;
        private static string uid;
        private static string password;

        public DbConnect()
        {
            Initialize();
        }

        private static void Initialize()
        {
            server = "kark.hin.no";
            database = "gruppe51";
            uid = "gruppe5";
            password = "storasveien";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        private static bool OpenConnection()
        {
            connection.Open();
            return true;
        }

        private static bool CloseConnection()
        {
            connection.Close();
            return true;
        }

        public static DataTable GetAll(string query)
        {
            if (OpenConnection() == true)
            {
                dataTable = new DataTable();
                adapter = new MySqlDataAdapter(query, connection);
                adapter.Fill(dataTable);
                CloseConnection();
            }
            return dataTable;
        }
        public static void InsertAll(string query)
        {
            if(OpenConnection() == true)
            {
                MySqlCommand comm = connection.CreateCommand();
                comm.CommandText = query;
                comm.ExecuteNonQuery();
                CloseConnection();
            }
        }
    }
}
