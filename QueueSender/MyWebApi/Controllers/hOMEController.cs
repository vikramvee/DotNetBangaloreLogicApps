using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebApi.Controllers
{
    public class hOMEController : ApiController
    {
        public string Get()
        {
            return "Hello Vikram";
        }

        public HttpResponseMessage Post(Person per)
        {
            return Request.CreateResponse(HttpStatusCode.OK, new { FullName = string.Format("{0} {1}", per.FirstName, per.LastName) });
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
    }
}
