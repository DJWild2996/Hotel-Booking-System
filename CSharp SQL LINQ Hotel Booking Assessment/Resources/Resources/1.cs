using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharp_SQL_LINQ_Hotel_Booking_Assessment.Presentation;
using CSharp_SQL_LINQ_Hotel_Booking_Assessment.Resources;

namespace CSharp_SQL_LINQ_Hotel_Booking_Assessment
{

    public partial class MainForm : Form
    {

        public int SingleRoomPrice;
        public int DoubleRoomPrice;
        public int ExtraRoomPrice;
        public int ExtraPerson;



     
        public MainForm()
        {
            InitializeComponent();
            GuestInfo();
            RoomInfo();
            CheckINInfo();
           
        }
       


        public void GuestInfo()
        {
            using (var context = new WorstEverHotelEntities2())
            {
                var alldata = from c in context.Guests
                              select new
                              {
                                  c.GuestID,
                                  c.Name,
                                  c.Address,
                                  c.ContactNumber,
                                  c.NumberOfGuests

                              };

                  
            }
        }

        private void RoomInfo()
        {
            using (var context = new WorstEverHotelEntities2())
            {
                var alldata = from c in context.Rooms
                    select new
                    {
                        c.RoomID,
                        c.SingleBeds_,
                        c.DoubleBeds_,
                        c.ExtraFeatures,
                        c.SinglePerson,
                        c.C2People,
                        c.ExtraPeople,
                        c.DateBookedFrom,
                        c.DateBookedTill,
                        c.RoomCapacity
                    };
                //dataGridViewRooms.DataSource = alldata.ToList();
            }
        }

        private void CheckINInfo()
        {
            using (var context = new WorstEverHotelEntities2())
            {
                var alldata = from c in context.Guests
                    select new
                    {
                        c.GuestID,
                        c.Name,
                        c.Address,
                        c.ContactNumber,
                        c.NumberOfGuests,
                        c.RoomBooked,
                        c.BooklingDate,
                        c.CheckIn,
                        c.CheckOut,
                        c.Price,
                        c.Meals,
                        c.Activities,
                        c.Vehiclals
                    };
                //dataGridViewCheckINOUT.DataSource = alldata.ToList();

            }
        }

        public void AddGuest()
        {
            using (var context = new WorstEverHotelEntities2())
            {
                var contact = new Guest();
                contact.Name = txtName.Text;
                contact.Address = txtAddress.Text;
                contact.ContactNumber = Convert.ToInt32(txtContactNumber.Text);
                contact.NumberOfGuests = Convert.ToInt32(txtGuestNumbers.Text);
                contact.Status = false;
                context.Guests.Add(contact);
                context.SaveChanges();

                ClearTextBoxes();
            }
        }


        public void btnAddInfo_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" && txtAddress.Text == "" && txtContactNumber.Text == "" && txtGuestNumbers.Text == "")
            {
                MessageBox.Show("Please fillout all the text boxes");
            }
            else
            {
                AddGuest();
                
            }
            
        }

        private void ClearTextBoxes()
        {
            
            txtName.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtContactNumber.Text = String.Empty;
            txtGuestNumbers.Text = String.Empty;
            txtID.Text = String.Empty;
        }

