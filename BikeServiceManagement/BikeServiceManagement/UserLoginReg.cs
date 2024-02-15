using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BikeServiceManagement
{
    public partial class UserLoginReg : Form
    {
        private bool Drag;
        private int MouseX;
        private int MouseY;

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        private bool m_aeroEnabled;

        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [DllImport("dwmapi.dll")]

        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        public UserLoginReg()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 8, 8));

            this.MouseDown += PanelMove_MouseDown;
            this.MouseMove += PanelMove_MouseMove;
            this.MouseUp += PanelMove_MouseUp;

            // Add shadow effect
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            MARGINS margins = new MARGINS() { leftWidth = 10, rightWidth = 10, topHeight = 10, bottomHeight = 10 };
            DwmExtendFrameIntoClientArea(this.Handle, ref margins);

            m_aeroEnabled = CheckAeroEnabled();

            // Home button
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            // Join button
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            // Login panel visible
            LoginPan.Visible = true;
            regpan.Visible = false;

        }

        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0; DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 0
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT) m.Result = (IntPtr)HTCAPTION;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(0, Color.Black)))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void PanelMove_MouseDown(object sender, MouseEventArgs e)
        {
            Drag = true;
            MouseX = Cursor.Position.X - this.Left;
            MouseY = Cursor.Position.Y - this.Top;
        }

        private void PanelMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (Drag)
            {
                this.Top = Cursor.Position.Y - MouseY;
                this.Left = Cursor.Position.X - MouseX;
            }
        }

        private void PanelMove_MouseUp(object sender, MouseEventArgs e)
        {
            Drag = false;
        }

        public void UserLoginReg_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void usernametxtbx_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            regpan.Visible = false;
            LoginPan.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginPan.Visible = false;
            regpan.Visible = true;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void regpan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoginPan_Paint(object sender, PaintEventArgs e)
        {

        }

        private void reg_pan_login_btn_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_pan_reg_btn_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginPan_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {
            LoginPan.Visible = false;
            regpan.Visible = true;

        }

        private void label21_Click(object sender, EventArgs e)
        {
            regpan.Visible = false;
            LoginPan.Visible = true;
        }

        // Function to validate email format
        private bool IsValidEmail(string email)
        {
            // This is a simple email format validation.
            // You might want to use a more sophisticated validation method in a real-world application.
            return email.Contains("@gmail.com");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility
            passtxtbx.UseSystemPasswordChar = !checkBox2.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle password visibility
            passtxtbx.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void updateLoginInfo(string loginUsername)
        {
            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to insert data into the table
                    string query = "INSERT INTO LoginInfo (Username) " +
                                   "VALUES (@Username)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query to prevent SQL injection
                        command.Parameters.AddWithValue("@Username", loginUsername);

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

        private void deleteLoginInfo()
        {
            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to delete all data from the table
                    string query = "DELETE FROM LoginInfo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
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

        private void button3_Click_1(object sender, EventArgs e)    // Login Button
        {
            string enteredUsername = usernametxtbx.Text;
            string enteredPassword = passtxtbx.Text;


            // Validate input
            if (string.IsNullOrWhiteSpace(enteredUsername) || string.IsNullOrWhiteSpace(enteredPassword))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // Query the database to check credentials
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to check login credentials with case sensitivity
                    string query = "SELECT * FROM Users WHERE Username COLLATE Latin1_General_CS_AS = @Username AND Password = @Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@Username", enteredUsername);
                        command.Parameters.AddWithValue("@Password", enteredPassword);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                MessageBox.Show("Login successful!");
                                updateLoginInfo(enteredUsername);

                                // Open the CustomerDashboard form
                                Dashboard customerDashboardForm = new Dashboard();
                                this.Hide();
                                customerDashboardForm.ShowDialog(); // Use ShowDialog to make it a modal form

                                // Close the login form when the dashboard form is closed
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.");
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


        private void button4_Click_2(object sender, EventArgs e)    // Join Button
        {


            // Get user input from textboxes
            string firstName = fntxtbx.Text;
            string lastName = lntxtbx.Text;
            string username = textBox4.Text;
            string email = emtxtbx.Text;
            string password = textBox3.Text;
            string confirmPassword = textBox6.Text;
            string userRole = "Customer";
            double credit = 1000.00;

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

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
            deleteLoginInfo();
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                passtxtbx.PasswordChar = '\0';
            }
            else
            {
                passtxtbx.PasswordChar = '•';
            }
        }
    }
}
