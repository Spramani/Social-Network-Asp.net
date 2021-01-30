using project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace project2.Controllers
{
    public class EmailSendController : Controller
    {
        socialnetworkEntities5 db = new socialnetworkEntities5();
        // GET: EmailSend
        public ActionResult Index()
        {
          
            var sessionimage = Session["user_profilephoto"];
            ViewBag.images = sessionimage;
            return View();
        }


        [HttpPost]
        public ActionResult Email(user model)
        {
            using (var context = new socialnetworkEntities5())
            {
                String mail = model.user_email;
                var uname = (string)Session["user_name_id"]; 
                var name = (string)Session["user_email"];

                if (name == mail)
                {

                    String pass = context.users.Where(x => x.user_email.Equals(model.user_email)).Select(x => x.user_password).FirstOrDefault();
                    ViewBag.msg = "We Send Your Register Password in your Registered Email Address";

                    var fromMail = new MailAddress("shubhamramani444@gmail.com", "Social Gram"); // set your email  
                    var fromEmailpassword = "ramani444"; // Set your password   
                        var toEmail = new MailAddress(mail);

                    var smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(fromMail.Address, fromEmailpassword);

                    var Message = new MailMessage(fromMail, toEmail);
                    Message.Subject = "Password Forgot Request";
                    Message.Body = "<html><head><title></title><meta http-equiv='Content-Type' content='text/html; charset=utf-8'/><meta name='viewport' content='width=device-width, initial-scale=1'><meta http-equiv='X-UA-Compatible' content='IE=edge'/><style type='text/css'>/* FONTS */ @media screen{@font-face{font-family: 'Lato'; font-style: normal; font-weight: 400; src: local('Lato Regular'), local('Lato-Regular'), url(https://fonts.gstatic.com/s/lato/v11/qIIYRU-oROkIk8vfvxw6QvesZW2xOQ-xsNqO47m55DA.woff) format('woff');}@font-face{font-family: 'Lato'; font-style: normal; font-weight: 700; src: local('Lato Bold'), local('Lato-Bold'), url(https://fonts.gstatic.com/s/lato/v11/qdgUG4U09HnJwhYI-uK18wLUuEpTyoUstqEm5AMlJo4.woff) format('woff');}@font-face{font-family: 'Lato'; font-style: italic; font-weight: 400; src: local('Lato Italic'), local('Lato-Italic'), url(https://fonts.gstatic.com/s/lato/v11/RYyZNoeFgb0l7W3Vu1aSWOvvDin1pK8aKteLpeZ5c0A.woff) format('woff');}@font-face{font-family: 'Lato'; font-style: italic; font-weight: 700; src: local('Lato Bold Italic'), local('Lato-BoldItalic'), url(https://fonts.gstatic.com/s/lato/v11/HkF_qI1x_noxlxhrhMQYELO3LdcAZYWl9Si6vvxL-qU.woff) format('woff');}}/* CLIENT-SPECIFIC STYLES */ body, table, td, a{-webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%;}table, td{mso-table-lspace: 0pt; mso-table-rspace: 0pt;}img{-ms-interpolation-mode: bicubic;}/* RESET STYLES */ img{border: 0; height: auto; line-height: 100%; outline: none; text-decoration: none;}table{border-collapse: collapse !important;}body{height: 100% !important; margin: 0 !important; padding: 0 !important; width: 100% !important;}/* iOS BLUE LINKS */ a[x-apple-data-detectors]{color: inherit !important; text-decoration: none !impomportant;}/* ANDROID CENTER FIX */ div[style*='margin: 16px 0;']{margin: 0 !important;}</style></head><body style='background-color: #ff572; margin: 0 !important; padding: 0 !important;'><div style='display: none; font-size: 1px; color: #fefefe; line-height: 1px; font-family: 'Lato', Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;'></div><table border='0' cellpadding='0' cellspacing='0' width='100%'> <tr> <td bgcolor='#7c72dc' align='center'> <table border='0' cellpadding='0' cellspacing='0' width='480' > <tr> <td align='center' valign='top' style='padding: 40px 10px 40px 10px;'> <a href='#' target='_blank'> <img alt='    icon - fly' src='https://i.ibb.co/RvcYVZr/icon-fly.png' width='150' height='150' style='display: block; font-family: 'Lato', Helvetica, Arial, sans-serif; color: #ffffff; font-size: 18px;' border='0'> </a> </td></tr></table> </td></tr><tr> <td bgcolor='#7c72dc' align='center' style='padding: 0px 10px 0px 10px;'> <table border='0' cellpadding='0' cellspacing='0' width='480' > <tr> <td bgcolor='#ffffff' align='center' valign='top' style='padding: 40px 20px 20px 20px; border-radius: 4px 4px 0px 0px; color: #111111; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 48px; font-weight: 400; letter-spacing: 4px; line-height: 48px;'> <h1 style='font-size: 32px; font-weight: 400; margin: 0;'>Welcome to Social Gram</h1> </td></tr></table> </td></tr><tr> <td bgcolor='#ff572' align='center' style='padding: 0px 10px 0px 10px;'> <table border='0' cellpadding='0' cellspacing='0' width='480' > <tr> <td bgcolor='#ffffff' align='left' style='padding: 20px 30px 40px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;' > <p style='margin: 0;padding-left: 30px; border:3' >Email :- " + mail + " </p><p style='margin: 0;padding-left: 30px'>Your User Name:- " + uname + "</p><p style='margin: 0;padding-left: 30px'>Your current Password :- " + pass + "</p><p style='margin: 0;padding-left: 30px'>Its Your Personal details don`t share any one</p></td></tr><tr> <td bgcolor='#ffffff' align='left'> <table width='100%' border='0' cellspacing='0' cellpadding='0'> <tr> <td bgcolor='#ffffff' align='center' style='padding: 20px 30px 60px 30px;'> <table border='0' cellspacing='0' cellpadding='0'> <tr> <td align='center' style='border-radius: 3px;' bgcolor='#7c72dc'></td></tr></table> </td></tr></table> </td></tr></table> </td></tr><tr> <td bgcolor='#ff572' align='center' style='padding: 30px 10px 0px 10px;'> <table border='0' cellpadding='0' cellspacing='0' width='480' > <tr> <td bgcolor='#C6C2ED' align='center' style='padding: 30px 30px 30px 30px; border-radius: 4px 4px 4px 4px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;' > <h2 style='font-size: 20px; font-weight: 400; color: #111111; margin: 0;'>Need more help?</h2> <p style='margin: 0;'><a href='' target='_blank' style='color: #7c72dc;'>We&rsquo;re here, ready to talk</a></p></td></tr></table> </td></tr><tr> <td bgcolor='#ff572' align='center' style='padding: 0px 10px 0px 10px;'> <table border='0' cellpadding='0' cellspacing='0' width='480' > <tr> <td bgcolor='#f4f4f4' align='left' style='padding: 0px 30px 30px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 18px;' > <p style='margin: 0;'>You received this email because you had registered by your Social Gram Network. If you did not, please contact us.</a></p></td></tr><tr> <td bgcolor='#f4f4f4' align='CENTER' style='padding: 0px 30px 30px 30px; color: #000000; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 18px;' > <p style='margin: 10;'>Social Gram</p></td></tr></table> </td></tr></table></body></html>";
                   
                    Message.IsBodyHtml = true;
                    smtp.Send(Message);

                }
                else {
                    ViewBag.Epassword = "Enter Correct email Address";
                    return View("Index");

                }

            }
            return RedirectToAction("Index", "Login");

        }




    }
}
