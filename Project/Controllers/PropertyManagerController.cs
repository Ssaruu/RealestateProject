using System.Collections.Generic;
using System.Linq;
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

        public IActionResult Index(string? status="")
        {
            ViewBag.status = status;
            return View();
        }
        //public IActionResult ViewAll()
        //{
        //    IEnumerable<House> data = _db.House;

        //    return View(data);
        //}
        public IActionResult ViewUserDetail()
        {
            IEnumerable<User> data = _db.User;

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


        public IActionResult Edit(int? HouseId)
        {
            if (HouseId==null || HouseId == 0)
            {
                return NotFound();
            }
            var newHouse = _db.House.Find(HouseId);
            if (newHouse == null)
            {
                return NotFound();
            }
            return View(newHouse);
        }

        [HttpPost]
        public IActionResult Edit(House newHouse)
        {
            if (ModelState.IsValid)
            {
                _db.House.Update(newHouse);
                _db.SaveChanges();
                return RedirectToAction("ViewAll");
            }
            return View(newHouse);
        }
       
        public IActionResult Search()
        {
            ViewBag.searchIndex = "";
            return View();
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User newUser)
        {
            _db.User.Add(newUser);
            _db.SaveChanges();
            return Redirect("Index");


        }
           public IActionResult DeleteHouse(int? id)
        {
            var house = _db.House.Find(id);
            return View(house);
        }

        [HttpPost]
        public IActionResult DeleteHouse(House house)
        {
            _db.House.Remove(house);
            _db.SaveChanges();
            return Redirect("Index");
        }

        public IActionResult ViewAll(string index = "", string type = "")
        {
            IEnumerable<House> houses;
            if (type == "" || type == null)
            {
                houses = _db.House.Where(temp => temp.Address.Contains(index)).ToList();
            }

            if (type == "id")
            {
                houses = _db.House.Where(temp => temp.HouseId.ToString().Contains(index)).ToList();

            }

            else if (type == "price")
            {
                houses = _db.House.Where(temp => temp.Price.ToString().Contains(index)).ToList();
            }
            else if (type == "size")
            {
                houses = _db.House.Where(temp => temp.HouseSize.ToString().Contains(index)).ToList();
            }
            else if (type == "status")
            {
                houses = _db.House.Where(temp => temp.HouseStatus.Contains(index)).ToList();
            }
            else
            {
                houses = _db.House.Where(temp => temp.Address.Contains(index)).ToList();
            }


            return View(houses);
        }

        public IActionResult AddSalesPerson()
        {
            return View();
        }
        public IActionResult UserInsertionCompleted(ApplicationUser salesPerson)
        {
            return View(salesPerson);
        }
    }
   
}
