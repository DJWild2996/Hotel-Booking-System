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
using CSharp_SQL_LINQ_Hotel_Booking_Assessment.Resources;

namespace CSharp_SQL_LINQ_Hotel_Booking_Assessment
{
    public partial class Form1 : Form
    {
        // LOADS THE DATA BASE INTO THE DATAGRIDVIEWS ON START UP
        public Form1()
        {
            InitializeComponent();
            GuestInfo();
            RoomInfo();
            CheckINInfo();
        }

        private void PBbackground_Click(object sender, EventArgs e)
        {

        }
        //CALLS IN THE DATABASE CALLS CLASS
        DataBaseCalls Calls = new DataBaseCalls();
        // LOADS THE GUEST INFO FROM THE DATABASE INTO THE DATAGRIDVIEW
        public void GuestInfo()
        {
            Calls.GuestInformation();
        }
        //LOADS THE ROOM INFO FROM THE DATABASE INTO ITS DATAGRID VIEW
        private void RoomInfo()
        {
            Calls.RoomInformation();
        }
        //LOADS THE GUEST INFO, ROOM DATES AND PRICE AND BOOKING INFO FROM THE DATABASE INTO ITS DATAGRID VIEW
        private void CheckINInfo()
        {
            Calls.CheckINInformation();
        }
        // RUNS THE ADD NEW GUEST CODE FROM THE CLASS AND ADDS WHAT IS IN THE TEXTBOXES INTO THE DATABASE
        CRUD crud = new CRUD();
        public void btnAddInfo_Click(object sender, EventArgs e)
        {
            //THROWS A ERROR MEASSAGEBOX IF NOT ALL THE TEXT BOXES ARE FULL
            if (txtName.Text == "" && txtAddress.Text == "" && txtContactNumber.Text == "" && txtGuestNumbers.Text == "")
            {
                MessageBox.Show("Please fillout all the text boxes");
            }
            else
            {
                crud.AddGuests();

            }
        }
        //RUNS THE UPDATE CODE IN THE CRUD CLASS WHICH UPDATES GUEST INFO OF GUEST ALREADY IN THE DATABSE
        public void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            crud.UpdateInfo();
        }

