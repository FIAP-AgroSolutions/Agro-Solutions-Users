using Microsoft.AspNetCore.Mvc;

namespace Users.API.Controllers
{
    public class UserController : ControllerBase
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
