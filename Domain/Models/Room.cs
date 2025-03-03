﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
  public class Room
  {
    public Guid Id { get; set; }
    public Guid HotelId { get; set; }
    public Hotel Hotel { get; set; }
    public int PeopleNumber { get; set; }
    public double Square {  get; set; }
    public IEnumerable<Price> Prices { get; set; }
    

  }
}
