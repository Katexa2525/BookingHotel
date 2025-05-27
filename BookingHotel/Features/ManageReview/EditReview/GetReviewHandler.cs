using Application.DTO.Review;
using Application.DTO.Review.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageReview.EditReview
{
  public class GetReviewHandler : IRequestHandler<GetReviewRequest, GetReviewRequest.Response?>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public GetReviewHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<GetReviewRequest.Response?> Handle(GetReviewRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Незащищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
        HttpClient? httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");

        string route = GetReviewRequest.RouteTemplate.Replace("{reviewId}", request.reviewId.ToString());

        var res = await httpClient.GetFromJsonAsync<ReviewDto?>(route, cancellationToken);

        return new GetReviewRequest.Response(res);
      }
      catch (HttpRequestException ex)
      {
        Console.WriteLine(ex.Message);
        return default!;
      }
    }
  }
}
