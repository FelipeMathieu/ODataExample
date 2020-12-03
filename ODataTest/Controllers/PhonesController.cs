using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ODataTest.Controllers
{
    [Route("api/Phones")]
    [ApiController]
    [Produces("application/json")]
    public class PhonesController : ControllerBase
    {
        private readonly IPhonesServices phonesServices;

        public PhonesController(IPhonesServices phonesServices)
        {
            this.phonesServices = phonesServices;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult GetAll()
        {
            return Ok(phonesServices.GetAll());
        }
    }
}
