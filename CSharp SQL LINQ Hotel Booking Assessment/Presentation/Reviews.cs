using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp_SQL_LINQ_Hotel_Booking_Assessment.Presentation;

namespace CSharp_SQL_LINQ_Hotel_Booking_Assessment.Resources
{
    public partial class Reviews : Form
    {
        public Reviews()
        {
            InitializeComponent();
        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            lbxYourReviews.Items.Add(txtReview.Text);
        }

        private void Reviews_Load(object sender, EventArgs e)
        {

        }

        private void lbxYourReviews_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReview_Click_1(object sender, EventArgs e)
        {
            lbxYourReviews.Items.Add(txtReview.Text);
        }

        private void bntLeave_Click(object sender, EventArgs e)
        {
            Leave Leave = new Leave();
            Leave.Show();
            this.Close();
          

        }
    }
}
