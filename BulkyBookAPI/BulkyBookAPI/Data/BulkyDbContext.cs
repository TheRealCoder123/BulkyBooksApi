using BulkyBookAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BulkyBookAPI.Data
{

    public class BulkyDbContext : DbContext
    {
        public BulkyDbContext(DbContextOptions<BulkyDbContext> dbContext) : base(dbContext)
        {
        }

        public DbSet<Book> Book { get; set; }
        
        public DbSet<Genre> Genre { get; set; }
        
        public DbSet<Author> Author { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Wishlist> Wishlist { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<CreditCards> CreditCard { get; set; }

        public DbSet<OrderedBooks> OrderedBook { get; set; }

    }

}
