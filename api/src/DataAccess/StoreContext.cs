using Microsoft.EntityFrameworkCore;
using StoreFront.DataAccess.Models;

namespace StoreFront.DataAccess;
class StoreContext(DbContextOptions<StoreContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
}