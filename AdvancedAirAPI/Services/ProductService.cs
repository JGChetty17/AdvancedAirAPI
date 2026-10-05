using AdvancedAirAPI.Data;
using AdvancedAirAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace AdvancedAirAPI.Services
{
    public class ProductService
    {
        private readonly AppDbContext _db;
        private readonly IMemoryCache _cache;
        private const string AllCacheKey = "products_all";

        public ProductService(AppDbContext db, IMemoryCache cache)
        {
            _db = db;
            _cache = cache;
        }

        public List<Product> GetAll()
        {
            if (_cache.TryGetValue(AllCacheKey, out List<Product>? cached) && cached != null)
            {
                return cached;
            }

            var products = _db.Products
                .AsNoTracking()
                .OrderBy(p => p.Name)
                .ToList();

            _cache.Set(AllCacheKey, products, TimeSpan.FromMinutes(5));
            return products;
        }

        public Product? GetById(string id)
        {
            // Single item lookups are cheap; caching them isn't worth the memory
            return _db.Products
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }
    }
}