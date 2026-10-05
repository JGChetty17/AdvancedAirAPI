using AdvancedAirAPI.Data;
using AdvancedAirAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAirAPI.Services
{
    public class QuoteService
    {
        private readonly AppDbContext _db;

        public QuoteService(AppDbContext db)
        {
            _db = db;
        }

        public QuoteRequest Save(QuoteRequest request)
        {
            // Save the parent quote first — Postgres assigns the id
            request.Id = 0;
            request.SubmittedAt = DateTime.UtcNow;
            _db.QuoteRequests.Add(request);
            _db.SaveChanges();

            // Save each room against the parent quote id
            foreach (var room in request.Rooms)
            {
                _db.Database.ExecuteSqlRaw(
                    @"INSERT INTO quote_rooms (quote_id, room_size, room_type, notes)
                      VALUES ({0}, {1}, {2}, {3})",
                    request.Id,
                    room.Size ?? string.Empty,
                    room.Type ?? string.Empty,
                    room.Notes ?? string.Empty
                );
            }

            return request;
        }

        public List<QuoteRequest> GetAll() =>
            _db.QuoteRequests.AsNoTracking()
                .OrderByDescending(q => q.SubmittedAt)
                .ToList();
    }
}