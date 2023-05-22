using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myEmailService.WebApp.Models;
using myEmailService.WebApp; // Dodaj odpowiedni using directive dla przestrzeni nazw EmailService

namespace myEmailService.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] EmailModel emailModel)
        {
            bool isEmailSent = await _emailService.SendEmail(emailModel.ToEmail, emailModel.Subject, emailModel.Body);

            if (isEmailSent)
            {
                return Ok("E-mail został wysłany pomyślnie.");
            }
            else
            {
                return BadRequest("Wystąpił błąd podczas wysyłania e-maila.");
            }
        }
    }
}
