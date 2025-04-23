using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;

namespace Infrastructure
{
  public class RepositoryContext : IdentityDbContext<User>
  {
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {    }

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
    public DbSet<Rate>? Rates { get; set; }

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

      modelBuilder.Entity<RoomType>().HasData(
        new { Id = Guid.Parse("3ca90fe7-2be3-4d2b-893c-329e78f1795b"), Name = "Номер Стандарт" },
        new { Id = Guid.Parse("68188476-48c6-48be-b4cc-f8b63b4f0b08"), Name = "Номер Делюкс" },
        new { Id = Guid.Parse("109d81b2-58b8-4f48-aa96-469b1e9dd445"), Name = "Двухкомнатный Люкс" },
        new { Id = Guid.Parse("91ed5eb9-d369-4788-bcdc-7bbaf1813a2a"), Name = "Номер «Восточный»" },
        new { Id = Guid.Parse("32de15de-509d-46ff-8c5a-baf5cdc34405"), Name = "Президентский люкс" },
        new { Id = Guid.Parse("4f9a65f2-de87-46b4-9860-e7c0262c92d9"), Name = "Улучшенные двухкомнатные апартаменты" },
        new { Id = Guid.Parse("5046fcc4-fbef-49f1-b2f5-b5c64e380ea0"), Name = "Двухкомнатные апартаменты с одной спальней" },
        new { Id = Guid.Parse("0282be52-3816-401e-af3f-074be089d921"), Name = "Студия" },
        new { Id = Guid.Parse("0f4ef0eb-7f4d-4a8b-94c6-6d9f7e0b8c0d"), Name = "Двухкомнатный Полулюкс" },
        new { Id = Guid.Parse("805175af-552e-4b6c-b3fd-5a49c3a226d8"), Name = "Трехкомнатные апартаменты с одной спальней" },
        new { Id = Guid.Parse("ebf1c674-191c-4d27-ab38-aad7f7360c17"), Name = "Стандарт 3-х местный" },
        new { Id = Guid.Parse("5afb6d3d-0ce3-4c34-a988-35187ffdf877"), Name = "Люкс двухкомнатный 8-ми местный" },
        new { Id = Guid.Parse("072fc618-8703-437f-9662-5ba97d0ab4f0"), Name = "Полулюкс" },
        new { Id = Guid.Parse("4776d7ce-cc8d-4c86-8b9d-40650651df33"), Name = "Стандарт Бизнес" },
        new { Id = Guid.Parse("de0f70a9-b924-47ed-a599-295a4e8b4889"), Name = "Стандарт Бизнес (четырехместный )" },
        new { Id = Guid.Parse("a19b9bbe-a941-4b3e-bb2d-07e75ed1850a"), Name = "Люкс Гранд Премиум" }
        );


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

      //установка альтернативного ключа
      modelBuilder.Entity<Currency>().HasAlternateKey(u => u.Cur_ID);

      modelBuilder.Entity<Rate>().Property(o => o.Cur_OfficialRate).HasColumnType("decimal(18,2)");

      modelBuilder.HasDefaultSchema("dbo");
      base.OnModelCreating(modelBuilder);
    }

  }
}
