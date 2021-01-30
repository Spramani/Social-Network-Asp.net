using project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project2.Controllers
{
    public class postController : Controller
    {
        socialnetworkEntities5 db = new socialnetworkEntities5();
        // GET: post
        public ActionResult Index()
        {
            if (Session["userid"] == null)
            {

                return RedirectToAction("Index", "Login");
            }
            
            return View();
        }
        public JsonResult ImageUpload(imagemodel model)
        {

            int imageId = 0;

            var file = model.ImageFile;


            if (file != null)
            {

                file.SaveAs(Server.MapPath("/image/Profile/" + file.FileName));
             
                int uid = Int32.Parse(Session["userid"].ToString());
                user img = (from u in db.users where u.id == uid select u).FirstOrDefault();

                img.user_profilephoto = "/image/Profile/" + file.FileName;



                db.SaveChanges();

                imageId = img.id;

            }

            return Json(imageId, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ImageRetrieve(int id)
        {
            int uid = Int32.Parse(Session["userid"].ToString());

            var img = db.users.SingleOrDefault(x => x.id == uid);

            return File(img.user_profilephoto, "uploadimage");

                
        }

        public JsonResult HImageUploads(imagemodel model)
        {

            int imageId = 0;

            var file = model.ImageFile;


            if (file != null)
            {

                file.SaveAs(Server.MapPath("/image/Cover/" + file.FileName));
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

                img.user_coverphoto = "/image/Cover/" + file.FileName;



                db.SaveChanges();

                imageId = img.id;

            }

            return Json(imageId, JsonRequestBehavior.AllowGet);

        }

        public ActionResult HImageRetrieves(int id)
        {
            int uid = Int32.Parse(Session["userid"].ToString());

            var img = db.users.SingleOrDefault(x => x.id == uid);

            return File(img.user_coverphoto, "HuploadedImages");


        }


    

    }

}