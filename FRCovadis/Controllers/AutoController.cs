
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

        /*VERANDER DE TIJD!!!*/

        [HttpPost("autos/create-reservation")]
        public IActionResult CreateReservation(int userId, int carId)
        {
            var response = _service.ReserveAuto(userId, carId, DateTime.Now);

            return Ok(response);
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
