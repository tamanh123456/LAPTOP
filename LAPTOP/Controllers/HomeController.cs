using LAPTOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace LAPTOP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public HomeController()
            {
            _dbContext = new ApplicationDbContext();
            }
        public ActionResult Index()
        {
            var upcominglaptops = _dbContext.Laptops
                .Include(c => c.Id)
                .Include(c => c.CPU)
                .Include(c => c.Ram)
                .Include(c => c.Price)
                .Include(c => c.Category)
                .Include(c => c.Image_laptop);


            return View(upcominglaptops);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}