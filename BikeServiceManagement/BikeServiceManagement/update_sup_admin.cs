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
    public partial class update_sup_admin : UserControl
    {
        public update_sup_admin()
        {
            InitializeComponent();

            // Call a method to populate the ComboBox with admin usernames
            PopulateAdminUsernames();

            updtUsrpan.Visible = true;
            updtSrvcpan.Visible = false;
        }

        private void PopulateAdminUsernames()
        {
            // Clear existing items in the ComboBox
            comboBox2.Items.Clear();

            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to select usernames from Users table where UserRole is 'Admin'
                    string query = "SELECT Username FROM Users WHERE UserRole = 'Admin'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Loop through the result set and add usernames to the ComboBox
                            while (reader.Read())
                            {
                                string username = reader.GetString(0);
                                comboBox2.Items.Add(username);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
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

        // Function to validate email format
        private bool IsValidEmail(string email)
        {
            // This is a simple email format validation.
            // You might want to use a more sophisticated validation method in a real-world application.
            return email.Contains("@gmail.com");
        }

        private bool IsNumeric(string text)
        {
            return decimal.TryParse(text, out _);
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

        private void button2_Click(object sender, EventArgs e)
        {
            // Get the service name and price from TextBoxes
            string serviceName = sn_box.Text.Trim();
            string priceText = price_bx.Text.Trim();
            string serviceProvider = comboBox2.SelectedItem?.ToString();

            // Validate ServiceProvider
            if (string.IsNullOrEmpty(serviceProvider))
            {
                MessageBox.Show("Please select a Service Provider.");
                return;
            }

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
            int providerID = GetUserID(serviceProvider);

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
        }

        private void UpdateUserProfile(string targetUsername, string username, string firstName, string lastName, string password, string email, decimal credit)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;Encrypt=False;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if the updated username is already in use
                    if (IsUsernameAvailable(targetUsername))
                    {
                        int userID = GetUserID(targetUsername);

                        // Construct the base update query
                        string updateQuery = "UPDATE Users SET ";

                        // Add fields to update only if values are provided
                        if (!string.IsNullOrEmpty(username)) updateQuery += "Username = @Username, ";
                        if (!string.IsNullOrEmpty(firstName)) updateQuery += "First_Name = @FirstName, ";
                        if (!string.IsNullOrEmpty(lastName)) updateQuery += "Last_Name = @LastName, ";
                        if (!string.IsNullOrEmpty(password)) updateQuery += "Password = @Password, ";
                        if (!string.IsNullOrEmpty(email)) updateQuery += "Email = @Email, ";
                        // Add the credit field
                        updateQuery += "Credit = @Credit, ";

                        // Remove the trailing comma and add the WHERE clause
                        updateQuery = updateQuery.TrimEnd(',', ' ') + " WHERE UserID = @UserID";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            // Add parameters only for the fields that are provided
                            updateCommand.Parameters.AddWithValue("@UserID", userID);
                            if (!string.IsNullOrEmpty(username)) updateCommand.Parameters.AddWithValue("@Username", username);
                            if (!string.IsNullOrEmpty(firstName)) updateCommand.Parameters.AddWithValue("@FirstName", firstName);
                            if (!string.IsNullOrEmpty(lastName)) updateCommand.Parameters.AddWithValue("@LastName", lastName);
                            if (!string.IsNullOrEmpty(password)) updateCommand.Parameters.AddWithValue("@Password", password);
                            if (!string.IsNullOrEmpty(email)) updateCommand.Parameters.AddWithValue("@Email", email);
                            // Add the credit parameter
                            updateCommand.Parameters.AddWithValue("@Credit", credit);

                            try
                            {
                                int rowsAffected = updateCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Failed to update profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (SqlException ex)
                            {
                                if (ex.Number == 2627) // Unique constraint violation error number
                                {
                                    MessageBox.Show("The provided username is already in use. Please choose a different username.",
                                        "Username In Use", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username not found. Please enter a valid username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearForm()
        {
            textBox4.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            fntxtbx.Text = "";
            emtxtbx.Text = "";
            lntxtbx.Text = "";
        }

        private bool IsUsernameAvailable(string username)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;Encrypt=False;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string checkUsernameQuery = @"SELECT COUNT(*) FROM Users WHERE Username = @Username";

                    using (SqlCommand checkUsernameCommand = new SqlCommand(checkUsernameQuery, connection))
                    {
                        checkUsernameCommand.Parameters.AddWithValue("@Username", username);

                        int existingUserCount = (int)checkUsernameCommand.ExecuteScalar();

                        return existingUserCount > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while checking the username: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void updtUsrBtn_Click(object sender, EventArgs e)
        {
            updtUsrpan.Visible = true;
            updtSrvcpan.Visible = false;
        }

        private void updtSrvcBtn_Click(object sender, EventArgs e)
        {
            updtUsrpan.Visible = false;
            updtSrvcpan.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the data from the form
            string targetUsername = textBox1.Text;
            string updatedUsername = textBox4.Text;
            string updatedFirstName = fntxtbx.Text;
            string updatedLastName = lntxtbx.Text;
            string updatedEmail = emtxtbx.Text;
            string updatedPassword = textBox3.Text;
            string updatedConfirmPassword = textBox6.Text;
            string updatedCreditText = textBox2.Text;

            if (!IsNumeric(updatedCreditText))
            {
                // If the input is not a valid decimal or integer, show an error message
                MessageBox.Show("Please enter a valid decimal or integer value for the price.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Convert the price to a decimal value
            decimal updatedCredit = decimal.Parse(updatedCreditText);


            // Confirm password
            if (updatedPassword != updatedConfirmPassword)
            {
                MessageBox.Show("Password and Confirm Password do not match.");
                return;
            }

            // Validate email format
            if (!IsValidEmail(updatedEmail))
            {
                MessageBox.Show("Please enter a valid email address (e.g., user@gmail.com).");
                return;
            }


            // Update the user's profile in the database
            UpdateUserProfile(targetUsername, updatedUsername, updatedFirstName, updatedLastName, updatedPassword, updatedEmail, updatedCredit);

            // Clear the textboxes
            clearForm();
        }
    }
}
