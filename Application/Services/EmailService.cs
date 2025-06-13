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
      var client = new System.Net.Mail.SmtpClient();
      client.Port = int.Parse(_configuration["SmtpPort"]); // Замените на свой SMTP порт
      client.Host = _configuration["SmtpServer"]; // Замените на свой SMTP сервер
      client.EnableSsl = true; // Замените на true, если используется SSL/TLS
      client.DeliveryMethod = SmtpDeliveryMethod.Network;
      client.UseDefaultCredentials = false;
      client.Credentials = new System.Net.NetworkCredential(_configuration["SmtpUsername"], _configuration["SmtpPassword"]);

      var message = new System.Net.Mail.MailMessage(
          _configuration["FromEmailAddress"],
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
