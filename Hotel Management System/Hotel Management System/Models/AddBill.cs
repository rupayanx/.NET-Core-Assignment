using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Models
{
    public class AddBill
    {
        public Guid GuestId { get; set; }
        public float Amount { get; set; }
        public DateTime BillDate { get; set; }
        public Guid reservationId { get; set; }
    }
}
