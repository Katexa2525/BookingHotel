using Application.BussinessLogic.Authentication;
using Application.DTO.Registration;
using Microsoft.AspNetCore.Components;

namespace BookingHotel.Features.Registration
{
  public partial class RegistrationPage
  {
    private UserForRegistrationDto _userForRegistration = new UserForRegistrationDto();

    //[Inject]
    //public IAuthenticationService AuthenticationService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public bool ShowRegistrationErrors { get; set; }
    public IEnumerable<string> Errors { get; set; } = Array.Empty<string>();

    public async Task Register()
    {
      ShowRegistrationErrors = false;
      //RegistrationResponseDto? result = await AuthenticationService.RegisterUser(_userForRegistration);
      RegistrationResponseDto? result = new RegistrationResponseDto();
      if (!result.IsSuccessfulRegistration)
      {
        Errors = result.Errors;
        ShowRegistrationErrors = true;
      }
      else
      {
        NavigationManager.NavigateTo("/");
      }
    }
  }
}
