using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project2.Models;

namespace project2.Controllers
{
    public class NewsFeedController : Controller
    {
        socialnetworkEntities5 db = new socialnetworkEntities5();


        // GET: NewsFeed
        [HttpGet]
        public ActionResult Index(int? id)
        {
            if (Session["userid"] == null)
            {

                return RedirectToAction("Index", "Login");
            }

            int uid = Int32.Parse(Session["userid"].ToString());
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
                                    //user_create_date = DateTime.Parse(u.create_date.ToString()),
                                    user_profilephoto = u.user_profilephoto,
                                    hobbies = h.hobbies,
                                    favorite_tv_shows = h.favorite_tv_shows,
                                    college_name = e.college_name,
                                    secondary_school = e.secondary_school,
                                }).FirstOrDefault();




            ProfileIntro.friendsCount = db.friends.Where(f => f.user_id == uid).Count();
            ProfileIntro.friends = db.friends.Where(f => f.user_id == uid).Take(14).ToList();
          
            List<user> firndlist = new List<user>();
            foreach (friend fr in ProfileIntro.friends)
            {
                user u = db.users.Where(us => us.id == fr.user_friend_id).FirstOrDefault();
                firndlist.Add(u);
            }


            ProfileIntro.posts = db.posts.Where(p => p.user_id == uid && p.post_type == 1).Take(9).OrderByDescending(p => p.create_date).ToList();
            ProfileIntro.videos = db.posts.Where(p => p.user_id == uid && p.post_type == 2).Take(3).OrderByDescending(p => p.create_date).ToList();



            //var post = db.posts.Where(p => db.friends.Select(f => f.user_id).ToList().Contains(p.user_id).Select(p => p));

            List<post> post = db.posts.Where(p => p.user_id == uid && ( p.post_type == 2 || p.post_type == 1 || p.post_type == 0)).ToList().OrderByDescending(s => s.create_date).Take(5).ToList();

            List<postwithComment> pp = new List<postwithComment>();
            foreach (post p in post)
            {
                postwithComment newpostcom = new postwithComment();
                newpostcom.cpost = p;
                newpostcom.cpostComments = db.comments.Where(c => c.post_id == p.id).OrderByDescending(cd => cd.create_date).Take(3).ToList();
                pp.Add(newpostcom);
            }



            ViewBag.ProfileIntrobg = ProfileIntro;
            ViewBag.Profilepostbg = post;
            ViewBag.Frindlist= firndlist;

            ViewBag.friendsCount = ProfileIntro.friendsCount;
            Session["count"] = ProfileIntro.friendsCount;



            return View(pp);
        }

        public ActionResult like(int id)
        {
            post_like update = db.post_like.ToList().Find(s => s.post_id == id);
            post Posts = db.posts.ToList().Find(s => s.id == id);
            int uid = Int32.Parse(Session["userid"].ToString());

            post_like pl = new post_like();
            //   pl.post_id = update;
            pl.user_id = uid;
            pl.create_date = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public string btnclick(int id, comment cms)
        {
            try
            {
                comment cm = db.comments.Where(p => p.id == id).FirstOrDefault();
                cm.post_id = id;
                cm.user_id = id;
                cm.comment_text = cms.comment_text;
                cm.create_date = DateTime.Now;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return "done";
        }

        [HttpGet]
        public string addLike(int id)
        {
            try
            {
                post psl = db.posts.Where(p => p.id == id).FirstOrDefault();
                psl.post_like += 1;
                db.SaveChanges();

                return "done";
            }
            catch (Exception)
            {

                return "Error in";
            }

        }
        [HttpGet]
        public string addComment(int id, string ctext)
        {
            try
            {
                post psl = db.posts.Where(p => p.id == id).FirstOrDefault();
                comment cm = new comment();
                cm.post_id = id;
                cm.user_id = Int32.Parse(Session["userid"].ToString());
                cm.comment_text = ctext;
                cm.create_date = DateTime.Now;
                db.comments.Add(cm);
                db.SaveChanges();

                return ctext;
            }
            catch (Exception ex)
            {

                return "Error in";
            }

        }

        public string search_porduct(string s_text)
        {
            var porlist = (from p in db.users where p.user_name_id.Contains(s_text) select p).ToList();

            ViewBag.search_r = porlist;

            string sJSONResponse = JsonConvert.SerializeObject(porlist);

            return sJSONResponse;
        }

        public ActionResult PhotoUPload(HttpPostedFileBase file, FormCollection collection)
        {
            if (file != null)
            {
                var PhotoDescription = collection["PhotoDescription"];


                Random r = new Random();
                string newname = "IMG" + r.Next();

                string ex = System.IO.Path.GetExtension(file.FileName);
                newname = newname + ex;
                string path = System.IO.Path.Combine(Server.MapPath("~/image/postimage/"), newname);

                int uid = Int32.Parse(Session["userid"].ToString());

                post p = new post();
                p.user_id = uid;
                p.post_type = 1;
                p.description = PhotoDescription;
                p.post_like = 0;
                p.media_path = "/image/postimage/" + newname;
                p.create_date = DateTime.Now;
                db.posts.Add(p);
                db.SaveChanges();

                file.SaveAs(path);


            }
            return RedirectToAction("Index", "NewsFeed");

        }


        public ActionResult TextPost(FormCollection collection, post posts)
        {


            var Tdescription = collection["Description"];

            int uid = Int32.Parse(Session["userid"].ToString());
            if (Tdescription != null || Tdescription != "" || Tdescription == "")
            {


                post p = new post();
                p.user_id = uid;
                p.post_type = 0;
                p.description = Tdescription;
                p.post_like = 0;
                p.create_date = DateTime.Now;
                db.posts.Add(p);
                db.SaveChanges();

                post_likes likes = new post_likes();
                likes.post_id = p.id;
                likes.post_like = 0;
                //   likes.post_date = DateTime.Now;
                db.post_likes.Add(likes);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "NewsFeed");

        }

        [HttpPost]
        public ActionResult VideoUpload(HttpPostedFileBase VideoFile, FormCollection collection)
        {
            var description = collection["VideoDescription"];

            int uid = Int32.Parse(Session["userid"].ToString());


            if (VideoFile != null)
            {
                string filename = Path.GetFileName(VideoFile.FileName);
                if (VideoFile.ContentLength < 104857600)
                {
                    VideoFile.SaveAs(Server.MapPath("/image/postvideo/" + filename));


                    post pots = new post();
                    pots.user_id = uid;
                    pots.post_type = 2;
                    pots.description = description;
                    pots.post_like = 0;
                    pots.media_path = "/image/postvideo/" + filename;
                    pots.create_date = DateTime.Now;
                    db.posts.Add(pots);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");




        }

    }
}
