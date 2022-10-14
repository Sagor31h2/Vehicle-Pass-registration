using VehiclePassRegister.Extensions;

var builder = WebApplication.CreateBuilder(args);

var _configure = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();

//Add from extention method starts here
builder.Host.ConfigureLogger();
builder.Services.ConfigureAppServices();
builder.Services.ConfigureDataAccess(_configure);
//end here

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//cores

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:4200/")
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Adding exception middleware
app.ConfigureExpectionMiddleware();

//cores
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
