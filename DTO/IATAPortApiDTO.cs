namespace DTO
{
    public class IATAPortApiDTO
    {
        public string iata { get; init; } = null!;
        public Location location { get; init; } = new();
        public class Location
        {
            public double lon { get; set; }
            public double lat { get; set; }
        }
    }
}
