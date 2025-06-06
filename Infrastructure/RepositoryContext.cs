﻿using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
      modelBuilder.Entity<Currency>()
          .HasMany(r => r.Prices)
          .WithOne(rp => rp.Currency)
          .HasForeignKey(p => p.CurrencyId)
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

      modelBuilder.Entity<Room>()
          .HasMany(r => r.RoomPhotos)
          .WithOne(rp => rp.Room)
          .HasForeignKey(rp => rp.RoomId)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Room>()
          .HasMany(r => r.RoomFacilities)
          .WithOne(rf => rf.Room)
          .HasForeignKey(rf => rf.RoomId)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Room>()
          .HasMany(r => r.Prices)
          .WithOne(rf => rf.Room)
          .HasForeignKey(rf => rf.RoomId)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Room>()
          .HasMany(r => r.Bookings)
          .WithOne(rf => rf.Room)
          .HasForeignKey(rf => rf.RoomId)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Hotel>()
          .HasMany(h => h.Rooms)
          .WithOne(r => r.Hotel)
          .HasForeignKey(r => r.HotelId)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<HotelFacility>()
          .HasOne(hf => hf.Hotel)
          .WithMany(h => h.HotelFacilities)
          .HasForeignKey(hf => hf.HotelId)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<HotelPhoto>()
          .HasOne(hp => hp.Hotel)
          .WithMany(h => h.HotelPhotos)
          .HasForeignKey(hp => hp.HotelId)
          .OnDelete(DeleteBehavior.Cascade); 

      modelBuilder.Entity<Location>()
          .HasOne(l => l.Hotel)
          .WithMany(h => h.Locations)
          .HasForeignKey(l => l.HotelId)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<Review>()
          .HasOne(rt => rt.Hotel)
          .WithMany(r => r.Reviews)
          .HasForeignKey(r => r.HotelId)
          .OnDelete(DeleteBehavior.Cascade);

      modelBuilder.Entity<HotelUsefulInfo>()
          .HasOne(rt => rt.Hotel)
          .WithOne(r => r.HotelUsefulInfo)
          .OnDelete(DeleteBehavior.Cascade);

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

      //установка альтернативного ключа
      modelBuilder.Entity<Currency>().HasAlternateKey(u => u.Cur_ID);

      modelBuilder.Entity<Hotel>().HasData(
        new { Id = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A"), Name = "Hotel, Singapore, Fullerton bay", Arrival = "14:00", Departure = "12:00", Location = "Durbach, Germany", Rating = 4.9, Star = 3, MainPhoto = "B3C83220-D255-46D7-AC76-114ECE1D925A.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla volutpat orci at augue ultricies fermentum. Ut massa lectus, dignissim sed molestie ut, viverra vel diam. Fusce at iaculis magna. Suspendisse vel est et est luctus ornare venenatis ut neque. Pellentesque varius lacus sed arcu pellentesque, a porttitor velit gravida. Nunc nunc lectus, rhoncus consectetur metus eget, fermentum laoreet mauris. Cras ac gravida ante. Ut in ante ex. Proin tristique a ligula vel pharetra. Vestibulum blandit nisl dui, in pulvinar metus mollis pharetra. Duis cursus porttitor libero, quis lacinia velit. Curabitur tincidunt laoreet mi, eu maximus nibh vestibulum sed. Phasellus orci." },
        new { Id = Guid.Parse("F6A9207D-AD8B-4D5F-BEA5-1CD2F87A0308"), Name = "Hotel, Nature, Switzerland", Arrival = "14:00", Departure = "12:00", Location = "Nottingham, UK", Rating = 2.4, Star = 4, MainPhoto = "F6A9207D-AD8B-4D5F-BEA5-1CD2F87A0308.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus a semper lacus. Vestibulum vehicula elementum auctor. Vestibulum malesuada, nibh a pretium ullamcorper, tortor nisi tincidunt ante, sed gravida purus mi in ligula. In malesuada ligula vitae risus iaculis, et sollicitudin lorem ornare. Nullam nec ullamcorper est. Donec efficitur et ipsum auctor semper. In id eros risus. Suspendisse quis massa convallis, suscipit eros eget, ullamcorper metus. Phasellus laoreet nulla quam, vel porttitor diam efficitur vitae. Etiam sollicitudin urna vel auctor accumsan. Suspendisse commodo pulvinar mauris, quis viverra lectus hendrerit dictum. In sed lorem tempus ipsum rutrum suscipit vitae sed mauris. Nunc." },
        new { Id = Guid.Parse("FFE1C64A-AD2B-443E-B5AC-2CE60ECA6340"), Name = "Lanzarote, Hotel, Heaven", Arrival = "14:00", Departure = "12:00", Location = "Furna, Switzerland", Rating = 4.7, Star = 3, MainPhoto = "FFE1C64A-AD2B-443E-B5AC-2CE60ECA6340.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut imperdiet ex ac euismod pulvinar. Cras lorem nulla, posuere sed semper sed, scelerisque non nulla. Sed mi lorem, condimentum nec magna ac, ultricies lobortis ante. Integer tincidunt, metus eget mattis hendrerit, nibh metus sagittis diam, sed imperdiet metus nisi ac magna. Pellentesque iaculis mi purus, a porta tortor sodales consequat. Pellentesque vel mattis ligula. Fusce ac massa id ex rutrum eleifend. Nunc porta tortor dictum, ornare metus quis, laoreet ante. Nullam ullamcorper magna eget eleifend consequat. In nulla ex, iaculis vestibulum eros ac, vestibulum euismod arcu. Nullam sollicitudin at neque et." },
        new { Id = Guid.Parse("2CEDEA9F-912D-48C7-9125-3C11769F71A7"), Name = "Hotel, Building, House, Shops", Arrival = "14:00", Departure = "12:00", Location = "Gearstones, UK", Rating = 4.8, Star = 5, MainPhoto = "2CEDEA9F-912D-48C7-9125-3C11769F71A7.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut laoreet, justo ut egestas pulvinar, est dui elementum neque, ac elementum lectus tellus in libero. Cras ullamcorper tellus id velit finibus, at rutrum odio convallis. Donec gravida nec mauris eget iaculis. Praesent faucibus ante fringilla, ullamcorper enim sit amet, suscipit leo. Sed libero erat, facilisis vel nunc et, venenatis volutpat quam. Integer sit amet lobortis risus, ut hendrerit orci. Vivamus pulvinar lectus dui, a dictum odio eleifend vitae. Pellentesque gravida risus eu ipsum efficitur consectetur. Nulla lectus leo, pharetra vel ante ut, mollis pharetra arcu. Morbi vitae metus ante. Integer lacinia." },
        new { Id = Guid.Parse("6C294357-66E3-49B1-AB63-42173553E89C"), Name = "Hotel, Winter, Season", Arrival = "14:00", Departure = "12:00", Location = "Ockle, Scotland", Rating = 3.6, Star = 4, MainPhoto = "", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer facilisis magna eget sem feugiat, non pulvinar dui interdum. Proin quis tincidunt ex. Pellentesque dictum nibh dolor, cursus porta magna sodales a. Morbi vitae tortor nisi. Nullam molestie dui tempus, lobortis dolor sit amet, hendrerit libero. Quisque sed massa id lacus ornare faucibus eget facilisis mi. Donec interdum bibendum leo nec facilisis. In semper nec eros id tincidunt. Nunc sed sagittis justo. Ut massa ligula, posuere sed iaculis sit amet, laoreet ut ipsum. Nulla facilisi. Vestibulum iaculis risus nulla. Nunc congue elit et erat blandit vulputate. Praesent vulputate tortor at augue." },
        new { Id = Guid.Parse("C48CBBE7-6A94-4480-9C60-48B54AF81545"), Name = "Marina bay sands, Singapore", Arrival = "14:00", Departure = "12:00", Location = "Ocluder, Singopour", Rating = 4.2, Star = 5, MainPhoto = "", Description = "Singapore skyline with urban buildings over water" },
        new { Id = Guid.Parse("E0C80AAF-2224-40D5-8D54-66BF4FBBFCD8"), Name = "Hotel, High, Stone image", Arrival = "14:00", Departure = "12:00", Location = "Madrid, Espane", Rating = 4.1, Star = 4, MainPhoto = "E0C80AAF-2224-40D5-8D54-66BF4FBBFCD8.jpg", Description = "Lorem ipsum dolor sit amet sed diam sadipscing sit stet amet invidunt nibh autem voluptua justo tempor tation sed. Consetetur labore accusam ut nonumy justo dolore kasd. Duis odio labore dolore stet. Kasd vel dolor feugait illum accusam veniam dolore dignissim labore. Ut sed elitr elitr amet gubergren ipsum tempor sed duo erat justo no nibh id voluptua ut." },
        new { Id = Guid.Parse("95175BFC-AF50-4588-9373-68EE30E88F75"), Name = "Hotel, Invalidendom", Arrival = "14:00", Departure = "12:00", Location = "Paris, France", Rating = 4.9, Star = 5, MainPhoto = "", Description = "Lorem ipsum dolor sit amet gubergren ipsum vulputate invidunt vel sit dolor liber. Elitr ut et vulputate est. Justo ut nonummy est. Dolor ipsum duis rebum lorem laoreet autem elitr vero gubergren sea est clita wisi et dolore. Ut duo lorem ipsum takimata facilisis est sanctus sea at accusam sanctus clita labore et dolor. Eos illum delenit et ipsum sed amet. Gubergren accusam consetetur." }
        );

      modelBuilder.Entity<Room>().HasData(
        new { Id = Guid.Parse("BEF53E26-C490-4FB6-89CA-D920EFC982F6"), HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A"), RoomTypeId = Guid.Parse("0282BE52-3816-401E-AF3F-074BE089D921"), PeopleNumber = 2, Square = 40.0, Description = "Takimata consectetuer lorem facilisis ipsum nibh sit accusam aliquyam justo clita" },
        new { Id = Guid.Parse("C9153FE4-CB5D-4A77-9F63-7B1DD34C7BF7"), HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A"), RoomTypeId = Guid.Parse("A19B9BBE-A941-4B3E-BB2D-07E75ED1850A"), PeopleNumber = 4, Square = 52.0, Description = "Elitr sed enim stet dolore consectetuer consetetur et facer diam eirmod dolores tempor ea sit." },
        new { Id = Guid.Parse("6FD8B06F-DDBB-463F-8362-29CFBF272751"), HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A"), RoomTypeId = Guid.Parse("4776D7CE-CC8D-4C86-8B9D-40650651DF33"), PeopleNumber = 2, Square = 34.0, Description = "Nibh vero illum sit. Dolor consetetur tempor amet sea lorem consequat diam dolor ea accusam no te at ea clita diam." },
        new { Id = Guid.Parse("9D551953-1B52-4CB1-AD90-31C8653955FA"), HotelId = Guid.Parse("F6A9207D-AD8B-4D5F-BEA5-1CD2F87A0308"), RoomTypeId = Guid.Parse("072FC618-8703-437F-9662-5BA97D0AB4F0"), PeopleNumber = 3, Square = 38.0, Description = "Zzril tation clita stet." },
        new { Id = Guid.Parse("DCA48FFC-C572-4CA5-8217-7A7D370FED2A"), HotelId = Guid.Parse("F6A9207D-AD8B-4D5F-BEA5-1CD2F87A0308"), RoomTypeId = Guid.Parse("68188476-48C6-48BE-B4CC-F8B63B4F0B08"), PeopleNumber = 3, Square = 40.5, Description = "Accumsan amet nonumy nonumy et amet euismod sed ipsum invidunt tincidunt ad. Ea dolor justo diam. Sea at labore duo iriure et ut ullamcorper in dignissim sit sit ipsum." }
        );


      modelBuilder.Entity<RoomFacility>().HasData(
        new { Id = Guid.Parse("572B5BB5-6254-4611-B57A-93F546FB62AF"), Name = "Цифровое ТВ", RoomId = Guid.Parse("BEF53E26-C490-4FB6-89CA-D920EFC982F6") },
        new { Id = Guid.Parse("FE5C4F20-89F9-4E2A-BA51-DCCFA75EBE5B"), Name = "Мини-холодильник", RoomId = Guid.Parse("BEF53E26-C490-4FB6-89CA-D920EFC982F6") },
        new { Id = Guid.Parse("A5D60B40-0270-4B9D-B559-161EFD8B6F86"), Name = "Wi-Fi", RoomId = Guid.Parse("BEF53E26-C490-4FB6-89CA-D920EFC982F6") },
        new { Id = Guid.Parse("13B17DAB-7ED0-40D9-93D5-B020EEA0AAD9"), Name = "Ванна", RoomId = Guid.Parse("C9153FE4-CB5D-4A77-9F63-7B1DD34C7BF7") },
        new { Id = Guid.Parse("427BA46A-07E6-4DA2-AFED-C1760F02A636"), Name = "Фен", RoomId = Guid.Parse("C9153FE4-CB5D-4A77-9F63-7B1DD34C7BF7") },
        new { Id = Guid.Parse("A774E890-3726-4E5B-8071-50E01F27B7B9"), Name = "Цифровое ТВ", RoomId = Guid.Parse("6FD8B06F-DDBB-463F-8362-29CFBF272751") },
        new { Id = Guid.Parse("573716D8-E318-4BA0-957C-2A1A0BE4AF30"), Name = "Wi-Fi", RoomId = Guid.Parse("6FD8B06F-DDBB-463F-8362-29CFBF272751") }
        );

      modelBuilder.Entity<HotelFacility>().HasData(
        new { Id = Guid.Parse("3ACE774A-94B2-4892-9071-3CF1BB24482B"), Name = "Wi-Fi", HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A") },
        new { Id = Guid.Parse("FAEF5433-37DD-4D7F-9A88-4B77FC3EF63C"), Name = "Парковка", HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A") },
        new { Id = Guid.Parse("5373222B-4390-4307-ADEC-3DAE329A8617"), Name = "Оплата картой", HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A") },
        new { Id = Guid.Parse("AC6EB263-EC82-432D-89EF-043CB803948F"), Name = "Wi-Fi", HotelId = Guid.Parse("F6A9207D-AD8B-4D5F-BEA5-1CD2F87A0308") },
        new { Id = Guid.Parse("CAFBC71D-E834-462B-BC1D-B81954014516"), Name = "Бассейн", HotelId = Guid.Parse("F6A9207D-AD8B-4D5F-BEA5-1CD2F87A0308") },
        new { Id = Guid.Parse("2AB2E0BC-E522-4B82-A85D-8A2AFD8B589D"), Name = "Парковка", HotelId = Guid.Parse("F6A9207D-AD8B-4D5F-BEA5-1CD2F87A0308") },
        new { Id = Guid.Parse("878DA153-3A2A-492F-8391-819B6011F460"), Name = "Тренажёрный зал", HotelId = Guid.Parse("F6A9207D-AD8B-4D5F-BEA5-1CD2F87A0308") },
        new { Id = Guid.Parse("93124016-D871-4999-B3CA-BB1D592743F3"), Name = "Оплата картой", HotelId = Guid.Parse("F6A9207D-AD8B-4D5F-BEA5-1CD2F87A0308") }
        );

      modelBuilder.Entity<Location>().HasData(
        new { Id = Guid.Parse("80E707D6-F4B4-46FA-A5EA-5A82B7A17749"), Name = "350 м до центра", HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A") },
        new { Id = Guid.Parse("F4014F30-C06B-480E-B8CD-13B77320D07C"), Name = "ост. «Главная городская площадь» 106 м", HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A") },
        new { Id = Guid.Parse("B1C79EBC-D7C5-474F-84E1-8F824BBFFDC6"), Name = "ост. «ЦКР» 350 м", HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A") },
        new { Id = Guid.Parse("D89FBCD6-8EA5-4E6A-BC2A-690B9A5CF23A"), Name = "Площадь Тукая 1 км", HotelId = Guid.Parse("F6A9207D-AD8B-4D5F-BEA5-1CD2F87A0308") },
        new { Id = Guid.Parse("646F990A-81A2-425C-9016-428DB3D58FD8"), Name = "8,6 км до центра", HotelId = Guid.Parse("F6A9207D-AD8B-4D5F-BEA5-1CD2F87A0308") },
        new { Id = Guid.Parse("BC2E63B0-8B5C-4EA6-BF47-48F5767705C9"), Name = "1 км до центра", HotelId = Guid.Parse("FFE1C64A-AD2B-443E-B5AC-2CE60ECA6340") },
        new { Id = Guid.Parse("8C0B9FDD-209A-4E07-BABB-C32F6308A25F"), Name = "2 км до футбольного стадиона", HotelId = Guid.Parse("FFE1C64A-AD2B-443E-B5AC-2CE60ECA6340") },
        new { Id = Guid.Parse("7D2A919D-E7D5-435A-AE0A-592037D489E3"), Name = "ост. «Реликтовый лес» 960 м", HotelId = Guid.Parse("2CEDEA9F-912D-48C7-9125-3C11769F71A7") }
        );

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

      modelBuilder.Entity<TypeFood>().HasData(
        new { Id = Guid.Parse("072fc618-8703-437f-9662-5ba97d0ab4f0"), Name = "Завтрак" },
        new { Id = Guid.Parse("4d53a1ed-9613-4406-8a31-a411c934e628"), Name = "Полупансион" },
        new { Id = Guid.Parse("b2d7509e-c5b3-4936-8deb-26e51052446f"), Name = "Завтрак, обед и ужин" },
        new { Id = Guid.Parse("ceb0cba6-80dd-43b0-a9a3-3b9a4165f782"), Name = "Всё включено" },
        new { Id = Guid.Parse("e0a5a158-5ef8-414c-896a-49fdf04dc7a4"), Name = "Завтрак полноценный" },
        new { Id = Guid.Parse("c9c6eb97-1d58-45d8-879a-9b2cf6c30cbd"), Name = "Без питания" });

      modelBuilder.Entity<Food>().HasData(
        new { Id = Guid.Parse("F7683DD2-73C0-4B87-B4F4-258C96632B95"), Name = "Завтрак", TypeFoodId = Guid.Parse("072fc618-8703-437f-9662-5ba97d0ab4f0"), HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A") },
        new { Id = Guid.Parse("00C01554-DDCB-4E68-A830-338742C458CC"), Name = "Полупансион", TypeFoodId = Guid.Parse("4d53a1ed-9613-4406-8a31-a411c934e628"), HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A") },
        new { Id = Guid.Parse("0375CBB1-A4C1-42BF-B4FF-46A70D5CA365"), Name = "Завтрак, обед и ужин", TypeFoodId = Guid.Parse("b2d7509e-c5b3-4936-8deb-26e51052446f"), HotelId = Guid.Parse("F6A9207D-AD8B-4D5F-BEA5-1CD2F87A0308") },
        new { Id = Guid.Parse("4321B0F8-FA4B-447F-91B0-89D119E02977"), Name = "Всё включено", TypeFoodId = Guid.Parse("ceb0cba6-80dd-43b0-a9a3-3b9a4165f782"), HotelId = Guid.Parse("FFE1C64A-AD2B-443E-B5AC-2CE60ECA6340") },
        new { Id = Guid.Parse("7DBFC4DF-A227-4DDB-87C0-011A057B4403"), Name = "Завтрак полноценный", TypeFoodId = Guid.Parse("e0a5a158-5ef8-414c-896a-49fdf04dc7a4"), HotelId = Guid.Parse("F6A9207D-AD8B-4D5F-BEA5-1CD2F87A0308") },
        new { Id = Guid.Parse("00F7E7F9-387C-47F3-A728-CF91782F6EE3"), Name = "Без питания", TypeFoodId = Guid.Parse("c9c6eb97-1d58-45d8-879a-9b2cf6c30cbd"), HotelId = Guid.Parse("FFE1C64A-AD2B-443E-B5AC-2CE60ECA6340") });

      modelBuilder.Entity<Review>().HasData(
        new { Id = Guid.Parse("311D11BA-0DB1-479D-B630-E605A2FC7DA2"), Name = "Ромка Тарасов",        DateTimeReview = new DateTime(2024, 11, 11), Star = 4, HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A"), Description = "Очень уютный отель. За свою цену более чем достаточно" },
        new { Id = Guid.Parse("7891815C-559C-4D88-8EC0-48F1DE339C5F"), Name = "KATERINA",             DateTimeReview = new DateTime(2023, 10, 06), Star = 5, HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A"), Description = "Все понравилось, чисто, тихо. Брали люкс. Большой двухкомнатный номер за приемлемую цену. Вежливый приятный персонал. Брали дополнительно комплексный завтрак, тоже понравился. Молодцы" },
        new { Id = Guid.Parse("56AB0D5B-75EA-4FA7-89B9-CAEDF1047E1D"), Name = "BlackAbaddon",         DateTimeReview = new DateTime(2025, 03, 19), Star = 4, HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A"), Description = "Были проездом и останавливались в отеле на две ночи в номере полулюкс. Что понравилось: отзывчивый персонал, чистый номер, вкусные завтрак, обед, и ужин. Порции смело можно делить на двоих), по вкусу как домашняя еда. Подаётся по времени, которое вы сами выбираете. Из необходимого в номере все есть чайник, стаканы, халаты, принадлежности для душа. В коридоре кулер с водой. Для курящих можно курить на пожарной лестнице не спускаясь вниз. Матрац хоть и немного усталый, но удобный. Заказали стирку и глажку одежды, все сделали аккуратно, принесли в номер на плечиках. В номере есть телефон можно связаться с персоналом, если возникают какие-то вопросы. Из минусов: почему полулюкс на третьем этаже? После долгой дороги очень некомфортно тащить чемоданы так высоко. Замок на двери в душевую с туалетом заедал и приходилось приноравливаться, чтобы его открыть, причем эта проблема возникала только изнутри помещения. Но самый большой минус это кондиционер, который дул четко на кровать, как его не настраивай. И ещё, о том что завтрак, обед и вечером ужин надо заказывать заранее, за день до заселения я вычитала в таком же отзыве. Считаю, что данную информацию отель должен вывешивать на своем сайте. Но все же положительных впечатлений больше чем отрицательных. Отель рекомендую для транзитных поездок." },
        new { Id = Guid.Parse("8D7AD3F8-748C-40F3-A70A-6C3C0654D224"), Name = "Надежда Долиновская",  DateTimeReview = new DateTime(2024, 08, 05), Star = 3, HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A"), Description = "Отель на 3 звездочки. Если сейчас не начать заниматься сервисом, то можно скатиться в самый низ. После 21:00 начинаются стуканья в дверь, горничные ходят то халат занести (который не просили), то полотенца у них высохли, тоже надо заглянуть." },
        new { Id = Guid.Parse("B621A29B-C219-473E-8C75-49DF2CE03448"), Name = "ольга шевченко",       DateTimeReview = new DateTime(2024, 12, 12), Star = 5, HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A"), Description = "Прекрасная гостиница,чистые номера и постельное,отмечу сразу очень хорошие,вкусные и сытные завтраки. Так же когда заказывала еду в номер вкусно и порции как дома у мамы🔥 Когда выезжали мы забыли там документы на автомобиль и еще кое-какие личные вещи,я позвонила спустя день ,все вещи были на ресепшене спасибо всему персоналу за вашу работу. " },
        new { Id = Guid.Parse("EE1AE40E-1A41-4D51-8D23-8D8DBE1F7F55"), Name = "Александр Никольский", DateTimeReview = new DateTime(2024, 08, 25), Star = 5, HotelId = Guid.Parse("FFE1C64A-AD2B-443E-B5AC-2CE60ECA6340"), Description = "Хороший уютный отель, приятный персонал, отель находится в 10 минутах ходьбы (или одна остановка на автобусе или троллейбусе) от железнодорожного вокзала. В номере есть всё необходимое: халат, тапочки, мыльные принадлежности, чайник кофе,чай, сахар (правда почему-то чайные ложки пластиковые, но из хорошего пластика)." },
        new { Id = Guid.Parse("F6311ACC-D059-4C76-8927-CB743E5B5930"), Name = "Ibn Minaev",           DateTimeReview = new DateTime(2025, 04, 29), Star = 4, HotelId = Guid.Parse("FFE1C64A-AD2B-443E-B5AC-2CE60ECA6340"), Description = "Отель хороший, комфортный, есть холодильник в номерах, сейф, удобный диван и стол для работы/еды. 4 звёзды поставил в связи с несколькими причинами: заезжало в номер два человека, всё оставили на двоих, а халат только один, ну как так... душевая очень странного стиля - 1.5 метра стекла отделяет душ от самой ванной комнаты, вход без какой-либо дверцы или подвижной стенки, в следствии чего у любителей держать душ в руках во время купания пол в ванной будет заливать от брызг, что однозначно не радует." },
        new { Id = Guid.Parse("C6EA5EB4-FBCE-47A3-9442-C59B0530A6FF"), Name = "алыкса сочи",          DateTimeReview = new DateTime(2023, 02, 01), Star = 2, HotelId = Guid.Parse("2CEDEA9F-912D-48C7-9125-3C11769F71A7"), Description = "Жарко и душно, фанкойл не влияет на температуру, если приоткрыть окно, то из за общей вытяжки сильный свист в щели двери, по этой же причине открыть входную дверь в отель невозможно без серьёзного усилия. В №521 вода в душевой не уходит, и дело в наклоне чаши против слива. Просили при уборке убирать воду, но горничная этого не делала, пришлось ловить горничную на этаже. За 4 дня один раз убрались. " }
        );

      modelBuilder.Entity<Currency>().HasData(
        new { Id = Guid.Parse("ABBE09FC-5E77-414C-8940-E77E934DE88F"), Name = "RUB", Cur_ID = 456, Cur_ParentID = 190, Cur_Code = "643", Cur_Abbreviation = "RUB", Cur_Name = "Российский рубль", Cur_Name_Bel = "Расійскі рубель", Cur_Name_Eng = "Russian Ruble", Cur_QuotName = "100 Российских рублей", Cur_QuotName_Bel = "100 Расійскіх рублёў", Cur_QuotName_Eng = "100 Russian Rubles", Cur_NameMulti = "Российских рублей", Cur_Name_BelMulti = "Расійскіх рублёў", Cur_Name_EngMulti = "Russian Rubles", Cur_Scale = 100, Cur_Periodicity = 0, Cur_DateStart = DateTime.Parse("2021-07-09T00:00:00"), Cur_DateEnd = DateTime.Parse("2050-01-01T00:00:00") },
        new { Id = Guid.Parse("F3CA1C7B-C275-4FEB-9790-9A42EFB878EE"), Name = "USD", Cur_ID = 145, Cur_ParentID = 145, Cur_Code = "840", Cur_Abbreviation = "USD", Cur_Name = "Доллар США", Cur_Name_Bel = "Долар ЗША", Cur_Name_Eng = "US Dollar", Cur_QuotName = "1 Доллар США", Cur_QuotName_Bel = "1 Долар ЗША", Cur_QuotName_Eng = "1 US Dollar", Cur_NameMulti = "Долларов США", Cur_Name_BelMulti = "Долараў ЗША", Cur_Name_EngMulti = "US Dollars", Cur_Scale = 1, Cur_Periodicity = 0, Cur_DateStart = DateTime.Parse("1991-01-01T00:00:00"), Cur_DateEnd = DateTime.Parse("2021-07-08T00:00:00") },
        new { Id = Guid.Parse("F3524EFF-E305-4305-8AE3-2731AD415FE9"), Name = "EUR", Cur_ID = 451, Cur_ParentID = 19, Cur_Code = "978", Cur_Abbreviation = "EUR", Cur_Name = "Евро", Cur_Name_Bel = "Еўра", Cur_Name_Eng = "Euro", Cur_QuotName = "1 Евро", Cur_QuotName_Bel = "1 Еўра", Cur_QuotName_Eng = "1 Euro", Cur_NameMulti = "Евро", Cur_Name_BelMulti = "Еўра", Cur_Name_EngMulti = "Euros", Cur_Scale = 1, Cur_Periodicity = 0, Cur_DateStart = DateTime.Parse("2021-07-09T00:00:00"), Cur_DateEnd = DateTime.Parse("2050-01-01T00:00:00") },
        new { Id = Guid.Parse("232BA1BD-0192-4E35-B4A2-908DD61EA5CC"), Name = "BYN", Cur_ID = 9333, Cur_ParentID = 9333, Cur_Code = "933", Cur_Abbreviation = "BYN", Cur_Name = "Белорусский рубль", Cur_Name_Bel = "Берарускі рубель", Cur_Name_Eng = "BYN", Cur_QuotName = "1 Белорусский рубль", Cur_QuotName_Bel = "1 Беларускі рубель", Cur_QuotName_Eng = "1 BYN", Cur_NameMulti = "Белорусский рублей", Cur_Name_BelMulti = "Беларускіх рублёў", Cur_Name_EngMulti = "Belorussian Rubles", Cur_Scale = 1, Cur_Periodicity = 0, Cur_DateStart = DateTime.Parse("2021-07-09T00:00:00"), Cur_DateEnd = DateTime.Parse("2050-01-01T00:00:00") }
      );


      modelBuilder.Entity<Rate>().Property(o => o.Cur_OfficialRate).HasColumnType("decimal(18,2)");

      modelBuilder.HasDefaultSchema("dbo");
      base.OnModelCreating(modelBuilder);
    }

  }
}
