
using FRCovadis.Requests;
using FRCovadis.Seeders;
using FRCovadis.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FRCovadis.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AutoController(AutoService _service) : ControllerBase
    {
        [HttpGet("autos")]
        public IActionResult GetAutos()
        {
            var autos = _service.GetAutos();
            return Ok(autos);
        }

        [HttpGet("autos/{carId}/reservations")]
        public IActionResult GetReservationsByAuto(int carId)
        {
            var reservations = _service.ReservationsByCar(carId);
            return Ok(reservations);
        }

        [HttpGet("autos/reservations")]
        public IActionResult GetAllReservations()
        {
            var reservations = _service.GetAllReservations();
            return Ok(reservations);
        }


        [HttpPost("autos/create-reservation")]
        public IActionResult CreateReservation(string userName, string carName, DateTime start, DateTime end)
        {
            if (start >= end)
            {
                return BadRequest("The start date must be before the end date.");
            }
            var response = _service.ReserveAuto(userName, carName, start, end);

            return Ok(response);
        }

        [HttpDelete("autos/delete-reservation")]
        public IActionResult DeleteReservation(int reservationId)
        {
           _service.DeleteReservation(reservationId);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteAutos()
        {
            var response = _service.DeleteAutos();

            return Ok(response);
        }

        /*  [HttpPost]
          public IActionResult CreateUser(CreateUserRequest user)
          {
              var response = _service.CreateUser(user);

              return Ok(response);
          }

          [Authorize(Roles = Roles.Administrator)]
          [HttpGet("secret")]
          public IActionResult Secret()
          {
              return Ok("This is a secret message");
          }*/
    }
}
