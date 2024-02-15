using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeServiceManagement
{
    public partial class home_admin : UserControl
    {

        public string? LoggedInUsername { get; private set; }
        public int service_no { get; private set; }
        public home_admin()
        {
            InitializeComponent();
            LoggedInUsername = GetLoggedInUsername();
            service_no = GetTotalServices();
            service_no_uc_label.Text = service_no.ToString();

        }


        private string GetLoggedInUsername()
        {
            // Initialize the result variable
            string? loggedInUsername = null;

            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to select the logged-in username from the table
                    string query = "SELECT TOP 1 Username FROM LoginInfo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and get the result
                        object result = command.ExecuteScalar();

                        // Check if the result is not null
                        if (result != null)
                        {
                            loggedInUsername = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // Return the result
            return loggedInUsername;
        }

        private int GetUserID(string username)
        {
            // Initialize the result variable
            int userID = -1;

            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to select the UserID from Users table based on the username
                    string query = "SELECT UserID FROM Users WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@Username", username);

                        // Execute the query and get the result
                        object result = command.ExecuteScalar();

                        // Check if the result is not null
                        if (result != null && int.TryParse(result.ToString(), out userID))
                        {
                            // UserID successfully retrieved
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // Return the result
            return userID;
        }

        private int GetTotalServices()
        {
            // Initialize the result variable
            int totalServices = 0;

            // Ensure that LoggedInUsername is not null
            if (LoggedInUsername != null)
            {
                // Retrieve the UserID based on the logged-in username
                int userID = GetUserID(LoggedInUsername);

                // Check if UserID is valid
                if (userID != -1)
                {
                    // Establish a connection to the database
                    string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            // Write the SQL query to count the number of services based on Provider_ID
                            string query = "SELECT COUNT(*) FROM Services WHERE Provider_ID = @UserID";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Add parameters to the query
                                command.Parameters.AddWithValue("@UserID", userID);

                                // Execute the query and get the result
                                object result = command.ExecuteScalar();

                                // Check if the result is not null
                                if (result != null && int.TryParse(result.ToString(), out totalServices))
                                {
                                    // Total services successfully retrieved
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }

            // Return the result
            return totalServices;
        }
    }
}
