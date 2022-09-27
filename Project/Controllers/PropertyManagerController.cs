﻿using System.Collections.Generic;
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
        public IActionResult ViewAll()
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
        [HttpGet]
        public IActionResult Delete(int? HouseId)
        {
            if (HouseId == null || HouseId == 0)
            {
                return NotFound();
            }
            var obj = _db.House.Find(HouseId);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        public IActionResult DeletePost(int? HouseId)
        {
            var obj = _db.House.Find(HouseId);

            if (obj == null)
            {
                return NotFound();

            }
            _db.House.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("ViewAll");
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
      


    }
}
