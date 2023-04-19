using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Pages
{
    [Route("api/[controller]")]
    [ApiController]//Attribute=it is properties about class...
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello";
        }
    }
}
