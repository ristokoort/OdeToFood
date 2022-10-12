using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.RestaurantReviews.Any())
                {
                    return;   // DB has been seeded
                }

                context.Restaurants.AddRange(
                    new Restaurant
                    {
                        Name = "Sabatino's",
                        City = "Baltimore",
                        Country = "USA",
                    },
                     new Restaurant
                     {
                         Name = "Great Lake",
                         City = "Chicago",
                         Country = "USA",
                     },
                      new Restaurant
                      {
                          Name = "Smaka",
                          City = "Gothenburg",
                          Country = "Sweden",
                          Reviews =
                          new List<RestaurantReview>
                          {
                              new RestaurantReview{Rating=9,Body="Great food!"}
                          }
                      }



                ); 
                context.SaveChanges();
            }
        }
    }
}

