using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace NewsUA.API.Controllers
{
    [ApiController]
    [EnableCors("OpenCORSPolicy")]
    [Route("[controller]")]
    public class BaseApiController : ControllerBase
    {
        
    }
}