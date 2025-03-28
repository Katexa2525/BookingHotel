using Application.BussinessLogic.Authentication;
using Domain.Models;
using Infrastructure;
using Microsoft.AspNetCore.Identity;

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
  }
}
