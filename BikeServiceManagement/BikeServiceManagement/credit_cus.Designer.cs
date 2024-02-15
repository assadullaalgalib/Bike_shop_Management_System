namespace BikeServiceManagement
{
    partial class credit_cus
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
            label4 = new Label();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            credit_uc_label = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(25, 35, 57);
            label4.Font = new Font("Century Gothic", 12.75F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.FromArgb(187, 150, 132);
            label4.Location = new Point(14, 16);
            label4.Name = "label4";
            label4.Size = new Size(65, 19);
            label4.TabIndex = 26;
            label4.Text = "CREDIT";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(25, 35, 57);
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(691, 50);
            pictureBox1.TabIndex = 25;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.FlatStyle = FlatStyle.Flat;
            label7.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.LightGray;
            label7.Location = new Point(145, 166);
            label7.Name = "label7";
            label7.Size = new Size(278, 28);
            label7.TabIndex = 27;
            label7.Text = "Your Current Credit is $";
            // 
            // credit_uc_label
            // 
            credit_uc_label.AutoSize = true;
            credit_uc_label.FlatStyle = FlatStyle.Flat;
            credit_uc_label.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point);
            credit_uc_label.ForeColor = Color.LightGray;
            credit_uc_label.Location = new Point(419, 167);
            credit_uc_label.Name = "credit_uc_label";
            credit_uc_label.Size = new Size(97, 28);
            credit_uc_label.TabIndex = 28;
            credit_uc_label.Text = "\"credit\"";
            // 
            // credit_cus
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 30, 49);
            Controls.Add(credit_uc_label);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Name = "credit_cus";
            Size = new Size(691, 540);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private PictureBox pictureBox1;
        private Label label7;
        private Label credit_uc_label;
    }
}
