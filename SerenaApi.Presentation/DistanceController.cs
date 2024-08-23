using Entities;
using Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace SerenaApi.Presentation
{
    [ApiController]
    [Route("/api/range")]
    public class DistanceController : ControllerBase
    {
        private IServiceManager _service;
        public DistanceController(IServiceManager service) =>
            _service = service;


        [HttpGet("{taskOffPort}/{landingPort}")]
        public async Task<IActionResult> GetDistanceBetween(string taskOffPort, string landingPort)
        {
            (IATAPort departurePort, IATAPort destinationPort) = await Task.WhenAll(_service.iataService.GetIATAPortLocation(taskOffPort)
                                                                                  , _service.iataService.GetIATAPortLocation(landingPort));

            OrthodromyDistance distance = _service.rangeService.CalculateDistance(departurePort, destinationPort);

            return Ok(distance);
        }
    }
}
