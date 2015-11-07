using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChurchWebsite.Controllers
{
    public class InfoController : Controller
    {
        //
        // GET: /Info/

        public List<string> read(string FilePath)
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
        public ActionResult Missions()
        {
            var data = read("/ContentData/Missions.html");
            ViewBag.Missions = data;
            return View();
        }
        public ActionResult Services()
        {

            var data = read("/ContentData/services.txt"); 
            ViewBag.File = data;
            return View();
        }
        public ActionResult Beliefs()
        {
            var data = read("/ContentData/beliefs.txt");
            ViewBag.File = data;
            return View();
        }
        public ActionResult WhatToExpect()
        {
            var data = read("/ContentData/WTE.txt");
            ViewBag.File = data;
            return View();
        }
        public ActionResult Prayer()
        {
            var data = read("/ContentData/Prayer.html");
            ViewBag.Prayer = data;
            return View();
        }
        public ActionResult Vision()
        {
            var data = read("/ContentData/Vision.txt");
            ViewBag.File = data;
            return View();
        }

    }
}
