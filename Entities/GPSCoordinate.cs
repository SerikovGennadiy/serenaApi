namespace Entities
{
    public class GPSCoordinate(double latitude, double longitude)
    {
        public double Latitude { get; } = latitude;
        public double Longitude { get; } = longitude;


        private double ConvertToRadian(double _part) => _part * (Math.PI / 180); 

        public double GetLatitudeInRadian() => ConvertToRadian(Latitude);
        public double GetLongitudeInRadian() => ConvertToRadian(Longitude);
        
        public static GPSCoordinate operator - (GPSCoordinate from, GPSCoordinate to)
        {
            return new GPSCoordinate(to.Latitude - from.Latitude, to.Longitude - from.Longitude);
        }
    }
}
