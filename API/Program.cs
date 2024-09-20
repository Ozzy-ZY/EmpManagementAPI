using Microsoft.EntityFrameworkCore;
using DataAccess.DbConnection;
using Business.Services;
using DataAccess.Models;
using API.Controllers;
using DataAccess.Repo;
using Microsoft.Extensions.Options;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => 
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
    );
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepo<Employee>, Repo<Employee>>();
builder.Services.AddScoped<IRepo<Department>, Repo<Department>>();
builder.Services.AddScoped<EmployeeManager>();
builder.Services.AddScoped<DepartmentManager>();
builder.Services.AddSingleton<ILogger<EmployeesController>, Logger<EmployeesController>>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
