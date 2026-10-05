using AdvancedAirAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedAirAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly ServiceService _serviceService;

        public ServicesController(ServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // GET: api/services
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_serviceService.GetAll());
        }

        // GET: api/services/installations
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var service = _serviceService.GetById(id);
            if (service == null)
                return NotFound(new { message = $"Service '{id}' not found" });

            return Ok(service);
        }
    }
}