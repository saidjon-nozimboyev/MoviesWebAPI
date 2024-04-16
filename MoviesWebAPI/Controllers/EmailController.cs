using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MoviesWebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailController(IEmailService email) : ControllerBase
{
    private readonly IEmailService _email = email;
    [HttpPost]
    public async Task<IActionResult> SendMessageAsync([FromForm] string to, [FromForm] string subject, [FromForm] string body)
    {
        await _email.SendEmailAsync(to, subject, body);
        return Ok();
    }
}
