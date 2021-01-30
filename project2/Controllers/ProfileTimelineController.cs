using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using project2.Models;

namespace project2.Controllers
{
    public class ProfileTimelineController : Controller
    {
        socialnetworkEntities5 db = new socialnetworkEntities5();
        // GET: ProfilePage
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

            var ProfileIntro = (from u in db.users
                                join h in db.hobbies on u.id equals h.user_id
                                join e in db.educations on u.id equals e.user_id
                                where u.id == uid
                                select new PI
                                {
                                    user_bio = u.user_bio,
                                    user_email = u.user_email,
                                    user_gender = u.user_gender,
                                    user_website = u.user_website,
                                    hobbies = h.hobbies,
                                    favorite_tv_shows = h.favorite_tv_shows,
                                    college_name = e.college_name,
                                    secondary_school = e.secondary_school
                                }).FirstOrDefault();
            var cuser = (from u in db.users where u.id == uid select u).FirstOrDefault();
            //ProfileIntro.friends = new List<friend>();
            if (db.friends.Where(f => f.user_id == uid).Any())
            {
                ProfileIntro.friends = db.friends.Where(f => f.user_id == uid).Take(14).ToList();

                ProfileIntro.friendsCount = db.friends.Where(f => f.user_id == uid).Count();
            }

            if (db.posts.Where(p => p.user_id == uid && p.post_type == 1).Any())
            {
                ProfileIntro.posts = db.posts.Where(p => p.user_id == uid && p.post_type == 1).Take(9).ToList();
            }
            if (db.posts.Where(p => p.user_id == uid && p.post_type == 2).Any())
            {
                ProfileIntro.videos = db.posts.Where(p => p.user_id == uid && p.post_type == 2).Take(3).ToList();
            }
            var postuser = db.friends.Where(f => f.user_id == uid || f.user_friend_id == uid).Count();

            //    var posts = db.posts.Where(p => db.friends.Select(f => f.user_id).ToList().Contains(p.user_id).Select(p => p));

            var post = db.posts.Where(p => p.user_id == uid && (p.post_type == 2 || p.post_type == 1 || p.post_type == 0)).OrderByDescending(s => s.create_date).Take(5).ToList();

            List<user> firndlist = new List<user>();
            foreach (friend fr in ProfileIntro.friends)
            {
                user u = db.users.Where(us => us.id == fr.user_friend_id).FirstOrDefault();
                firndlist.Add(u);
            }

            ViewBag.ProfileIntrobg = ProfileIntro;
            ViewBag.Profilepostuserbg = postuser;
            ViewBag.Profilepostbg = post;
            ViewBag.Frindlist = firndlist;
            ViewBag.friendsCount = ProfileIntro.friendsCount;
            Session["count"] = ProfileIntro.friendsCount;
            ViewBag.cuser = cuser;


            return View();
        }


        // GET: ProfilePage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfilePage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfilePage/Create
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

        // GET: ProfilePage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProfilePage/Edit/5
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

        // GET: ProfilePage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProfilePage/Delete/5
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
        [HttpPost]
        public string addfriend(int id)
        {
            try
            {
                int uid = Int32.Parse(Session["userid"].ToString());
                if(!db.friends.Where(fr => fr.user_id == uid && fr.user_friend_id == id).Any()){
                    friend newfr = new friend();
                    newfr.user_friend_id = id;
                    newfr.user_id = uid;
                    newfr.create_date = DateTime.Now;
                    db.friends.Add(newfr);
                    db.SaveChanges();
                    return "Now friends";
                }

                return "alrady friends";
            }
            catch
            {
                return "Error";
            }
        }
    }
}
