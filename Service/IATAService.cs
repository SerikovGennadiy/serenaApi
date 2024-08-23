using DTO;
using AutoMapper;
using System.Net.Http.Json;
using Service.Contracts;
using Entities;
using Contracts;
using Entities.Exceptions;

namespace Service
{
    public class IATAService : IIATAService, IDisposable
    {
        private readonly IMapper _mapper;
        private readonly ILoggerService _logger;
        public IATAService(IMapper mapper, ILoggerService logger)
        {
            _mapper = mapper;
            _logger = logger;
        }


        private readonly HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://places-dev.cteleport.com/airports/")
        };

        public async Task<IATAPort> GetIATAPortLocation(string iataAirportCode)
        {
            var response = await client.GetAsync(iataAirportCode);
            var iataPortDTO = await response.Content.ReadFromJsonAsync<IATAPortApiDTO>();
            if (iataPortDTO!.iata is null)
                throw new IATAPortNotFoundException(iataAirportCode);

            return _mapper.Map<IATAPort>(iataPortDTO);
        }
        public void Dispose()
        {
            client.Dispose();
        }
    }
}
