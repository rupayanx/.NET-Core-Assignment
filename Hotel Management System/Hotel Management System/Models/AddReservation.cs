namespace Hotel_Management_System.Models
{
    public class AddReservation
    {

        public DateTime Checkin_Time { get; set; }
        public DateTime Checkout_Time { get; set; }
        public int Number_of_Guests { get; set; }
        public Guid GuestsId { get; set; }
    }
}
