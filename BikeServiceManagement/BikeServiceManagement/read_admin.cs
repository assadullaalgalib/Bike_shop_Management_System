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
    public partial class read_admin : UserControl
    {

        public string? LoggedInUsername { get; private set; }
        public read_admin()
        {
            InitializeComponent();
            LoggedInUsername = GetLoggedInUsername();

            // Attach the event handler for the DataGridView cell click
            dataGridView1.CellClick += DataGridViewCell_Click;

            // Attach the event handler for the "Delete" button click
            dltbtn.Click += DeleteButton_Click;

            // Populate the DataGridView initially
            PopulateServices();
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

        // Call this method to populate the DataGridView with services for the logged-in admin
        public void PopulateServices()
        {
            // Get the UserID for the logged-in admin
            int adminUserID = GetUserID(LoggedInUsername);

            // Check if the UserID is valid
            if (adminUserID != -1)
            {
                // Retrieve services for the admin from the database
                DataTable adminServices = GetAdminServicesDataTable(adminUserID);

                // Populate the DataGridView with the retrieved services
                PopulateServiceDataGridView(adminServices);
            }
            else
            {
                MessageBox.Show("Failed to retrieve admin information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to retrieve services for the admin from the database and return as DataTable
        private DataTable GetAdminServicesDataTable(int adminUserID)
        {
            DataTable servicesDataTable = new DataTable();

            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to select services for the admin based on UserID
                    string query = "SELECT Service_Name, Price FROM Services WHERE Provider_ID = @ProviderID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@ProviderID", adminUserID);

                        // Use SqlDataAdapter to fill the DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(servicesDataTable);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            return servicesDataTable;
        }

        // Method to populate the DataGridView with services
        private void PopulateServiceDataGridView(DataTable servicesDataTable)
        {
            // Clear existing columns and data
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            // Assign the DataTable as the DataGridView's data source
            dataGridView1.DataSource = servicesDataTable;

            // Optionally, you can customize column headers or other properties here
        }

        // Method to delete a service from the Services table
        private void DeleteService(string serviceName, decimal price)
        {
            // Get the UserID for the logged-in admin
            int adminUserID = GetUserID(LoggedInUsername);

            // Check if the UserID is valid
            if (adminUserID != -1)
            {
                // Establish a connection to the database
                string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        // Write the SQL query to delete the selected service
                        string query = "DELETE FROM Services WHERE Provider_ID = @ProviderID AND Service_Name = @ServiceName AND Price = @Price";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            // Add parameters to the query
                            command.Parameters.AddWithValue("@ProviderID", adminUserID);
                            command.Parameters.AddWithValue("@ServiceName", serviceName);
                            command.Parameters.AddWithValue("@Price", price);

                            // Execute the query
                            int rowsAffected = command.ExecuteNonQuery();

                            // Check if the deletion was successful
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Service deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete service. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Failed to retrieve admin information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add a field to store the selected row index
        private int selectedRowIndex = -1;

        // Event handler for the DataGridView cell click
        private void DataGridViewCell_Click(object sender, DataGridViewCellEventArgs e)
        {
            // Store the selected row index
            selectedRowIndex = e.RowIndex;
        }

        // Event handler for the "Delete" button click
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (selectedRowIndex != -1)
            {
                // Assuming the "Service_Name" column is at index 0 and "Price" column is at index 1
                string serviceName = dataGridView1.Rows[selectedRowIndex].Cells["Service_Name"].Value?.ToString();
                decimal price = Convert.ToDecimal(dataGridView1.Rows[selectedRowIndex].Cells["Price"].Value);

                // Delete the selected row from the Services table
                DeleteService(serviceName, price);

                // Refresh the DataGridView after deletion
                PopulateServices();

                // Reset the selected row index
                selectedRowIndex = -1;
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Modified event handler for the "Delete" button click
        private void dltbtn_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // Get the row index from the selected cell
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

                // Assuming the "Service_Name" column is at index 0 and "Price" column is at index 1
                string serviceName = dataGridView1.Rows[rowIndex].Cells["Service_Name"].Value?.ToString();
                decimal price = Convert.ToDecimal(dataGridView1.Rows[rowIndex].Cells["Price"].Value);

                // Delete the selected row from the Services table
                DeleteService(serviceName, price);

                // Refresh the DataGridView after deletion
                PopulateServices();
            }
            else
            {
                MessageBox.Show("Please select a cell to delete the corresponding row.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

}

