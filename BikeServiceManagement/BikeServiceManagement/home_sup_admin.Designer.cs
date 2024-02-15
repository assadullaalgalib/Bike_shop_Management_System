namespace BikeServiceManagement
{
    partial class home_sup_admin
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            customer_no_uc_label = new Label();
            label7 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            provider_no_uc_label = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // customer_no_uc_label
            // 
            customer_no_uc_label.AutoSize = true;
            customer_no_uc_label.FlatStyle = FlatStyle.Flat;
            customer_no_uc_label.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            customer_no_uc_label.ForeColor = Color.LightGray;
            customer_no_uc_label.Location = new Point(423, 133);
            customer_no_uc_label.Name = "customer_no_uc_label";
            customer_no_uc_label.Size = new Size(28, 28);
            customer_no_uc_label.TabIndex = 32;
            customer_no_uc_label.Text = "X";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.FlatStyle = FlatStyle.Flat;
            label7.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.LightGray;
            label7.Location = new Point(87, 132);
            label7.Name = "label7";
            label7.Size = new Size(347, 28);
            label7.TabIndex = 31;
            label7.Text = "Total Number of Customers : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(25, 35, 57);
            label4.Font = new Font("Century Gothic", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(187, 150, 132);
            label4.Location = new Point(14, 16);
            label4.Name = "label4";
            label4.Size = new Size(59, 19);
            label4.TabIndex = 34;
            label4.Text = "HOME";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(25, 35, 57);
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(691, 50);
            pictureBox1.TabIndex = 33;
            pictureBox1.TabStop = false;
            // 
            // provider_no_uc_label
            // 
            provider_no_uc_label.AutoSize = true;
            provider_no_uc_label.FlatStyle = FlatStyle.Flat;
            provider_no_uc_label.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            provider_no_uc_label.ForeColor = Color.LightGray;
            provider_no_uc_label.Location = new Point(496, 196);
            provider_no_uc_label.Name = "provider_no_uc_label";
            provider_no_uc_label.Size = new Size(28, 28);
            provider_no_uc_label.TabIndex = 36;
            provider_no_uc_label.Text = "X";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.LightGray;
            label2.Location = new Point(87, 196);
            label2.Name = "label2";
            label2.Size = new Size(420, 28);
            label2.TabIndex = 35;
            label2.Text = "Total Number of Service Providers : ";
            // 
            // home_sup_admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 30, 49);
            Controls.Add(provider_no_uc_label);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Controls.Add(customer_no_uc_label);
            Controls.Add(label7);
            Name = "home_sup_admin";
            Size = new Size(691, 540);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label customer_no_uc_label;
        private Label label7;
        private Label label4;
        private PictureBox pictureBox1;
        private Label provider_no_uc_label;
        private Label label2;
    }
}
