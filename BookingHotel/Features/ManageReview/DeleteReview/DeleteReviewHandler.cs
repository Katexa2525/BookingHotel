using Application.DTO.Review.ClientRequest;
using MediatR;

namespace BookingHotel.Features.ManageReview.DeleteReview
{
  public class DeleteReviewHandler : IRequestHandler<DeleteReviewRequest, DeleteReviewRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public DeleteReviewHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<DeleteReviewRequest.Response> Handle(DeleteReviewRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Защищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
        HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");
        //Заполнитель locationId в RouteTemplate заменяется идентификатором озыва отеля, подлежащему редактированию, перед выполнением HTTP-запроса
        string route = DeleteReviewRequest.RouteTemplate.Replace("{reviewId}", request.reviewId.ToString());

        var requestDel = new HttpRequestMessage(HttpMethod.Delete, route);

        var response = await httpClient.SendAsync(requestDel);

        if (response.IsSuccessStatusCode)
        {
          return new DeleteReviewRequest.Response(true);
        }
        else
        {
          // если запрос не выполнен
          return new DeleteReviewRequest.Response(false);
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
