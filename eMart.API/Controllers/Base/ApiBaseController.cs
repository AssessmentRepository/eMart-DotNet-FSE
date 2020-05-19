using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eMart.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApiBaseController : ControllerBase
    {
    }
}