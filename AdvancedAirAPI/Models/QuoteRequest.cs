namespace AdvancedAirAPI.Models
{
    public class RoomDetail
    {
        public string Size { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }

    public class QuoteRequest
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string PreferredContactMethod { get; set; } = string.Empty;
        public string UrgencyLevel { get; set; } = string.Empty;
        public string ServiceType { get; set; } = string.Empty;
        public string PreferredDate { get; set; } = string.Empty;
        public string AdditionalInformation { get; set; } = string.Empty;
        public List<RoomDetail> Rooms { get; set; } = new();
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}