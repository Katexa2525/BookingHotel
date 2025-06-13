using Application.BussinessLogic.RoleClaim;
using Application.Interfaces.Email;
using Application.Services;
using Blazored.LocalStorage;
using BookingHotel;
using BookingHotel.MappingProfile;
using BookingHotel.State;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// HttpClient для неавторизованных запросов
builder.Services.AddScoped(sp => new HttpClient 
{ 
  BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
  //BaseAddress = new Uri("https://localhost:7222")
});

// HttpClient для неавторизованных запросов
builder.Services.AddHttpClient("NoAuthenticationClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// HttpClient только для авторизованных запросов
builder.Services.AddHttpClient("SecureAPIClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("SecureAPIClient"));
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("NoAuthenticationClient"));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddAutoMapper(typeof(MappingProfileClient));

builder.Services.AddOidcAuthentication(options =>
{
  options.ProviderOptions.Authority = "http://localhost:8080/realms/BlazorWebApiRealm";
  options.ProviderOptions.ClientId = "blazor-client";
  options.ProviderOptions.ResponseType = "code";
  options.ProviderOptions.DefaultScopes.Add("blazor_api_scope");
  options.UserOptions.RoleClaim = "role";
}).AddAccountClaimsPrincipalFactory<MultipleRoleClaimsPrincipalFactory<RemoteUserAccount>>(); ;

//Добавляю сервис авторизации в коллекцию IService
builder.Services.AddAuthorizationCore();
// регистрирую класс в в коллекцию IService 
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AppState>();
builder.Services.AddMudServices();

builder.Services.AddScoped<IEmailService, EmailService>();

//builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
//builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

await builder.Build().RunAsync();
