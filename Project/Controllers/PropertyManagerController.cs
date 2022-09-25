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
            return View();
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

        public IActionResult Search()
        {
            ViewBag.searchIndex="";
            return View();
        }
    }
}
