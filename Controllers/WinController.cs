using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebPrefer.Tests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WinController : ControllerBase
    {
        [HttpPost]
        public Task<Models.TransactionResponse> Post([FromBody] Models.WinRequest value)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}