using DIPR.Models.Nursing;
using DIPR.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIPR.WebMVC.Controllers
{
    public class NursingController : Controller
    {
        // GET: Nursing
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new NursingService(userID);
            var model = service.GetNursingData();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST : Create Nursing Data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NursingCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateNursingService();

            if (service.CreateNursingData(model))
            {
                TempData["SaveResult"] = "Your baby's nursing data has been added!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your baby's nursing data could not be added. Please, try again.");

            return View(model);
        }

        // GET : Nursing Data by ID
        public ActionResult Details(int id)
        {
            var svc = CreateNursingService();
            var model = svc.GetNursingDataById(id);

            return View(model);
        }

        // GET : Nursing Data
        public ActionResult Edit(int id)
        {
            var service = CreateNursingService();
            var babyService = CreateBabyService();
            var detail = service.GetNursingDataById(id);
            var babies = babyService.GetBaby()
               .Select(x => new
               {
                   Text = x.Name,
                   Value = x.BabyID
               });
            var model =
                new NursingEdit
                {
                    NursingID = detail.NursingID,
                    Time = detail.Time,
                    TimeFed = detail.TimeFed,
                    Name = detail.Name,
                    FeedingSide = detail.FeedingSide,
                    Notes = detail.Notes,
                    Babies = new SelectList(babies, "Value", "Text"),
                    BabyID = detail.BabyID
                };
            return View(model);
        }

        // POST : Edit Nursing Data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, NursingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.NursingID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }
            var service = CreateNursingService();

            if (service.UpdateNursingData(model))
            {
                TempData["SaveResult"] = "The nursing data was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The nursing data could not be updated.");
            return View();
        }

        // GET : Nursing Data
        public ActionResult Delete(int id)
        {
            var svc = CreateNursingService();
            var model = svc.GetNursingDataById(id);

            return View(model);
        }

        // GET : Delete Nursing Data
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteNursingData(int id)
        {
            var service = CreateNursingService();

            service.DeleteNursingData(id);

            TempData["SaveResult"] = "You've deleted the selected nursing data.";

            return RedirectToAction("Index");
        }

        private NursingService CreateNursingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NursingService(userId);
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