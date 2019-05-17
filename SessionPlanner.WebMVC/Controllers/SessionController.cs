using Microsoft.AspNet.Identity;
using SessionPlanner.Models;
using SessionPlanner.Models.Session;
using SessionPlanner.Services;
using System;
using System.Web.Mvc;

namespace SessionPlanner.WebMVC.Controllers
{
    [Authorize]
    public class SessionController : Controller
    {

        // GET: List of Sessions
        public ActionResult Index()
        {
            var service = GetSessionService();
            var model=service.GetSessions();

            return View(model);
        }

        // CREATE
        public ActionResult Create()
        {
            var sessionTypeService = new SessionTypeService();
            var sessionTypeList = sessionTypeService.GetSessionTypes();

            ViewBag.SessionTypeID = new SelectList(sessionTypeList, "SessionTypeID", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SessionCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = GetSessionService();

            if (service.CreateSession(model))
            {
                return RedirectToAction("Index", "Session");
            }

            var sessionService = new SessionTypeService();
            var sessionTypeList = sessionService.GetSessionTypes();

            ViewBag.SessionTypeID = new SelectList(sessionTypeList, "SessionTypeID", "Name");

            return View(model);
        }


        //EDIT
        public ActionResult Edit(int id)
        {
            var service = GetSessionService();
            var detail = service.GetSessionByID(id);
            var model = new SessionEdit
            {
                SessionID = detail.SessionID,
                SessionTypeID = detail.SessionTypeID,
                StartTime = detail.StartTime,
                EndTime = detail.EndTime,
                Extras = detail.Extras
            };

            var sessionService = new SessionTypeService();
            var sessionTypeList = sessionService.GetSessionTypes();

            ViewBag.SessionTypeID = new SelectList(sessionTypeList, "SessionTypeID", "Name", model.SessionTypeID);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SessionEdit model)
        {
            var sessionService = new SessionTypeService();
            var sessionTypeList = sessionService.GetSessionTypes();

            ViewBag.SessionTypeID = new SelectList(sessionTypeList, "SessionTypeID", "Name", model.SessionTypeID);

            if (!ModelState.IsValid) return View(model);

            //if(model.SessionID != id)
            //{
            //    ModelState.AddModelError("", "Id Mismatch");
            //    return View(model);
            //}

            var service = GetSessionService();

            if (service.EditSession(model))
            {
                TempData["Save Result"] = "Your session was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your session could not be updated.");
            return View(model);
        }


        // DELETE
        public ActionResult Delete(int id)
        {
            var service = GetSessionService();
            var model = service.GetSessionByID(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteSession(int id)
        {
            var service = GetSessionService();

            if (service.DeleteSession(id))
                return RedirectToAction("Index", "Session");

            ModelState.AddModelError("", "Could not delete Rating");

            return RedirectToAction("Delete", new { id });
        }


        //GET by SessionID
        public ActionResult Details(int id)
        {
            var service = GetSessionService();
            var model = service.GetSessionByID(id);
            return View(model);
        }


        private SessionService GetSessionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SessionService(userId);
            return service;
        }
    }
}