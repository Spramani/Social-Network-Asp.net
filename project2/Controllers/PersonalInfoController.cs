using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project2.Controllers
{
    public class PersonalInfoController : Controller
    {
        socialnetworkEntities5 db = new socialnetworkEntities5();

        // GET: PersonalInfo
        public ActionResult Index()
        {
            if (Session["userid"] == null)
            {

                return RedirectToAction("Index", "Login");
            }
            int uid = Int32.Parse(Session["userid"].ToString());
            var userdata = (from u in db.users where u.id == uid select u).FirstOrDefault();
            ViewBag.edituserdata = userdata;


            return View(userdata);
        }

        // GET: PersonalInfo/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: PersonalInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonalInfo/Create
        [HttpPost]
        public ActionResult Create(user uses)
        {
            try
            {

                int uid = Int32.Parse(Session["userid"].ToString());
                user us = (from u in db.users where u.id == uid select u).FirstOrDefault();
                us.user_name = uses.user_name;
                us.user_bio = uses.user_bio;
                us.user_dateofbirth = uses.user_dateofbirth;
                us.user_occupation = uses.user_occupation;
                us.user_status = uses.user_status;
                us.user_name_id = uses.user_name_id;
                us.user_email = uses.user_email;
                us.user_contect = uses.user_contect;
                us.user_birthplace = uses.user_birthplace;
                us.user_livesin = uses.user_livesin;
                us.user_website = uses.user_website;

                
                //db.users.Add(us);
                db.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");

            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: PersonalInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonalInfo/Edit/5
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

        // GET: PersonalInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonalInfo/Delete/5
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
