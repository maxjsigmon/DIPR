using DIPR.Data;
using DIPR.Models;
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
        //private ApplicationDbContext _babyDb = new ApplicationDbContext();

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BabyCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateBabyService();

            if (service.CreateBaby(model))
            {
                TempData["SaveResult"] = "You baby has been added!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Your baby could not be added. Please, try again.");

            return View(model);

        }

        public ActionResult Details(int id)
        {
            var svc = CreateBabyService();
            var model = svc.GetBabyById(id);

            return View(model);
        }

        

        public ActionResult Delete(int id)
        {
            var svc = CreateBabyService();
            var model = svc.GetBabyById(id);

            return View(model);
        }

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