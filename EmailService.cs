using Mailjet.Client;
using Mailjet.Client.Resources;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace myEmailService.WebApp
{
    public class EmailService
    {
        public async Task<bool> SendEmail(string toEmail, string subject, string body)
        {
            MailjetClient client = new MailjetClient("YOUR_MAILJET_API_KEY", "YOUR_MAILJET_API_SECRET");

            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
                .Property(Send.Messages, new JArray {
                    new JObject {
                        {
                            "From",
                            new JObject {
                                { "Email", "your-email@example.com" },
                                { "Name", "Your Name" }
                            }
                        },
                        {
                            "To",
                            new JArray {
                                new JObject {
                                    { "Email", toEmail }
                                }
                            }
                        },
                        {
                            "Subject",
                            subject
                        },
                        {
                            "TextPart",
                            body
                        },
                        {
                            "HTMLPart",
                            body
                        }
                    }
                });

            MailjetResponse response = await client.PostAsync(request);

            if (response.IsSuccessStatusCode)
            {
                // E-mail został wysłany pomyślnie
                return true;
            }
            else
            {
                // Wystąpił błąd podczas wysyłania e-maila
                return false;
            }
        }
    }
}
