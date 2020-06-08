using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TennisCourtReservations.Replies
{
    public abstract class Reply
    {
        public bool Success { get; protected set; } = true;
        public string Error { get; protected set; }

        public Reply(bool success, string error)
        {
            Success = success;
            Error = error;
        }
    }
}
