
using Microsoft.EntityFrameworkCore;
using SUT23_TeknikButik.Data;
using SUT23_TeknikButik.Services;
using SUT23_TeknikButikModels;
using System.Text.Json.Serialization;

namespace SUT23_TeknikButik
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<ITeknikButik<Product>, ProductRepository>();
            builder.Services.AddScoped<ITeknikButik<Order>, OrderRepository>();
            builder.Services.AddScoped<ICustomer, CustomerRepository>();



            // löser problemet med serialize loopar på Controller nivå. Går att lösa på model nivå
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            });

            //EF TILL SQL Connection
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

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
        }
    }
}
