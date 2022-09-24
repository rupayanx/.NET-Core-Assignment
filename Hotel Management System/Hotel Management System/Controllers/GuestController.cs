using Hotel_Management_System.Data_Access_Layer;
using Hotel_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Management_System.Controllers
{
    [ApiController]
    [Route("api/guest")]
    public class GuestController : Controller
    {
        private readonly GuestDbContext Guest;

        public GuestController(GuestDbContext Guest)
        {
            this.Guest = Guest;
        }
        [HttpGet]
        public IActionResult GetGuestDetails()
        {
            return Ok(Guest.guests.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetGuestDetail([FromRoute] Guid id)
        {
            var roomid = Guest.guests.Find(id);

            if (roomid == null)
            {
                return NotFound();
            }
            return Ok(roomid);
        }

        [HttpPost]
        public IActionResult AddGuest(AddGuest addGuest)
        {
            var Guestt=new Guest()
            {
                GuestId = Guid.NewGuid(),
                GuestName = addGuest.GuestName,
                GuestAddress = addGuest.GuestAddress,
                GuestAdhaarCard = addGuest.GuestAdhaarCard,
                GuestAge = addGuest.GuestAge,
                GuestEmail = addGuest.GuestEmail,
                GuestPhoneNumber = addGuest.GuestPhoneNumber
                
            };

            Guest.guests.Add(Guestt);
            Guest.SaveChanges();

            return Ok(Guestt);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee([FromRoute] Guid id, UpdateGuest updateGuest)
        {
            var guestid = Guest.guests.Find(id);

            if (guestid != null)
            {
                guestid.GuestName = updateGuest.GuestName;
                guestid.GuestAddress = updateGuest.GuestAddress;  
                guestid.GuestAdhaarCard = updateGuest.GuestAdhaarCard;
                guestid.GuestAge = updateGuest.GuestAge;
                guestid.GuestEmail = updateGuest.GuestEmail;
                guestid.GuestPhoneNumber = updateGuest.GuestPhoneNumber;
                

                Guest.SaveChanges();

                return Ok(guestid);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee([FromRoute] Guid id)
        {
            var guestid = Guest.guests.Find(id);

            if (guestid != null)
            {
               Guest.guests.Remove(guestid);
                Guest.SaveChanges();

                return Ok(guestid);
            }

            return NotFound();
        }

    }
}
