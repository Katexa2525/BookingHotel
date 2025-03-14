﻿namespace Domain.Models
{
  public class RoomType : BaseEntity
  {
    public IEnumerable<Price> Prices { get; set; }
    public IEnumerable<Room> Rooms { get; set; }
  }
}
