using AdvancedAirAPI.Models;
using AdvancedAirAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedAirAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuoteController : ControllerBase
    {
        private readonly QuoteService _quoteService;

        public QuoteController(QuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        // POST: api/quote
        [HttpPost]
        public IActionResult Submit([FromBody] QuoteRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Phone))
            {
                return BadRequest(new { message = "Name, email, and phone are required." });
            }

            if (request.Rooms.Count == 0)
            {
                return BadRequest(new { message = "Please add at least one room." });
            }

            var saved = _quoteService.Save(request);
            return Ok(new
            {
                success = true,
                id = saved.Id,
                message = "Your quote request has been received. Our team will prepare a detailed quote and get back to you shortly."
            });
        }

        // GET: api/quote (for debugging)
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_quoteService.GetAll());
        }
    }
}