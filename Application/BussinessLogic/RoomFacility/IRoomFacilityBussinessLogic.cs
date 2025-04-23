using Application.DTO.RoomFacility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BussinessLogic.RoomFacility
{
  public interface IRoomFacilityBussinessLogic
  {
    Task<List<RoomFacilityDto>> GetAllAsync();
    Task<RoomFacilityDto> GetByIdAsync(Guid id);
    Task<Guid> CreateAsync(RoomFacilityCreateWithIdDto dto);
    Task DeleteAsync(Guid roomFacilityId);
    Task UpdateAsync(RoomFacilityDto dto);
  }
}
