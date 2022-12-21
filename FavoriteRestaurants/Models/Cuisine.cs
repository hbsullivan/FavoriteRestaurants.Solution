using System.Collections.Generic;

namespace FavoriteRestaurants.Models
{
  public class Cuisine
  {
    public int CuisineId { get; set; }
    public string Name { get; set; }
    public List<Restaurant> Restaurants { get; set; }
  }
}