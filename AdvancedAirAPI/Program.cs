using AdvancedAirAPI.Data;
using AdvancedAirAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAirAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ---------- Port (Render assigns one at runtime) ----------
            var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
            builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

            // ---------- Database ----------
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("SupabaseConnection")));

            // ---------- Application services ----------
            builder.Services.AddControllers();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<ServiceService>();
            builder.Services.AddScoped<ContactService>();
            builder.Services.AddScoped<CalloutService>();
            builder.Services.AddScoped<QuoteService>();

            // ---------- Swagger ----------
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ---------- CORS ----------
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp", policy =>
                {
                    var origins = builder.Configuration
                        .GetSection("Cors:AllowedOrigins")
                        .Get<string[]>()
                        ?? new[] { "http://localhost:5173" };

                    policy.WithOrigins(origins)
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Enable Swagger in all environments so you can test the deployed API
            app.UseSwagger();
            app.UseSwaggerUI();

            // Skip HTTPS redirect in production — Render terminates HTTPS for us
            if (!app.Environment.IsProduction())
            {
                app.UseHttpsRedirection();
            }

            app.UseCors("AllowReactApp");
            app.UseAuthorization();
            app.MapControllers();

            // Health check — returns 200 OK when the app is running
            app.MapGet("/health", () => Results.Ok(new
            {
                status = "healthy",
                timestamp = DateTime.UtcNow,
                environment = app.Environment.EnvironmentName
            }));

            app.Run();
        }
    }
}