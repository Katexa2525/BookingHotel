﻿using MediatR;

namespace Application.DTO.HotelFacility.ClientRequest
{
  public record GetHotelFacilitiesRequest(Guid hotelId) : IRequest<GetHotelFacilitiesRequest.Response>
  {
    public const string RouteTemplate = "api/hotels/{hotelId}/facilities";

    public record Response(List<HotelFacilityDto>? HotelFacilities);
  }
}
