using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisCourtReservations.Dtos
{
    public class PersonReplyDto : PersonDto
    {
        public int Id { get; set; }

        public override string ToString() => $"{Lastname} {Firstname}";
        
    }
}
