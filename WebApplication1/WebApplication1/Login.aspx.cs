using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;

namespace YourNamespace
{
    public partial class Login : Page
    {
        // Specify the file path to your Main.odb database
        private string mainDatabasePath = "C:\\Users\\SV\\source\\repos\\WebApplication1\\WebApplication1\\Databases\\Main.odb";

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Add code to validate the username and password from the database
            string query = $"SELECT COUNT(*) FROM Users WHERE Username='{username}' AND Password='{password}'";
            int count = (int)ExecuteQuery(query).Rows[0][0];

            if (count > 0)
            {
                // User is authenticated, redirect to a secure page
                Response.Redirect("SecurePage.aspx");
            }
            else
            {
                // Invalid credentials, display error message
                lblError.Text = "Invalid username or password.";
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = string.Empty;

            // Add code to insert the user registration details into the UserInfo.odb database
            string insertQuery = $"INSERT INTO Users (Username, Password, Email) VALUES ('{username}', '{password}', '{email}')";
            int rowsAffected = ExecuteNonQuery(insertQuery);

            if (rowsAffected > 0)
            {
                // Registration successful, redirect to the login page
                Response.Redirect("Login.aspx");
            }
            else
            {
                // Registration failed, display error message
                lblError.Text = "Registration failed. Please try again.";
            }
        }

        private string GetConnectionString(string databasePath)
        {
            string connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath};";
            return connectionString;
        }

        private DataTable ExecuteQuery(string query)
        {
            using (OleDbConnection connection = new OleDbConnection(GetConnectionString(mainDatabasePath)))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        private int ExecuteNonQuery(string query)
        {
            using (OleDbConnection connection = new OleDbConnection(GetConnectionString(mainDatabasePath)))
            {
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }
    }
}
