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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BikeServiceManagement
{
    public partial class home_cus : UserControl
    {

        public string? LoggedInUsername { get; private set; }
        public string? SelectedServiceName { get; private set; }

        public decimal Price { get; private set; }

        public home_cus()
        {
            InitializeComponent();

            LoggedInUsername = GetLoggedInUsername();

            // Call a method to populate the ComboBox with admin usernames
            PopulateAdminUsernames();

            // Retrieve the latest transaction details
            Tuple<string, string, DateTime, bool, decimal> lastTransactionDetails = GetLastTransactionDetails();

            // Update the labels based on the retrieved details
            if (lastTransactionDetails != null)
            {
                SP_label.Text = lastTransactionDetails.Item1; // Service Provider
                SN_Label.Text = lastTransactionDetails.Item2; // Service Name
                Date_Label.Text = lastTransactionDetails.Item3.ToString(); // Date

                // Home Service
                HS_Label.Text = lastTransactionDetails.Item4 ? "Yes" : "No";

                // Total Cost
                TC_Label.Text = "$" + lastTransactionDetails.Item5.ToString(); // Assuming total cost is stored as decimal
            }

            service_panel.Visible = true;
            thnku_panel.Visible = false;
            payment_panel.Visible = false;
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

        // Modify the PopulateServiceNames method
        private void PopulateServiceNames(int providerID)
        {
            // Clear existing items in the ComboBox
            comboBox1.Items.Clear();

            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to select Service_Names and Prices from Services table based on the Provider_ID
                    string query = "SELECT Service_Name, Price FROM Services WHERE Provider_ID = @ProviderID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@ProviderID", providerID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Loop through the result set and add formatted strings to the ComboBox
                            while (reader.Read())
                            {
                                // Create a formatted string with service name and price
                                string serviceName = reader.GetString(0);
                                decimal price = reader.GetDecimal(1);
                                SelectedServiceName = serviceName;
                                string formattedService = $"{serviceName} : ${price}";

                                // Add the formatted string to the ComboBox
                                comboBox1.Items.Add(formattedService);
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


        private Tuple<int, decimal> GetServiceInfo(string serviceName, int providerID)
        {
            // Initialize the result variable
            Tuple<int, decimal> serviceInfo = null;

            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to select ServiceID and Price from Services table based on the Service_Name and Provider_ID
                    string query = "SELECT ServiceID, Price FROM Services WHERE Service_Name = @ServiceName AND Provider_ID = @ProviderID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@ServiceName", serviceName);
                        command.Parameters.AddWithValue("@ProviderID", providerID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Check if the result set has rows
                            if (reader.Read())
                            {
                                int serviceID = reader.GetInt32(0);
                                decimal price = reader.GetDecimal(1);
                                serviceInfo = Tuple.Create(serviceID, price);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // Return the result
            return serviceInfo;
        }


        private void UpdateTransactionDetails(string providerName, string serviceName, decimal price, DateTime date, bool homeService)
        {
            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to insert data into the TransactionDetails table
                    string query = "INSERT INTO TransactionDetails (Username, Service_Provider, Service_Name, Price, [Date], Home_Service) " +
                                   "VALUES (@Username, @ServiceProvider, @ServiceName, @Price, @Date, @HomeService)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@Username", LoggedInUsername);
                        command.Parameters.AddWithValue("@ServiceProvider", providerName);
                        command.Parameters.AddWithValue("@ServiceName", serviceName);
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@Date", date);
                        command.Parameters.AddWithValue("@HomeService", homeService ? 1 : 0);

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected username from the ComboBox
            string selectedUsername = comboBox2.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedUsername))
            {
                // Retrieve the UserID based on the selected username
                int userID = GetUserID(selectedUsername);

                // Populate the ComboBox with Service_Names based on the Provider_ID
                PopulateServiceNames(userID);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void UpdateUserCredit(string username, decimal amount)
        {
            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to update the credit for the specified user
                    string query = "UPDATE Users SET Credit = Credit - @Amount WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@Amount", amount);
                        command.Parameters.AddWithValue("@Username", username);

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Get the selected values from ComboBoxes
            string selectedProvider = comboBox2.SelectedItem as string;
            string selectedService = SelectedServiceName;

            // Validate that both provider and service are selected
            if (string.IsNullOrEmpty(selectedProvider) || string.IsNullOrEmpty(selectedService))
            {
                MessageBox.Show("Please select both a provider and a service before proceeding.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Retrieve the ProviderID based on the selected provider
            int providerID = GetUserID(selectedProvider); // Here, I'm using GetUserID for consistency; you can change it to GetProviderID if needed

            // Retrieve the ServiceID and Price based on the selected service and provider
            Tuple<int, decimal> serviceInfo = GetServiceInfo(selectedService, providerID);


            if (serviceInfo == null)
            {
                MessageBox.Show("Error retrieving service information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the selected date from DateTimePicker
            DateTime selectedDate = dateTimePicker1.Value;

            // Get the selected value from the Home Service checkbox
            bool homeService = checkBox1.Checked;

            // Calculate the total cost based on the service price and home service selection
            //decimal totalCost = CalculateTotalCost(serviceInfo.Item2, homeService);

            // Update the TransactionDetails table
            UpdateTransactionDetails(selectedProvider, selectedService, serviceInfo.Item2, selectedDate, homeService);

            payment_panel.Invalidate();
            payment_panel.Update();

            // Show the appropriate panel
            payment_panel.Visible = true;
            service_panel.Visible = false;
            thnku_panel.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateUserCredit(LoggedInUsername, Price);
            thnku_panel.Visible = true;
            service_panel.Visible = false;
            payment_panel.Visible = false;


        }

        private Tuple<string, string, DateTime, bool, decimal> GetLastTransactionDetails()
        {
            Tuple<string, string, DateTime, bool, decimal> transactionDetails = null;

            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();


                    // Retrieve the latest transaction details from TransactionDetails table
                    string query = "SELECT TOP 1 Service_Provider, Service_Name, [Date], Home_Service, Price FROM TransactionDetails ORDER BY TransactionID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string serviceProvider = reader.GetString(0);
                                string serviceName = reader.GetString(1);
                                DateTime date = reader.GetDateTime(2);
                                bool homeService = reader.GetBoolean(3);
                                decimal price = reader.GetDecimal(4);
                                Price = price;

                                transactionDetails = Tuple.Create(serviceProvider, serviceName, date, homeService, price);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return transactionDetails;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            service_panel.Visible = true;
            thnku_panel.Visible = false;
            payment_panel.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void home_cus_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            thnku_panel.Visible = false;
            service_panel.Visible = true;
            payment_panel.Visible = false;
        }
    }
}
