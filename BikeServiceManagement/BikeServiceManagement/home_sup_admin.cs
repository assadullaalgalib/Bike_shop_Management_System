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
    public partial class home_sup_admin : UserControl
    {
        public home_sup_admin()
        {
            InitializeComponent();

            UpdateServiceProviderCountLabel();
            UpdateCustomerCountLabel();
        }

        private void UpdateServiceProviderCountLabel()
        {
            try
            {
                // Establish a connection to the database
                string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Write the SQL query to count the number of "Admin" users
                    string query = "SELECT COUNT(*) FROM Users WHERE UserRole = 'Admin'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and get the result
                        int serviceProviderCount = Convert.ToInt32(command.ExecuteScalar());

                        // Update the label with the count
                        provider_no_uc_label.Text = serviceProviderCount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (display or log the error)
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCustomerCountLabel()
        {
            try
            {
                // Establish a connection to the database
                string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Write the SQL query to count the number of "Admin" users
                    string query = "SELECT COUNT(*) FROM Users WHERE UserRole = 'Customer'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Execute the query and get the result
                        int customerCount = Convert.ToInt32(command.ExecuteScalar());

                        // Update the label with the count
                        customer_no_uc_label.Text = customerCount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (display or log the error)
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
