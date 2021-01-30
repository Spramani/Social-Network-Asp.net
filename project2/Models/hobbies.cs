using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project2.Models
{
    public class hobbies
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string Hobbies { get; set; }
        public string favorite_tv_shows { get; set; }
        public string favorite_movies { get; set; }
        public string favorite_games { get; set; }
        public string favorite_books { get; set; }
        public string favorite_writers { get; set; }
        public string other_interest { get; set; }
    }
}