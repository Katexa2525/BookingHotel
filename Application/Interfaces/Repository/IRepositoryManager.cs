using Domain.Models;

namespace Application.Interfaces.Repository
{
  public interface IRepositoryManager
  {
    IRoomRepository RoomRepository { get; }
    IPriceRepository PriceRepository { get; }
    IRoomFacilityRepository RoomFacilityRepository { get; }
    IRoomPhotoRepository RoomPhotoRepository { get; }
    IFoodRepository FoodRepository { get; }
    IHotelRepository HotelRepository { get; }
    IHotelFacilityRepository HotelFacilityRepository { get; }
    IHotelPhotoRepository HotelPhotoRepository { get; }
    ILocationRepository LocationRepository { get; }
    IReviewRepository ReviewRepository { get; }
    IRoomTypeRepository RoomTypeRepository { get; }
    ITypeFoodRepository TypeFoodRepository { get; }
    IBookingRepository BookingRepository { get; }

    Task SaveAsync();
    void Save();
  }
}
