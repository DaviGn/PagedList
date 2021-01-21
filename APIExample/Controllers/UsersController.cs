using Microsoft.AspNetCore.Mvc;
using PagedList;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Get([FromQuery] UserViewModel empresaViewModel)
        {
            var pagedList = await _context.Users.ToPagedListAsync(empresaViewModel);

            return new OkObjectResult(pagedList);
        }
    }
}
