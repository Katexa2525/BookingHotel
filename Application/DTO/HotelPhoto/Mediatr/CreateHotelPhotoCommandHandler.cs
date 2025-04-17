using Application.BussinessLogic.HotelPhoto;
using Application.BussinessLogic.RoomPhoto;
using Application.DTO.HotelPhoto.CQRS;
using Application.DTO.RoomPhoto.CQRS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.HotelPhoto.Mediatr
{
  public class CreateHotelPhotoCommandHandler : IRequestHandler<CreateHotelPhotoCommand, Guid>
  {
    private readonly IHotelPhotoBussinessLogic _bussinessLogic;
    public CreateHotelPhotoCommandHandler(IHotelPhotoBussinessLogic bussinessLogic)
    {
      _bussinessLogic = bussinessLogic;
    }
    public async Task<Guid> Handle(CreateHotelPhotoCommand request, CancellationToken cancellationToken)
    {
      return await _bussinessLogic.CreateAsync(request.Dto);
    }
  }
}
