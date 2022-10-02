using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Transaction = Project.Models.Transaction;

namespace Project.Controllers
{
  
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public SalesController(ApplicationDbContext db , UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index(string? status = "")
        {
            ViewBag.status = status;
            return View();

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

        public async Task<IActionResult> InsertAsync(int? houseid)
        {
            ApplicationUser currentUser= await _userManager.GetUserAsync(User);
            ViewBag.UserId = currentUser.Id;
            ViewBag.HouseId = houseid;
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Transaction newTransaction)
        {
            _db.Transactions.Add(newTransaction);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}
