using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Registration
{
  public class UserForRegistrationDto
  {
    [Required(ErrorMessage = "Необходимо указать адрес электронной почты")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Пароль обязателен")]
    public string Password { get; set; }
    [Compare("Password", ErrorMessage = "Пароль и пароль подтверждения не совпадают.")]
    public string ConfirmPassword { get; set; }
  }
}
