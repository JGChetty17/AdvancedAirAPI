using AdvancedAirAPI.Data;
using AdvancedAirAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAirAPI.Services
{
    public class ContactService
    {
        private readonly AppDbContext _db;

        public ContactService(AppDbContext db)
        {
            _db = db;
        }

        public ContactMessage Save(ContactMessage message)
        {
            message.Id = 0;   // let Postgres SERIAL assign the id
            message.SubmittedAt = DateTime.UtcNow;
            _db.ContactMessages.Add(message);
            _db.SaveChanges();
            return message;
        }

        public List<ContactMessage> GetAll() =>
            _db.ContactMessages.AsNoTracking()
                .OrderByDescending(c => c.SubmittedAt)
                .ToList();
    }
}