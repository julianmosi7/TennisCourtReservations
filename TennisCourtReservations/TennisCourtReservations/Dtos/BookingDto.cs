using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisCourtReservations.Dtos
{
    public class BookingDto
    {
        public int Week { get; set; }
        public int DayOfWeek { get; set; }
        public int Hour { get; set; }
        public int PersonId { get; set; }

        public override string ToString() => $"{Week}/{DayOfWeek}/{Hour}";       

    }
}
