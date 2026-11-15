using Application.DTO.Hotel;
using MediatR;

namespace Application.DTO.Hotel.CQRS
{
  public class GetAllHotelQuery : IRequest<HotelListPageDto>
  {
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public string? SearchTerm { get; set; }
    public double? MinRating { get; set; }
    public double? MaxRating { get; set; }
  }
}
