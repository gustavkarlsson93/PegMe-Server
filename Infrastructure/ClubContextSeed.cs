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
                }
                

            }catch{

            }
        }
    }
}