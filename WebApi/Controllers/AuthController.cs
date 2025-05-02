using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BusinessLogic.Authentication;
using DataAccess.Repositories.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WashCar.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IUserRepository userRepository, IConfiguration configuration) : ControllerBase
{
    private readonly string _jwtSecretKey = configuration["Jwt:SecretKey"] ?? throw new ArgumentNullException("Jwt:SecretKey");
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await userRepository.GetUserByEmailAsync(request.Email);
        if (user == null)
            return Unauthorized("Invalid email");

        var roles = user.RoleUsers.Select(ru => ru.Role?.Name).Where(r => r != null).ToList();
        if (roles.Count == 0)
            return Unauthorized("User has no roles assigned");

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Email),
            new(ClaimTypes.NameIdentifier, user.Id.ToString())
        };

        // добавляем все роли пользователя
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role!)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(new { token = jwt });
    }
}
