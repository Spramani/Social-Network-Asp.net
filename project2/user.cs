//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace project2
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public int id { get; set; }
        public string user_name { get; set; }
        public string user_name_id { get; set; }
        public string user_email { get; set; }
        public string user_password { get; set; }
        public string user_gender { get; set; }
        public string user_contect { get; set; }
        public string user_website { get; set; }
        public string user_dateofbirth { get; set; }
        public string user_coverphoto { get; set; }
        public string user_profilephoto { get; set; }
        public string user_bio { get; set; }
        public string user_birthplace { get; set; }
        public string user_livesin { get; set; }
        public string user_occupation { get; set; }
        public string user_is_private { get; set; }
        public string user_status { get; set; }
        public string user_merriage_status { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }

        public string user_Conpassword { get; set; }
        public string CompairPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
    }
    public enum Status
    {
        Single,
        Merried,
        Living

    }
    public enum Gender
    {
        Male,
        Female
    }

}
