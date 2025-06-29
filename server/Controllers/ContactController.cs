using Microsoft.AspNetCore.Mvc;
using Server.Types;
using System.ComponentModel.DataAnnotations;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(Contact contact)
        {
            /*if (contact.BusinessName?.Length is < 8 or > 40)
            {
                return BadRequest(new { message = "Business name must be between 8 and 50 characters." });
            }*/

            return Ok(contact);
        }
    }
}