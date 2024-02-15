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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BikeServiceManagement
{
    public partial class settings_cus : UserControl
    {


        private void settings_cus_Load(object sender, EventArgs e)
        {

        }

        // Method to set LoggedInUsername in the user control
        public string? LoggedInUsername { get; private set; }
        public settings_cus()
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
            try
            {
                string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;Encrypt=False;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string getUserIDQuery = @"SELECT UserID FROM Users WHERE Username = @Username";

                    using (SqlCommand getUserIDCommand = new SqlCommand(getUserIDQuery, connection))
                    {
                        getUserIDCommand.Parameters.AddWithValue("@Username", username);

                        object result = getUserIDCommand.ExecuteScalar();

                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while retrieving the user ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
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

        private void UpdateUserProfile(string targetUsername, string username, string firstName, string lastName, string password, string email)
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

        private bool IsValidEmail(string email)
        {
            // This is a simple email format validation.
            // You might want to use a more sophisticated validation method in a real-world application.
            return email.Contains("@gmail.com");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get the data from the form
            string targetUsername = LoggedInUsername;
            string updatedUsername = textBox4.Text;
            string updatedFirstName = fntxtbx.Text;
            string updatedLastName = lntxtbx.Text;
            string updatedEmail = emtxtbx.Text;
            string updatedPassword = textBox3.Text;
            string updatedConfirmPassword = textBox6.Text;

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
            UpdateUserProfile(targetUsername, updatedUsername, updatedFirstName, updatedLastName, updatedPassword, updatedEmail);

            // Clear the textboxes
            clearForm();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox3.PasswordChar = '\0';
                textBox6.PasswordChar = '\0';
            }
            else
            {
                textBox3.PasswordChar = '•';
                textBox6.PasswordChar = '•';
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
