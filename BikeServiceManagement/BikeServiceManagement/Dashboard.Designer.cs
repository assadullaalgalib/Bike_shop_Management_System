namespace BikeServiceManagement
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            panelMenu = new Panel();
            stgbtn = new Button();
            lgoutbtn = new Button();
            crdtbtn = new Button();
            homebtn = new Button();
            panelUsername = new Panel();
            Cus_un_label = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            admin_pan = new Panel();
            button8 = new Button();
            button9 = new Button();
            button10 = new Button();
            button11 = new Button();
            button12 = new Button();
            panel4 = new Panel();
            label6 = new Label();
            label7 = new Label();
            pictureBox3 = new PictureBox();
            button13 = new Button();
            panelDesktop = new Panel();
            sup_admin_pan = new Panel();
            button7 = new Button();
            button6 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            panel2 = new Panel();
            label3 = new Label();
            label4 = new Label();
            pictureBox2 = new PictureBox();
            label15 = new Label();
            label5 = new Label();
            label2 = new Label();
            button1 = new Button();
            panelMenu.SuspendLayout();
            panelUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            admin_pan.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            sup_admin_pan.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(25, 35, 57);
            panelMenu.Controls.Add(stgbtn);
            panelMenu.Controls.Add(lgoutbtn);
            panelMenu.Controls.Add(crdtbtn);
            panelMenu.Controls.Add(homebtn);
            panelMenu.Controls.Add(panelUsername);
            panelMenu.Location = new Point(2, 60);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(209, 540);
            panelMenu.TabIndex = 1;
            panelMenu.Paint += panelMenu_Paint;
            // 
            // stgbtn
            // 
            stgbtn.BackColor = Color.FromArgb(25, 35, 57);
            stgbtn.BackgroundImageLayout = ImageLayout.None;
            stgbtn.FlatAppearance.BorderSize = 0;
            stgbtn.FlatStyle = FlatStyle.Flat;
            stgbtn.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            stgbtn.ForeColor = Color.FromArgb(187, 150, 132);
            stgbtn.Image = (Image)resources.GetObject("stgbtn.Image");
            stgbtn.Location = new Point(0, 183);
            stgbtn.Name = "stgbtn";
            stgbtn.Size = new Size(209, 43);
            stgbtn.TabIndex = 9;
            stgbtn.Text = "SETTINGS ";
            stgbtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            stgbtn.UseVisualStyleBackColor = false;
            stgbtn.Click += stgbtn_Click;
            // 
            // lgoutbtn
            // 
            lgoutbtn.BackColor = Color.FromArgb(25, 35, 57);
            lgoutbtn.BackgroundImageLayout = ImageLayout.None;
            lgoutbtn.FlatAppearance.BorderSize = 0;
            lgoutbtn.FlatStyle = FlatStyle.Flat;
            lgoutbtn.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            lgoutbtn.ForeColor = Color.FromArgb(187, 150, 132);
            lgoutbtn.Image = (Image)resources.GetObject("lgoutbtn.Image");
            lgoutbtn.Location = new Point(0, 495);
            lgoutbtn.Name = "lgoutbtn";
            lgoutbtn.Size = new Size(209, 43);
            lgoutbtn.TabIndex = 8;
            lgoutbtn.Text = "LOGOUT   ";
            lgoutbtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            lgoutbtn.UseVisualStyleBackColor = false;
            lgoutbtn.Click += lgoutbtn_Click;
            // 
            // crdtbtn
            // 
            crdtbtn.BackColor = Color.FromArgb(25, 35, 57);
            crdtbtn.BackgroundImageLayout = ImageLayout.None;
            crdtbtn.FlatAppearance.BorderSize = 0;
            crdtbtn.FlatStyle = FlatStyle.Flat;
            crdtbtn.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            crdtbtn.ForeColor = Color.FromArgb(187, 150, 132);
            crdtbtn.Image = (Image)resources.GetObject("crdtbtn.Image");
            crdtbtn.Location = new Point(0, 137);
            crdtbtn.Name = "crdtbtn";
            crdtbtn.Size = new Size(209, 43);
            crdtbtn.TabIndex = 7;
            crdtbtn.Text = "CREDIT    ";
            crdtbtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            crdtbtn.UseVisualStyleBackColor = false;
            crdtbtn.Click += crdtbtn_Click;
            // 
            // homebtn
            // 
            homebtn.BackColor = Color.FromArgb(25, 35, 57);
            homebtn.BackgroundImageLayout = ImageLayout.None;
            homebtn.FlatAppearance.BorderSize = 0;
            homebtn.FlatStyle = FlatStyle.Flat;
            homebtn.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            homebtn.ForeColor = Color.FromArgb(187, 150, 132);
            homebtn.Image = (Image)resources.GetObject("homebtn.Image");
            homebtn.Location = new Point(0, 91);
            homebtn.Name = "homebtn";
            homebtn.Size = new Size(209, 43);
            homebtn.TabIndex = 4;
            homebtn.Text = "HOME     ";
            homebtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            homebtn.UseVisualStyleBackColor = false;
            homebtn.Click += homebtn_Click;
            // 
            // panelUsername
            // 
            panelUsername.BackColor = Color.FromArgb(25, 35, 57);
            panelUsername.Controls.Add(Cus_un_label);
            panelUsername.Controls.Add(label1);
            panelUsername.Controls.Add(pictureBox1);
            panelUsername.Location = new Point(-1, 0);
            panelUsername.Name = "panelUsername";
            panelUsername.Size = new Size(209, 90);
            panelUsername.TabIndex = 3;
            panelUsername.Paint += panelUsername_Paint;
            // 
            // Cus_un_label
            // 
            Cus_un_label.AutoSize = true;
            Cus_un_label.FlatStyle = FlatStyle.Flat;
            Cus_un_label.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Cus_un_label.ForeColor = Color.WhiteSmoke;
            Cus_un_label.Location = new Point(76, 22);
            Cus_un_label.Name = "Cus_un_label";
            Cus_un_label.Size = new Size(71, 16);
            Cus_un_label.TabIndex = 6;
            Cus_un_label.Text = "Username";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.WhiteSmoke;
            label1.Location = new Point(76, 47);
            label1.Name = "label1";
            label1.Size = new Size(107, 16);
            label1.TabIndex = 5;
            label1.Text = "Customer Account";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(13, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(57, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // admin_pan
            // 
            admin_pan.BackColor = Color.FromArgb(25, 35, 57);
            admin_pan.Controls.Add(button8);
            admin_pan.Controls.Add(button9);
            admin_pan.Controls.Add(button10);
            admin_pan.Controls.Add(button11);
            admin_pan.Controls.Add(button12);
            admin_pan.Controls.Add(panel4);
            admin_pan.Controls.Add(button13);
            admin_pan.Location = new Point(0, 60);
            admin_pan.Name = "admin_pan";
            admin_pan.Size = new Size(209, 539);
            admin_pan.TabIndex = 12;
            // 
            // button8
            // 
            button8.BackColor = Color.FromArgb(25, 35, 57);
            button8.BackgroundImageLayout = ImageLayout.None;
            button8.FlatAppearance.BorderSize = 0;
            button8.FlatStyle = FlatStyle.Flat;
            button8.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            button8.ForeColor = Color.FromArgb(187, 150, 132);
            button8.Image = (Image)resources.GetObject("button8.Image");
            button8.Location = new Point(0, 229);
            button8.Name = "button8";
            button8.Size = new Size(209, 43);
            button8.TabIndex = 11;
            button8.Text = "READ       ";
            button8.TextImageRelation = TextImageRelation.TextBeforeImage;
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // button9
            // 
            button9.BackColor = Color.FromArgb(25, 35, 57);
            button9.BackgroundImageLayout = ImageLayout.None;
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Flat;
            button9.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            button9.ForeColor = Color.FromArgb(187, 150, 132);
            button9.Image = (Image)resources.GetObject("button9.Image");
            button9.Location = new Point(0, 137);
            button9.Name = "button9";
            button9.Size = new Size(209, 43);
            button9.TabIndex = 10;
            button9.Text = "CREATE   ";
            button9.TextImageRelation = TextImageRelation.TextBeforeImage;
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.FromArgb(25, 35, 57);
            button10.BackgroundImageLayout = ImageLayout.None;
            button10.FlatAppearance.BorderSize = 0;
            button10.FlatStyle = FlatStyle.Flat;
            button10.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            button10.ForeColor = Color.FromArgb(187, 150, 132);
            button10.Image = (Image)resources.GetObject("button10.Image");
            button10.Location = new Point(0, 275);
            button10.Name = "button10";
            button10.Size = new Size(209, 43);
            button10.TabIndex = 9;
            button10.Text = "SETTINGS  ";
            button10.TextImageRelation = TextImageRelation.TextBeforeImage;
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // button11
            // 
            button11.BackColor = Color.FromArgb(25, 35, 57);
            button11.BackgroundImageLayout = ImageLayout.None;
            button11.FlatAppearance.BorderSize = 0;
            button11.FlatStyle = FlatStyle.Flat;
            button11.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            button11.ForeColor = Color.FromArgb(187, 150, 132);
            button11.Image = (Image)resources.GetObject("button11.Image");
            button11.Location = new Point(0, 496);
            button11.Name = "button11";
            button11.Size = new Size(209, 43);
            button11.TabIndex = 8;
            button11.Text = "LOGOUT   ";
            button11.TextImageRelation = TextImageRelation.TextBeforeImage;
            button11.UseVisualStyleBackColor = false;
            button11.Click += button11_Click;
            // 
            // button12
            // 
            button12.BackColor = Color.FromArgb(25, 35, 57);
            button12.BackgroundImageLayout = ImageLayout.None;
            button12.FlatAppearance.BorderSize = 0;
            button12.FlatStyle = FlatStyle.Flat;
            button12.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            button12.ForeColor = Color.FromArgb(187, 150, 132);
            button12.Image = (Image)resources.GetObject("button12.Image");
            button12.Location = new Point(0, 183);
            button12.Name = "button12";
            button12.Size = new Size(209, 43);
            button12.TabIndex = 7;
            button12.Text = "UPDATE   ";
            button12.TextImageRelation = TextImageRelation.TextBeforeImage;
            button12.UseVisualStyleBackColor = false;
            button12.Click += button12_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(25, 35, 57);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(pictureBox3);
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(209, 90);
            panel4.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.FlatStyle = FlatStyle.Flat;
            label6.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.WhiteSmoke;
            label6.Location = new Point(76, 22);
            label6.Name = "label6";
            label6.Size = new Size(71, 16);
            label6.TabIndex = 6;
            label6.Text = "Username";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.FlatStyle = FlatStyle.Flat;
            label7.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.WhiteSmoke;
            label7.Location = new Point(76, 47);
            label7.Name = "label7";
            label7.Size = new Size(90, 16);
            label7.TabIndex = 5;
            label7.Text = "Admin Account";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.InitialImage = (Image)resources.GetObject("pictureBox3.InitialImage");
            pictureBox3.Location = new Point(13, 16);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(57, 50);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 3;
            pictureBox3.TabStop = false;
            // 
            // button13
            // 
            button13.BackColor = Color.FromArgb(25, 35, 57);
            button13.BackgroundImageLayout = ImageLayout.None;
            button13.FlatAppearance.BorderSize = 0;
            button13.FlatStyle = FlatStyle.Flat;
            button13.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            button13.ForeColor = Color.FromArgb(187, 150, 132);
            button13.Image = (Image)resources.GetObject("button13.Image");
            button13.Location = new Point(0, 91);
            button13.Name = "button13";
            button13.Size = new Size(209, 43);
            button13.TabIndex = 4;
            button13.Text = "HOME     ";
            button13.TextImageRelation = TextImageRelation.TextBeforeImage;
            button13.UseVisualStyleBackColor = false;
            button13.Click += button13_Click;
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.FromArgb(22, 30, 49);
            panelDesktop.Location = new Point(209, 60);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(691, 540);
            panelDesktop.TabIndex = 3;
            panelDesktop.Paint += panelDesktop_Paint;
            // 
            // sup_admin_pan
            // 
            sup_admin_pan.BackColor = Color.FromArgb(25, 35, 57);
            sup_admin_pan.Controls.Add(button7);
            sup_admin_pan.Controls.Add(button6);
            sup_admin_pan.Controls.Add(button2);
            sup_admin_pan.Controls.Add(button3);
            sup_admin_pan.Controls.Add(button4);
            sup_admin_pan.Controls.Add(button5);
            sup_admin_pan.Controls.Add(panel2);
            sup_admin_pan.Location = new Point(2, 60);
            sup_admin_pan.Name = "sup_admin_pan";
            sup_admin_pan.Size = new Size(209, 539);
            sup_admin_pan.TabIndex = 10;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(25, 35, 57);
            button7.BackgroundImageLayout = ImageLayout.None;
            button7.FlatAppearance.BorderSize = 0;
            button7.FlatStyle = FlatStyle.Flat;
            button7.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            button7.ForeColor = Color.FromArgb(187, 150, 132);
            button7.Image = (Image)resources.GetObject("button7.Image");
            button7.Location = new Point(0, 229);
            button7.Name = "button7";
            button7.Size = new Size(209, 43);
            button7.TabIndex = 11;
            button7.Text = "READ       ";
            button7.TextImageRelation = TextImageRelation.TextBeforeImage;
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(25, 35, 57);
            button6.BackgroundImageLayout = ImageLayout.None;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            button6.ForeColor = Color.FromArgb(187, 150, 132);
            button6.Image = (Image)resources.GetObject("button6.Image");
            button6.Location = new Point(0, 137);
            button6.Name = "button6";
            button6.Size = new Size(209, 43);
            button6.TabIndex = 10;
            button6.Text = "CREATE   ";
            button6.TextImageRelation = TextImageRelation.TextBeforeImage;
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(25, 35, 57);
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.FromArgb(187, 150, 132);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(0, 275);
            button2.Name = "button2";
            button2.Size = new Size(209, 43);
            button2.TabIndex = 9;
            button2.Text = "SETTINGS  ";
            button2.TextImageRelation = TextImageRelation.TextBeforeImage;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(25, 35, 57);
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.FromArgb(187, 150, 132);
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(0, 495);
            button3.Name = "button3";
            button3.Size = new Size(209, 43);
            button3.TabIndex = 8;
            button3.Text = "LOGOUT   ";
            button3.TextImageRelation = TextImageRelation.TextBeforeImage;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(25, 35, 57);
            button4.BackgroundImageLayout = ImageLayout.None;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.FromArgb(187, 150, 132);
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(0, 183);
            button4.Name = "button4";
            button4.Size = new Size(209, 43);
            button4.TabIndex = 7;
            button4.Text = "UPDATE   ";
            button4.TextImageRelation = TextImageRelation.TextBeforeImage;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(25, 35, 57);
            button5.BackgroundImageLayout = ImageLayout.None;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = Color.FromArgb(187, 150, 132);
            button5.Image = (Image)resources.GetObject("button5.Image");
            button5.Location = new Point(0, 91);
            button5.Name = "button5";
            button5.Size = new Size(209, 43);
            button5.TabIndex = 4;
            button5.Text = "HOME     ";
            button5.TextImageRelation = TextImageRelation.TextBeforeImage;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(25, 35, 57);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(pictureBox2);
            panel2.Location = new Point(-1, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(209, 90);
            panel2.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.WhiteSmoke;
            label3.Location = new Point(76, 22);
            label3.Name = "label3";
            label3.Size = new Size(71, 16);
            label3.TabIndex = 6;
            label3.Text = "Username";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.FlatStyle = FlatStyle.Flat;
            label4.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.WhiteSmoke;
            label4.Location = new Point(76, 47);
            label4.Name = "label4";
            label4.Size = new Size(124, 16);
            label4.TabIndex = 5;
            label4.Text = "Super Admin Account";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.InitialImage = (Image)resources.GetObject("pictureBox2.InitialImage");
            pictureBox2.Location = new Point(13, 16);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(57, 50);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.FlatStyle = FlatStyle.Flat;
            label15.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = Color.WhiteSmoke;
            label15.Location = new Point(57, 21);
            label15.Name = "label15";
            label15.RightToLeft = RightToLeft.No;
            label15.Size = new Size(99, 22);
            label15.TabIndex = 21;
            label15.Text = "NX Services";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Century Gothic", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.FromArgb(248, 177, 121);
            label5.Location = new Point(148, 8);
            label5.Name = "label5";
            label5.Size = new Size(23, 36);
            label5.TabIndex = 23;
            label5.Text = ".";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Pristina", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.FromArgb(248, 177, 121);
            label2.Location = new Point(8, 6);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(51, 49);
            label2.TabIndex = 22;
            label2.Text = "nx";
            // 
            // button1
            // 
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.FromArgb(187, 150, 132);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(874, -1);
            button1.Name = "button1";
            button1.Size = new Size(25, 28);
            button1.TabIndex = 24;
            button1.TextImageRelation = TextImageRelation.TextBeforeImage;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(33, 46, 74);
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(900, 600);
            Controls.Add(sup_admin_pan);
            Controls.Add(panelMenu);
            Controls.Add(admin_pan);
            Controls.Add(button1);
            Controls.Add(label15);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(panelDesktop);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Dashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "userDashboard";
            Load += CustomerDashboard_Load;
            panelMenu.ResumeLayout(false);
            panelUsername.ResumeLayout(false);
            panelUsername.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            admin_pan.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            sup_admin_pan.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panelMenu;
        private Panel panelUsername;
        private Label label1;
        private PictureBox pictureBox1;
        private Button homebtn;
        private Button lgoutbtn;
        private Panel panelDesktop;
        private Label label15;
        private Label label5;
        private Label label2;
        private Button button1;
        private Label Cus_un_label;
        private Panel sup_admin_pan;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Panel panel2;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox2;
        private Button button6;
        private Button button7;
        private Panel admin_pan;
        private Button button8;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button12;
        private Button button13;
        private Panel panel4;
        private Label label6;
        private Label label7;
        private PictureBox pictureBox3;
        private Button stgbtn;
        private Button crdtbtn;
    }
}