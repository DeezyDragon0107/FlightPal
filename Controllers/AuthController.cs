using FlightPal.Models.ViewModels;
using FlightPal.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("AuthController")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> SignIn([FromBody] LoginDTO dto)
    {
        var usuario = await _authService.ValidateUser(dto.Username, dto.Password);
        if (usuario == null)
        {
            return Unauthorized(new { message = "Usuario o contraseña incorrectos." });
        }


        var claims = new List<Claim>(){
            new Claim(ClaimTypes.Name, dto.Username),
            new Claim(ClaimTypes.Role, "ADMIN")
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);
        await HttpContext.SignInAsync(principal);
        return Ok();
    }
}