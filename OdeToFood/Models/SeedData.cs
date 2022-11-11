using Microsoft.AspNetCore.Identity;
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
        public const string ROLE_ADMIN = "Admin";
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
               
                if (context.RestaurantReviews.Any())
                {
                    return;   
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
                for(int i=0;i<1000;i++)
                {
                    context.Restaurants.AddRange(
                        new Restaurant
                        {
                            Name = $"{i}",
                            City = "Nowhere",
                            Country =
                        "USA"
                        });
                }
                context.SaveChanges();
            }
        }

        public static async Task SeedIdentity(UserManager<OdeToFoodUser> userManager, RoleManager<OdeToFoodRole> roleManager)
        {
            var user = await userManager.FindByNameAsync("123@gmail.com");
            if (user == null)
            {
                user = new OdeToFoodUser();
                user.Email = "123@gmail.com";
                user.EmailConfirmed = true;
                user.UserName = "123@gmail.com";
                var userResult = await userManager.CreateAsync(user);
                if (!userResult.Succeeded)
                {
                    throw new Exception($"User creation failed: {userResult.Errors.FirstOrDefault()}");
                }
                await userManager.AddPasswordAsync(user, "Pa$$w0rd");
            }
            var role = await roleManager.FindByNameAsync(ROLE_ADMIN);
            if (role == null)
            {
                role = new OdeToFoodRole();
                role.Name = ROLE_ADMIN;
                role.NormalizedName = ROLE_ADMIN;
                var roleResult = roleManager.CreateAsync(role).Result;
                if (!roleResult.Succeeded)
                {
                    throw new Exception(roleResult.Errors.First().Description);
                }
            }
            await userManager.AddToRoleAsync(user, ROLE_ADMIN);
        }
    }
}
