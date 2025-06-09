using MediatR;

namespace Application.DTO.TypeFood.ClientRequest
{
  public record GetTypeFoodsRequest : IRequest<GetTypeFoodsRequest.Response>
  {
    public const string RouteTemplate = "api/typefoods";

    public record Response(List<TypeFoodDto>? TypeFoods);
  }
}
