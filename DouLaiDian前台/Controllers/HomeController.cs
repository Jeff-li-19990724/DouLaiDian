using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DouLaiDian前台.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }       
        public ActionResult BoardList()
        {
            return View();
        }
        public ActionResult CuisineList()
        {
            return View();
        } 
        public ActionResult FoodList()
        {
            return View();
        }   
        public ActionResult OrderList()
        {
            return View();
        }

        readonly DouLaiDian.Models.MDF_DouLaiDian mDF = new DouLaiDian.Models.MDF_DouLaiDian();
        public ActionResult About()
        {
          
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}