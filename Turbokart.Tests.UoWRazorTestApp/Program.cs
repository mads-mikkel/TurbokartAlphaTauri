using Microsoft.EntityFrameworkCore;

using Turbokart.Application.Interfaces;
using Turbokart.Application.UseCases;
using Turbokart.Infrastructure.Persistence.EfContexts;
using Turbokart.Infrastructure.Persistence.Interfaces;
using Turbokart.Infrastructure.Persistence.Repositories;

namespace Turbokart.Tests.UoWRazorTestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<DbContext, TurbokartContext>();
            builder.Services.AddTransient<IBookingRepository, BookingRepository>();
            builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<IBookingUseCase, BookingUseCase>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if(!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}