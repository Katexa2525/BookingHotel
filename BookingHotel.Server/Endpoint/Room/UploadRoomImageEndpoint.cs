using Application.ConstMessages;
using Application.DTO.Room;
using Application.DTO.Room.ClientRequest;
using Application.DTO.Room.CQRS;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace BookingHotel.Server.Endpoint.Room
{
  public class UploadRoomImageEndpoint : BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<string>
  {
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UploadRoomImageEndpoint(IMediator mediator, IMapper mapper)
    {
      _mediator = mediator;
      _mapper = mapper;
    }

    [HttpPost(UploadRoomImageRequest.RouteTemplate)]
    public override async Task<ActionResult<string>> HandleAsync([FromRoute] Guid roomId, CancellationToken cancellationToken = default)
    {
      // получаю отель по Id
      RoomDto? room = await _mediator.Send(new GetByIdRoomQuery() { Id = roomId });
      if (room is null)
      {
        return BadRequest(AppMessage.GetRoomByIdTextErrorMessage);
      }

      //Используя объект Request, пытаюсь загрузить файл, размещенный в запросе, и возвращаю сообщение "Фото не найдено", если файл не найден
      IFormFile? file = Request.Form.Files[0];
      if (file.Length == 0)
      {
        return BadRequest(AppMessage.GetRoomImageTextErrorMessage);
      }

      //Создаю новое имя файла для загруженного изображения, безопасное для использования в приложении
      string? filename = $"{Guid.NewGuid()}.jpg";
      //Определяю место сохранения файла
      string? saveLocation = Path.Combine(Directory.GetCurrentDirectory(), "Images", filename);

      //Используя ImageSharp,изменяю размер загруженного изображения, чтобы получить нужные размеры, и сохраняем его в файловой системе
      var resizeOptions = new ResizeOptions
      {
        Mode = ResizeMode.Pad,
        Size = new Size(640, 426)
      };
      using var image = Image.Load(file.OpenReadStream());
      image.Mutate(x => x.Resize(resizeOptions));
      await image.SaveAsJpegAsync(saveLocation, cancellationToken: cancellationToken);
      // Проверяет, есть ли у отеля, которому принадлежит изображение, уже существующее изображение
      if (!string.IsNullOrWhiteSpace(room.MainPhoto))
      {
        // Если изображение есть, удаляем его из файловой системы
        System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "Images", room.MainPhoto));
      }

      //Обновляю отель, указав местоположение фото отеля. Оно будет использоваться в интерфейсе для загрузки изображения
      room.MainPhoto = filename;
      await _mediator.Send(new UpdateRoomCommand() { Dto = _mapper.Map<RoomUpdateDto>(room) });

      return Ok(room.MainPhoto);
    }
  }
}
