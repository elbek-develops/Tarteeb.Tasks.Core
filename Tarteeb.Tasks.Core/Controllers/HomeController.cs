using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Tarteeb.Tasks.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : RESTFulController
    {
        [HttpGet]
        public ActionResult<string> Get() => Ok("Hey, I am up and running");
    }
}
