namespace BikeServiceManagement
{
    partial class read_sup_admin
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            addSrvcBtn = new Button();
            addUsrBtn = new Button();
            panel1 = new Panel();
            dltbtn = new Button();
            dataGridView1 = new DataGridView();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            dltbtn2 = new Button();
            dataGridView2 = new DataGridView();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
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
            label4.Size = new Size(53, 19);
            label4.TabIndex = 30;
            label4.Text = "READ";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(25, 35, 57);
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(691, 50);
            pictureBox1.TabIndex = 29;
            pictureBox1.TabStop = false;
            // 
            // addSrvcBtn
            // 
            addSrvcBtn.BackgroundImageLayout = ImageLayout.None;
            addSrvcBtn.Cursor = Cursors.Hand;
            addSrvcBtn.FlatStyle = FlatStyle.Flat;
            addSrvcBtn.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            addSrvcBtn.ForeColor = Color.DarkGray;
            addSrvcBtn.Location = new Point(169, 54);
            addSrvcBtn.Name = "addSrvcBtn";
            addSrvcBtn.Size = new Size(160, 23);
            addSrvcBtn.TabIndex = 34;
            addSrvcBtn.Text = "Service Details";
            addSrvcBtn.UseVisualStyleBackColor = true;
            addSrvcBtn.Click += addSrvcBtn_Click;
            // 
            // addUsrBtn
            // 
            addUsrBtn.BackgroundImageLayout = ImageLayout.None;
            addUsrBtn.Cursor = Cursors.Hand;
            addUsrBtn.FlatStyle = FlatStyle.Flat;
            addUsrBtn.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            addUsrBtn.ForeColor = Color.DarkGray;
            addUsrBtn.Location = new Point(3, 54);
            addUsrBtn.Name = "addUsrBtn";
            addUsrBtn.Size = new Size(160, 23);
            addUsrBtn.TabIndex = 33;
            addUsrBtn.Text = "User Details";
            addUsrBtn.UseVisualStyleBackColor = true;
            addUsrBtn.Click += UsrBtn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(dltbtn);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(4, 77);
            panel1.Name = "panel1";
            panel1.Size = new Size(685, 460);
            panel1.TabIndex = 36;
            // 
            // dltbtn
            // 
            dltbtn.BackColor = Color.FromArgb(248, 177, 121);
            dltbtn.BackgroundImageLayout = ImageLayout.None;
            dltbtn.Cursor = Cursors.Hand;
            dltbtn.FlatStyle = FlatStyle.Popup;
            dltbtn.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dltbtn.ForeColor = Color.FromArgb(22, 30, 49);
            dltbtn.Location = new Point(283, 312);
            dltbtn.Name = "dltbtn";
            dltbtn.Size = new Size(97, 28);
            dltbtn.TabIndex = 75;
            dltbtn.Text = "Delete";
            dltbtn.UseVisualStyleBackColor = false;
            dltbtn.Click += dltbtn_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(22, 30, 49);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Gainsboro;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Gainsboro;
            dataGridViewCellStyle2.Font = new Font("Lato Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.GridColor = Color.FromArgb(224, 224, 224);
            dataGridView1.Location = new Point(23, 36);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(633, 254);
            dataGridView1.TabIndex = 74;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.FromArgb(248, 177, 121);
            pictureBox2.Location = new Point(165, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(160, 3);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 15;
            pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(dltbtn2);
            panel2.Controls.Add(dataGridView2);
            panel2.Location = new Point(4, 77);
            panel2.Name = "panel2";
            panel2.Size = new Size(682, 457);
            panel2.TabIndex = 37;
            // 
            // dltbtn2
            // 
            dltbtn2.BackColor = Color.FromArgb(248, 177, 121);
            dltbtn2.BackgroundImageLayout = ImageLayout.None;
            dltbtn2.Cursor = Cursors.Hand;
            dltbtn2.FlatStyle = FlatStyle.Popup;
            dltbtn2.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            dltbtn2.ForeColor = Color.FromArgb(22, 30, 49);
            dltbtn2.Location = new Point(283, 260);
            dltbtn2.Name = "dltbtn2";
            dltbtn2.Size = new Size(97, 28);
            dltbtn2.TabIndex = 31;
            dltbtn2.Text = "Delete";
            dltbtn2.UseVisualStyleBackColor = false;
            dltbtn2.Click += dltbtn2_Click_1;
            // 
            // dataGridView2
            // 
            dataGridView2.BackgroundColor = Color.FromArgb(22, 30, 49);
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Gainsboro;
            dataGridViewCellStyle3.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Gainsboro;
            dataGridViewCellStyle4.Font = new Font("Lato Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.LightSteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridView2.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridView2.GridColor = Color.FromArgb(224, 224, 224);
            dataGridView2.Location = new Point(23, 27);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(626, 227);
            dataGridView2.TabIndex = 30;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.FromArgb(248, 177, 121);
            pictureBox3.Location = new Point(3, 77);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(160, 3);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 16;
            pictureBox3.TabStop = false;
            // 
            // read_sup_admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 30, 49);
            Controls.Add(pictureBox3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(addSrvcBtn);
            Controls.Add(addUsrBtn);
            Controls.Add(label4);
            Controls.Add(pictureBox1);
            Name = "read_sup_admin";
            Size = new Size(691, 540);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private PictureBox pictureBox1;
        private Button addSrvcBtn;
        private Button addUsrBtn;
        private Panel panel1;
        private PictureBox pictureBox2;
        private Button dltbtn;
        private DataGridView dataGridView1;
        private Panel panel2;
        private PictureBox pictureBox3;
        private DataGridView dataGridView2;
        private Button dltbtn2;
    }
}
