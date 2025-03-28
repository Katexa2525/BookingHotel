using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BookingHotel;
using System.Reflection;
using BookingHotel.Features.AuthProviders;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

//Добавляю сервис авторизации в коллекцию IService
builder.Services.AddAuthorizationCore();
// регистрирую класс в в коллекцию IService 
builder.Services.AddScoped<AuthenticationStateProvider, TestAuthStateProvider>();

await builder.Build().RunAsync();
