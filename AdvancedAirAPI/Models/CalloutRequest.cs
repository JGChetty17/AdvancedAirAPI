namespace AdvancedAirAPI.Models
{
    public class CalloutRequest
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Urgency { get; set; } = string.Empty;
        public string PropertyAddress { get; set; } = string.Empty;
        public string IssueDescription { get; set; } = string.Empty;
        public string PreferredContactMethod { get; set; } = string.Empty;
        public string? PreferredVisitTime { get; set; }   // nullable — optional field
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}