using BookingHotel.Server.ContextFactory;
using BookingHotel.Server.Extensions;
using BookingHotel.Server.MappingProfile;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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
//builder.Services.ConfigureServiceManager();
builder.Services.ConfigureCors();
builder.Services.ConfigureJWT(builder.Configuration);
// Добавляем регистрацию Identity
builder.Services.ConfigureIdentity();
// Регистрируем репозитории
builder.Services.ConfigureRepository();
// Регистрируем бизнес логику
builder.Services.ConfigureBussinessLogic();

//builder.Services.AddControllers();
builder.Services.AddControllers().AddFluentValidation(p=>p.RegisterValidatorsFromAssembly(Assembly.Load("Application")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
  app.UseSwagger();
  app.UseSwaggerUI();
  // позволяет отлаживать код Blazor WebAssembly
  app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();

// позволяет серверной части прослушивать приложение Blazor
app.UseBlazorFrameworkFiles();
// позволяет обслуживать статичекие файлы с помощью API
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
// если запрос не соответствует контроллеру, выдаем файл index.html из проекта Blazor
app.MapFallbackToFile("index.html");

app.Run();
