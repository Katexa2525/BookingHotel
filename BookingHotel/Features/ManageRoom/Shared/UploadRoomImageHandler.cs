using Application.DTO.Room.ClientRequest;
using MediatR;

namespace BookingHotel.Features.ManageRoom.Shared
{
  public class UploadRoomImageHandler : IRequestHandler<UploadRoomImageRequest, UploadRoomImageRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public UploadRoomImageHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<UploadRoomImageRequest.Response> Handle(UploadRoomImageRequest request, CancellationToken cancellationToken)
    {
      // тип IBrowserFile включает вспомогательный метод, позволяющий считывать файл как поток
      Stream? fileContent = request.File.OpenReadStream(request.File.Size, cancellationToken);

      // создаю тип MultipartFormDataContent и к нему добавляется файл 
      using var content = new MultipartFormDataContent();
      content.Add(new StreamContent(fileContent), "image", request.File.Name);

      HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");
      // файл отправляется в API серверной части, заменяю поле {hotelId} в шаблоне маршрута на идентификатор тропы, передаваемый в запросе
      HttpResponseMessage? response = await httpClient.PostAsync(
        UploadRoomImageRequest.RouteTemplate.Replace("{roomId}", request.RoomId.ToString())
        , content, cancellationToken);

      if (response.IsSuccessStatusCode)
      {
        // если загрузка прошла успешно, десериализуем и возвращаем ответ
        string? fileName = await response.Content.ReadAsStringAsync(cancellationToken: cancellationToken);
        return new UploadRoomImageRequest.Response(fileName);
      }
      else
      {
        // если загрузка не удалась, возвращается ответ, содержащий пустую строку
        return new UploadRoomImageRequest.Response("");
      }
    }
  }
}
