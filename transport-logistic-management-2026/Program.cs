using business_logic;
using data_access;
using data_access.Identity;
using Microsoft.AspNetCore.Identity;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;

namespace transport_logistic_management_2026
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("connectionString");


            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddBusinessLogicServices();
            builder.Services.AddDataAccessServices(connectionString);
            builder.Services.AddIdentity();
            builder.Services.AddOpenApi();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowNextJS", policy =>
                {
                    policy.WithOrigins("http://localhost:3000") 
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowNextJS");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
