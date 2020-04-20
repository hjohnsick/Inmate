using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PoliceHQ.Models;

namespace PoliceHQ.Controllers
{
    [Authorize]
    public class PoliceHqController : Controller
    {
        private readonly PoliceHqDbContext _context;
        private readonly string _configuration;
        public PoliceHqController(IConfiguration configuration, PoliceHqDbContext context)
        {
            _context = context;
            
        }
        public IActionResult Index()
        {
            return View(_context.Inmate.ToList());
        }

        [HttpGet]
        public IActionResult AddInmate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddInmate(Inmate newInmate)
        {
            if (ModelState.IsValid)
            {
                _context.Inmate.Add(newInmate);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateInmate(int id)
        {
            Inmate found = _context.Inmate.Find(id);
            return View(found);
        }
        [HttpPost]
        public IActionResult UpdateInmate(Inmate updatedInmate)
        {
            Inmate dbInmate = _context.Inmate.Find(updatedInmate.Id);
            if (ModelState.IsValid)
            {
                dbInmate.FirstName = updatedInmate.FirstName;
                dbInmate.LastName = updatedInmate.LastName;
                dbInmate.Dob = updatedInmate.Dob;
                dbInmate.Charges = updatedInmate.Charges;
                dbInmate.DateBooked = updatedInmate.DateBooked;
                dbInmate.HairColor = updatedInmate.HairColor;
                dbInmate.EyeColor = updatedInmate.EyeColor;
                dbInmate.Tattoos = updatedInmate.Tattoos;

                _context.Entry(dbInmate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.Update(dbInmate);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //public IActionResult DeleteInmate(int id)
        //{
        //    Inmate found = _context.Inmate.Find(id);
        //    if(found != null)
        //    { 
        //        _context.Inmate.Remove(found);
        //        _context.SaveChanges();
        //    }
        //}
    }
}