namespace Application.DTO.Hotel
{
  public class HotelListPageDto
  {
    public List<HotelListDto> Hotels { get; set; } = new();
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
  }
}
