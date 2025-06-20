﻿namespace Application.Interfaces.Email
{
  public interface IEmailService
  {
    Task SendEmailAsync(string toEmail, string subject, string body);
  }
}
