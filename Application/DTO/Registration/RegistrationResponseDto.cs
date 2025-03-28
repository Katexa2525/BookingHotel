using Domain.Models;

namespace Application.DTO.Registration
{
  public class RegistrationResponseDto
  {
    public bool IsSuccessfulRegistration { get; set; } = false;
    public IEnumerable<string> Errors { get; set; } = Array.Empty<string>();
  }
}
