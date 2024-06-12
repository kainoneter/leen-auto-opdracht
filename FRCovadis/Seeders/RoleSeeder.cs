

using FRCovadis.Context;
using FRCovadis.Entities;

namespace FRCovadis.Seeders
{
    public class RoleSeeder
    {
        public static void Seed(UserContext _context)
        {

            var existingRoles = _context.Roles
                .Select(x => x.Name)
                .ToList();

            var roles = new List<Role>
        {
            new() { Name = Roles.Administrator },
            new() { Name = Roles.Employee }
        };

            var rolesToAdd = roles
                .Where(x => !existingRoles.Contains(x.Name))
                .ToList();

            _context.Roles.AddRange(rolesToAdd);
            _context.SaveChanges();
        }
    }
    public static class Roles
    {
        public const string Administrator = "Administrator";
        public const string Employee = "Employee";
    }
}
