using Application.DTO.Review.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageReview.EditReview
{
  public class EditReviewHandler : IRequestHandler<EditReviewRequest, EditReviewRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public EditReviewHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<EditReviewRequest.Response> Handle(EditReviewRequest request, CancellationToken cancellationToken)
    {
      HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");

      //Получаю обновленные сведения об отеле и отправляю их в API через HTTP - запрос методом PUT
      var response = await httpClient.PutAsJsonAsync(EditReviewRequest.RouteTemplate, request, cancellationToken);
      if (response.IsSuccessStatusCode)
      {
        //Если запрос был успешным, вызывающей стороне отправляется ответ true
        return new EditReviewRequest.Response(true);
      }
      else
      {
        return new EditReviewRequest.Response(false);
      }
    }
  }
}
