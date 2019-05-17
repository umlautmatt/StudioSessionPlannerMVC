using Microsoft.AspNet.Identity;
using SessionPlanner.Models;
using SessionPlanner.Models.SessionType;
using SessionPlanner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionPlanner.WebMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SessionTypeController : Controller
    {
        // GET: List of SessionType
        public ActionResult Index()
        {
            var service = new SessionTypeService();
            var model = service.GetSessionTypes();

            return View(model);
        }

        // CREATE
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SessionTypeCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new SessionTypeService();
            if(service.CreateSessionType(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Session type could not be added");
            return View(model);
        }


        //Edit by Id
        public ActionResult Edit(int id)
        {
            var service = new SessionTypeService();
            var detail = service.GetSessionTypeByID(id);

            var model = new SessionTypeEdit
            {
                SessionTypeID = detail.SessionTypeID,
                Name = detail.Name,
                PricePerHour = detail.PricePerHour
            };

            var sessionService = new SessionTypeService();
            var sessionTypeList = sessionService.GetSessionTypes();

            ViewBag.SessionTypeID = new SelectList(sessionTypeList, "SessionTypeID", "Name", model.SessionTypeID);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SessionTypeEdit model)
        {
            var sessionService = new SessionTypeService();
            var sessionTypeList = sessionService.GetSessionTypes();

            ViewBag.SessionTypeID = new SelectList(sessionTypeList, "SessionTypeID", "Name", model.SessionTypeID);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new SessionTypeService();

            if (service.EditSessionType(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Session type could not be updated.");
            return View(model);
        }



        //DELETE by ID
        public ActionResult Delete(int id)
        {
            var service = new SessionTypeService();

            var model = service.GetSessionTypeByID(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteSessionType(int id)
        {
            var service = new SessionTypeService();

            if (service.DeleteSessionType(id))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Delete", new { id });
        }




        //GET DETAILS by ID
        public ActionResult Details (int id)
        {
            var service = new SessionTypeService();
            var model = service.GetSessionTypeByID(id);

            return View(model);
        }

    }
}