
using FRCovadis.Context;

namespace FRCovadis.Seeders
{
    public static class Seeder
    {
        public static void Seed(this UserContext _context)
        {
            RoleSeeder.Seed(_context);
            UserSeeder.Seed(_context);
            AutoSeeder.Seed(_context);
        }
    }
}
