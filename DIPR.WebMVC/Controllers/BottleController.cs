using DIPR.Models.Bottle;
using DIPR.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIPR.WebMVC.Controllers
{
    public class BottleController : Controller
    {
        // GET: Bottle
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new BottleService(userID);
            var model = service.GetBottle();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BottleCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBottleService();

            if (service.CreateBottle(model))
            {
                TempData["SaveResult"] = "Your baby's bottle has been added!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your baby's bottle could not be added. Please, try again.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBottleService();
            var model = svc.GetBottleById(id);

            return View(model);
        }

        // GET

        public ActionResult Edit(int id)
        {
            var service = CreateBottleService();
            var babyService = CreateBabyService();
            var detail = service.GetBottleById(id);
            var babies = babyService.GetBaby()
                .Select(x => new
                {
                    Text = x.Name,
                    Value = x.BabyID
                });

            var model =
                new BottleEdit
                {
                    BottleID = detail.BottleID,
                    Time = detail.Time,
                    Quantity = detail.Quantity,
                    Consumed = detail.Consumed,
                    Notes = detail.Notes,
                    Babies = new SelectList(babies, "Value", "Text")
                    
                };
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BottleEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BottleID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateBottleService();

            if (service.UpdateBottle(model))
            {
                TempData["SaveResult"] = "The bottle was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The bottle could not be updated.");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateBottleService();
            var model = svc.GetBottleById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBottle(int id)
        {
            var service = CreateBottleService();

            service.DeleteBottle(id);

            TempData["SaveResult"] = "You've deleted the selected bottle.";

            return RedirectToAction("Index");
        }

        private BottleService CreateBottleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BottleService(userId);
            return service;
        }

        private BabyService CreateBabyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BabyService(userId);
            return service;
        }
    }
}