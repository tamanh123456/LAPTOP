using LAPTOP.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAPTOP.Controllers
{
    
    public class LaptopsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private string AdminId;

        public LaptopsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        public object CategoryId { get; private set; }

        // GET: Laptops
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new Laptop
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Laptop viewModel)
        {
            if(ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }
            var laptop = new Laptop()
            {
                Id = viewModel.Id,
                AdminId = User.Identity.GetUserId(),
                CategoryId = viewModel.CategoryId,
                Ram = viewModel.Ram,
                Price = viewModel.Price,
                Image_laptop=viewModel.Image_laptop,
                CPU=viewModel.CPU
            };
            
            _dbContext.Laptops.Add(laptop);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Edit()//chua add view
        {
            return View();
        }
    }
}