        private void dataGridViewGuests_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridViewGuests.Rows[rowIndex];
            txtName.Text = row.Cells[1].Value.ToString();
            txtAddress.Text = row.Cells[2].Value.ToString();
            txtContactNumber.Text = row.Cells[3].Value.ToString();
            txtGuestNumbers.Text = row.Cells[4].Value.ToString();
            txtID.Text = row.Cells[0].Value.ToString();
        }

        private void UpdateInfo()
        {
            using (var context = new WorstEverHotelEntities2())
            {
                int id = Convert.ToInt32(txtID.Text);
                var query = from s in context.Guests where s.GuestID == id select s;
                var guest = query.FirstOrDefault();
                guest.Name = txtName.Text;
                guest.Address = txtAddress.Text;
                guest.ContactNumber = Convert.ToInt32(txtContactNumber.Text);
                guest.NumberOfGuests = Convert.ToInt32(txtGuestNumbers.Text);
                context.SaveChanges();
                ClearTextBoxes();
            }
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        private void DeleteInfo()
        {
            string ID = txtID.Text;
            string name = txtName.Text;
            if (MessageBox.Show("Do you REALLY want to delete " + name + " from the guest database?", "Delete Record", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                using (var context = new WorstEverHotelEntities2())
                {
                    int id = Convert.ToInt32(txtID.Text);
                    var contact = (from s in context.Guests where s.GuestID == id select s).SingleOrDefault();
                    context.Guests.Remove(contact);
                    context.SaveChanges();
                    ClearTextBoxes();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured");
                throw;
            }
        }





        private void txtDelete_Click(object sender, EventArgs e)
        {
            DeleteInfo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GuestInfo();
        }

        public void AddBooking()
        {

            using (var context = new WorstEverHotelEntities2())
            {
                var contact = new Guest();
                contact.Name = txtName.Text;
                contact.Address = txtAddress.Text;
                contact.ContactNumber = Convert.ToInt32(txtContactNumber.Text);
                contact.NumberOfGuests = Convert.ToInt32(txtGuestNumbers.Text);
                contact.RoomBooked = Convert.ToInt32(txtRoomNumber.Text);
                contact.CheckIn = dateTimePickerArrive.Value;
                contact.CheckOut = dateTimePickerLeave.Value;
                contact.BooklingDate = DateTime.Today;
                contact.Price = Convert.ToInt32(txtPrice.Text);
                contact.Meals = Convert.ToInt32(txtMealPrice.Text);
                contact.Activities = Convert.ToInt32(txtActivPrice.Text);
                contact.Vehiclals = Convert.ToInt32(txtvehicleprice.Text);
                context.Guests.Add(contact);
                context.SaveChanges();


            }
            
        }

        private void UpdateBooking()
        {
            using (var context = new WorstEverHotelEntities2())
            {
                int id = Convert.ToInt32(txtRoomNumber.Text);
                var query = from s in context.Rooms where s.RoomID == id select s;
                var rooms = query.FirstOrDefault();
                rooms.DateBookedFrom = dateTimePickerArrive.Value;
                rooms.DateBookedTill = dateTimePickerLeave.Value;
                context.SaveChanges();
                ClearTextBoxes();
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
          AddBooking();
          UpdateBooking();
        }

        public void dataGridViewRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowIndex = e.RowIndex;
            int Numbers = Convert.ToInt32(txtGuestNumbers.Text);
            //int ExtraPerson;
            DataGridViewRow row = dataGridViewRooms.Rows[rowIndex];
            txtRoomNumber.Text = row.Cells[0].Value.ToString();
            //lblRoomsNumber.Text = row.Cells[0].Value.ToString();
            lblName.Text = txtName.Text + " " + "books room number" + " " + row.Cells[0].Value.ToString() + " " + "for" +" " + txtGuestNumbers.Text + " " + "people";
            if (Numbers == 1)
            {
                 SingleRoomPrice = Convert.ToInt32(row.Cells[4].Value);

                lblName.Text = txtName.Text + " " + "books room number" + " " + row.Cells[0].Value.ToString() + " " + "for" + " " + txtGuestNumbers.Text + " " + "person";
                lblPrices.Text = "at" + "$" + row.Cells[4].Value.ToString() + " per night";
                txtPrice.Text = SingleRoomPrice.ToString();
            }
            if (Numbers == 2)
            {
                DoubleRoomPrice = Convert.ToInt32(row.Cells[5].Value);

                lblPrices.Text = "at" + "$" + row.Cells[5].Value.ToString() + " per night";
                txtPrice.Text = DoubleRoomPrice.ToString();
            }
            if (Numbers >= 3)
            {
                ExtraRoomPrice = Convert.ToInt32(row.Cells[6].Value);

                lblPrices.Text = "at" + " " + "$" + row.Cells[5].Value.ToString() + " " + "+" + " " + "$" + row.Cells[6].Value.ToString() + " " + "per extra guest" + " " + " per night";
                int DoublePerson = Convert.ToInt32(row.Cells[4].Value);
                int Morepeople = Convert.ToInt32(row.Cells[5].Value);
                ExtraPerson = DoublePerson + Morepeople;
                txtPrice.Text = Convert.ToString(ExtraPerson);
            }

            int GuestNumbers = Convert.ToInt32(txtGuestNumbers.Text);
            int RoomCapacity = Convert.ToInt32(row.Cells[9].Value);
            int Difference = GuestNumbers - RoomCapacity;

                if ( dateTimePickerArrive.Value >= Convert.ToDateTime(row.Cells[7].Value) && dateTimePickerLeave.Value <= Convert.ToDateTime(row.Cells[8].Value))
                {
                    
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    MessageBox.Show("Sorry this room is not available on these dates please choose a different room");
                    btnBook.Enabled = false;
                }
            else if (GuestNumbers > RoomCapacity)
            {
                row.DefaultCellStyle.BackColor = Color.DarkBlue;
                row.DefaultCellStyle.ForeColor = Color.White;
                MessageBox.Show("You have too many guests for this room" + " " + Difference + " " + " people have to go into a different room." );
               // btnBook.Enabled = false;

                using (var context = new WorstEverHotelEntities2())
                {
                    var contact = new Guest();
                    contact.Name = txtName.Text + " " + "Extra People";
                    contact.Address = txtAddress.Text;
                    contact.ContactNumber = Convert.ToInt32(txtContactNumber.Text);
                    contact.NumberOfGuests = Difference;
                    contact.RoomBooked = Convert.ToInt32(txtRoomNumber.Text) + 1;
                    contact.CheckIn = dateTimePickerArrive.Value;
                    contact.CheckOut = dateTimePickerLeave.Value;
                    contact.BooklingDate = DateTime.Today;
                    contact.Price = Convert.ToInt32(txtPrice.Text);
                    context.Guests.Add(contact);
                    context.SaveChanges();


                }
            }
            else
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    MessageBox.Show("This room is available");
                    btnBook.Enabled = true;
                }
        }


        private void btnCheckIN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to the Sunshine Hotel");
        }

        public void btnAddUpCost_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtWIFI.Text == " " || txtPhone.Text == " " || txtBar.Text == " ")
            //    {
            //        MessageBox.Show("Here is your final bill");
                    RoomPrice();
            //    }
            //    else
            //    {
            //        RoomPrice();

            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Please fill all text boxes with a number");
            //    throw;
            //}

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to write us a review of how your stay with us was?" , "Please Give Us your FeedBack!", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            else
            {
                MessageBox.Show("Thank you for staying at the SunShine Hotel please come again!");
            }
            try
            {
                Reviews MyReviews = new Reviews();
                MyReviews.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured");
                throw;
            }
            using (var context = new WorstEverHotelEntities2())
            {
                int id = Convert.ToInt32(TXTCheckOutID.Text);
                var contact = (from s in context.Guests where s.GuestID == id select s).SingleOrDefault();
                context.Guests.Remove(contact);
                context.SaveChanges();
            }


        }

        private void btnViewBooking_Click(object sender, EventArgs e)
        {
            CheckINInfo();
            RoomInfo();
        }

        public void RoomPrice ()
        {
            int Price = Convert.ToInt32(txtPrice.Text);

            int WIFICost = Convert.ToInt32(txtWIFI.Text);
            int PhoneCost = Convert.ToInt32(txtPhone.Text);
            int BarCost = Convert.ToInt32(txtBar.Text);
           // int MealCost = Convert.ToInt32(txtMealPrice.Text);
            int VeclCost = Convert.ToInt32(txtVehicle.Text);


            TimeSpan difference = dateTimePickerLeave.Value - dateTimePickerArrive.Value;
            int days = difference.Days;
            int RoomCharge = Price * days ;
            string MYStay = days.ToString();

            lblNumberDaysBooked.Text = "Customer Stayed for:" + MYStay + " " + "days";
            lblNumberDaysOverStayed.Text = String.Empty;
           // int MyPrice = RoomCharge * days;
            lblRoomsPrice.Text = "Your price for your room is:" + " " + "$" + txtPrice.Text;
            int TotalCost = RoomCharge + WIFICost + PhoneCost + BarCost;
            lblTotalCharge.Text = "$" + TotalCost.ToString();

            if (DateTime.Today > dateTimePickerLeave.Value)
            {
                TimeSpan OverStay = DateTime.Today - dateTimePickerLeave.Value;
                int OverStayCost = OverStay.Days;
              //  int AddOnPrice = OverStayCost*Price;
               // string FullOverStayCost = (OverStayCost - MYCharge).ToString();
                string MyOverStayCost = OverStayCost.ToString();
                lblNumberDaysOverStayed.Text = "Customer OverStayed for:" + MyOverStayCost + " " + "days";
                int OverStayTotalCost = RoomCharge + WIFICost + PhoneCost + BarCost + VeclCost * OverStayCost;
                lblTotalCharge.Text = OverStayTotalCost.ToString();
            }
        }

        private void dataGridViewCheckINOUT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridViewCheckINOUT.Rows[rowIndex];
          //  RoomPrice();
            txtFood.Text = row.Cells[10].Value.ToString();
            txtActivityPrice.Text = row.Cells[11].Value.ToString();
            txtVehicle.Text = row.Cells[12].Value.ToString();
            TXTCheckOutID.Text = row.Cells[0].Value.ToString();
            txtPrice.Text = row.Cells[9].Value.ToString();
            dateTimePickerArrive.Value = Convert.ToDateTime(row.Cells[7].Value);
            dateTimePickerLeave.Value = Convert.ToDateTime(row.Cells[8].Value);

                if (DateTime.Today == dateTimePickerArrive.Value)
                {
                    btnCheckIN.Enabled = true;
                    row.DefaultCellStyle.BackColor = Color.Green;
                    row.DefaultCellStyle.ForeColor = Color.White;
                MessageBox.Show(row.Cells[1].Value.ToString() + " " + "can check in now");
            }
            else if (DateTime.Today > dateTimePickerArrive.Value && DateTime.Today < dateTimePickerLeave.Value)
            {
                row.DefaultCellStyle.BackColor = Color.Lime;
                row.DefaultCellStyle.ForeColor = Color.Black;
                MessageBox.Show(row.Cells[1].Value.ToString() + " " + "you are late to check in ");
             //   btnCheckIN.Enabled = Enabled;

            }
            else if (DateTime.Today == dateTimePickerLeave.Value)
            {
                row.DefaultCellStyle.BackColor = Color.DarkBlue;
                row.DefaultCellStyle.ForeColor = Color.White;
                MessageBox.Show(row.Cells[1].Value.ToString() + " " + "today is your check out date please have your total cost added up and then check out ");
                btnCheckIN.Enabled = false;

            }
            else if (DateTime.Today > dateTimePickerLeave.Value)
            {
                row.DefaultCellStyle.BackColor = Color.Red;
                row.DefaultCellStyle.ForeColor = Color.Black;
                MessageBox.Show(row.Cells[1].Value.ToString() + " " + "you are overdue for your check out please pay your bill and leave now ");
                btnCheckIN.Enabled = false;
            }
            else if (DateTime.Today < dateTimePickerArrive.Value)
            {
                MessageBox.Show(row.Cells[1].Value.ToString() + " " + "can not check in till: " + " " + row.Cells[7].Value.ToString() + " " + "come back them.");
                btnCheckIN.Enabled = false;
                row.DefaultCellStyle.BackColor = Color.Gold;
                row.DefaultCellStyle.ForeColor = Color.Black;
                btnCheckIN.Enabled = false;
            }
 

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void PBRoom1_Click(object sender, EventArgs e)
        {
            Room_1 room1 = new Room_1();
            room1.Show();
        }

        private void PBRoom2_Click(object sender, EventArgs e)
        {
            Room_2 room2 = new Room_2();
            room2.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tabPageRooms_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void PBRoom3_Click(object sender, EventArgs e)
        {
            Room_3 room3 = new Room_3();
            room3.Show();
        }

        private void PBRoom4_Click(object sender, EventArgs e)
        {
            Room_4 room4 = new Room_4();
            room4.Show();
        }

        private void PBRoom5_Click(object sender, EventArgs e)
        {
            Room_5 room5 = new Room_5();
            room5.Show();
        }

        private void PBRoom6_Click(object sender, EventArgs e)
        {
            Room_6 room6 = new Room_6();
            room6.Show();
        }

        private void PBRoom7_Click(object sender, EventArgs e)
        {
            Room_7 room7 = new Room_7();
            room7.Show();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            MyMeal.Items.Add(checkedListBox1.Text);
        }

        private void btnTotalfood_Click(object sender, EventArgs e)
        {
            int MealPrice = MyMeal.Items.Count*100;
            txtMealPrice.Text = MealPrice.ToString();
        }

        private void MyMeal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnOrderthing_Click(object sender, EventArgs e)
        {
            MyActivities.Items.Add(checkedListBox2.Text);
        }

        private void btnTotalThings_Click(object sender, EventArgs e)
        {
            int ActviPrice = MyActivities.Items.Count * 100;
            txtActivPrice.Text = ActviPrice.ToString();
        }

        private void btnActivityPrice_Click(object sender, EventArgs e)
        {
            txtActivityPrice.Text = txtActivPrice.Text;
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            txtFood.Text = txtMealPrice.Text;
        }

        private void txtActivityPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnVehicleOrder_Click(object sender, EventArgs e)
        {
            VehicleOrders.Items.Add(checkedListBox3.Text);
            dateTimePickerFrom.Value = dateTimePickerArrive.Value;
            dateTimePickerUntil.Value = dateTimePickerLeave.Value;
        }

        private void btnTotalVehicle_Click(object sender, EventArgs e)
        {
            int VehiclPrice = VehicleOrders.Items.Count * 1000;
            txtvehicleprice.Text = VehiclPrice.ToString();
        }

        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            txtVehicle.Text = txtvehicleprice.Text;
        }

        private void txtVehicle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


