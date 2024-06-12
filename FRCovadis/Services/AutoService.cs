
using FRCovadis.Context;
using FRCovadis.Entities;
using FRCovadis.Requests;
using FRCovadis.Responses;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FRCovadis.Services
{
    public class AutoService(UserContext _context)
    {

        public IActionResult ReserveAuto(int userId, int autoId, DateTime start)
        {
            var user = _context.Users.Any(x => x.Id == userId);

            if (user == false)
            {
                return new BadRequestObjectResult("user doesnt exist");
            }
            else
            {

                var reservation = new Reservation
                {
                    Start = start,
                    AutoId = autoId,
                    UserId = userId

                };

                _context.Reservations.Add(reservation);
                _context.SaveChanges();

                var auto = _context.Autos.FirstOrDefault(x => x.Id == autoId);

                if (auto != null)
                {
                    auto.IsReserved = true;
                    auto.ReservationsById.Add(reservation.Id);
                }
                else
                {
                    return new BadRequestObjectResult("car doesnt exist");
                }

                return new OkObjectResult("Reservation successful.");
            }



        }

        public IEnumerable<SmallReservationResponse> ReservationsByCar(int carId)
        {
            return _context.Reservations.Select(x => new SmallReservationResponse
            {
                Id = x.Id,
                UserId = x.UserId
            }).ToList();

            }

        public IEnumerable<AutoResponse> GetAutos()
        {
            return _context.Autos.Select(x => new AutoResponse
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public IActionResult DeleteAutos()
        {
            _context.Autos.RemoveRange(_context.Autos);

            _context.SaveChanges();

            return new OkObjectResult("deleted!");
        }

        


    }
}


