﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project2.Models;

namespace project2.Controllers
{
    public class ProfilePhotoController : Controller
    {
        socialnetworkEntities5 db = new socialnetworkEntities5();
        // GET: ProfilePhoto
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
           // int uid = Int32.Parse(Session["userid"].ToString());

           var Photos = db.posts.Where(p => p.user_id == uid && p.post_type == 1).OrderByDescending(s => s.create_date).ToList();
            ViewBag.ProfileIntrobgs = Photos;

            var cuser = (from u in db.users where u.id == uid select u).FirstOrDefault();
            ViewBag.cuser = cuser;

            return View();
        }

    }
}