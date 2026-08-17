using LiveShoppingList.Models;
using Microsoft.EntityFrameworkCore;

namespace LiveShoppingList.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ShoppingItem> ShoppingItems => Set<ShoppingItem>();
    }
}
