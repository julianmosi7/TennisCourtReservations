using System;
using System.Collections.Generic;
using System.Text;

namespace TennisCourtReservationsDb
{
    public partial class Person
    {
        public Person()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
