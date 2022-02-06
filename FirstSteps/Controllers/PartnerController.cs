using FirstSteps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FirstSteps.Controllers
{
    public class PartnerController : Controller
    {
        private readonly FirstStepsDbContext _db;

        public PartnerController(FirstStepsDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Partner> objList = _db.Partners;
            return View(objList);
        }

        //Get create method
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> TypeDropDown = _db.Contacts.Select(i => new SelectListItem
            {

                Text = i.ContactName,
                Value = i.ContactId.ToString()

            }) ;

            ViewBag.TypeDropDown = TypeDropDown;

            return View();
        }

        //Post create method
        [HttpPost]
        public IActionResult Create(Partner obj)
        {
            if (ModelState.IsValid)
            {
                _db.Partners.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get partnerform method
        public IActionResult PartnerForm(int? PartnerId)
        { 
        
            if (PartnerId == null || PartnerId == 0)
            {
                return NotFound("A keresett parner Id nem található! ");
            }

            var obj = _db.Partners.Find(PartnerId);
            if (obj == null)
            {
                return NotFound("A keresett parner osztály nem található!");
            }
            return View(obj);
        }

        //Get  update method
        public IActionResult Update(int? PartnerId)
        {
            if (PartnerId == null || PartnerId == 0)
            {
                return NotFound("A keresett parner Id nem található! ");
            }

            var obj = _db.Partners.Find(PartnerId);
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
        public IActionResult UpdatePost(Partner obj)
        {
            if (ModelState.IsValid)
            {
                _db.Partners.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get delete method

        public IActionResult Delete(int? PartnerId)
        {
           if (PartnerId == null || PartnerId == 0)
            {
                return NotFound("A keresett parner Id nem található! ");
            }
            
            var obj = _db.Partners.Find(PartnerId);
           if (obj == null)
            {
                return NotFound("A keresett parner osztály nem található!");
            }
            return View(obj);
        }

        //Post delete method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? PartnerId)
        {
            var obj = _db.Partners.Find(PartnerId);
            if (obj == null)
            {
                return NotFound("A keresett parner nem található! post");
            }
            
                _db.Partners.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
