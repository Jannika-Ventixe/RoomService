using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using Persistence.Entities;

//Fick hjälp av Emil med denna

namespace Persistence.Seeders;

public static class AppSeeder
{
    public static async Task SeedDb(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<DataContext>();

        // Avsluta om databasen redan har rum
        if (db.Rooms.Any()) return;

        // Skapa paket
        var packages = new List<PackageEntity>
        {
            new() { Title = "Standard", RoomDescription = "Basic room package", Price = 799, Currency = "SEK" },
            new() { Title = "Deluxe", RoomDescription = "Larger room with better view", Price = 1299, Currency = "SEK" },
            new() { Title = "Business", RoomDescription = "Includes workspace and breakfast", Price = 1499, Currency = "SEK" },
            new() { Title = "Romantic", RoomDescription = "Couples special with champagne", Price = 1599, Currency = "SEK" },
            new() { Title = "Family", RoomDescription = "2 adults + 2 kids, extra beds", Price = 1399, Currency = "SEK" },
            new() { Title = "Weekend Deal", RoomDescription = "Discount for Friday-Sunday", Price = 999, Currency = "SEK" },
            new() { Title = "Spa Package", RoomDescription = "Room with spa access", Price = 1799, Currency = "SEK" },
            new() { Title = "Conference", RoomDescription = "Room + meeting room access", Price = 1699, Currency = "SEK" },
            new() { Title = "Eco Stay", RoomDescription = "Environmentally-friendly stay", Price = 899, Currency = "SEK" },
            new() { Title = "All Inclusive", RoomDescription = "Everything included", Price = 1999, Currency = "SEK" },
        };

        await db.Packages.AddRangeAsync(packages);
        await db.SaveChangesAsync();

        var random = new Random();
        var rooms = new List<RoomEntity>();
        var roomPackageRelations = new List<RoomPackagesEntity>();

        for (int i = 1; i <= 10; i++)
        {
            var room = new RoomEntity
            {
                Title = $"Room {i}",
                Description = $"Room {i} description.",
                Image = $"room{i}.jpg"
            };

            rooms.Add(room);

            // Koppla detta rum till 1–3 slumpmässiga paket
            var packageCount = random.Next(1, 4);
            var selectedPackages = packages.OrderBy(x => random.Next()).Take(packageCount).ToList();

            foreach (var pkg in selectedPackages)
            {
                roomPackageRelations.Add(new RoomPackagesEntity
                {
                    Room = room,
                    Package = pkg
                });
            }
        }

        await db.Rooms.AddRangeAsync(rooms);
        await db.SaveChangesAsync();

        await db.AddRangeAsync(roomPackageRelations);
        await db.SaveChangesAsync();
    }
}



