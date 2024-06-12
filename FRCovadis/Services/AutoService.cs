
using FRCovadis.Context;
using FRCovadis.Entities;
using FRCovadis.Requests;
using FRCovadis.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FRCovadis.Services
{
    public class AutoService (UserContext _context)
    {   

        public IActionResult ReserveAuto(int userId, int autoId, string email, DateTime start, DateTime end)
        {
            var user = _context.Users.Select(x => x.Email ==  email).FirstOrDefault();

            if(user == false)
            {
                return new BadRequestObjectResult("user doesnt exist");
            }
            else
            {
                _context.Reservations.Add(new Reservation
                {
                    start = start,
                    end = end,
                    autoId = autoId,
                    userId = userId

                });
            }

            return new OkObjectResult("Reservation successful.");
        }

        public

      /*  public UserResponse CreateAuto(CreateUserRequest userReq)
        {

          
            
        }*/


    }
}


