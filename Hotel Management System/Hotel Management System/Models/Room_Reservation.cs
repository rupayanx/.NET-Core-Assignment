using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Models
{
    public class Room_Reservation
    {
        [Key]
        public Guid reservationId { get; set; }
        public Guid RoomId { get; set; }
        [ForeignKey("RoomId")]

        public DateTime Checkin_Time { get; set; }
        public DateTime Checkout_Time { get; set; }
        public int Number_of_Guests { get; set; }
        public Guid GuestsId { get; set; }
        [ForeignKey("GuestId")]

        public virtual Room Room { get; set; }
        public virtual Guest Guest { get; set; }
    }
}
