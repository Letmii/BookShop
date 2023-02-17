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
                       ISBN = "9789129688311",
                       PublishedDate = DateTime.Parse("1997-6-26"),
                       Price = 30,
                       Author = "J.K. Rowling",
                       ImageUrl = "/images/harry1.jpg"
                   },
                    new Book
                    {
                        Title = "Harry Potter And The Chamber Of Secrets",
                        Language = "English",
                        ISBN = "9780261102352",
                        PublishedDate = DateTime.Parse("1998-7-2"),
                        Price = 31,
                        Author = "J.K. Rowling",
                        ImageUrl = "/images/harry2.jpg"
                    },
                    new Book
                    {
                        Title = "The Lord Of The Rings",
                        Language = "English",
                        ISBN = "9780261102353",
                        PublishedDate = DateTime.Parse("2008-3-4"),
                        Price = 100,
                        Author = "J. R. R. Tolkien",
                        ImageUrl = "/images/lord.jpg"
                    },
                    new Book
                    {
                        Title = "The hobbit, or There and back again",
                        Language = "English",
                        ISBN = "9780261102354",
                        PublishedDate = DateTime.Parse("2012-7-12"),
                        Price = 120,
                        Author = "J. R. R. Tolkien",
                        ImageUrl = "/images/hobbit.jpg"
                    },
                    new Book
                    {
                        Title = "Fairy Tale",
                        Language = "English",
                        ISBN = "9780261102355",
                        PublishedDate = DateTime.Parse("2012-12-5"),
                        Price = 59,
                        Author = "Stephen King",
                        ImageUrl = "/images/fairytale.jpg"
                    }
                );

                
                context.SaveChanges();
            }
        }
    }
}

