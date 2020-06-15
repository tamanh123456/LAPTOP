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
        public ActionResult Create(Laptop viewModel, HttpPostedFileBase fileUpload)
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
            //upload hinh anh
            var fileName = Path.GetFileName(fileUpload.FileName);
            var path = Path.Combine(Server.MapPath("~/Image_laptop"), fileName);
            if (System.IO.File.Exists(path))
            {
                ViewBag.ThongBao = "Hinh anh da ton tai";
            }
            else
            {
                fileUpload.SaveAs(path);
            }

            _dbContext.Laptops.Add(laptop);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        
        /*public ActionResult UploadImage(Laptop laptop, HttpPostedFileBase fileUpload)
        {
            var fileName = Path.GetFileName(fileUpload.FileName);
            var path = Path.Combine(Server.MapPath("~/Image_laptop"), fileName);
            if(System.IO.File.Exists(path))
            {
                ViewBag.ThongBao = "Hinh anh da ton tai";
            }
            else
            {
                fileUpload.SaveAs(path);
            }
            return View();
        }*/
        public ActionResult Edit()
        { 

            return View();
        }
        public ActionResult Delete() //chua addview
        {

            return View();
        }
    }
}