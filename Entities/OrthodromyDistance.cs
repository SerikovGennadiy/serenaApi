using System.Net.Mime;

namespace Entities
{
    // Международная авиационная миля равна международной морской (1852 м)
    public class OrthodromyDistance(string from, string to, double distanceInMeters)
    {
        private const double NAVIMILE = 1852.0;
        private const double LANDMILE = 1609.3;
        private const double KILOMETR = 1000.0;

        private readonly double _nameMilesValue = double.Round(distanceInMeters / NAVIMILE, 3);
        private readonly double _landMilesValue = double.Round(distanceInMeters / LANDMILE, 3);
        private readonly double _kiloMetersValue = double.Round(distanceInMeters / KILOMETR, 3);

        public string From => from;
        public string To => to;
        public double Nm  => _nameMilesValue;
        public double Lm  => _landMilesValue;
        public double Km  => _kiloMetersValue;
    }
}