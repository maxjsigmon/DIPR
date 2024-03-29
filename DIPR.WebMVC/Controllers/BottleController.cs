﻿using DIPR.Models.Bottle;
using DIPR.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
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
            var babyService = CreateBabyService();
            var babies = babyService.GetBaby()
              .Select(x => new
              {
                  Text = x.Name,
                  Value = x.BabyID
              });

            var model = new BottleCreate()
            {
                Babies = new SelectList(babies, "Value", "Text")
            };

            return View(model);
        }

        // POST : Create Bottle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BottleCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBottleService();
            var babyService = CreateBabyService();
            var babies = babyService.GetBaby()
                .Select(x => new
                {
                    Text = x.Name,
                    Value = x.BabyID
                });

            if (service.CreateBottle(model))
            {
                TempData["SaveResult"] = "Your baby's bottle has been added!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your baby's bottle could not be added. Please, try again.");

            return View(model);
        }

        // GET : Bottle Details by ID
        public ActionResult Details(int id)
        {
            var svc = CreateBottleService();
            var model = svc.GetBottleById(id);

            return View(model);
        }

        // GET : Bottle Details by ID
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
                    BabyID = detail.BabyID,
                    BottleID = detail.BottleID,
                    Time = detail.Time,
                    Contents = detail.Contents,
                    Quantity = detail.Quantity,
                    Consumed = detail.Consumed,
                    Notes = detail.Notes,
                    Babies = new SelectList(babies, "Value", "Text")

                };
            return View(model);
        }

        // Post : Edit Bottle Data
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

        // GET : Bottle by ID
        public ActionResult Delete(int id)
        {
            var svc = CreateBottleService();
            var model = svc.GetBottleById(id);

            return View(model);
        }

        // POST : Delete Bottle
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