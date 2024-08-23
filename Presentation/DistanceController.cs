using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Presentation
{
    [ApiController]
    [Route("/api/range")]
    public class DistanceController : Controller
    {
        private ILoggerService _logger;
        public DistanceController(ILoggerService logger) => _logger = logger;


        public IActionResult GetDistanceBetweend(string iataDeparturePort, string iataDestinationPort)
        {
            return Ok(new
            {
                Departure = iataDeparturePort,
                Destination = iataDestinationPort
            });
        }
    }
}
