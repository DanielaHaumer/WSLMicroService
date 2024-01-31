
using Campus02WebService.Models;
using Campus02WebService.Services;
using Microsoft.EntityFrameworkCore;

namespace Campus02WebService
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

            //1. Interface extrahieren
            //2. Klasse erstellen / Interface implementieren
            //3. Interface als Service registrieren
            //4. Im Controller Konstruktor Injection

            builder.Services.Add(
                new ServiceDescriptor(typeof(ILieferkostenCalculator),
                new LieferkostenCalculator()));
            builder.Services.Add(
                new ServiceDescriptor(typeof(IMyService),
                new MyService()));
            builder.Services.AddDbContext<ToDoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            builder.Services.AddTransient<IApiKeyValidation, ApiKeyValidation>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            var app = builder.Build();

            app.UseCors("AllowAll");

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
