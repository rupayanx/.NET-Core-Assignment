using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Models
{
    public class AddPayment
    {
        public long PaymentCard { get; set; }
        public string CardHolderName { get; set; }
        public Guid BillId { get; set; }
    }
}
