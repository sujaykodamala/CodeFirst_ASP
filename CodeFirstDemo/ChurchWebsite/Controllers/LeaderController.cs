using ChurchWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChurchWebsite.Controllers
{
    public class LeaderController : Controller
    {
        //
        // GET: /Leader/
        ChurchEntityPrimary db = new ChurchEntityPrimary();
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users="sujaykodamala")]
        public ActionResult Create(Leader leader)
        {
            if (leader.File.ContentLength > (2 * 1024 * 1024))
            {
                ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
                return View();
            }
            if (!(leader.File.ContentType == "image/jpeg" || leader.File.ContentType == "image/gif"))
            {
                ModelState.AddModelError("CustomError", "File type allowed : jpeg and gif");
                return View();
            }

            leader.ImageSize = leader.File.ContentLength;

            byte[] data = new byte[leader.File.ContentLength];
            leader.File.InputStream.Read(data, 0, leader.File.ContentLength);

            leader.Picture = data;
          
                db.Leaders.Add(leader);
                db.SaveChanges();
            
            return View(leader);
            
        }
        public ActionResult Leadership(Leader leader)
        {
            List<Leader> all = new List<Leader>();
          
            all = db.Leaders.ToList();
          
           return View(all.ToList());

        }
        public ActionResult MinistryLeaders(int ID)
        {
            List<Leader> leaders = db.Leaders.Where(emp => emp.MinistryID==  ID).ToList();
            
            
            return View(leaders.ToList());
        }
        }

    }


