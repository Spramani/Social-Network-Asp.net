using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using project2.Models;

namespace project2.Controllers
{
    public class ForgetPasswordController : Controller
    {
        socialnetworkEntities5 db = new socialnetworkEntities5();

        // GET: ForgetPassword
        public ActionResult Index()
        {

            
            return View();
        }


        // GET: ForgetPassword/
        public ActionResult ForgetUser(registration rgs)
        {

        
            var usname = (from p in db.users where p.user_name_id == rgs.user_name_id select p).FirstOrDefault();

            if (usname == null)
            {
                return RedirectToAction("Index" , "Login");
            }
            else
            {
                Session["user_email"] = usname.user_email;
                Session["user_name"] = usname.user_name;
                Session["user_name_id"] = usname.user_name_id;
                Session["user_profilephoto"] = usname.user_profilephoto;

                ViewBag.user_emails = usname.user_email;
                return RedirectToAction("Index", "EmailSend");
            }

            
        }



    }
}
