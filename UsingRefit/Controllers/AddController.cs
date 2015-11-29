using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Web.Http;

namespace UsingRefit.Controllers
{
    public class AddController : ApiController
    {
        [HttpGet]
        [Route("add")]
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }
    }
}
