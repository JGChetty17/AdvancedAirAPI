using AdvancedAirAPI.Data;
using AdvancedAirAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAirAPI.Services
{
    public class ServiceService
    {
        private readonly AppDbContext _db;

        public ServiceService(AppDbContext db)
        {
            _db = db;
        }

        public List<ServiceItem> GetAll() =>
            _db.Services.AsNoTracking().OrderBy(s => s.Title).ToList();

        public ServiceItem? GetById(string id) =>
            _db.Services.AsNoTracking().FirstOrDefault(s => s.Id == id);
    }
}