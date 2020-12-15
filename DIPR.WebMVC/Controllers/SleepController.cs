using DIPR.Models.Sleep;
using DIPR.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIPR.WebMVC.Controllers
{
    public class SleepController : Controller
    {
        // GET: Sleep
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new SleepService(userID);
            var model = service.GetSleep();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SleepCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSleepService();

            if (service.CreateSleep(model))
            {
                TempData["SaveResult"] = "Your baby's sleep data has been added!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your baby's sleep data could not be added. Please, try again.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSleepService();
            var model = svc.GetSleepById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSleepService();
            var detail = service.GetSleepById(id);
            var model =
                new SleepEdit
                {
                    SleepID = detail.SleepID
                   
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SleepEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SleepID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateSleepService();

            if (service.UpdateSleep(model))
            {
                TempData["SaveResult"] = "The sleep data was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The sleep data could not be updated.");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateSleepService();
            var model = svc.GetSleepById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSleep(int id)
        {
            var service = CreateSleepService();

            service.DeleteSleep(id);

            TempData["SaveResult"] = "You've deleted the selected sleep data.";

            return RedirectToAction("Index");
        }


        private SleepService CreateSleepService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SleepService(userId);
            return service;
        }
    }
}