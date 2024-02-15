using BikeServiceManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeServiceManagement
{
    public partial class Dashboard : Form
    {

        public string? LoggedInUsername { get; private set; }

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


        public Dashboard()
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

            LoggedInUsername = GetLoggedInUsername();
            Cus_un_label.Text = LoggedInUsername;
            label3.Text = LoggedInUsername;
            label6.Text = LoggedInUsername;

            // Check user role and set panel visibility
            string userRole = GetUserRole(LoggedInUsername);
            switch (userRole)
            {
                case "Customer":
                    panelMenu.Visible = true;
                    admin_pan.Visible = false;
                    sup_admin_pan.Visible = false;

                    break;

                case "Admin":
                    panelMenu.Visible = false;
                    admin_pan.Visible = true;
                    sup_admin_pan.Visible = false;

                    break;

                case "SuperAdmin":
                    panelMenu.Visible = false;
                    admin_pan.Visible = false;
                    sup_admin_pan.Visible = true;

                    break;

                default:
                    // Handle any other cases or set a default visibility
                    break;
            }
        }

        private string GetUserRole(string username)
        {
            // Initialize the result variable
            string userRole = "Default"; // Set a default value

            // Establish a connection to the database
            string connectionString = @"Data Source=DESKTOP-H9MPPVO\SQLEXPRESS;Initial Catalog=BikeServiceManagementDB;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Write the SQL query to select the UserRole from Users table based on the Username
                    string query = "SELECT UserRole FROM Users WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@Username", username);

                        // Execute the query and get the result
                        object result = command.ExecuteScalar();

                        // Check if the result is not null
                        if (result != null)
                        {
                            userRole = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // Return the result
            return userRole;
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panelTitle_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTitlebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelUsername_Paint(object sender, PaintEventArgs e)
        {
            /*panelTitle.Visible = true;
            panelTitlebar.Visible = true;
            panelMenu.Visible = true;
            panelUsername.Visible = true;
            panelDesktop.Visible = true;*/
        }

        private void homebtn_Click(object sender, EventArgs e)
        {
            // Create an instance of your user control
            home_cus homeCusControl = new home_cus();

            // Add the user control to the panelDesktop (assuming panelDesktop is the container for user controls)
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(homeCusControl);

            // Optionally, you can set the Dock property of the user control to fill the panelDesktop
            //homeCusControl.Dock = DockStyle.Fill;
        }

        private void hstrbtn_Click(object sender, EventArgs e)
        {
        }

        private void srvcbtn_Click(object sender, EventArgs e)
        {
        }

        private void crdtbtn_Click(object sender, EventArgs e)
        {
            credit_cus creditCusControl = new credit_cus();

            // Add the user control to the panelDesktop (assuming panelDesktop is the container for user controls)
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(creditCusControl);

        }

        private void stgbtn_Click(object sender, EventArgs e)
        {
            settings_cus settingsCusControl = new settings_cus();

            // Add the user control to the panelDesktop (assuming panelDesktop is the container for user controls)
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(settingsCusControl);
        }

        private void lgoutbtn_Click(object sender, EventArgs e)
        {
            deleteLoginInfo();
            this.Hide();

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
            deleteLoginInfo();
        }

        private void CustomerDashboard_Load(object sender, EventArgs e)
        {

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e) // Admin Home
        {
            // Create an instance of your user control
            home_admin homeAdminControl = new home_admin();

            // Add the user control to the panelDesktop (assuming panelDesktop is the container for user controls)
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(homeAdminControl);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            deleteLoginInfo();
            this.Hide();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            deleteLoginInfo();



        }

        private void button10_Click(object sender, EventArgs e)
        {
            settings_cus settingsCusControl = new settings_cus();

            // Add the user control to the panelDesktop (assuming panelDesktop is the container for user controls)
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(settingsCusControl);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Create an instance of your user control
            create_admin createAdminControl = new create_admin();

            // Add the user control to the panelDesktop (assuming panelDesktop is the container for user controls)
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(createAdminControl);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Create an instance of your user control
            update_admin updateAdminControl = new update_admin();

            // Add the user control to the panelDesktop (assuming panelDesktop is the container for user controls)
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(updateAdminControl);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Create an instance of your user control
            create_sup_admin createSupAdminControl = new create_sup_admin();

            // Add the user control to the panelDesktop (assuming panelDesktop is the container for user controls)
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(createSupAdminControl);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Create an instance of your user control
            update_sup_admin updateSupAdminControl = new update_sup_admin();

            // Add the user control to the panelDesktop (assuming panelDesktop is the container for user controls)
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(updateSupAdminControl);
        }

        private void button8_Click(object sender, EventArgs e)  //Admin read
        {
            // Create an instance of your user control
            read_admin readAdminControl = new read_admin();

            // Add the user control to the panelDesktop (assuming panelDesktop is the container for user controls)
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(readAdminControl);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Create an instance of your user control
            read_sup_admin readSupAdminControl = new read_sup_admin();

            // Add the user control to the panelDesktop (assuming panelDesktop is the container for user controls)
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(readSupAdminControl);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            settings_cus settingsCusControl = new settings_cus();

            // Add the user control to the panelDesktop (assuming panelDesktop is the container for user controls)
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(settingsCusControl);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            home_sup_admin homeSupAdminControl = new home_sup_admin();

            // Add the user control to the panelDesktop (assuming panelDesktop is the container for user controls)
            panelDesktop.Controls.Clear();
            panelDesktop.Controls.Add(homeSupAdminControl);
        }
    }
}


