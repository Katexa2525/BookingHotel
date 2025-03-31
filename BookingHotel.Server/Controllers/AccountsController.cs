using Application.DTO.Login;
using Application.DTO.Registration;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookingHotel.Server.Controllers
{
  [Route("accounts")]
  [ApiController]
  public class AccountsController : ControllerBase
  {
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IConfigurationSection _jwtSettings;

    public AccountsController(UserManager<User> userManager, IConfiguration configuration)
    {
      _userManager = userManager;
      _configuration = configuration;
      _jwtSettings = _configuration.GetSection("JwtSettings");
    }

    [HttpPost("registration")]
    public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
    {
      if (userForRegistration == null || !ModelState.IsValid)
        return BadRequest();

      User? user = new User { UserName = userForRegistration.Email, Email = userForRegistration.Email };

      IdentityResult? result = await _userManager.CreateAsync(user, userForRegistration.Password);
      if (!result.Succeeded)
      {
        IEnumerable<string>? errors = result.Errors.Select(e => e.Description);
        return BadRequest(new RegistrationResponseDto { Errors = errors });
      }

      return StatusCode(201);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthentication)
    {
      User? user = await _userManager.FindByNameAsync(userForAuthentication.Email);

      if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
        return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });

      SigningCredentials? signingCredentials = GetSigningCredentials();
      List<Claim>? claims = GetClaims(user);
      JwtSecurityToken? tokenOptions = GenerateTokenOptions(signingCredentials, claims);
      string? token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

      return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
    }

    private SigningCredentials GetSigningCredentials()
    {
      byte[]? key = Encoding.UTF8.GetBytes(_jwtSettings["securityKey"]);
      SymmetricSecurityKey? secret = new SymmetricSecurityKey(key);

      return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private List<Claim> GetClaims(IdentityUser user)
    {
      List<Claim>? claims = new List<Claim>
      {
        new Claim(ClaimTypes.Name, user.Email)
      };

      return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
      JwtSecurityToken? tokenOptions = new JwtSecurityToken(
          issuer: _jwtSettings["validIssuer"],
          audience: _jwtSettings["validAudience"],
          claims: claims,
          expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings["expiryInMinutes"])),
          signingCredentials: signingCredentials);

      return tokenOptions;
    }

  }
}
