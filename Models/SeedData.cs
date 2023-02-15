using BookShop.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing.Drawing2D;
using System.Linq;

namespace BookShop.Models
{
    public class SeedData
    {
        public static async Task EnsurePopulated(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<BookShopContext>();
            var storeContext = scope.ServiceProvider.GetRequiredService<BookShopContext>();


            var pendingMigrations = context.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                context.Database.Migrate();
            }
            context.Database.EnsureCreated();

            var identityPendingMigrations = storeContext.Database.GetPendingMigrations();
            if (identityPendingMigrations.Any())
            {
                storeContext.Database.Migrate();
            }

            storeContext.Database.EnsureCreated();


            if (!await context.Books.AnyAsync())
            {
                context.Books.AddRange(
                
                    new Book
                   {
                       Title = "Harry Potter and the Philosopher's Stone",
                       Language = "English",
                       ISBN = "9789129688313",
                       PublishedDate = DateTime.Parse("2002-1-18"),
                       Price = 56,
                       Author = "J.K. Rowling",
                       ImageUrl = "/images/harry1.jpg"
                   }
                );
                
                context.SaveChanges();
            }
        }
    }
}

