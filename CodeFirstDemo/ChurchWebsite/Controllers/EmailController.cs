using ChurchWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ChurchWebsite.Controllers
{
    public class EmailController : Controller
    {
        private ChurchEntityPrimary db = new ChurchEntityPrimary();


        public ViewResult Index()
        {
            return View();
        }



        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Submit()
        {
            return View();
        }
        //
        // POST: /eMail/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Submit(Email email)
        {
            if (ModelState.IsValid)
            {
                db.Emails.Add(email);
                db.SaveChanges();
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("sujaysiddu@gmail.com"));  // replace with valid value 
                message.From = new MailAddress(email.Email1);  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, email.Name, email.Email1, email.Request);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "sujaymvctest@gmail.com",  //sender's username
                        Password = "sujaykodamala"  // sender's Password
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        //
        // GET: /eMail/Edit/5


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
