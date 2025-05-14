using Application.Interfaces.Repository;

namespace Infrastructure.Repository
{
  /// <summary>
  /// Класс менеджера репозитория, который создаст экземпляры пользовательских классов репозитория, а затем
  /// зарегистрирует их внутри контейнера внедрения зависимостей.После этого можно внедрить его внутри сервисов 
  /// с помощью внедрения конструктора(при поддержке ASP.NET Core). Имея класс менеджера репозитория, можно вызвать
  /// любой класс пользователя репозитория, который нам нужен.
  /// </summary>
  public sealed class RepositoryManager : IRepositoryManager
  {
    private readonly RepositoryContext _repositoryContext;

    private readonly Lazy<IRoomRepository> _roomRepository;
    private readonly Lazy<IPriceRepository> _priceRepository;
    private readonly Lazy<IRoomFacilityRepository> _roomFacilityRepository;
    private readonly Lazy<IRoomPhotoRepository> _roomPhotoRepository;
    private readonly Lazy<IFoodRepository> _foodRepository;
    private readonly Lazy<IHotelRepository> _hotelRepository;
    private readonly Lazy<IHotelFacilityRepository> _hotelFacilityRepository;
    private readonly Lazy<IHotelPhotoRepository> _hotelPhotoRepository;
    private readonly Lazy<ILocationRepository> _locationRepository;
    private readonly Lazy<IReviewRepository> _reviewRepository;
    private readonly Lazy<IRoomTypeRepository> _roomTypeRepository;
    private readonly Lazy<ITypeFoodRepository> _typeFoodRepository;
    private readonly Lazy<IBookingRepository> _bookingRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
      _repositoryContext = repositoryContext;

      _roomRepository = new Lazy<IRoomRepository>(() => new RoomRepository(repositoryContext));
      _priceRepository = new Lazy<IPriceRepository>(() => new PriceRepository(repositoryContext));
      _roomFacilityRepository = new Lazy<IRoomFacilityRepository>(() => new RoomFacilityRepository(repositoryContext));
      _roomPhotoRepository = new Lazy<IRoomPhotoRepository>(() => new RoomPhotoRepository(repositoryContext));
      _foodRepository = new Lazy<IFoodRepository>(() => new FoodRepository(repositoryContext));
      _hotelRepository = new Lazy<IHotelRepository>(() => new HotelRepository(repositoryContext));
      _hotelFacilityRepository = new Lazy<IHotelFacilityRepository>(() => new HotelFacilityRepository(repositoryContext));
      _hotelPhotoRepository = new Lazy<IHotelPhotoRepository>(() => new HotelPhotoRepository(repositoryContext));
      _locationRepository = new Lazy<ILocationRepository>(() => new LocationRepository(repositoryContext));
      _reviewRepository = new Lazy<IReviewRepository>(() => new ReviewRepository(repositoryContext));
      _roomTypeRepository = new Lazy<IRoomTypeRepository>(() => new RoomTypeRepository(repositoryContext));
      _typeFoodRepository = new Lazy<ITypeFoodRepository>(() => new TypeFoodRepository(repositoryContext));
      _bookingRepository = new Lazy<IBookingRepository>(() => new BookingRepository(repositoryContext));
    }

    public IRoomRepository RoomRepository => _roomRepository.Value;
    public IPriceRepository PriceRepository => _priceRepository.Value;
    public IRoomFacilityRepository RoomFacilityRepository => _roomFacilityRepository.Value;
    public IRoomPhotoRepository RoomPhotoRepository => _roomPhotoRepository.Value;
    public IFoodRepository FoodRepository => _foodRepository.Value;
    public IHotelRepository HotelRepository => _hotelRepository.Value;
    public IHotelFacilityRepository HotelFacilityRepository => _hotelFacilityRepository.Value;
    public IHotelPhotoRepository HotelPhotoRepository => _hotelPhotoRepository.Value;
    public ILocationRepository LocationRepository => _locationRepository.Value;
    public IReviewRepository ReviewRepository => _reviewRepository.Value;
    public IRoomTypeRepository RoomTypeRepository => _roomTypeRepository.Value;
    public ITypeFoodRepository TypeFoodRepository => _typeFoodRepository.Value;
    public IBookingRepository BookingRepository => _bookingRepository.Value;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    public void Save() => _repositoryContext.SaveChanges();

  }
}
