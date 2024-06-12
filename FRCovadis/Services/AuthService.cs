namespace FRCovadis.Services;

using FRCovadis.Context;
using FRCovadis.Requests;
using FRCovadis.Responses;
using Microsoft.EntityFrameworkCore;

public class AuthService(UserContext _context, TokenService tokenService)
{
    public AuthResponse? Login(LoginRequest request)
    {
        var user = _context.Users
            .Include(x => x.Roles)
            .SingleOrDefault(x => x.Email == request.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            return null;
        }

        return new AuthResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Token = tokenService.CreateToken(user)
        };
    }
}