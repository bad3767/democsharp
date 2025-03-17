using Microsoft.AspNetCore.Mvc;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;

    public AuthController()
    {
        _jwtService = new JwtService("YourSuperSecretKey"); // Use the same key
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        if (model.Username == "admin" && model.Password == "password")
        {
            var token = _jwtService.GenerateToken(model.Username);
            Console.WriteLine(token);
            return Ok(new { token });
        }
        return Unauthorized();
    }
}

public class LoginModel
{
    public string Username { get; set; }
    public string Password { get; set; }
}
