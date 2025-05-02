using Application.DTO.Hotel.ClientRequest;
using MediatR;

namespace BookingHotel.Features.ManageHotel.Shared
{
  public class UploadHotelImageHandler : IRequestHandler<UploadHotelImageRequest, UploadHotelImageRequest.Response>
  {
    private readonly HttpClient _httpClient;

    public UploadHotelImageHandler(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }

    public async Task<UploadHotelImageRequest.Response> Handle(UploadHotelImageRequest request, CancellationToken cancellationToken)
    {
      // тип IBrowserFile включает вспомогательный метод, позволяющий считывать файл как поток
      Stream? fileContent = request.File.OpenReadStream(request.File.Size, cancellationToken);

      // создаю тип MultipartFormDataContent и к нему добавляется файл 
      using var content = new MultipartFormDataContent();
      content.Add(new StreamContent(fileContent), "image", request.File.Name);

      // файл отправляется в API серверной части, заменяю поле {hotelId} в шаблоне маршрута на идентификатор тропы, передаваемый в запросе
      HttpResponseMessage? response = await _httpClient.PostAsync(UploadHotelImageRequest.RouteTemplate.Replace("{hotelId}", request.HotelId.ToString()), content, cancellationToken);

      if (response.IsSuccessStatusCode)
      {
        // если загрузка прошла успешно, десериализуем и возвращаем ответ
        string? fileName = await response.Content.ReadAsStringAsync(cancellationToken: cancellationToken);
        return new UploadHotelImageRequest.Response(fileName);
      }
      else
      {
        // если загрузка не удалась, возвращается ответ, содержащий пустую строку
        return new UploadHotelImageRequest.Response("");
      }
    }
  }
}
