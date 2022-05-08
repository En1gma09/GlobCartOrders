using Microsoft.AspNetCore.Mvc;
using GlobCartOrderService.Domain.Services;
using GlobCartOrderService.Domain.Models;
using GlobCartOrderService.Domain.Interfaces;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using GlobCartOrderService.Services.API.Models;

namespace GlobCartOrderService.Services.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthController(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        [Route("token")]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel user)
        {
            user.Email = user.Email.ToLower();
            var existingUser = await _authenticationRepository.LoginAsync(user.Email, user.Password);

            if (existingUser == null || existingUser.Email != user.Email || existingUser.Password != user.Password)
                return Unauthorized();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString()),

                new Claim(ClaimTypes.NameIdentifier,
                          existingUser.Id.ToString()),

                new Claim(ClaimTypes.Name, ClaimTypes.Email),
                new Claim(ClaimTypes.Role, (existingUser.Role).ToString())
            };

            var tokenSecretKey = Encoding.UTF8.GetBytes(Settings.Secret);

            var key = new SymmetricSecurityKey(tokenSecretKey);

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenExpirationHours = Convert.ToInt32(Settings.TokenExpirationHours);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(tokenExpirationHours),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { user, token = tokenHandler.WriteToken(token) });
        }
    }
}
