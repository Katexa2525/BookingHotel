using Application.DTO.Food.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageHotelFood.EditFood
{
  public class EditHotelFoodHandler : IRequestHandler<EditFoodRequest, EditFoodRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public EditHotelFoodHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<EditFoodRequest.Response> Handle(EditFoodRequest request, CancellationToken cancellationToken)
    {
      HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");

      //Получаю обновленные сведения об отеле и отправляю их в API через HTTP - запрос методом PUT
      var response = await httpClient.PutAsJsonAsync(EditFoodRequest.RouteTemplate, request, cancellationToken);
      if (response.IsSuccessStatusCode)
      {
        //Если запрос был успешным, вызывающей стороне отправляется ответ true
        return new EditFoodRequest.Response(true);
      }
      else
      {
        return new EditFoodRequest.Response(false);
      }
    }
  }
}
