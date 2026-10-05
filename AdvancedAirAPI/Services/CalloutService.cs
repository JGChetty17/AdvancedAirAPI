using AdvancedAirAPI.Data;
using AdvancedAirAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAirAPI.Services
{
    public class CalloutService
    {
        private readonly AppDbContext _db;

        public CalloutService(AppDbContext db)
        {
            _db = db;
        }

        public CalloutRequest Save(CalloutRequest request)
        {
            request.Id = 0;
            request.SubmittedAt = DateTime.UtcNow;
            _db.CalloutRequests.Add(request);
            _db.SaveChanges();
            return request;
        }

        public List<CalloutRequest> GetAll() =>
            _db.CalloutRequests.AsNoTracking()
                .OrderByDescending(c => c.SubmittedAt)
                .ToList();
    }
}