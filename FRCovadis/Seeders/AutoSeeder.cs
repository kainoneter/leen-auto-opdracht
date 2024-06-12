
using FRCovadis.Context;
using FRCovadis.Entities;

using System.Data;
using BCrypt.Net;
namespace FRCovadis.Seeders
{
    public class AutoSeeder
    {
        public static void Seed(UserContext _context)
        {
            var existingAutos = _context.Autos
                .Select(x => x.Id)
                .ToList();

            var roles = _context.Roles.ToList();

            var autos = new List<Auto>
            {
                new Auto(), new Auto(), new Auto()
            };

            var AutosToAdd = _context.Autos.Where(x => !existingAutos.Contains(x.Id)).ToList();

            _context.Autos.AddRange(AutosToAdd);
            _context.SaveChanges();
        }
    }
}
