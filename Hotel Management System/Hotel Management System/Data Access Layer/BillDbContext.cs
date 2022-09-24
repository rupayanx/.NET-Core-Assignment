using Hotel_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Data_Access_Layer
{
    public class BillDbContext : DbContext
    {
        public BillDbContext(DbContextOptions<BillDbContext> options) : base(options)
        {
        }

        public DbSet<Bill> Bills { get; set; }
    }
}
