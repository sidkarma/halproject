﻿using System.Data;
using System.Data.Odbc;

namespace YourNamespace
{
    public static class DatabaseHelper
    {
        public static string GetConnectionString()
        {
            string connectionString = "Driver={OpenOffice.org 2.0 ODBC Driver};Dbq=C:/Users/SV/source/repos/WebApplication1/WebApplication1/Databases/Main.odb;";
            return connectionString;
        }

        public static DataTable ExecuteQuery(string query)
        {
            using (OdbcConnection connection = new OdbcConnection(GetConnectionString()))
            {
                using (OdbcDataAdapter adapter = new OdbcDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public static int ExecuteNonQuery(string query)
        {
            using (OdbcConnection connection = new OdbcConnection(GetConnectionString()))
            {
                using (OdbcCommand command = new OdbcCommand(query, connection))
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }
    }
}
