using Application.BussinessLogic.Booking;
using Application.BussinessLogic.Food;
using Application.BussinessLogic.GeneralMethods;
using Application.BussinessLogic.Guest;
using Application.BussinessLogic.Hotel;
using Application.BussinessLogic.HotelFacility;
using Application.BussinessLogic.HotelPhoto;
using Application.BussinessLogic.Location;
using Application.BussinessLogic.Price;
using Application.BussinessLogic.Review;
using Application.BussinessLogic.Room;
using Application.BussinessLogic.RoomFacility;
using Application.BussinessLogic.RoomPhoto;
using Application.BussinessLogic.RoomType;
using Application.BussinessLogic.TypeFood;
using Application.Interfaces.Repository;
using Domain.Models;
using Infrastructure;
using Infrastructure.Repository;
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

    public static void ConfigureCors(this IServiceCollection services) =>
      services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithExposedHeaders("X-Pagination"));
      });

    /// <summary> Регистрация менеджера репозитория </summary>
    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
                                  services.AddScoped<IRepositoryManager, RepositoryManager>();

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

    public static void ConfigureBussinessLogic(this IServiceCollection services)
    {
      services.AddScoped<IGeneralBussinessLogic, GeneralBussinessLogic>();
      services.AddScoped<IRoomBussinessLogic, RoomBussinessLogic>();
      services.AddScoped<IHotelBussinessLogic, HotelBussinessLogic>();
      services.AddScoped<IFoodBussinessLogic, FoodBussinessLogic>();
      services.AddScoped<IRoomPhotoBussinessLogic, RoomPhotoBussinessLogic>();
      services.AddScoped<IRoomFacilityBussinessLogic, RoomFacilityBussinessLogic>();
      services.AddScoped<IHotelPhotoBussinessLogic, HotelPhotoBussinessLogic>();
      services.AddScoped<IHotelFacilityBussinessLogic, HotelFacilityBussinessLogic>();
      services.AddScoped<ILocationBussinessLogic, LocationBussinessLogic>();
      services.AddScoped<IPriceBussinessLogic, PriceBussinessLogic>();
      services.AddScoped<IBookingBussinessLogic, BookingBussinessLogic>();
      services.AddScoped<IRoomTypeBussinessLogic, RoomTypeBussinessLogic>();
      services.AddScoped<IGuestBussinessLogic, GuestBussinessLogic>();
      services.AddScoped<IReviewBussinessLogic, ReviewBussinessLogic>();
      services.AddScoped<ITypeFoodBussinessLogic, TypeFoodBussinessLogic>();
    }

    public static void ConfigureAuthenticationJWTKeycloak(this IServiceCollection services)
    {
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                options.Authority = "http://localhost:8080/realms/BlazorWebApiRealm";
                options.Audience = "web-api";
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true
                };
              });
    }

  }
}
