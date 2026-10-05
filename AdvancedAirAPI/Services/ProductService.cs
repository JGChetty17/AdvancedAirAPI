using AdvancedAirAPI.Data;
using AdvancedAirAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAirAPI.Services
{
    public class ProductService
    {
        private readonly AppDbContext _db;

        public ProductService(AppDbContext db)
        {
            _db = db;
        }

        public List<Product> GetAll() =>
            _db.Products.AsNoTracking().OrderBy(p => p.Name).ToList();

        public Product? GetById(string id) =>
            _db.Products.AsNoTracking().FirstOrDefault(p => p.Id == id);
    }
}