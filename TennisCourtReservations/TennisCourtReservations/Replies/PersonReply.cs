using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisCourtReservationsDb;

namespace TennisCourtReservations.Replies
{
    public class PersonReply : Reply
    {
        public Person Person { get; set; }
        private PersonReply(bool success, string error, Person person) : base(success, error)
        {
            Person = person;
        }
        public PersonReply(Person person) : this(true, null, person) { }
        public PersonReply(string error) : this(false, error, null) { }
    }
}
