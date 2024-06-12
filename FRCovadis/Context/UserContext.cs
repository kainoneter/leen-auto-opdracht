
using FRCovadis.Entities;
using Microsoft.EntityFrameworkCore;

namespace FRCovadis.Context
{
    public class UserContext(DbContextOptions<UserContext> options)
        : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Auto> Autos {  get; set; }

        public DbSet<Reservation> Reservations { get; set; }
    }
}
