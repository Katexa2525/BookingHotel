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

      //modelBuilder.Entity<Price>()
      //    .HasOne(p => p.Hotel)
      //    .WithMany(h => h.Prices)
      //    .HasForeignKey(p => p.HotelId)
      //    .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<Price>()
          .HasOne(p => p.Currency)
          .WithMany()
          .HasForeignKey(p => p.CurrencyId)
          .OnDelete(DeleteBehavior.Restrict); 

      //modelBuilder.Entity<Price>()
      //    .HasOne(p => p.RoomType)
      //    .WithMany(rt => rt.Prices)
      //    .HasForeignKey(p => p.RoomTypeId)
      //    .OnDelete(DeleteBehavior.Restrict); 

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

      modelBuilder.Entity<Hotel>().HasData(
        new { Id = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A"), Name = "Hotel, Singapore, Fullerton bay", Location = "Durbach, Germany", Rating = 4.9, Star = 3, MainPhoto = "B3C83220-D255-46D7-AC76-114ECE1D925A.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla volutpat orci at augue ultricies fermentum. Ut massa lectus, dignissim sed molestie ut, viverra vel diam. Fusce at iaculis magna. Suspendisse vel est et est luctus ornare venenatis ut neque. Pellentesque varius lacus sed arcu pellentesque, a porttitor velit gravida. Nunc nunc lectus, rhoncus consectetur metus eget, fermentum laoreet mauris. Cras ac gravida ante. Ut in ante ex. Proin tristique a ligula vel pharetra. Vestibulum blandit nisl dui, in pulvinar metus mollis pharetra. Duis cursus porttitor libero, quis lacinia velit. Curabitur tincidunt laoreet mi, eu maximus nibh vestibulum sed. Phasellus orci." },
        new { Id = Guid.Parse("F6A9207D-AD8B-4D5F-BEA5-1CD2F87A0308"), Name = "Hotel, Nature, Switzerland", Location = "Nottingham, UK", Rating = 2.4, Star = 4, MainPhoto = "F6A9207D-AD8B-4D5F-BEA5-1CD2F87A0308.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus a semper lacus. Vestibulum vehicula elementum auctor. Vestibulum malesuada, nibh a pretium ullamcorper, tortor nisi tincidunt ante, sed gravida purus mi in ligula. In malesuada ligula vitae risus iaculis, et sollicitudin lorem ornare. Nullam nec ullamcorper est. Donec efficitur et ipsum auctor semper. In id eros risus. Suspendisse quis massa convallis, suscipit eros eget, ullamcorper metus. Phasellus laoreet nulla quam, vel porttitor diam efficitur vitae. Etiam sollicitudin urna vel auctor accumsan. Suspendisse commodo pulvinar mauris, quis viverra lectus hendrerit dictum. In sed lorem tempus ipsum rutrum suscipit vitae sed mauris. Nunc." },
        new { Id = Guid.Parse("FFE1C64A-AD2B-443E-B5AC-2CE60ECA6340"), Name = "Lanzarote, Hotel, Heaven", Location = "Furna, Switzerland", Rating = 4.7, Star = 3, MainPhoto = "FFE1C64A-AD2B-443E-B5AC-2CE60ECA6340.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut imperdiet ex ac euismod pulvinar. Cras lorem nulla, posuere sed semper sed, scelerisque non nulla. Sed mi lorem, condimentum nec magna ac, ultricies lobortis ante. Integer tincidunt, metus eget mattis hendrerit, nibh metus sagittis diam, sed imperdiet metus nisi ac magna. Pellentesque iaculis mi purus, a porta tortor sodales consequat. Pellentesque vel mattis ligula. Fusce ac massa id ex rutrum eleifend. Nunc porta tortor dictum, ornare metus quis, laoreet ante. Nullam ullamcorper magna eget eleifend consequat. In nulla ex, iaculis vestibulum eros ac, vestibulum euismod arcu. Nullam sollicitudin at neque et." },
        new { Id = Guid.Parse("2CEDEA9F-912D-48C7-9125-3C11769F71A7"), Name = "Hotel, Building, House, Shops", Location = "Gearstones, UK", Rating = 4.8, Star = 5, MainPhoto = "2CEDEA9F-912D-48C7-9125-3C11769F71A7.jpg", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut laoreet, justo ut egestas pulvinar, est dui elementum neque, ac elementum lectus tellus in libero. Cras ullamcorper tellus id velit finibus, at rutrum odio convallis. Donec gravida nec mauris eget iaculis. Praesent faucibus ante fringilla, ullamcorper enim sit amet, suscipit leo. Sed libero erat, facilisis vel nunc et, venenatis volutpat quam. Integer sit amet lobortis risus, ut hendrerit orci. Vivamus pulvinar lectus dui, a dictum odio eleifend vitae. Pellentesque gravida risus eu ipsum efficitur consectetur. Nulla lectus leo, pharetra vel ante ut, mollis pharetra arcu. Morbi vitae metus ante. Integer lacinia." },
        new { Id = Guid.Parse("6C294357-66E3-49B1-AB63-42173553E89C"), Name = "Hotel, Winter, Season", Location = "Ockle, Scotland", Rating = 3.6, Star = 4, MainPhoto = "", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer facilisis magna eget sem feugiat, non pulvinar dui interdum. Proin quis tincidunt ex. Pellentesque dictum nibh dolor, cursus porta magna sodales a. Morbi vitae tortor nisi. Nullam molestie dui tempus, lobortis dolor sit amet, hendrerit libero. Quisque sed massa id lacus ornare faucibus eget facilisis mi. Donec interdum bibendum leo nec facilisis. In semper nec eros id tincidunt. Nunc sed sagittis justo. Ut massa ligula, posuere sed iaculis sit amet, laoreet ut ipsum. Nulla facilisi. Vestibulum iaculis risus nulla. Nunc congue elit et erat blandit vulputate. Praesent vulputate tortor at augue." },
        new { Id = Guid.Parse("C48CBBE7-6A94-4480-9C60-48B54AF81545"), Name = "Marina bay sands, Singapore", Location = "Ocluder, Singopour", Rating = 4.2, Star = 5, MainPhoto = "", Description = "Singapore skyline with urban buildings over water" },
        new { Id = Guid.Parse("E0C80AAF-2224-40D5-8D54-66BF4FBBFCD8"), Name = "Hotel, High, Stone image", Location = "Madrid, Espane", Rating = 4.1, Star = 4, MainPhoto = "E0C80AAF-2224-40D5-8D54-66BF4FBBFCD8.jpg", Description = "Lorem ipsum dolor sit amet sed diam sadipscing sit stet amet invidunt nibh autem voluptua justo tempor tation sed. Consetetur labore accusam ut nonumy justo dolore kasd. Duis odio labore dolore stet. Kasd vel dolor feugait illum accusam veniam dolore dignissim labore. Ut sed elitr elitr amet gubergren ipsum tempor sed duo erat justo no nibh id voluptua ut." },
        new { Id = Guid.Parse("95175BFC-AF50-4588-9373-68EE30E88F75"), Name = "Hotel, Invalidendom", Location = "Paris, France", Rating = 4.9, Star = 5, MainPhoto = "", Description = "Lorem ipsum dolor sit amet gubergren ipsum vulputate invidunt vel sit dolor liber. Elitr ut et vulputate est. Justo ut nonummy est. Dolor ipsum duis rebum lorem laoreet autem elitr vero gubergren sea est clita wisi et dolore. Ut duo lorem ipsum takimata facilisis est sanctus sea at accusam sanctus clita labore et dolor. Eos illum delenit et ipsum sed amet. Gubergren accusam consetetur." }
        );

      modelBuilder.Entity<Room>()
          .HasMany(r => r.RoomPhotos)
          .WithOne(rp => rp.Room)
          .HasForeignKey(rp => rp.RoomId)
          .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<Room>().HasData(
        new { Id = Guid.Parse("6B09F078-169F-4AE8-AAA1-5B8A2E1C896B"), HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A"), RoomTypeId= Guid.Parse("0282BE52-3816-401E-AF3F-074BE089D921"), PeopleNumber = 2, Square = 40.0, Description = "Takimata consectetuer lorem facilisis ipsum nibh sit accusam aliquyam justo clita" },
        new { Id = Guid.Parse("E12D0BA1-7AC8-4A19-B241-31705C2A3500"), HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A"), RoomTypeId = Guid.Parse("A19B9BBE-A941-4B3E-BB2D-07E75ED1850A"), PeopleNumber = 4, Square = 52.0, Description = "Elitr sed enim stet dolore consectetuer consetetur et facer diam eirmod dolores tempor ea sit." },
        new { Id = Guid.Parse("1088F86A-F6F2-4CC8-88FA-1D0BEB5E95D8"), HotelId = Guid.Parse("B3C83220-D255-46D7-AC76-114ECE1D925A"), RoomTypeId = Guid.Parse("4776D7CE-CC8D-4C86-8B9D-40650651DF33"), PeopleNumber = 2, Square = 34.0, Description = "Nibh vero illum sit. Dolor consetetur tempor amet sea lorem consequat diam dolor ea accusam no te at ea clita diam." },
        new { Id = Guid.Parse("9D551953-1B52-4CB1-AD90-31C8653955FA"), HotelId = Guid.Parse("F6A9207D-AD8B-4D5F-BEA5-1CD2F87A0308"), RoomTypeId = Guid.Parse("072FC618-8703-437F-9662-5BA97D0AB4F0"), PeopleNumber = 3, Square = 38.0, Description = "Zzril tation clita stet." },
        new { Id = Guid.Parse("DCA48FFC-C572-4CA5-8217-7A7D370FED2A"), HotelId = Guid.Parse("F6A9207D-AD8B-4D5F-BEA5-1CD2F87A0308"), RoomTypeId = Guid.Parse("68188476-48C6-48BE-B4CC-F8B63B4F0B08"), PeopleNumber = 3, Square = 40.5, Description = "Accumsan amet nonumy nonumy et amet euismod sed ipsum invidunt tincidunt ad. Ea dolor justo diam. Sea at labore duo iriure et ut ullamcorper in dignissim sit sit ipsum." }
        );


      modelBuilder.Entity<RoomFacility>().HasData(
        new { Id = Guid.Parse("4C17ADE5-2349-43FE-A9D1-D10AED6DDEBD"), Name = "Цифровое ТВ",      RoomId = Guid.Parse("6B09F078-169F-4AE8-AAA1-5B8A2E1C896B")}, 
        new { Id = Guid.Parse("6E69E113-EB98-4094-B417-83D61A9AB4EB"), Name = "Мини-холодильник", RoomId = Guid.Parse("6B09F078-169F-4AE8-AAA1-5B8A2E1C896B")},
        new { Id = Guid.Parse("D3FB6A18-F736-4CB5-BF64-69C36B3D489C"), Name = "Wi-Fi",            RoomId = Guid.Parse("6B09F078-169F-4AE8-AAA1-5B8A2E1C896B")},
        new { Id = Guid.Parse("13B17DAB-7ED0-40D9-93D5-B020EEA0AAD9"), Name = "Ванна",            RoomId = Guid.Parse("E12D0BA1-7AC8-4A19-B241-31705C2A3500")},
        new { Id = Guid.Parse("427BA46A-07E6-4DA2-AFED-C1760F02A636"), Name = "Фен",              RoomId = Guid.Parse("E12D0BA1-7AC8-4A19-B241-31705C2A3500")},
        new { Id = Guid.Parse("A774E890-3726-4E5B-8071-50E01F27B7B9"), Name = "Цифровое ТВ",      RoomId = Guid.Parse("E12D0BA1-7AC8-4A19-B241-31705C2A3500")},
        new { Id = Guid.Parse("573716D8-E318-4BA0-957C-2A1A0BE4AF30"), Name = "Wi-Fi",            RoomId = Guid.Parse("E12D0BA1-7AC8-4A19-B241-31705C2A3500")}
        );

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
