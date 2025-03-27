using Microsoft.AspNetCore.Mvc;

namespace WTS.Controller;
[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    public HomeController()
    {
    }
    
    [HttpGet("GetMy")]
    public string GetHello()
    {
        return "Hello";
    }
}