using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spectrum.Model.Model;
using Spectrum.Bll.Bll;
using AutoMapper;
using Spectrum.Models;


namespace Spectrum.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();
        [HttpGet]
        public ActionResult Add()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.Categories = _categoryManager.GetAll();
            return View(categoryViewModel);

        }


        [HttpPost]
        public ActionResult Add(CategoryViewModel categoryViewModel)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                Category category = Mapper.Map<Category>(categoryViewModel);
                if (_categoryManager.Add(category))
                {
                    message = "Category Added Successfully";
                }
                else
                {
                    message = "Not Saved";
                }
            }
            else
            {
                message = "ModelState Failed";
            }

            ViewBag.Message = message;
            categoryViewModel.Categories = _categoryManager.GetAll();
            return View(categoryViewModel);
        }

        [HttpGet]
        public ActionResult Search()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.Categories = _categoryManager.GetAll();
            return View(categoryViewModel);
        }

        [HttpPost]
        public ActionResult Search(CategoryViewModel categoryViewModel)
        {
            var categories = _categoryManager.GetAll();
            if (categoryViewModel.Code != null)
            {
                categories = categories.Where(c => c.Code.Contains(categoryViewModel.Code)).ToList();
            }
            if (categoryViewModel.Name != null)
            {
                categories = categories.Where(c => c.Name.Contains(categoryViewModel.Name)).ToList();
            }

            categoryViewModel.Categories = categories;

            return View(categoryViewModel);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            var category = _categoryManager.getById(id);
            CategoryViewModel categoryViewModel = Mapper.Map<CategoryViewModel>(category);
            categoryViewModel.Categories = _categoryManager.GetAll();

            return View(categoryViewModel);

        }
        // POST: Student/Edit/5	
        [HttpPost]
        public ActionResult Edit (CategoryViewModel categoryViewModel)
        {
            string message = "";


            if (ModelState.IsValid)
            {
                Category category = Mapper.Map<Category>(categoryViewModel);

                if (_categoryManager.Update(category))
                {
                    message = "Updated";
                }
                else
                {
                    message = "Not Updated";
                }
            }
            else
            {
                message = "Update Failed";
            }

            ViewBag.Message = message;
            categoryViewModel.Categories = _categoryManager.GetAll();
            return View(categoryViewModel);
        }
        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    var category = _categoryManager.getById(id);
        //    CategoryViewModel categoryViewModel = Mapper.Map<CategoryViewModel>(category);
        //    categoryViewModel.Categories = _categoryManager.GetAll();

        //    return View(categoryViewModel);

        //}
        //[HttpPost]
        //public ActionResult Edit(CategoryViewModel categoryViewModel)
        //{
        //    string message = "";
        //    if (ModelState.IsValid)
        //    {
        //        Category category = Mapper.Map<Category>(categoryViewModel);
        //        if (_categoryManager.Update(category))
        //        {
        //            message = "Updated!";
        //        }
        //        else
        //        {
        //            message = "Not Updated";
        //        }
        //    }
        //    else
        //    {
        //        message = "ModelState Failed";
        //    }

        //    ViewBag.Message = message;
        //    categoryViewModel.Categories = _categoryManager.GetAll();
        //    return View(categoryViewModel);
        //}


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var category = _categoryManager.getById(id);
            CategoryViewModel categoryViewModel = Mapper.Map<CategoryViewModel>(category);
            categoryViewModel.Categories = _categoryManager.GetAll();

            return View(categoryViewModel);

        }
        [HttpPost]
        public ActionResult Delete(CategoryViewModel categoryViewModel)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                Category category = Mapper.Map<Category>(categoryViewModel);
                if (_categoryManager.Delete(category.Id))
                {
                    message = "Deleted!!";
                }
                else
                {
                    message = "Not Deleted";
                }
            }
            else
            {
                message = "ModelState Failed";
            }

            ViewBag.Message = message;
            categoryViewModel.Categories = _categoryManager.GetAll();
            return View(categoryViewModel);
        }
    }
}