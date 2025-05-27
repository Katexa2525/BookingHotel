using Application.DTO.Review;
using Application.DTO.Review.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageReview.Review
{
  public class GetReviewsHandler : IRequestHandler<GetReviewsRequest, GetReviewsRequest.Response?>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public GetReviewsHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<GetReviewsRequest.Response?> Handle(GetReviewsRequest request, CancellationToken cancellationToken)
    {
      try
      {
        HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");

        //Заполнитель hotelId в RouteTemplate заменяется идентификатором отеля, подлежащему редактированию, перед выполнением HTTP-запроса
        string route = GetReviewsRequest.RouteTemplate.Replace("{hotelId}", request.hotelId.ToString());

        // Выполняется запрос к API. В случае успеха ответ десериализуется и возвращается вызывающей стороне
        var allReviews = await httpClient.GetFromJsonAsync<List<ReviewDto>>(route, cancellationToken);
        if (allReviews == null)
          return new GetReviewsRequest.Response(new List<ReviewDto>());
        else
          return new GetReviewsRequest.Response(allReviews);
      }
      catch (HttpRequestException ex)
      {
        Console.WriteLine(ex.Message);
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
