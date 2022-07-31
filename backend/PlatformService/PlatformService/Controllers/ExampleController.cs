using Microsoft.AspNetCore.Mvc;

namespace PlatformService.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{
    [HttpGet(Name = "Get")]
    public IActionResult Get()
    {
        return Ok();
    }
}