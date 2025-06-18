using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
  public class Hotel : BaseEntity
  {
    /// <summary> Описание отеля </summary>
    public string? Description { get; set; } = string.Empty;
    /// <summary> Основное фото отеля </summary>
    public string? MainPhoto { get; set; } = string.Empty;
    /// <summary>Рейтинг отеля </summary>
    public double Rating { get; set; }
    /// <summary> Кол-во звезд отеля </summary>
    [Range(1, 5)]
    public int Star { get; set; }
    /// <summary> Местоположение самого отеля </summary>
    public string Location { get; set; } = string.Empty;
    /// <summary>Время заезда в часах, например, с 14:00  </summary>
    [MaxLength(5)]
    public string? Arrival { get; set; } = string.Empty;
    /// <summary>Время выезда в часах, например, до 12:00  </summary>
    [MaxLength(5)]
    public string? Departure { get; set; } = string.Empty;
    /// <summary>Широта </summary>
    public double? Latitude { get; set; }
    /// <summary>Долгота </summary>
    public double? Longitude { get; set; }
    /// <summary> Коллекция номеров в отеле </summary>
    public ICollection<Room>? Rooms { get; set; }
    /// <summary> Типы питания, предостовляемые отелем </summary>
    public ICollection<Food>? Foods { get; set; }
    /// <summary> Удобства, предоставляемые отелем, например: wifi, парковка, трансфер и тд  </summary>
    public ICollection<HotelFacility>? HotelFacilities { get; set; }
    /// <summary> Коллекция фоток отеля </summary>
    public ICollection<HotelPhoto>? HotelPhotos { get; set; }
    /// <summary> Местоположение рядом находящихся объектов, например, рядом аэропорт, рядом подъемник, ботанический сад в 15 км и тд </summary>
    public ICollection<Location>? Locations { get; set; }
    /// <summary> Отзывы по отелю </summary>
    public ICollection<Review>? Reviews { get; set; }
    /// <summary>Связь один-к-одному по полезной информации по отелю </summary>
    public HotelUsefulInfo? HotelUsefulInfo { get; set; }
  }
}
