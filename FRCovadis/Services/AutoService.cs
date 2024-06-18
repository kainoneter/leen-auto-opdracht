
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

        public IActionResult ReserveAuto(int userId, int autoId, DateTime start, DateTime end)
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
                    End = end,
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

        public IActionResult DeleteReservation(int reservationId)
        {
            var reservation = _context.Reservations.FirstOrDefault(x => x.Id == reservationId);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
            }
            else
            {
                return new BadRequestObjectResult("car not found");
            }

            return new OkObjectResult("reservation deleted");
        }

        public IEnumerable<ReservationResponse> ReservationsByCar(int carId)
        {
            return _context.Reservations
                .Where(r => r.AutoId == carId) 
                .Select(r => new ReservationResponse 
                {
                    Id = r.Id,
                    UserId = r.UserId,
                    AutoId = r.AutoId,
                    Start = r.Start
                })
                .ToList();
        }


        public IEnumerable<ReservationResponse> GetAllReservations()
        {
            return _context.Reservations.Select(x => new ReservationResponse
            {
                Id = x.Id,
                AutoId = x.AutoId,
                UserId = x.UserId
            });
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


