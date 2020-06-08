using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TennisCourtReservations.Dtos;
using TennisCourtReservations.Replies;
using TennisCourtReservations.Services;
using TennisCourtReservationsDb;

namespace TennisCourtReservations.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly BookingService bookingService;

        public BookingsController(BookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        // GET: Bookings
        [HttpGet]
        public IEnumerable<BookingReplyDto> Get()
        {
            return bookingService.GetAll().Select(x => new BookingReplyDto().CopyPropertiesFrom(x));
        }

        // GET: Bookings/5
        [HttpGet("{week}")]
        public ActionResult<BookingReplyDto> Get(int week)
        {
            Booking booking = bookingService.GetBooking(week);
            return new BookingReplyDto().CopyPropertiesFrom(booking);
        }

        // POST: Bookings
        [HttpPost]
        public ActionResult<BookingReplyDto> Post([FromBody] BookingDto bookingDto)
        {
            var booking = new Booking().CopyPropertiesFrom(bookingDto);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var bookingReply = bookingService.PostBooking(booking);
            if (!bookingReply.Success) return BadRequest(bookingReply.Error);
            return Ok(new BookingReplyDto().CopyPropertiesFrom(bookingReply.Booking));
        }

        // PUT: Bookings/5
        [HttpPut("{id}")]
        public ActionResult<BookingReplyDto> Put(int id, [FromBody] PersonDto bookingDto)
        {
            var booking = new Booking().CopyPropertiesFrom(bookingDto);
            var bookingReply = bookingService.PutBooking(id, booking);
            if (!bookingReply.Success) return BadRequest(bookingReply.Error);
            return Ok(new BookingReplyDto().CopyPropertiesFrom(bookingReply.Booking));
        }

        // DELETE: ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<BookingReplyDto> Delete(int id)
        {
            var bookingReply = bookingService.DeleteBooking(id);
            if (!bookingReply.Success) return BadRequest(bookingReply);
            return Ok(new BookingReplyDto().CopyPropertiesFrom(bookingReply));
        }
    }
}
