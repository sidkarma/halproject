using System;
using System.Data;

namespace YourNamespace
{
    public partial class MainPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Get the username from the query parameter
                string username = Request.QueryString["username"];

                // Use the username to connect to the user's Main database
                // and perform any required operations

                // Example: Retrieve data from the user's Main database
                string query = "SELECT * FROM TableName";
                DataTable dataTable = MainDatabaseHelper.ExecuteQuery(query, username);

                // Use the retrieved data for display or further processing
            }
        }
    }
}
