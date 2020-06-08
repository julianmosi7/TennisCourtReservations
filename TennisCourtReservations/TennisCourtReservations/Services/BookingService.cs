using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisCourtReservations.Replies;
using TennisCourtReservationsDb;

namespace TennisCourtReservations.Services
{
    public class BookingService
    {
        private readonly TennisContext db;

        public BookingService(TennisContext db)
        {
            this.db = db;
        }        

        public IEnumerable<Booking> GetAll()
        {
            return db.Bookings.AsEnumerable();
        }

        public Booking GetBooking(int week)
        {
            Booking booking = db.Bookings.Where(x => x.Week == week).FirstOrDefault();
            return booking;
        }

        public BookingReply PostBooking(Booking booking)
        {
            db.Bookings.Add(booking);
            db.SaveChanges();
            return new BookingReply(booking);
        }

        public BookingReply PutBooking(int id, Booking booking)
        {
            db.Bookings.Remove(db.Bookings.Where(x => x.Id == id).FirstOrDefault());
            if (db.Bookings.Where(x => x.Id == id).FirstOrDefault() != null)
            {
                db.Bookings.Add(booking);
            }
            db.SaveChanges();
            return new BookingReply(booking);
        }

        public BookingReply DeleteBooking(int id)
        {
            Booking Bookings = db.Bookings.Where(x => x.Id == id).FirstOrDefault();
            db.Bookings.Remove(db.Bookings.Where(x => x.Id == id).FirstOrDefault());
            db.SaveChanges();
            return new BookingReply(Bookings);
        }
    }
}
