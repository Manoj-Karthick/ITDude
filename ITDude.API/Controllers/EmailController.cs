using FluentEmail.Core;
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
            Email.DefaultSender = singleEmail.Sender;
            try
            {
                var email = await Email
                .From("test@test.com")
                .To("test@test.com", "TestUser")
                .Subject("Test email")
                .Body("Sending email from .net application").SendAsync();

                if (email.Successful)
                    return Ok();
                
            }
            catch(Exception ex)
            {
                // implement logging
            }
            return BadRequest();
        }
    }
}
