using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;

namespace Infrastructure
{
  public class RepositoryContext : IdentityDbContext<User>
  {
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Для Price, избегаем каскадного удаления
      modelBuilder.Entity<Price>()
          .HasOne(p => p.Room)
          .WithMany(r => r.Prices)
          .HasForeignKey(p => p.RoomId)
          .OnDelete(DeleteBehavior.Restrict); 

      modelBuilder.Entity<Price>()
          .HasOne(p => p.Hotel)
          .WithMany(h => h.Prices)
          .HasForeignKey(p => p.HotelId)
          .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<Price>()
          .HasOne(p => p.Currency)
          .WithMany()
          .HasForeignKey(p => p.CurrencyId)
          .OnDelete(DeleteBehavior.Restrict); 

      modelBuilder.Entity<Price>()
          .HasOne(p => p.RoomType)
          .WithMany(rt => rt.Prices)
          .HasForeignKey(p => p.RoomTypeId)
          .OnDelete(DeleteBehavior.Restrict); 

      // Применяем каскадное удаление только для нужных внешних ключей
      modelBuilder.Entity<Booking>()
          .HasMany(b => b.Guests)
          .WithOne(g => g.Booking)
          .HasForeignKey(g => g.BookingId)
          .OnDelete(DeleteBehavior.Cascade); // Каскадное удаление для Guests

      modelBuilder.Entity<Booking>()
          .HasMany(b => b.Services)
          .WithOne(s => s.Booking)
          .HasForeignKey(s => s.BookingId)
          .OnDelete(DeleteBehavior.Cascade); // Каскадное удаление для Services

      modelBuilder.Entity<Hotel>()
          .HasMany(h => h.Rooms)
          .WithOne(r => r.Hotel)
          .HasForeignKey(r => r.HotelId)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Room>()
          .HasMany(r => r.RoomPhotos)
          .WithOne(rp => rp.Room)
          .HasForeignKey(rp => rp.RoomId)
          .OnDelete(DeleteBehavior.Restrict); 

      modelBuilder.Entity<Room>()
          .HasMany(r => r.RoomFacilities)
          .WithOne(rf => rf.Room)
          .HasForeignKey(rf => rf.RoomId)
          .OnDelete(DeleteBehavior.Restrict); 

      modelBuilder.Entity<HotelFacility>()
          .HasOne(hf => hf.Hotel)
          .WithMany(h => h.HotelFacilities)
          .HasForeignKey(hf => hf.HotelId)
          .OnDelete(DeleteBehavior.Restrict); 

      modelBuilder.Entity<HotelPhoto>()
          .HasOne(hp => hp.Hotel)
          .WithMany(h => h.HotelPhotos)
          .HasForeignKey(hp => hp.HotelId)
          .OnDelete(DeleteBehavior.Restrict); 

      modelBuilder.Entity<Location>()
          .HasOne(l => l.Hotel)
          .WithMany(h => h.Locations)
          .HasForeignKey(l => l.HotelId)
          .OnDelete(DeleteBehavior.Restrict); 

      modelBuilder.Entity<RoomType>()
          .HasMany(rt => rt.Rooms)
          .WithOne(r => r.RoomType)
          .HasForeignKey(r => r.RoomTypeId)
          .OnDelete(DeleteBehavior.Restrict); 

      modelBuilder.Entity<TypeFood>()
          .HasMany(rt => rt.Foods)
          .WithOne(r => r.TypeFood)
          .HasForeignKey(r => r.TypeFoodId)
          .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<TypeFood>().HasData(
        new { Id = Guid.Parse("072fc618-8703-437f-9662-5ba97d0ab4f0"), Name = "Завтрак" },
        new { Id = Guid.Parse("4d53a1ed-9613-4406-8a31-a411c934e628"), Name = "Полупансион" },
        new { Id = Guid.Parse("b2d7509e-c5b3-4936-8deb-26e51052446f"), Name = "Завтрак, обед и ужин" },
        new { Id = Guid.Parse("ceb0cba6-80dd-43b0-a9a3-3b9a4165f782"), Name = "Всё включено" },
        new { Id = Guid.Parse("e0a5a158-5ef8-414c-896a-49fdf04dc7a4"), Name = "Завтрак" },
        new { Id = Guid.Parse("c9c6eb97-1d58-45d8-879a-9b2cf6c30cbd"), Name = "Без питания" });

      modelBuilder.Entity<Review>()
          .HasOne(rt => rt.Hotel)
          .WithMany(r => r.Reviews)
          .HasForeignKey(r => r.HotelId)
          .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<HotelUsefulInfo>()
          .HasOne(rt => rt.Hotel)
          .WithOne(r => r.HotelUsefulInfo)
          .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.HasDefaultSchema("dbo");
      base.OnModelCreating(modelBuilder);
    }


    public DbSet<Hotel>? Hotels { get; set; }
    public DbSet<Room>? Rooms { get; set; }
    public DbSet<Booking>? Bookings { get; set; }
    public DbSet<Currency>? Currencies { get; set; }
    public DbSet<Food>? Foods { get; set; }
    public DbSet<Guest>? Guests { get; set; }
    public DbSet<HotelFacility>? HotelFacilities { get; set; }
    public DbSet<HotelPhoto>? HotelPhotos { get; set; }
    public DbSet<Location>? Locations { get; set; }
    public DbSet<Price>? Prices { get; set; }
    public DbSet<RoomFacility>? RoomFacilities { get; set; }
    public DbSet<RoomPhoto>? RoomPhotos { get; set; }
    public DbSet<RoomType>? RoomTypes { get; set; }
    public DbSet<Service>? Services { get; set; }
    public DbSet<TypeFood>? TypeFoods { get; set; }
    public DbSet<Review>? Reviews { get; set; }
    public DbSet<HotelUsefulInfo>? HotelUsefulInfos { get; set; }
  }
}
