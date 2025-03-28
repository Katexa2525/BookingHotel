using BookingHotel.Server.ContextFactory;
using BookingHotel.Server.Extensions;
using FluentValidation.AspNetCore;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// ������ ������ ����������� �� ������������
var connectionString = builder.Configuration.GetConnectionString("sqlConnection");

// ��������� DbContext � DI ���������
builder.Services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString));

// ��������� Factory ��� ��������
builder.Services.AddSingleton<IDesignTimeDbContextFactory<RepositoryContext>, RepositoryContextFactory>();

builder.Services.AddHttpClient();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureJWT(builder.Configuration);
// ��������� ����������� Identity
builder.Services.ConfigureIdentity();


//builder.Services.AddControllers();
builder.Services.AddControllers().AddFluentValidation(p=>p.RegisterValidatorsFromAssembly(Assembly.Load("Application")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
  var context = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
  context.Database.Migrate(); // ��������� �������� �� ������ ����������
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
