using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class FoodController : Controller
    {
        IRestaurantRepository repository;

        public FoodController(IRestaurantRepository repository)
        {
            this.repository = repository;
        }
        [OutputCache(Duration = 20, VaryByParam = "none")]
        public IActionResult Index()
        {
            return View(this.repository.Read());
        }
        [OutputCache(Duration = 20, VaryByParam = "none")]
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Food food, IFormFile picturedata)
        {
            using (var stream = picturedata.OpenReadStream())
            {
                byte[] buffer = new byte[picturedata.Length];
                stream.Read(buffer, 0, (int)picturedata.Length);
                string filename = food.Id + "." + picturedata.FileName.Split('.')[1];
                food.ImageFileName = filename;
                //fájl módszer
                //System.IO.File.WriteAllBytes(Path.Combine("wwwroot", "images", filename), buffer);
                //db módszer
                food.Data = buffer;
                food.ContentType = picturedata.ContentType;
            }
            if (!ModelState.IsValid)
            {
                return View(food);
            }
            repository.Create(food);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult GetImage(string id)
        {
            var hero = repository.ReadFromId(id);
            if (hero.ContentType.Length > 3)
            {
                return new FileContentResult(hero.Data, hero.ContentType);
            }
            else
            {
                return BadRequest();
            }

        }
        
    }
}
