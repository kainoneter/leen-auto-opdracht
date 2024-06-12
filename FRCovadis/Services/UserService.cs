
using FRCovadis.Context;
using FRCovadis.Entities;
using FRCovadis.Requests;
using FRCovadis.Responses;

namespace FRCovadis.Services
{
    public class UserService(UserContext _context)
    {
        public IEnumerable<UserResponse> GetUsers()
        {
            return _context.Users.Select(x => new UserResponse
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email
            });
        }

        public UserResponse? GetUserById(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return null;
            }

            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public UserResponse CreateUser(CreateUserRequest request)
        {
            var existingUser = _context.Users
                .SingleOrDefault(x => x.Email == request.Email);

            if (existingUser != null)
            { 
                throw new Exception("User already exists");
            }

            var roles = _context.Roles
                .Where(x => request.Roles.Contains(x.Id))
                .ToList();

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Roles = roles
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public UserResponse? UpdateUser(int id, UpdateUserRequest request)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return null;
            }

            user.Name = request.Name;
            user.Email = request.Email;

            _context.SaveChanges();

            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public UserResponse? DeleteUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}


