namespace AdvancedAirAPI.Models
{
    public class ServiceItem
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> Bullets { get; set; } = new();
        public string IconName { get; set; } = string.Empty;
    }
}