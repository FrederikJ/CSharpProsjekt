using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace CSharpProsjekt.LoginKlasser
{
    /// <summary>
    /// DbConnect.cs av Frederik Johnsen
    /// Programmering 3 - C# Prosjekt
    /// 
    /// Klassen som brukes til å koble opp mot våres MySQL database. 
    /// </summary>
    class DbConnect
    {
        //Medlems variabler
        private MySqlConnection connection;
        private MySqlDataAdapter adapter;
        private DataTable dataTable;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DbConnect()
        {
            this.Initialize();
        }

        //Selve oppkoblingen til databasen
        private void Initialize()
        {
            server = "kark.hin.no";
            database = "gruppe5";
            uid = "gruppe5";
            password = "storasveien";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Retunere true viss koblingen mot db enda er åpen
        /// </summary>
        /// <returns></returns>
        private bool OpenConnection()
        {
            connection.Open();
            return true;
        }

        /// <summary>
        /// Retunere true viss koblingen mot db er stengt
        /// </summary>
        /// <returns></returns>
        private bool CloseConnection()
        {
            connection.Close();
            return true;
        }

        /// <summary>
        /// En generel spørring som kan hente ut hva som helst fra databasen
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
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

        /// <summary>
        /// En generel spørring som kan legge hva som helst til databasen.
        /// </summary>
        /// <param name="query"></param>
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
