
using FRCovadis.Context;
using FRCovadis.Entities;

using System.Data;
using BCrypt.Net;
namespace FRCovadis.Seeders
{
    public class UserSeeder
    {
        public static void Seed(UserContext _context)
        {
            var existingUsers = _context.Users
                .Select(x => x.Email)
                .ToList();

            var roles = _context.Roles.ToList();

            var users = new List<User>
        {
            new()
            {
                Name = "Kain",
                Email = "kscheffer@mail.com",
                Password =  BCrypt.Net.BCrypt.HashPassword("Wachtwoord123?"),
                Roles = [roles.Find(x => x.Name == Roles.Administrator)!]
            },
            new()
            {
                Name = "John Doe",
                Email = "j.doe@example.com",
                Password =  BCrypt.Net.BCrypt.HashPassword("Password123!"),
                Roles = [roles.Find(x => x.Name == Roles.Employee)!]
            }
        };

            var usersToAdd = users
                .Where(x => !existingUsers.Contains(x.Email))
                .ToList();

            _context.Users.AddRange(usersToAdd);
            _context.SaveChanges();
        }
    }
}
