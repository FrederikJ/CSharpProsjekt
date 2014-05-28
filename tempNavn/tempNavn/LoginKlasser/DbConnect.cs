using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace CSharpProsjekt.LoginKlasser
{
    class DbConnect
    {
        private MySqlConnection connection;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;
        private Bruker bruker;
        private string server;
        private string database;
        private string uid;
        private string passord;

        public DbConnect()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            server = "kark.hin.no";
            database = "gruppe5";
            uid = "gruppe5";
            passord = "storasveien";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + passord + ";";

            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            connection.Open();
            return true;
        }

        private bool CloseConnection()
        {
            connection.Close();
            return true;
        }

        public DataTable GetAll(string query)
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
        public void InsertAll(string query)
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
