using Application.BussinessLogic.Authentication;
using Application.BussinessLogic.AuthProviders;
using Domain.Models;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
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
        //o.SignIn.RequireConfirmedPhoneNumber = true; //Требует от пользователей подтверждения своей учетной записи по электронной почте, прежде чем они смогут выполнить вход
        o.Lockout.AllowedForNewUsers = true; // Активирует блокировку пользователя, чтобы предотвратить атаки методом перебора, направленные на пароли пользователей
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

    public static void ConfigureCors(this IServiceCollection services) =>
      services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithExposedHeaders("X-Pagination"));
      });

    public static void ConfigureServiceManager(this IServiceCollection services)
    {
      //services.AddScoped<IAuthenticationService, AuthenticationService>();
      //services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
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
