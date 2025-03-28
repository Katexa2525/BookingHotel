namespace Application.DTO.Login
{
  public class AuthResponseDto
  {
    public bool IsAuthSuccessful { get; set; }
    public string ErrorMessage { get; set; }
    public string Token { get; set; }
  }
}
