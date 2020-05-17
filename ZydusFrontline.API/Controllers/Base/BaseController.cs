using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZydusFrontline.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    //[APIAttributes]
    public class BaseController : ControllerBase
    {
        // to be added in later stage
        // The base api of all API Controller
        // add logs for both request & response
    }
}
