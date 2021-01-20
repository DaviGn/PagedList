using Microsoft.AspNetCore.Mvc;
using PagedList;

namespace APIExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly Context _context;

        public BusinessController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]BusinessViewModel empresaViewModel)
        {
            var pagedList = _context.Business.ToPagedList(empresaViewModel);

            return new OkObjectResult(pagedList);
        }
    }
}
