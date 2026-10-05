using AdvancedAirAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedAirAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<ServiceItem> Services => Set<ServiceItem>();
        public DbSet<ContactMessage> ContactMessages => Set<ContactMessage>();
        public DbSet<CalloutRequest> CalloutRequests => Set<CalloutRequest>();
        public DbSet<QuoteRequest> QuoteRequests => Set<QuoteRequest>();
        public DbSet<RoomDetail> QuoteRooms => Set<RoomDetail>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ---------- products ----------
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).HasColumnName("id");
                entity.Property(p => p.Name).HasColumnName("name");
                entity.Property(p => p.Brand).HasColumnName("brand");
                entity.Property(p => p.Model).HasColumnName("model");
                entity.Property(p => p.Btu).HasColumnName("btu");
                entity.Property(p => p.Price).HasColumnName("price");
                entity.Property(p => p.Description).HasColumnName("description");
                entity.Property(p => p.Rating).HasColumnName("rating");
                entity.Property(p => p.Image).HasColumnName("image");
                entity.Property(p => p.Coverage).HasColumnName("coverage");
                entity.Property(p => p.Features).HasColumnName("features");
            });

            // ---------- services ----------
            modelBuilder.Entity<ServiceItem>(entity =>
            {
                entity.ToTable("services");
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Id).HasColumnName("id");
                entity.Property(s => s.Title).HasColumnName("title");
                entity.Property(s => s.Description).HasColumnName("description");
                entity.Property(s => s.IconName).HasColumnName("icon_name");
                entity.Property(s => s.Bullets).HasColumnName("bullets");
            });

            // ---------- contact_messages ----------
            modelBuilder.Entity<ContactMessage>(entity =>
            {
                entity.ToTable("contact_messages");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).HasColumnName("id");
                entity.Property(c => c.FullName).HasColumnName("full_name");
                entity.Property(c => c.Email).HasColumnName("email");
                entity.Property(c => c.Phone).HasColumnName("phone");
                entity.Property(c => c.Subject).HasColumnName("subject");
                entity.Property(c => c.Message).HasColumnName("message");
                entity.Property(c => c.SubmittedAt).HasColumnName("submitted_at");
            });

            // ---------- callout_requests ----------
            modelBuilder.Entity<CalloutRequest>(entity =>
            {
                entity.ToTable("callout_requests");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).HasColumnName("id");
                entity.Property(c => c.FullName).HasColumnName("full_name");
                entity.Property(c => c.Phone).HasColumnName("phone");
                entity.Property(c => c.Email).HasColumnName("email");
                entity.Property(c => c.Urgency).HasColumnName("urgency");
                entity.Property(c => c.PropertyAddress).HasColumnName("property_address");
                entity.Property(c => c.IssueDescription).HasColumnName("issue_description");
                entity.Property(c => c.PreferredContactMethod).HasColumnName("preferred_contact_method");
                entity.Property(c => c.PreferredVisitTime).HasColumnName("preferred_visit_time");
                entity.Property(c => c.SubmittedAt).HasColumnName("submitted_at");
            });

            // ---------- quote_requests ----------
            modelBuilder.Entity<QuoteRequest>(entity =>
            {
                entity.ToTable("quote_requests");
                entity.HasKey(q => q.Id);
                entity.Property(q => q.Id).HasColumnName("id");
                entity.Property(q => q.FullName).HasColumnName("full_name");
                entity.Property(q => q.Email).HasColumnName("email");
                entity.Property(q => q.Phone).HasColumnName("phone");
                entity.Property(q => q.PreferredContactMethod).HasColumnName("preferred_contact_method");
                entity.Property(q => q.UrgencyLevel).HasColumnName("urgency_level");
                entity.Property(q => q.ServiceType).HasColumnName("service_type");
                entity.Property(q => q.PreferredDate).HasColumnName("preferred_date");
                entity.Property(q => q.AdditionalInformation).HasColumnName("additional_information");
                entity.Property(q => q.SubmittedAt).HasColumnName("submitted_at");

                // Ignore the Rooms navigation for now — we handle rooms manually
                entity.Ignore(q => q.Rooms);
            });

            // ---------- quote_rooms (child table, inserted manually for now) ----------
            modelBuilder.Entity<RoomDetail>(entity =>
            {
                entity.ToTable("quote_rooms");
                entity.HasNoKey(); // no primary key for now since we insert via raw SQL
            });
        }
    }
}