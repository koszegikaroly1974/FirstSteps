using FirstSteps.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstSteps.Controllers
{
    public class ContactController : Controller
    {
        private readonly FirstStepsDbContext _db;

        public ContactController(FirstStepsDbContext db)
        {
            _db = db;
        }



        public IActionResult Index()
        {
            IEnumerable<Contact> objList = _db.Contacts;
            return View(objList);
        }

        //Get create method
        public IActionResult Create()
        {
            IEnumerable<Contact> objList = _db.Contacts;
            return View();
        }

        //Post create method
        [HttpPost]
        public IActionResult Create(Contact obj)
        {
            if (ModelState.IsValid)
            {
                _db.Contacts.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get partnerform method
        public IActionResult ContactForm(int? ContactId)
        {

            if (ContactId == null || ContactId == 0)
            {
                return NotFound("A keresett parner Id nem található! ");
            }

            var obj = _db.Contacts.Find(ContactId);
            if (obj == null)
            {
                return NotFound("A keresett parner osztály nem található!");
            }
            return View(obj);
        }

        //Get  update method
        public IActionResult Update(int? ContactId)
        {
            if (ContactId == null || ContactId == 0)
            {
                return NotFound("A keresett parner Id nem található! ");
            }

            var obj = _db.Contacts.Find(ContactId);
            if (obj == null)
            {
                return NotFound("A keresett parner osztály nem található!");
            }
            ViewBag.obj = obj;
            return View(obj);
        }


        //Post update method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(Contact obj)
        {
            if (ModelState.IsValid)
            {
                _db.Contacts.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get delete method

        public IActionResult Delete(int? ContactId)
        {
            if (ContactId == null || ContactId == 0)
            {
                return NotFound("A keresett parner Id nem található! ");
            }

            var obj = _db.Contacts.Find(ContactId);
            if (obj == null)
            {
                return NotFound("A keresett parner osztály nem található!");
            }
            return View(obj);
        }

        //Post delete method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? ContactId)
        {
            var obj = _db.Contacts.Find(ContactId);
            if (obj == null)
            {
                return NotFound("A keresett parner nem található! post");
            }

            _db.Contacts.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
