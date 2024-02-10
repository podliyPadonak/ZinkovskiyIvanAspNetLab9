
using Microsoft.EntityFrameworkCore;
using ZinkovskiyTask;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
var connection = configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<SchoolDbContext>(options =>
{
    options.UseMySql(connection, new MariaDbServerVersion(new Version(8, 0, 34)));
}, ServiceLifetime.Singleton);

builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
builder.Services.AddSingleton<IStudentService, StudentService>();

var app = builder.Build();

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