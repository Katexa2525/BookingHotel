using Application.Interfaces.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Application.BussinessLogic.AuthProviders
{
  public class AuthenticationStateFunc : IAuthenticationStateFunc
  {
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthenticationStateFunc(AuthenticationStateProvider authenticationStateProvider)
    {
      _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<string> GetUserIdFromClaimsPrincipal()
    {
      var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
      ClaimsPrincipal userClaimsPrincipal = authState.User;
      if (userClaimsPrincipal is not null && userClaimsPrincipal.Identity is not null && userClaimsPrincipal.Identity.IsAuthenticated)
      {
        var userId = userClaimsPrincipal.FindFirst(c => c.Type == "sub")?.Value;
        //Console.WriteLine($"User ID: {userId}");

        return userId is not null ? userId : string.Empty;
      }
      return string.Empty;
    }

    public async Task<string> GetUserNameFromClaimsPrincipal()
    {
      var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
      ClaimsPrincipal userClaimsPrincipal = authState.User;
      if (userClaimsPrincipal is not null && userClaimsPrincipal.Identity is not null && userClaimsPrincipal.Identity.IsAuthenticated)
      {
        var userName = userClaimsPrincipal.Identity.Name;
        //Console.WriteLine($"User ID: {userName}");

        return userName is not null ? userName : string.Empty;
      }
      return string.Empty;
    }

  }
}
