using LAPTOP.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

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
        public ActionResult Create(Laptop viewModel, HttpPostedFileBase hinhanh)
        {
            if(!ModelState.IsValid)
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
                //Image_laptop=viewModel.Image_laptop,
                CPU=viewModel.CPU
            };
            //upload hinh anh
            if(hinhanh != null && hinhanh.ContentLength>0)
            {
                var fileName = Path.GetFileName(hinhanh.FileName);
                laptop.Image_laptop = fileName;
                var path = Path.Combine(Server.MapPath("~/Content/Image_laptop"), fileName);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hinh anh da ton tai";
                }
                else
                {
                    hinhanh.SaveAs(path);
                }
            }
            _dbContext.Laptops.Add(laptop);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        
        
        [Authorize]
        [HttpGet]

        public ActionResult Edit(string Id)
        {
            var laptop = _dbContext.Laptops.SingleOrDefault(c => c.Id == Id && c.AdminId == AdminId);
            var userId = User.Identity.GetUserId();
            
            var viewModel = new Laptop
            {
                Categories = _dbContext.Categories.ToList(),
                Category= laptop.Category,
                Id=laptop.Id,
                Ram=laptop.Ram,
                Price=laptop.Price,
                Image_laptop=laptop.Image_laptop
                
            };

            
            return View("Edit", viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Laptop  viewModel,HttpPostedFileBase hinhanh)
        {
            if(!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Edit", viewModel);
            }
            var userId = User.Identity.GetUserId();
            var laptop = _dbContext.Laptops.Single(c => c.Id == viewModel.Id && c.AdminId == userId);
            laptop.Id = viewModel.Id;
            laptop.CPU = viewModel.CPU;
            laptop.Ram = viewModel.Ram;
            laptop.Price = viewModel.Price;
            if (hinhanh != null && hinhanh.ContentLength > 0)
            {
                var fileName = Path.GetFileName(hinhanh.FileName);
                laptop.Image_laptop = fileName;
                var path = Path.Combine(Server.MapPath("~/Content/Image_laptop"), fileName);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hinh anh da ton tai";
                }
                else
                {
                    hinhanh.SaveAs(path);
                }
            }
            UpdateModel(viewModel);
            _dbContext.SaveChanges();   
            return RedirectToAction("Index","Home");
        }
        
        
    }
}