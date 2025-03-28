using Application.DTO.Login;
using Application.DTO.Registration;

namespace Application.BussinessLogic.Authentication
{
  public interface IAuthenticationService
  {
    Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration);
    Task<AuthResponseDto> Login(UserForAuthenticationDto userForAuthentication);
    Task Logout();
  }
}
