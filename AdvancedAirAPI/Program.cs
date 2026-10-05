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
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("SupabaseConnection"),
                    npgsqlOptions =>
                    {
                        npgsqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorCodesToAdd: null
                        );
                        npgsqlOptions.CommandTimeout(30);
                    }));

            // ---------- Application services ----------
            builder.Services.AddMemoryCache();
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

            // Enable Swagger in all environments
            app.UseSwagger();
            app.UseSwaggerUI();

            // NOTE: HTTPS redirect intentionally disabled.
            // Render terminates HTTPS at the proxy level.
            // app.UseHttpsRedirection();

            app.UseCors("AllowReactApp");
            app.UseAuthorization();
            app.MapControllers();

            // Health check
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