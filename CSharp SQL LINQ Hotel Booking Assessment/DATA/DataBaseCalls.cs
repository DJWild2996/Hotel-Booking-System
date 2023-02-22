using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_SQL_LINQ_Hotel_Booking_Assessment
{
    internal class DataBaseCalls : Form1
    {
        //LINKS IN THE DATABASE AND BRINGS IN THE TABLES
        public void GuestInformation()
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
                dataGridViewGuests.DataSource = alldata.ToList();
            }
        }
        //LINKS IN THE DATABASE AND BRINGS IN THE TABLES
        public void RoomInformation()
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
                dataGridViewRooms.DataSource = alldata.ToList();
            }
        }
        //LINKS IN THE DATABASE AND BRINGS IN THE TABLES
        public void CheckINInformation()
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
                dataGridViewCheckINOUT.DataSource = alldata.ToList();
            }
        }
    }
}