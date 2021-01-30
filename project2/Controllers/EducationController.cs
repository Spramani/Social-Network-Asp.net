using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project2.Controllers
{
    public class EducationController : Controller
    {
        socialnetworkEntities5 db = new socialnetworkEntities5();

        // GET: Education
        public ActionResult Index()
        {
            if (Session["userid"] == null)
            {

                return RedirectToAction("Index", "Login");
            }
            int uid = Int32.Parse(Session["userid"].ToString());
            var educationdata = (from e in db.educations where e.id == uid select e).FirstOrDefault();
            ViewBag.editeducationdata = educationdata;


            return View(educationdata);
        }

        // GET: Education/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Education/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Education/Create
        [HttpPost]
        public ActionResult Create(education edus)
        {
            try
            {
                
                    education edu = new education();
                    edu.user_id = Int32.Parse(Session["userid"].ToString());
                    edu.college_name = edus.college_name;
                    edu.college_join_date = edus.college_join_date;
                    edu.address_of_college = edus.address_of_college;
                    edu.secondary_school = edus.secondary_school;
                    edu.school_join_date = edus.school_join_date;
                    edu.address_of_school = edus.address_of_school;

                    edu.create_date = DateTime.Now;

                    db.educations.Add(edu);
                    db.SaveChanges();
                    // TODO: Add insert logic here

                    return RedirectToAction("Index", "Education");
               
            }

            catch
            {
                return View();
            }

        }
        // POST: Education/Create
        [HttpPost]
        public ActionResult Edit(education edus)
        {
            try
            {
                int uid = Int32.Parse(Session["userid"].ToString());
                education edu = (from e in db.educations where e.id == uid select e).FirstOrDefault();
                edu.user_id = Int32.Parse(Session["userid"].ToString());
                edu.college_name = edus.college_name;
                edu.college_join_date = edus.college_join_date;
                edu.address_of_college = edus.address_of_college;
                edu.secondary_school = edus.secondary_school;
                edu.school_join_date = edus.school_join_date;
                edu.address_of_school = edus.address_of_school;

               
                 db.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");

            }

            catch
            {
                return View();
            }

        }

    }


}

