using System.Text.Json;
using Microsoft.Extensions.Logging;
using PegMe.Models;

namespace Infrastructure
{
    public class ClubContextSeed
    {
        public static async Task SeedAsync(ClubDbContext context, ILogger logger)
        {
            try{

                if(!context.Clubs.Any())
                {
                    var clubData = File.ReadAllText("../Infrastructure/SeedData/Clubs.json");
                    var clubs = JsonSerializer.Deserialize<List<Club>>(clubData);

                    foreach(var item in clubs)
                    {
                        context.Clubs.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if(!context.Courses.Any())
                {
                    var courseData = File.ReadAllText("../Infrastructure/SeedData/Courses.json");
                    var clubs = JsonSerializer.Deserialize<List<Course>>(courseData);

                    foreach(var item in clubs)
                    {
                        context.Courses.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                
                if(!context.Holes.Any())
                {
                    var holesData = File.ReadAllText("../Infrastructure/SeedData/Holes.json");
                    var holes = JsonSerializer.Deserialize<List<Hole>>(holesData);

                    foreach(var item in holes)
                    {
                        context.Holes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if(!context.HoleLengths.Any())
                {
                    var holeLengthsData = File.ReadAllText("../Infrastructure/SeedData/HoleLengths.json");
                    var holeLengths = JsonSerializer.Deserialize<List<HoleLength>>(holeLengthsData);

                    foreach(var item in holeLengths)
                    {
                        context.HoleLengths.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

            }catch(Exception ex)
                {
                    logger.LogError(ex.Message);
                }
        }
    }
}