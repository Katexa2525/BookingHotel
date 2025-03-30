using Application.BussinessLogic.Authentication;
using Application.BussinessLogic.AuthProviders;
using Blazored.LocalStorage;
using BookingHotel;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient 
{ 
  BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
  //BaseAddress = new Uri("https://localhost:7222")
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

//�������� ������ ����������� � ��������� IService
builder.Services.AddAuthorizationCore();
// ����������� ����� � � ��������� IService 
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

await builder.Build().RunAsync();
