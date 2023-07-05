using System.Data;
using System.Data.Odbc;

namespace YourNamespace
{
    public static class MainDatabaseHelper
    {
        public static string GetConnectionString(string username)
        {
            string connectionString = $"Driver={{OpenOffice.org 2.0 ODBC Driver}};Database=Databases/Main.odb;"; // Main_{username}.odb
            return connectionString;
        }

        public static DataTable ExecuteQuery(string query, string username)
        {
            using (OdbcConnection connection = new OdbcConnection(GetConnectionString(username)))
            {
                using (OdbcDataAdapter adapter = new OdbcDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public static int ExecuteNonQuery(string query, string username)
        {
            using (OdbcConnection connection = new OdbcConnection(GetConnectionString(username)))
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
