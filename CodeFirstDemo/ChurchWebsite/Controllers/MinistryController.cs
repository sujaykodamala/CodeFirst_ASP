using ChurchWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChurchWebsite.Controllers
{
    public class MinistryController : Controller
    {
        //
        // GET: /Ministry/
        ChurchEntityPrimary db = new ChurchEntityPrimary();
        public List<string>  read(string FilePath)
        {
            var root = AppDomain.CurrentDomain.BaseDirectory;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(root + FilePath);
            var fileLines = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                fileLines.Add(line);
            }
            return fileLines;
        }

        public ActionResult Index()
        {
            return View(db.Ministries.ToList());
        }
      
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users="sujaykodamala")]
        public ActionResult Create(Ministry minsitry)
        {
            if (ModelState.IsValid)
            {
                db.Ministries.Add(minsitry);
                db.SaveChanges();
            }

            return View(minsitry);
        }
        public ActionResult Missions()
        {
            var data = read(@"/ContentData/Missions.html");
            ViewBag.Worship = data;
            return View();
           
        }
        public ActionResult Youth()
        {
            var data = read(@"/ContentData/Youth.html");
            ViewBag.Youth = data;
           
            return View();
        }
        public ActionResult Kids()
        {
            var data = read(@"/ContentData/Kids.html");
            ViewBag.Kids = data;

            return View();
        }
        public ActionResult Tweens()
        {
            var data = read(@"/ContentData/Tweens.txt");
            ViewBag.Tweens = data;
            return View();
        }
        public ActionResult list()
        {
           
            return View(db.Ministries.ToList());
        }

    }
}
