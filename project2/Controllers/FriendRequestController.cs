using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project2.Controllers
{
    public class FriendRequestController : Controller
    {
        // GET: FriendRequest
        public ActionResult Index()
        {
            return View();
        }

        // GET: FriendRequest/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FriendRequest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FriendRequest/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FriendRequest/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FriendRequest/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FriendRequest/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FriendRequest/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
