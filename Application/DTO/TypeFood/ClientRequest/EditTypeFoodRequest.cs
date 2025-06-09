using MediatR;

namespace Application.DTO.TypeFood.ClientRequest
{
  public record EditTypeFoodRequest(TypeFoodDto typefood) : IRequest<EditTypeFoodRequest.Response>
  {
    public const string RouteTemplate = "api/typefoods/edit";
    public record Response(bool IsSuccess);
  }
}
