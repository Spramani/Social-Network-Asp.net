using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project2.Models
{
    public class PI
    {
        public PI()
        {
            friends = new List<friend>();
            posts = new List<post>();
            videos = new List<post>();
        }
        public string user_profilephoto { get; set; }

        public String user_bio { get; set; }
        public String user_email { get; set; }
        public String user_gender { get; set; }
        public String user_website { get; set; }
        public String hobbies { get; set; }
        public String favorite_tv_shows { get; set; }
        public String college_name { get; set; }
        public String secondary_school { get; set; }
        public string description { get; set; }

        public DateTime user_create_date { get; set; }

        public List<friend> friends { get; set; }
        public List<post> posts { get; set; }
        public List<post> videos { get; set; }

        public int friendsCount { get; set; }
    }
    
}