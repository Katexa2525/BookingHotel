using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Login
{
  public class UserForAuthenticationDto
  {
    [Required(ErrorMessage = "Требуется электронная почта.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Требуется пароль")]
    public string Password { get; set; }
  }
}
