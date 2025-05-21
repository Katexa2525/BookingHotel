using MediatR;

namespace Application.DTO.Food.ClientRequest
{
  public record AddFoodRequest(FoodCreateWithIdDto Food) : IRequest<AddFoodRequest.Response>
  {
    /// <summary>Адрес конечной точки</summary>
    public const string RouteTemplate = "api/foods/create";

    /// <summary>Вложенная запись определяет данные ответа на запрос</summary>
    public record Response(Guid foodId);
  }
}
