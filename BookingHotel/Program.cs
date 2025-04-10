using Application.BussinessLogic.Authentication;
using Application.BussinessLogic.AuthProviders;
using Blazored.LocalStorage;
using BookingHotel;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient 
{ 
  BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
  //BaseAddress = new Uri("https://localhost:7222")
});

builder.Services.AddHttpClient("NoAuthenticationClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddHttpClient("SecureAPIClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("SecureAPIClient"));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddOidcAuthentication(options =>
{
  options.ProviderOptions.Authority = "http://localhost:8080/realms/BlazorWebApiRealm";
  options.ProviderOptions.ClientId = "blazor-client";
  options.ProviderOptions.ResponseType = "code";
  options.ProviderOptions.DefaultScopes.Add("blazor_api_scope");
  options.UserOptions.RoleClaim = "role";
});

//Добавляю сервис авторизации в коллекцию IService
builder.Services.AddAuthorizationCore();
// регистрирую класс в в коллекцию IService 
builder.Services.AddBlazoredLocalStorage();

//builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
//builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

await builder.Build().RunAsync();
