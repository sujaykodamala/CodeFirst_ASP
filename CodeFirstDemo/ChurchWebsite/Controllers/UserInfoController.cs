using ChurchWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace ChurchWebsite.Controllers
{
    public class UserInfoController : Controller
    {
        private ChurchEntityPrimary db = new ChurchEntityPrimary();

        //
        // GET: /UserLogin/Create

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
      
        //
        // POST: /UserLogin/Create

        [HttpPost]
        public ActionResult Create(UserInfo user)
        {
            if (ModelState.IsValid)
            {
               
                string EncodedPass;
                EncodedPass = Crypto.SHA256(user.Pass);
                db.Database.ExecuteSqlCommand("insert into userinfoes(Name,email,Pass,Role) values({0},{1},{2},{3})", user.Name, user.Email, EncodedPass,user.Role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }
        public ActionResult Login()
        {
            return View();
        }

       

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
