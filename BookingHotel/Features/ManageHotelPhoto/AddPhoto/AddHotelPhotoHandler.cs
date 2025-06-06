﻿using Application.DTO.HotelPhoto.ClientRequest;
using MediatR;
using System.Net.Http.Json;

namespace BookingHotel.Features.ManageHotelPhoto.AddPhoto
{
  public class AddHotelPhotoHandler : IRequestHandler<AddHotelPhotoRequest, AddHotelPhotoRequest.Response>
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public AddHotelPhotoHandler(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<AddHotelPhotoRequest.Response> Handle(AddHotelPhotoRequest request, CancellationToken cancellationToken)
    {
      try
      {
        // Защищенный HttpClient используется для вызова API с использованием шаблона маршрута, который определили для запроса
        HttpClient? httpClient = _httpClientFactory.CreateClient("SecureAPIClient");
        //httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        var response = await httpClient.PostAsJsonAsync(AddHotelPhotoRequest.RouteTemplate, request, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
          Guid hotelFacilityId = await response.Content.ReadFromJsonAsync<Guid>(cancellationToken);
          // если запрос был успешным, то hotelId считывается из ответа и возвращается с помощью записи AddHotelRequest.Response
          return new AddHotelPhotoRequest.Response(hotelFacilityId);
        }
        else
        {
          // если запрос не выполнен
          return new AddHotelPhotoRequest.Response(Guid.Empty);
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
