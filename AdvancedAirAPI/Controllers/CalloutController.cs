using AdvancedAirAPI.Models;
using AdvancedAirAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedAirAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalloutController : ControllerBase
    {
        private readonly CalloutService _calloutService;

        public CalloutController(CalloutService calloutService)
        {
            _calloutService = calloutService;
        }

        // POST: api/callout
        [HttpPost]
        public IActionResult Submit([FromBody] CalloutRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.Phone) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.PropertyAddress) ||
                string.IsNullOrWhiteSpace(request.IssueDescription))
            {
                return BadRequest(new { message = "Name, phone, email, address, and issue description are required." });
            }

            var saved = _calloutService.Save(request);
            return Ok(new
            {
                success = true,
                id = saved.Id,
                message = "Your callout has been booked. We'll contact you shortly to confirm."
            });
        }

        // GET: api/callout (for debugging)
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_calloutService.GetAll());
        }
    }
}