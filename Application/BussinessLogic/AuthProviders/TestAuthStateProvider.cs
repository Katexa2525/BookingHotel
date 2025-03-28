using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Application.BussinessLogic.AuthProviders
{
  /// <summary>
  /// Класс предоставит информацию о состоянии аутентификации пользователя - будь то аутентификация или нет, каковы его претензии и т. Д.
  /// </summary>
  public class TestAuthStateProvider : AuthenticationStateProvider
  {
    public async override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
      await Task.Delay(1000);

      var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, "John Doe"),
        new Claim(ClaimTypes.Role, "Administrator")
    };

      ClaimsIdentity? anonymous = new ClaimsIdentity();
      return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
    }
  }
}
