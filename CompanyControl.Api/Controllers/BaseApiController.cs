using AutoMapper;
using CompanyControl.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CompanyControl.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected ApplicationDbContext Context { get; private set; }
        protected IMapper Mapper { get; private set; }

        protected BaseApiController(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }
    }
}
