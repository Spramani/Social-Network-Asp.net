using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project2.Controllers
{
    public class ChangePasswordController : Controller
    {
        socialnetworkEntities5 db = new socialnetworkEntities5();
        // GET: ChangePassword
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


        public ActionResult changepass(user rgs)
        {
            user useds = new user();


            var usname = (from p in db.users where p.user_password == rgs.CompairPassword select p).FirstOrDefault();
            if (usname != null)
            {
                if (rgs.NewPassword == rgs.ConfirmNewPassword)
                {
                    int uid = Int32.Parse(Session["userid"].ToString());
                    user us = (from e in db.users where e.id == uid select e).FirstOrDefault(); ;
                    us.id = Int32.Parse(Session["userid"].ToString());

                    us.user_password = rgs.NewPassword;

                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    ViewBag.compMessage = "password or Conformpassword are mismatch";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.cpMessage = "not match your current password";
                return View("Index");

            }
             return View("Index");
        }




    }


}

