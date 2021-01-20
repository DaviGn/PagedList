using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace APIExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Context _context;

        public UsersController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]UserViewModel empresaViewModel)
        {
            var pagedList = _context.Users.ToPagedList(empresaViewModel);

            return new OkObjectResult(pagedList);
        }
    }
}
