using AdvancedAirAPI.Models;
using AdvancedAirAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedAirAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ContactService _contactService;

        public ContactController(ContactService contactService)
        {
            _contactService = contactService;
        }

        // POST: api/contact
        [HttpPost]
        public IActionResult Submit([FromBody] ContactMessage message)
        {
            if (string.IsNullOrWhiteSpace(message.FullName) ||
                string.IsNullOrWhiteSpace(message.Email) ||
                string.IsNullOrWhiteSpace(message.Message))
            {
                return BadRequest(new { message = "Name, email, and message are required." });
            }

            var saved = _contactService.Save(message);
            return Ok(new
            {
                success = true,
                id = saved.Id,
                message = "Thank you. We'll be in touch within 2 hours during business hours."
            });
        }

        // GET: api/contact (optional — useful for debugging, would be removed in production)
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_contactService.GetAll());
        }
    }
}