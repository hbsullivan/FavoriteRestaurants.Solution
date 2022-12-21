using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FavoriteRestaurants.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FavoriteRestaurants.Controllers
{
  public class RestaurantController : Controller
  {
    private readonly FavoriteRestaurantsContext _db;
    public RestaurantController(FavoriteRestaurantsContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Restaurant> model = _db.Restaurants
        .Include(restaurant => restaurant.Cuisine)
        .ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants
        .Include(restaurant => restaurant.Cuisine)
        .FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }
  }
}