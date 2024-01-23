
using VisitorSecurityClearnceSystem.Common;
using VisitorSecurityClearnceSystem.CosmosDBService;
using VisitorSecurityClearnceSystem.Interfaces;
using VisitorSecurityClearnceSystem.Services;

namespace VisitorSecurityClearnceSystem
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

            builder.Services.AddSingleton<IManagerService,ManegerService>();
            builder.Services.AddSingleton<ICosmosService,CosmosService>();
            builder.Services.AddSingleton<IVisitorService,VisitorService>();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


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
