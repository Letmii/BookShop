﻿using BookShop.Data;
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
                       Title = "Harry Potter",
                       Language = "Swedish",
                       ISBN = "9789129688313",
                       PublishedDate = DateTime.Parse("2002-9-26"),
                       Price = 56,
                       Author = "Tomek",
                       ImageUrl = "/images/abcd.jpg",
                       Description = "abcdef"
                   }
                );
                context.Books.AddRange(
                   new Book
                   {
                       Title = "Tomcio Paluch",
                       Language = "Polski",
                       ISBN = "97899688313",
                       PublishedDate = DateTime.Parse("2012-9-26"),
                       Price = 11,
                       Author = "Tomek",
                       ImageUrl = "/images/adad.jpg",
                       Description = "abcdeaaaf"
                   }
                );
                context.Books.AddRange();
                context.SaveChanges();
            }
        }
    }
}

