using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisCourtReservationsDb;

namespace TennisCourtReservations.Replies
{
    public class BookingReply : Reply
    {
        public Booking Booking { get; set; }
        private BookingReply(bool success, string error, Booking booking) : base(success, error)
        {
            Booking = booking;
        }
        public BookingReply(Booking booking) : this(true, null, booking) { }
        public BookingReply(string error) : this(false, error, null) { }
    }
}
