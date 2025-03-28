using Application.BussinessLogic.Authentication;
using Domain.Models;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BookingHotel.Server.Extensions
{
  public static class ServiceExtensions
  {
    public static void ConfigureIdentity(this IServiceCollection services)
    {
      var builder = services.AddIdentity<User, IdentityRole>(o =>
      {
        o.Password.RequireDigit = true;
        o.Password.RequireLowercase = false;
        o.Password.RequireUppercase = false;
        o.Password.RequireNonAlphanumeric = false;
        o.Password.RequiredLength = 8;
        o.User.RequireUniqueEmail = true;
      })
      .AddEntityFrameworkStores<RepositoryContext>()
      .AddDefaultTokenProviders();
    }

    public static void ConfigureServiceManager(this IServiceCollection services)
    {
      services.AddScoped<IAuthenticationService, AuthenticationService>();
    }

    public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
    {
      var jwtSettings = configuration.GetSection("JwtSettings");
      services.AddAuthentication(opt =>
      {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(options =>
      {
        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          ValidIssuer = jwtSettings["validIssuer"],
          ValidAudience = jwtSettings["validAudience"],
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["securityKey"]))
        };
      });
    }
  }
}
