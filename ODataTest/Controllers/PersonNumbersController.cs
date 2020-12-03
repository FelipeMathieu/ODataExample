using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ODataTest.Controllers
{
    [Route("api/Person-Numbers")]
    [ApiController]
    [Produces("application/json")]
    public class PersonNumbersController : ControllerBase
    {
        private readonly IPersonNumbersServices personNumbersServices;

        public PersonNumbersController(IPersonNumbersServices personNumbersServices)
        {
            this.personNumbersServices = personNumbersServices;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult GetAll()
        {
            return Ok(personNumbersServices.GetAll());
        }
    }
}
