using AdvancedAirAPI.Data;
using AdvancedAirAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace AdvancedAirAPI.Services
{
    public class ServiceService
    {
        private readonly AppDbContext _db;
        private readonly IMemoryCache _cache;
        private const string AllCacheKey = "services_all";

        public ServiceService(AppDbContext db, IMemoryCache cache)
        {
            _db = db;
            _cache = cache;
        }

        public List<ServiceItem> GetAll()
        {
            if (_cache.TryGetValue(AllCacheKey, out List<ServiceItem>? cached) && cached != null)
            {
                return cached;
            }

            var services = _db.Services
                .AsNoTracking()
                .OrderBy(s => s.Title)
                .ToList();

            _cache.Set(AllCacheKey, services, TimeSpan.FromMinutes(5));
            return services;
        }

        public ServiceItem? GetById(string id)
        {
            return _db.Services
                .AsNoTracking()
                .FirstOrDefault(s => s.Id == id);
        }
    }
}