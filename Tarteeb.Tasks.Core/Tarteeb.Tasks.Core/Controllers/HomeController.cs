using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Tarteeb.Tasks.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : RESTFulController
    {
        [HttpGet]
        public ActionResult<string> Get() => Ok("I am up and running!");
    }
}
