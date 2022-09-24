using Hotel_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Data_Access_Layer
{
    public class PaymentDbContext : DbContext
    {
        public PaymentDbContext(DbContextOptions<PaymentDbContext> options) : base(options)
        {
        }

        public DbSet<Payment> payments { get; set; }
    }
}
