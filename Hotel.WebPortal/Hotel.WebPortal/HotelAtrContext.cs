using Hotel.WebPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.WebPortal
{
    public class HotelAtrContext:DbContext
    {
        public HotelAtrContext(DbContextOptions<HotelAtrContext> options):base(options)
        { 

        }

        public DbSet<Room> Rooms { get; set; }
    }
}
