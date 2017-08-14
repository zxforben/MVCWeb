using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Bleum")]
    public class BleumController : ApiController
    {
        // GET api/Bleum/BaseInfo
        [Route("BaseInfo")]
        public dynamic GetUserInfo()
        {
            return new
            {
                Email = "aaa@bleum.com"
            };
        }
    }
}
