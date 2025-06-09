using MediatR;

namespace Application.DTO.TypeFood.ClientRequest
{
  public record AddTypeFoodRequest(TypeFoodCreateWithIdDto TypeFood) : IRequest<AddTypeFoodRequest.Response>
  {
    /// <summary>Адрес конечной точки</summary>
    public const string RouteTemplate = "api/typefoods/create";

    /// <summary>Вложенная запись определяет данные ответа на запрос</summary>
    public record Response(Guid typefoodId);
  }
}
