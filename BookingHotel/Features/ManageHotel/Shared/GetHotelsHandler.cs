using Application.DTO.Hotel;
using Application.DTO.Hotel.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageHotel.Shared
{
  public class GetHotelsHandler : IRequestHandler<GetHotelsRequest, HotelListPageDto?>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public GetHotelsHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<HotelListPageDto?> Handle(GetHotelsRequest request, CancellationToken cancellationToken)
    {
      try
      {
        var httpClient = _httpClientFactory.CreateClient("NoAuthenticationClient");
        var query = new List<string>
        {
          $"pageNumber={request.PageNumber}",
          $"pageSize={request.PageSize}"
        };
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
          query.Add($"searchTerm={Uri.EscapeDataString(request.SearchTerm)}");
        if (request.MinRating.HasValue)
          query.Add($"minRating={request.MinRating.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
        if (request.MaxRating.HasValue)
          query.Add($"maxRating={request.MaxRating.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)}");

        return await httpClient.GetFromJsonAsync<HotelListPageDto>(
          $"{GetHotelsRequest.RouteTemplate}?{string.Join("&", query)}", cancellationToken);
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
