using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BikeServiceManagement
{
    public partial class read_sup_admin : UserControl
    {
        private int selectedRowIndex = -1; // Add a field to store the selected row index
        public read_sup_admin()
        {
            InitializeComponent();
            // Attach the event handler for the DataGridView cell click
            dataGridView1.CellClick += DataGridViewCell_Click;
            // Attach the event handler for the "Delete" button click
            dltbtn.Click += DeleteButton_Click;

            // Populate the DataGridView initially
            PopulateServices();
            PopulateUsersGrid();


            panel1.Visible = false;
            panel2.Visible = true;
        }

        // Method to populate the DataGridView with services
        private void PopulateServices()
        {
            // Clear existing columns and data
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to select services with Service Provider, Service Name, and Price
                    string query = "SELECT Users.Username AS Service_Provider, Services.Service_Name, Services.Price " +
                                   "FROM Services " +
                                   "INNER JOIN Users ON Services.Provider_ID = Users.UserID " +
                                   "ORDER BY Users.Username, Services.Service_Name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use SqlDataAdapter to fill the DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable servicesDataTable = new DataTable();
                        adapter.Fill(servicesDataTable);

                        // Assign the DataTable as the DataGridView's data source
                        dataGridView1.DataSource = servicesDataTable;

                        // Optionally, you can customize column headers or other properties here
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        // Method to delete a service from the Services table
        private void DeleteService(string serviceProvider, string serviceName, decimal price)
        {
            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to delete the selected service
                    string query = "DELETE FROM Services WHERE Provider_ID = (SELECT UserID FROM Users WHERE Username = @ServiceProvider) AND Service_Name = @ServiceName AND Price = @Price";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@ServiceProvider", serviceProvider);
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

        // Event handler for the "Delete" button click
        // Event handler for the "Delete" button click
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (selectedRowIndex != -1)
            {
                // Assuming the "Service_Provider" column is at index 0, "Service_Name" column is at index 1, and "Price" column is at index 2
                string serviceProvider = dataGridView1.Rows[selectedRowIndex].Cells["Service_Provider"].Value?.ToString();
                string serviceName = dataGridView1.Rows[selectedRowIndex].Cells["Service_Name"].Value?.ToString();
                decimal price = Convert.ToDecimal(dataGridView1.Rows[selectedRowIndex].Cells["Price"].Value);

                // Delete the selected row from the Services table
                DeleteService(serviceProvider, serviceName, price);

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

        // Event handler for the DataGridView cell click
        private void DataGridViewCell_Click(object sender, DataGridViewCellEventArgs e)
        {
            // Store the selected row index
            selectedRowIndex = e.RowIndex;
        }

        private void dltbtn_Click(object sender, EventArgs e)
        {
        }

        // Method to populate dataGridView2 with user information
        private void PopulateUsers()
        {
            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to select user information from Users table
                    string query = "SELECT UserRole, UserID, Username, First_Name, Last_Name, Email, Credit FROM Users ORDER BY UserRole, UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Use SqlDataAdapter to fill the DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable usersDataTable = new DataTable();
                        adapter.Fill(usersDataTable);

                        // Assign the DataTable as the DataGridView's data source
                        dataGridView2.DataSource = usersDataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Call this method to populate dataGridView2 with user information
        private void PopulateUsersGrid()
        {
            // Call the method to populate dataGridView2
            PopulateUsers();

            // Optionally, you can customize column headers or other properties here
        }

        // Method to delete a user from the Users table
        private void DeleteUser(int userID)
        {
            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to delete the selected user
                    string query = "DELETE FROM Users WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@UserID", userID);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Check if the deletion was successful
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete user. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        
        private void UsrBtn_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
        }

        private void addSrvcBtn_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void dltbtn2_Click_1(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridView2.SelectedCells.Count > 0)
            {
                // Get the row index from the selected cell
                int rowIndex = dataGridView2.SelectedCells[0].RowIndex;

                // Assuming the "UserID" column is at index 1
                int userID = Convert.ToInt32(dataGridView2.Rows[rowIndex].Cells["UserID"].Value);

                // Delete the selected user from the Users table
                DeleteUser(userID);

                // Refresh the DataGridView after deletion
                PopulateUsers();
            }
            else
            {
                MessageBox.Show("Please select a row.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

}
