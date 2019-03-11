using Audiometry2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Data;
using static Audiometry2018.Models.Datapoint;
using Newtonsoft.Json;

namespace Audiometry2018.Controllers
{
    public class HomeController : Controller
    {

        
        public ActionResult Whisper()
        {

            return View();
            
        }

        

        public ActionResult Main()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult DataUser()
        {

            return View();
        }


        public ActionResult Instruction()
        {

            return View();
        }
        public ActionResult Me()
        {

            return View();
        }
        public ActionResult test()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint(20, -15));
            dataPoints.Add(new DataPoint(40, 0));
            dataPoints.Add(new DataPoint(60, 43));
            dataPoints.Add(new DataPoint(80, 45));
            dataPoints.Add(new DataPoint(100, 10));
            dataPoints.Add(new DataPoint(120, 79));
            dataPoints.Add(new DataPoint(140, 57));
            dataPoints.Add(new DataPoint(160, 56));
            dataPoints.Add(new DataPoint(175, 58));
            

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();


            
        }
        //[HttpPost]
        //public ActionResult test(Datapoint datapoint)
        //{



        //    if (ModelState.IsValid)
        //    {
        //        using (OurDbContext db = new OurDbContext())
        //        {

        //            db.datapoint.Add(datapoint);
        //            db.SaveChanges();


        //        }
        //        ModelState.Clear();

        //    }
        //    return View();
        //}
        

        public ActionResult User()
        {

            return View();
        }
    }
}