        //RUNS THE DELETE CODE IN THE CRUD CLASS WHICH REMOVES GUSTS FROM THE DATABASE
        private void txtDelete_Click(object sender, EventArgs e)
        {
            string ID = txtID.Text;
            string name = txtName.Text;
            if (MessageBox.Show("Do you REALLY want to delete " + name + " from the guest database?", "Delete Record", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            try
            {
                crud.DeleteInfo();
            }
            catch (Exception)
            {
                MessageBox.Show("Error has occured");
                throw;
            }
        }
        //RUNS THE CELL CLICK ON THE GUEST DATAGRIDVIEW AND PASSES THE INFO FROM EACH CELL INTO THE RIGHT TEXTBOX
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
        //REFESHES THE DATABASE BY CALLING IT AGAIN SO THAT CHANGES APEAR
        public void btnRefresh_Click(object sender, EventArgs e)
        {
            GuestInfo();
        }
        //RUNS THE BOOKING CODE FROM THE CRUD CLASS WHICH ADDS BOOKED ROOM, PRICE AND DATES AND CONNECTS THAT INFO TO THE GUEST TABLE 
        public void btnBook_Click(object sender, EventArgs e)
        {
            crud.AddBooking();
            crud.UpdateBooking();
        }
        //RUNS THE CELL CLICK FOR THE ROOM DTATGRIDVIEW
        public void dataGridViewRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MAKES THE CONTENT CLICK WORK
            int rowIndex = e.RowIndex;
            int Numbers = Convert.ToInt32(txtGuestNumbers.Text);
            int SingleRoomPrice;
            int DoubleRoomPrice;
            int ExtraRoomPrice;
            int ExtraPerson;

            //SENDS THE INFO FROM EACH CELL TO THE LABELS TO SHOW THE PERSON ALL THE INFO ON THEN AND THAT ROOM
            DataGridViewRow row = dataGridViewRooms.Rows[rowIndex];
            txtRoomNumber.Text = row.Cells[0].Value.ToString();
            // HOLDS THE PRICE OF EACH ROOM DEPENDING ON HOW MANY GUESTS

            lblName.Text = txtName.Text + " " + "books room number" + " " + row.Cells[0].Value.ToString() + " " + "for" + " " + txtGuestNumbers.Text + " " + "people";
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
            //WORKS OUT IF ROOMS CAN HOLD THE NUMBER OF GUEST OR NOT
            int GuestNumbers = Convert.ToInt32(txtGuestNumbers.Text);
            int RoomCapacity = Convert.ToInt32(row.Cells[9].Value);
            int Difference = GuestNumbers - RoomCapacity;
            //TURNS THE ROOM RED IF THE ROOM IS ALREADY BOOKED
            if (dateTimePickerArrive.Value >= Convert.ToDateTime(row.Cells[7].Value) && dateTimePickerLeave.Value <= Convert.ToDateTime(row.Cells[8].Value))
            {

                row.DefaultCellStyle.BackColor = Color.Red;
                row.DefaultCellStyle.ForeColor = Color.Black;
                MessageBox.Show("Sorry this room is not available on these dates please choose a different room");
                btnBook.Enabled = false;
            }
            //TURNS THE ROOM BLUE IF THERE ARE TOO MANY GUESTS FOR THE ROOM
            else if (GuestNumbers > RoomCapacity)
            {
                row.DefaultCellStyle.BackColor = Color.DarkBlue;
                row.DefaultCellStyle.ForeColor = Color.White;
                MessageBox.Show("You have too many guests for this room" + " " + Difference + " " + " people have to go into a different room.");
                //  btnBook.Enabled = false;
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
            //TURNS THE ROOM GREEN IF IT CAN BE BOOKED
            else
            {
                row.DefaultCellStyle.BackColor = Color.Green;
                row.DefaultCellStyle.ForeColor = Color.White;
                MessageBox.Show("This room is available");
                btnBook.Enabled = true;
            }
        }
        //CHECKS THE SELECTED PERSON INTO THE HOTEL
        private void btnCheckIN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to the Sunshine Hotel");
        }
        //ADDS UP THE COST FOR THE SELCTED GUEST
        public void btnAddUpCost_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtWIFI.Text == " " || txtPhone.Text == " " || txtBar.Text == " ")
                {
                    MessageBox.Show("Here is your final bill");
                    RoomPrice();
                }
                else
                {
                    RoomPrice();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please fill all text boxes with a number");
                throw;
            }

        }
        //ADDS THE ROOM COSTS ONTO THE PRICE OF THE ROOM WHICH HAS BEEN TIMESED BY THE NUMBER OF DAYS STAYED
        public void RoomPrice()
        {
            int Price = Convert.ToInt32(txtPrice.Text);

            int WIFICost = Convert.ToInt32(txtWIFI.Text);
            int PhoneCost = Convert.ToInt32(txtPhone.Text);
            int BarCost = Convert.ToInt32(txtBar.Text);


            TimeSpan difference = dateTimePickerLeave.Value - dateTimePickerArrive.Value;
            int days = difference.Days;
            int RoomCharge = Price * days;
            string MYStay = days.ToString();

            lblNumberDaysBooked.Text = "Customer Stayed for:" + MYStay + " " + "days";
            lblNumberDaysOverStayed.Text = String.Empty;
            int MyPrice = RoomCharge * days;
            lblRoomsPrice.Text = "Your price for your room is:" + " " + "$" + txtPrice.Text;
            int TotalCost = MyPrice + WIFICost + PhoneCost + BarCost;
            lblTotalCharge.Text = "$" + TotalCost.ToString();

            if (DateTime.Today > dateTimePickerLeave.Value)
            {
                TimeSpan OverStay = DateTime.Today - dateTimePickerLeave.Value;
                int OverStayCost = OverStay.Days;
                //  int AddOnPrice = OverStayCost*Price;
                // string FullOverStayCost = (OverStayCost - MYCharge).ToString();
                string MyOverStayCost = OverStayCost.ToString();
                lblNumberDaysOverStayed.Text = "Customer OverStayed for:" + MyOverStayCost + " " + "days";
                int OverStayTotalCost = MyPrice + WIFICost + PhoneCost + BarCost * OverStayCost;
                lblTotalCharge.Text = OverStayTotalCost.ToString();
            }
        }
        //RUNS THE CELL CLICK OF THE CHECKIN AND OUT TABLE
        private void dataGridViewCheckINOUT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridViewCheckINOUT.Rows[rowIndex];
            //  RoomPrice();
            txtPrice.Text = row.Cells[9].Value.ToString();
            dateTimePickerArrive.Value = Convert.ToDateTime(row.Cells[7].Value);
            dateTimePickerLeave.Value = Convert.ToDateTime(row.Cells[8].Value);
            //TURNS THE GUEST GREEN IF THEY CAN CHECK IN
            if (DateTime.Today == dateTimePickerArrive.Value)
            {
                btnCheckIN.Enabled = true;
                row.DefaultCellStyle.BackColor = Color.Green;
                row.DefaultCellStyle.ForeColor = Color.White;
                MessageBox.Show(row.Cells[1].Value.ToString() + " " + "can check in now");
            }
            //TURNS THE GUEST LIGHT GREEN IF THEY ARE LATE TO CHECKED IN BUT THEIR CHECKOUT DATE HAS NOT JET PASTED
            else if (DateTime.Today > dateTimePickerArrive.Value && DateTime.Today < dateTimePickerLeave.Value)
            {
                row.DefaultCellStyle.BackColor = Color.Lime;
                row.DefaultCellStyle.ForeColor = Color.Black;
                MessageBox.Show(row.Cells[1].Value.ToString() + " " + "you are late to check in ");
                //   btnCheckIN.Enabled = Enabled;

            }
            //TURNS THE GUST BLUE IF THE DAY IS THEIR CHECKOUT DAY
            else if (DateTime.Today == dateTimePickerLeave.Value)
            {
                row.DefaultCellStyle.BackColor = Color.DarkBlue;
                row.DefaultCellStyle.ForeColor = Color.White;
                MessageBox.Show(row.Cells[1].Value.ToString() + " " + "today is your check out date please have your total cost added up and then check out ");
                btnCheckIN.Enabled = false;

            }
            //TURNS THE GUEST RED IF THEY ARE LATE TO CHECKOUT
            else if (DateTime.Today > dateTimePickerLeave.Value)
            {
                row.DefaultCellStyle.BackColor = Color.Red;
                row.DefaultCellStyle.ForeColor = Color.Black;
                MessageBox.Show(row.Cells[1].Value.ToString() + " " + "you are overdue for your check out please pay your bill and leave now ");
                btnCheckIN.Enabled = false;
            }
            //TURNS THE GUEST GOLD IF THEY CAN NOT CHECK IN YET
            else if (DateTime.Today < dateTimePickerArrive.Value)
            {
                MessageBox.Show(row.Cells[1].Value.ToString() + " " + "can not check in till: " + " " + row.Cells[7].Value.ToString() + " " + "come back them.");
                btnCheckIN.Enabled = false;
                row.DefaultCellStyle.BackColor = Color.Gold;
                row.DefaultCellStyle.ForeColor = Color.Black;
                btnCheckIN.Enabled = false;
            }


        }
        //CHECKS THE SELECTED GUST OUT
        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for staying at the SunShine Hotel please come again!");
        }
        //UPDATES DATAGRIDVIEWS WHEN CHANGES ARE AMDE
        private void btnViewBooking_Click(object sender, EventArgs e)
        {
            CheckINInfo();
            RoomInfo();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
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

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {

        }
        // Runs the check out code opening the review form and femoving the checking out person from the database.
        private void btnCheckOut_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Would you like to write us a review of how your stay with us was?", "Please Give Us your FeedBack!", MessageBoxButtons.YesNo) != DialogResult.Yes)
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

        //Adds the prices of the activity list, meal and vehicle list to the orders totals the price then add then to the checkout form
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnUpdateInfo_Click_1(object sender, EventArgs e)
        {

        }
    }
    }
