namespace CSharp_SQL_LINQ_Hotel_Booking_Assessment.Presentation
{
    partial class Leave
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
            this.pictureBox21 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox21
            // 
            this.pictureBox21.Image = global::CSharp_SQL_LINQ_Hotel_Booking_Assessment.Properties.Resources.check_out;
            this.pictureBox21.Location = new System.Drawing.Point(-6, 1);
            this.pictureBox21.Name = "pictureBox21";
            this.pictureBox21.Size = new System.Drawing.Size(879, 636);
            this.pictureBox21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox21.TabIndex = 27;
            this.pictureBox21.TabStop = false;
            // 
            // Leave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 634);
            this.Controls.Add(this.pictureBox21);
            this.Name = "Leave";
            this.Text = "Leave";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox21;
    }
}