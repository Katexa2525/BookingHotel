﻿using Application.DTO.Guest;
using Application.DTO.Room;
using Application.DTO.Service;

namespace Application.DTO.Booking
{
  public class BookingDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int NumberOfAdults { get; set; }
    public int NumberOfChilds { get; set; }
    /// <summary> Дата начала  </summary>
    public DateTime ArrivalDate { get; set; }
    /// <summary> Дата окончания </summary>
    public DateTime DepartureDate { get; set; }
    /// <summary> Комментарий к бронированию </summary>
    public string? Description { get; set; } = string.Empty;
    /// <summary> id пользователя из Keycloak </summary>
    public string? UserId { get; set; } = string.Empty;
    public Guid RoomId { get; set; }
    public RoomDto Room { get; set; }
    public IEnumerable<GuestDto> Guests { get; set; }
    public IEnumerable<ServiceDto> Services { get; set; }
  }
}
