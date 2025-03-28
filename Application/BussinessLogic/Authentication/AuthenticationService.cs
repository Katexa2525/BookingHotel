using Application.DTO.Registration;
using System.Text;
using System.Text.Json;

namespace Application.BussinessLogic.Authentication
{
  public class AuthenticationService : IAuthenticationService
  {
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;

    public AuthenticationService(HttpClient client)
    {
      _client = client;
      _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration)
    {
      string? content = JsonSerializer.Serialize(userForRegistration);
      StringContent? bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
      HttpResponseMessage? registrationResult = await _client.PostAsync("accounts/registration", bodyContent);
      string? registrationContent = await registrationResult.Content.ReadAsStringAsync();
      if (!registrationResult.IsSuccessStatusCode)
      {
        RegistrationResponseDto? result = JsonSerializer.Deserialize<RegistrationResponseDto>(registrationContent, _options);
        return result;
      }
      return new RegistrationResponseDto { IsSuccessfulRegistration = true };
    }
  }
}
