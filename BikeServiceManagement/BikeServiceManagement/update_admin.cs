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
    public partial class update_admin : UserControl
    {
        public string? LoggedInUsername { get; private set; }
        public update_admin()
        {
            InitializeComponent();
            LoggedInUsername = GetLoggedInUsername();
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

        private bool ServiceExists(string serviceName)
        {
            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to check if the service name already exists
                    string query = "SELECT COUNT(*) FROM Services WHERE Service_Name = @ServiceName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@ServiceName", serviceName);

                        // Execute the query and get the result
                        int count = (int)command.ExecuteScalar();

                        // If count is greater than 0, the service exists
                        if (count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return false; // Assume service does not exist in case of an error
                }
            }
        }

        private void UpdateService(int providerID, string serviceName, decimal price)
        {
            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to update an existing service in the Services table
                    string query = "UPDATE Services SET Price = @Price WHERE Provider_ID = @ProviderID AND Service_Name = @ServiceName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@ProviderID", providerID);
                        command.Parameters.AddWithValue("@ServiceName", serviceName);
                        command.Parameters.AddWithValue("@Price", price);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // The update was successful
                            MessageBox.Show("Service updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // No rows were affected, indicating that the service does not exist
                            MessageBox.Show("Service does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool IsNumeric(string text)
        {
            return decimal.TryParse(text, out _);
        }

        private void button2_Click(object sender, EventArgs e)  // Confirm Button
        {
            // Get the service name and price from TextBoxes
            string serviceName = sn_box.Text.Trim();
            string priceText = price_bx.Text.Trim();

            // Check if the price contains anything other than an integer or decimal
            if (!IsNumeric(priceText))
            {
                // If the input is not a valid decimal or integer, show an error message
                MessageBox.Show("Please enter a valid decimal or integer value for the price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Convert the price to a decimal value
            decimal price = decimal.Parse(priceText);

            // Get the provider ID based on the logged-in username
            int providerID = GetUserID(LoggedInUsername);

            // Check if the service already exists
            if (ServiceExists(serviceName))
            {
                // Service already exists, update the price
                UpdateService(providerID, serviceName, price);
            }
            else
            {
                MessageBox.Show("Service does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Optionally, you can perform additional actions or show a success message
        }


        private void price_bx_TextChanged(object sender, EventArgs e)
        {

        }

        private void sn_box_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
