using Application.DTO.Hotel;

namespace Application.BussinessLogic.Hotel
{
    public interface IHotelBussinessLogic
    {
        Task<List<HotelDto>> GetAllAsync();
    }
}
