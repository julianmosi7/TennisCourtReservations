using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisCourtReservations.Dtos
{
    public class PersonDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }
        public int NrBookings { get; set; }

        public override string ToString() => $"{Lastname} {Firstname}";
    }
}
