using Hotel_Management_System.Data_Access_Layer;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Controllers
{
    [ApiController]
    [Route("api/reservation")]
    public class RoomReservationController : Controller
    {
        private readonly RoomReservationDbContext reservation;

        public RoomReservationController(RoomReservationDbContext reservation)
        {
            this.reservation = reservation;
        }

        [HttpGet]
        public IActionResult GetReservationDetails()
        {
            return Ok(reservation.Room_Reservations.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetRoomDetail([FromRoute] Guid id)
        {
            var roomid = reservation.Room_Reservations.Find(id);

            if (roomid == null)
            {
                return NotFound();
            }
            return Ok(roomid);
        }

        [HttpPost]
        public IActionResult AddReservation(AddReservation addReservation)
        {
            var  Room_Reservation=new Room_Reservation()
            {
                
            };

            reservation.Room_Reservations.Add(Room_Reservation);
            reservation.SaveChanges();

            return Ok(Room_Reservation);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteRoom([FromRoute] Guid id)
        {
            var roomid = reservation.Room_Reservations.Find(id);

            if (roomid != null)
            {
                reservation.Room_Reservations.Remove(roomid);
                reservation.SaveChanges();

                return Ok(roomid);
            }

            return NotFound();
        }
    }
}
