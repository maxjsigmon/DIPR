using DIPR.Data;
using DIPR.Models;
using DIPR.Models.Baby;
using DIPR.Services;
using DIPR.WebMVC.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIPR.WebMVC.Controllers
{
    [Authorize]
    public class BabyController : Controller
    {

        // GET: Baby
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new BabyService(userID);
            var model = service.GetBaby();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST : Create Baby
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BabyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBabyService();

            if (service.CreateBaby(model))
            {
                TempData["SaveResult"] = "Your baby has been added!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your baby could not be added. Please, try again.");

            return View(model);
        }

        // GET : Baby Details by ID
        [HttpGet]
        public ActionResult Details(int id)
        {
            var svc = CreateBabyService();
            var model = svc.GetBabyById(id);

            return View(model);
        }

        // GET : Baby Details by ID
        public ActionResult Edit(int id)
        {
            var service = CreateBabyService();
            var detail = service.GetBabyById(id);
            var model =
                new BabyEdit
                {
                    BabyID = detail.BabyID,
                    Name = detail.Name,
                    BirthDate = detail.BirthDate,
                    Gender = detail.Gender,
                    Notes = detail.Notes
                };
            return View(model);
        }

        // POST : Baby Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BabyEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            var service = CreateBabyService();

            if (service.UpdateBaby(model))
            {
                TempData["SaveResult"] = "The baby was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The baby could not be updated.");
            return View();
        }

        // GET : Baby Details by ID
        public ActionResult Delete(int id)
        {
            var svc = CreateBabyService();
            var model = svc.GetBabyById(id);

            return View(model);
        }

        // POST : Delete Baby Data
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBaby(int id)
        {
            var service = CreateBabyService();

            service.DeleteBaby(id);

            TempData["SaveResult"] = "You've deleted the selected baby.";

            return RedirectToAction("Index");

        }

        private BabyService CreateBabyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BabyService(userId);
            return service;
        }
    }
}