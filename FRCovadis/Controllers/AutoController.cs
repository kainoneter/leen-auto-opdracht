
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
       /* [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _service.GetUsers();

            return Ok(users);
        }

        [HttpPost]
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
