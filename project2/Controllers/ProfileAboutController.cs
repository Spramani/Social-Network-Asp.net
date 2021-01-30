using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project2.Models;

namespace project2.Controllers
{
    public class ProfileAboutController : Controller
    {
        socialnetworkEntities5 db = new socialnetworkEntities5();
        // GET: AboutProfile
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
            var Hobbiesdata = (from h in db.hobbies where h.user_id == uid select h).FirstOrDefault();
            ViewBag.edithobbiesdata = Hobbiesdata;

            var educationdata = (from e in db.educations where e.user_id == uid select e).FirstOrDefault();
            ViewBag.editeducationdata = educationdata;

            var persoanldata = (from u in db.users where u.id == uid select u).FirstOrDefault();
            ViewBag.edituserdata = persoanldata;

            var cuser = (from u in db.users where u.id == uid select u).FirstOrDefault();
            ViewBag.cuser = cuser;


            return View();
        }

        // GET: userProfilePhoto


        public JsonResult ImageUpload(imagemodel model)
        {

            int imageId = 0;

            var file = model.ImageFile;


            if (file != null)
            {

                file.SaveAs(Server.MapPath("/image/" + file.FileName));
                /*
                                int uid = Int32.Parse(Session["userid"].ToString());
                                post img = (from p in db.posts where p.id == uid select p).FirstOrDefault();

                                img.user_id = uid;
                                img.description = file.FileName;
                                img.media_path = "/image/" + file.FileName;
                                img.create_date = DateTime.Now;
                                */
                int uid = Int32.Parse(Session["userid"].ToString());
                user img = (from u in db.users where u.id == uid select u).FirstOrDefault();

                img.user_coverphoto = file.FileName;



                db.SaveChanges();

                imageId = img.id;

            }

            return Json(imageId, JsonRequestBehavior.AllowGet);

        }



    }
}
