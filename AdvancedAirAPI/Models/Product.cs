namespace AdvancedAirAPI.Models
{
    public class Product
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Btu { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Rating { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Coverage { get; set; } = string.Empty;
        public List<string> Features { get; set; } = new();
    }
}