using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BookShop.Data
{
    public class BookShopContext : IdentityDbContext<DefaultUser>
    {
        public BookShopContext (DbContextOptions<BookShopContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

    }
}
