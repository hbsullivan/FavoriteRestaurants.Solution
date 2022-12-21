using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Controllers
{
  public class AnimalsController : Controller
  {
    private readonly AnimalShelterContext _db;

    public AnimalsController(AnimalShelterContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Animal> model = _db.Animals
        .OrderBy(animal => animal.DateOfAdmission)
        .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Animal animal)
    {
      _db.Animals.Add(animal);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      return View(thisAnimal);
    }
    public ActionResult SearchDetails(int id)
    {
      Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.AnimalId == id);
      return View(thisAnimal);
    }
    public ActionResult Search(string searchTerm, string searchby)
    {

      List<Animal> animalList = new List<Animal>();
      if(searchby.Contains("Breed"))
      {
        animalList = _db.Animals.Where(animal => animal.Breed.Contains(searchTerm)).ToList();

      }
      else if(searchby.Contains("Type"))
      {
        animalList = _db.Animals.Where(animal => animal.TypeOfAnimal.Contains(searchTerm)).ToList();
        
        
      }
      else if(searchby.Contains("Name")) {
        animalList = _db.Animals.Where(animal => animal.Name.Contains(searchTerm)).ToList();
        
      }
      
      return View(animalList);
    }
  }
}