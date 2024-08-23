using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private Lazy<IIATAService> _iataService;
        private Lazy<IRangeService> _rangeService;

        public ServiceManager(IMapper mapper, ILoggerService logger)
        {
            _iataService = new Lazy<IIATAService>(new IATAService(mapper, logger));
            _rangeService = new Lazy<IRangeService>(new RangeService(mapper, logger));
        }


        public IIATAService iataService => _iataService.Value;
        public IRangeService rangeService => _rangeService.Value;
    }
}
