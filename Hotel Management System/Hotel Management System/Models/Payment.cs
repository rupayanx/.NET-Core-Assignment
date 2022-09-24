using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Management_System.Models
{
    public class Payment
    {
        public Guid PaymentId { get; set; }
        public long PaymentCard { get; set; }
        public string CardHolderName { get; set; }
        public Guid BillId { get; set; }
        [ForeignKey("BillId")]
        public virtual Bill Bill { get; set; }
    }
}
