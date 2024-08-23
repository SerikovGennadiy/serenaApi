using DTO;
using Entities;

namespace Service.Contracts
{
    public interface IRangeService
    {
        OrthodromyDistance CalculateDistance(IATAPort takeOffPort, IATAPort landingPort);
    }
}
