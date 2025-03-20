using BookingSystem.API.Middlewares;
using BookingSystem.Application;
using BookingSystem.Application.Abstractions;
using BookingSystem.Infrastructure;
using BookingSystem.Infrastructure.Repositories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();

builder.Services.AddProblemDetails();
builder.Services.AddHttpLogging(options => { });

var app = builder.Build();
app.UseMiddleware<GlobalExceptionMiddleware>();



// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



