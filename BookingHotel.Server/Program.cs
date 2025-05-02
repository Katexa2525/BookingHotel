using BookingHotel.Server.ContextFactory;
using BookingHotel.Server.Extensions;
using BookingHotel.Server.MappingProfile;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.FileProviders;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Чтение строки подключения из конфигурации
var connectionString = builder.Configuration.GetConnectionString("sqlConnection");

// Добавляем DbContext в DI контейнер
builder.Services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString));

// Добавляем Factory для миграций
builder.Services.AddSingleton<IDesignTimeDbContextFactory<RepositoryContext>, RepositoryContextFactory>();

builder.Services.AddHttpClient();
//builder.Services.AddHttpClient( client => client.BaseAddress = new Uri("https://localhost:7222"));
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7222") });

//builder.Services.ConfigureServiceManager();
builder.Services.ConfigureCors();
//builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.ConfigureAuthenticationJWTKeycloak();
builder.Services.AddAuthorization();
// Добавляем регистрацию Identity
builder.Services.ConfigureIdentity();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

//builder.Services.AddControllers();
builder.Services.AddControllers().AddFluentValidation(p=>p.RegisterValidatorsFromAssembly(Assembly.Load("Application")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.ConfigureRepositoryManager();
// Регистрируем бизнес логику
builder.Services.ConfigureBussinessLogic();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("Application")));

builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  var context = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
  context.Database.Migrate(); // Применить миграции на старте приложения
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  //app.UseSwagger();
  //app.UseSwaggerUI();
  // позволяет отлаживать код Blazor WebAssembly
  app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();
//app.UseCors("CorsPolicy");

// позволяет серверной части прослушивать приложение Blazor
app.UseBlazorFrameworkFiles();

// позволяет обслуживать статичекие файлы с помощью API
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{ 
  FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Images")),
  RequestPath = new Microsoft.AspNetCore.Http.PathString("/Images")
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
// если запрос не соответствует контроллеру, выдаем файл index.html из проекта Blazor
app.MapFallbackToFile("index.html");

app.Run();
