using Application.DTO.Registration;

namespace Application.BussinessLogic.Authentication
{
  public interface IAuthenticationService
  {
    Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration);
  }
}
