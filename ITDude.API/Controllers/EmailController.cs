using FluentEmail.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITDude.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost("SendEmail")]
        public async Task<IActionResult> SendSingleEmail([FromServices] IFluentEmail singleEmail)
        {
            var email = singleEmail
                .To("test@outlook.com")
                .Subject("Test email")
                .Body("This is a single email");

            await email.SendAsync();

            return Ok();
        }
    }
}
