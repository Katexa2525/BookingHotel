using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using System.Security.Claims;
using System.Text.Json;

namespace Application.BussinessLogic.RoleClaim
{
  public class MultipleRoleClaimsPrincipalFactory<TAccount> : AccountClaimsPrincipalFactory<TAccount>
                                             where TAccount : RemoteUserAccount
  {
    public MultipleRoleClaimsPrincipalFactory(IAccessTokenProviderAccessor accessor) : base(accessor)
    {    }

    public async override ValueTask<ClaimsPrincipal> CreateUserAsync(TAccount account, RemoteAuthenticationUserOptions options)
    {
      var user = await base.CreateUserAsync(account, options);
      if (user.Identity is ClaimsIdentity claimsIdentity)
        MapArrayClaimsToMultipleSeparateClaims(account, claimsIdentity);

      return user;
    }

    private static void MapArrayClaimsToMultipleSeparateClaims(TAccount account, ClaimsIdentity claimsIdentity)
    {
      var additionalProperties = account?.AdditionalProperties;
      if (additionalProperties is null)
        return;

      foreach (var prop in additionalProperties)
      {
        var value = prop.Value;
        if (value is JsonElement element && element.ValueKind == JsonValueKind.Array)
        {
          var existingClaim = claimsIdentity.FindFirst(prop.Key);
          if (existingClaim is not null)
            claimsIdentity.RemoveClaim(existingClaim);

          var claims = element.EnumerateArray()
                                              .Select(x => new Claim(prop.Key, x.ToString()));
          claimsIdentity.AddClaims(claims);
        }
      }
    }
  }
}
