﻿using DIPR.Models.Diaper;
using DIPR.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIPR.WebMVC.Controllers
{
    public class DiaperController : Controller
    {
        // GET: Diaper
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new DiaperService(userID);
            var model = service.GetDiaper();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DiaperCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateDiaperService();

            if (service.CreateDiaper(model))
            {
                TempData["SaveResult"] = "Your baby's diaper has been added!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your baby's diaper could not be added. Please, try again.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateDiaperService();
            var model = svc.GetDiaperById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateDiaperService();
            var detail = service.GetDiaperById(id);
            var model =
                new DiaperEdit
                {
                    DiaperID = detail.DiaperID,
                    Time = detail.Time
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DiaperEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DiaperID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateDiaperService();

            if (service.UpdateDiaper(model))
            {
                TempData["SaveResult"] = "The diaper was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The diaper could not be updated.");
            return View();
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateDiaperService();
            var model = svc.GetDiaperById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDiaper(int id)
        {
            var service = CreateDiaperService();

            service.DeleteDiaper(id);

            TempData["SaveResult"] = "You've deleted the selected diaper.";

            return RedirectToAction("Index");
        }

        private DiaperService CreateDiaperService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DiaperService(userId);
            return service;
        }
    }
}