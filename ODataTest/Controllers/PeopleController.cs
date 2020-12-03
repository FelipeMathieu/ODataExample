using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODataTest.Controllers
{
    [Route("api/People")]
    [ApiController]
    [Produces("application/json")]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleServices peopleServices;

        public PeopleController(IPeopleServices peopleServices)
        {
            this.peopleServices = peopleServices;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult GetAll()
        {
            return Ok(peopleServices.GetAll());
        }
    }
}
