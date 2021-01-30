using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project2.Models;

namespace project2.Controllers
{
    public class HobbiesController : Controller
    {
        socialnetworkEntities5 db = new socialnetworkEntities5();
        // GET: Hobbies
        public ActionResult Index()
        {
            if (Session["userid"] == null)
            {

                return RedirectToAction("Index", "Login");
            }
            int uid = Int32.Parse(Session["userid"].ToString());
            var Hobbiesdata = (from h in db.hobbies where h.id == uid select h).FirstOrDefault();
            ViewBag.edithobbiesdata = Hobbiesdata;
       
            return View(Hobbiesdata);
        

        }

        // GET: Hobbies/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Hobbies/Create

        // POST: Hobbies/Create
        [HttpPost]
        public ActionResult Create(hobbies hs)
        {
            try
            {


                hobby hss = new hobby();
                hss.user_id = Int32.Parse(Session["userid"].ToString());
                hss.hobbies = hs.Hobbies;
                hss.favorite_tv_shows = hs.favorite_tv_shows;
                hss.favorite_movies = hs.favorite_movies;
                hss.favorite_games = hs.favorite_games;
                hss.favorite_books = hs.favorite_books;
                hss.favorite_writers = hs.favorite_writers;
                hss.other_interest = hs.other_interest;

                hss.create_date = DateTime.Now;

                db.hobbies.Add(hss);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Hobbies/Create
        [HttpPost]
        public ActionResult Edit(hobbies hs)
        {
            try
            {


                int uid = Int32.Parse(Session["userid"].ToString());
                hobby hb = (from e in db.hobbies where e.id == uid select e).FirstOrDefault();
                hb.user_id = Int32.Parse(Session["userid"].ToString());
                hb.hobbies = hs.Hobbies;
                hb.favorite_tv_shows = hs.favorite_tv_shows;
                hb.favorite_movies = hs.favorite_movies;
                hb.favorite_games = hs.favorite_games;
                hb.favorite_books = hs.favorite_books;
                hb.favorite_writers = hs.favorite_writers;
                hb.other_interest = hs.other_interest;

           
                db.SaveChanges();
                return RedirectToAction("Index");

             }
            catch
            {
                return RedirectToAction("Index");
            }
        }

    }

}
