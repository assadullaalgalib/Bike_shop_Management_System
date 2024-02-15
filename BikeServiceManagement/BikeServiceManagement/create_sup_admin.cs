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
    public partial class create_sup_admin : UserControl
    {
        public create_sup_admin()
        {
            InitializeComponent();

            // Call a method to populate the ComboBox with admin usernames
            PopulateAdminUsernames();


            addusrpan.Visible = true;
            addsrvcpan.Visible = false;
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

        private void button4_Click(object sender, EventArgs e)
        {


            // Get user input from textboxes
            string firstName = fntxtbx.Text;
            string lastName = lntxtbx.Text;
            string username = textBox4.Text;
            string email = emtxtbx.Text;
            string password = textBox3.Text;
            string confirmPassword = textBox6.Text;
            string userRole = usrRoleComboBox.SelectedItem?.ToString();
            double credit = 1000.00;

            // Validate UserRole
            if (string.IsNullOrEmpty(userRole))
            {
                MessageBox.Show("Please select a user role.");
                return;
            }

            // Validate input
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }


            // Validate email format
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Please enter a valid email address (e.g., user@gmail.com).");
                return;
            }

            // Confirm password
            if (password != confirmPassword)
            {
                MessageBox.Show("Password and Confirm Password do not match.");
                return;
            }

            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to insert data into the table
                    string query = "INSERT INTO Users (UserRole, First_Name, Last_Name, Username, Email, Password, Credit) " +
                                   "VALUES (@UserRole, @FirstName, @LastName, @Username, @Email, @Password, @Credit)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query to prevent SQL injection
                        command.Parameters.AddWithValue("@UserRole", userRole);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Credit", credit);

                        // Execute the query
                        command.ExecuteNonQuery();

                        MessageBox.Show("User registration successful!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void addUsrBtn_Click(object sender, EventArgs e)
        {
            addusrpan.Visible = true;
            addsrvcpan.Visible = false;
        }

        private void addSrvcBtn_Click(object sender, EventArgs e)
        {
            addusrpan.Visible = false;
            addsrvcpan.Visible = true;
        }

        private bool ServiceExists(int providerID, string serviceName)
        {
            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to check if the service name already exists
                    string query = "SELECT COUNT(*) FROM Services WHERE Provider_ID = @ProviderID AND Service_Name = @ServiceName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@ServiceName", serviceName);
                        command.Parameters.AddWithValue("@ProviderID", providerID);

                        // Execute the query and get the result
                        int count = (int)command.ExecuteScalar();

                        // If count is greater than 0, the service exists
                        if (count > 0)
                        {
                            MessageBox.Show("Service name already exists. Please choose a different service name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void InsertNewService(int providerID, string serviceName, decimal price)
        {
            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to insert a new service into the Services table
                    string query = "INSERT INTO Services (Provider_ID, Service_Name, Price) VALUES (@ProviderID, @ServiceName, @Price)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@ProviderID", providerID);
                        command.Parameters.AddWithValue("@ServiceName", serviceName);
                        command.Parameters.AddWithValue("@Price", price);

                        // Execute the query
                        command.ExecuteNonQuery();

                        // Optionally, you can perform additional actions or show a success message
                        MessageBox.Show("New service added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (ServiceExists(providerID, serviceName))
            {
                // Service already exists, return without further processing
                return;
            }

            // Insert the new service into the Services table
            InsertNewService(providerID, serviceName, price);

            // Optionally, you can perform additional actions or show a success message
        }
    }
}
