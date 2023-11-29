global using Turbokart.Application.Interfaces;
global using Turbokart.Application.UseCases;
global using Turbokart.Infrastructure.Persistence.Interfaces;
global using Turbokart.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Turbokart.Infrastructure.Persistence.EfContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContext, TurbokartContext>();

builder.Services.AddScoped<IBookingUseCase, BookingUseCase>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

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
