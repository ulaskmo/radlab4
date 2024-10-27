using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using radlab4._0.Models;
using System;
using System.Linq;

namespace radlab4._0.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TodoDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<TodoDbContext>>()))
            {
                if (context.TodoItems.Any())
                {
                    return; // DB has been seeded
                }

                context.TodoItems.AddRange(
                    new TodoItem
                    {
                        Name = "Task 1",
                        Description = "This is a sample task",
                        Status = Status.NotStarted
                    },
                    new TodoItem
                    {
                        Name = "Task 2",
                        Description = "This is another sample task",
                        Status = Status.InProgress
                    }
                );
                context.SaveChanges();
            }

            using (var adContext = new AdDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AdDbContext>>()))
            {
                if (adContext.Ads.Any() || adContext.Sellers.Any() || adContext.Categories.Any())
                {
                    return; // DB has been seeded
                }

                // Seed the Sellers and Categories
                var sellers = new[]
                {
                    new Seller { Name = "Seller 1" },
                    new Seller { Name = "Seller 2" }
                };

                var categories = new[]
                {
                    new Category { Name = "Category 1" },
                    new Category { Name = "Category 2" }
                };

                adContext.Sellers.AddRange(sellers);
                adContext.Categories.AddRange(categories);
                adContext.SaveChanges();

                // Retrieve the IDs for Sellers and Categories after saving them
                var seller1 = adContext.Sellers.FirstOrDefault(s => s.Name == "Seller 1");
                var seller2 = adContext.Sellers.FirstOrDefault(s => s.Name == "Seller 2");

                var category1 = adContext.Categories.FirstOrDefault(c => c.Name == "Category 1");
                var category2 = adContext.Categories.FirstOrDefault(c => c.Name == "Category 2");

                // Ensure they exist before seeding Ads
                if (seller1 != null && seller2 != null && category1 != null && category2 != null)
                {
                    // Seed Ads with valid foreign keys
                    adContext.Ads.AddRange(
                        new Ad
                        {
                            Title = "Sample Ad 1",
                            Description = "This is a sample ad",
                            SellerId = seller1.Id, // Use valid SellerId
                            CategoryId = category1.Id // Use valid CategoryId
                        },
                        new Ad
                        {
                            Title = "Sample Ad 2",
                            Description = "This is another sample ad",
                            SellerId = seller2.Id, // Use valid SellerId
                            CategoryId = category2.Id // Use valid CategoryId
                        }
                    );
                    adContext.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Error: Sellers or Categories could not be found during seeding.");
                }
            }
        }
    }
}
