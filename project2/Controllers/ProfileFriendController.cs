using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project2.Controllers
{
    public class ProfileFriendController : Controller
    {

        socialnetworkEntities5 db = new socialnetworkEntities5();

        // GET: ProfileFriend
        public ActionResult Index(int? passuserId)
        {
            if (Session["userid"] == null)
            {

                return RedirectToAction("Index", "Login");
            }
            int uid = -1;
            if (passuserId != null)
            {
                uid = Convert.ToInt32(passuserId);
            }
            else
            {
                uid = Int32.Parse(Session["userid"].ToString());
            }

            var cuser = (from u in db.users where u.id == uid select u).FirstOrDefault();
            ViewBag.cuser = cuser;
            //  int uid = Int32.Parse(Session["userid"].ToString());
            var frienduser = db.friends.Where(p => p.user_id == uid).ToList();
            ViewBag.frienduser = frienduser;

            return View();
        }

        // GET: ProfileFriend/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfileFriend/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfileFriend/Create
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

        // GET: ProfileFriend/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfileFriend/Edit/5
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

        // GET: ProfileFriend/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfileFriend/Delete/5
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
