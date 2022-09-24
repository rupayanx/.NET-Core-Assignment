using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Models
{
    public class Bill
    {
        public Guid BillId { get; set; }
        public float Amount { get; set; }
        public DateTime BillDate { get; set; }
        public Guid GuestId { get; set; }
        [ForeignKey("GuestId")]
        public virtual Guest guest { get; set; }
        public Guid reservationId { get; set; }
        [ForeignKey("reservationId")]
        public virtual Room_Reservation Room_Reservation { get; set; }

    }
}
