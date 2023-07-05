using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace YourNamespace
{
    public partial class Register : Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;

            // Add code to insert the user registration details into the UserInfo database
            string query = $"INSERT INTO Users (Username, Password, Email) VALUES ('{username}', '{password}', '{email}')";
            int rowsAffected = UserInfoDatabaseHelper.ExecuteNonQuery(query);

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


    }
}
