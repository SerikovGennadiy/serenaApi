namespace Entities
{
    public class IATAPort
    {
        public string PortCode { get; init; } = null!;
        public GPSCoordinate geoPoint { get; init; } = new(default, default);
    }

    public static class IATAPortDeconstruct
    {
        public static void Deconstruct(this IATAPort[] ports, out IATAPort departure, out IATAPort destination)
        {
            departure = ports[0];
            destination = ports[1];
        }
    }
}
