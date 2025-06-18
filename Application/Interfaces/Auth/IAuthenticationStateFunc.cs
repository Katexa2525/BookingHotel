namespace Application.Interfaces.Auth
{
  public interface IAuthenticationStateFunc
  {
    /// <summary>Метод получения UserId Keycloak из ClaimsPrincipal </summary>
    Task<string> GetUserIdFromClaimsPrincipal();
    /// <summary>Метод получения UserName Keycloak из ClaimsPrincipal </summary>
    Task<string> GetUserNameFromClaimsPrincipal();

  }
}
