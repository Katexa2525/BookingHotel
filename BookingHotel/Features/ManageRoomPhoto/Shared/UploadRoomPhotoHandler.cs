using Application.DTO.RoomPhoto.ClientRequest;
using MediatR;

namespace BookingHotel.Features.ManageRoomPhoto.Shared
{
  public class UploadRoomPhotoHandler : IRequestHandler<UploadRoomPhotoRequest, UploadRoomPhotoRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public UploadRoomPhotoHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<UploadRoomPhotoRequest.Response> Handle(UploadRoomPhotoRequest request, CancellationToken cancellationToken)
    {
      // тип IBrowserFile включает вспомогательный метод, позволяющий считывать файл как поток
      Stream? fileContent = request.File.OpenReadStream(request.File.Size, cancellationToken);

      // создаю тип MultipartFormDataContent и к нему добавляется файл 
      using var content = new MultipartFormDataContent();
      content.Add(new StreamContent(fileContent), "image", request.File.Name);

      HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");
      // файл отправляется в API серверной части, заменяю поле {hotelId} в шаблоне маршрута на идентификатор тропы, передаваемый в запросе
      HttpResponseMessage? response = await httpClient.PostAsync(
        UploadRoomPhotoRequest.RouteTemplate.Replace("{roomId}", request.RoomId.ToString()), content, cancellationToken);

      if (response.IsSuccessStatusCode)
      {
        // если загрузка прошла успешно, десериализуем и возвращаем ответ
        string? fileName = await response.Content.ReadAsStringAsync(cancellationToken: cancellationToken);
        return new UploadRoomPhotoRequest.Response(fileName);
      }
      else
      {
        // если загрузка не удалась, возвращается ответ, содержащий пустую строку
        return new UploadRoomPhotoRequest.Response("");
      }
    }
  }
}
