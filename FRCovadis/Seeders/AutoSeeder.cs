using FRCovadis.Context;
using FRCovadis.Entities;

using System.Collections.Generic;
using System.Linq;

namespace FRCovadis.Seeders
{
    public class AutoSeeder
    {
        public static void Seed(UserContext _context)
        {
            var existingAutos = _context.Autos
                .Select(x => x.Name)
                .ToList();

            // Log existing autos for debugging
            foreach (var id in existingAutos)
            {
                Console.WriteLine($"Existing Auto Id: {id}");
            }

            var autos = new List<Auto>
            {
                new Auto("citroën") { ReservationsById = new List<int>() },
                new Auto("opel") { ReservationsById = new List<int>() },
                new Auto("RR") { ReservationsById = new List<int>() }
            };

            var autosToAdd = autos.Where(y => !existingAutos.Contains(y.Name)).ToList();

            _context.Autos.AddRange(autosToAdd);

            _context.SaveChanges();
        }
    }
}
