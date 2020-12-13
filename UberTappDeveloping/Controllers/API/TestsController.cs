using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UberTappDeveloping.Controllers.API
{
    public class TestsController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Test([FromBody] object obj)
        {


            return Ok(obj);
        }

    }
}
