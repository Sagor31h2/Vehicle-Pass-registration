using Microsoft.EntityFrameworkCore;
using VehiclePassRegister.Data;
using VehiclePassRegister.Repositories;
using VehiclePassRegister.Repositories.IRepository;
using VehiclePassRegister.Services;
using VehiclePassRegister.Services.IServices;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using VehiclePassRegister.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Database string
builder.Services.AddDbContext<DataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

//unit of work
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleService, VehicleService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//mapper
builder.Services.AddAutoMapper(typeof(VehicleProfile));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
