using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    public class PropertyManagerController : Controller
    {

        private readonly ApplicationDbContext _db;
        public PropertyManagerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<House> data = _db.House;

            return View(data);
        }
        public IActionResult Insertion()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insertion(House newHouse)
        {
            _db.House.Add(newHouse);
            _db.SaveChanges();
            return Redirect("Index");


        }

        public IActionResult Edit(int HouseId)
        {
           
            var obj = _db.House.Find(HouseId);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(House obj)
        {
                  
                 _db.House.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
         
        }
        public IActionResult Search()
        {
            ViewBag.searchIndex = "";
            return View();
        }
    }
}
