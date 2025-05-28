using Application.DTO.Review.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageReview.AddReview
{
  public class AddReviewHandler : IRequestHandler<AddReviewRequest, AddReviewRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public AddReviewHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<AddReviewRequest.Response> Handle(AddReviewRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Защищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
        HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");

        var response = await httpClient.PostAsJsonAsync(AddReviewRequest.RouteTemplate, request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
          Guid reviewId = await response.Content.ReadFromJsonAsync<Guid>(cancellationToken);
          // если запрос был успешным, то roomId считывается из ответа и возвращается с помощью записи AddRoomRequest.Response
          return new AddReviewRequest.Response(reviewId);
        }
        else
        {
          // если запрос не выполнен
          return new AddReviewRequest.Response(Guid.Empty);
        }
      }
      catch (HttpRequestException)
      {
        //В противном случае вызывающая сторона получает в качестве ответа null
        return default!;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        return default!;
      }
    }
  }
}
