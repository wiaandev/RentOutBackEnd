using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentOutBackEnd.Domain.Entities;

namespace RentOutBackEnd.Domain.Services;

public class SeedService(AppDbContext appDbContext, UserManager<User> userManager)
{
    public async Task Seed()
    {
        await this.SeedPropertyPosts();
        await this.SeedPropertyExtras();
    }

    public async Task SeedPropertyPosts()
    {
        var properties = new List<PropertyPost>
        {
            new()
            {
                PropertyType = PropertyPost.RentType.Apartment,
                WeeklyAmount = 600,
                BedroomAmount = 2,
                BathroomAmount = 1,
                ParkingAmount = 2,
                PetAmount = 2,
                PetType = new List<PropertyPost.AllowedPetType>
                {
                    PropertyPost.AllowedPetType.Bird,
                    PropertyPost.AllowedPetType.Dog
                },
                CreatedAt = DateTime.UtcNow.AddHours(2),
            }
        };

        appDbContext.PropertyPosts.AddRange(properties);
        await appDbContext.SaveChangesAsync(); // Save to persist the data and generate IDs
    }

    public async Task SeedPropertyExtras()
    {
        // Retrieve the PropertyPost to get its generated ID
        var propertyPost = await appDbContext.PropertyPosts.ToListAsync();

        if (!propertyPost.Any())
        {
            throw new Exception("No propertyPost found.");
        }

        var propertyExtras = new List<PropertyExtras>
        {
            new()
            {
                Property = new PropertyPost
                {
                    PropertyType = PropertyPost.RentType.Apartment,
                    WeeklyAmount = 600,
                    BedroomAmount = 2,
                    BathroomAmount = 1,
                    ParkingAmount = 2,
                    PetAmount = 2,
                    PetType = new List<PropertyPost.AllowedPetType>
                    {
                        PropertyPost.AllowedPetType.Bird,
                        PropertyPost.AllowedPetType.Dog
                    },
                    CreatedAt = DateTime.UtcNow.AddHours(2)
                },
                PropertyPostId = 1, // Use the actual ID of the saved PropertyPost
                HasFiber = true,
                PetsAllowed = true,
                HasPool = true,
                HasGarden = false,
                HasPatio = true,
                HasFlatlet = false
            }
        };

        appDbContext.PropertyExtrasEnumerable.AddRange(propertyExtras);
        await appDbContext.SaveChangesAsync();
    }
}
