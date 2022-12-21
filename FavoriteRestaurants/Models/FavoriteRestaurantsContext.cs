using Microsoft.EntityFrameworkCore;

namespace FavoriteRestaurants.Models
{
  public class FavoriteRestaurantsContext : DbContext
  {
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Cuisine> Cuisines { get; set; }

    public FavoriteRestaurantsContext(DbContextOptions options) : base(options) { }
  }
}