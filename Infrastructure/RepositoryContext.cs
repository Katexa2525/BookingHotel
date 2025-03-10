using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Для Price, избегаем каскадного удаления
      modelBuilder.Entity<Price>()
          .HasOne(p => p.Room)
          .WithMany(r => r.Prices)
          .HasForeignKey(p => p.RoomId)
          .OnDelete(DeleteBehavior.Restrict); // Изменено на Restrict

      modelBuilder.Entity<Price>()
          .HasOne(p => p.Hotel)
          .WithMany(h => h.Prices)
          .HasForeignKey(p => p.HotelId)
          .OnDelete(DeleteBehavior.Restrict); // Изменено на Restrict

      modelBuilder.Entity<Price>()
          .HasOne(p => p.Currency)
          .WithMany()
          .HasForeignKey(p => p.CurrencyId)
          .OnDelete(DeleteBehavior.Restrict); // Изменено на Restrict

      modelBuilder.Entity<Price>()
          .HasOne(p => p.RoomType)
          .WithMany(rt => rt.Prices)
          .HasForeignKey(p => p.RoomTypeId)
          .OnDelete(DeleteBehavior.Restrict); // Изменено на Restrict

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
          .OnDelete(DeleteBehavior.Restrict); // Изменено на Restrict

      modelBuilder.Entity<Room>()
          .HasMany(r => r.RoomPhotos)
          .WithOne(rp => rp.Room)
          .HasForeignKey(rp => rp.RoomId)
          .OnDelete(DeleteBehavior.Restrict); // Изменено на Restrict

      modelBuilder.Entity<Room>()
          .HasMany(r => r.RoomFacilities)
          .WithOne(rf => rf.Room)
          .HasForeignKey(rf => rf.RoomId)
          .OnDelete(DeleteBehavior.Restrict); // Изменено на Restrict

      modelBuilder.Entity<HotelFacility>()
          .HasOne(hf => hf.Hotel)
          .WithMany(h => h.HotelFacilities)
          .HasForeignKey(hf => hf.HotelId)
          .OnDelete(DeleteBehavior.Restrict); // Изменено на Restrict

      modelBuilder.Entity<HotelPhoto>()
          .HasOne(hp => hp.Hotel)
          .WithMany(h => h.HotelPhotos)
          .HasForeignKey(hp => hp.HotelId)
          .OnDelete(DeleteBehavior.Restrict); // Изменено на Restrict

      modelBuilder.Entity<Location>()
          .HasOne(l => l.Hotel)
          .WithMany(h => h.Locations)
          .HasForeignKey(l => l.HotelId)
          .OnDelete(DeleteBehavior.Restrict); // Изменено на Restrict

      modelBuilder.Entity<RoomType>()
          .HasMany(rt => rt.Rooms)
          .WithOne(r => r.RoomType)
          .HasForeignKey(r => r.RoomTypeId)
          .OnDelete(DeleteBehavior.Restrict); // Изменено на Restrict

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
      }
}
