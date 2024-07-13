using CompanyControl.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CompanyControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected ApplicationDbContext Context { get; private set; }

        protected BaseApiController(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}
