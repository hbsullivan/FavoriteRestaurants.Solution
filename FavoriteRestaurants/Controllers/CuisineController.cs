using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FavoriteRestaurants.Models;
using System.Collections.Generic;

namespace FavoriteRestaurants.Controllers
{
  public class CuisineController : Controller
  {
    private readonly FavoriteRestaurantsContext _db;

    public CuisineController(FavoriteRestaurantsContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Cuisine cuisine)
    {
      _db.Cuisines.Add(cuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Cuisine thisCuisine = _db.Cuisines
        .Include(cuisine => cuisine.Restaurants)
        .FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }
    public ActionResult Edit(int id)
    {
      Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }
    
    [HttpPost]
    public ActionResult Edit(Cuisine cuisine)
    {
      _db.Cuisines.Update(cuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    // [HttpPost, ActionName("Delete")]
    [HttpPost]
    public ActionResult Delete(int id)
    {
        Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(Cuisine => Cuisine.CuisineId == id);
        _db.Cuisines.Remove(thisCuisine);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}