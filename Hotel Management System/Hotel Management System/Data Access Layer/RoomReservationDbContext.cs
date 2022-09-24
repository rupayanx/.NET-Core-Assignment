using Hotel_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Data_Access_Layer
{
    public class RoomReservationDbContext : DbContext
    {
        public RoomReservationDbContext(DbContextOptions<RoomReservationDbContext> options) : base(options)
        {
        }

        public DbSet<Room_Reservation> Room_Reservations { get; set; }
    }
}
