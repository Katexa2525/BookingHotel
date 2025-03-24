namespace Domain.Models
{
  public class Hotel : BaseEntity
  {
    /// <summary> Описание отеля </summary>
    public string Description { get; set; } = string.Empty;
    /// <summary> Основное фото отеля </summary>
    public string MainPhoto { get; set; } = string.Empty;
    /// <summary>Рейтинг отеля </summary>
    public double Rating { get; set; }
    /// <summary> Кол-во звезд отеля </summary>
    public int Star { get; set; }
    /// <summary> Местоположение самого отеля </summary>
    public string Location { get; set; } = string.Empty;
    /// <summary> Коллекция номеров в отеле </summary>
    public IEnumerable<Room> Rooms { get; set; } = Array.Empty<Room>();
    /// <summary> Типы питания, предостовляемые отелем </summary>
    public IEnumerable<Food> Foods { get; set; } = Array.Empty<Food>();
    /// <summary> Удобства, предоставляемые отелем, например: wifi, парковка, трансфер и тд  </summary>
    public IEnumerable<HotelFacility> HotelFacilities { get; set; } = Array.Empty<HotelFacility>();
    /// <summary> Коллекция фоток отеля </summary>
    public IEnumerable<HotelPhoto> HotelPhotos { get; set; } = Array.Empty<HotelPhoto>();
    /// <summary> Местоположение рядом находящихся объектов, например, рядом аэропорт, рядом подъемник, ботанический сад в 15 км и тд </summary>
    public IEnumerable<Location> Locations { get; set; } = Array.Empty<Location>();
    public IEnumerable<Price> Prices { get; set; } = Array.Empty<Price>();
    /// <summary> Отзывы по отелю </summary>
    public IEnumerable<Review> Reviews { get; set; } = Array.Empty<Review>();
    /// <summary>Связь один-к-одному по полезной информации по отелю </summary>
    public HotelUsefulInfo? HotelUsefulInfo { get; set; }
  }
}
