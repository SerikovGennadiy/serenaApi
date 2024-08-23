using AutoMapper;
using Contracts;
using DTO;
using Entities;
using Service.Contracts;

namespace Service
{
    internal class RangeService : IRangeService
    {
        private const double EARTH_RADIUS_IN_METERS = 6378137D;
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;
        public RangeService(IMapper mapper, ILoggerService logger)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public OrthodromyDistance CalculateDistance(IATAPort takeOffPort, IATAPort landingPort)
        {
            GPSCoordinate begin = takeOffPort.geoPoint;
            GPSCoordinate end = landingPort.geoPoint;
            GPSCoordinate delta = end - begin;
            

            double temp = Math.Pow(Math.Sin(delta.GetLatitudeInRadian() / 2D), 2D)
                         + Math.Cos(begin.GetLatitudeInRadian())
                         * Math.Cos(end.GetLatitudeInRadian())
                         * Math.Pow(Math.Sin(delta.GetLongitudeInRadian() / 2D), 2D);
                              
            double orthodromyDegrees = 2D * Math.Atan2(Math.Sqrt(temp), Math.Sqrt(1D - temp));
            double orthodromyDistance = EARTH_RADIUS_IN_METERS * orthodromyDegrees;

            return new OrthodromyDistance(from: takeOffPort.PortCode
                                        , to: landingPort.PortCode
                                        , distanceInMeters: orthodromyDistance);
        }
    }
}
