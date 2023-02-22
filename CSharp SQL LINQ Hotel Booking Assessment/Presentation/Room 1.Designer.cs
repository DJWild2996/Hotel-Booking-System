namespace CSharp_SQL_LINQ_Hotel_Booking_Assessment.Resources
{
    partial class Room_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Room_1));
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PBRoom1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBRoom1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-1, 478);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(419, 67);
            this.label6.TabIndex = 9;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 549);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "tripadvisor rating";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CSharp_SQL_LINQ_Hotel_Booking_Assessment.Properties.Resources._4_Stars;
            this.pictureBox2.Location = new System.Drawing.Point(167, 548);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(125, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // PBRoom1
            // 
            this.PBRoom1.Image = global::CSharp_SQL_LINQ_Hotel_Booking_Assessment.Properties.Resources.room_8;
            this.PBRoom1.Location = new System.Drawing.Point(2, 125);
            this.PBRoom1.Name = "PBRoom1";
            this.PBRoom1.Size = new System.Drawing.Size(416, 350);
            this.PBRoom1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PBRoom1.TabIndex = 8;
            this.PBRoom1.TabStop = false;
            this.PBRoom1.Click += new System.EventHandler(this.PBRoom1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CSharp_SQL_LINQ_Hotel_Booking_Assessment.Properties.Resources.sign;
            this.pictureBox1.Location = new System.Drawing.Point(2, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(416, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // Room_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 563);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PBRoom1);
            this.Name = "Room_1";
            this.Text = "Room_1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PBRoom1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PBRoom1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}