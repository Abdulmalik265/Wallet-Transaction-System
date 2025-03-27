using Microsoft.AspNetCore.Mvc;
using WTS_CORE.Dto;
using WTS_CORE.Entities;
using WTS_CORE.Interface;

namespace WTS.Controller;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRegistration _userRegistration;
    public UserController(IUserRegistration userRegistration)
    {
        _userRegistration = userRegistration;
    }
    [HttpPost("Register")]
    public async Task<IActionResult> RegisterUser(UserDto user)
    {
        try
        {
            var response = await _userRegistration.RegisterAsync(user);
            return Ok(new ResponseDto<User>()
            {
                Data = response,
                ResponseMessage = "user created",
                ResponseCode = 200,
            });

        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseDto<User>()
            {
                Data = null,
                ResponseMessage = ex.Message,
                ResponseCode = 400
            });
        }
       
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserDto user)
    {
        try
        {
            var token = await _userRegistration.LoginAsync(user);
            return Ok(token);
        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseDto<User>()
            {
                Data = null,
                ResponseMessage = ex.Message,
                ResponseCode = 400
            });
        }
    }
}
