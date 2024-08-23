using Entities;

namespace Service.Contracts
{
    public interface IIATAService
    {
        Task<IATAPort> GetIATAPortLocation(string iataAirportCode);
    }
}
