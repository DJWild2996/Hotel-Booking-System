using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_SQL_LINQ_Hotel_Booking_Assessment
{
    class CRUD : Form1
    {
        //ADD NEW GUEST INFO FROM THE TEXT BOXES INTO THE DATABASE
        public void AddGuests()
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
        //CLEAR THE TEXT BOXES WHEN INFO GOES IN
        public void ClearTextBoxes()
        {

            txtName.Text = String.Empty;
            txtAddress.Text = String.Empty;
            txtContactNumber.Text = String.Empty;
            txtGuestNumbers.Text = String.Empty;
            txtID.Text = String.Empty;
        }
        //LETS YOU UPDATE GUST INFO OF PEOPOLE IN THE DATABASE
        public void UpdateInfo()
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
        //LETS YOU ROMOVE PEOPLE FROM THAT DATABSE
        public void DeleteInfo()
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
        // ADDS IN A PERSONS BOOKING INFO AND GUST INFO
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
                context.Guests.Add(contact);
                context.SaveChanges();


            }

        }
        //LEST YOU UPDATE GUST BOOKING INFO
        public void UpdateBooking()
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
    }
}
