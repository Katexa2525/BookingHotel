using Application.Interfaces.Email;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace Application.Services
{
  public class EmailService : IEmailService
  {
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string body)
    {
      var smtpPortText = _configuration["SmtpPort"]
          ?? throw new InvalidOperationException("Configuration value 'SmtpPort' is required.");
      if (!int.TryParse(smtpPortText, out var smtpPort))
        throw new InvalidOperationException("Configuration value 'SmtpPort' must be a valid integer.");

      var smtpServer = _configuration["SmtpServer"]
          ?? throw new InvalidOperationException("Configuration value 'SmtpServer' is required.");
      var smtpUsername = _configuration["SmtpUsername"]
          ?? throw new InvalidOperationException("Configuration value 'SmtpUsername' is required.");
      var smtpPassword = _configuration["SmtpPassword"]
          ?? throw new InvalidOperationException("Configuration value 'SmtpPassword' is required.");
      var fromEmailAddress = _configuration["FromEmailAddress"]
          ?? throw new InvalidOperationException("Configuration value 'FromEmailAddress' is required.");

      var client = new System.Net.Mail.SmtpClient();
      client.Port = smtpPort;
      client.Host = smtpServer;
      client.EnableSsl = true; // Замените на true, если используется SSL/TLS
      client.DeliveryMethod = SmtpDeliveryMethod.Network;
      client.UseDefaultCredentials = false;
      client.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword);

      var message = new System.Net.Mail.MailMessage(
          fromEmailAddress,
          toEmail,
          subject,
          body);

      try
      {
        await client.SendMailAsync(message);
      }
      catch (Exception ex)
      {
        // Обработка исключений
        Console.WriteLine($"Ошибка при отправке почты: {ex.Message}");
      }
    }
  }
}
