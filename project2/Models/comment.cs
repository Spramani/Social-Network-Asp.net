using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project2.Models
{
    public class comment_shubh
    {
        public string commenttext { get; set; }

    }
    public class postwithComment
    {
        public postwithComment()
        {
            cpostComments = new List<comment>();
        }
        public post cpost { get; set; }
        public List<comment> cpostComments { get; set; }

    }
    public class passPost
    {
        public passPost()
        {
            postlist = new List<postwithComment>();
        }
       
        public List<postwithComment> postlist { get; set; }

    }
}