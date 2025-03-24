using BookingHotel.Server.ContextFactory;
using Infrastructure;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Чтение строки подключения из конфигурации
var connectionString = builder.Configuration.GetConnectionString("sqlConnection");

// Добавляем DbContext в DI контейнер
builder.Services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString));

// Добавляем Factory для миграций
builder.Services.AddSingleton<IDesignTimeDbContextFactory<RepositoryContext>, RepositoryContextFactory>();

//builder.Services.AddControllers();
builder.Services.AddControllers().AddFluentValidation(p=>p.RegisterValidatorsFromAssembly(Assembly.Load("Application")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
