using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project2.Models;


namespace project2.Controllers
{
    public class LoginController : Controller
    {
        socialnetworkEntities5 db = new socialnetworkEntities5();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }



        //login
        public ActionResult loginform(FormCollection collection)
        {

            var user_name_id = collection["user_name_id"];
            var user_password = collection["user_password"];
            var user_email  = collection["user_email"];
            try
            {

                //       var result = db.users.Where(x => x.user_name_id.Equals(user_name_id) && x.user_password.Equals(user_password)).ToList();

                var userdt = (from f in db.users where  f.user_name_id == user_name_id && f.user_password == user_password select f).FirstOrDefault();

                if (userdt != null)    
                {

                    Session["userid"] = userdt.id;
                    Session["username_id"] = userdt.user_name_id;
                    Session["user"] = userdt;
                    Session["UserName"] = userdt.user_name;
                    Session["profilephoto"] = userdt.user_profilephoto;


                    return RedirectToAction("Index", "NewsFeed");


                }
                else
                {
                    ViewBag.Message = "UserName or Password incorect";
                    return View("Index");
                }
            }
            catch (Exception)
            {

                return RedirectToAction("Index","Login");

            }

        }

        // GET: Login/Create


        // POST: Login/Create
        [HttpPost]

        public ActionResult Create(registration rgs, education edus, hobby hs)
        {
            try
            {
                if (rgs.user_name != null && rgs.user_name_id != null && rgs.user_email != null && rgs.user_password != null && rgs.user_gender != null && rgs.user_password == rgs.user_Conpassword)
                {


                    user cname = new user();
              //      var usname = db.users.Where(p => p.user_name_id == rgs.user_name_id select p).ToString();
                    var usname = (from p in db.users where p.user_name_id == rgs.user_name_id select p).FirstOrDefault();

                    if (usname == null)
                    {
                        // TODO: Add insert logic here                        

                        user regu = new user();
                        regu.user_name = rgs.user_name;
                        regu.user_name_id = rgs.user_name_id;
                        regu.user_email = rgs.user_email;
                        regu.user_password = rgs.user_password;
                        regu.user_gender = rgs.user_gender;
                        regu.user_contect = " ";
                        regu.user_website = " ";
                        regu.user_dateofbirth = " ";
                        regu.user_coverphoto = "/image/Cover/default.png";
                        regu.user_profilephoto = "/image/Profile/profile.png";
                        regu.user_bio = " ";
                        regu.user_birthplace = " ";
                        regu.user_livesin = " ";
                        regu.user_occupation = " ";
                        regu.user_is_private = " ";
                        regu.user_status = " ";
                        regu.user_merriage_status = " ";

                        regu.create_date = DateTime.Now;

                        db.users.Add(regu);
                        db.SaveChanges();


                        education edu = new education();
                        edu.user_id = regu.id;
                        edu.college_name = " ";
                        edu.college_join_date = " ";
                        edu.address_of_college = " ";
                        edu.secondary_school = " ";
                        edu.school_join_date = " ";
                        edu.address_of_school = " ";
                        edu.create_date = DateTime.Now;

                        db.educations.Add(edu);

                        db.SaveChanges();


                        hobby hob = new hobby();
                        hob.user_id = regu.id;
                        hob.hobbies = " ";
                        hob.favorite_tv_shows = " ";
                        hob.favorite_movies = " ";
                        hob.favorite_games = " ";
                        hob.favorite_books = " ";
                        hob.favorite_writers = " ";
                        hob.other_interest = " ";
                        hob.create_date = DateTime.Now;
                        db.hobbies.Add(hob);
                        db.SaveChanges();



                    }
                    else
                    {

                        ViewBag.registration = "enter your all field details";

                        return View("Index");

                    }

                }
                else
                {
                    ViewBag.registration = "enter your all field details";

                    return View("Index");
                   }
                return RedirectToAction("Index");

            }
            catch
            {
                return RedirectToAction("Index");
            }
        }


        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
